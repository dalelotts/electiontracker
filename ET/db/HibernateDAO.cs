using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using DesignByContract;
using NHibernate;
using NHibernate.Expression;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal abstract class HibernateDAO<T> : GenericDAO<T> {
        protected static readonly IList<ICriterion> EMPTY_CRITERION = new List<ICriterion>();
        private readonly ISessionFactory factory;
        private readonly ISession session;
        protected readonly Type objectType = typeof (T);
        private readonly IList<PropertyInfo> properties;

        public HibernateDAO(ISessionFactory factory) {
            Check.Assert(factory != null, "Null:factory");
            this.factory = factory;
            session = this.factory.OpenSession();
            properties = getRequiredProperties(objectType);
        }

        protected static IList<Fault> makeEmptyFaultList() {
            List<Fault> result = new List<Fault>();
            result.Add(new Fault(false, "Validation is not implemented."));
            return result;
        }

        protected ISession getCurrentSession() {
            // sdegen - This change may cause performance issues.  If subsequent
            //  revisions show performance issues, consider reverting.  This was done 
            //  to resolve session conflicts in the vote entry form.
            if (session == null)
                return factory.OpenSession();
            return session;
        }

        public T findById(Object id, bool lockRecord) {
            return (T) session.Load(objectType, id, lockRecord ? LockMode.Upgrade : LockMode.None);
        }

        public virtual IList<T> findAll() {
            return findByCriteria(EMPTY_CRITERION);
        }

        public IList<T> findByExample(T exampleInstance, IList<String> excludedProperties) {
            Example example = Example.Create(exampleInstance);
            foreach (string property in excludedProperties) {
                example.ExcludeProperty(property);
            }
            ICriteria criteria = session.CreateCriteria(objectType);
            criteria.Add(example);
            return criteria.List<T>();
        }

        public T makePersistent(T entity) {
            ITransaction transaction = session.BeginTransaction();
            session.SaveOrUpdate(entity);
            transaction.Commit();
            return entity;
        }

        public void makeTransient(T entity) {
            ITransaction transaction = session.BeginTransaction();
            session.Delete(entity);
            transaction.Commit();
        }


        public IList<Fault> validate(T entity) {
            if (entity == null) throw new ArgumentNullException("Null: entity");
            IList<Fault> result = validateRequiredProperties(entity);
            if (result.Count == 0) {
                return performValidation(entity);
            }
            return result;
        }

        protected abstract IList<Fault> performValidation(T entity);

        protected IList<T> findByCriteria(IList<ICriterion> criterion, IList<Order> order) {
            ICriteria criteria = session.CreateCriteria(objectType);
            foreach (ICriterion expression in criterion) {
                criteria.Add(expression);
            }
            foreach (Order orderBy in order) {
                criteria.AddOrder(orderBy);
            }
            return criteria.List<T>();
        }

        protected IList<T> findByCriteria(IList<ICriterion> criterion) {
            return findByCriteria(criterion, new List<Order>());
        }

        public void flush() {
            session.Flush();
        }

        public void clear() {
            session.Clear();
        }

        private IList<Fault> validateRequiredProperties(T entity) {
            IList<Fault> result = new List<Fault>();
            foreach (PropertyInfo property in properties) {
                RequiredProperty attribute =
                    (RequiredProperty) Attribute.GetCustomAttribute(property, typeof (RequiredProperty));

                if (attribute != null) {
                    object propertyResult =
                        objectType.InvokeMember(property.Name, BindingFlags.GetProperty, binder, entity, new object[0]);

                    if (propertyResult == null) {
                        result.Add(new Fault(true, "The " + attribute.FriendlyName + " property cannot be null."));
                    } else if (typeof (string).IsAssignableFrom(propertyResult.GetType())) {
                        string resultString = (string) propertyResult;
                        if (resultString.Length == 0) {
                            result.Add(
                                new Fault(true,
                                          "The " + attribute.FriendlyName + " property cannot be a zero length string."));
                        }
                    } else if (typeof (ICollection).IsAssignableFrom(propertyResult.GetType()) &&
                               attribute.AllowEmptyList == false) {
                        ICollection collectionResult = (ICollection) propertyResult;
                        // Hack: sdegen - We are presenting in 10 minutes.
                        if (entity.GetType() != typeof(edu.uwec.cs.cs355.group4.et.core.ContestCounty))
                        {
                            if (collectionResult.Count == 0)
                            {
                                result.Add(
                                    new Fault(true,
                                              "The " + attribute.FriendlyName +
                                              " property must have one or more members."));
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