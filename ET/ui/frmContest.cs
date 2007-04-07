using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui.util;
using log4net;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmContest : BaseMDIChild {
        private readonly ContestDAO contestDAO;
        private readonly ContestTypeDAO contestTypeDAO;
        private static readonly ILog LOG = LogManager.GetLogger(typeof (frmContest));

        private Contest currentContest;

        public frmContest(ContestDAO contestDAO, ContestTypeDAO contestTypeDAO) {
            InitializeComponent();
            this.contestDAO = contestDAO;
            this.contestTypeDAO = contestTypeDAO;

            currentContest = new Contest();

            refreshGoToList();
        }

        private void frmContest_Load(object sender, EventArgs e) {
            IList<ContestType> contestTypes = contestTypeDAO.findAll();
            foreach (ContestType contestType in contestTypes) {
                cbContestType.Items.Add(new ListItemWrapper<ContestType>(contestType.Name, contestType));
            }

            if (contestTypes.Count > 0) cbContestType.SelectedIndex = 0;
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            currentContest = new Contest();
            refreshControls();
            base.btnAdd_Click(sender, e);
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            try {
                Contest contest = new Contest();
                contest.IsActive = chkActive.Checked;
                contest.Name = txtName.Text;
                contest.ContestType = ((ListItemWrapper<ContestType>) cbContestType.SelectedItem).Value;
                contest.Notes = txtNotes.Text;
                contestDAO.makePersistent(contest);
                refreshGoToList();
            } catch (Exception ex) {
                LOG.Error("unable to save: operation failed", ex);
            }
        }

        private void refreshGoToList()
        {
            IList<Contest> contests = contestDAO.findAll();
            cboGoTo.Items.Clear();
            foreach (Contest contest in contests)
            {
                cboGoTo.Items.Add(contest);
            }
        }

        private void refreshControls() {
            //clear the fields
            txtName.Text = currentContest.Name;
            txtNotes.Text = currentContest.Notes;

            if (currentContest.ContestType == null) {
                cbContestType.SelectedIndex = 0;
            } else {
                for (int i = 1, limit = cbContestType.Items.Count; i < limit; i++) {
                    if (((ListItemWrapper<ContestType>) cbContestType.Items[i]).Value.ID ==
                        currentContest.ContestType.ID) {
                        cbContestType.SelectedIndex = i;
                    }
                }
            }
            chkActive.Checked = currentContest.IsActive;
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            refreshControls();
            base.btnReset_Click(sender, e);
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            currentContest = (Contest) cboGoTo.SelectedItem;
            ;
        }
    }
}