/**
 *  Copyright (C) 2008 Knight Rider Consulting, Inc.
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

namespace KnightRider.ElectionTracker.reports {
    internal sealed partial class frmReport : Form {
        private readonly IElectionDAO electionDAO;
        private readonly IDAOTask<Election> loadTask;
        private readonly IReport<Election> report;
        private int pageCount;
        private int bodyLineNumber;
        private List<String> groupHeader = new List<string>();

        public frmReport(IElectionDAO electionDAO, IDAOTask<Election> loadTask, IList<TreeViewFilter> filters, IReport<Election> report) {
            InitializeComponent();
            this.electionDAO = electionDAO;
            this.loadTask = loadTask;
            this.report = report;
            Text = report.Name();

            foreach (TreeViewFilter filter in filters) {
                cboFilter.Items.Add(filter);
            }

            if (cboFilter.Items.Count > 0) cboFilter.SelectedIndex = 0;
        }

        private void btnPrint_Click(object sender, EventArgs e) {
            pageCount = 0;
            DialogResult result = ctlPrintDialog.ShowDialog(this);
            if (DialogResult.OK.Equals(result)) {
                ppcElection.Document.PrinterSettings = ctlPrintDialog.PrinterSettings;
                ppcElection.Document.Print();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e) {
            if (ppcElection.StartPage > 0) {
                ppcElection.StartPage--;
            }
        }

        private void btnNext_Click(object sender, EventArgs e) {
            if (ppcElection.StartPage < pageCount) {
                ppcElection.StartPage++;
            }
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
                displayReport(election);
            }
        }

        private void displayReport(Election election) {
            pageCount = 0;
            report.Reset();
            report.Generate(election);

            PrintDocument document = new PrintDocument();
            document.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
            document.PrintPage += new PrintPageEventHandler(PrintPageHandler);
            document.DefaultPageSettings.Landscape = report.IsLandscape();
            document.DocumentName = report.Name();
            document.EndPrint += new PrintEventHandler(endPrint);

            refreshReport(document);
        }

        private void refreshReport(PrintDocument document) {
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

        private void endPrint(object sender, PrintEventArgs e) {
            btnPrint.Enabled = true;
            btnPageSetup.Enabled = true;
            btnZoomIn.Enabled = true;
            btnZoomOut.Enabled = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
        }


        private void PrintPageHandler(object sender, PrintPageEventArgs ev) {
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;

            // Calculate the number of lines per page.
            Font printFont = report.Font();
            float fontHeight = printFont.GetHeight(ev.Graphics);
            int bottomMargin = ev.MarginBounds.Height;

            // reserve space for the footer.

            List<string> footer = report.Footer();
            bottomMargin -= (int) (footer.Count * fontHeight);

            int lineNumber = 0;
            float yPos = GetYPos(topMargin, lineNumber, fontHeight);

            // Print the header.
            foreach (string line in report.Header()) {
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                lineNumber++;
                yPos = GetYPos(topMargin, lineNumber, fontHeight);
            }


            // Print the group header if there is one.
            foreach (string line in groupHeader) {
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                lineNumber++;
                yPos = GetYPos(topMargin, lineNumber, fontHeight);
            }

            // Print the body of the report, keeping track of the line number 
            // just in case there is a page break somewhere in the body.
            List<string> bodyLines = report.Body();

            //while (bodyLineNumber < bodyLines.Count && ((availableLines - lineNumber) > 0)) {
            while (bodyLineNumber < bodyLines.Count && ((yPos + fontHeight) <= bottomMargin)) {
                string line = bodyLines[bodyLineNumber];
                bodyLineNumber++;

                if (line.Length == 0) {
                    lineNumber++;  // Nothing to do, just increment the line number and loop again.
                    yPos = GetYPos(topMargin, lineNumber, fontHeight);
                    continue;
                }
                
                if ("<PAGE_BREAK/>".Equals(line)) {
                    break;
                } else if ("<KEEP_TOGETHER>".Equals(line)) {
                    // Ignore keep together as the first tag in the body of the page
                    if (lineNumber > report.Header().Count) {
                        // Look ahead to see if there is enough room on the page to fit 
                        // the lines to keep togehter.
                        // NOTE: This does not support nested keep together tags.
                        int keepTogetherLines = linesToTag("</KEEP_TOGETHER>", bodyLines, bodyLineNumber);
                        float tmpYPos = GetYPos(topMargin, lineNumber + keepTogetherLines, fontHeight);
                        if (tmpYPos > bottomMargin) {
                            break; // There are not enough lines remianing on the page so move to the next page.
                        }
                    }
                    continue; // always skip the rest of this loop when encountering this tag
                } else if ("</KEEP_TOGETHER>".Equals(line)) {
                    continue; // always skip the rest of this loop when encountering this tag
                } else if ("<GROUP>".Equals(line)) {
                    continue;
                } else if ("</GROUP>".Equals(line)) {
                    groupHeader.Clear();
                    continue;
                } else if ("<GROUP_HEADER>".Equals(line)) {
                    fillGroupHeader("</GROUP_HEADER>", bodyLines, bodyLineNumber);
                    continue;
                } else if ("</GROUP_HEADER>".Equals(line)) {
                    continue;
                }

                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                lineNumber++;
                yPos = GetYPos(topMargin, lineNumber, fontHeight);
            }

            // Reset the bottom margin so it no longer reserves space for the footer.
            bottomMargin = ev.MarginBounds.Height;

            // Print the footer at the bottom of the page.
            for (int i = footer.Count - 1, j = 1; i >= 0; i--, j++) {
                yPos = bottomMargin - (j * fontHeight);
                string line = footer[i];
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
            }

            if (bodyLines.Count > bodyLineNumber) {
                ev.HasMorePages = true;
                pageCount++;
            } else {
                bodyLineNumber = 0;
            }
        }

        private void fillGroupHeader(string tag, List<string> lines, int lineNumber) {
            groupHeader.Clear();
            for (int i = lineNumber; i < lines.Count; i++) {
                string line = lines[i];
                if (tag.Equals(line)) {
                    break;
                } else {
                    groupHeader.Add(line);
                }
            }
        }

        private static int linesToTag(string tag, List<string> lines, int startLineNumber) {
            for (int i = startLineNumber, limit = lines.Count; i < limit; i++) {
                string line = lines[i];
                if (tag.Equals(line)) {
                    return i - startLineNumber;
                }
            }
            return lines.Count - startLineNumber;
        }


        private static float GetYPos(float topMargin, int lineNumber, float fontHeight) {
            return topMargin + (lineNumber * fontHeight);
        }

        private void btnZoomIn_Click(object sender, EventArgs e) {
            ppcElection.Zoom += .1;
        }

        private void btnZoomOut_Click(object sender, EventArgs e) {
            ppcElection.Zoom -= .1;
        }

        private void btnPageSetup_Click(object sender, EventArgs e) {
            PrintDocument document = ppcElection.Document;
            ctlPageSetup.Document = document;
            DialogResult result = ctlPageSetup.ShowDialog(this);
            if (DialogResult.OK.Equals(result)) {
                document.DefaultPageSettings = ctlPageSetup.PageSettings;
                refreshReport(document);
            }
        }
    }
}