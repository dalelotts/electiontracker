using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    internal class CustomResponse : Response {
        private string description;

        [RequiredProperty("Custom Response Description")]
        public virtual string Description {
            get { return description; }
            set { description = value; }
        }

        public override string ToString() {
            return description;
        }
    }
}