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
using NHibernate;
using NHibernate.Expression;
using Spring.Data.NHibernate.Generic;
using Spring.Transaction.Interceptor;

namespace KnightRider.ElectionTracker.db {
    internal class ContestDAO : HibernateDAO<Contest> {
        private static readonly IList<ICriterion> ACTIVE_CRITERION = new List<ICriterion>();
        private static readonly IList<Order> ORDER_BY_NAME = new List<Order>();
        private static readonly IList<ICriterion> NOT_ACTIVE_CRITERION = new List<ICriterion>();

        static ContestDAO() {
            ACTIVE_CRITERION.Add(new EqExpression("IsActive", true));
            NOT_ACTIVE_CRITERION.Add(new EqExpression("IsActive", false));
            ORDER_BY_NAME.Add(new Order("Name", true));
        }

        public ContestDAO(HibernateTemplate factory) : base(factory) {}

        // [Transaction(ReadOnly = true)]
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
            FindHibernateDelegate<Contest> findDelegate = delegate(ISession session)
                                                              {
                                                                  IQuery query =
                                                                      session.CreateSQLQuery(
                                                                          "select * from contest where contestname = '" +
                                                                          entity.Name + "' and contestid != " +
                                                                          entity.ID + ";").AddEntity(objectType);
                                                                  return query.List<Contest>();
                                                              };

            IList<Contest> duplicates = ExecuteFind(findDelegate);

            IList<Fault> result = new List<Fault>();

            if (duplicates.Count > 0) {
                result.Add(
                    new Fault(true,
                              "Duplicate Phone Number Type: a phone number type named '" + entity.Name +
                              "' already exists."));
            }

            return result;
        }

        public override IList<Fault> canMakeTransient(Contest entity) {
            return new List<Fault>();
        }
    }
}