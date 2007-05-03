using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.db;

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

        public override string ToString() {
            if (contest != null) {
                return contest.Name;
            } else {
                return "NULL CONTEST: unknown";
            }
        }
    }
}