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
using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.core {
    public abstract class Response {
        private long id;
        private int sortorder;
        private ElectionContest electionContest;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Response Election Contest")]
        public virtual ElectionContest ElectionContest {
            get { return electionContest; }
            set { electionContest = value; }
        }

        public virtual int SortOrder {
            get { return sortorder; }
            set { sortorder = value; }
        }

        public abstract override string ToString();

        public virtual int GetTotalVotes() {
            int result = 0;
            if (electionContest != null) {
                foreach (ContestCounty cc in electionContest.Counties) {
                    foreach (ResponseValue rv in cc.ResponseValues) {
                        if (rv.Response.ID == ID) {
                            result += rv.VoteCount;
                        }
                    }
                }
            }
            return result;
        }
    }
}