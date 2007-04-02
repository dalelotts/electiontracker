using System.Collections.Generic;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class ElectionContest {
        private long id;
        private Election election;
        private Contest contest;
        private IList<Response> responses;
        private IList<ContestCounty> counties;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        public virtual Election Election {
            get { return election; }
            set { election = value; }
        }

        public virtual Contest Contest {
            get { return contest; }
            set { contest = value; }
        }


        public virtual IList<Response> Responses {
            get { return responses; }
            set { responses = value; }
        }

        public virtual IList<ContestCounty> Counties {
            get { return counties; }
            set { counties = value; }
        }

        public override string ToString() {
            if (contest != null) {
                return contest.Name;
            } else {
                return "NULL CONTEST: unknown";
            }
        }
    }
}