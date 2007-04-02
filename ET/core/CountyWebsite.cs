namespace edu.uwec.cs.cs355.group4.et.core {
    public class CountyWebsite {
        private long id;
        private string url;
        private County county;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        public virtual string URL {
            get { return url; }
            set { url = value; }
        }


        public virtual County County
        {
            get { return county; }
            set { county = value; }
        }

        public override string ToString()
        {
            return url;
        }
    }
}