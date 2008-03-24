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
using Spring.Transaction.Interceptor;

namespace KnightRider.ElectionTracker.db {
    public class CandidateDAO : ICandidateDAO {
        private static readonly IList<Order> ORDER_BY_LAST_FIRST_NAME = new List<Order>();

        private readonly DelegateDAO<Candidate> delegateDAO;
        private static readonly Type objectType = typeof (Candidate);

        static CandidateDAO() {
            ORDER_BY_LAST_FIRST_NAME.Add(new Order("LastName", true));
            ORDER_BY_LAST_FIRST_NAME.Add(new Order("FirstName", true));
        }

        public CandidateDAO(HibernateTemplate factory) {
            delegateDAO = new DelegateDAO<Candidate>(factory);
        }

        [Transaction(ReadOnly = true)]
        public IList<Candidate> findAll() {
            return delegateDAO.findByCriteria(DelegateDAO<Candidate>.EMPTY_CRITERION, ORDER_BY_LAST_FIRST_NAME);
        }

        [Transaction(ReadOnly = true)]
        public IList<Candidate> findActive() {
            return delegateDAO.findByCriteria(DelegateDAO<Candidate>.ACTIVE_CRITERION, ORDER_BY_LAST_FIRST_NAME);
        }

        [Transaction(ReadOnly = true)]
        public IList<Candidate> findInactive() {
            return delegateDAO.findByCriteria(DelegateDAO<Candidate>.NOT_ACTIVE_CRITERION, ORDER_BY_LAST_FIRST_NAME);
        }

        [Transaction(ReadOnly = true)]
        public Candidate findById(object id, bool lockRecord, params IDAOTask<Candidate>[] tasks) {
            return delegateDAO.findById(id, lockRecord, tasks);
        }

        [Transaction(ReadOnly = false)]
        public Candidate makePersistent(Candidate entity) {
            return delegateDAO.makePersistent(entity);
        }

        [Transaction(ReadOnly = false)]
        public void makeTransient(Candidate entity) {
            delegateDAO.makeTransient(entity);
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakePersistent(Candidate entity) {
            IList<Fault> result = delegateDAO.canMakePersistent(entity);

            FindHibernateDelegate<Candidate> findDelegate = delegate(ISession session)
                                                                {
                                                                    IQuery query = session.CreateSQLQuery("select * from candidate where CandidateFirstName = '" + entity.FirstName + "' and CandidateLastName = '" + entity.LastName + "' and CandidateID != " + entity.ID + ";").AddEntity(objectType);
                                                                    return query.List<Candidate>();
                                                                };

            IList<Candidate> duplicates = delegateDAO.ExecuteFind(findDelegate);


            if (duplicates.Count > 0) {
                result.Add(new Fault(true, "Duplicate Candidate: a candidate named '" + entity + "' already exists."));
            }
            return result;
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakeTransient(Candidate entity) {
            return delegateDAO.canMakeTransient(entity);
        }
    }
}