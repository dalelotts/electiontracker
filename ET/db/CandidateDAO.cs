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

        protected override IList<Fault> performValidation(Candidate entity) {
            List<Fault> result = new List<Fault>();


            if (entity == null) {
                result.Add(new Fault(true, "Candidate is null."));
            } else {
                if (entity.LastName == null) {
                    result.Add(new Fault(true, "Candidate last name is null."));
                } else if (entity.LastName == "") {
                    result.Add(new Fault(true, "Candidate last name is empty."));
                }

                if (entity.FirstName == null) {
                    result.Add(new Fault(true, "Candidate first name is null."));
                } else if (entity.FirstName == "") {
                    result.Add(new Fault(true, "Candidate first name is empty."));
                }

                if (result.Count == 0) {
                    ISession currentSession = getCurrentSession();

                    // TODO: This checks First name and Last name right now as the only identifiers
                    // Might want to do a findall() and see if the 'entity' is listed in the return
                    IQuery validQuery =
                        currentSession.CreateSQLQuery("select * from candidate where FirstName = " + entity.FirstName +
                                                      " and LastName = " + entity.LastName + ";");
                    if (validQuery.List().Count > 0) {
                        result.Add(new Fault(true, "Candidate already exists"));
                    }
                }
            }

            return result;
        }
    }
}