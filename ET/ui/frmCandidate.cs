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
    internal partial class frmCandidate : BaseMDIChild {
        private readonly CandidateDAO candidateDAO;
        private Candidate currentCandidate;

        public frmCandidate(CandidateDAO candidateDAO, PoliticalPartyDAO politicalPartyDAO) {
            InitializeComponent();
            this.candidateDAO = candidateDAO;

            cboPoliticalParty.Items.Add(new ListItemWrapper<PoliticalParty>("< NONE >", null));

            IList<PoliticalParty> politicalParties = politicalPartyDAO.findActive();
            foreach (PoliticalParty politicalParty in politicalParties) {
                cboPoliticalParty.Items.Add(new ListItemWrapper<PoliticalParty>(politicalParty.Name, politicalParty));
            }

            if (politicalParties.Count > 0) cboPoliticalParty.SelectedIndex = 0;

            currentCandidate = new Candidate();

            refreshGoToList();
        }

        private void refreshGoToList() {
            IList<Candidate> candidates = candidateDAO.findAll();
            cboGoTo.Items.Clear();
            foreach (Candidate candidate in candidates) {
                cboGoTo.Items.Add(candidate);
            }
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            try {
                // To Do: Detect Dirty
                currentCandidate = new Candidate();
                refreshControls();
                base.btnAdd_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnAdd_Click", ex);
            }
        }

        private void refreshControls() {
            //clear the fields
            txtFirstName.Text = currentCandidate.FirstName;
            txtMiddleName.Text = currentCandidate.MiddleName;
            txtLastName.Text = currentCandidate.LastName;
            txtNotes.Text = currentCandidate.Notes;

            if (currentCandidate.PoliticalParty == null) {
                cboPoliticalParty.SelectedIndex = 0;
            } else {
                for (int i = 1, limit = cboPoliticalParty.Items.Count; i < limit; i++) {
                    if (((ListItemWrapper<PoliticalParty>) cboPoliticalParty.Items[i]).Value.ID ==
                        currentCandidate.PoliticalParty.ID) {
                        cboPoliticalParty.SelectedIndex = i;
                    }
                }
            }
            chkActive.Checked = currentCandidate.IsActive;

            refreshGoToList();
        }

        public override void btnDelete_Click(object sender, EventArgs e) {
            try {
                IList<Fault> faults = candidateDAO.canMakeTransient(currentCandidate);
                if (reportFaults(faults)) {
                    candidateDAO.makeTransient(currentCandidate);
                    refreshControls();
                    raiseMakeTransientEvent();
                }
            } catch (Exception ex) {
                reportException("btnDelete_Click", ex);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            try {
                // To Do: Validate Candidate
                currentCandidate.FirstName = txtFirstName.Text;
                currentCandidate.MiddleName = txtMiddleName.Text;
                currentCandidate.LastName = txtLastName.Text;
                currentCandidate.PoliticalParty =
                    ((ListItemWrapper<PoliticalParty>) cboPoliticalParty.SelectedItem).Value;
                currentCandidate.Notes = txtNotes.Text;
                currentCandidate.IsActive = chkActive.Checked;

                //Validate the current data and get a list of faults.
                IList<Fault> faultLst = candidateDAO.canMakePersistent(currentCandidate);

                bool persistData = reportFaults(faultLst);

                //If there were no errors, persist data to the database
                if (persistData) {
                    candidateDAO.makePersistent(currentCandidate);
                    refreshGoToList();
                    raiseMakePersistentEvent();
                }
            } catch (Exception ex) {
                reportException("btnSave_Click", ex);
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
                // To Do: Detect Dirty
                currentCandidate = (Candidate) cboGoTo.SelectedItem;
                refreshControls();
                base.cboGoTo_SelectedIndexChanged(sender, e);
            } catch (Exception ex) {
                reportException("cboGoTo_SelectedIndexChanged", ex);
            }
        }

        public void loadCandidate(long? id) {
            if (id.HasValue) {
                Candidate candidate = candidateDAO.findById(id, false);
                if (candidate != null) {
                    currentCandidate = candidate;
                    refreshControls();
                }
            }
        }

        private void cboPoliticalParty_Leave(object sender, EventArgs e) {
            try {
                if (cboPoliticalParty.SelectedIndex == -1) {
                    MessageBox.Show(
                        "Please use \"Insert > Political Party\" if you wish to create a new political party.");
                    cboPoliticalParty.SelectedIndex = 0;
                }
            } catch (Exception ex) {
                reportException("cboPoliticalParty_Leave", ex);
            }
        }
    }
}