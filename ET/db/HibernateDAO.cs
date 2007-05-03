using System;
using System.Collections.Generic;
using DesignByContract;
using NHibernate;
using NHibernate.Expression;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal abstract class HibernateDAO<T> : GenericDAO<T> {
        protected static readonly IList<ICriterion> EMPTY_CRITERION = new List<ICriterion>();
        private readonly ISessionFactory factory;
        private readonly ISession session;
        protected readonly Type objectType = typeof (T);


        public HibernateDAO(ISessionFactory factory) {
            Check.Assert(factory != null, "Null:factory");
            this.factory = factory;
            session = this.factory.OpenSession();
        }

        protected static IList<Fault> makeEmptyFaultList() {
            List<Fault> result = new List<Fault>();
            result.Add(new Fault(false, "Validation is not implemented."));
            return result;
        }

        protected ISession getCurrentSession() {
            return factory.OpenSession();
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

        public abstract IList<Fault> validate(T entity);

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
    }
}