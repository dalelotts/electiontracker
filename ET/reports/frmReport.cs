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
using KnightRider.ElectionTracker.ui;
using KnightRider.ElectionTracker.ui.util;

namespace KnightRider.ElectionTracker.reports {
    internal sealed partial class frmReport : BaseMDIChild {
        private  IReport report;
        private int pageCount;
        private int bodyLineNumber;
        private List<String> groupHeader = new List<string>();
        private readonly Point previewControlLocation;
        private Boolean needToRefresh;
        private Margins margins = new Margins(50,50,50,50);

        public frmReport(IReport report) {
            InitializeComponent();
            toolStrip1.Visible = false;
            this.report = report;
            Text = report.Name();
            needToRefresh = false;
            previewControlLocation = new Point(190, 12);
            foreach (TreeViewFilter filter in report.Filters()) {
                cboFilter.Items.Add(filter);
            }
            if (cboFilter.Items.Count > 0) cboFilter.SelectedIndex = 0;
        }

        private void btnPrint_Click(object sender, EventArgs e) {
            try {
                ctlPrintDialog.AllowCurrentPage = false ;
                ctlPrintDialog.AllowSomePages = true;
                ctlPrintDialog.UseEXDialog = true;
                // The document on the print document needs to be set to the same document we just previewed
                ctlPrintDialog.Document = ctlPrintPreview.Document;
                DialogResult result = ctlPrintDialog.ShowDialog(this);
                if (DialogResult.OK.Equals(result)) {
                    pageCount = 0;

                    PrinterSettings settings = ctlPrintDialog.PrinterSettings;
                    needToRefresh = true;
                    ctlPrintDialog.Document.PrinterSettings = settings;
                    // set the margins on the printing document to those out of the page setup dialog
                    ctlPrintDialog.Document.DefaultPageSettings.Margins = margins;
                    ctlPrintDialog.Document.Print();
                }
            } catch (Exception ex) {
                reportException("btnPrint_Click", ex);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e) {
            try {
                if (ctlPrintPreview.StartPage > 0) {
                    ctlPrintPreview.StartPage--;
                }
            } catch (Exception ex) {
                reportException("btnPrevious_Click", ex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e) {
            try {
                if (ctlPrintPreview.StartPage < pageCount) {
                    ctlPrintPreview.StartPage++;
                }
            } catch (Exception ex) {
                reportException("btnNext_Click", ex);
            }
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                ctlTreeView.Nodes.Clear();
                ((TreeViewFilter) cboFilter.SelectedItem).apply(ctlTreeView.Nodes);
            } catch (Exception ex) {
                reportException("cboFilter_SelectedIndexChanged", ex);
            }
        }

        private void ctlTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                TreeNode node = ctlTreeView.SelectedNode;
                if (node == null) return;
                displayReport(node);
            } catch (Exception ex) {
                reportException("tvElections_AfterSelect", ex);
            }
        }

        private void displayReport(TreeNode node) {
            pageCount = 0;
            report.Reset();
            report.NodeSelected(node);
            report.Generate();

            PrintDocument document = new PrintDocument();
            
            document.DefaultPageSettings.Margins = margins;
            ctlPageSetup.Document = document;
            ctlPageSetup.PageSettings.Margins = margins;

            document.PrintPage += new PrintPageEventHandler(PrintPageHandler);
            document.DefaultPageSettings.Landscape = report.IsLandscape();
            document.DocumentName = report.Name();
            document.EndPrint += new PrintEventHandler(endPrint);

            // Add document to print preview control.  Print preview is the report pane on the form window
            //ctlPrintPreview.Document = document;
       
            refreshReport(document);
        }

        private void refreshReport(PrintDocument document) {
            Controls.Remove(ctlPrintPreview);
            
            ctlPrintPreview = new PrintPreviewControl();
            ctlPrintPreview.Location = previewControlLocation;
            ctlPrintPreview.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
            ctlPrintPreview.Size = new Size(Width - ctlPrintPreview.Location.X - 12, Height - 78);
            ctlPrintPreview.TabIndex = 8;
            ctlPrintPreview.UseAntiAlias = true;
            ctlPrintPreview.Document = document;
            Controls.Add(ctlPrintPreview);
        }

        private void endPrint(object sender, PrintEventArgs e) {
            btnPrint.Enabled = true;
            btnPageSetup.Enabled = true;
            btnZoomIn.Enabled = true;
            btnZoomOut.Enabled = true;
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            if (needToRefresh)
            {
                needToRefresh = false;
                ctlPrintPreview.Document.PrinterSettings = new PrinterSettings();
                ctlPrintPreview.Document.PrinterSettings.PrintRange = PrintRange.AllPages;
                ctlPrintPreview.Document.DefaultPageSettings.Landscape = report.IsLandscape();
                // creating the new printer settings reset our margins, we need to put them back
                ctlPrintPreview.Document.PrinterSettings.DefaultPageSettings.Margins = margins;
                refreshReport(ctlPrintPreview.Document );
                
            }
        }


        private void PrintPageHandler(object sender, PrintPageEventArgs ev) {
            //check to see if there are from and to pages selected

            
            if (ev.PageSettings.PrinterSettings.PrintRange.Equals(PrintRange.SomePages))
            {
                if (pageCount + 1 < ev.PageSettings.PrinterSettings.FromPage && pageCount + 1 < ev.PageSettings.PrinterSettings.ToPage)
                {
                    //increment to get to the page we need to print
                    while (pageCount + 1 < ev.PageSettings.PrinterSettings.FromPage)
                    {
                        float leftMargin = ev.MarginBounds.Left;
                        float topMargin = ev.MarginBounds.Top;

                        // Calculate the number of lines per page.
                        Font printFont = report.Font();
                        float fontHeight = printFont.GetHeight(ev.Graphics);
                        int bottomMargin = ev.MarginBounds.Height;

                        // reserve space for the footer.

                        List<string> footer = report.Footer();
                        bottomMargin -= (int)(footer.Count * fontHeight);

                        int lineNumber = 0;
                        float yPos = GetYPos(topMargin, lineNumber, fontHeight);

                        // Print the header.
                        foreach (string line in report.Header())
                        {
                            lineNumber++;
                            yPos = GetYPos(topMargin, lineNumber, fontHeight);
                        }


                        // Print the group header if there is one.
                        foreach (string line in groupHeader)
                        {
                            lineNumber++;
                            yPos = GetYPos(topMargin, lineNumber, fontHeight);
                        }

                        // Print the body of the report, keeping track of the line number 
                        // just in case there is a page break somewhere in the body.

                        List<string> bodyLines = report.Body();
                        //while (bodyLineNumber < bodyLines.Count && ((availableLines - lineNumber) > 0)) {
                        while (bodyLineNumber < bodyLines.Count && ((yPos + fontHeight) <= bottomMargin))
                        {
                            string line = bodyLines[bodyLineNumber];
                            bodyLineNumber++;

                            if (line.Length == 0)
                            {
                                lineNumber++; // Nothing to do, just increment the line number and loop again.
                                yPos = GetYPos(topMargin, lineNumber, fontHeight);
                                continue;
                            }

                            if ("<PAGE_BREAK/>".Equals(line))
                            {
                                break;
                            }
                            else if ("<KEEP_TOGETHER>".Equals(line))
                            {
                                // Ignore keep together as the first tag in the body of the page
                                if (lineNumber > report.Header().Count)
                                {
                                    // Look ahead to see if there is enough room on the page to fit 
                                    // the lines to keep togehter.
                                    // NOTE: This does not support nested keep together tags.
                                    int keepTogetherLines = linesToTag("</KEEP_TOGETHER>", bodyLines, bodyLineNumber);
                                    float tmpYPos = GetYPos(topMargin, lineNumber + keepTogetherLines, fontHeight);
                                    if (tmpYPos > bottomMargin)
                                    {
                                        break; // There are not enough lines remianing on the page so move to the next page.
                                    }
                                }
                                continue; // always skip the rest of this loop when encountering this tag
                            }
                            else if ("</KEEP_TOGETHER>".Equals(line))
                            {
                                continue; // always skip the rest of this loop when encountering this tag
                            }
                            else if ("<GROUP>".Equals(line))
                            {
                                continue;
                            }
                            else if ("</GROUP>".Equals(line))
                            {
                                groupHeader.Clear();
                                continue;
                            }
                            else if ("<GROUP_HEADER>".Equals(line))
                            {
                                fillGroupHeader("</GROUP_HEADER>", bodyLines, bodyLineNumber);
                                continue;
                            }
                            else if ("</GROUP_HEADER>".Equals(line))
                            {
                                continue;
                            }

                            lineNumber++;
                            yPos = GetYPos(topMargin, lineNumber, fontHeight);
                        }
                        pageCount++;
                    }
                }

            }

            if ((ev.PageSettings.PrinterSettings.PrintRange.Equals(PrintRange.SomePages) && pageCount + 1 <= ev.PageSettings.PrinterSettings.ToPage) || ev.PageSettings.PrinterSettings.PrintRange.Equals(PrintRange.AllPages))
            {
                //print page
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;

                // Calculate the number of lines per page.
                Font printFont = report.Font();
                float fontHeight = printFont.GetHeight(ev.Graphics);
                int bottomMargin = ev.MarginBounds.Height;

                // reserve space for the footer.

                List<string> footer = report.Footer();
                bottomMargin -= (int)(footer.Count * fontHeight);

                int lineNumber = 0;
                float yPos = GetYPos(topMargin, lineNumber, fontHeight);

                // Print the header.
                foreach (string line in report.Header())
                {
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                    lineNumber++;
                    yPos = GetYPos(topMargin, lineNumber, fontHeight);
                }


                // Print the group header if there is one.
                foreach (string line in groupHeader)
                {
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                    lineNumber++;
                    yPos = GetYPos(topMargin, lineNumber, fontHeight);
                }

                // Print the body of the report, keeping track of the line number 
                // just in case there is a page break somewhere in the body.

                List<string> bodyLines = report.Body();

                //while (bodyLineNumber < bodyLines.Count && ((availableLines - lineNumber) > 0)) {
                while (bodyLineNumber < bodyLines.Count && ((yPos + fontHeight) <= bottomMargin))
                {
                    string line = bodyLines[bodyLineNumber];
                    bodyLineNumber++;

                    if (line.Length == 0)
                    {
                        lineNumber++; // Nothing to do, just increment the line number and loop again.
                        yPos = GetYPos(topMargin, lineNumber, fontHeight);
                        continue;
                    }

                    if ("<PAGE_BREAK/>".Equals(line))
                    {
                        break;
                    }
                    else if ("<KEEP_TOGETHER>".Equals(line))
                    {
                        // Ignore keep together as the first tag in the body of the page
                        if (lineNumber > report.Header().Count)
                        {
                            // Look ahead to see if there is enough room on the page to fit 
                            // the lines to keep togehter.
                            // NOTE: This does not support nested keep together tags.
                            int keepTogetherLines = linesToTag("</KEEP_TOGETHER>", bodyLines, bodyLineNumber);
                            float tmpYPos = GetYPos(topMargin, lineNumber + keepTogetherLines, fontHeight);
                            if (tmpYPos > bottomMargin)
                            {
                                break; // There are not enough lines remianing on the page so move to the next page.
                            }
                        }
                        continue; // always skip the rest of this loop when encountering this tag
                    }
                    else if ("</KEEP_TOGETHER>".Equals(line))
                    {
                        continue; // always skip the rest of this loop when encountering this tag
                    }
                    else if ("<GROUP>".Equals(line))
                    {
                        continue;
                    }
                    else if ("</GROUP>".Equals(line))
                    {
                        groupHeader.Clear();
                        continue;
                    }
                    else if ("<GROUP_HEADER>".Equals(line))
                    {
                        fillGroupHeader("</GROUP_HEADER>", bodyLines, bodyLineNumber);
                        continue;
                    }
                    else if ("</GROUP_HEADER>".Equals(line))
                    {
                        continue;
                    }

                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                    lineNumber++;
                    yPos = GetYPos(topMargin, lineNumber, fontHeight);
                }

                // Reset the bottom margin so it no longer reserves space for the footer.
                bottomMargin = ev.MarginBounds.Height;

                string pageString = (pageCount + 1).ToString();
                // Print the footer at the bottom of the page.
                for (int i = footer.Count - 1, j = 1; i >= 0; i--, j++)
                {
                    yPos = bottomMargin - (j * fontHeight);
                    string line = footer[i];
                    line = line.Replace("${Page}", pageString);
                    ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                }
                if (bodyLines.Count > bodyLineNumber)
                {
                    ev.HasMorePages = true;
                    pageCount++;
                }
                else
                {
                    bodyLineNumber = 0;
                }
                if (pageCount == ev.PageSettings.PrinterSettings.ToPage)
                {
                    pageCount = 0;
                    bodyLineNumber = 0;
                    ev.HasMorePages = false;
                }
            }
            else
            {
                ev.HasMorePages = false;
                bodyLineNumber = 0;
                pageCount = 0;
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
            try {
                ctlPrintPreview.Zoom += .1;
            } catch (Exception ex) {
                reportException("btnZoomIn_Click", ex);
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e) {
            try {
                if (ctlPrintPreview.Zoom >= .1) ctlPrintPreview.Zoom -= .1;
            } catch (Exception ex) {
                reportException("btnZoomOut_Click", ex);
            }
        }

        private void btnPageSetup_Click(object sender, EventArgs e) {
            try {
                PrintDocument document = ctlPrintPreview.Document;
                ctlPageSetup.Document = document;
                DialogResult result = ctlPageSetup.ShowDialog(this);
                if (DialogResult.OK.Equals(result)) {
                    document.DefaultPageSettings = ctlPageSetup.PageSettings;
                    // Update the document with the newly entered margins
                    margins = ctlPageSetup.PageSettings.Margins;
                    document.DefaultPageSettings.Margins = margins;
                    refreshReport(document);

                }
            } catch (Exception ex) {
                reportException("btnPageSetup_Click", ex);
            }
        }
    }
}