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
            Altea.OutlookBarButton outlookBarButton8 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton9 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton10 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton11 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton12 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton13 = new Altea.OutlookBarButton();
            Altea.OutlookBarButton outlookBarButton14 = new Altea.OutlookBarButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.politicalPartyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voteResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proofingSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contestVoteSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countyContactFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.filterBar = new Altea.OutlookBar();
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.mainStatusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 744);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1190, 22);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "ready...";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.MdiWindowListItem = this.windowToolStripMenuItem;
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(148, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(147, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(147, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.electionToolStripMenuItem,
            this.contestToolStripMenuItem,
            this.candidateToolStripMenuItem,
            this.politicalPartyToolStripMenuItem,
            this.countyToolStripMenuItem,
            this.voteResultsToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "&Insert";
            // 
            // electionToolStripMenuItem
            // 
            this.electionToolStripMenuItem.Name = "electionToolStripMenuItem";
            this.electionToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.electionToolStripMenuItem.Text = "&Election";
            // 
            // contestToolStripMenuItem
            // 
            this.contestToolStripMenuItem.Name = "contestToolStripMenuItem";
            this.contestToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.contestToolStripMenuItem.Text = "&Contest";
            // 
            // candidateToolStripMenuItem
            // 
            this.candidateToolStripMenuItem.Name = "candidateToolStripMenuItem";
            this.candidateToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.candidateToolStripMenuItem.Text = "C&andidate";
            // 
            // politicalPartyToolStripMenuItem
            // 
            this.politicalPartyToolStripMenuItem.Name = "politicalPartyToolStripMenuItem";
            this.politicalPartyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.politicalPartyToolStripMenuItem.Text = "&Political Party";
            // 
            // countyToolStripMenuItem
            // 
            this.countyToolStripMenuItem.Name = "countyToolStripMenuItem";
            this.countyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.countyToolStripMenuItem.Text = "C&ounty";
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
            this.electionReportToolStripMenuItem,
            this.proofingSheetToolStripMenuItem,
            this.contestVoteSummaryToolStripMenuItem,
            this.countyContactFormToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.reportsToolStripMenuItem.Text = "&Reports";
            // 
            // electionReportToolStripMenuItem
            // 
            this.electionReportToolStripMenuItem.Name = "electionReportToolStripMenuItem";
            this.electionReportToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.electionReportToolStripMenuItem.Text = "Vote County Tally Sheet";
            // 
            // proofingSheetToolStripMenuItem
            // 
            this.proofingSheetToolStripMenuItem.Name = "proofingSheetToolStripMenuItem";
            this.proofingSheetToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.proofingSheetToolStripMenuItem.Text = "Proofing Sheet";
            // 
            // contestVoteSummaryToolStripMenuItem
            // 
            this.contestVoteSummaryToolStripMenuItem.Name = "contestVoteSummaryToolStripMenuItem";
            this.contestVoteSummaryToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.contestVoteSummaryToolStripMenuItem.Text = "Contest Vote Summary";
            // 
            // countyContactFormToolStripMenuItem
            // 
            this.countyContactFormToolStripMenuItem.Name = "countyContactFormToolStripMenuItem";
            this.countyContactFormToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.countyContactFormToolStripMenuItem.Text = "County Contact Listing";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
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
            outlookBarButton8.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton8.Image")));
            outlookBarButton8.Text = "Elections";
            outlookBarButton9.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton9.Image")));
            outlookBarButton9.Text = "Contests";
            outlookBarButton10.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton10.Image")));
            outlookBarButton10.Text = "Candidates";
            outlookBarButton11.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton11.Image")));
            outlookBarButton11.Text = "Counties";
            outlookBarButton12.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton12.Image")));
            outlookBarButton12.Text = "Political Parties";
            outlookBarButton13.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton13.Image")));
            outlookBarButton13.Text = "Enter Votes";
            outlookBarButton14.Image = ((System.Drawing.Icon)(resources.GetObject("outlookBarButton14.Image")));
            outlookBarButton14.Text = "Reports";
            this.filterBar.Buttons.Add(outlookBarButton8);
            this.filterBar.Buttons.Add(outlookBarButton9);
            this.filterBar.Buttons.Add(outlookBarButton10);
            this.filterBar.Buttons.Add(outlookBarButton11);
            this.filterBar.Buttons.Add(outlookBarButton12);
            this.filterBar.Buttons.Add(outlookBarButton13);
            this.filterBar.Buttons.Add(outlookBarButton14);
            this.filterBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filterBar.Location = new System.Drawing.Point(0, 552);
            this.filterBar.MinimumSize = new System.Drawing.Size(16, 40);
            this.filterBar.Name = "filterBar";
            this.filterBar.Renderer = Altea.Renderer.Outlook2007;
            this.filterBar.Size = new System.Drawing.Size(232, 168);
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
            // MDIForm
            // 
            this.ClientSize = new System.Drawing.Size(1190, 766);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Election Tracker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MDIForm_Shown);
            this.Resize += new System.EventHandler(this.resizeHandler);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
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
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem candidateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem politicalPartyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voteResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem electionReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proofingSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contestVoteSummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem countyContactFormToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private Altea.OutlookBar filterBar;
        private System.Windows.Forms.TreeView mainTreeView;

    }
}