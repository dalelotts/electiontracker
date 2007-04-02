using System.Windows.Forms;

namespace edu.uwec.cs.cs355.group4.et.events {
    internal interface IShowMessageSender {
        DialogResult Result { get; set; }
    }
}