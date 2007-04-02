namespace edu.uwec.cs.cs355.group4.et.core {
    public class CountyPhoneNumber {
        private long id;
        private PhoneNumberType type;
        private string areaCode;
        private string phoneNumber;
        private string extension;
        private County county;


        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        public virtual PhoneNumberType Type {
            get { return type; }
            set { type = value; }
        }

        public virtual string AreaCode {
            get { return areaCode; }
            set { areaCode = value; }
        }

        public virtual string PhoneNumber {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public virtual string Extension {
            get { return extension; }
            set { extension = value; }
        }

        public virtual County County
        {
            get { return county; }
            set { county = value; }
        }

        public override string ToString()
        {
            return (type.Name + ": (" + areaCode + ") " + phoneNumber);
        }
    }
}