using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class ActivePoliticalPartyFilter : BaseTreeViewFilter {
        private const string name = "Political Parties - Active";

        private readonly PoliticalPartyDAO dao;

        public ActivePoliticalPartyFilter(PoliticalPartyDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            IList<PoliticalParty> parties = dao.findActive();
            foreach (PoliticalParty party in parties) {
                nodes.Add(DBEntity.POLITICAL_PARTY + "=" + party.ID, party.ToString());
            }
        }
    }
}