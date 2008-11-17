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
using System.Reflection;
using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.core {
    public class ContestCounty {
        private long id;
        private County county;
        private int wardCount;
        private IList<ResponseValue> responseValues;
        private int wardsReporting;
        private ElectionContest electionContest;

        #region Properties

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Contest County Response Values")]
        public virtual IList<ResponseValue> ResponseValues {
            get { return responseValues; }
            set { responseValues = value; }
        }

        [RequiredProperty("Contest County County")]
        public virtual County County {
            get { return county; }
            set { county = value; }
        }


        [RequiredProperty("Contest County Election Contest")]
        public virtual ElectionContest ElectionContest {
            get { return electionContest; }
            set { electionContest = value; }
        }

        public virtual int WardCount {
            get { return wardCount; }
            set { wardCount = value; }
        }

        public virtual int WardsReporting {
            get { return wardsReporting; }
            set { wardsReporting = value; }
        }

        #endregion

        public override string ToString() {
            return county != null ? county.Name : "NULL COUNTY: UNKNOWN";
        }

        public virtual int GetTotalVotes() {
            int result = 0;
            foreach (ResponseValue rv in ResponseValues) {
                result += rv.VoteCount;
            }
            return result;
        }

        public virtual void ResetTotalVotes() {
            for (int i=0; i < ResponseValues.Count; i++)
            {
                ResponseValues[i].VoteCount = 0;
            }
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            ContestCounty that = obj as ContestCounty;
            if (that == null) return false;
            if (id == 0 && that.ID == 0) {
                return base.Equals(obj);
            } else {
                return id.Equals(that.ID);
            }
        }

        public override int GetHashCode() {
            if (id == 0) {
                return base.GetHashCode();
            } else {
                string stringRepresentation = MethodBase.GetCurrentMethod().DeclaringType.FullName + "#" + id;
                return stringRepresentation.GetHashCode();
            }
        }
    }
}