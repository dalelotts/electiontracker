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
using KnightRider.ElectionTracker.ui.util;

namespace KnightRider.ElectionTracker.ui {
    internal partial class frmCandidate : BaseMDIChild {
        private readonly ICandidateDAO candidateDAO;
        private Candidate currentCandidate;
        private Boolean dirty;

        public frmCandidate(ICandidateDAO candidateDAO, PoliticalPartyDAO politicalPartyDAO) {
            InitializeComponent();
            this.candidateDAO = candidateDAO;

            cboPoliticalParty.Items.Add(new ListItemWrapper<PoliticalParty>("< NONE >", null));

            IList<PoliticalParty> politicalParties = politicalPartyDAO.findActive();
            foreach (PoliticalParty politicalParty in politicalParties) {
                cboPoliticalParty.Items.Add(new ListItemWrapper<PoliticalParty>(politicalParty.Name, politicalParty));
            }

            currentCandidate = new Candidate();
            //set up text boxes with a hanlder for text changed
            txtFirstName.TextChanged += new EventHandler(DataChanged);
            txtLastName.TextChanged += new EventHandler(DataChanged);
            txtMiddleName.TextChanged += new EventHandler(DataChanged);
            txtNotes.TextChanged += new EventHandler(DataChanged);
            cboPoliticalParty.TextChanged += new EventHandler(DataChanged);
            dirty = false;
        }
        // Event handler.  Marks the Candidate form as dirty.
        private void DataChanged(object sender, EventArgs e)
        {
            dirty = true;
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            if (dirty)
            {
                DialogResult dr = MessageBox.Show("Do you want to save the current record first?", "Candidate not saved", MessageBoxButtons.YesNo);
                if (String.Equals(dr.ToString(), "Yes"))
                {
                    //save record
                    btnSave_Click(sender, e);
                }
            }
            try
            {
                // To Do: Detect Dirty
                currentCandidate = new Candidate();
                refreshControls();
                base.btnAdd_Click(sender, e);
            }
            catch (Exception ex)
            {
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
                    if (((ListItemWrapper<PoliticalParty>) cboPoliticalParty.Items[i]).Value.ID == currentCandidate.PoliticalParty.ID) {
                        cboPoliticalParty.SelectedIndex = i;
                    }
                }
            }
            chkActive.Checked = currentCandidate.IsActive;

            dirty = false;
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
                currentCandidate.FirstName = txtFirstName.Text;
                currentCandidate.MiddleName = txtMiddleName.Text;
                currentCandidate.LastName = txtLastName.Text;
                currentCandidate.PoliticalParty = ((ListItemWrapper<PoliticalParty>) cboPoliticalParty.SelectedItem).Value;
                currentCandidate.Notes = txtNotes.Text;
                currentCandidate.IsActive = chkActive.Checked;

                IList<Fault> faults = candidateDAO.canMakePersistent(currentCandidate);

                bool persistData = reportFaults(faults);

                //If there were no errors, persist data to the database
                if (persistData) {
                    currentCandidate = candidateDAO.makePersistent(currentCandidate);
                    raiseMakePersistentEvent();
                    MessageBox.Show(this, currentCandidate + " saved.", "Sucessful Save");
                }
            } catch (Exception ex) {
                reportException("btnSave_Click", ex);
            }
            dirty = false;
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            try {
                currentCandidate = currentCandidate.ID == 0 ? new Candidate() : candidateDAO.findById(currentCandidate.ID, false);
                refreshControls();
                base.btnReset_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnReset_Click", ex);
            }
        }

        public void loadCandidate(long? id) {
            if (id.HasValue) {
                Candidate candidate = candidateDAO.findById(id.Value, false);
                if (candidate != null) {
                    currentCandidate = candidate;
                }
            }
            refreshControls();
            dirty = false;
        }

        private void cboPoliticalParty_Leave(object sender, EventArgs e) {
            try {
                if (cboPoliticalParty.SelectedIndex == -1) {
                    MessageBox.Show("Please use \"Insert > Political Party\" if you wish to create a new political party.");
                    cboPoliticalParty.SelectedIndex = 0;
                }
            } catch (Exception ex) {
                reportException("cboPoliticalParty_Leave", ex);
            }
        }
        private void frmCandidate_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check for dirty
            if (dirty)
            {
                DialogResult dr = MessageBox.Show("Do you want to save Candidate before closing?", "Candidate not saved", MessageBoxButtons.YesNo);
                if (String.Equals("Yes",dr.ToString()))
                {
                    btnSave_Click(sender, e);
                }

            }
        }
    }
}