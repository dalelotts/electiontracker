using System;

namespace edu.uwec.cs.cs355.group4.et.events {
    internal class ShowMessageArgs : EventArgs {
        private readonly string text;
        private readonly string caption;


        public ShowMessageArgs(string text, string caption) {
            this.text = text;
            this.caption = caption;
        }

        public string Text {
            get { return text; }
        }

        public string Caption {
            get { return caption; }
        }
    }
}