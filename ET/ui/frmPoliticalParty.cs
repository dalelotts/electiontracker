using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    internal partial class frmPoliticalParty : BaseMDIChild
    {
        private readonly PoliticalPartyDAO politicalPartyDAO;

        private PoliticalParty currentPoliticalParty;

        public frmPoliticalParty(PoliticalPartyDAO politicalPartyDAO)
        {
            InitializeComponent();
            this.politicalPartyDAO = politicalPartyDAO;
            currentPoliticalParty = new PoliticalParty();
            refreshControls();
            refreshGoToList();
        }

        private void refreshControls()
        {
            txtName.Text = currentPoliticalParty.Name;
            txtAbbrev.Text = currentPoliticalParty.Abbreviation;
            chkActive.Checked = currentPoliticalParty.IsActive;
        }

        private void refreshGoToList()
        {
            IList<PoliticalParty> politicalParties = politicalPartyDAO.findAll();
            foreach (PoliticalParty politicalParty in politicalParties)
            {
                cboGoTo.Items.Add(politicalParty);
            }
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                currentPoliticalParty = new PoliticalParty();
                refreshControls();
                base.btnAdd_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO performValidation political party
                currentPoliticalParty.Name = txtName.Text;
                currentPoliticalParty.Abbreviation = txtAbbrev.Text;
                currentPoliticalParty.IsActive = chkActive.Checked;

                IList<Fault> faultLst = politicalPartyDAO.validate(currentPoliticalParty);
                bool persistData = true;

                //Go through the list of faults and display warnings and errors.
                foreach (Fault fault in faultLst)
                {
                    if (persistData)
                    {
                        if (fault.IsError)
                        {
                            persistData = false;
                            MessageBox.Show("Error: " + fault.Message);
                        }
                        else
                        {
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result = MessageBox.Show("Warning: " + fault.Message + "\n\nWould you like to save anyway?", "Warning Message", buttons);
                            if (result == DialogResult.No)
                            {
                                persistData = false;
                            }
                        }
                    }
                }

                //If there were no errors, persist data to the database
                if (persistData)
                {
                    politicalPartyDAO.makePersistent(currentPoliticalParty);
                    refreshGoToList();
                    base.btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        public override void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                refreshControls();
                base.btnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        public override void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                politicalPartyDAO.makeTransient(currentPoliticalParty);
                currentPoliticalParty = new PoliticalParty();
                refreshControls();
                refreshGoToList();
                base.btnDelete_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentPoliticalParty = (PoliticalParty)cboGoTo.SelectedItem;
                refreshControls();
                base.cboGoTo_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        public void loadPoliticalParty(long? id)
        {
            try
            {
                if (id.HasValue)
                {
                    PoliticalParty party = politicalPartyDAO.findById(id, false);
                    if (party != null)
                    {
                        currentPoliticalParty = party;
                        refreshControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }
}