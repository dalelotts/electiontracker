using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmPoliticalParty : BaseMDIChild {
        private readonly PoliticalPartyDAO politicalPartyDAO;

        private PoliticalParty currentPoliticalParty;

        public frmPoliticalParty(PoliticalPartyDAO politicalPartyDAO) {
            InitializeComponent();
            this.politicalPartyDAO = politicalPartyDAO;
            currentPoliticalParty = new PoliticalParty();
            refreshControls();
            refreshGoToList();
        }

        private void refreshControls() {
            txtName.Text = currentPoliticalParty.Name;
            txtAbbrev.Text = currentPoliticalParty.Abbreviation;
            chkActive.Checked = currentPoliticalParty.IsActive;
        }

        private void refreshGoToList() {
            IList<PoliticalParty> politicalParties = politicalPartyDAO.findAll();
            foreach (PoliticalParty politicalParty in politicalParties) {
                cboGoTo.Items.Add(politicalParty);
            }
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            currentPoliticalParty = new PoliticalParty();
            refreshControls();
            base.btnAdd_Click(sender, e);
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            //TODO validate political party
            currentPoliticalParty.Name = txtName.Text;
            currentPoliticalParty.Abbreviation = txtAbbrev.Text;
            currentPoliticalParty.IsActive = chkActive.Checked;

            //persist political party to db
            politicalPartyDAO.makePersistent(currentPoliticalParty);
            refreshGoToList();
            base.btnSave_Click(sender, e);
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            refreshControls();
            base.btnReset_Click(sender, e);
        }

        public override void btnDelete_Click(object sender, EventArgs e) {
            politicalPartyDAO.makeTransient(currentPoliticalParty);
            currentPoliticalParty = new PoliticalParty();
            refreshControls();
            refreshGoToList();
            base.btnDelete_Click(sender, e);
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            currentPoliticalParty = (PoliticalParty) cboGoTo.SelectedItem;
            refreshControls();
            base.cboGoTo_SelectedIndexChanged(sender, e);
        }

        public void loadPoliticalParty(long? id)
        {
            if (id.HasValue) {
                PoliticalParty party = politicalPartyDAO.findById(id, false);
                if (party != null) {
                    currentPoliticalParty = party;
                    refreshControls();
                }
            }
        }
    }
}