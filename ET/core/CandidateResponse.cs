namespace edu.uwec.cs.cs355.group4.et.core {
    internal class CandidateResponse : Response {
        private Candidate candidate;

        public virtual Candidate Candidate {
            get { return candidate; }
            set { candidate = value; }
        }

        public override string ToString() {
            return candidate != null ? candidate.FirstName + " " + candidate.LastName : "NULL CANDIDATE: UNKNOWN";
        }
    }
}