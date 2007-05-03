using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class PhoneNumberType {
        private long id;
        private string name;


        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Phone Number Type Name")]
        public virtual string Name {
            get { return name; }
            set { name = value; }
        }
    }
}