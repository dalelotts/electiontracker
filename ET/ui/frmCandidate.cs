using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmCandidate : Form {
        private readonly CandidateDAO candidateDAO;
        
        public frmCandidate(CandidateDAO candidateDAO, PoliticalPartyDAO politicalPartyDAO) {
            InitializeComponent();

            cboPoliticalParty.Items.Add(new PoliticalPartyItem("< NONE >"));

            IList<PoliticalParty> politicalParties = politicalPartyDAO.findActive();
            foreach (PoliticalParty politicalParty in politicalParties) {
                cboPoliticalParty.Items.Add(new PoliticalPartyItem(politicalParty));
            }
            
            if (politicalParties.Count > 0) cboPoliticalParty.SelectedIndex = 0;

            this.candidateDAO = candidateDAO;
        }


        private void btnCandReset_Click(object sender, System.EventArgs e)
        {
            //TODO
        }

        private void btnCandNew_Click(object sender, System.EventArgs e)
        {
            //clear the fields
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            cboPoliticalParty.SelectedIndex = 0;
            txtNotes.Text = "";
            chkActive.Checked = true; //default to active

            //make fields editable
            txtFirstName.Enabled = true;
            txtMiddleName.Enabled = true;
            txtLastName.Enabled = true;
            cboPoliticalParty.Enabled = true;
            txtNotes.Enabled = true;
            chkActive.Enabled = true;
        }

        private void btnCandEdit_Click(object sender, System.EventArgs e)
        {
            //make fields editable
            txtFirstName.Enabled = true;
            txtMiddleName.Enabled = true;
            txtLastName.Enabled = true;
            cboPoliticalParty.Enabled = true;
            txtNotes.Enabled = true;
            chkActive.Enabled = true;
        }

        private void btnSave_Click(object sender, System.EventArgs e) {

            // To Do: Validate Candidate

            Candidate candidate = new Candidate();
            candidate.FirstName = txtFirstName.Text;
            candidate.MiddleName = txtMiddleName.Text;
            candidate.LastName = txtLastName.Text;
            candidate.PoliticalParty = ((PoliticalPartyItem) cboPoliticalParty.SelectedItem).Party;
            candidate.Notes = txtNotes.Text;
            candidate.IsActive = chkActive.Checked;

            //make fields uneditable
            txtFirstName.Enabled = false;
            txtMiddleName.Enabled = false;
            txtLastName.Enabled = false;
            cboPoliticalParty.Enabled = false;
            txtNotes.Enabled = false;
            chkActive.Enabled = false;

            //persist candidate to db
            candidateDAO.makePersistent(candidate);
        }

    }

    internal class PoliticalPartyItem {
        private readonly string displayName;
        private readonly PoliticalParty party;

        public PoliticalPartyItem(string displayName) {
            this.displayName = displayName;
            party = null;
        }


        public PoliticalPartyItem(PoliticalParty party) {
            displayName = party.Name;
            this.party = party;
        }

        public override string ToString() {
            return displayName;
        }

        public PoliticalParty Party {
            get { return party; }
        }
    }
}