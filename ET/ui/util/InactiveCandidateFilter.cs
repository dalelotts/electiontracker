using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal sealed class InactiveCandidateFilter : BaseTreeViewFilter {
        private readonly CandidateDAO dao;

        private const string name = "Candidates - Inactive";

        public InactiveCandidateFilter(CandidateDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            TreeNode candidateNode = GetNodeByKey(nodes, DBEntity.CANDIDATE.ToString(), DBEntity.CANDIDATE.Label);

            IList<Candidate> candidates = dao.findInactive();

            foreach (Candidate candidate in candidates) {
                TreeNode newNode = candidateNode.Nodes.Add(DBEntity.CANDIDATE + ";" + candidate.ID,
                                                           candidate.LastName + ", " + candidate.FirstName + " " + candidate.MiddleName);
                newNode.ToolTipText = candidate.Notes;
            }
        }
    }
}