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
    partial class frmAbstractReport
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
        protected void InitializeComponent()
        {
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.ppcElection = new System.Windows.Forms.PrintPreviewControl();
            this.lstElections = new System.Windows.Forms.ListBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(723, 634);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(111, 23);
            this.btnDown.TabIndex = 10;
            this.btnDown.Text = "Next Page >>";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(606, 634);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(111, 23);
            this.btnUp.TabIndex = 9;
            this.btnUp.Text = "<< Previous Page";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // ppcElection
            // 
            this.ppcElection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ppcElection.Location = new System.Drawing.Point(190, 12);
            this.ppcElection.Name = "ppcElection";
            this.ppcElection.Size = new System.Drawing.Size(648, 616);
            this.ppcElection.TabIndex = 8;
            // 
            // lstElections
            // 
            this.lstElections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstElections.FormattingEnabled = true;
            this.lstElections.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lstElections.Location = new System.Drawing.Point(12, 12);
            this.lstElections.Name = "lstElections";
            this.lstElections.Size = new System.Drawing.Size(172, 615);
            this.lstElections.TabIndex = 7;
            this.lstElections.SelectedIndexChanged += new System.EventHandler(this.lstElections_SelectedIndexChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(12, 632);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "&Print Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmAbstractReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 660);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.ppcElection);
            this.Controls.Add(this.lstElections);
            this.Controls.Add(this.btnPrint);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "frmAbstractReport";
            this.Text = "frmAbstractReport";
            this.Load += new System.EventHandler(this.frmAbstractReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnDown;
        protected System.Windows.Forms.Button btnUp;
        protected System.Windows.Forms.PrintPreviewControl ppcElection;
        protected System.Windows.Forms.ListBox lstElections;
        protected System.Windows.Forms.Button btnPrint;
    }
}