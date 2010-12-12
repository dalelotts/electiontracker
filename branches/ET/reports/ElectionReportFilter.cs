using System.Collections.Generic;
using System.Windows.Forms;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;
using KnightRider.ElectionTracker.db.task;
using KnightRider.ElectionTracker.ui.util;

namespace KnightRider.ElectionTracker.reports {
    internal class ElectionReportFilter : TreeViewFilter {
        private readonly string name;
        private readonly IElectionDAO dao;
        private readonly IDAOTask<Election> loadTask;
        private readonly bool isActive;


        public ElectionReportFilter(string name, IElectionDAO dao, IDAOTask<Election> loadTask, bool isActive) {
            this.name = name;
            this.dao = dao;
            this.loadTask = loadTask;
            this.isActive = isActive;
        }

        public void apply(TreeNodeCollection nodes) {
            IList<Election> elections = GetElections();

            foreach (Election election in elections) {
                TreeNode electionNode = nodes.Add(election.ToString());
                electionNode.Tag = election;
                electionNode.ToolTipText = election.Notes;
            }
        }

        private IList<Election> GetElections() {
            if (isActive) {
                return dao.findActive(loadTask);
            } else {
                return dao.findInactive(loadTask);
            }
        }

        public override string ToString() {
            return name;
        }
    }
}