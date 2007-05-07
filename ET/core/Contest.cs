using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class Contest {
        private long? id;
        private string name;
        private ContestType contestType;
        private string notes;
        private bool isActive;


        public virtual long ID {
            get { return id.HasValue ? id.Value : 0; }
            set { id = value; }
        }

        [RequiredProperty("Contest Name")]
        public virtual string Name {
            get { return name; }
            set { name = value; }
        }

        [RequiredProperty("Contest Type")]
        public virtual ContestType ContestType {
            get { return contestType; }
            set { contestType = value; }
        }

        public virtual string Notes {
            get { return notes; }
            set { notes = value; }
        }

        public virtual bool IsActive {
            get { return isActive; }
            set { isActive = value; }
        }

        public override string ToString() {
            return Name;
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            if (!GetType().Equals(obj.GetType())) return false;
            Contest that = (Contest) obj;
            if (id.HasValue && that.id.HasValue) {
                return id.Equals(that.id);
            } else {
                return false;
            }
        }
    }
}