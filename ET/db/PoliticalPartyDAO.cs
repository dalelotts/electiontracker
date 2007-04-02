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

        public override IList<Fault> validate(PoliticalParty entity) {
            throw new NotImplementedException();
        }

        public IList<PoliticalParty> findActive() {
            return findByCriteria(ACTIVE_CRITERION, order_BY_NAME);
        }

        public IList<PoliticalParty> findInactive() {
            return findByCriteria(NOT_ACTIVE_CRITERION, order_BY_NAME);
        }
    }
}