namespace edu.uwec.cs.cs355.group4.et.db {
    internal class Fault {
        private readonly bool isError;
        private readonly string message;

        public Fault(bool isError, string message) {
            this.isError = isError;
            this.message = message;
        }


        public bool IsError {
            get { return isError; }
        }

        public string Message {
            get { return message; }
        }
    }
}