using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ContestCountyDAO : HibernateDAO<ContestCounty> {
        public ContestCountyDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(ContestCounty entity) {
            IList<Fault> retVal = new List<Fault>();

            return retVal;
        }

        public IList<ContestCounty> find(long countyID, long electionContestID) {
            IQuery query =
                getCurrentSession().CreateSQLQuery("select * from contestcounty where CountyID = " + countyID +
                                                   " and ElectionContestID = " + electionContestID + ";").AddEntity(
                    objectType);
            return query.List<ContestCounty>();
        }
    }
}