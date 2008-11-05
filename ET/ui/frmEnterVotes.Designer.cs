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
            this.components = new System.ComponentModel.Container();
            this.gbElection = new System.Windows.Forms.GroupBox();
            this.cboElections = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCounty = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.lstCounties = new System.Windows.Forms.ListBox();
            this.gbContest = new System.Windows.Forms.GroupBox();
            this.btnSaveVotes = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_electionDayNumber = new System.Windows.Forms.Label();
            this.lbl_mainNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbElection.SuspendLayout();
            this.gbCounty.SuspendLayout();
            this.gbContest.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.cboElections.TabIndex = 3;
            this.cboElections.TabStop = false;
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
            this.gbCounty.TabIndex = 2;
            this.gbCounty.TabStop = false;
            this.gbCounty.Text = "Counties";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Location = new System.Drawing.Point(106, 304);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.TabStop = false;
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
            this.lstCounties.TabIndex = 2;
            this.lstCounties.TabStop = false;
            this.lstCounties.UseTabStops = false;
            this.lstCounties.SelectedIndexChanged += new System.EventHandler(this.lstCounties_SelectedIndexChanged);
            this.lstCounties.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstCounties_MouseMove);
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
            this.gbContest.TabIndex = 0;
            this.gbContest.TabStop = false;
            this.gbContest.Text = "Contests";
            this.gbContest.Enter += new System.EventHandler(this.gbContest_Enter);
            // 
            // btnSaveVotes
            // 
            this.btnSaveVotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveVotes.Location = new System.Drawing.Point(388, 304);
            this.btnSaveVotes.Name = "btnSaveVotes";
            this.btnSaveVotes.Size = new System.Drawing.Size(75, 23);
            this.btnSaveVotes.TabIndex = 1;
            this.btnSaveVotes.Text = "&Save";
            this.btnSaveVotes.UseVisualStyleBackColor = true;
            this.btnSaveVotes.Click += new System.EventHandler(this.btnSaveVotes_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_electionDayNumber);
            this.groupBox1.Controls.Add(this.lbl_mainNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(356, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 53);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "County Contact Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbl_electionDayNumber
            // 
            this.lbl_electionDayNumber.AutoSize = true;
            this.lbl_electionDayNumber.Location = new System.Drawing.Point(117, 34);
            this.lbl_electionDayNumber.Name = "lbl_electionDayNumber";
            this.lbl_electionDayNumber.Size = new System.Drawing.Size(102, 13);
            this.lbl_electionDayNumber.TabIndex = 3;
            this.lbl_electionDayNumber.Text = "election day number";
            // 
            // lbl_mainNumber
            // 
            this.lbl_mainNumber.AutoSize = true;
            this.lbl_mainNumber.Location = new System.Drawing.Point(78, 16);
            this.lbl_mainNumber.Name = "lbl_mainNumber";
            this.lbl_mainNumber.Size = new System.Drawing.Size(67, 13);
            this.lbl_mainNumber.TabIndex = 2;
            this.lbl_mainNumber.Text = "main number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Election Day Number: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Main Number: ";
            // 
            // frmEnterVotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbContest);
            this.Controls.Add(this.gbCounty);
            this.Controls.Add(this.gbElection);
            this.MinimumSize = new System.Drawing.Size(700, 450);
            this.Name = "frmEnterVotes";
            this.Text = "Enter Votes";
            this.Load += new System.EventHandler(this.frmEnterVotes_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEnterVotes_Closing);
            this.Controls.SetChildIndex(this.gbElection, 0);
            this.Controls.SetChildIndex(this.gbCounty, 0);
            this.Controls.SetChildIndex(this.gbContest, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.gbElection.ResumeLayout(false);
            this.gbElection.PerformLayout();
            this.gbCounty.ResumeLayout(false);
            this.gbContest.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_electionDayNumber;
        private System.Windows.Forms.Label lbl_mainNumber;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}

