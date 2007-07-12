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
            this.btnDown.Location = new System.Drawing.Point(731, 320);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(20, 23);
            this.btnDown.TabIndex = 10;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(731, 291);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(21, 23);
            this.btnUp.TabIndex = 9;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // ppcElection
            // 
            this.ppcElection.Location = new System.Drawing.Point(191, 12);
            this.ppcElection.Name = "ppcElection";
            this.ppcElection.Size = new System.Drawing.Size(533, 620);
            this.ppcElection.TabIndex = 8;
            // 
            // lstElections
            // 
            this.lstElections.FormattingEnabled = true;
            this.lstElections.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lstElections.Location = new System.Drawing.Point(13, 12);
            this.lstElections.Name = "lstElections";
            this.lstElections.Size = new System.Drawing.Size(172, 563);
            this.lstElections.TabIndex = 7;
            this.lstElections.SelectedIndexChanged += new System.EventHandler(this.lstElections_SelectedIndexChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(94, 609);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "&Print Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmAbstractReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 644);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.ppcElection);
            this.Controls.Add(this.lstElections);
            this.Controls.Add(this.btnPrint);
            this.Name = "frmAbstractReport";
            this.Text = "frmAbstractReport";
            this.Resize += new System.EventHandler(this.ResizeForm);
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