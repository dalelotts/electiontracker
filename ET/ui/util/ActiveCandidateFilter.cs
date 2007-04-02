using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal sealed class ActiveCandidateFilter : BaseTreeViewFilter {
        private readonly CandidateDAO dao;

        private const string name = "Candidates - Active";

        public ActiveCandidateFilter(CandidateDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            TreeNode candidateNode = GetNodeByKey(nodes, DBEntity.CANDIDATE.ToString(), DBEntity.CANDIDATE.Label);

            IList<Candidate> candidates = dao.findActive();

            foreach (Candidate candidate in candidates) {
                string displayName = string.Format("{0}, {1} {2}", candidate.LastName, candidate.FirstName, candidate.MiddleName);
                if (candidate.PoliticalParty != null) {
                    displayName += string.Format(" ({0})", candidate.PoliticalParty.Abbreviation);
                }
                TreeNode newNode = candidateNode.Nodes.Add(DBEntity.CANDIDATE + ";" + candidate.ID,
                                                           displayName);
                newNode.ToolTipText = candidate.Notes;
            }
        }
    }
}