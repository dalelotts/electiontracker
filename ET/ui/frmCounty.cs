using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.ui.util;
using log4net;
using Spring.Collections;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    internal partial class frmCounty : Form
    {
        private readonly CountyDAO countyDAO;
        private readonly AttributeTypeDAO attributeTypeDAO;
        private readonly PhoneNumberTypeDAO phoneNumberTypeDAO;
        private readonly CountyWebsiteDAO countyWebsiteDAO;
        private readonly CountyPhoneNumberDAO countyPhoneNumberDAO;
        private readonly CountyAttributeDAO countyAttributeDAO;


        private static readonly ILog LOG = LogManager.GetLogger(typeof(frmContest));

        public frmCounty(CountyDAO countyDAO, AttributeTypeDAO attributeTypeDAO, PhoneNumberTypeDAO phoneNumberTypeDAO, CountyWebsiteDAO countyWebsiteDAO, CountyAttributeDAO countyAttributeDAO, CountyPhoneNumberDAO countyPhoneNumberDAO)
        {
            InitializeComponent();
            this.countyDAO = countyDAO;
            this.phoneNumberTypeDAO = phoneNumberTypeDAO;
            this.attributeTypeDAO = attributeTypeDAO;
            this.countyWebsiteDAO = countyWebsiteDAO;
            this.countyAttributeDAO = countyAttributeDAO;
            this.countyPhoneNumberDAO = countyPhoneNumberDAO;
        }

        private void btnAddPhoneNum_Click(object sender, EventArgs e)
        {
            CountyPhoneNumber tmpPhoneNumber = new CountyPhoneNumber();
            tmpPhoneNumber.AreaCode = txtAreaCode.Text;
            tmpPhoneNumber.PhoneNumber = txtPhoneNum.Text;
            tmpPhoneNumber.Type = ((ListItemWrapper<PhoneNumberType>)cbPhoneNumberType.SelectedItem).Value;

            lstPhoneNums.Items.Add(tmpPhoneNumber);
        }

        private void btnRemovePhoneNum_Click(object sender, EventArgs e)
        {
            if (lstPhoneNums.SelectedIndex >= 0)
            {
                lstPhoneNums.Items.RemoveAt(lstPhoneNums.SelectedIndex);
            }
        }

        private void btnAddWebsite_Click(object sender, EventArgs e)
        {
            CountyWebsite tmpWebsite = new CountyWebsite();
            tmpWebsite.URL = txtWebsite.Text;
            lstWebsites.Items.Add(tmpWebsite);
        }

        private void btnRemoveWebsite_Click(object sender, EventArgs e)
        {
            if (lstWebsites.SelectedIndex >= 0)
            {
                lstWebsites.Items.RemoveAt(lstWebsites.SelectedIndex);
            }
        }

        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            CountyAttribute tmpAttribute = new CountyAttribute();
            if (cbKey != null) tmpAttribute.Type = ((ListItemWrapper<AttributeType>)cbKey.SelectedItem).Value;
            tmpAttribute.Value = txtValue.Text;
            lstAttributes.Items.Add(tmpAttribute);
        }

        private void btnRemoveAttribute_Click(object sender, EventArgs e)
        {
            if (lstAttributes.SelectedIndex >= 0)
            {
                lstAttributes.Items.RemoveAt(lstAttributes.SelectedIndex);
            }
        }

        private void btnCountySave_Click(object sender, EventArgs e)
        {
            try
            {
                County county = new County();
                county.Name = txtCountyName.Text;
                county.Notes = txtNotes.Text;
                county.WardCount = int.Parse(txtCountyWardCount.Text);


                IList<CountyPhoneNumber> tmpPhoneNumber = new List<CountyPhoneNumber>();
                foreach (CountyPhoneNumber cfn in lstPhoneNums.Items)
                {
                    cfn.County = county;
                    tmpPhoneNumber.Add(cfn);
                }

                IList<CountyWebsite> tmpWebsite = new List<CountyWebsite>();
                foreach (CountyWebsite cws in lstWebsites.Items)
                {
                    cws.County = county;
                    tmpWebsite.Add(cws);
                }

                IList<CountyAttribute> tmpAttribute = new List<CountyAttribute>();
                foreach (CountyAttribute cat in lstAttributes.Items)
                {
                    cat.County = county;
                    tmpAttribute.Add(cat);
                }


                countyDAO.makePersistent(county);

                foreach (CountyPhoneNumber cfn in tmpPhoneNumber)
                {
                    cfn.County = county;
                    countyPhoneNumberDAO.makePersistent(cfn);
                }

                foreach (CountyWebsite cws in tmpWebsite)
                {
                    cws.County = county;
                    countyWebsiteDAO.makePersistent(cws);
                }

                foreach (CountyAttribute cat in tmpAttribute)
                {
                    cat.County = county;
                    countyAttributeDAO.makePersistent(cat);
                }


                county.PhoneNumbers = tmpPhoneNumber;
                county.Attributes = tmpAttribute;
                county.Websites = tmpWebsite;
            }
            catch (Exception ex)
            {
                LOG.Error("unable to save: operation failed", ex);
            }
        }

        private void frmCounty_Load(object sender, EventArgs e)
        {
            IList<PhoneNumberType> phoneNumberTypes = phoneNumberTypeDAO.findAll();
            foreach (PhoneNumberType phoneNumberType in phoneNumberTypes)
            {
                cbPhoneNumberType.Items.Add(new ListItemWrapper<PhoneNumberType>(phoneNumberType.Name, phoneNumberType));
            }

            if (phoneNumberTypes.Count > 0) cbPhoneNumberType.SelectedIndex = 0;


            IList<AttributeType> attributeTypes = attributeTypeDAO.findAll();
            foreach (AttributeType attributeType in attributeTypes)
            {
                cbKey.Items.Add(new ListItemWrapper<AttributeType>(attributeType.Name, attributeType));
            }

            if (attributeTypes.Count > 0) cbKey.SelectedIndex = 0;
        }

    }
}