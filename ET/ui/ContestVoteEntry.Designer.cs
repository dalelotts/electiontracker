namespace KnightRider.ElectionTracker.ui
{
    partial class ContestVoteEntry
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblContestName = new System.Windows.Forms.Label();
            this.lblWardTotal = new System.Windows.Forms.Label();
            this.txtWardsReporting = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblContestName
            // 
            this.lblContestName.AutoSize = true;
            this.lblContestName.Location = new System.Drawing.Point(3, 7);
            this.lblContestName.Name = "lblContestName";
            this.lblContestName.Size = new System.Drawing.Size(74, 13);
            this.lblContestName.TabIndex = 0;
            this.lblContestName.Text = "Contest Name";
            // 
            // lblWardTotal
            // 
            this.lblWardTotal.AutoSize = true;
            this.lblWardTotal.Location = new System.Drawing.Point(274, 7);
            this.lblWardTotal.Name = "lblWardTotal";
            this.lblWardTotal.Size = new System.Drawing.Size(35, 13);
            this.lblWardTotal.TabIndex = 1;
            this.lblWardTotal.Text = "####";
            // 
            // txtWardsReporting
            // 
            this.txtWardsReporting.Location = new System.Drawing.Point(240, 3);
            this.txtWardsReporting.Name = "txtWardsReporting";
            this.txtWardsReporting.Size = new System.Drawing.Size(28, 20);
            this.txtWardsReporting.TabIndex = 2;
            // 
            // ContestVoteEntry
            // 
            this.Controls.Add(this.txtWardsReporting);
            this.Controls.Add(this.lblWardTotal);
            this.Controls.Add(this.lblContestName);
            this.Name = "ContestVoteEntry";
            this.Size = new System.Drawing.Size(312, 87);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContestName;
        private System.Windows.Forms.Label lblWardTotal;
        private System.Windows.Forms.TextBox txtWardsReporting;
    }
}
