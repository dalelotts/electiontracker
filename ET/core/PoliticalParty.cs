using System.Collections.Generic;
using Spring.Collections;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class PoliticalParty {
        private long    id;
        private string  name;
        private string  abbreviation;
        private IList<Candidate> candidates;
        private bool    isActive = true;

        public virtual IList<Candidate>  Candidates {
            get { return candidates; }
            set { candidates = value; }
        }

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        public virtual string Name {
            get { return name; }
            set { name = value; }
        }

        public virtual string Abbreviation {
            get { return abbreviation; }
            set { abbreviation = value; }
        }

        public virtual bool IsActive {
            get { return isActive; }
            set { isActive = value; }
        }

        public override string ToString() {
            return name + " (" + abbreviation + ")";
        }
    }
}