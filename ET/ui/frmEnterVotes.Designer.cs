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
    internal partial class frmEnterVotes
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
            this.gbElection = new System.Windows.Forms.GroupBox();
            this.cboElections = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCounty = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.lstCounties = new System.Windows.Forms.ListBox();
            this.gbContest = new System.Windows.Forms.GroupBox();
            this.btnSaveVotes = new System.Windows.Forms.Button();
            this.gbElection.SuspendLayout();
            this.gbCounty.SuspendLayout();
            this.gbContest.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbElection
            // 
            this.gbElection.Controls.Add(this.cboElections);
            this.gbElection.Controls.Add(this.label1);
            this.gbElection.Location = new System.Drawing.Point(12, 12);
            this.gbElection.Name = "gbElection";
            this.gbElection.Size = new System.Drawing.Size(338, 53);
            this.gbElection.TabIndex = 0;
            this.gbElection.TabStop = false;
            this.gbElection.Text = "Election";
            // 
            // cboElections
            // 
            this.cboElections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboElections.FormattingEnabled = true;
            this.cboElections.Location = new System.Drawing.Point(60, 19);
            this.cboElections.Name = "cboElections";
            this.cboElections.Size = new System.Drawing.Size(272, 21);
            this.cboElections.TabIndex = 1;
            this.cboElections.SelectedIndexChanged += new System.EventHandler(this.cmbElections_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Election:";
            // 
            // gbCounty
            // 
            this.gbCounty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCounty.Controls.Add(this.btnNext);
            this.gbCounty.Controls.Add(this.lstCounties);
            this.gbCounty.Location = new System.Drawing.Point(12, 71);
            this.gbCounty.Name = "gbCounty";
            this.gbCounty.Size = new System.Drawing.Size(194, 333);
            this.gbCounty.TabIndex = 1;
            this.gbCounty.TabStop = false;
            this.gbCounty.Text = "Counties";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Location = new System.Drawing.Point(106, 304);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lstCounties
            // 
            this.lstCounties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstCounties.FormattingEnabled = true;
            this.lstCounties.Location = new System.Drawing.Point(9, 19);
            this.lstCounties.Name = "lstCounties";
            this.lstCounties.Size = new System.Drawing.Size(172, 264);
            this.lstCounties.Sorted = true;
            this.lstCounties.TabIndex = 0;
            this.lstCounties.SelectedIndexChanged += new System.EventHandler(this.lstCounties_SelectedIndexChanged);
            // 
            // gbContest
            // 
            this.gbContest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContest.Controls.Add(this.btnSaveVotes);
            this.gbContest.Location = new System.Drawing.Point(212, 71);
            this.gbContest.Name = "gbContest";
            this.gbContest.Size = new System.Drawing.Size(469, 333);
            this.gbContest.TabIndex = 2;
            this.gbContest.TabStop = false;
            this.gbContest.Text = "Contests";
            // 
            // btnSaveVotes
            // 
            this.btnSaveVotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveVotes.Location = new System.Drawing.Point(388, 304);
            this.btnSaveVotes.Name = "btnSaveVotes";
            this.btnSaveVotes.Size = new System.Drawing.Size(75, 23);
            this.btnSaveVotes.TabIndex = 0;
            this.btnSaveVotes.Text = "&Save";
            this.btnSaveVotes.UseVisualStyleBackColor = true;
            this.btnSaveVotes.Click += new System.EventHandler(this.btnSaveVotes_Click);
            // 
            // frmEnterVotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 416);
            this.Controls.Add(this.gbContest);
            this.Controls.Add(this.gbCounty);
            this.Controls.Add(this.gbElection);
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "frmEnterVotes";
            this.Text = "Enter Votes";
            this.Load += new System.EventHandler(this.frmEnterVotes_Load);
            this.Controls.SetChildIndex(this.gbElection, 0);
            this.Controls.SetChildIndex(this.gbCounty, 0);
            this.Controls.SetChildIndex(this.gbContest, 0);
            this.gbElection.ResumeLayout(false);
            this.gbElection.PerformLayout();
            this.gbCounty.ResumeLayout(false);
            this.gbContest.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbElection;
        private System.Windows.Forms.ComboBox cboElections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCounty;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ListBox lstCounties;
        private System.Windows.Forms.GroupBox gbContest;
        private System.Windows.Forms.Button btnSaveVotes;

    }
}

