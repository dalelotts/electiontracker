namespace edu.uwec.cs.cs355.group4.et.ui
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
            this.tabContact = new System.Windows.Forms.TabPage();
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.btnRemoveAttribute = new System.Windows.Forms.Button();
            this.btnAddAttribute = new System.Windows.Forms.Button();
            this.lstAttributes = new System.Windows.Forms.ListBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.gbPhone = new System.Windows.Forms.GroupBox();
            this.txtPhoneNum = new System.Windows.Forms.MaskedTextBox();
            this.txtAreaCode = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPhoneNumberType = new System.Windows.Forms.ComboBox();
            this.btnRemovePhoneNum = new System.Windows.Forms.Button();
            this.lblPhoneNum = new System.Windows.Forms.Label();
            this.lblAreaCode = new System.Windows.Forms.Label();
            this.btnAddPhoneNum = new System.Windows.Forms.Button();
            this.lstPhoneNums = new System.Windows.Forms.ListBox();
            this.gbWebsite = new System.Windows.Forms.GroupBox();
            this.btnRemoveWebsite = new System.Windows.Forms.Button();
            this.btnAddWebsite = new System.Windows.Forms.Button();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lstWebsites = new System.Windows.Forms.ListBox();
            this.gbCounty.SuspendLayout();
            this.gbCountyNotes.SuspendLayout();
            this.tbDisplay.SuspendLayout();
            this.tabCounty.SuspendLayout();
            this.tabContact.SuspendLayout();
            this.gbAttributes.SuspendLayout();
            this.gbPhone.SuspendLayout();
            this.gbWebsite.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCounty
            // 
            this.gbCounty.Controls.Add(this.txtCountyWardCount);
            this.gbCounty.Controls.Add(this.txtCountyName);
            this.gbCounty.Controls.Add(this.lblCountyWardCount);
            this.gbCounty.Controls.Add(this.lblCountyName);
            this.gbCounty.Location = new System.Drawing.Point(6, 6);
            this.gbCounty.Name = "gbCounty";
            this.gbCounty.Size = new System.Drawing.Size(409, 74);
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
            this.txtCountyWardCount.TabIndex = 6;
            this.txtCountyWardCount.Tag = "lock=true";
            // 
            // txtCountyName
            // 
            this.txtCountyName.Location = new System.Drawing.Point(79, 17);
            this.txtCountyName.Name = "txtCountyName";
            this.txtCountyName.Size = new System.Drawing.Size(324, 20);
            this.txtCountyName.TabIndex = 4;
            this.txtCountyName.Tag = "lock=true";
            // 
            // lblCountyWardCount
            // 
            this.lblCountyWardCount.AutoSize = true;
            this.lblCountyWardCount.Location = new System.Drawing.Point(7, 46);
            this.lblCountyWardCount.Name = "lblCountyWardCount";
            this.lblCountyWardCount.Size = new System.Drawing.Size(67, 13);
            this.lblCountyWardCount.TabIndex = 1;
            this.lblCountyWardCount.Text = "Ward Count:";
            // 
            // lblCountyName
            // 
            this.lblCountyName.AutoSize = true;
            this.lblCountyName.Location = new System.Drawing.Point(7, 20);
            this.lblCountyName.Name = "lblCountyName";
            this.lblCountyName.Size = new System.Drawing.Size(38, 13);
            this.lblCountyName.TabIndex = 0;
            this.lblCountyName.Text = "Name:";
            // 
            // gbCountyNotes
            // 
            this.gbCountyNotes.Controls.Add(this.txtNotes);
            this.gbCountyNotes.Location = new System.Drawing.Point(6, 86);
            this.gbCountyNotes.Name = "gbCountyNotes";
            this.gbCountyNotes.Size = new System.Drawing.Size(409, 435);
            this.gbCountyNotes.TabIndex = 1;
            this.gbCountyNotes.TabStop = false;
            this.gbCountyNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(6, 19);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(397, 410);
            this.txtNotes.TabIndex = 0;
            this.txtNotes.Tag = "lock=true";
            // 
            // tbDisplay
            // 
            this.tbDisplay.Controls.Add(this.tabCounty);
            this.tbDisplay.Controls.Add(this.tabContact);
            this.tbDisplay.Location = new System.Drawing.Point(12, 28);
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.SelectedIndex = 0;
            this.tbDisplay.Size = new System.Drawing.Size(429, 550);
            this.tbDisplay.TabIndex = 2;
            // 
            // tabCounty
            // 
            this.tabCounty.Controls.Add(this.gbCounty);
            this.tabCounty.Controls.Add(this.gbCountyNotes);
            this.tabCounty.Location = new System.Drawing.Point(4, 22);
            this.tabCounty.Name = "tabCounty";
            this.tabCounty.Padding = new System.Windows.Forms.Padding(3);
            this.tabCounty.Size = new System.Drawing.Size(421, 524);
            this.tabCounty.TabIndex = 0;
            this.tabCounty.Text = "County";
            this.tabCounty.UseVisualStyleBackColor = true;
            // 
            // tabContact
            // 
            this.tabContact.Controls.Add(this.gbAttributes);
            this.tabContact.Controls.Add(this.gbPhone);
            this.tabContact.Controls.Add(this.gbWebsite);
            this.tabContact.Location = new System.Drawing.Point(4, 22);
            this.tabContact.Name = "tabContact";
            this.tabContact.Padding = new System.Windows.Forms.Padding(3);
            this.tabContact.Size = new System.Drawing.Size(421, 524);
            this.tabContact.TabIndex = 1;
            this.tabContact.Text = "Contact Information";
            this.tabContact.UseVisualStyleBackColor = true;
            // 
            // gbAttributes
            // 
            this.gbAttributes.Controls.Add(this.btnRemoveAttribute);
            this.gbAttributes.Controls.Add(this.btnAddAttribute);
            this.gbAttributes.Controls.Add(this.lstAttributes);
            this.gbAttributes.Controls.Add(this.txtValue);
            this.gbAttributes.Controls.Add(this.lblValue);
            this.gbAttributes.Controls.Add(this.lblKey);
            this.gbAttributes.Controls.Add(this.cbKey);
            this.gbAttributes.Location = new System.Drawing.Point(17, 344);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Size = new System.Drawing.Size(387, 161);
            this.gbAttributes.TabIndex = 5;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Attributes";
            // 
            // btnRemoveAttribute
            // 
            this.btnRemoveAttribute.Location = new System.Drawing.Point(306, 49);
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
            this.btnAddAttribute.Location = new System.Drawing.Point(306, 19);
            this.btnAddAttribute.Name = "btnAddAttribute";
            this.btnAddAttribute.Size = new System.Drawing.Size(75, 23);
            this.btnAddAttribute.TabIndex = 5;
            this.btnAddAttribute.Tag = "lock=true";
            this.btnAddAttribute.Text = "Add";
            this.btnAddAttribute.UseVisualStyleBackColor = true;
            this.btnAddAttribute.Click += new System.EventHandler(this.btnAddAttribute_Click);
            // 
            // lstAttributes
            // 
            this.lstAttributes.FormattingEnabled = true;
            this.lstAttributes.Location = new System.Drawing.Point(6, 58);
            this.lstAttributes.Name = "lstAttributes";
            this.lstAttributes.Size = new System.Drawing.Size(290, 95);
            this.lstAttributes.TabIndex = 4;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(158, 31);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(138, 20);
            this.txtValue.TabIndex = 3;
            this.txtValue.Tag = "lock=true";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(155, 14);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 2;
            this.lblValue.Text = "Value";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(6, 14);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(25, 13);
            this.lblKey.TabIndex = 1;
            this.lblKey.Text = "Key";
            // 
            // cbKey
            // 
            this.cbKey.FormattingEnabled = true;
            this.cbKey.Location = new System.Drawing.Point(6, 30);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(146, 21);
            this.cbKey.TabIndex = 0;
            this.cbKey.Tag = "lock=true";
            // 
            // gbPhone
            // 
            this.gbPhone.Controls.Add(this.txtPhoneNum);
            this.gbPhone.Controls.Add(this.txtAreaCode);
            this.gbPhone.Controls.Add(this.label1);
            this.gbPhone.Controls.Add(this.cbPhoneNumberType);
            this.gbPhone.Controls.Add(this.btnRemovePhoneNum);
            this.gbPhone.Controls.Add(this.lblPhoneNum);
            this.gbPhone.Controls.Add(this.lblAreaCode);
            this.gbPhone.Controls.Add(this.btnAddPhoneNum);
            this.gbPhone.Controls.Add(this.lstPhoneNums);
            this.gbPhone.Location = new System.Drawing.Point(17, 23);
            this.gbPhone.Name = "gbPhone";
            this.gbPhone.Size = new System.Drawing.Size(387, 162);
            this.gbPhone.TabIndex = 3;
            this.gbPhone.TabStop = false;
            this.gbPhone.Text = "Phone Numbers";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(219, 33);
            this.txtPhoneNum.Mask = "000-0000";
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(76, 20);
            this.txtPhoneNum.TabIndex = 9;
            this.txtPhoneNum.Tag = "lock=true";
            // 
            // txtAreaCode
            // 
            this.txtAreaCode.Location = new System.Drawing.Point(155, 33);
            this.txtAreaCode.Mask = "000";
            this.txtAreaCode.Name = "txtAreaCode";
            this.txtAreaCode.Size = new System.Drawing.Size(56, 20);
            this.txtAreaCode.TabIndex = 8;
            this.txtAreaCode.Tag = "lock=true";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Type";
            // 
            // cbPhoneNumberType
            // 
            this.cbPhoneNumberType.FormattingEnabled = true;
            this.cbPhoneNumberType.Location = new System.Drawing.Point(6, 31);
            this.cbPhoneNumberType.Name = "cbPhoneNumberType";
            this.cbPhoneNumberType.Size = new System.Drawing.Size(146, 21);
            this.cbPhoneNumberType.TabIndex = 1;
            this.cbPhoneNumberType.Tag = "lock=true";
            // 
            // btnRemovePhoneNum
            // 
            this.btnRemovePhoneNum.Location = new System.Drawing.Point(302, 48);
            this.btnRemovePhoneNum.Name = "btnRemovePhoneNum";
            this.btnRemovePhoneNum.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePhoneNum.TabIndex = 6;
            this.btnRemovePhoneNum.Tag = "lock=true";
            this.btnRemovePhoneNum.Text = "Remove";
            this.btnRemovePhoneNum.UseVisualStyleBackColor = true;
            this.btnRemovePhoneNum.Click += new System.EventHandler(this.btnRemovePhoneNum_Click);
            // 
            // lblPhoneNum
            // 
            this.lblPhoneNum.AutoSize = true;
            this.lblPhoneNum.Location = new System.Drawing.Point(218, 16);
            this.lblPhoneNum.Name = "lblPhoneNum";
            this.lblPhoneNum.Size = new System.Drawing.Size(78, 13);
            this.lblPhoneNum.TabIndex = 5;
            this.lblPhoneNum.Text = "Phone Number";
            // 
            // lblAreaCode
            // 
            this.lblAreaCode.AutoSize = true;
            this.lblAreaCode.Location = new System.Drawing.Point(155, 16);
            this.lblAreaCode.Name = "lblAreaCode";
            this.lblAreaCode.Size = new System.Drawing.Size(57, 13);
            this.lblAreaCode.TabIndex = 4;
            this.lblAreaCode.Text = "Area Code";
            // 
            // btnAddPhoneNum
            // 
            this.btnAddPhoneNum.Location = new System.Drawing.Point(302, 19);
            this.btnAddPhoneNum.Name = "btnAddPhoneNum";
            this.btnAddPhoneNum.Size = new System.Drawing.Size(75, 23);
            this.btnAddPhoneNum.TabIndex = 1;
            this.btnAddPhoneNum.Tag = "lock=true";
            this.btnAddPhoneNum.Text = "Add";
            this.btnAddPhoneNum.UseVisualStyleBackColor = true;
            this.btnAddPhoneNum.Click += new System.EventHandler(this.btnAddPhoneNum_Click);
            // 
            // lstPhoneNums
            // 
            this.lstPhoneNums.FormattingEnabled = true;
            this.lstPhoneNums.Location = new System.Drawing.Point(6, 61);
            this.lstPhoneNums.Name = "lstPhoneNums";
            this.lstPhoneNums.Size = new System.Drawing.Size(290, 95);
            this.lstPhoneNums.TabIndex = 4;
            // 
            // gbWebsite
            // 
            this.gbWebsite.Controls.Add(this.btnRemoveWebsite);
            this.gbWebsite.Controls.Add(this.btnAddWebsite);
            this.gbWebsite.Controls.Add(this.txtWebsite);
            this.gbWebsite.Controls.Add(this.lstWebsites);
            this.gbWebsite.Location = new System.Drawing.Point(17, 191);
            this.gbWebsite.Name = "gbWebsite";
            this.gbWebsite.Size = new System.Drawing.Size(387, 147);
            this.gbWebsite.TabIndex = 4;
            this.gbWebsite.TabStop = false;
            this.gbWebsite.Text = "Websites";
            // 
            // btnRemoveWebsite
            // 
            this.btnRemoveWebsite.Location = new System.Drawing.Point(306, 45);
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
            this.btnAddWebsite.Location = new System.Drawing.Point(306, 16);
            this.btnAddWebsite.Name = "btnAddWebsite";
            this.btnAddWebsite.Size = new System.Drawing.Size(75, 23);
            this.btnAddWebsite.TabIndex = 2;
            this.btnAddWebsite.Tag = "lock=true";
            this.btnAddWebsite.Text = "Add";
            this.btnAddWebsite.UseVisualStyleBackColor = true;
            this.btnAddWebsite.Click += new System.EventHandler(this.btnAddWebsite_Click);
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(6, 19);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(290, 20);
            this.txtWebsite.TabIndex = 1;
            this.txtWebsite.Tag = "lock=true";
            this.txtWebsite.Text = "http://";
            // 
            // lstWebsites
            // 
            this.lstWebsites.FormattingEnabled = true;
            this.lstWebsites.Location = new System.Drawing.Point(6, 45);
            this.lstWebsites.Name = "lstWebsites";
            this.lstWebsites.Size = new System.Drawing.Size(290, 95);
            this.lstWebsites.TabIndex = 0;
            // 
            // frmCounty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 590);
            this.Controls.Add(this.tbDisplay);
            this.Name = "frmCounty";
            this.Text = "County";
            this.Controls.SetChildIndex(this.tbDisplay, 0);
            this.gbCounty.ResumeLayout(false);
            this.gbCounty.PerformLayout();
            this.gbCountyNotes.ResumeLayout(false);
            this.gbCountyNotes.PerformLayout();
            this.tbDisplay.ResumeLayout(false);
            this.tabCounty.ResumeLayout(false);
            this.tabContact.ResumeLayout(false);
            this.gbAttributes.ResumeLayout(false);
            this.gbAttributes.PerformLayout();
            this.gbPhone.ResumeLayout(false);
            this.gbPhone.PerformLayout();
            this.gbWebsite.ResumeLayout(false);
            this.gbWebsite.PerformLayout();
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
        private System.Windows.Forms.TabPage tabContact;
        private System.Windows.Forms.GroupBox gbAttributes;
        private System.Windows.Forms.Button btnRemoveAttribute;
        private System.Windows.Forms.Button btnAddAttribute;
        private System.Windows.Forms.ListBox lstAttributes;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.GroupBox gbPhone;
        private System.Windows.Forms.Button btnRemovePhoneNum;
        private System.Windows.Forms.Label lblPhoneNum;
        private System.Windows.Forms.Label lblAreaCode;
        private System.Windows.Forms.Button btnAddPhoneNum;
        private System.Windows.Forms.ListBox lstPhoneNums;
        private System.Windows.Forms.GroupBox gbWebsite;
        private System.Windows.Forms.Button btnRemoveWebsite;
        private System.Windows.Forms.Button btnAddWebsite;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.ListBox lstWebsites;
        private System.Windows.Forms.ComboBox cbPhoneNumberType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtCountyWardCount;
        private System.Windows.Forms.MaskedTextBox txtPhoneNum;
        private System.Windows.Forms.MaskedTextBox txtAreaCode;
    }
}