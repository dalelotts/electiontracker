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
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class ResponseValue {
        private Response response;
        private ContestCounty contestCounty;
        private int voteCount;
        private long id;

        #region Properties

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Response Value Response")]
        public virtual Response Response {
            get { return response; }
            set { response = value; }
        }

        [RequiredProperty("Response Value Contest County")]
        public virtual ContestCounty ContestCounty {
            get { return contestCounty; }
            set { contestCounty = value; }
        }

        public virtual int VoteCount {
            get { return voteCount; }
            set { voteCount = value; }
        }

        #endregion

        public virtual double GetVotePercentage() {
            return ContestCounty.GetTotalVotes() != 0 ? (double) voteCount/(double) ContestCounty.GetTotalVotes() : 0;
        }
    }
}