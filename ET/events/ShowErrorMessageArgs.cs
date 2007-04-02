using System;


namespace edu.uwec.cs.cs355.group4.et.events
{
    class ShowErrorMessageArgs : ShowMessageArgs {
        private readonly Exception exception;

        public ShowErrorMessageArgs(string text, Exception exception) : base(text, "Error") {
            this.exception = exception;
        }

        public Exception Exception {
            get { return exception; }
        }
    }
}
