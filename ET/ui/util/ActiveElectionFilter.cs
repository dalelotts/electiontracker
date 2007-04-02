using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class ActiveElectionFilter : BaseTreeViewFilter {
        private readonly ElectionDAO dao;

        private const string name = "Elections - Active";

        public ActiveElectionFilter(ElectionDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {

            TreeNode electionNode = GetNodeByKey(nodes, DBEntity.ELECTION.ToString(), DBEntity.ELECTION.Label);

            IList<Election> activeElections = dao.findActive();

            foreach (Election election in activeElections) {
                string nodeText = election.Date.ToString("dddd, MMMM dd yyyy");
                TreeNode newNode = electionNode.Nodes.Add(DBEntity.ELECTION + ";" + election.ID, nodeText);
                newNode.ToolTipText = election.Notes;
            }
        }
    }
}