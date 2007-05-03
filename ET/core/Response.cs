using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public abstract class Response {
        private long id;
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

        public abstract override string ToString();
    }
}