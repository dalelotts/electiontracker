using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class County {
        private long id;
        private string name;
        private string notes;
        private int wardCount;
        private IList<CountyPhoneNumber> phoneNumbers = new List<CountyPhoneNumber>();
        private IList<CountyAttribute> attributes = new List<CountyAttribute>();
        private IList<CountyWebsite> websites = new List<CountyWebsite>();

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("County Name")]
        public virtual string Name {
            get { return name; }
            set { name = value; }
        }

        public virtual string Notes {
            get { return notes; }
            set { notes = value; }
        }

        public virtual int WardCount {
            get { return wardCount; }
            set { wardCount = value; }
        }

        public virtual IList<CountyPhoneNumber> PhoneNumbers {
            get { return phoneNumbers; }
            set { phoneNumbers = value; }
        }

        public virtual IList<CountyWebsite> Websites
        {
            get { return websites; }
            set { websites = value; }
        }

        public virtual IList<CountyAttribute> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}