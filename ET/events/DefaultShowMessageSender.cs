using System.Windows.Forms;

namespace edu.uwec.cs.cs355.group4.et.events {
    internal class DefaultShowMessageSender : IShowMessageSender {
        private DialogResult result;

        public DialogResult Result {
            get { return result; }
            set { result = value; }
        }
    }
}