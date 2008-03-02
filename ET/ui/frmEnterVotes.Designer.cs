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
namespace edu.uwec.cs.cs355.group4.et.ui
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
            this.cmbElections = new System.Windows.Forms.ComboBox();
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
            this.gbElection.Controls.Add(this.cmbElections);
            this.gbElection.Controls.Add(this.label1);
            this.gbElection.Location = new System.Drawing.Point(12, 12);
            this.gbElection.Name = "gbElection";
            this.gbElection.Size = new System.Drawing.Size(338, 53);
            this.gbElection.TabIndex = 1;
            this.gbElection.TabStop = false;
            this.gbElection.Text = "Election";
            // 
            // cmbElections
            // 
            this.cmbElections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElections.FormattingEnabled = true;
            this.cmbElections.Location = new System.Drawing.Point(60, 19);
            this.cmbElections.Name = "cmbElections";
            this.cmbElections.Size = new System.Drawing.Size(272, 21);
            this.cmbElections.TabIndex = 4;
            this.cmbElections.SelectedIndexChanged += new System.EventHandler(this.cmbElections_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Election:";
            // 
            // gbCounty
            // 
            this.gbCounty.Controls.Add(this.btnNext);
            this.gbCounty.Controls.Add(this.lstCounties);
            this.gbCounty.Location = new System.Drawing.Point(12, 71);
            this.gbCounty.Name = "gbCounty";
            this.gbCounty.Size = new System.Drawing.Size(194, 350);
            this.gbCounty.TabIndex = 2;
            this.gbCounty.TabStop = false;
            this.gbCounty.Text = "Counties";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(106, 321);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lstCounties
            // 
            this.lstCounties.FormattingEnabled = true;
            this.lstCounties.Location = new System.Drawing.Point(9, 19);
            this.lstCounties.Name = "lstCounties";
            this.lstCounties.Size = new System.Drawing.Size(172, 290);
            this.lstCounties.Sorted = true;
            this.lstCounties.TabIndex = 1;
            this.lstCounties.SelectedIndexChanged += new System.EventHandler(this.lstCounties_SelectedIndexChanged);
            // 
            // gbContest
            // 
            this.gbContest.Controls.Add(this.btnSaveVotes);
            this.gbContest.Location = new System.Drawing.Point(212, 71);
            this.gbContest.Name = "gbContest";
            this.gbContest.Size = new System.Drawing.Size(480, 350);
            this.gbContest.TabIndex = 3;
            this.gbContest.TabStop = false;
            this.gbContest.Text = "Contests";
            // 
            // btnSaveVotes
            // 
            this.btnSaveVotes.Location = new System.Drawing.Point(399, 321);
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
            this.ClientSize = new System.Drawing.Size(703, 433);
            this.Controls.Add(this.gbContest);
            this.Controls.Add(this.gbCounty);
            this.Controls.Add(this.gbElection);
            this.Name = "frmEnterVotes";
            this.Text = "Enter Votes";
            this.Load += new System.EventHandler(this.frmEnterVotes_Load);
            this.Resize += new System.EventHandler(this.frmEnterVotes_Resize);
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
        private System.Windows.Forms.ComboBox cmbElections;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCounty;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ListBox lstCounties;
        private System.Windows.Forms.GroupBox gbContest;
        private System.Windows.Forms.Button btnSaveVotes;

    }
}

