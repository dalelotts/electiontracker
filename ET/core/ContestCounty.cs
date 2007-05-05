using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.db;
namespace edu.uwec.cs.cs355.group4.et.core {
    public class ContestCounty {
        private long id;
        private County county;
        private int wardCount;
        private IList<ResponseValue> responseValues;
        private int wardsReporting;
        private ElectionContest electionContest;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Contest County Response Values")]
        public virtual IList<ResponseValue> ResponseValues
        {
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


        public override string ToString() {
            return county != null ? county.Name : "NULL COUNTY: UNKNOWN";
        }

        public virtual int GetTotalVotes()
        {
            int result = 0;
            foreach (ResponseValue rv in ResponseValues)
            {
                result += rv.VoteCount;
            }
            return result;
        }
    }
}