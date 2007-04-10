using System;

namespace edu.uwec.cs.cs355.group4.et.events {
    internal abstract class DBEntityArgs : EventArgs {
        private readonly long? id;


        public DBEntityArgs() {
            id = null;
        }

        public DBEntityArgs(long id) {
            this.id = id;
        }


        public long? ID {
            get { return id; }
        }
    }
}