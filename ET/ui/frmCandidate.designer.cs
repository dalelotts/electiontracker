namespace edu.uwec.cs.cs355.group4.et.ui
{
    internal partial class frmCandidate
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCandEdit = new System.Windows.Forms.Button();
            this.btnCandNew = new System.Windows.Forms.Button();
            this.btnCandReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.cboPoliticalParty = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(471, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCandEdit
            // 
            this.btnCandEdit.Location = new System.Drawing.Point(391, 11);
            this.btnCandEdit.Name = "btnCandEdit";
            this.btnCandEdit.Size = new System.Drawing.Size(74, 28);
            this.btnCandEdit.TabIndex = 1;
            this.btnCandEdit.Text = "&Edit";
            this.btnCandEdit.UseVisualStyleBackColor = true;
            this.btnCandEdit.Click += new System.EventHandler(this.btnCandEdit_Click);
            // 
            // btnCandNew
            // 
            this.btnCandNew.Location = new System.Drawing.Point(311, 11);
            this.btnCandNew.Name = "btnCandNew";
            this.btnCandNew.Size = new System.Drawing.Size(74, 28);
            this.btnCandNew.TabIndex = 2;
            this.btnCandNew.Text = "&New";
            this.btnCandNew.UseVisualStyleBackColor = true;
            this.btnCandNew.Click += new System.EventHandler(this.btnCandNew_Click);
            // 
            // btnCandReset
            // 
            this.btnCandReset.Location = new System.Drawing.Point(231, 12);
            this.btnCandReset.Name = "btnCandReset";
            this.btnCandReset.Size = new System.Drawing.Size(74, 28);
            this.btnCandReset.TabIndex = 3;
            this.btnCandReset.Text = "&Reset";
            this.btnCandReset.UseVisualStyleBackColor = true;
            this.btnCandReset.Click += new System.EventHandler(this.btnCandReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "&First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(90, 46);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(457, 20);
            this.txtFirstName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "&Middle Name";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(90, 72);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(457, 20);
            this.txtMiddleName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "&Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(90, 98);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(457, 20);
            this.txtLastName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "&Political Party";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "N&otes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(17, 174);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(530, 230);
            this.txtNotes.TabIndex = 15;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(17, 410);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(62, 17);
            this.chkActive.TabIndex = 17;
            this.chkActive.Text = "Active?";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // cboPoliticalParty
            // 
            this.cboPoliticalParty.FormattingEnabled = true;
            this.cboPoliticalParty.Location = new System.Drawing.Point(90, 124);
            this.cboPoliticalParty.Name = "cboPoliticalParty";
            this.cboPoliticalParty.Size = new System.Drawing.Size(457, 21);
            this.cboPoliticalParty.TabIndex = 19;
            // 
            // frmCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 434);
            this.Controls.Add(this.cboPoliticalParty);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnCandReset);
            this.Controls.Add(this.btnCandNew);
            this.Controls.Add(this.btnCandEdit);
            this.Controls.Add(this.btnSave);
            this.Name = "frmCandidate";
            this.Text = "Candidate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCandEdit;
        private System.Windows.Forms.Button btnCandNew;
        private System.Windows.Forms.Button btnCandReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ComboBox cboPoliticalParty;
    }
}