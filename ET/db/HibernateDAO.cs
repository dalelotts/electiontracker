/**
 *  Copyright (C) 2007 Knight Rider Consulting, Inc.
 *  support@knightrider.com
 *  http://www.knightrider.com
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see http://www.gnu.org/licenses/
 **/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using DesignByContract;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db.task;
using NHibernate;
using NHibernate.Expression;
using Spring.Data.NHibernate.Generic;

namespace KnightRider.ElectionTracker.db {
    internal abstract class HibernateDAO<T> : IGenericDAO<T> {
        private readonly HibernateTemplate template;
        protected static readonly IList<ICriterion> EMPTY_CRITERION = new List<ICriterion>();
        protected readonly Type objectType = typeof (T);
        private readonly IList<PropertyInfo> properties;
        private static readonly IList<ICriterion> ACTIVE_CRITERION = new List<ICriterion>();
        private static readonly IList<ICriterion> NOT_ACTIVE_CRITERION = new List<ICriterion>();

        static HibernateDAO() {
            ACTIVE_CRITERION.Add(new EqExpression("IsActive", true));
            NOT_ACTIVE_CRITERION.Add(new EqExpression("IsActive", false));
        }

        public HibernateDAO(HibernateTemplate template) {
            Check.Assert(template != null, "Null:template");
            this.template = template;
            properties = getRequiredProperties(objectType);
        }

        protected static IList<Fault> makeEmptyFaultList() {
            List<Fault> result = new List<Fault>();
            result.Add(new Fault(false, "Validation is not implemented."));
            return result;
        }

        // [Transaction(ReadOnly = true)]
        public T findById(Object id, bool lockRecord, params IDAOTask<T>[] tasks) {
            T result = template.Get<T>(id, lockRecord ? LockMode.Upgrade : LockMode.None);
            performTasks(tasks, result);
            return result;
        }


        private static void performTasks(IDAOTask<T>[] tasks, T entity) {
            if (tasks.Length > 0) {
                //template.Lock(entity, LockMode.None);
                for (int i = 0; i < tasks.Length; i++) {
                    IDAOTask<T> task = tasks[i];
                    task.perform(entity);
                }
            }
        }

        // [Transaction(ReadOnly = false)]
        public virtual IList<T> findAll() {
            return findByCriteria(EMPTY_CRITERION);
        }

        // [Transaction(ReadOnly = false)]
        public T makePersistent(T entity) {
            return (T) template.SaveOrUpdateCopy(entity);
        }

        // [Transaction(ReadOnly = false)]
        public void makeTransient(T entity) {
            template.Delete(entity);
        }

        // [Transaction(ReadOnly = true)]
        public IList<Fault> canMakePersistent(T entity) {
            if (entity == null) throw new ArgumentNullException("Null: entity");
            IList<Fault> result = validateRequiredProperties(entity);
            if (result.Count == 0) {
                return performCanMakePersistent(entity);
            }
            return result;
        }

        public abstract IList<Fault> canMakeTransient(T entity);

        protected abstract IList<Fault> performCanMakePersistent(T entity);

        // [Transaction(ReadOnly = false)]
        protected IList<T> findByCriteria(IList<ICriterion> criterion, IList<Order> order) {
            FindHibernateDelegate<T> findDelegate = delegate(ISession session)
                                                        {
                                                            ICriteria criteria = session.CreateCriteria(objectType);
                                                            foreach (ICriterion expression in criterion) {
                                                                criteria.Add(expression);
                                                            }
                                                            foreach (Order orderBy in order) {
                                                                criteria.AddOrder(orderBy);
                                                            }
                                                            return criteria.List<T>();
                                                        };
            return ExecuteFind(findDelegate);
        }

        // [Transaction(ReadOnly = false)]
        protected IList<T> ExecuteFind(FindHibernateDelegate<T> findDelegate) {
            return template.ExecuteFind(findDelegate);
        }

        // [Transaction(ReadOnly = false)]
        protected U Execute<U>(HibernateDelegate<U> findDelegate) {
            return template.Execute(findDelegate);
        }

        // [Transaction(ReadOnly = false)]
        protected IList<T> findByCriteria(IList<ICriterion> criterion) {
            return findByCriteria(criterion, new List<Order>());
        }

        // [Transaction(ReadOnly = false)]
        private IList<Fault> validateRequiredProperties(T entity) {
            IList<Fault> result = new List<Fault>();
            foreach (PropertyInfo property in properties) {
                RequiredProperty attribute = (RequiredProperty) Attribute.GetCustomAttribute(property, typeof (RequiredProperty));

                if (attribute != null) {
                    object propertyResult = objectType.InvokeMember(property.Name, BindingFlags.GetProperty, binder, entity, new object[0]);

                    if (propertyResult == null) {
                        result.Add(new Fault(true, "The " + attribute.FriendlyName + " property cannot be null."));
                    } else if (typeof (string).IsAssignableFrom(propertyResult.GetType())) {
                        string resultString = (string) propertyResult;
                        if (resultString.Length == 0) {
                            result.Add(new Fault(true, "The " + attribute.FriendlyName + " property cannot be a zero length string."));
                        }
                    } else if (typeof (ICollection).IsAssignableFrom(propertyResult.GetType()) && attribute.AllowEmptyList == false) {
                        ICollection collectionResult = (ICollection) propertyResult;
                        // Hack: sdegen - We are presenting in 10 minutes.
                        if (entity.GetType() != typeof (ContestCounty)) {
                            if (collectionResult.Count == 0) {
                                result.Add(new Fault(true, "The " + attribute.FriendlyName + " property must have one or more members."));
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static IList<PropertyInfo> getRequiredProperties(Type objectType) {
            IList<PropertyInfo> result = new List<PropertyInfo>();
            PropertyInfo[] properties = objectType.GetProperties();
            for (int i = 0; i < properties.Length; i++) {
                PropertyInfo info = properties[i];
                Attribute attribute = Attribute.GetCustomAttribute(info, typeof (RequiredProperty));
                if (attribute != null) {
                    result.Add(info);
                }
            }
            return result;
        }

        private readonly CustomBinder binder = new CustomBinder();

        private class CustomBinder : Binder {
            public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, ref object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] names, out object state) {
                if (match == null)
                    throw new ArgumentNullException("match");
                // Arguments are not being reordered.
                state = null;
                // Find a parameter match and return the first method with
                // parameters that match the request.
                foreach (MethodBase mb in match) {
                    ParameterInfo[] parameters = mb.GetParameters();
                    if (ParametersMatch(parameters, args))
                        return mb;
                }
                return null;
            }

            // Returns true only if the type of each object in a matches
            // the type of each corresponding object in b.
            private static bool ParametersMatch(ParameterInfo[] a, object[] b) {
                if (a.Length != b.Length)
                    return false;
                for (int i = 0; i < a.Length; i++) {
                    if (a[i].ParameterType != b[i].GetType())
                        return false;
                }
                return true;
            }

            public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, object value, CultureInfo culture) {
                throw new NotImplementedException();
            }

            public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, Type[] types, ParameterModifier[] modifiers) {
                throw new NotImplementedException();
            }

            public override PropertyInfo SelectProperty(BindingFlags bindingAttr, PropertyInfo[] match, Type returnType, Type[] indexes, ParameterModifier[] modifiers) {
                if (match == null)
                    throw new ArgumentNullException("match");
                foreach (PropertyInfo pi in match) {
                    if (pi.GetType() == returnType && ParametersMatch(pi.GetIndexParameters(), indexes))
                        return pi;
                }
                return null;
            }

            public override object ChangeType(object value, Type type, CultureInfo culture) {
                throw new NotImplementedException();
            }

            public override void ReorderArgumentArray(ref object[] args, object state) {
                throw new NotImplementedException();
            }
        }
    }
}