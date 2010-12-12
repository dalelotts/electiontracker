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
using System;

namespace KnightRider.ElectionTracker.ui
{
    sealed internal partial class MDIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIForm));
            Altea.OutlookBarButton outlookBarButton50 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton51 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton52 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton53 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton54 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton55 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton56 = new Altea.OutlookBarButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerOptionsToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.politicalPartyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voteResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countyContactFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contestVoteSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proofingSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electionQuickScanSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voteCountyTallySheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.filterBar = new Altea.OutlookBar();
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.hlpElectionTracker = new System.Windows.Forms.HelpProvider();
            this.mainMenuStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 744);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1190, 22);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mainMenuStrip.Size = new System.Drawing.Size(1190, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.ServerOptionsToolStrip,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Visible = false;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Visible = false;
            // 
            // ServerOptionsToolStrip
            // 
            this.ServerOptionsToolStrip.Name = "ServerOptionsToolStrip";
            this.ServerOptionsToolStrip.Size = new System.Drawing.Size(157, 22);
            this.ServerOptionsToolStrip.Text = "Server Options";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(154, 6);
            this.toolStripSeparator.Visible = false;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Visible = false;
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Visible = false;
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.candidateToolStripMenuItem,
            this.contestToolStripMenuItem,
            this.countyToolStripMenuItem,
            this.electionToolStripMenuItem,
            this.politicalPartyToolStripMenuItem,
            this.voteResultsToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "&Insert";
            // 
            // candidateToolStripMenuItem
            // 
            this.candidateToolStripMenuItem.Name = "candidateToolStripMenuItem";
            this.candidateToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.candidateToolStripMenuItem.Text = "C&andidate";
            // 
            // contestToolStripMenuItem
            // 
            this.contestToolStripMenuItem.Name = "contestToolStripMenuItem";
            this.contestToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.contestToolStripMenuItem.Text = "&Contest";
            // 
            // countyToolStripMenuItem
            // 
            this.countyToolStripMenuItem.Name = "countyToolStripMenuItem";
            this.countyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.countyToolStripMenuItem.Text = "C&ounty";
            // 
            // electionToolStripMenuItem
            // 
            this.electionToolStripMenuItem.Name = "electionToolStripMenuItem";
            this.electionToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.electionToolStripMenuItem.Text = "&Election";
            // 
            // politicalPartyToolStripMenuItem
            // 
            this.politicalPartyToolStripMenuItem.Name = "politicalPartyToolStripMenuItem";
            this.politicalPartyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.politicalPartyToolStripMenuItem.Text = "&Political Party";
            // 
            // voteResultsToolStripMenuItem
            // 
            this.voteResultsToolStripMenuItem.Name = "voteResultsToolStripMenuItem";
            this.voteResultsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.voteResultsToolStripMenuItem.Text = "&Vote Results";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countyContactFormToolStripMenuItem,
            this.contestVoteSummaryToolStripMenuItem,
            this.proofingSheetToolStripMenuItem,
            this.electionQuickScanSheetToolStripMenuItem,
            this.voteCountyTallySheetToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // countyContactFormToolStripMenuItem
            // 
            this.countyContactFormToolStripMenuItem.Name = "countyContactFormToolStripMenuItem";
            this.countyContactFormToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.countyContactFormToolStripMenuItem.Text = "County Contact Listing";
            // 
            // contestVoteSummaryToolStripMenuItem
            // 
            this.contestVoteSummaryToolStripMenuItem.Name = "contestVoteSummaryToolStripMenuItem";
            this.contestVoteSummaryToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.contestVoteSummaryToolStripMenuItem.Text = "Contest Vote Summary";
            // 
            // proofingSheetToolStripMenuItem
            // 
            this.proofingSheetToolStripMenuItem.Name = "proofingSheetToolStripMenuItem";
            this.proofingSheetToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.proofingSheetToolStripMenuItem.Text = "Election Proofing Sheet";
            // 
            // electionQuickScanSheetToolStripMenuItem
            // 
            this.electionQuickScanSheetToolStripMenuItem.Name = "electionQuickScanSheetToolStripMenuItem";
            this.electionQuickScanSheetToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.electionQuickScanSheetToolStripMenuItem.Text = "Election Quick Scan Sheet";
            // 
            // voteCountyTallySheetToolStripMenuItem
            // 
            this.voteCountyTallySheetToolStripMenuItem.Name = "voteCountyTallySheetToolStripMenuItem";
            this.voteCountyTallySheetToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.voteCountyTallySheetToolStripMenuItem.Text = "Vote County Tally Sheet";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem1.Text = "&Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.filterBar);
            this.mainPanel.Controls.Add(this.mainTreeView);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mainPanel.Location = new System.Drawing.Point(0, 24);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(232, 720);
            this.mainPanel.TabIndex = 0;
            // 
            // filterBar
            // 
            outlookBarButton50.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton50.Image")));
            outlookBarButton50.Text = "Elections";
            outlookBarButton51.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton51.Image")));
            outlookBarButton51.Text = "Contests";
            outlookBarButton52.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton52.Image")));
            outlookBarButton52.Text = "Candidates";
            outlookBarButton53.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton53.Image")));
            outlookBarButton53.Text = "Counties";
            outlookBarButton54.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton54.Image")));
            outlookBarButton54.Text = "Political Parties";
            outlookBarButton55.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton55.Image")));
            outlookBarButton55.Text = "Enter Votes";
            outlookBarButton56.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton56.Image")));
            outlookBarButton56.Text = "Reports";
            this.filterBar.Buttons.Add(outlookBarButton50);
            this.filterBar.Buttons.Add(outlookBarButton51);
            this.filterBar.Buttons.Add(outlookBarButton52);
            this.filterBar.Buttons.Add(outlookBarButton53);
            this.filterBar.Buttons.Add(outlookBarButton54);
            this.filterBar.Buttons.Add(outlookBarButton55);
            this.filterBar.Buttons.Add(outlookBarButton56);
            this.filterBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filterBar.Location = new System.Drawing.Point(0, 456);
            this.filterBar.MinimumSize = new System.Drawing.Size(16, 40);
            this.filterBar.Name = "filterBar";
            this.filterBar.Renderer = Altea.Renderer.Outlook2007;
            this.filterBar.Size = new System.Drawing.Size(232, 264);
            this.filterBar.TabIndex = 1;
            this.filterBar.Text = "outlookBar1";
            this.filterBar.Move += new System.EventHandler(this.resizeHandler);
            this.filterBar.ButtonClicked += new Altea.OutlookBar.ButtonClickedEventHandler(this.filterBar_ButtonClicked);
            // 
            // mainTreeView
            // 
            this.mainTreeView.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainTreeView.HideSelection = false;
            this.mainTreeView.HotTracking = true;
            this.mainTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainTreeView.Name = "mainTreeView";
            this.mainTreeView.ShowNodeToolTips = true;
            this.mainTreeView.Size = new System.Drawing.Size(232, 243);
            this.mainTreeView.TabIndex = 0;
            this.mainTreeView.DoubleClick += new System.EventHandler(this.mainTreeView_DoubleClick);
            // 
            // hlpElectionTracker
            // 
            this.hlpElectionTracker.HelpNamespace = "ElectionTracker.chm";
            // 
            // MDIForm
            // 
            this.ClientSize = new System.Drawing.Size(1190, 766);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Election Tracker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MDIForm_Shown);
            this.Resize += new System.EventHandler(this.resizeHandler);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem candidateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem politicalPartyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voteResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voteCountyTallySheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proofingSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contestVoteSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countyContactFormToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private Altea.OutlookBar filterBar;
        private System.Windows.Forms.TreeView mainTreeView;
        private System.Windows.Forms.ToolStripMenuItem electionQuickScanSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServerOptionsToolStrip;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        public System.Windows.Forms.HelpProvider hlpElectionTracker;

    }
}