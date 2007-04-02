namespace edu.uwec.cs.cs355.group4.et.core {
    internal class CustomResponse : Response {
        private string description;

        public virtual string Description {
            get { return description; }
            set { description = value; }
        }

        public override string ToString() {
            return description;
        }
    }
}