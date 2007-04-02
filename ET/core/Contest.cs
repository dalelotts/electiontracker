namespace edu.uwec.cs.cs355.group4.et.core {
    public class Contest {
        private long id;
        private string name;
        private ContestType contestType;
        private string notes;
        private bool isActive;


        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name {
            get { return name; }
            set { name = value; }
        }

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

        public override string ToString()
        {
            return Name;
        }
    }
}