namespace edu.uwec.cs.cs355.group4.et.core {
    public class ContestCounty {
        private long id;
        private County county;
        private int wardCount;
        private int wardsReporting;
        private ElectionContest electionContest;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        public virtual County County {
            get { return county; }
            set { county = value; }
        }


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
    }
}