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
using System.Windows.Forms;

namespace KnightRider.ElectionTracker.ui.util {
    internal abstract class BaseTreeViewFilter : TreeViewFilter {
        private readonly string name;

        protected BaseTreeViewFilter(string name) {
            this.name = name;
        }

        public abstract void apply(TreeNodeCollection nodes);

        public override sealed string ToString() {
            return name;
        }

        /// <summary>
        ///     Return the node with the specified key.  If the node does not exist
        ///     it is created as a child of the parent node with the specified text.
        /// </summary>
        /// <param name="parentNode">the parent node</param>
        /// <param name="nodeKey">the key of the node</param>
        /// <param name="nodeText">the next of the node if the node does not exist.</param>
        /// <returns>a node with the specified key that is a child of the parent node.</returns>
        protected static TreeNode GetNodeByKey(TreeNode parentNode, string nodeKey, string nodeText) {
            TreeNode result = GetNodeByKey(parentNode, nodeKey);
            if (result == null) {
                result = parentNode.Nodes.Add(nodeKey, nodeText);
            }
            return result;
        }

        /// <summary>
        ///     Return the node with the specified.
        /// </summary>
        /// <param name="parentNode">the parent node</param>
        /// <param name="nodeKey">the key of the node</param>
        /// <returns>the node with the specified key or null if the node does not exist.</returns>
        protected static TreeNode GetNodeByKey(TreeNode parentNode, string nodeKey) {
            TreeNode result = null;
            TreeNode[] foundNodes = parentNode.Nodes.Find(nodeKey, true);
            if (foundNodes != null && foundNodes.Length != 0) {
                result = foundNodes[0];
            }
            return result;
        }

        protected static TreeNode GetNodeByKey(TreeNodeCollection nodes, string nodeKey, string nodeText) {
            TreeNode result = GetNodeByKey(nodes, nodeKey);
            if (result == null) {
                result = nodes.Add(nodeKey, nodeText);
            }
            return result;
        }

        protected static TreeNode GetNodeByKey(TreeNodeCollection nodes, string nodeKey) {
            TreeNode result = null;
            TreeNode[] foundNodes = nodes.Find(nodeKey, true);
            if (foundNodes != null && foundNodes.Length != 0) {
                result = foundNodes[0];
            }
            return result;
        }
    }
}