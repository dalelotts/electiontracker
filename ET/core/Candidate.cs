namespace edu.uwec.cs.cs355.group4.et.core {
    public class Candidate {
        private long id;
        private string firstName;
        private string middleName;
        private string lastName;
        private string notes;
        private PoliticalParty politicalParty;
        private bool isActive = true;


        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        public virtual string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }

        public virtual string MiddleName {
            get { return middleName; }
            set { middleName = value; }
        }

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
            return name + (politicalParty != null ? " (" + politicalParty.Abbreviation + ")"  : "");
        }
    }
}