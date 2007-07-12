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
    internal class ContestDAO : HibernateDAO<Contest> {
        private static readonly IList<ICriterion> ACTIVE_CRITERION = new List<ICriterion>();
        private static readonly IList<Order> ORDER_BY_NAME = new List<Order>();
        private static readonly IList<ICriterion> NOT_ACTIVE_CRITERION = new List<ICriterion>();

        static ContestDAO() {
            ACTIVE_CRITERION.Add(new EqExpression("IsActive", true));
            NOT_ACTIVE_CRITERION.Add(new EqExpression("IsActive", false));
            ORDER_BY_NAME.Add(new Order("Name", true));
        }

        public ContestDAO(ISessionFactory factory) : base(factory) {}

        public IList<Contest> findActive() {
            return findByCriteria(ACTIVE_CRITERION, ORDER_BY_NAME);
        }

        public IList<Contest> findInactive() {
            return findByCriteria(NOT_ACTIVE_CRITERION, ORDER_BY_NAME);
        }


        public override IList<Contest> findAll() {
            return findByCriteria(EMPTY_CRITERION, ORDER_BY_NAME);
        }

        protected override IList<Fault> performCanMakePersistent(Contest entity) {
            List<Fault> result = new List<Fault>();

            ISession currentSession = getCurrentSession();

            IQuery validQuery =
                currentSession.CreateSQLQuery("select * from contest where contestname = '" + entity.Name +
                                              "' and contestid != " + entity.ID + ";").AddEntity(objectType);

            if (validQuery.List().Count > 0) {
                result.Add(new Fault(true, "Contest already exists"));
            }

            return result;
        }

        public override IList<Fault> canMakeTransient(Contest entity) {
            throw new NotImplementedException();
        }
    }
}