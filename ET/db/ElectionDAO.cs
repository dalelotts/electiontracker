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
using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db.task;
using NHibernate.Expression;
using Spring.Data.NHibernate.Generic;
using Spring.Transaction.Interceptor;

namespace KnightRider.ElectionTracker.db {
    internal class ElectionDAO : IElectionDAO {
        private static readonly IList<ICriterion> ACTIVE_CRITERION = new List<ICriterion>();
        private static readonly IList<Order> ORDER_BY_ELECTION_DATE = new List<Order>();
        private static readonly IList<ICriterion> NOT_ACTIVE_CRITERION = new List<ICriterion>();
        private readonly DelegateDAO<Election> delegateDAO;

        static ElectionDAO() {
            ACTIVE_CRITERION.Add(new EqExpression("IsActive", true));
            NOT_ACTIVE_CRITERION.Add(new EqExpression("IsActive", false));
            ORDER_BY_ELECTION_DATE.Add(new Order("Date", false));
        }

        public ElectionDAO(HibernateTemplate factory) {
            this.delegateDAO = new DelegateDAO<Election>(factory);
        }

        [Transaction(ReadOnly = true)]
        public IList<Election> findActive() {
            return delegateDAO.findByCriteria(ACTIVE_CRITERION, ORDER_BY_ELECTION_DATE);
        }

        [Transaction(ReadOnly = true)]
        public IList<Election> findInactive() {
            return delegateDAO.findByCriteria(NOT_ACTIVE_CRITERION, ORDER_BY_ELECTION_DATE);
        }

        [Transaction(ReadOnly = true)]
        public Election findById(object id, bool lockRecord, params IDAOTask<Election>[] tasks) {
            return delegateDAO.findById(id, lockRecord, tasks);
        }

        [Transaction(ReadOnly = true)]
        public IList<Election> findAll() {
            return delegateDAO.findAll();
        }

        [Transaction(ReadOnly = false)]
        public Election makePersistent(Election entity) {
            return delegateDAO.makePersistent(entity);
        }

        [Transaction(ReadOnly = false)]
        public void makeTransient(Election entity) {
            delegateDAO.makeTransient(entity);
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakePersistent(Election entity) {
            return delegateDAO.canMakePersistent(entity);
        }

        [Transaction(ReadOnly = true)]
        public IList<Fault> canMakeTransient(Election entity) {
            return delegateDAO.canMakeTransient(entity);
        }
    }
}