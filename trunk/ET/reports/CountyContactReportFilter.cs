using System.Collections.Generic;
using System.Windows.Forms;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;
using KnightRider.ElectionTracker.db.task;
using KnightRider.ElectionTracker.ui.util;

namespace KnightRider.ElectionTracker.reports {
    public class CountyContactReportFilter : TreeViewFilter {
        private readonly ICountyDAO dao;
        private readonly IDAOTask<County> loadTask;
        private const string name = "All Counties";

        public CountyContactReportFilter(ICountyDAO dao, IDAOTask<County> loadTask) {
            this.dao = dao;
            this.loadTask = loadTask;
        }

        public void apply(TreeNodeCollection nodes) {
            IList<County> counties = dao.findAll(loadTask);
            TreeNode node = nodes.Add(name);
            node.Tag = counties;
        }

        public override string ToString() {
            return name;
        }
    }
}