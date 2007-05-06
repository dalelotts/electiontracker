using System.ComponentModel;
using System.Windows.Forms;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    internal partial class frmCandidate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.gbCandidate = new System.Windows.Forms.GroupBox();
            this.cboPoliticalParty = new System.Windows.Forms.ComboBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.gbCandidate.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCandidate
            // 
            this.gbCandidate.Controls.Add(this.cboPoliticalParty);
            this.gbCandidate.Controls.Add(this.chkActive);
            this.gbCandidate.Controls.Add(this.txtNotes);
            this.gbCandidate.Controls.Add(this.label6);
            this.gbCandidate.Controls.Add(this.label5);
            this.gbCandidate.Controls.Add(this.label4);
            this.gbCandidate.Controls.Add(this.txtLastName);
            this.gbCandidate.Controls.Add(this.label3);
            this.gbCandidate.Controls.Add(this.txtMiddleName);
            this.gbCandidate.Controls.Add(this.label2);
            this.gbCandidate.Controls.Add(this.txtFirstName);
            this.gbCandidate.Location = new System.Drawing.Point(12, 28);
            this.gbCandidate.Name = "gbCandidate";
            this.gbCandidate.Size = new System.Drawing.Size(369, 308);
            this.gbCandidate.TabIndex = 11;
            this.gbCandidate.TabStop = false;
            this.gbCandidate.Text = "Candidate";
            // 
            // cboPoliticalParty
            // 
            this.cboPoliticalParty.FormattingEnabled = true;
            this.cboPoliticalParty.Location = new System.Drawing.Point(88, 95);
            this.cboPoliticalParty.Name = "cboPoliticalParty";
            this.cboPoliticalParty.Size = new System.Drawing.Size(270, 21);
            this.cboPoliticalParty.TabIndex = 30;
            this.cboPoliticalParty.Tag = "lock=true";
            this.cboPoliticalParty.Leave += new System.EventHandler(this.cboPoliticalParty_Leave);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(15, 287);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(62, 17);
            this.chkActive.TabIndex = 29;
            this.chkActive.Tag = "lock=true";
            this.chkActive.Text = "Active?";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(15, 145);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(343, 136);
            this.txtNotes.TabIndex = 28;
            this.txtNotes.Tag = "lock=true";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "N&otes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "&Political Party";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "&Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(88, 69);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(270, 20);
            this.txtLastName.TabIndex = 24;
            this.txtLastName.Tag = "lock=true";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "&Middle Name";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(88, 43);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(270, 20);
            this.txtMiddleName.TabIndex = 22;
            this.txtMiddleName.Tag = "lock=true";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "&First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(88, 17);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(270, 20);
            this.txtFirstName.TabIndex = 20;
            this.txtFirstName.Tag = "lock=true";
            // 
            // frmCandidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 345);
            this.Controls.Add(this.gbCandidate);
            this.Name = "frmCandidate";
            this.Text = "Candidate";
            this.Controls.SetChildIndex(this.gbCandidate, 0);
            this.gbCandidate.ResumeLayout(false);
            this.gbCandidate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox gbCandidate;
        private ComboBox cboPoliticalParty;
        private CheckBox chkActive;
        private TextBox txtNotes;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtLastName;
        private Label label3;
        private TextBox txtMiddleName;
        private Label label2;
        private TextBox txtFirstName;


    }
}