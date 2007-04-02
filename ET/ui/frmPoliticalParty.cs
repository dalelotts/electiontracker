using System;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    internal partial class frmPoliticalParty : Form
    {
        private readonly PoliticalPartyDAO politicalPartyDAO;

        public frmPoliticalParty(PoliticalPartyDAO politicalPartyDAO)
        {
            InitializeComponent();
            this.politicalPartyDAO = politicalPartyDAO;
        }

        private void btnPPReset_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void btnPPNew_Click(object sender, EventArgs e)
        {
            //clear the fields
            txtName.Text = "";
            txtAbbrev.Text = "";
            chkActive.Checked = true; //default to active

            //make fields editable
            txtName.Enabled = true;
            txtAbbrev.Enabled = true;
            chkActive.Enabled = true;
        }

        private void btnPPEdit_Click(object sender, EventArgs e)
        {
            //make fields editable
            txtName.Enabled = true;
            txtAbbrev.Enabled = true;
            chkActive.Enabled = true;
        }

        private void btnPPSave_Click(object sender, EventArgs e)
        {
            //TODO validate political party

            PoliticalParty pp = new PoliticalParty();
            pp.Name = txtName.Text;
            pp.Abbreviation = txtAbbrev.Text;
            pp.IsActive = chkActive.Checked;

            //make fields uneditable
            txtName.Enabled = false;
            txtAbbrev.Enabled = false;
            chkActive.Enabled = false;

            //persist political party to db
            politicalPartyDAO.makePersistent(pp);
        }


    }
}