using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ContestCountyDAO : HibernateDAO<ContestCounty> {
        public ContestCountyDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(ContestCounty entity)
        {
            IList<Fault> retVal = new List<Fault>();

            if (entity == null)
            {
                retVal.Add(new Fault(true, "ResponseValue is null."));
            }
            else
            {
                if (entity.County == null)
                {
                    retVal.Add(new Fault(true, "County in ContestCounty is null."));
                }

                if (entity.ElectionContest == null)
                {
                    retVal.Add(new Fault(true, "ElectionContest in ContestCounty is null."));
                }

                if (entity.ResponseValues == null)
                {
                    retVal.Add(new Fault(true, "ResponseValues in ContestCounty is null."));
                }
                else if (entity.ResponseValues.Count < 1)
                {
                    retVal.Add(new Fault(false, "ResponseValues in ContestCounty is empty."));
                }

            }




            return retVal;
        }

        public IList<ContestCounty> find(long countyID, long electionContestID) {
            IQuery query = getCurrentSession().CreateSQLQuery("select * from contestcounty where CountyID = " + countyID + " and ElectionContestID = " + electionContestID + ";").AddEntity(objectType);
            return query.List<ContestCounty>();
        }
    }


}