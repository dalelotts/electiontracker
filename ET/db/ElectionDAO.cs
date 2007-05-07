using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using NHibernate.Expression;
using System;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ElectionDAO : HibernateDAO<Election> {
        private static readonly IList<ICriterion> ACTIVE_CRITERION = new List<ICriterion>();
        private static readonly IList<Order> ORDER_BY_ELECTION_DATE = new List<Order>();
        private static readonly IList<ICriterion> NOT_ACTIVE_CRITERION = new List<ICriterion>();

        static ElectionDAO() {
            ACTIVE_CRITERION.Add(new EqExpression("IsActive", true));
            NOT_ACTIVE_CRITERION.Add(new EqExpression("IsActive", false));
            ORDER_BY_ELECTION_DATE.Add(new Order("Date", false));
        }

        public ElectionDAO(ISessionFactory factory) : base(factory) {}

        public IList<Election> findActive() {
            return findByCriteria(ACTIVE_CRITERION, ORDER_BY_ELECTION_DATE);
        }

        public IList<Election> findInactive() {
            return findByCriteria(NOT_ACTIVE_CRITERION, ORDER_BY_ELECTION_DATE);
        }

        protected override IList<Fault> performValidation(Election entity) {
            IList<Fault> retVal = new List<Fault>();

            return retVal;
        }

        public IList<County> findCounties(Election e)
        {
            IQuery iqQuery = getCurrentSession().CreateSQLQuery("select c.CountyID, c.CountyName, c.CountyNotes, c.CountyWardCount from election e left join ElectionContest ec on (ec.ElectionID = e.ElectionID) left join ContestCounty cc on (ec.ElectionContestID = cc.ElectionContestID) left join County c on (cc.CountyID = c.CountyID) where e.ElectionID = " + e.ID + ";").AddEntity(typeof(County));
            return iqQuery.List<County>();
        }
    }
}