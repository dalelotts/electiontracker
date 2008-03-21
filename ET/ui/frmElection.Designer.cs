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
    partial class frmElection
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listBox6 = new System.Windows.Forms.ListBox();
            this.listBox7 = new System.Windows.Forms.ListBox();
            this.listBox5 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbDisplay = new System.Windows.Forms.TabControl();
            this.tabElection = new System.Windows.Forms.TabPage();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabContests = new System.Windows.Forms.TabPage();
            this.btnAddAllContests = new System.Windows.Forms.Button();
            this.btnRemoveContest = new System.Windows.Forms.Button();
            this.btnRemoveAllContests = new System.Windows.Forms.Button();
            this.btnAddContest = new System.Windows.Forms.Button();
            this.lstAllContests = new System.Windows.Forms.ListBox();
            this.lstElectionContests = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.btnResponseDown = new System.Windows.Forms.Button();
            this.btnResponseUp = new System.Windows.Forms.Button();
            this.btnAddCustomResponse = new System.Windows.Forms.Button();
            this.txtCustomResponse = new System.Windows.Forms.TextBox();
            this.btnAddAllCandidates = new System.Windows.Forms.Button();
            this.btnRemoveCandidate = new System.Windows.Forms.Button();
            this.btnRemoveAllCandidates = new System.Windows.Forms.Button();
            this.btnAddCandidate = new System.Windows.Forms.Button();
            this.lstContestCandidate = new System.Windows.Forms.ListBox();
            this.lstAllCandidates = new System.Windows.Forms.ListBox();
            this.lstContestCandidates = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pgCounties = new System.Windows.Forms.TabPage();
            this.dgvContestCounties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCounties = new System.Windows.Forms.DataGridView();
            this.dgvCounty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvWardCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAddAllCounties = new System.Windows.Forms.Button();
            this.btnRemoveCounty = new System.Windows.Forms.Button();
            this.btnRemoveAllCounties = new System.Windows.Forms.Button();
            this.btnAddCounty = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lstContestCounty = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblRequired = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tbDisplay.SuspendLayout();
            this.tabElection.SuspendLayout();
            this.tabContests.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.pgCounties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContestCounties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(11, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(407, 332);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(399, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Election";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(23, 272);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Active";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(64, 103);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(317, 151);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Notes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(399, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contests";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "label5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Members";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(188, 188);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 25);
            this.button5.TabIndex = 5;
            this.button5.Text = ">>";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(188, 95);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 25);
            this.button4.TabIndex = 4;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 157);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 25);
            this.button3.TabIndex = 3;
            this.button3.Text = ">";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(223, 33);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(161, 264);
            this.listBox2.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(18, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(161, 264);
            this.listBox1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox6);
            this.tabPage3.Controls.Add(this.listBox7);
            this.tabPage3.Controls.Add(this.listBox5);
            this.tabPage3.Controls.Add(this.listBox4);
            this.tabPage3.Controls.Add(this.listBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(399, 306);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Contest Details";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBox6
            // 
            this.listBox6.FormattingEnabled = true;
            this.listBox6.Location = new System.Drawing.Point(276, 205);
            this.listBox6.Name = "listBox6";
            this.listBox6.Size = new System.Drawing.Size(120, 95);
            this.listBox6.TabIndex = 4;
            // 
            // listBox7
            // 
            this.listBox7.FormattingEnabled = true;
            this.listBox7.Location = new System.Drawing.Point(276, 36);
            this.listBox7.Name = "listBox7";
            this.listBox7.Size = new System.Drawing.Size(120, 95);
            this.listBox7.TabIndex = 3;
            // 
            // listBox5
            // 
            this.listBox5.FormattingEnabled = true;
            this.listBox5.Location = new System.Drawing.Point(145, 205);
            this.listBox5.Name = "listBox5";
            this.listBox5.Size = new System.Drawing.Size(120, 95);
            this.listBox5.TabIndex = 2;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(145, 36);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(120, 95);
            this.listBox4.TabIndex = 1;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(6, 36);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 264);
            this.listBox3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "&Duplicate";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbDisplay
            // 
            this.tbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisplay.Controls.Add(this.tabElection);
            this.tbDisplay.Controls.Add(this.tabContests);
            this.tbDisplay.Controls.Add(this.tabDetails);
            this.tbDisplay.Controls.Add(this.pgCounties);
            this.tbDisplay.Location = new System.Drawing.Point(12, 55);
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.SelectedIndex = 0;
            this.tbDisplay.Size = new System.Drawing.Size(587, 303);
            this.tbDisplay.TabIndex = 0;
            // 
            // tabElection
            // 
            this.tabElection.Controls.Add(this.dtpDate);
            this.tabElection.Controls.Add(this.label9);
            this.tabElection.Controls.Add(this.chkActive);
            this.tabElection.Controls.Add(this.txtNotes);
            this.tabElection.Controls.Add(this.label7);
            this.tabElection.Location = new System.Drawing.Point(4, 22);
            this.tabElection.Name = "tabElection";
            this.tabElection.Padding = new System.Windows.Forms.Padding(3);
            this.tabElection.Size = new System.Drawing.Size(579, 277);
            this.tabElection.TabIndex = 0;
            this.tabElection.Text = "Election";
            this.tabElection.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(64, 15);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Date *";
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(503, 15);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(62, 17);
            this.chkActive.TabIndex = 4;
            this.chkActive.Text = "Active?";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(64, 50);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(501, 221);
            this.txtNotes.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Notes:";
            // 
            // tabContests
            // 
            this.tabContests.Controls.Add(this.btnAddAllContests);
            this.tabContests.Controls.Add(this.btnRemoveContest);
            this.tabContests.Controls.Add(this.btnRemoveAllContests);
            this.tabContests.Controls.Add(this.btnAddContest);
            this.tabContests.Controls.Add(this.lstAllContests);
            this.tabContests.Controls.Add(this.lstElectionContests);
            this.tabContests.Controls.Add(this.label10);
            this.tabContests.Controls.Add(this.label11);
            this.tabContests.Location = new System.Drawing.Point(4, 22);
            this.tabContests.Name = "tabContests";
            this.tabContests.Padding = new System.Windows.Forms.Padding(3);
            this.tabContests.Size = new System.Drawing.Size(579, 277);
            this.tabContests.TabIndex = 1;
            this.tabContests.Text = "Contests";
            this.tabContests.UseVisualStyleBackColor = true;
            // 
            // btnAddAllContests
            // 
            this.btnAddAllContests.Location = new System.Drawing.Point(258, 33);
            this.btnAddAllContests.Name = "btnAddAllContests";
            this.btnAddAllContests.Size = new System.Drawing.Size(30, 29);
            this.btnAddAllContests.TabIndex = 4;
            this.btnAddAllContests.Text = "<<";
            this.btnAddAllContests.UseVisualStyleBackColor = true;
            this.btnAddAllContests.Click += new System.EventHandler(this.btnAddAllContests_Click);
            // 
            // btnRemoveContest
            // 
            this.btnRemoveContest.Location = new System.Drawing.Point(258, 106);
            this.btnRemoveContest.Name = "btnRemoveContest";
            this.btnRemoveContest.Size = new System.Drawing.Size(30, 29);
            this.btnRemoveContest.TabIndex = 6;
            this.btnRemoveContest.Text = ">";
            this.btnRemoveContest.UseVisualStyleBackColor = true;
            this.btnRemoveContest.Click += new System.EventHandler(this.btnRemoveContest_Click);
            // 
            // btnRemoveAllContests
            // 
            this.btnRemoveAllContests.Location = new System.Drawing.Point(258, 141);
            this.btnRemoveAllContests.Name = "btnRemoveAllContests";
            this.btnRemoveAllContests.Size = new System.Drawing.Size(30, 29);
            this.btnRemoveAllContests.TabIndex = 7;
            this.btnRemoveAllContests.Text = ">>";
            this.btnRemoveAllContests.UseVisualStyleBackColor = true;
            this.btnRemoveAllContests.Click += new System.EventHandler(this.btnRemoveAllContests_Click);
            // 
            // btnAddContest
            // 
            this.btnAddContest.Location = new System.Drawing.Point(258, 68);
            this.btnAddContest.Name = "btnAddContest";
            this.btnAddContest.Size = new System.Drawing.Size(30, 29);
            this.btnAddContest.TabIndex = 5;
            this.btnAddContest.Text = "<";
            this.btnAddContest.UseVisualStyleBackColor = true;
            this.btnAddContest.Click += new System.EventHandler(this.btnAddContest_Click);
            // 
            // lstAllContests
            // 
            this.lstAllContests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllContests.FormattingEnabled = true;
            this.lstAllContests.Location = new System.Drawing.Point(294, 31);
            this.lstAllContests.Name = "lstAllContests";
            this.lstAllContests.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAllContests.Size = new System.Drawing.Size(271, 238);
            this.lstAllContests.Sorted = true;
            this.lstAllContests.TabIndex = 3;
            // 
            // lstElectionContests
            // 
            this.lstElectionContests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstElectionContests.FormattingEnabled = true;
            this.lstElectionContests.Location = new System.Drawing.Point(6, 31);
            this.lstElectionContests.Name = "lstElectionContests";
            this.lstElectionContests.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstElectionContests.Size = new System.Drawing.Size(246, 238);
            this.lstElectionContests.Sorted = true;
            this.lstElectionContests.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Members *";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(332, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "All";
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.btnResponseDown);
            this.tabDetails.Controls.Add(this.btnResponseUp);
            this.tabDetails.Controls.Add(this.btnAddCustomResponse);
            this.tabDetails.Controls.Add(this.txtCustomResponse);
            this.tabDetails.Controls.Add(this.btnAddAllCandidates);
            this.tabDetails.Controls.Add(this.btnRemoveCandidate);
            this.tabDetails.Controls.Add(this.btnRemoveAllCandidates);
            this.tabDetails.Controls.Add(this.btnAddCandidate);
            this.tabDetails.Controls.Add(this.lstContestCandidate);
            this.tabDetails.Controls.Add(this.lstAllCandidates);
            this.tabDetails.Controls.Add(this.lstContestCandidates);
            this.tabDetails.Controls.Add(this.label13);
            this.tabDetails.Controls.Add(this.label12);
            this.tabDetails.Controls.Add(this.label8);
            this.tabDetails.Controls.Add(this.label6);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(579, 277);
            this.tabDetails.TabIndex = 2;
            this.tabDetails.Text = "Candidates";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // btnResponseDown
            // 
            this.btnResponseDown.Location = new System.Drawing.Point(358, 237);
            this.btnResponseDown.Name = "btnResponseDown";
            this.btnResponseDown.Size = new System.Drawing.Size(27, 22);
            this.btnResponseDown.TabIndex = 14;
            this.btnResponseDown.Text = "v";
            this.btnResponseDown.UseVisualStyleBackColor = true;
            this.btnResponseDown.Click += new System.EventHandler(this.btnResponseDown_Click);
            // 
            // btnResponseUp
            // 
            this.btnResponseUp.Location = new System.Drawing.Point(358, 209);
            this.btnResponseUp.Name = "btnResponseUp";
            this.btnResponseUp.Size = new System.Drawing.Size(27, 22);
            this.btnResponseUp.TabIndex = 13;
            this.btnResponseUp.Text = "^";
            this.btnResponseUp.UseVisualStyleBackColor = true;
            this.btnResponseUp.Click += new System.EventHandler(this.btnResponseUp_Click);
            // 
            // btnAddCustomResponse
            // 
            this.btnAddCustomResponse.Location = new System.Drawing.Point(358, 36);
            this.btnAddCustomResponse.Name = "btnAddCustomResponse";
            this.btnAddCustomResponse.Size = new System.Drawing.Size(27, 22);
            this.btnAddCustomResponse.TabIndex = 6;
            this.btnAddCustomResponse.Text = "<";
            this.btnAddCustomResponse.UseVisualStyleBackColor = true;
            this.btnAddCustomResponse.Click += new System.EventHandler(this.btnAddCustomResponse_Click);
            // 
            // txtCustomResponse
            // 
            this.txtCustomResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomResponse.Location = new System.Drawing.Point(391, 36);
            this.txtCustomResponse.Name = "txtCustomResponse";
            this.txtCustomResponse.Size = new System.Drawing.Size(173, 20);
            this.txtCustomResponse.TabIndex = 5;
            // 
            // btnAddAllCandidates
            // 
            this.btnAddAllCandidates.Location = new System.Drawing.Point(358, 85);
            this.btnAddAllCandidates.Name = "btnAddAllCandidates";
            this.btnAddAllCandidates.Size = new System.Drawing.Size(27, 22);
            this.btnAddAllCandidates.TabIndex = 9;
            this.btnAddAllCandidates.Text = "<<";
            this.btnAddAllCandidates.UseVisualStyleBackColor = true;
            this.btnAddAllCandidates.Click += new System.EventHandler(this.btnAddAllCandidates_Click);
            // 
            // btnRemoveCandidate
            // 
            this.btnRemoveCandidate.Location = new System.Drawing.Point(358, 141);
            this.btnRemoveCandidate.Name = "btnRemoveCandidate";
            this.btnRemoveCandidate.Size = new System.Drawing.Size(27, 22);
            this.btnRemoveCandidate.TabIndex = 11;
            this.btnRemoveCandidate.Text = ">";
            this.btnRemoveCandidate.UseVisualStyleBackColor = true;
            this.btnRemoveCandidate.Click += new System.EventHandler(this.btnRemoveCandidate_Click);
            // 
            // btnRemoveAllCandidates
            // 
            this.btnRemoveAllCandidates.Location = new System.Drawing.Point(358, 169);
            this.btnRemoveAllCandidates.Name = "btnRemoveAllCandidates";
            this.btnRemoveAllCandidates.Size = new System.Drawing.Size(27, 22);
            this.btnRemoveAllCandidates.TabIndex = 12;
            this.btnRemoveAllCandidates.Text = ">>";
            this.btnRemoveAllCandidates.UseVisualStyleBackColor = true;
            this.btnRemoveAllCandidates.Click += new System.EventHandler(this.btnRemoveAllCandidates_Click);
            // 
            // btnAddCandidate
            // 
            this.btnAddCandidate.Location = new System.Drawing.Point(357, 113);
            this.btnAddCandidate.Name = "btnAddCandidate";
            this.btnAddCandidate.Size = new System.Drawing.Size(27, 22);
            this.btnAddCandidate.TabIndex = 10;
            this.btnAddCandidate.Text = "<";
            this.btnAddCandidate.UseVisualStyleBackColor = true;
            this.btnAddCandidate.Click += new System.EventHandler(this.btnAddCandidate_Click);
            // 
            // lstContestCandidate
            // 
            this.lstContestCandidate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstContestCandidate.FormattingEnabled = true;
            this.lstContestCandidate.Location = new System.Drawing.Point(9, 35);
            this.lstContestCandidate.Name = "lstContestCandidate";
            this.lstContestCandidate.Size = new System.Drawing.Size(163, 225);
            this.lstContestCandidate.Sorted = true;
            this.lstContestCandidate.TabIndex = 1;
            this.lstContestCandidate.SelectedIndexChanged += new System.EventHandler(this.lstContestCandidate_SelectedIndexChanged);
            // 
            // lstAllCandidates
            // 
            this.lstAllCandidates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllCandidates.FormattingEnabled = true;
            this.lstAllCandidates.Location = new System.Drawing.Point(391, 85);
            this.lstAllCandidates.Name = "lstAllCandidates";
            this.lstAllCandidates.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAllCandidates.Size = new System.Drawing.Size(173, 173);
            this.lstAllCandidates.Sorted = true;
            this.lstAllCandidates.TabIndex = 8;
            // 
            // lstContestCandidates
            // 
            this.lstContestCandidates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstContestCandidates.FormattingEnabled = true;
            this.lstContestCandidates.Location = new System.Drawing.Point(190, 36);
            this.lstContestCandidates.Name = "lstContestCandidates";
            this.lstContestCandidates.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstContestCandidates.Size = new System.Drawing.Size(161, 225);
            this.lstContestCandidates.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(187, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Candidates*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Contests *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(388, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Available Candidates";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Custom Response (Referendum)";
            // 
            // pgCounties
            // 
            this.pgCounties.Controls.Add(this.dgvContestCounties);
            this.pgCounties.Controls.Add(this.dgvCounties);
            this.pgCounties.Controls.Add(this.label15);
            this.pgCounties.Controls.Add(this.btnAddAllCounties);
            this.pgCounties.Controls.Add(this.btnRemoveCounty);
            this.pgCounties.Controls.Add(this.btnRemoveAllCounties);
            this.pgCounties.Controls.Add(this.btnAddCounty);
            this.pgCounties.Controls.Add(this.label14);
            this.pgCounties.Controls.Add(this.lstContestCounty);
            this.pgCounties.Controls.Add(this.label16);
            this.pgCounties.Location = new System.Drawing.Point(4, 22);
            this.pgCounties.Name = "pgCounties";
            this.pgCounties.Padding = new System.Windows.Forms.Padding(3);
            this.pgCounties.Size = new System.Drawing.Size(579, 277);
            this.pgCounties.TabIndex = 3;
            this.pgCounties.Text = "Counties";
            this.pgCounties.UseVisualStyleBackColor = true;
            // 
            // dgvContestCounties
            // 
            this.dgvContestCounties.AllowUserToAddRows = false;
            this.dgvContestCounties.AllowUserToDeleteRows = false;
            this.dgvContestCounties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvContestCounties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContestCounties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvContestCounties.Location = new System.Drawing.Point(189, 33);
            this.dgvContestCounties.Name = "dgvContestCounties";
            this.dgvContestCounties.RowHeadersVisible = false;
            this.dgvContestCounties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContestCounties.Size = new System.Drawing.Size(172, 225);
            this.dgvContestCounties.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "County";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 78;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Ward Count";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // dgvCounties
            // 
            this.dgvCounties.AllowUserToAddRows = false;
            this.dgvCounties.AllowUserToDeleteRows = false;
            this.dgvCounties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCounties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCounties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCounty,
            this.dgvWardCount});
            this.dgvCounties.Location = new System.Drawing.Point(400, 33);
            this.dgvCounties.Name = "dgvCounties";
            this.dgvCounties.RowHeadersVisible = false;
            this.dgvCounties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCounties.Size = new System.Drawing.Size(171, 225);
            this.dgvCounties.TabIndex = 5;
            // 
            // dgvCounty
            // 
            this.dgvCounty.HeaderText = "County";
            this.dgvCounty.Name = "dgvCounty";
            this.dgvCounty.ReadOnly = true;
            this.dgvCounty.Width = 78;
            // 
            // dgvWardCount
            // 
            this.dgvWardCount.HeaderText = "Ward Count";
            this.dgvWardCount.Name = "dgvWardCount";
            this.dgvWardCount.ReadOnly = true;
            this.dgvWardCount.Width = 90;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(397, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Available Counties";
            // 
            // btnAddAllCounties
            // 
            this.btnAddAllCounties.Location = new System.Drawing.Point(367, 62);
            this.btnAddAllCounties.Name = "btnAddAllCounties";
            this.btnAddAllCounties.Size = new System.Drawing.Size(27, 22);
            this.btnAddAllCounties.TabIndex = 6;
            this.btnAddAllCounties.Text = "<<";
            this.btnAddAllCounties.UseVisualStyleBackColor = true;
            this.btnAddAllCounties.Click += new System.EventHandler(this.btnAddAllCounties_Click);
            // 
            // btnRemoveCounty
            // 
            this.btnRemoveCounty.Location = new System.Drawing.Point(367, 118);
            this.btnRemoveCounty.Name = "btnRemoveCounty";
            this.btnRemoveCounty.Size = new System.Drawing.Size(27, 22);
            this.btnRemoveCounty.TabIndex = 8;
            this.btnRemoveCounty.Text = ">";
            this.btnRemoveCounty.UseVisualStyleBackColor = true;
            this.btnRemoveCounty.Click += new System.EventHandler(this.btnRemoveCounty_Click);
            // 
            // btnRemoveAllCounties
            // 
            this.btnRemoveAllCounties.Location = new System.Drawing.Point(367, 146);
            this.btnRemoveAllCounties.Name = "btnRemoveAllCounties";
            this.btnRemoveAllCounties.Size = new System.Drawing.Size(27, 22);
            this.btnRemoveAllCounties.TabIndex = 9;
            this.btnRemoveAllCounties.Text = ">>";
            this.btnRemoveAllCounties.UseVisualStyleBackColor = true;
            this.btnRemoveAllCounties.Click += new System.EventHandler(this.btnRemoveAllCounties_Click);
            // 
            // btnAddCounty
            // 
            this.btnAddCounty.Location = new System.Drawing.Point(367, 90);
            this.btnAddCounty.Name = "btnAddCounty";
            this.btnAddCounty.Size = new System.Drawing.Size(27, 22);
            this.btnAddCounty.TabIndex = 7;
            this.btnAddCounty.Text = "<";
            this.btnAddCounty.UseVisualStyleBackColor = true;
            this.btnAddCounty.Click += new System.EventHandler(this.btnAddCounty_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(186, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Counties *";
            // 
            // lstContestCounty
            // 
            this.lstContestCounty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstContestCounty.FormattingEnabled = true;
            this.lstContestCounty.Location = new System.Drawing.Point(10, 33);
            this.lstContestCounty.Name = "lstContestCounty";
            this.lstContestCounty.Size = new System.Drawing.Size(163, 225);
            this.lstContestCounty.Sorted = true;
            this.lstContestCounty.TabIndex = 1;
            this.lstContestCounty.SelectedIndexChanged += new System.EventHandler(this.lstContestCounty_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Contests *";
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequired.ForeColor = System.Drawing.Color.Blue;
            this.lblRequired.Location = new System.Drawing.Point(12, 36);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(177, 16);
            this.lblRequired.TabIndex = 1;
            this.lblRequired.Text = "A * indicates a required field.";
            // 
            // frmElection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(607, 366);
            this.Controls.Add(this.tbDisplay);
            this.Controls.Add(this.lblRequired);
            this.MinimumSize = new System.Drawing.Size(615, 400);
            this.Name = "frmElection";
            this.Text = "Election";
            this.Controls.SetChildIndex(this.lblRequired, 0);
            this.Controls.SetChildIndex(this.tbDisplay, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tbDisplay.ResumeLayout(false);
            this.tabElection.ResumeLayout(false);
            this.tabElection.PerformLayout();
            this.tabContests.ResumeLayout(false);
            this.tabContests.PerformLayout();
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.pgCounties.ResumeLayout(false);
            this.pgCounties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContestCounties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCounties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox6;
        private System.Windows.Forms.ListBox listBox7;
        private System.Windows.Forms.ListBox listBox5;
        private System.Windows.Forms.TabControl tbDisplay;
        private System.Windows.Forms.TabPage tabElection;
        private System.Windows.Forms.TabPage tabContests;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddAllContests;
        private System.Windows.Forms.Button btnRemoveContest;
        private System.Windows.Forms.Button btnRemoveAllContests;
        private System.Windows.Forms.Button btnAddContest;
        private System.Windows.Forms.ListBox lstAllContests;
        private System.Windows.Forms.ListBox lstElectionContests;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lstContestCandidate;
        private System.Windows.Forms.ListBox lstAllCandidates;
        private System.Windows.Forms.ListBox lstContestCandidates;
        private System.Windows.Forms.Button btnAddAllCandidates;
        private System.Windows.Forms.Button btnRemoveCandidate;
        private System.Windows.Forms.Button btnRemoveAllCandidates;
        private System.Windows.Forms.Button btnAddCandidate;
        private System.Windows.Forms.TextBox txtCustomResponse;
        private System.Windows.Forms.Button btnAddCustomResponse;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Button btnResponseDown;
        protected System.Windows.Forms.Button btnResponseUp;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.TabPage pgCounties;
        private System.Windows.Forms.DataGridView dgvContestCounties;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dgvCounties;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCounty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvWardCount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAddAllCounties;
        private System.Windows.Forms.Button btnRemoveCounty;
        private System.Windows.Forms.Button btnRemoveAllCounties;
        private System.Windows.Forms.Button btnAddCounty;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox lstContestCounty;
        private System.Windows.Forms.Label label16;

    }
}