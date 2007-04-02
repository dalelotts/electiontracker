namespace edu.uwec.cs.cs355.group4.et.ui
{
    partial class frmPoliticalParty
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
            this.btnPPReset = new System.Windows.Forms.Button();
            this.btnPPNew = new System.Windows.Forms.Button();
            this.btnPPEdit = new System.Windows.Forms.Button();
            this.btnPPSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAbbrev = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPPReset
            // 
            this.btnPPReset.Location = new System.Drawing.Point(151, 13);
            this.btnPPReset.Name = "btnPPReset";
            this.btnPPReset.Size = new System.Drawing.Size(74, 28);
            this.btnPPReset.TabIndex = 7;
            this.btnPPReset.Text = "&Reset";
            this.btnPPReset.UseVisualStyleBackColor = true;
            this.btnPPReset.Click += new System.EventHandler(this.btnPPReset_Click);
            // 
            // btnPPNew
            // 
            this.btnPPNew.Location = new System.Drawing.Point(231, 12);
            this.btnPPNew.Name = "btnPPNew";
            this.btnPPNew.Size = new System.Drawing.Size(74, 28);
            this.btnPPNew.TabIndex = 6;
            this.btnPPNew.Text = "&New";
            this.btnPPNew.UseVisualStyleBackColor = true;
            this.btnPPNew.Click += new System.EventHandler(this.btnPPNew_Click);
            // 
            // btnPPEdit
            // 
            this.btnPPEdit.Location = new System.Drawing.Point(311, 12);
            this.btnPPEdit.Name = "btnPPEdit";
            this.btnPPEdit.Size = new System.Drawing.Size(74, 28);
            this.btnPPEdit.TabIndex = 5;
            this.btnPPEdit.Text = "&Edit";
            this.btnPPEdit.UseVisualStyleBackColor = true;
            this.btnPPEdit.Click += new System.EventHandler(this.btnPPEdit_Click);
            // 
            // btnPPSave
            // 
            this.btnPPSave.Location = new System.Drawing.Point(391, 12);
            this.btnPPSave.Name = "btnPPSave";
            this.btnPPSave.Size = new System.Drawing.Size(74, 28);
            this.btnPPSave.TabIndex = 4;
            this.btnPPSave.Text = "&Save";
            this.btnPPSave.UseVisualStyleBackColor = true;
            this.btnPPSave.Click += new System.EventHandler(this.btnPPSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "&Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "A&bbreviation";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(163, 81);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(62, 17);
            this.chkActive.TabIndex = 11;
            this.chkActive.Text = "&Active?";
            this.chkActive.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(85, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(380, 20);
            this.txtName.TabIndex = 12;
            // 
            // txtAbbrev
            // 
            this.txtAbbrev.Location = new System.Drawing.Point(85, 78);
            this.txtAbbrev.Name = "txtAbbrev";
            this.txtAbbrev.Size = new System.Drawing.Size(62, 20);
            this.txtAbbrev.TabIndex = 13;
            // 
            // frmPoliticalParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 112);
            this.Controls.Add(this.txtAbbrev);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPPReset);
            this.Controls.Add(this.btnPPNew);
            this.Controls.Add(this.btnPPEdit);
            this.Controls.Add(this.btnPPSave);
            this.Name = "frmPoliticalParty";
            this.Text = "frmPoliticalParty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPPReset;
        private System.Windows.Forms.Button btnPPNew;
        private System.Windows.Forms.Button btnPPEdit;
        private System.Windows.Forms.Button btnPPSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAbbrev;
    }
}