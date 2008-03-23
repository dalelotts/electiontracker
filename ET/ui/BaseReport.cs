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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;
using KnightRider.ElectionTracker.db.task;
using KnightRider.ElectionTracker.ui.util;

namespace KnightRider.ElectionTracker.ui {
    internal partial class BaseReport : Form {
        protected readonly IElectionDAO electionDAO;
        protected readonly IDAOTask<Election> loadTask;
        private readonly bool isLandscape;
        protected int intPages;
        protected Font printFont;

        protected BaseReport(IElectionDAO electionDAO, IDAOTask<Election> loadTask, IList<TreeViewFilter> filters, bool isLandscape) {
            InitializeComponent();
            this.electionDAO = electionDAO;
            this.loadTask = loadTask;
            this.isLandscape = isLandscape;

            printFont = new Font("Courier New", 10);

            foreach (TreeViewFilter filter in filters) {
                cboFilter.Items.Add(filter);
            }

            if (cboFilter.Items.Count > 0) cboFilter.SelectedIndex = 0;
            displayDocument(null);
        }

        private int GetMarginSpot()
        {
            if (isLandscape) {
                return 105;
            } else {
                return 75;
            }
        }


        protected string CenterText(string text) {
            return CenterText(text, ' ');
        }

        protected static string FormatTextLength(string text, int length, bool padRight) {
            int textLength = text.Length;
            string result = text;
            if (textLength > length) {
                result = text.Substring(0, length);
            } else {
                while (result.Length < length) {
                    if (padRight) {
                        result = result + " ";
                    } else {
                        result = " " + result;
                    }
                }
            }
            return result;
        }

        protected static string FormatTextLength(string text, int length) {
            return FormatTextLength(text, length, true);
        }

        protected string CenterText(string text, char space) {
            int length = text.Length;
            for (int i = 0; i <= ((GetMarginSpot() - length) / 2); i++) {
                text = "" + space + text + space;
            }
            return text;
        }

        protected string AlignRight(string text) {
            int length = text.Length;
            for (int i = 0; i <= ((GetMarginSpot() - length)); i++) {
                text = " " + text;
            }
            return text;
        }

        protected void btnPrint_Click(object sender, EventArgs e) {
            intPages = 0;
            ppcElection.Document.Print();
        }

        protected void btnUp_Click(object sender, EventArgs e) {
            if (ppcElection.StartPage > 0) {
                ppcElection.StartPage--;
            }
        }

        protected void btnDown_Click(object sender, EventArgs e) {
            if (ppcElection.StartPage < intPages) {
                ppcElection.StartPage++;
            }
        }


        protected virtual PrintDocument CreateDocumnt(Election election) {
            // No Op
            return null;
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e) {
            tvElections.Nodes.Clear();
            ((TreeViewFilter) cboFilter.SelectedItem).apply(tvElections.Nodes);
        }

        private void tvElections_AfterSelect(object sender, TreeViewEventArgs e) {
            TreeNode node = tvElections.SelectedNode;
            if (node == null) return;
            string[] entityID = node.Name.Split('=');
            if (entityID.Length == 2) {
                long id = long.Parse(entityID[1]);
                Election election = electionDAO.findById(id, false, loadTask);
                PrintDocument document = CreateDocumnt(election);
                displayDocument(document);
            }
        }

        protected void displayDocument(PrintDocument document) {
            Controls.Remove(ppcElection);

            ppcElection = new PrintPreviewControl();
            ppcElection.Location = new Point(190, 12);
            ppcElection.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
            ppcElection.Size = new Size(Width - 206, Height - 78);
            ppcElection.TabIndex = 8;
            ppcElection.UseAntiAlias = true;
            ppcElection.Document = document;

            Controls.Add(ppcElection);
        }

        private void btnZoomIn_Click(object sender, EventArgs e) {
            ppcElection.Zoom += .1;
        }

        private void btnZoomOut_Click(object sender, EventArgs e) {
            ppcElection.Zoom -= .1;
        }
    }
}