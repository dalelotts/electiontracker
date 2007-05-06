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

        protected override IList<Fault> performValidation(Contest entity) {
            List<Fault> result = new List<Fault>();

            if (entity == null) {
                result.Add(new Fault(true, "Contest is null."));
            } else {
                if (entity.Name == null) {
                    result.Add(new Fault(true, "Contest name is null."));
                } else if (entity.Name == "") {
                    result.Add(new Fault(true, "Contest name is empty."));
                }
                if (entity.ContestType == null) {
                    result.Add(new Fault(true, "Contest type is null."));
                }
                if (result.Count == 0) {
                    ISession currentSession = getCurrentSession();

                    IQuery validQuery =
                        currentSession.CreateSQLQuery("select * from contest where name = " + entity.Name + ";");

                    if (validQuery.List().Count > 0) {
                        result.Add(new Fault(true, "Contest already exists"));
                    }
                }
            }


            return result;
        }

        public IList<Candidate> findCandidates() {
            IList<Candidate> lstCandidates = new List<Candidate>();
            Candidate cd = new Candidate();
            cd.FirstName = "George";
            cd.LastName = "Bush";
            lstCandidates.Add(cd);
            cd = new Candidate();
            cd.FirstName = "John";
            cd.LastName = "Kerry";
            lstCandidates.Add(cd);
            return lstCandidates;
        }
    }
}