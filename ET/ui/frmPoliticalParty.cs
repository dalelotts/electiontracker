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
    internal partial class frmPoliticalParty : BaseMDIChild {
        private readonly PoliticalPartyDAO politicalPartyDAO;
        private Boolean dirty;
        private PoliticalParty currentPoliticalParty;

        public frmPoliticalParty(PoliticalPartyDAO politicalPartyDAO) {
            InitializeComponent();
            this.politicalPartyDAO = politicalPartyDAO;
            currentPoliticalParty = new PoliticalParty();
            refreshControls();
            refreshGoToList();
            txtAbbrev.TextChanged += new EventHandler(DataChanged);
            txtName.TextChanged += new EventHandler(DataChanged);
            dirty = false;
        }

        private void refreshControls() {
            txtName.Text = currentPoliticalParty.Name;
            txtAbbrev.Text = currentPoliticalParty.Abbreviation;
            chkActive.Checked = currentPoliticalParty.IsActive;
            refreshGoToList();
        }

        private void refreshGoToList() {
            IList<PoliticalParty> politicalParties = politicalPartyDAO.findAll();
            foreach (PoliticalParty politicalParty in politicalParties) {
                cboGoTo.Items.Add(politicalParty);
            }
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            try {
                currentPoliticalParty = new PoliticalParty();
                refreshControls();
                base.btnAdd_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnAdd_Click", ex);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            try {
                currentPoliticalParty.Name = txtName.Text;
                currentPoliticalParty.Abbreviation = txtAbbrev.Text;
                currentPoliticalParty.IsActive = chkActive.Checked;

                IList<Fault> faults = politicalPartyDAO.canMakePersistent(currentPoliticalParty);

                //If there were no errors, persist data to the database
                if (reportFaults(faults)) {
                    currentPoliticalParty = politicalPartyDAO.makePersistent(currentPoliticalParty);
                    refreshGoToList();
                    raiseMakePersistentEvent();
                    MessageBox.Show(this, currentPoliticalParty.Name + " party saved.", "Sucessful Save");;
                }
            } catch (Exception ex) {
                reportException("btnSave_Click", ex);
            }
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            try {
                currentPoliticalParty = currentPoliticalParty.ID == 0 ? new PoliticalParty() : politicalPartyDAO.findById(currentPoliticalParty.ID, false);
                refreshControls();
                base.btnReset_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnReset_Click", ex);
            }
        }

        public override void btnDelete_Click(object sender, EventArgs e) {
            //delete's but throws an error
            try {
                IList<Fault> faults = politicalPartyDAO.canMakeTransient(currentPoliticalParty);
                if (reportFaults(faults)) {
                    politicalPartyDAO.makeTransient(currentPoliticalParty);
                    currentPoliticalParty = new PoliticalParty();
                    refreshControls();
                    raiseMakeTransientEvent();
                }
            } catch (Exception ex) {
                reportException("btnDelete_Click", ex);
            }
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                currentPoliticalParty = (PoliticalParty) cboGoTo.SelectedItem;
                refreshControls();
                base.cboGoTo_SelectedIndexChanged(sender, e);
                dirty = false;
            } catch (Exception ex) {
                reportException("cboGoTo_SelectedIndexChanged", ex);
            }
        }

        public void loadPoliticalParty(long? id) {
            try {
                if (id.HasValue) {
                    PoliticalParty party = politicalPartyDAO.findById(id.Value, false);
                    if (party != null) {
                        currentPoliticalParty = party;
                        refreshControls();
                    }
                }
                dirty = false;
            } catch (Exception ex) {
                reportException("loadPoliticalParty", ex);
            }
        }
        // Event handler.  Marks the Candidate form as dirty.
        private void DataChanged(object sender, EventArgs e)
        {
            dirty = true;
        }
        private void frmPoliticalParty_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check for dirty
            if (dirty)
            {
                DialogResult dr = MessageBox.Show("Do you want to save Political Party before closing?", "Political Party not saved", MessageBoxButtons.YesNo);
                if (String.Equals("Yes", dr.ToString()))
                {
                    btnSave_Click(sender, e);
                }

            }
        }
    }
}