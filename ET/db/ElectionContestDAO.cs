using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using log4net;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db
{
    internal class ElectionContestDAO : HibernateDAO<ElectionContest>
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (ElectionContestDAO));

        // TODO: We will have to enter more Hibernate stuff here in order to get
        // the election creation to work.  We will need to persist new ElectionContests.
        public ElectionContestDAO(ISessionFactory factory) : base(factory) {}

        public IList<ElectionContest> findContests(County c)
        {
            IQuery iqQuery = getCurrentSession().CreateSQLQuery("select ec.ElectionContestID, ec.ElectionID, ec.ContestID from ElectionContest ec left join ContestCounty cc on (cc.ElectionContestID = ec.ElectionContestID) where cc.countyID =" + c.ID + ";").AddEntity(typeof(ElectionContest));
            return iqQuery.List<ElectionContest>();
        }

        public ContestCounty findContestCounty(County c, ElectionContest elec)
        {
            IQuery iqQuery = getCurrentSession().CreateSQLQuery("select * from contestcounty where CountyID = " + c.ID + " and ElectionContestID = " + elec.ID + ";").AddEntity(typeof(ContestCounty));
            IList<ContestCounty> lstCC = iqQuery.List<ContestCounty>();
            if (lstCC.Count > 0){
                return lstCC[0];
            }
            else{
                LOG.Debug("ElectionContestDAO.findContestCounty(" + c.ID + "," + elec.ID + ") failed!");
                return null;
            }
        }

        public IList<Response> findResponses(ElectionContest e)
        {
            IQuery iqQuery = getCurrentSession().CreateSQLQuery("select cr.ResponseID, cr.CandidateID from CandidateResponse cr join Response r on (r.ResponseID = cr.ResponseID) where r.ElectionContestID = " + e.ID + ";").AddEntity(typeof(CandidateResponse));
            // TODO: Currently only selects Candidate Responses.  Select CustomResponses as well.
            return iqQuery.List<Response>();
        }

        public int findVoteCount(Response r,ContestCounty c){
            IQuery iqQuery = getCurrentSession().CreateSQLQuery("select rv.ResponseValueID, rv.VoteCount, rv.ResponseID, rv.ContestCountyID from ResponseValue rv where rv.ResponseID = " + r.ID + " and rv.ContestCountyID = " + c.ID + ";").AddEntity(typeof(ResponseValue));
            IList<ResponseValue> lstRV = iqQuery.List<ResponseValue>();
            if (lstRV.Count > 0){
                return lstRV[0].VoteCount;
            }
            else{
                return 0;
            }
        }

        public override IList<Fault> validate(ElectionContest entity)
        {
            return makeEmptyFaultList();
        }
    }
}
