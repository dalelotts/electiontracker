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
            this.lstElections = new System.Windows.Forms.ListBox();
            this.ppcElection = new System.Windows.Forms.PrintPreviewControl();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(93, 609);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lstElections
            // 
            this.lstElections.FormattingEnabled = true;
            this.lstElections.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.lstElections.Location = new System.Drawing.Point(12, 12);
            this.lstElections.Name = "lstElections";
            this.lstElections.Size = new System.Drawing.Size(172, 589);
            this.lstElections.TabIndex = 2;
            this.lstElections.SelectedIndexChanged += new System.EventHandler(this.lstElections_SelectedIndexChanged);
            // 
            // ppcElection
            // 
            this.ppcElection.Location = new System.Drawing.Point(190, 12);
            this.ppcElection.Name = "ppcElection";
            this.ppcElection.Size = new System.Drawing.Size(533, 620);
            this.ppcElection.TabIndex = 3;
            this.ppcElection.Click += new System.EventHandler(this.ppcElection_Click);
            // 
            // frmElectionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 644);
            this.Controls.Add(this.ppcElection);
            this.Controls.Add(this.lstElections);
            this.Controls.Add(this.btnPrint);
            this.Name = "frmElectionReport";
            this.Text = "Election Report";
            this.Resize += new System.EventHandler(this.frmElectionReport_Resize);
            this.Load += new System.EventHandler(this.frmElectionReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListBox lstElections;
        private System.Windows.Forms.PrintPreviewControl ppcElection;
    }
}