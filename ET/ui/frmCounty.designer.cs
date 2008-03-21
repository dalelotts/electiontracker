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
namespace KnightRider.ElectionTracker.ui
{
    partial class frmCounty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbCounty = new System.Windows.Forms.GroupBox();
            this.txtCountyWardCount = new System.Windows.Forms.MaskedTextBox();
            this.txtCountyName = new System.Windows.Forms.TextBox();
            this.lblCountyWardCount = new System.Windows.Forms.Label();
            this.lblCountyName = new System.Windows.Forms.Label();
            this.gbCountyNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.tbDisplay = new System.Windows.Forms.TabControl();
            this.tabCounty = new System.Windows.Forms.TabPage();
            this.tabPhoneNumbers = new System.Windows.Forms.TabPage();
            this.gbPhone = new System.Windows.Forms.GroupBox();
            this.txtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtAreaCode = new System.Windows.Forms.MaskedTextBox();
            this.cbPhoneNumberType = new System.Windows.Forms.ComboBox();
            this.btnRemovePhoneNum = new System.Windows.Forms.Button();
            this.btnAddPhoneNum = new System.Windows.Forms.Button();
            this.lstPhoneNums = new System.Windows.Forms.ListBox();
            this.lblPhoneNumberType = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.tabWebSites = new System.Windows.Forms.TabPage();
            this.gbWebsite = new System.Windows.Forms.GroupBox();
            this.btnRemoveWebsite = new System.Windows.Forms.Button();
            this.btnAddWebsite = new System.Windows.Forms.Button();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lstWebsites = new System.Windows.Forms.ListBox();
            this.tabAttributes = new System.Windows.Forms.TabPage();
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.btnRemoveAttribute = new System.Windows.Forms.Button();
            this.btnAddAttribute = new System.Windows.Forms.Button();
            this.lstAttributes = new System.Windows.Forms.ListBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.lblAttributeValue = new System.Windows.Forms.Label();
            this.lblAttributeKey = new System.Windows.Forms.Label();
            this.lblRequired = new System.Windows.Forms.Label();
            this.gbCounty.SuspendLayout();
            this.gbCountyNotes.SuspendLayout();
            this.tbDisplay.SuspendLayout();
            this.tabCounty.SuspendLayout();
            this.tabPhoneNumbers.SuspendLayout();
            this.gbPhone.SuspendLayout();
            this.tabWebSites.SuspendLayout();
            this.gbWebsite.SuspendLayout();
            this.tabAttributes.SuspendLayout();
            this.gbAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCounty
            // 
            this.gbCounty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCounty.Controls.Add(this.txtCountyWardCount);
            this.gbCounty.Controls.Add(this.txtCountyName);
            this.gbCounty.Controls.Add(this.lblCountyWardCount);
            this.gbCounty.Controls.Add(this.lblCountyName);
            this.gbCounty.Location = new System.Drawing.Point(6, 6);
            this.gbCounty.Name = "gbCounty";
            this.gbCounty.Size = new System.Drawing.Size(395, 74);
            this.gbCounty.TabIndex = 0;
            this.gbCounty.TabStop = false;
            this.gbCounty.Text = "County";
            // 
            // txtCountyWardCount
            // 
            this.txtCountyWardCount.Location = new System.Drawing.Point(79, 43);
            this.txtCountyWardCount.Mask = "0000";
            this.txtCountyWardCount.Name = "txtCountyWardCount";
            this.txtCountyWardCount.Size = new System.Drawing.Size(66, 20);
            this.txtCountyWardCount.TabIndex = 3;
            this.txtCountyWardCount.Tag = "lock=true";
            this.txtCountyWardCount.Text = "0";
            // 
            // txtCountyName
            // 
            this.txtCountyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCountyName.Location = new System.Drawing.Point(79, 17);
            this.txtCountyName.Name = "txtCountyName";
            this.txtCountyName.Size = new System.Drawing.Size(307, 20);
            this.txtCountyName.TabIndex = 1;
            this.txtCountyName.Tag = "lock=true";
            // 
            // lblCountyWardCount
            // 
            this.lblCountyWardCount.AutoSize = true;
            this.lblCountyWardCount.Location = new System.Drawing.Point(7, 46);
            this.lblCountyWardCount.Name = "lblCountyWardCount";
            this.lblCountyWardCount.Size = new System.Drawing.Size(71, 13);
            this.lblCountyWardCount.TabIndex = 2;
            this.lblCountyWardCount.Text = "Ward Count *";
            // 
            // lblCountyName
            // 
            this.lblCountyName.AutoSize = true;
            this.lblCountyName.Location = new System.Drawing.Point(7, 20);
            this.lblCountyName.Name = "lblCountyName";
            this.lblCountyName.Size = new System.Drawing.Size(42, 13);
            this.lblCountyName.TabIndex = 0;
            this.lblCountyName.Text = "Name *";
            // 
            // gbCountyNotes
            // 
            this.gbCountyNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCountyNotes.Controls.Add(this.txtNotes);
            this.gbCountyNotes.Location = new System.Drawing.Point(6, 86);
            this.gbCountyNotes.Name = "gbCountyNotes";
            this.gbCountyNotes.Size = new System.Drawing.Size(395, 104);
            this.gbCountyNotes.TabIndex = 1;
            this.gbCountyNotes.TabStop = false;
            this.gbCountyNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(6, 19);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(383, 79);
            this.txtNotes.TabIndex = 0;
            this.txtNotes.Tag = "lock=true";
            // 
            // tbDisplay
            // 
            this.tbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisplay.Controls.Add(this.tabCounty);
            this.tbDisplay.Controls.Add(this.tabPhoneNumbers);
            this.tbDisplay.Controls.Add(this.tabWebSites);
            this.tbDisplay.Controls.Add(this.tabAttributes);
            this.tbDisplay.Location = new System.Drawing.Point(15, 53);
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.SelectedIndex = 0;
            this.tbDisplay.Size = new System.Drawing.Size(415, 221);
            this.tbDisplay.TabIndex = 0;
            // 
            // tabCounty
            // 
            this.tabCounty.Controls.Add(this.gbCounty);
            this.tabCounty.Controls.Add(this.gbCountyNotes);
            this.tabCounty.Location = new System.Drawing.Point(4, 22);
            this.tabCounty.Name = "tabCounty";
            this.tabCounty.Padding = new System.Windows.Forms.Padding(3);
            this.tabCounty.Size = new System.Drawing.Size(407, 195);
            this.tabCounty.TabIndex = 0;
            this.tabCounty.Text = "County";
            this.tabCounty.UseVisualStyleBackColor = true;
            // 
            // tabPhoneNumbers
            // 
            this.tabPhoneNumbers.Controls.Add(this.gbPhone);
            this.tabPhoneNumbers.Location = new System.Drawing.Point(4, 22);
            this.tabPhoneNumbers.Name = "tabPhoneNumbers";
            this.tabPhoneNumbers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhoneNumbers.Size = new System.Drawing.Size(407, 195);
            this.tabPhoneNumbers.TabIndex = 1;
            this.tabPhoneNumbers.Text = "Phone Numbers";
            this.tabPhoneNumbers.UseVisualStyleBackColor = true;
            // 
            // gbPhone
            // 
            this.gbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPhone.Controls.Add(this.txtPhoneNumber);
            this.gbPhone.Controls.Add(this.txtAreaCode);
            this.gbPhone.Controls.Add(this.cbPhoneNumberType);
            this.gbPhone.Controls.Add(this.btnRemovePhoneNum);
            this.gbPhone.Controls.Add(this.btnAddPhoneNum);
            this.gbPhone.Controls.Add(this.lstPhoneNums);
            this.gbPhone.Controls.Add(this.lblPhoneNumberType);
            this.gbPhone.Controls.Add(this.lblPhoneNumber);
            this.gbPhone.Controls.Add(this.lblAreaCode);
            this.gbPhone.Location = new System.Drawing.Point(6, 6);
            this.gbPhone.Name = "gbPhone";
            this.gbPhone.Size = new System.Drawing.Size(395, 180);
            this.gbPhone.TabIndex = 0;
            this.gbPhone.TabStop = false;
            this.gbPhone.Text = "Phone Numbers";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(232, 32);
            this.txtPhoneNumber.Mask = "000-0000";
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(76, 20);
            this.txtPhoneNumber.TabIndex = 5;
            this.txtPhoneNumber.Tag = "Requred=AddPhoneNumber";
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAreaCode.Location = new System.Drawing.Point(168, 32);
            this.txtAreaCode.Mask = "000";
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(56, 20);
            this.txtAreaCode.TabIndex = 3;
            this.txtAreaCode.Tag = "Requred=AddPhoneNumber";
            // 
            // cbPhoneNumberType
            // 
            this.cbPhoneNumberType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPhoneNumberType.FormattingEnabled = true;
            this.cbPhoneNumberType.Location = new System.Drawing.Point(6, 31);
            this.cbPhoneNumberType.Name = "cbPhoneNumberType";
            this.cbPhoneNumberType.Size = new System.Drawing.Size(156, 21);
            this.cbPhoneNumberType.TabIndex = 1;
            this.cbPhoneNumberType.Tag = "Requred=AddPhoneNumber";
            this.cbPhoneNumberType.Leave += new System.EventHandler(this.cbPhoneNumberType_Leave);
            // 
            // btnRemovePhoneNum
            // 
            this.btnRemovePhoneNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePhoneNum.Location = new System.Drawing.Point(314, 61);
            this.btnRemovePhoneNum.Name = "btnRemovePhoneNum";
            this.btnRemovePhoneNum.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePhoneNum.TabIndex = 8;
            this.btnRemovePhoneNum.Tag = "lock=true";
            this.btnRemovePhoneNum.Text = "Remove";
            this.btnRemovePhoneNum.UseVisualStyleBackColor = true;
            this.btnRemovePhoneNum.Click += new System.EventHandler(this.btnRemovePhoneNum_Click);
            // 
            // btnAddPhoneNum
            // 
            this.btnAddPhoneNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPhoneNum.Location = new System.Drawing.Point(314, 30);
            this.btnAddPhoneNum.Name = "btnAddPhoneNum";
            this.btnAddPhoneNum.Size = new System.Drawing.Size(75, 23);
            this.btnAddPhoneNum.TabIndex = 6;
            this.btnAddPhoneNum.Tag = "lock=true";
            this.btnAddPhoneNum.Text = "Add";
            this.btnAddPhoneNum.UseVisualStyleBackColor = true;
            this.btnAddPhoneNum.Click += new System.EventHandler(this.btnAddPhoneNum_Click);
            // 
            // lstPhoneNums
            // 
            this.lstPhoneNums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPhoneNums.FormattingEnabled = true;
            this.lstPhoneNums.Location = new System.Drawing.Point(6, 61);
            this.lstPhoneNums.Name = "lstPhoneNums";
            this.lstPhoneNums.Size = new System.Drawing.Size(302, 108);
            this.lstPhoneNums.TabIndex = 7;
            // 
            // lblPhoneNumberType
            // 
            this.lblPhoneNumberType.AutoSize = true;
            this.lblPhoneNumberType.Location = new System.Drawing.Point(3, 16);
            this.lblPhoneNumberType.Name = "lblPhoneNumberType";
            this.lblPhoneNumberType.Size = new System.Drawing.Size(31, 13);
            this.lblPhoneNumberType.TabIndex = 0;
            this.lblPhoneNumberType.Text = "Type";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(230, 16);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(78, 13);
            this.lblPhoneNumber.TabIndex = 4;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.Location = new System.Drawing.Point(167, 16);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(57, 13);
            this.lblAreaCode.TabIndex = 2;
            this.lblAreaCode.Text = "Area Code";
            // 
            // tabWebSites
            // 
            this.tabWebSites.Controls.Add(this.gbWebsite);
            this.tabWebSites.Location = new System.Drawing.Point(4, 22);
            this.tabWebSites.Name = "tabWebSites";
            this.tabWebSites.Padding = new System.Windows.Forms.Padding(3);
            this.tabWebSites.Size = new System.Drawing.Size(407, 195);
            this.tabWebSites.TabIndex = 2;
            this.tabWebSites.Text = "Web Sites";
            this.tabWebSites.UseVisualStyleBackColor = true;
            // 
            // gbWebsite
            // 
            this.gbWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWebsite.Controls.Add(this.btnRemoveWebsite);
            this.gbWebsite.Controls.Add(this.btnAddWebsite);
            this.gbWebsite.Controls.Add(this.txtWebsite);
            this.gbWebsite.Controls.Add(this.lstWebsites);
            this.gbWebsite.Location = new System.Drawing.Point(6, 6);
            this.gbWebsite.Name = "gbWebsite";
            this.gbWebsite.Size = new System.Drawing.Size(395, 180);
            this.gbWebsite.TabIndex = 5;
            this.gbWebsite.TabStop = false;
            this.gbWebsite.Text = "Websites";
            // 
            // btnRemoveWebsite
            // 
            this.btnRemoveWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveWebsite.Location = new System.Drawing.Point(312, 45);
            this.btnRemoveWebsite.Name = "btnRemoveWebsite";
            this.btnRemoveWebsite.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveWebsite.TabIndex = 3;
            this.btnRemoveWebsite.Tag = "lock=true";
            this.btnRemoveWebsite.Text = "Remove";
            this.btnRemoveWebsite.UseVisualStyleBackColor = true;
            this.btnRemoveWebsite.Click += new System.EventHandler(this.btnRemoveWebsite_Click);
            // 
            // btnAddWebsite
            // 
            this.btnAddWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddWebsite.Location = new System.Drawing.Point(312, 17);
            this.btnAddWebsite.Name = "btnAddWebsite";
            this.btnAddWebsite.Size = new System.Drawing.Size(75, 23);
            this.btnAddWebsite.TabIndex = 1;
            this.btnAddWebsite.Tag = "lock=true";
            this.btnAddWebsite.Text = "Add";
            this.btnAddWebsite.UseVisualStyleBackColor = true;
            this.btnAddWebsite.Click += new System.EventHandler(this.btnAddWebsite_Click);
            // 
            // txtWebsite
            // 
            this.txtWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebsite.Location = new System.Drawing.Point(6, 19);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(298, 20);
            this.txtWebsite.TabIndex = 0;
            this.txtWebsite.Tag = "lock=true";
            this.txtWebsite.Text = "http://";
            // 
            // lstWebsites
            // 
            this.lstWebsites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstWebsites.FormattingEnabled = true;
            this.lstWebsites.Location = new System.Drawing.Point(6, 45);
            this.lstWebsites.Name = "lstWebsites";
            this.lstWebsites.Size = new System.Drawing.Size(298, 121);
            this.lstWebsites.TabIndex = 2;
            // 
            // tabAttributes
            // 
            this.tabAttributes.Controls.Add(this.gbAttributes);
            this.tabAttributes.Location = new System.Drawing.Point(4, 22);
            this.tabAttributes.Name = "tabAttributes";
            this.tabAttributes.Size = new System.Drawing.Size(407, 195);
            this.tabAttributes.TabIndex = 3;
            this.tabAttributes.Text = "Attributes";
            this.tabAttributes.UseVisualStyleBackColor = true;
            // 
            // gbAttributes
            // 
            this.gbAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAttributes.Controls.Add(this.btnRemoveAttribute);
            this.gbAttributes.Controls.Add(this.btnAddAttribute);
            this.gbAttributes.Controls.Add(this.lstAttributes);
            this.gbAttributes.Controls.Add(this.txtValue);
            this.gbAttributes.Controls.Add(this.cbKey);
            this.gbAttributes.Controls.Add(this.lblAttributeValue);
            this.gbAttributes.Controls.Add(this.lblAttributeKey);
            this.gbAttributes.Location = new System.Drawing.Point(6, 6);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Size = new System.Drawing.Size(398, 183);
            this.gbAttributes.TabIndex = 0;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Attributes";
            // 
            // btnRemoveAttribute
            // 
            this.btnRemoveAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAttribute.Location = new System.Drawing.Point(315, 58);
            this.btnRemoveAttribute.Name = "btnRemoveAttribute";
            this.btnRemoveAttribute.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAttribute.TabIndex = 6;
            this.btnRemoveAttribute.Tag = "lock=true";
            this.btnRemoveAttribute.Text = "Remove";
            this.btnRemoveAttribute.UseVisualStyleBackColor = true;
            this.btnRemoveAttribute.Click += new System.EventHandler(this.btnRemoveAttribute_Click);
            // 
            // btnAddAttribute
            // 
            this.btnAddAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAttribute.Location = new System.Drawing.Point(315, 28);
            this.btnAddAttribute.Name = "btnAddAttribute";
            this.btnAddAttribute.Size = new System.Drawing.Size(75, 23);
            this.btnAddAttribute.TabIndex = 4;
            this.btnAddAttribute.Tag = "lock=true";
            this.btnAddAttribute.Text = "Add";
            this.btnAddAttribute.UseVisualStyleBackColor = true;
            this.btnAddAttribute.Click += new System.EventHandler(this.btnAddAttribute_Click);
            // 
            // lstAttributes
            // 
            this.lstAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAttributes.FormattingEnabled = true;
            this.lstAttributes.Location = new System.Drawing.Point(6, 58);
            this.lstAttributes.Name = "lstAttributes";
            this.lstAttributes.Size = new System.Drawing.Size(301, 108);
            this.lstAttributes.TabIndex = 5;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(158, 31);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(149, 20);
            this.txtValue.TabIndex = 3;
            this.txtValue.Tag = "lock=true";
            // 
            // cbKey
            // 
            this.cbKey.FormattingEnabled = true;
            this.cbKey.Location = new System.Drawing.Point(6, 30);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(146, 21);
            this.cbKey.TabIndex = 1;
            this.cbKey.Tag = "lock=true";
            this.cbKey.Leave += new System.EventHandler(this.cbKey_Leave);
            // 
            // lblAttributeValue
            // 
            this.lblAttributeValue.AutoSize = true;
            this.lblAttributeValue.Location = new System.Drawing.Point(155, 14);
            this.lblAttributeValue.Name = "lblAttributeValue";
            this.lblAttributeValue.Size = new System.Drawing.Size(34, 13);
            this.lblAttributeValue.TabIndex = 2;
            this.lblAttributeValue.Text = "Value";
            // 
            // lblAttributeKey
            // 
            this.lblAttributeKey.AutoSize = true;
            this.lblAttributeKey.Location = new System.Drawing.Point(6, 14);
            this.lblAttributeKey.Name = "lblAttributeKey";
            this.lblAttributeKey.Size = new System.Drawing.Size(25, 13);
            this.lblAttributeKey.TabIndex = 0;
            this.lblAttributeKey.Text = "Key";
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.ForeColor = System.Drawing.Color.Blue;
            this.lblRequired.Location = new System.Drawing.Point(12, 34);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(177, 16);
            this.lblRequired.TabIndex = 0;
            this.lblRequired.Text = "A * indicates a required field.";
            // 
            // frmCounty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 286);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.lblRequired);
            this.MinimumSize = new System.Drawing.Size(450, 320);
            this.Name = "frmCounty";
            this.Text = "County";
            this.Controls.SetChildIndex(this.lblRequired, 0);
            this.Controls.SetChildIndex(this.tbDisplay, 0);
            this.gbCounty.ResumeLayout(false);
            this.gbCounty.PerformLayout();
            this.gbCountyNotes.ResumeLayout(false);
            this.gbCountyNotes.PerformLayout();
            this.tbDisplay.ResumeLayout(false);
            this.tabCounty.ResumeLayout(false);
            this.tabPhoneNumbers.ResumeLayout(false);
            this.gbPhone.ResumeLayout(false);
            this.gbPhone.PerformLayout();
            this.tabWebSites.ResumeLayout(false);
            this.gbWebsite.ResumeLayout(false);
            this.gbWebsite.PerformLayout();
            this.tabAttributes.ResumeLayout(false);
            this.gbAttributes.ResumeLayout(false);
            this.gbAttributes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCounty;
        private System.Windows.Forms.TextBox txtCountyName;
        private System.Windows.Forms.Label lblCountyWardCount;
        private System.Windows.Forms.Label lblCountyName;
        private System.Windows.Forms.GroupBox gbCountyNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TabControl tbDisplay;
        private System.Windows.Forms.TabPage tabCounty;
        private System.Windows.Forms.TabPage tabPhoneNumbers;
        private System.Windows.Forms.GroupBox gbPhone;
        private System.Windows.Forms.Button btnRemovePhoneNum;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblAreaCode;
        private System.Windows.Forms.Button btnAddPhoneNum;
        private System.Windows.Forms.ListBox lstPhoneNums;
        private System.Windows.Forms.ComboBox cbPhoneNumberType;
        private System.Windows.Forms.Label lblPhoneNumberType;
        private System.Windows.Forms.MaskedTextBox txtCountyWardCount;
        private System.Windows.Forms.MaskedTextBox txtPhoneNumber;
        private System.Windows.Forms.MaskedTextBox txtAreaCode;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.TabPage tabWebSites;
        private System.Windows.Forms.GroupBox gbWebsite;
        private System.Windows.Forms.Button btnRemoveWebsite;
        private System.Windows.Forms.Button btnAddWebsite;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.ListBox lstWebsites;
        private System.Windows.Forms.TabPage tabAttributes;
        private System.Windows.Forms.GroupBox gbAttributes;
        private System.Windows.Forms.Button btnRemoveAttribute;
        private System.Windows.Forms.Button btnAddAttribute;
        private System.Windows.Forms.ListBox lstAttributes;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.Label lblAttributeValue;
        private System.Windows.Forms.Label lblAttributeKey;
    }
}