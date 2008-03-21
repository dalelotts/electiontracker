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
using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db.task;
using NHibernate;
using NHibernate.Expression;
using Spring.Data.NHibernate.Generic;

namespace KnightRider.ElectionTracker.db {
    internal class ContestDAO : IContestDAO {
        private static readonly Type contestObjectType = typeof (Contest);
        private static readonly IList<Order> ORDER_BY_NAME = new List<Order>();
        private readonly DelegateDAO<Contest> delegateDAO;

        static ContestDAO() {
            ORDER_BY_NAME.Add(new Order("Name", true));
        }

        public ContestDAO(HibernateTemplate factory) {
            delegateDAO = new DelegateDAO<Contest>(factory);
        }

        public IList<Contest> findActive() {
            return delegateDAO.findByCriteria(DelegateDAO<Contest>.ACTIVE_CRITERION, ORDER_BY_NAME);
        }

        public IList<Contest> findInactive() {
            return delegateDAO.findByCriteria(DelegateDAO<Contest>.NOT_ACTIVE_CRITERION, ORDER_BY_NAME);
        }

        public Contest findById(object id, bool lockRecord, params IDAOTask<Contest>[] tasks) {
            return delegateDAO.findById(id, lockRecord, tasks);
        }

        public IList<Contest> findAll() {
            return delegateDAO.findByCriteria(DelegateDAO<Contest>.EMPTY_CRITERION, ORDER_BY_NAME);
        }

        public Contest makePersistent(Contest entity) {
            return delegateDAO.makePersistent(entity);
        }

        public void makeTransient(Contest entity) {
            delegateDAO.makeTransient(entity);
        }

        public IList<Fault> canMakePersistent(Contest entity) {
            IList<Fault> result = delegateDAO.canMakePersistent(entity);
            FindHibernateDelegate<Contest> findDelegate = delegate(ISession session)
                                                              {
                                                                  IQuery query =
                                                                      session.CreateSQLQuery(
                                                                          "select * from contest where contestname = '" +
                                                                          entity.Name + "' and contestid != " +
                                                                          entity.ID + ";").AddEntity(contestObjectType);
                                                                  return query.List<Contest>();
                                                              };

            IList<Contest> duplicates = delegateDAO.ExecuteFind(findDelegate);

            if (duplicates.Count > 0) {
                result.Add(
                    new Fault(true, "Duplicate Contest Name: a contest named '" + entity.Name + "' already exists."));
            }

            return result;
        }

        public IList<Fault> canMakeTransient(Contest entity) {
            return delegateDAO.canMakeTransient(entity);
        }

        protected IList<Fault> performCanMakePersistent(Contest entity) {
            FindHibernateDelegate<Contest> findDelegate = delegate(ISession session)
                                                              {
                                                                  IQuery query =
                                                                      session.CreateSQLQuery(
                                                                          "select * from contest where contestname = '" +
                                                                          entity.Name + "' and contestid != " +
                                                                          entity.ID + ";").AddEntity(contestObjectType);
                                                                  return query.List<Contest>();
                                                              };

            IList<Contest> duplicates = delegateDAO.ExecuteFind(findDelegate);

            IList<Fault> result = new List<Fault>();

            if (duplicates.Count > 0) {
                result.Add(
                    new Fault(true,
                              "Duplicate Phone Number Type: a phone number type named '" + entity.Name +
                              "' already exists."));
            }

            return result;
        }
    }
}