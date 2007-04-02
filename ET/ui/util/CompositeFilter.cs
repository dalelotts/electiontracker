using System.Collections.Generic;
using System.Windows.Forms;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class CompositeFilter : BaseTreeViewFilter {
        private readonly IList<TreeViewFilter> members;

        public CompositeFilter(string name, IList<TreeViewFilter> members) : base(name) {
            this.members = members;
        }

        public override void apply(TreeNodeCollection nodes) {
            foreach (TreeViewFilter filter in members) {
                filter.apply(nodes);
            }
        }
    }
}