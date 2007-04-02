using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class ActiveContestFilter : BaseTreeViewFilter {
        private static readonly string name = "Contest - Active";

        private readonly ContestDAO dao;

        public ActiveContestFilter(ContestDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            TreeNode electionNode = GetNodeByKey(nodes, DBEntity.CONTEST.ToString(), DBEntity.CONTEST.Label);

            IList<Contest> contests = dao.findActive();

            foreach (Contest contest in contests) {
                string nodeText = contest.Name;
                TreeNode newNode = electionNode.Nodes.Add(DBEntity.CONTEST + ";" + contest.ID, nodeText);
                newNode.ToolTipText = contest.Notes;
            }
        }
    }
}