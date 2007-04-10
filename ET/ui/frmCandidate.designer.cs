using System;

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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "&First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(91, 37);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(270, 20);
            this.txtFirstName.TabIndex = 6;
            this.txtFirstName.Tag = "lock=true";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "&Middle Name";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(91, 63);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(270, 20);
            this.txtMiddleName.TabIndex = 8;
            this.txtMiddleName.Tag = "lock=true";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "&Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(91, 89);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(270, 20);
            this.txtLastName.TabIndex = 10;
            this.txtLastName.Tag = "lock=true";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "&Political Party";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "N&otes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(18, 165);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(343, 136);
            this.txtNotes.TabIndex = 15;
            this.txtNotes.Tag = "lock=true";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(18, 307);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(62, 17);
            this.chkActive.TabIndex = 17;
            this.chkActive.Tag = "lock=true";
            this.chkActive.Text = "Active?";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // cboPoliticalParty
            // 
            this.cboPoliticalParty.FormattingEnabled = true;
            this.cboPoliticalParty.Location = new System.Drawing.Point(91, 115);
            this.cboPoliticalParty.Name = "cboPoliticalParty";
            this.cboPoliticalParty.Size = new System.Drawing.Size(270, 21);
            this.cboPoliticalParty.TabIndex = 19;
            this.cboPoliticalParty.Tag = "lock=true";
            // 
            // frmCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 337);
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
            this.Name = "frmCandidate";
            this.Text = "Candidate";
            this.Controls.SetChildIndex(this.txtFirstName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtMiddleName, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtLastName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtNotes, 0);
            this.Controls.SetChildIndex(this.chkActive, 0);
            this.Controls.SetChildIndex(this.cboPoliticalParty, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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