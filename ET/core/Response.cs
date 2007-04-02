using System;

namespace edu.uwec.cs.cs355.group4.et.core {
    public abstract class Response {
        private long id;
        private ElectionContest electionContest;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }


        public virtual ElectionContest ElectionContest {
            get { return electionContest; }
            set { electionContest = value; }
        }

        public abstract override string ToString();
    }
}