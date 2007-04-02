using System.Windows.Forms;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal interface TreeViewFilter {
        void apply(TreeNodeCollection nodes);
    }
}