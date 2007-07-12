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
    internal sealed class PoliticalPartyDAO : HibernateDAO<PoliticalParty> {
        private static readonly IList<ICriterion> ACTIVE_CRITERION = new List<ICriterion>();
        private static readonly IList<Order> order_BY_NAME = new List<Order>();
        private static readonly IList<ICriterion> NOT_ACTIVE_CRITERION = new List<ICriterion>();

        static PoliticalPartyDAO() {
            ACTIVE_CRITERION.Add(new EqExpression("IsActive", true));
            NOT_ACTIVE_CRITERION.Add(new EqExpression("IsActive", false));
            order_BY_NAME.Add(new Order("Name", true));
        }

        public PoliticalPartyDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performCanMakePersistent(PoliticalParty entity) {
            List<Fault> retVal = new List<Fault>();

            ISession currentSession = getCurrentSession();

            IQuery validQuery =
                currentSession.CreateSQLQuery("select * from politicalparty pp where pp.politicalpartyname = '" +
                                              entity.Name + "' and pp.politicalpartyid != " + entity.ID + ";").AddEntity
                    (objectType);
            if (validQuery.List().Count > 0) {
                retVal.Add(new Fault(true, "Name entered for Political Party already exists"));
            }

            validQuery =
                currentSession.CreateSQLQuery("select * from politicalparty where PoliticalPartyAbbrev = '" +
                                              entity.Abbreviation + "' and PoliticalPartyID != " + entity.ID + ";").
                    AddEntity(objectType);
            if (validQuery.List().Count > 0) {
                retVal.Add(new Fault(true, "Abbreviation entered for Political Party already exists"));
            }


            return retVal;
        }

        public IList<PoliticalParty> findActive() {
            return findByCriteria(ACTIVE_CRITERION, order_BY_NAME);
        }

        public IList<PoliticalParty> findInactive() {
            return findByCriteria(NOT_ACTIVE_CRITERION, order_BY_NAME);
        }

        public override IList<Fault> canMakeTransient(PoliticalParty entity) {
            throw new NotImplementedException();
        }
    }
}