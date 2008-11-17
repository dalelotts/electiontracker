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
using System;
using System.Collections.Generic;
using System.Reflection;
using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.core {
    public class Election {
        private long id;
        private DateTime date = DateTime.Today;
        private string notes;
        private bool isActive = true;
        private IList<ElectionContest> electionContests;

        public Election() {
            electionContests = new List<ElectionContest>();
        }

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Election Date")]
        public virtual DateTime Date {
            get { return date; }
            set { date = value; }
        }

        public virtual string Notes {
            get { return notes; }
            set { notes = value == null || value.Length == 0 ? null : value; ; }
        }

        public virtual bool IsActive {
            get { return isActive; }
            set { isActive = value; }
        }

        [RequiredProperty("Election Contests")]
        public virtual IList<ElectionContest> ElectionContests {
            get { return electionContests; }
            set { electionContests = value; }
        }

        public override string ToString() {
            return date.ToString("MM/dd/yyyy");
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            Election that = obj as Election;
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

        public virtual void ResetTotalVotes()
        {
            for (int i = 0; i < electionContests.Count; i++) {
                electionContests[i].ResetTotalVotes();
            }
            
        }
    }
}