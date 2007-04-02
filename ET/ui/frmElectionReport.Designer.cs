namespace edu.uwec.cs.cs355.group4.et.ui
{
    partial class frmElectionReport
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.rtbElectionReport = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 521);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rtbElectionReport
            // 
            this.rtbElectionReport.Location = new System.Drawing.Point(13, 13);
            this.rtbElectionReport.Name = "rtbElectionReport";
            this.rtbElectionReport.Size = new System.Drawing.Size(467, 491);
            this.rtbElectionReport.TabIndex = 1;
            this.rtbElectionReport.Text = "";
            // 
            // frmElectionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 556);
            this.Controls.Add(this.rtbElectionReport);
            this.Controls.Add(this.btnPrint);
            this.Name = "frmElectionReport";
            this.Text = "Election Report";
            this.Load += new System.EventHandler(this.frmElectionReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RichTextBox rtbElectionReport;
    }
}