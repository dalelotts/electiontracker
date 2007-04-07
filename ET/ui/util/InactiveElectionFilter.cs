using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class InactiveElectionFilter : BaseTreeViewFilter {
        private readonly ElectionDAO dao;

        private const string name = "Elections - Inactive";

        public InactiveElectionFilter(ElectionDAO dao) : base(name) {
            this.dao = dao;
        }


        public override void apply(TreeNodeCollection nodes) {
            IList<Election> elections = dao.findInactive();

            foreach (Election election in elections) {
                string nodeText = election.Date.ToString("dddd, MMMM dd yyyy");
                TreeNode newNode = nodes.Add(DBEntity.ELECTION + ";" + election.ID, nodeText);
                newNode.ToolTipText = election.Notes;
            }
        }
    }
}