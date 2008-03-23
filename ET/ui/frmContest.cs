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
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.ui {
    internal partial class frmContest : BaseMDIChild {
        private readonly IContestDAO contestDAO;
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

        public frmContest(IContestDAO contestDAO) {
            InitializeComponent();
            this.contestDAO = contestDAO;

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
            try {
                currentContest.IsActive = chkActive.Checked;
                currentContest.Name = txtName.Text;
                currentContest.Notes = txtNotes.Text;

                //Validate the current data and get a list of faults.
                IList<Fault> faults = contestDAO.canMakePersistent(currentContest);
                bool persistData = reportFaults(faults);

                //If there were no errors, persist data to the database
                if (persistData) {
                    currentContest = contestDAO.makePersistent(currentContest);
                    refreshControls();
                    raiseMakePersistentEvent();
                    MessageBox.Show(this, currentContest + " saved.", "Sucessful Save");
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
            chkActive.Checked = currentContest.IsActive;
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            try {
                currentContest = currentContest.ID == 0 ? new Contest() : contestDAO.findById(currentContest.ID, false);
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
    }
}