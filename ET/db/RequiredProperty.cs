using System;

namespace edu.uwec.cs.cs355.group4.et.db {
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    internal class RequiredProperty : Attribute {
        private string friendlyName;
        private bool allowEmptyList = false;

        public bool AllowEmptyList {
            get { return allowEmptyList; }
            set { allowEmptyList = value; }
        }

        public RequiredProperty(string friendlyName) {
            this.friendlyName = friendlyName;
        }

        public virtual string FriendlyName {
            get { return friendlyName; }
        }
    }
}