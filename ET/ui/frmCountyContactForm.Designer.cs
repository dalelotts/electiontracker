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
    partial class frmCountyContactForm
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
            this.ppcViewer = new System.Windows.Forms.PrintPreviewControl();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ppcViewer
            // 
            this.ppcViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ppcViewer.Location = new System.Drawing.Point(12, 12);
            this.ppcViewer.Name = "ppcViewer";
            this.ppcViewer.Size = new System.Drawing.Size(524, 440);
            this.ppcViewer.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(12, 458);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Location = new System.Drawing.Point(432, 458);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(104, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "Next Page >>";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(322, 458);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(104, 23);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "<< Previous Page";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // frmCountyContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 488);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.ppcViewer);
            this.Name = "frmCountyContactForm";
            this.Text = "County Contact Listing";
            this.Load += new System.EventHandler(this.frmCountyContactForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewControl ppcViewer;
        private System.Windows.Forms.Button btnPrint;
        protected System.Windows.Forms.Button btnDown;
        protected System.Windows.Forms.Button btnUp;
    }
}