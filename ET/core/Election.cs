using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
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
            set { notes = value; }
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
            return date.ToShortDateString();
        }
    }
}