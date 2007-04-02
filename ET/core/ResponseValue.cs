namespace edu.uwec.cs.cs355.group4.et.core {
    internal class ResponseValue {
        private Response response;
        private ContestCounty contestCounty;
        private int voteCount;
        private long id;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }


        public virtual Response Response {
            get { return response; }
            set { response = value; }
        }


        public virtual ContestCounty ContestCounty {
            get { return contestCounty; }
            set { contestCounty = value; }
        }


        public virtual int VoteCount {
            get { return voteCount; }
            set { voteCount = value; }
        }
    }
}