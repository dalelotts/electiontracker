using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class InactivePoliticalPartyFilter : BaseTreeViewFilter {
        private const string name = "Political Parties - Inactive";

        private readonly PoliticalPartyDAO dao;

        public InactivePoliticalPartyFilter(PoliticalPartyDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            TreeNode partyNode = GetNodeByKey(nodes, DBEntity.POLITICAL_PARTY.ToString(), DBEntity.POLITICAL_PARTY.Label);

            IList<PoliticalParty> parties = dao.findInactive();
            foreach (PoliticalParty party in parties) {
                partyNode.Nodes.Add(DBEntity.POLITICAL_PARTY + ";" + party.ID, party.Name + " (Inactive)");
            }
        }
    }
}