using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            try {
                refreshContestTypes();
            } catch (Exception ex) {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex);
                LOG.Error(message, ex);
            }
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            try {
                currentContest = new Contest();
                refreshControls();
                base.btnAdd_Click(sender, e);
            } catch (Exception ex) {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex);
                LOG.Error(message, ex);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            try {
                currentContest.IsActive = chkActive.Checked;
                currentContest.Name = txtName.Text;
                currentContest.ContestType = ((ListItemWrapper<ContestType>) cbContestType.SelectedItem).Value;
                currentContest.Notes = txtNotes.Text;

                //Validate the current data and get a list of faults.
                IList<Fault> faultLst = contestDAO.validate(currentContest);
                bool persistData = true;

                //Go through the list of faults and display warnings and errors.
                foreach (Fault fault in faultLst) {
                    if (persistData) {
                        if (fault.IsError) {
                            persistData = false;
                            MessageBox.Show("Error: " + fault.Message);
                        } else {
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result =
                                MessageBox.Show("Warning: " + fault.Message + "\n\nWould you like to save anyway?",
                                                "Warning Message", buttons);
                            if (result == DialogResult.No) {
                                persistData = false;
                            }
                        }
                    }
                }

                //If there were no errors, persist data to the database
                if (persistData) {
                    contestDAO.makePersistent(currentContest);
                    refreshGoToList();
                }
            } catch (Exception ex) {
                string message = "Unable to save: Operation failed";
                MessageBox.Show(message + "\n\n" + ex);
                LOG.Error(message, ex);
            }
        }

        private void refreshGoToList() {
            IList<Contest> contests = contestDAO.findAll();
            cboGoTo.Items.Clear();
            foreach (Contest contest in contests) {
                cboGoTo.Items.Add(contest);
            }
        }

        private void refreshControls() {
            //clear the fields
            txtName.Text = currentContest.Name;
            txtNotes.Text = currentContest.Notes;

            if (currentContest.ContestType == null && cbContestType.Items.Count > 0) {
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

        private void refreshContestTypes() {
            cbContestType.Items.Clear();
            IList<ContestType> contestTypes = contestTypeDAO.findAll();
            foreach (ContestType contestType in contestTypes) {
                cbContestType.Items.Add(new ListItemWrapper<ContestType>(contestType.Name, contestType));
            }

            //if (cbContestType.SelectedIndex != -1) cbContestType.SelectedIndex = 0;
            refreshControls();
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            try {
                refreshControls();
                base.btnReset_Click(sender, e);
            } catch (Exception ex) {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex);
                LOG.Error(message, ex);
            }
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                currentContest = (Contest) cboGoTo.SelectedItem;
                ;
            } catch (Exception ex) {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex);
                LOG.Error(message, ex);
            }
        }

        public void loadContest(long? id) {
            if (id.HasValue) {
                Contest contest = contestDAO.findById(id, false);
                if (contest != null) {
                    currentContest = contest;
                    refreshControls();
                }
            }
            refreshControls();
        }

        private void cbContestType_Leave(object sender, EventArgs e) {
            try {
                if ((cbContestType.SelectedIndex == -1) && (!cbContestType.Text.Equals(""))) {
                    String newTypeName = cbContestType.Text;
                    String message = "Contest Type \"" + newTypeName +
                                     "\" does not exist.\nWould you like to create it?";
                    String caption = "Unidentified Type";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.Yes) {
                        ContestType newType = new ContestType();
                        newType.Name = newTypeName;
                        contestTypeDAO.makePersistent(newType);
                        refreshContestTypes();

                        for (int i = 0; i < cbContestType.Items.Count; i++) {
                            if ((((ListItemWrapper<ContestType>) cbContestType.Items[i]).Value).Name.Equals(newTypeName)) {
                                cbContestType.SelectedIndex = i;
                            }
                        }
                    }
                    if (result == DialogResult.No) {
                        cbContestType.SelectedIndex = 0;
                    }
                }
            } catch (Exception ex) {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex);
                LOG.Error(message, ex);
            }
        }
    }
}