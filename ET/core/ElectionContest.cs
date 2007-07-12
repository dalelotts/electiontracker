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
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class ElectionContest {
        private long id;
        private Election election;
        private Contest contest;
        private IList<Response> responses;
        private IList<ContestCounty> counties = new List<ContestCounty>();

        #region Properties

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Election Contest Election")]
        public virtual Election Election {
            get { return election; }
            set { election = value; }
        }

        [RequiredProperty("Election Contest Contest")]
        public virtual Contest Contest {
            get { return contest; }
            set { contest = value; }
        }

        [RequiredProperty("Election Contest Responses")]
        public virtual IList<Response> Responses {
            get { return responses; }
            set { responses = value; }
        }

        [RequiredProperty("Election Contest Counties")]
        public virtual IList<ContestCounty> Counties {
            get { return counties; }
            set { counties = value; }
        }

        #endregion

        public override string ToString() {
            if (contest != null) {
                return contest.Name;
            } else {
                return "NULL CONTEST: unknown";
            }
        }

        public virtual int GetTotalVotes() {
            int result = 0;
            foreach (ContestCounty cc in Counties) {
                /*foreach (ResponseValue rv in cc.ResponseValues){
                    result += rv.VoteCount;
                }*/
                result += cc.GetTotalVotes();
            }
            return result;
        }

        public virtual int GetWardsReporting() {
            int result = 0;
            foreach (ContestCounty cc in Counties) {
                result += cc.WardsReporting;
            }
            return result;
        }

        public virtual int GetWardCount() {
            int result = 0;
            foreach (ContestCounty cc in Counties) {
                result += cc.WardCount;
            }
            return result;
        }

        public virtual double GetWardsReportingPercentage() {
            if (GetWardCount() == 0)
                return 0;
            return ((double) GetWardsReporting()/(double) GetWardCount());
        }
    }
}