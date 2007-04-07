using System.Drawing;
using Altea;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class FilterButton : OutlookBarButton {
        private readonly TreeViewFilter filter;

        public FilterButton(string text, Icon image, TreeViewFilter filter) : base(text, image) {
            this.filter = filter;
        }


        public TreeViewFilter Filter {
            get { return filter; }
        }
    }
}