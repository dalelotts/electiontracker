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
    internal partial class frmCounty : BaseMDIChild {
        private readonly CountyDAO countyDAO;
        private readonly PhoneNumberTypeDAO phoneNumberTypeDAO;
        private readonly AttributeTypeDAO attributeTypeDAO;

        private IList<CountyPhoneNumber> resetPhoneNums;
        private IList<CountyWebsite> resetWebsites;
        private IList<CountyAttribute> resetAttributes;

        private County currentCounty;

        public frmCounty(CountyDAO countyDAO, AttributeTypeDAO attributeTypeDAO, PhoneNumberTypeDAO phoneNumberTypeDAO) {
            InitializeComponent();

            this.countyDAO = countyDAO;
            this.attributeTypeDAO = attributeTypeDAO;
            this.phoneNumberTypeDAO = phoneNumberTypeDAO;

            resetPhoneNums = new List<CountyPhoneNumber>();
            resetWebsites = new List<CountyWebsite>();
            resetAttributes = new List<CountyAttribute>();

            refreshPhoneNumberTypes();
            refreshAttributeTypes();

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
            refreshGoToList();
        }

        private void refreshPhoneNumbers() {
            lstPhoneNums.Items.Clear();
            IList<CountyPhoneNumber> phoneNumbers = currentCounty.PhoneNumbers;
            foreach (CountyPhoneNumber phoneNumber in phoneNumbers) {
                lstPhoneNums.Items.Add(phoneNumber);
            }
        }

        private void refreshPhoneNumberTypes() {
            cbPhoneNumberType.Items.Clear();
            IList<PhoneNumberType> phoneNumberTypes = phoneNumberTypeDAO.findAll();
            foreach (PhoneNumberType phoneNumberType in phoneNumberTypes) {
                cbPhoneNumberType.Items.Add(new ListItemWrapper<PhoneNumberType>(phoneNumberType.Name, phoneNumberType));
            }

            if (phoneNumberTypes.Count > 0) cbPhoneNumberType.SelectedIndex = 0;
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

        private void refreshAttributeTypes() {
            cbKey.Items.Clear();
            IList<AttributeType> attributeTypes = attributeTypeDAO.findAll();
            foreach (AttributeType attributeType in attributeTypes) {
                cbKey.Items.Add(new ListItemWrapper<AttributeType>(attributeType.Name, attributeType));
            }

            if (attributeTypes.Count > 0) cbKey.SelectedIndex = 0;
        }

        private void btnAddPhoneNum_Click(object sender, EventArgs e) {
            try {
                CountyPhoneNumber tmpPhoneNumber = new CountyPhoneNumber();
                tmpPhoneNumber.AreaCode = txtAreaCode.Text;
                tmpPhoneNumber.PhoneNumber = txtPhoneNum.Text;
                tmpPhoneNumber.Type = ((ListItemWrapper<PhoneNumberType>) cbPhoneNumberType.SelectedItem).Value;
                currentCounty.PhoneNumbers.Add(tmpPhoneNumber);
                refreshPhoneNumbers();
            } catch (Exception ex) {
                reportException("btnAddPhoneNum_Click", ex);
            }
        }

        private void btnRemovePhoneNum_Click(object sender, EventArgs e) {
            try {
                if (lstPhoneNums.SelectedIndex >= 0) {
                    currentCounty.PhoneNumbers.RemoveAt(lstPhoneNums.SelectedIndex);
                    refreshPhoneNumbers();
                }
            } catch (Exception ex) {
                reportException("btnRemovePhoneNum_Click", ex);
            }
        }

        private void btnAddWebsite_Click(object sender, EventArgs e) {
            try {
                CountyWebsite tmpWebsite = new CountyWebsite();
                tmpWebsite.URL = txtWebsite.Text;
                currentCounty.Websites.Add(tmpWebsite);
                refreshWebsites();
            } catch (Exception ex) {
                reportException("btnAddWebsite_Click", ex);
            }
        }

        private void btnRemoveWebsite_Click(object sender, EventArgs e) {
            try {
                if (lstWebsites.SelectedIndex >= 0) {
                    currentCounty.Websites.RemoveAt(lstWebsites.SelectedIndex);
                    refreshWebsites();
                }
            } catch (Exception ex) {
                reportException("btnRemoveWebsite_Click", ex);
            }
        }

        private void btnAddAttribute_Click(object sender, EventArgs e) {
            try {
                CountyAttribute tmpAttribute = new CountyAttribute();
                if (cbKey != null) tmpAttribute.Type = ((ListItemWrapper<AttributeType>) cbKey.SelectedItem).Value;
                tmpAttribute.Value = txtValue.Text;
                currentCounty.Attributes.Add(tmpAttribute);
                refreshAttributes();
            } catch (Exception ex) {
                reportException("btnAddAttribute_Click", ex);
            }
        }

        private void btnRemoveAttribute_Click(object sender, EventArgs e) {
            try {
                if (lstAttributes.SelectedIndex >= 0) {
                    currentCounty.Attributes.RemoveAt(lstAttributes.SelectedIndex);
                    refreshAttributes();
                }
            } catch (Exception ex) {
                reportException("btnRemoveAttribute_Click", ex);
            }
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            try {
                currentCounty = new County();
                refreshControls();
                base.btnAdd_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnAdd_Click", ex);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            foreach (CountyPhoneNumber cpn in currentCounty.PhoneNumbers) {
                cpn.County = currentCounty;
            }
            foreach (CountyWebsite cw in currentCounty.Websites) {
                cw.County = currentCounty;
            }
            foreach (CountyAttribute ca in currentCounty.Attributes) {
                ca.County = currentCounty;
            }
            try {
                currentCounty.Name = txtCountyName.Text;
                currentCounty.Notes = txtNotes.Text;
                int i;
                Int32.TryParse(txtCountyWardCount.Text, out i);
                currentCounty.WardCount = i;

                IList<Fault> faults = countyDAO.canMakePersistent(currentCounty);
                bool persistData = reportFaults(faults);

                //If there were no errors, persist data to the database
                if (persistData) {
                    currentCounty = countyDAO.makePersistent(currentCounty);
                    refreshGoToList();
                    raiseMakePersistentEvent();
                }
            } catch (Exception ex) {
                reportException("btnSave_Click", ex);
            }
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            try {
                resetControls();
                base.btnReset_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnReset_Click", ex);
            }
        }

        private void resetControls() {
            txtCountyName.Text = currentCounty.Name;
            txtCountyWardCount.Text = currentCounty.WardCount.ToString();
            resetPhoneNumbers();
            resetSites();
            resetAttr();
        }

        private void resetPhoneNumbers() {
            lstPhoneNums.Items.Clear();
            foreach (CountyPhoneNumber cpn in resetPhoneNums) {
                lstPhoneNums.Items.Add(cpn);
            }

            IList<CountyPhoneNumber> removeList = new List<CountyPhoneNumber>();
            foreach (CountyPhoneNumber cpn in currentCounty.PhoneNumbers) {
                if (!resetPhoneNums.Contains(cpn))
                    removeList.Add(cpn);
            }

            foreach (CountyPhoneNumber cpn in removeList) {
                currentCounty.PhoneNumbers.Remove(cpn);
            }
        }

        private void resetSites() {
            lstWebsites.Items.Clear();
            foreach (CountyWebsite cws in resetWebsites) {
                lstWebsites.Items.Add(cws);
            }

            IList<CountyWebsite> removeList = new List<CountyWebsite>();
            foreach (CountyWebsite cws in currentCounty.Websites) {
                if (!resetWebsites.Contains(cws))
                    removeList.Add(cws);
            }

            foreach (CountyWebsite cws in removeList) {
                currentCounty.Websites.Remove(cws);
            }
        }

        private void resetAttr() {
            lstAttributes.Items.Clear();
            foreach (CountyAttribute ca in resetAttributes) {
                lstAttributes.Items.Add(ca);
            }

            IList<CountyAttribute> removeList = new List<CountyAttribute>();
            foreach (CountyAttribute ca in currentCounty.Attributes) {
                if (!resetAttributes.Contains(ca))
                    removeList.Add(ca);
            }

            foreach (CountyAttribute ca in removeList) {
                currentCounty.Attributes.Remove(ca);
            }
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                currentCounty = (County) cboGoTo.SelectedItem;
                refreshControls();
                base.cboGoTo_SelectedIndexChanged(sender, e);
            } catch (Exception ex) {
                reportException("cboGoTo_SelectedIndexChanged", ex);
            }
        }

        public override void btnDelete_Click(object sender, EventArgs e) {
            try {
                IList<Fault> faults = countyDAO.canMakeTransient(currentCounty);
                if (reportFaults(faults)) {
                    countyDAO.makeTransient(currentCounty);
                    currentCounty = new County();
                    refreshControls();
                    raiseMakeTransientEvent();
                }
            } catch (Exception ex) {
                reportException("btnDelete_Click", ex);
            }
        }

        public void loadCounty(long? id) {
            try {
                if (id.HasValue) {
                    County county = countyDAO.findById(id.Value, false);
                    if (county != null) {
                        currentCounty = county;
                        foreach (CountyPhoneNumber cpn in currentCounty.PhoneNumbers) {
                            resetPhoneNums.Add(cpn);
                        }
                        foreach (CountyWebsite cws in currentCounty.Websites) {
                            resetWebsites.Add(cws);
                        }
                        foreach (CountyAttribute ca in currentCounty.Attributes) {
                            resetAttributes.Add(ca);
                        }
                        refreshControls();
                    }
                }
            } catch (Exception ex) {
                reportException("loadCounty", ex);
            }
        }

        private void cbPhoneNumberType_Leave(object sender, EventArgs e) {
            try {
                if ((cbPhoneNumberType.SelectedIndex == -1) && (!cbPhoneNumberType.Text.Equals(""))) {
                    String newTypeName = cbPhoneNumberType.Text;
                    String message = "Phone number type \"" + newTypeName +
                                     "\" does not exist.\nWould you like to create it?";
                    String caption = "Unidentified Type";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.Yes) {
                        PhoneNumberType newType = new PhoneNumberType();
                        newType.Name = newTypeName;
                        phoneNumberTypeDAO.makePersistent(newType);
                        refreshPhoneNumberTypes();

                        for (int i = 0; i < cbPhoneNumberType.Items.Count; i++) {
                            if (
                                (((ListItemWrapper<PhoneNumberType>) cbPhoneNumberType.Items[i]).Value).Name.Equals(
                                    newTypeName)) {
                                cbPhoneNumberType.SelectedIndex = i;
                            }
                        }
                    }
                    if (result == DialogResult.No) {
                        cbPhoneNumberType.SelectedIndex = 0;
                    }
                }
            } catch (Exception ex) {
                reportException("cbPhoneNumberType_Leave", ex);
            }
        }

        private void cbKey_Leave(object sender, EventArgs e) {
            try {
                if ((cbKey.SelectedIndex == -1) && (!cbKey.Text.Equals(""))) {
                    String newTypeName = cbKey.Text;
                    String message = "Attribute \"" + newTypeName + "\" does not exist.\nWould you like to create it?";
                    String caption = "Unidentified Attribute";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.Yes) {
                        AttributeType newType = new AttributeType();
                        newType.Name = newTypeName;
                        attributeTypeDAO.makePersistent(newType);
                        refreshAttributeTypes();

                        for (int i = 0; i < cbKey.Items.Count; i++) {
                            if ((((ListItemWrapper<AttributeType>) cbKey.Items[i]).Value).Name.Equals(newTypeName)) {
                                cbKey.SelectedIndex = i;
                            }
                        }
                    }
                    if (result == DialogResult.No) {
                        cbKey.SelectedIndex = 0;
                    }
                }
            } catch (Exception ex) {
                reportException("cbKey_Leave", ex);
            }
        }
    }
}