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
        private readonly IList<Candidate> allCandidates;

        public frmPoliticalParty(PoliticalPartyDAO politicalPartyDAO, ICandidateDAO candidateDAO)
        {
            InitializeComponent();
            this.politicalPartyDAO = politicalPartyDAO;
            currentPoliticalParty = new PoliticalParty();
            refreshControls();
            txtAbbrev.TextChanged += new EventHandler(DataChanged);
            txtName.TextChanged += new EventHandler(DataChanged);
            allCandidates = candidateDAO.findAll();
            dirty = false;
        }

        private void refreshControls() {
            txtName.Text = currentPoliticalParty.Name;
            txtAbbrev.Text = currentPoliticalParty.Abbreviation;
            chkActive.Checked = currentPoliticalParty.IsActive;
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
            //because its trying to save the data - dont save when its a null string in party name
            try {
                bool containCandidates = false;
                int index = 0;
                /*The user is unable to delete a party if it has candidates due to a foreign key constraint on the database.
                 * A list of candidates belonging to the party is not automatically generated when party information is
                 * queried.  Have to pull all candidates from database and check to see if any of them are members.
                 This is extrememly inefficient and will get slower as candidates are added*/
                while(!containCandidates &&(index < allCandidates.Count))   
                {
                    if (allCandidates[index].PoliticalParty != null)
                    {
                        if (allCandidates[index].PoliticalParty.ID==currentPoliticalParty.ID)
                        {
                            containCandidates = true;
                        }
                    }
                    index++;
                }

                IList<Fault> faults = politicalPartyDAO.canMakeTransient(currentPoliticalParty);
                if (reportFaults(faults) && !containCandidates)
                {
                    politicalPartyDAO.makeTransient(currentPoliticalParty);
                    currentPoliticalParty = new PoliticalParty();
                    refreshControls();
                    raiseMakeTransientEvent();
                    dirty = false;
                }else
                {
                    MessageBox.Show("Cannot Delete a party with members","Cannot Delete",MessageBoxButtons.OK);
                }
            } catch (Exception ex) {
                reportException("btnDelete_Click", ex);
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
                if (String.Equals("Yes", dr.ToString()) && !this.txtName.Text.ToString().Equals(""))
                {
                    btnSave_Click(sender, e);
                }

            }
        }
    }
}