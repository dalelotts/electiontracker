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
using Common.Logging;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using Spring.Data.NHibernate.Generic;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ElectionContestDAO : HibernateDAO<ElectionContest> {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (ElectionContestDAO));

        public ElectionContestDAO(HibernateTemplate factory) : base(factory) {}

//        public IList<ElectionContest> findContests(County c) {
//            FindHibernateDelegate<ElectionContest> findDelegate = delegate(ISession session)
//                                                                      {
//                                                                          IQuery query =
//                                                                              session.CreateSQLQuery(
//                                                                                  "select ec.ElectionContestID, ec.ElectionID, ec.ContestID from ElectionContest ec left join ContestCounty cc on (cc.ElectionContestID = ec.ElectionContestID) where cc.countyID =" +
//                                                                                  c.ID + ";").AddEntity(
//                                                                                  typeof (ElectionContest));
//                                                                          return query.List<ElectionContest>();
//                                                                      };
//
//            return ExecuteFind(findDelegate);
//        }
//
//        public ContestCounty findContestCounty(County c, ElectionContest elec) {
//            HibernateDelegate<ContestCounty> findDelegate = delegate(ISession session)
//                                                                {
//                                                                    IQuery query =
//                                                                        session.CreateSQLQuery(
//                                                                            "select ec.ElectionContestID, ec.ElectionID, ec.ContestID from ElectionContest ec left join ContestCounty cc on (cc.ElectionContestID = ec.ElectionContestID) where cc.countyID =" +
//                                                                            c.ID + ";").AddEntity(typeof (ContestCounty));
//                                                                    return query.UniqueResult<ContestCounty>();
//                                                                };
//
//            return Execute(findDelegate);
//        }
//
//        public IList<Response> findResponses(ElectionContest e) {
//            FindHibernateDelegate<Response> findDelegate = delegate(ISession session)
//                                                                      {
//                                                                          IQuery query =
//                                                                              session.CreateSQLQuery(
//                                                                                  "select ec.ElectionContestID, ec.ElectionID, ec.ContestID from ElectionContest ec left join ContestCounty cc on (cc.ElectionContestID = ec.ElectionContestID) where cc.countyID =" +
//                                                                                  c.ID + ";").AddEntity(
//                                                                                  typeof(Response));
//                                                                          return query.List<Response>();
//                                                                      };
//
//            return ExecuteFind<Response>(findDelegate);
//
//            IQuery iqQuery =
//                getCurrentSession().CreateSQLQuery(
//                    "select cr.ResponseID, cr.CandidateID from CandidateResponse cr join Response r on (r.ResponseID = cr.ResponseID) where r.ElectionContestID = " +
//                    e.ID + ";").AddEntity(typeof (CandidateResponse));
//            // TODO: Currently only selects Candidate Responses.  Select CustomResponses as well.
//            return iqQuery.List<Response>();
//        }
//
//        public int findVoteCount(Response r, ContestCounty c) {
//            IQuery iqQuery =
//                getCurrentSession().CreateSQLQuery(
//                    "select rv.ResponseValueID, rv.VoteCount, rv.ResponseID, rv.ContestCountyID from ResponseValue rv where rv.ResponseID = " +
//                    r.ID + " and rv.ContestCountyID = " + c.ID + ";").AddEntity(typeof (ResponseValue));
//            IList<ResponseValue> lstRV = iqQuery.List<ResponseValue>();
//            if (lstRV.Count > 0) {
//                return lstRV[0].VoteCount;
//            } else {
//                return 0;
//            }
//        }

        public override IList<Fault> canMakeTransient(ElectionContest entity) {
            return new List<Fault>();
        }

        protected override IList<Fault> performCanMakePersistent(ElectionContest entity) {
            return new List<Fault>();
        }
    }
}