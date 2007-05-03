using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public  class ContestType {
        private long id;
        private string name;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Contest Type Name")]
        public virtual string Name {
            get { return name; }
            set { name = value; }
        }
    }
}