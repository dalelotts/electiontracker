using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
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