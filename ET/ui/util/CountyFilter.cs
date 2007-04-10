using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class CountyFilter : BaseTreeViewFilter {
        private readonly CountyDAO dao;

        private const string name = "Counties";

        public CountyFilter(CountyDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            IList<County> counties = dao.findAll();

            foreach (County county in counties) {
                string nodeText = county.Name;
                TreeNode newNode = nodes.Add(DBEntity.COUNTY + "=" + county.ID, nodeText);
                newNode.ToolTipText = county.Notes;
            }
        }
    }
}