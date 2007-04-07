using System;
using System.Collections.Generic;
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
            // To Do: Detect Dirty
            currentCandidate = new Candidate();
            refreshControls();
            base.btnAdd_Click(sender, e);
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
                for (int i = 1, limit = cboPoliticalParty.Items.Count; i < limit; i++)
                {
                    if (((ListItemWrapper<PoliticalParty>)cboPoliticalParty.Items[i]).Value.ID == currentCandidate.PoliticalParty.ID) {
                        cboPoliticalParty.SelectedIndex = i;
                    }
                }
            }
            chkActive.Checked = currentCandidate.IsActive; 
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            // To Do: Validate Candidate
            currentCandidate.FirstName = txtFirstName.Text;
            currentCandidate.MiddleName = txtMiddleName.Text;
            currentCandidate.LastName = txtLastName.Text;
            currentCandidate.PoliticalParty = ((ListItemWrapper<PoliticalParty>)cboPoliticalParty.SelectedItem).Value;
            currentCandidate.Notes = txtNotes.Text;
            currentCandidate.IsActive = chkActive.Checked;

            //persist candidate to db
            candidateDAO.makePersistent(currentCandidate);
            refreshGoToList();
            base.btnSave_Click(sender, e);
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            refreshControls();
            base.btnReset_Click(sender, e);
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            // To Do: Detect Dirty
            currentCandidate = (Candidate)cboGoTo.SelectedItem;
            refreshControls();
            base.cboGoTo_SelectedIndexChanged(sender, e);
        }
    }
}