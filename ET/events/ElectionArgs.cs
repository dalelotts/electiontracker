using System;

namespace edu.uwec.cs.cs355.group4.et.events {
    internal class ElectionArgs : EventArgs {
        private readonly long? electionID;


        public ElectionArgs() {
            electionID = null;
        }

        public ElectionArgs(long electionID) {
            this.electionID = electionID;
        }

        public long? ElectionID {
            get { return electionID; }
        }
    }
}