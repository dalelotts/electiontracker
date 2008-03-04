using System;
using System.Collections.Generic;
using KnightRider.ElectionTracker.db.task;
using NHibernate;
using NHibernate.Expression;
using Spring.Data.NHibernate.Generic;

namespace KnightRider.ElectionTracker.db {
    internal sealed class DelegateDAO<T> : IGenericDAO<T> {
        private static readonly IList<ICriterion> EMPTY_CRITERION = new List<ICriterion>();

        private readonly Type objectType = typeof (T);
        private readonly HibernateTemplate template;

        public DelegateDAO(HibernateTemplate template) {
            this.template = template;
        }

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
            throw new NotImplementedException();
        }

        public IList<Fault> canMakeTransient(T entity) {
            throw new NotImplementedException();
        }

        public IList<T> findByCriteria(IList<ICriterion> criterion) {
            return findByCriteria(criterion, new List<Order>());
        }

        public IList<T> findByCriteria(IList<ICriterion> criterion, IList<Order> order) {
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

        private IList<T> ExecuteFind(FindHibernateDelegate<T> findDelegate) {
            return template.ExecuteFind(findDelegate);
        }
    }
}