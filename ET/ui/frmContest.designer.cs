namespace edu.uwec.cs.cs355.group4.et.ui
{
    partial class frmContest
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.cbContestType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Notes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Name:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(53, 91);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(309, 116);
            this.txtNotes.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(309, 20);
            this.txtName.TabIndex = 7;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(53, 213);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(62, 17);
            this.chkActive.TabIndex = 10;
            this.chkActive.Text = "Active?";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // cbContestType
            // 
            this.cbContestType.FormattingEnabled = true;
            this.cbContestType.Location = new System.Drawing.Point(53, 64);
            this.cbContestType.Name = "cbContestType";
            this.cbContestType.Size = new System.Drawing.Size(309, 21);
            this.cbContestType.TabIndex = 5;
            this.cbContestType.Leave += new System.EventHandler(this.cbContestType_Leave);
            // 
            // frmContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 234);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cbContestType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmContest";
            this.Text = "Contest";
            this.Load += new System.EventHandler(this.frmContest_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cbContestType, 0);
            this.Controls.SetChildIndex(this.txtNotes, 0);
            this.Controls.SetChildIndex(this.chkActive, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.ComboBox cbContestType;
    }
}

