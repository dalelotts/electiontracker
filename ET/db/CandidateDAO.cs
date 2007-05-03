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

        protected override IList<Fault> performValidation(Candidate entity)
        {
            return makeEmptyFaultList();
        }
    }
}