using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class InactiveContestFilter : BaseTreeViewFilter {
        private static readonly string name = "Contest - Inactive";

        private readonly ContestDAO dao;

        public InactiveContestFilter(ContestDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            TreeNode electionNode = GetNodeByKey(nodes, DBEntity.CONTEST.ToString(), DBEntity.CONTEST.Label);

            IList<Contest> contests = dao.findInactive();

            foreach (Contest contest in contests) {
                string nodeText = contest.Name;
                TreeNode newNode = electionNode.Nodes.Add(DBEntity.CONTEST + ";" + contest.ID, nodeText);
                newNode.ToolTipText = contest.Notes;
            }
        }
    }
}