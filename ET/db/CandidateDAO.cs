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
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using NHibernate.Expression;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class CandidateDAO : HibernateDAO<Candidate> {
        private static readonly IList<ICriterion> ACTIVE_CRITERION = new List<ICriterion>();
        private static readonly IList<Order> ORDER_BY_LAST_FIRST_NAME = new List<Order>();
        private static readonly IList<ICriterion> NOT_ACTIVE_CRITERION = new List<ICriterion>();

        static CandidateDAO() {
            ACTIVE_CRITERION.Add(new EqExpression("IsActive", true));
            NOT_ACTIVE_CRITERION.Add(new EqExpression("IsActive", false));
            ORDER_BY_LAST_FIRST_NAME.Add(new Order("LastName", true));
            ORDER_BY_LAST_FIRST_NAME.Add(new Order("FirstName", true));
        }

        public CandidateDAO(ISessionFactory factory) : base(factory) {}


        public IList<Candidate> findActive() {
            return findByCriteria(ACTIVE_CRITERION, ORDER_BY_LAST_FIRST_NAME);
        }

        public IList<Candidate> findInactive() {
            return findByCriteria(NOT_ACTIVE_CRITERION, ORDER_BY_LAST_FIRST_NAME);
        }


        public override IList<Candidate> findAll() {
            return findByCriteria(EMPTY_CRITERION, ORDER_BY_LAST_FIRST_NAME);
        }

        protected override IList<Fault> performCanMakePersistent(Candidate entity) {
            List<Fault> result = new List<Fault>();

            ISession currentSession = getCurrentSession();

            // TODO: This checks First name and Last name right now as the only identifiers
            // Might want to do a findall() and see if the 'entity' is listed in the return
            IQuery validQuery =
                currentSession.CreateSQLQuery("select * from candidate where CandidateFirstName = '" + entity.FirstName +
                                              "' and CandidateLastName = '" + entity.LastName + "' and CandidateID != " +
                                              entity.ID + ";").AddEntity(objectType);
            if (validQuery.List().Count > 0) {
                result.Add(new Fault(true, "Candidate already exists"));
            }

            return result;
        }

        public override IList<Fault> canMakeTransient(Candidate entity) {
            return new List<Fault>();
        }
    }
}