using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using KnightRider.ElectionTracker.db.task;
using KnightRider.ElectionTracker.util;
using NHibernate;
using NHibernate.Expression;
using Spring.Data.NHibernate.Generic;

namespace KnightRider.ElectionTracker.db {
    internal sealed class DelegateDAO<T> : IGenericDAO<T> {
        public static readonly IList<ICriterion> ACTIVE_CRITERION = new List<ICriterion>();
        public static readonly IList<ICriterion> EMPTY_CRITERION = new List<ICriterion>();
        public static readonly IList<ICriterion> NOT_ACTIVE_CRITERION = new List<ICriterion>();

        private static readonly Map<Type, IList<PropertyInfo>> TYPE_TO_REQUIRED_PROPERTIES =
            new Map<Type, IList<PropertyInfo>>();

        private static readonly CustomBinder BINDER = new CustomBinder();
        private static readonly Type STRING_TYPE = typeof (string);

        static DelegateDAO() {
            ACTIVE_CRITERION.Add(new EqExpression("IsActive", true));
            NOT_ACTIVE_CRITERION.Add(new EqExpression("IsActive", false));
        }

        private readonly Type objectType = typeof (T);
        private readonly HibernateTemplate template;


        public DelegateDAO(HibernateTemplate template) {
            this.template = template;
            if (!TYPE_TO_REQUIRED_PROPERTIES.ContainsKey(objectType)) {
                TYPE_TO_REQUIRED_PROPERTIES.Add(objectType, getRequiredProperties(objectType));
            }
        }

        public T findById(Object id, bool lockRecord, params IDAOTask<T>[] tasks) {
            T result = template.Get<T>(id, lockRecord ? LockMode.Upgrade : LockMode.None);
            performTasks(tasks, result);
            return result;
        }

        public void performTasks(IDAOTask<T>[] tasks, T entity) {
            if (tasks.Length > 0) {
                for (int i = 0; i < tasks.Length; i++) {
                    IDAOTask<T> task = tasks[i];
                    task.perform(entity);
                }
            }
        }

        public void performTasks(IDAOTask<T>[] tasks, IList<T> entities) {
            if (tasks.Length > 0) {
                for (int i = 0; i < entities.Count; i++) {
                    T entity = entities[i];
                    performTasks(tasks, entity);
                }
            }
        }

        public IList<T> findAll() {
            return findByCriteria(EMPTY_CRITERION);
        }


        public T makePersistent(T entity) {
            return (T) template.SaveOrUpdateCopy(entity);
        }


        public void makeTransient(T entity) {
            template.Delete(entity);
        }

        public IList<Fault> canMakePersistent(T entity) {
            if (entity == null) throw new ArgumentNullException("Null: entity");
            return validateRequiredProperties(entity, objectType);
        }

        public IList<Fault> canMakeTransient(T entity) {
            IList<Fault> result = new List<Fault>();
            result.Add(
                new Fault(false,
                          "Are you sure you want to perminantly delete this " + objectType.Name + " (" + entity +
                          ") ? \nNOTE: You cannot undo a delete, the data is perminantly deleted."));

            return result;
        }

        public IList<T> findByCriteria(IList<ICriterion> criterion, params IDAOTask<T>[] tasks) {
            IList<T> result = findByCriteria(criterion, new List<Order>());
            performTasks(tasks, result);
            return result;
        }

        public IList<T> findByCriteria(IList<ICriterion> criterion, IList<Order> order, params IDAOTask<T>[] tasks) {
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
            IList<T> result = ExecuteFind(findDelegate);
            performTasks(tasks, result);
            return result;
        }

        public IList<T> ExecuteFind(FindHibernateDelegate<T> findDelegate) {
            return template.ExecuteFind(findDelegate);
        }

        private static IList<Fault> validateRequiredProperties(T entity, Type objectType) {
            IList<Fault> result = new List<Fault>();
            IList<PropertyInfo> properties = TYPE_TO_REQUIRED_PROPERTIES.Get(objectType);

            foreach (PropertyInfo property in properties) {
                RequiredProperty attribute =
                    (RequiredProperty) Attribute.GetCustomAttribute(property, typeof (RequiredProperty));

                if (attribute != null) {
                    object propertyResult =
                        objectType.InvokeMember(property.Name, BindingFlags.GetProperty, BINDER, entity, new object[0]);

                    if (propertyResult == null) {
                        result.Add(new Fault(true, "The " + attribute.FriendlyName + " property cannot be null."));
                    } else if (STRING_TYPE.IsAssignableFrom(propertyResult.GetType())) {
                        string resultString = (string) propertyResult;
                        if (resultString.Length == 0) {
                            result.Add(
                                new Fault(true,
                                          "The " + attribute.FriendlyName + " property cannot be a zero length string."));
                        } else if (resultString.Length < attribute.minLength) {
                            string message = "The " + attribute.FriendlyName + " property must be a minimum of " +
                                             attribute.minLength + " characters.";
                            if (attribute.example != null) message = message + " For example: " + attribute.example;
                            result.Add(new Fault(true, message));
                        } else if (resultString.Length > attribute.maxLength) {
                            string message = "The " + attribute.FriendlyName + " property cannot be greater than " +
                                             attribute.minLength + " characters.";
                            if (attribute.example != null) message = message + " For example: " + attribute.example;
                            result.Add(new Fault(true, message));
                        }
                    } else if (typeof (ICollection).IsAssignableFrom(propertyResult.GetType()) &&
                               attribute.AllowEmptyList == false) {
                        ICollection collectionResult = (ICollection) propertyResult;
                        if (collectionResult.Count == 0) {
                            result.Add(
                                new Fault(true,
                                          "The " + attribute.FriendlyName +
                                          " property must have one or more members."));
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


        private class CustomBinder : Binder {
            public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, ref object[] args,
                                                    ParameterModifier[] modifiers, CultureInfo culture, string[] names,
                                                    out object state) {
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

            public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, object value,
                                                  CultureInfo culture) {
                throw new NotImplementedException();
            }

            public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, Type[] types,
                                                    ParameterModifier[] modifiers) {
                throw new NotImplementedException();
            }

            public override PropertyInfo SelectProperty(BindingFlags bindingAttr, PropertyInfo[] match, Type returnType,
                                                        Type[] indexes, ParameterModifier[] modifiers) {
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