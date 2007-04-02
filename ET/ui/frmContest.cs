using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.ui.util;
using log4net;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    internal partial class frmContest : Form
    {
        private readonly ContestDAO contestDAO;
        private readonly ContestTypeDAO contestTypeDAO;
        private static readonly ILog LOG = LogManager.GetLogger(typeof (frmContest));

        public frmContest(ContestDAO contestDAO, ContestTypeDAO contestTypeDAO) {
            InitializeComponent();
            this.contestDAO = contestDAO;
            this.contestTypeDAO = contestTypeDAO;
        }

        private void frmContest_Load(object sender, EventArgs e)
        {
            IList<ContestType> contestTypes = contestTypeDAO.findAll();
            foreach (ContestType contestType in contestTypes)
            {
                cbContestType.Items.Add(new ListItemWrapper<ContestType>(contestType.Name, contestType));
            }

            if (contestTypes.Count > 0) cbContestType.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ContestType contestType = new ContestType();
                contestType.Name = ((ListItemWrapper<ContestType>)cbContestType.SelectedItem).Value.Name;
                contestType.ID = ((ListItemWrapper<ContestType>)cbContestType.SelectedItem).Value.ID;
                Contest contest = new Contest();
                contest.IsActive = chkActive.Checked;
                contest.Name = txtName.Text;
                contest.ContestType = (contestType);
                contest.Notes = txtNotes.Text;
                contestDAO.makePersistent(contest);
            }
            catch (Exception ex)
            {
                LOG.Error("unable to save: operation failed", ex);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}