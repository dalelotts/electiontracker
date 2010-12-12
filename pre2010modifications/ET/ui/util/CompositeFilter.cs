/**
 *  Copyright (C) 2007 Knight Rider Consulting, Inc.
 *  support@knightrider.com
 *  http://www.knightrider.com
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see http://www.gnu.org/licenses/
 **/
using System.Collections.Generic;
using System.Windows.Forms;

namespace KnightRider.ElectionTracker.ui.util {
    internal class CompositeFilter : BaseTreeViewFilter {
        private readonly IList<TreeViewFilter> members;

        public CompositeFilter(string name, IList<TreeViewFilter> members) : base(name) {
            this.members = members;
        }

        public override void apply(TreeNodeCollection nodes) {
            foreach (TreeViewFilter filter in members) {
                TreeNode filterNode = nodes.Add(filter.ToString());
                filter.apply(filterNode.Nodes);
            }
        }
    }
}