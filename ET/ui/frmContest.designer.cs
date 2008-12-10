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
using System.ComponentModel;
using System.Windows.Forms;

namespace KnightRider.ElectionTracker.ui
{
    partial class frmContest
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
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblRequired = new System.Windows.Forms.Label();
            this.chkFinal = new System.Windows.Forms.CheckBox();
            this.tcContest = new System.Windows.Forms.TabControl();
            this.tpContest = new System.Windows.Forms.TabPage();
            this.tpCounties = new System.Windows.Forms.TabPage();
            this.lstAllCounties = new System.Windows.Forms.ListBox();
            this.dgvContestCounties = new System.Windows.Forms.DataGridView();
            this.countyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wardCountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAllCounties = new System.Windows.Forms.Label();
            this.btnAddAllCounties = new System.Windows.Forms.Button();
            this.btnRemoveCounty = new System.Windows.Forms.Button();
            this.btnRemoveAllCounties = new System.Windows.Forms.Button();
            this.btnAddCounty = new System.Windows.Forms.Button();
            this.lblMemberCounties = new System.Windows.Forms.Label();
            this.tcContest.SuspendLayout();
            this.tpContest.SuspendLayout();
            this.tpCounties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContestCounties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(13, 35);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 3;
            this.lblNotes.Text = "Notes:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(42, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name *";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(57, 32);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(343, 167);
            this.txtNotes.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(57, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(343, 20);
            this.txtName.TabIndex = 2;
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(12, 204);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(62, 17);
            this.chkActive.TabIndex = 5;
            this.chkActive.Text = "Active?";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.ForeColor = System.Drawing.Color.Blue;
            this.lblRequired.Location = new System.Drawing.Point(12, 41);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(177, 16);
            this.lblRequired.TabIndex = 0;
            this.lblRequired.Text = "A * indicates a required field.";
            // 
            // chkFinal
            // 
            this.chkFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFinal.AutoSize = true;
            this.chkFinal.Location = new System.Drawing.Point(80, 205);
            this.chkFinal.Name = "chkFinal";
            this.chkFinal.Size = new System.Drawing.Size(54, 17);
            this.chkFinal.TabIndex = 11;
            this.chkFinal.Text = "Final?";
            this.chkFinal.UseVisualStyleBackColor = true;
            this.chkFinal.CheckedChanged += new System.EventHandler(this.chkFinal_CheckedChanged);
            // 
            // tcContest
            // 
            this.tcContest.Controls.Add(this.tpContest);
            this.tcContest.Controls.Add(this.tpCounties);
            this.tcContest.Location = new System.Drawing.Point(12, 60);
            this.tcContest.Name = "tcContest";
            this.tcContest.SelectedIndex = 0;
            this.tcContest.Size = new System.Drawing.Size(414, 253);
            this.tcContest.TabIndex = 12;
            // 
            // tpContest
            // 
            this.tpContest.Controls.Add(this.txtName);
            this.tpContest.Controls.Add(this.lblName);
            this.tpContest.Controls.Add(this.chkFinal);
            this.tpContest.Controls.Add(this.chkActive);
            this.tpContest.Controls.Add(this.txtNotes);
            this.tpContest.Controls.Add(this.lblNotes);
            this.tpContest.Location = new System.Drawing.Point(4, 22);
            this.tpContest.Name = "tpContest";
            this.tpContest.Padding = new System.Windows.Forms.Padding(3);
            this.tpContest.Size = new System.Drawing.Size(406, 227);
            this.tpContest.TabIndex = 0;
            this.tpContest.Text = "Contest";
            this.tpContest.UseVisualStyleBackColor = true;
            // 
            // tpCounties
            // 
            this.tpCounties.Controls.Add(this.lstAllCounties);
            this.tpCounties.Controls.Add(this.dgvContestCounties);
            this.tpCounties.Controls.Add(this.lblAllCounties);
            this.tpCounties.Controls.Add(this.btnAddAllCounties);
            this.tpCounties.Controls.Add(this.btnRemoveCounty);
            this.tpCounties.Controls.Add(this.btnRemoveAllCounties);
            this.tpCounties.Controls.Add(this.btnAddCounty);
            this.tpCounties.Controls.Add(this.lblMemberCounties);
            this.tpCounties.Location = new System.Drawing.Point(4, 22);
            this.tpCounties.Name = "tpCounties";
            this.tpCounties.Padding = new System.Windows.Forms.Padding(3);
            this.tpCounties.Size = new System.Drawing.Size(406, 227);
            this.tpCounties.TabIndex = 1;
            this.tpCounties.Text = "Counties";
            this.tpCounties.UseVisualStyleBackColor = true;
            // 
            // lstAllCounties
            // 
            this.lstAllCounties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllCounties.FormattingEnabled = true;
            this.lstAllCounties.Location = new System.Drawing.Point(220, 19);
            this.lstAllCounties.Name = "lstAllCounties";
            this.lstAllCounties.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAllCounties.Size = new System.Drawing.Size(160, 199);
            this.lstAllCounties.Sorted = true;
            this.lstAllCounties.TabIndex = 18;
            // 
            // dgvContestCounties
            // 
            this.dgvContestCounties.AllowUserToAddRows = false;
            this.dgvContestCounties.AllowUserToDeleteRows = false;
            this.dgvContestCounties.AllowUserToResizeRows = false;
            this.dgvContestCounties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvContestCounties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContestCounties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContestCounties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.countyColumn,
            this.wardCountColumn});
            this.dgvContestCounties.Location = new System.Drawing.Point(9, 19);
            this.dgvContestCounties.MultiSelect = false;
            this.dgvContestCounties.Name = "dgvContestCounties";
            this.dgvContestCounties.RowHeadersVisible = false;
            this.dgvContestCounties.RowHeadersWidth = 60;
            this.dgvContestCounties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContestCounties.Size = new System.Drawing.Size(172, 199);
            this.dgvContestCounties.TabIndex = 12;
            // 
            // countyColumn
            // 
            this.countyColumn.FillWeight = 76.92308F;
            this.countyColumn.HeaderText = "County";
            this.countyColumn.Name = "countyColumn";
            this.countyColumn.ReadOnly = true;
            // 
            // wardCountColumn
            // 
            this.wardCountColumn.FillWeight = 123.0769F;
            this.wardCountColumn.HeaderText = "Reporting Units";
            this.wardCountColumn.Name = "wardCountColumn";
            this.wardCountColumn.ToolTipText = "Enter the reporting units for this county in this contest.";
            // 
            // lblAllCounties
            // 
            this.lblAllCounties.AutoSize = true;
            this.lblAllCounties.Location = new System.Drawing.Point(217, 3);
            this.lblAllCounties.Name = "lblAllCounties";
            this.lblAllCounties.Size = new System.Drawing.Size(94, 13);
            this.lblAllCounties.TabIndex = 13;
            this.lblAllCounties.Text = "Available Counties";
            // 
            // btnAddAllCounties
            // 
            this.btnAddAllCounties.Location = new System.Drawing.Point(187, 38);
            this.btnAddAllCounties.Name = "btnAddAllCounties";
            this.btnAddAllCounties.Size = new System.Drawing.Size(27, 24);
            this.btnAddAllCounties.TabIndex = 14;
            this.btnAddAllCounties.Text = "<<";
            this.btnAddAllCounties.UseVisualStyleBackColor = true;
            this.btnAddAllCounties.Click += new System.EventHandler(this.btnAddAllCounties_Click);
            // 
            // btnRemoveCounty
            // 
            this.btnRemoveCounty.Image = global::KnightRider.ElectionTracker.Properties.Resources.arrow_right;
            this.btnRemoveCounty.Location = new System.Drawing.Point(187, 94);
            this.btnRemoveCounty.Name = "btnRemoveCounty";
            this.btnRemoveCounty.Size = new System.Drawing.Size(27, 24);
            this.btnRemoveCounty.TabIndex = 16;
            this.btnRemoveCounty.UseVisualStyleBackColor = true;
            this.btnRemoveCounty.Click += new System.EventHandler(this.btnRemoveCounty_Click);
            // 
            // btnRemoveAllCounties
            // 
            this.btnRemoveAllCounties.Location = new System.Drawing.Point(187, 122);
            this.btnRemoveAllCounties.Name = "btnRemoveAllCounties";
            this.btnRemoveAllCounties.Size = new System.Drawing.Size(27, 24);
            this.btnRemoveAllCounties.TabIndex = 17;
            this.btnRemoveAllCounties.Text = ">>";
            this.btnRemoveAllCounties.UseVisualStyleBackColor = true;
            this.btnRemoveAllCounties.Click += new System.EventHandler(this.btnRemoveAllCounties_Click);
            // 
            // btnAddCounty
            // 
            this.btnAddCounty.Image = global::KnightRider.ElectionTracker.Properties.Resources.arrow_left;
            this.btnAddCounty.Location = new System.Drawing.Point(187, 66);
            this.btnAddCounty.Name = "btnAddCounty";
            this.btnAddCounty.Size = new System.Drawing.Size(27, 24);
            this.btnAddCounty.TabIndex = 15;
            this.btnAddCounty.UseVisualStyleBackColor = true;
            this.btnAddCounty.Click += new System.EventHandler(this.btnAddCounty_Click);
            // 
            // lblMemberCounties
            // 
            this.lblMemberCounties.AutoSize = true;
            this.lblMemberCounties.Location = new System.Drawing.Point(6, 3);
            this.lblMemberCounties.Name = "lblMemberCounties";
            this.lblMemberCounties.Size = new System.Drawing.Size(55, 13);
            this.lblMemberCounties.TabIndex = 11;
            this.lblMemberCounties.Text = "Counties *";
            // 
            // frmContest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 316);
            this.Controls.Add(this.lblRequired);
            this.Controls.Add(this.tcContest);
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "frmContest";
            this.Text = "Contest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmContest_FormClosing);
            this.Controls.SetChildIndex(this.tcContest, 0);
            this.Controls.SetChildIndex(this.lblRequired, 0);
            this.tcContest.ResumeLayout(false);
            this.tpContest.ResumeLayout(false);
            this.tpContest.PerformLayout();
            this.tpCounties.ResumeLayout(false);
            this.tpCounties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContestCounties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNotes;
        private Label lblName;
        private TextBox txtNotes;
        private TextBox txtName;
        private CheckBox chkActive;
        private Label lblRequired;
        private CheckBox chkFinal;
        private TabControl tcContest;
        private TabPage tpContest;
        private TabPage tpCounties;
        private ListBox lstAllCounties;
        private DataGridView dgvContestCounties;
        private DataGridViewTextBoxColumn countyColumn;
        private DataGridViewTextBoxColumn wardCountColumn;
        private Label lblAllCounties;
        private Button btnAddAllCounties;
        private Button btnRemoveCounty;
        private Button btnRemoveAllCounties;
        private Button btnAddCounty;
        private Label lblMemberCounties;
    }
}

