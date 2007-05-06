using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class CountyAttribute {
        private long id;
        private AttributeType type;
        private string value;
        private County county;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("County Attribute Type")]
        public virtual AttributeType Type {
            get { return type; }
            set { type = value; }
        }

        [RequiredProperty("County Attribute County")]
        public virtual County County {
            get { return county; }
            set { county = value; }
        }

        [RequiredProperty("County Attribute Value")]
        public virtual string Value {
            get { return value; }
            set { this.value = value; }
        }

        public override string ToString() {
            return (type.Name + ": " + value);
        }
    }
}