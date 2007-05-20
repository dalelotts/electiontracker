using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class Candidate {
        private long? id;
        private string firstName;
        private string middleName;
        private string lastName;
        private string notes;
        private PoliticalParty politicalParty;
        private bool isActive = true;


        public virtual long ID {
            get { return id.HasValue ? id.Value : 0; }
            set { id = value; }
        }

        [RequiredProperty("Candidate First Name")]
        public virtual string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }

        public virtual string MiddleName {
            get { return middleName; }
            set { middleName = value; }
        }

        [RequiredProperty("Candidate Last Name")]
        public virtual string LastName {
            get { return lastName; }
            set { lastName = value; }
        }

        public virtual string Notes {
            get { return notes; }
            set { notes = value; }
        }

        public virtual PoliticalParty PoliticalParty {
            get { return politicalParty; }
            set { politicalParty = value; }
        }

        public virtual bool IsActive {
            get { return isActive; }
            set { isActive = value; }
        }

        public override string ToString() {
            string name = lastName + ", " + firstName + " " + middleName;
            return name + (politicalParty != null ? " (" + politicalParty.Abbreviation + ")" : "");
        }


        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            if (!GetType().Equals(obj.GetType())) return false;
            Candidate that = (Candidate) obj;
            if (id.HasValue && that.id.HasValue) {
                return id.Equals(that.id);
            } else {
                return false;
            }
        }

        public override int GetHashCode() {
            return id.HasValue ? (int) id.Value : base.GetHashCode();
        }
    }
}