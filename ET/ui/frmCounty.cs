using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui.util;
using log4net;
using System.Windows.Forms;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmCounty : BaseMDIChild {
        private readonly CountyDAO countyDAO;

        private static readonly ILog LOG = LogManager.GetLogger(typeof (frmContest));

        private County currentCounty;

        public frmCounty(CountyDAO countyDAO, AttributeTypeDAO attributeTypeDAO, PhoneNumberTypeDAO phoneNumberTypeDAO) {
            InitializeComponent();

            this.countyDAO = countyDAO;

            IList<PhoneNumberType> phoneNumberTypes = phoneNumberTypeDAO.findAll();
            foreach (PhoneNumberType phoneNumberType in phoneNumberTypes) {
                cbPhoneNumberType.Items.Add(new ListItemWrapper<PhoneNumberType>(phoneNumberType.Name, phoneNumberType));
            }

            if (phoneNumberTypes.Count > 0) cbPhoneNumberType.SelectedIndex = 0;

            IList<AttributeType> attributeTypes = attributeTypeDAO.findAll();
            foreach (AttributeType attributeType in attributeTypes) {
                cbKey.Items.Add(new ListItemWrapper<AttributeType>(attributeType.Name, attributeType));
            }

            if (attributeTypes.Count > 0) cbKey.SelectedIndex = 0;

            currentCounty = new County();
            refreshGoToList();
        }


        private void refreshGoToList() {
            IList<County> counties = countyDAO.findAll();
            cboGoTo.Items.Clear();
            foreach (County county in counties) {
                cboGoTo.Items.Add(county);
            }
        }

        private void refreshControls() {
            //clear the fields
            txtCountyName.Text = currentCounty.Name;
            txtCountyWardCount.Text = currentCounty.WardCount.ToString();
            txtNotes.Text = currentCounty.Notes;

            refreshPhoneNumbers();
            refreshWebsites();
            refreshAttributes();
        }

        private void refreshPhoneNumbers() {
            lstPhoneNums.Items.Clear();
            IList<CountyPhoneNumber> phoneNumbers = currentCounty.PhoneNumbers;
            foreach (CountyPhoneNumber phoneNumber in phoneNumbers) {
                lstPhoneNums.Items.Add(phoneNumber);
            }
        }

        private void refreshWebsites() {
            lstWebsites.Items.Clear();
            IList<CountyWebsite> websites = currentCounty.Websites;
            foreach (CountyWebsite website in websites) {
                lstWebsites.Items.Add(website);
            }
        }

        private void refreshAttributes() {
            lstAttributes.Items.Clear();
            IList<CountyAttribute> attributes = currentCounty.Attributes;
            foreach (CountyAttribute attribute in attributes) {
                lstAttributes.Items.Add(attribute);
            }
        }

        private void btnAddPhoneNum_Click(object sender, EventArgs e) {
            CountyPhoneNumber tmpPhoneNumber = new CountyPhoneNumber();
            tmpPhoneNumber.AreaCode = txtAreaCode.Text;
            tmpPhoneNumber.PhoneNumber = txtPhoneNum.Text;
            tmpPhoneNumber.Type = ((ListItemWrapper<PhoneNumberType>) cbPhoneNumberType.SelectedItem).Value;
            currentCounty.PhoneNumbers.Add(tmpPhoneNumber);
            refreshPhoneNumbers();
        }

        private void btnRemovePhoneNum_Click(object sender, EventArgs e) {
            if (lstPhoneNums.SelectedIndex >= 0) {
                currentCounty.PhoneNumbers.RemoveAt(lstPhoneNums.SelectedIndex);
                refreshPhoneNumbers();
            }
        }

        private void btnAddWebsite_Click(object sender, EventArgs e) {
            CountyWebsite tmpWebsite = new CountyWebsite();
            tmpWebsite.URL = txtWebsite.Text;
            currentCounty.Websites.Add(tmpWebsite);
            refreshWebsites();
        }

        private void btnRemoveWebsite_Click(object sender, EventArgs e) {
            if (lstWebsites.SelectedIndex >= 0) {
                currentCounty.Websites.RemoveAt(lstWebsites.SelectedIndex);
                refreshWebsites();
            }
        }

        private void btnAddAttribute_Click(object sender, EventArgs e) {
            CountyAttribute tmpAttribute = new CountyAttribute();
            if (cbKey != null) tmpAttribute.Type = ((ListItemWrapper<AttributeType>) cbKey.SelectedItem).Value;
            tmpAttribute.Value = txtValue.Text;
            currentCounty.Attributes.Add(tmpAttribute);
            refreshAttributes();
        }

        private void btnRemoveAttribute_Click(object sender, EventArgs e) {
            if (lstAttributes.SelectedIndex >= 0) {
                currentCounty.Attributes.RemoveAt(lstAttributes.SelectedIndex);
                refreshAttributes();
            }
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            currentCounty = new County();
            refreshControls();
            base.btnAdd_Click(sender, e);
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            try {
                
                currentCounty.Name = txtCountyName.Text;
                currentCounty.Notes = txtNotes.Text;
                currentCounty.WardCount = int.Parse(txtCountyWardCount.Text);

//                foreach (CountyPhoneNumber cfn in lstPhoneNums.Items) {
//                    cfn.County = currentCounty;
//                    currentCounty.PhoneNumbers.Add(cfn);
//                }
//
//                foreach (CountyWebsite cws in lstWebsites.Items) {
//                    cws.County = currentCounty;
//                    currentCounty.Websites.Add(cws);
//                }
//
//                foreach (CountyAttribute cat in lstAttributes.Items) {
//                    cat.County = currentCounty;
//                    currentCounty.Attributes.Add(cat);
//                }

                IList<Fault> faultLst = countyDAO.validate(currentCounty);
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
                            if (result == System.Windows.Forms.DialogResult.No)
                            {
                                persistData = false;
                            }
                        }
                    }
                }
                
                //If there were no errors, persist data to the database
                if (persistData)
                {
                    countyDAO.makePersistent(currentCounty);
                    refreshGoToList();
                }
            } catch (Exception ex) {
                LOG.Error("unable to save: operation failed", ex);
            }
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            refreshControls();
            base.btnReset_Click(sender, e);
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            currentCounty = (County) cboGoTo.SelectedItem;
            refreshControls();
            base.cboGoTo_SelectedIndexChanged(sender, e);
        }

        public override void btnDelete_Click(object sender, EventArgs e) {
            countyDAO.makeTransient(currentCounty);
            currentCounty = new County();
            refreshControls();
            refreshGoToList();
            base.btnDelete_Click(sender, e);
        }

        public void loadCounty(long? id) {
            if (id.HasValue) {
                County county = countyDAO.findById(id, false);
                if (county != null) {
                    currentCounty = county;
                    refreshControls();
                }
            }
        }

        private void frmCounty_Load(object sender, EventArgs e)
        {
           // System.Windows.Forms.MessageBox.Show(lblCountyWardCount.back);
        }
    }
}