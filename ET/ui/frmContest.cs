/**
 *  Copyright (C) 2007 Knight Rider Consulting, Inc.
 *  support@knightrider.com
 *  http://www.knightrider.com
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see http://www.gnu.org/licenses/
 **/
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui.util;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmContest : BaseMDIChild {
        private readonly ContestDAO contestDAO;
        private readonly ContestTypeDAO contestTypeDAO;
        private Contest currentContest;

        public override void btnDelete_Click(object sender, EventArgs e) {
            try {
                IList<Fault> faults = contestDAO.canMakeTransient(currentContest);
                if (reportFaults(faults)) {
                    contestDAO.makeTransient(currentContest);
                    currentContest = new Contest();
                    refreshControls();
                    raiseMakeTransientEvent();
                }
            } catch (Exception ex) {
                reportException("btnDelete_Click", ex);
            }
        }

        public frmContest(ContestDAO contestDAO, ContestTypeDAO contestTypeDAO) {
            InitializeComponent();
            this.contestDAO = contestDAO;
            this.contestTypeDAO = contestTypeDAO;

            currentContest = new Contest();
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            try {
                currentContest = new Contest();
                refreshControls();
                base.btnAdd_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnAdd_Click", ex);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            cbContestType_Leave(null, null);
            try {
                currentContest.IsActive = chkActive.Checked;
                currentContest.Name = txtName.Text;
                if (cbContestType.SelectedItem != null) {
                    currentContest.ContestType = ((ListItemWrapper<ContestType>) cbContestType.SelectedItem).Value;
                }
                currentContest.Notes = txtNotes.Text;

                //Validate the current data and get a list of faults.
                IList<Fault> faults = contestDAO.canMakePersistent(currentContest);
                bool persistData = reportFaults(faults);

                //If there were no errors, persist data to the database
                if (persistData) {
                    currentContest = contestDAO.makePersistent(currentContest);
                    refreshControls();
                    raiseMakePersistentEvent();
                }
            } catch (Exception ex) {
                reportException("btnSave_Click", ex);
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

            txtName.Text = currentContest.Name;
            txtNotes.Text = currentContest.Notes;

            refreshGoToList();
            refreshContestTypes();

            if (currentContest.ContestType == null && cbContestType.Items.Count > 0) {
                cbContestType.SelectedIndex = 0;
            } else {
                for (int i = 0, limit = cbContestType.Items.Count; i < limit; i++) {
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
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            try {
                refreshControls();
                base.btnReset_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnReset_Click", ex);
            }
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                currentContest = (Contest) cboGoTo.SelectedItem;
                refreshControls();
                base.cboGoTo_SelectedIndexChanged(sender, e);
            } catch (Exception ex) {
                reportException("cboGoTo_SelectedIndexChanged", ex);
            }
        }

        public void loadContest(long? id) {
            if (id.HasValue) {
                Contest contest = contestDAO.findById(id.Value, false);
                if (contest != null) {
                    currentContest = contest;
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
                        refreshControls();

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
                reportException("cbContestType_Leave", ex);
            }
        }
    }
}