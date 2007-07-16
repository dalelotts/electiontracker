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
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.util;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal class frmContestVoteSumry : frmAbstractReport {
        private int intCount;
        private IList<string> lstHeader;
        private IList<string> lstToPrint;
        private ComboBox cmbElectionType;

        public frmContestVoteSumry(ElectionDAO electionDAO) : base(electionDAO) {
            blnLandscape = true;
            InitializeElectionType();
        }

        protected override IList<Election> GetElections() {
            if (cmbElectionType.SelectedIndex == 1)
                return electionDAO.findInactive();
            else
                return electionDAO.findActive();
        }

        protected override string GetTitle() {
            return "Vote Counts";
        }

        private static int GetVoteTotals(ElectionContest ec, Response r) {
            int total = 0;
            foreach (ContestCounty cc in ec.Counties) {
                foreach (ResponseValue rv in cc.ResponseValues) {
                    if (rv.Response == r) {
                        total += rv.VoteCount;
                    }
                }
            }
            return total;
        }

        private static string GetVoteNumbers(Response r, ContestCounty cc, string noResponseValue) {
            ResponseValue res = null;
            foreach (ResponseValue rv in cc.ResponseValues) {
                if (rv.Response.ID == r.ID) {
                    res = rv;
                    break;
                }
            }
            if (res == null) {
                return noResponseValue;
            } else {
                return
                    FormatTextLength(res.VoteCount.ToString(), 6) + "(" +
                    FormatTextLength((res.GetVotePercentage()*100).ToString(), 4) + "%)        ";
            }
        }

        private class IntComparer : IComparer {
            public int Compare(object x, object y) {
                ValueSortedListEntry entryX = (ValueSortedListEntry) x;
                ValueSortedListEntry entryY = (ValueSortedListEntry) y;
                return -1*((int) entryX.Value).CompareTo(((int) entryY.Value));
            }
        }

        string noResponseValue = FormatTextLength(" ", 21);

        protected override void CreateReport(Election election) {
            intCount = 0;
            intPages = 0;
            lstToPrint = new List<string>();


            IList<ElectionContest> lstContests = election.ElectionContests;
            foreach (ElectionContest electionContest in lstContests) {
                // First, determine the responses.  If there's more than three, we can only
                //  fit three, so pick the three most important.

                ValueSortedList responses = new ValueSortedList(new IntComparer());
                foreach (Response response in electionContest.Responses) {
                    int totalVotes = GetVoteTotals(electionContest, response);
                    responses.Add(response, totalVotes);
                }

                string candidateNames = "";
                int responseCount = responses.Count > 3 ? 3 : responses.Count;

                switch (responseCount) {
                    case 3:
                        candidateNames = FormatTextLength(responses[0].Key.ToString(), 20) + " " +
                                         FormatTextLength(responses[1].Key.ToString(), 20) + " " +
                                         FormatTextLength(responses[2].Key.ToString(), 20);
                        break;
                    case 2:
                        candidateNames = FormatTextLength(responses[0].Key.ToString(), 20) + " " +
                                         FormatTextLength(responses[1].Key.ToString(), 41);
                        break;
                    case 1:
                        candidateNames = FormatTextLength(responses[0].Key.ToString(), 62);
                        break;

                    case 0:
                        candidateNames = FormatTextLength("----------NO CANDIDATES----------", 62);
                        break;
                }

                lstToPrint.Add("<HEADER>");
                lstToPrint.Add(DateTime.Now.ToString());
                lstToPrint.Add("");
                lstToPrint.Add(CenterText(electionContest.Contest.Name));
                lstToPrint.Add(CenterText(election.ToString()));
                lstToPrint.Add("");
                lstToPrint.Add("County           " + candidateNames + "   Wards             Votes");

                lstToPrint.Add("</HEADER>");

                foreach (ContestCounty cc in electionContest.Counties) {
                    
                    string strVoteCounts = FormatTextLength(cc.County.Name, 17);
    
                    for (int i = 0; i <= 2; i++) {
                        if (responseCount > i) {
                            strVoteCounts += GetVoteNumbers((Response) responses[i].Key, cc, noResponseValue);
                        } else {
                            strVoteCounts += noResponseValue;
                        }
                    }

                    strVoteCounts += FormatTextLength(cc.WardsReporting + "/" + cc.WardCount, 7, false);

                    if (cc.WardCount > 0)
                        strVoteCounts +=
                            FormatTextLength("(" + (((double) cc.WardsReporting/(double) cc.WardCount)*100).ToString("0.0") + "%)", 12, false);
                    else {
                        if (cc.WardsReporting > 0) {
                            strVoteCounts += FormatTextLength("(100.0%)", 12, false);
                        } else {
                            strVoteCounts += FormatTextLength("(00.0%)", 12, false);
                        }
                    }
                    strVoteCounts += FormatTextLength(" " + cc.GetTotalVotes(), 6, false);
                    lstToPrint.Add(strVoteCounts);
                }
                lstToPrint.Add("");
                lstToPrint.Add("");

                string strTotals = "Totals           ";

                for (int i = 0; i <= 2; i++) {
                    if (responseCount > i)
                        if (electionContest.GetTotalVotes() > 0) {
                            strTotals += 
                                FormatTextLength( 
                                FormatTextLength(GetVoteTotals(electionContest, (Response)responses[i].Key).ToString(), 5, true) +
                                    FormatTextLength(" (" + ((double)GetVoteTotals(electionContest, (Response)responses[i].Key) / (double) electionContest.GetTotalVotes()).ToString("0.0" + "%)"), 12, true), 
                                    21);
                        } else {
                            strTotals +=
                                FormatTextLength(
                                    FormatTextLength(GetVoteTotals(electionContest, (Response) responses[i].Key).ToString(), 5, true) + FormatTextLength("(" + "00.0%)", 12, true), 21);
                        }
                    else {
                        strTotals += noResponseValue;
                    }
                }
                strTotals +=
                    FormatTextLength(electionContest.GetWardsReporting() + "/" + electionContest.GetWardCount(), 7,
                                     false) +
                    FormatTextLength("(" + (electionContest.GetWardsReportingPercentage()*100).ToString("0.0") + "%)",
                                     12, false) + 
                    FormatTextLength(electionContest.GetTotalVotes().ToString(), 6, false);
                lstToPrint.Add(strTotals);
                lstToPrint.Add("<BREAK>");
            }

            // Set up print preview control.
            Controls.Remove(ppcElection);
            docToPrint = new PrintDocument();
            docToPrint.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            ppcElection = new PrintPreviewControl();
            ppcElection.Document = null;
            ppcElection.Document = docToPrint;
            docToPrint.DefaultPageSettings.Landscape = true;
            ppcElection.Location = new Point(190, 12);
            ppcElection.Name = "ppcElection";
            ppcElection.Width = Width - 237;
            ppcElection.Height = Height - 58;
            ppcElection.TabIndex = 3;
            Controls.Add(ppcElection);
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev) {
            try {
                intPages++;
                float linesPerPage;
                bool blnHeader = false;
                int intPageCount = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;

                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height/printFont.GetHeight(ev.Graphics);

                while (intPageCount < linesPerPage && intCount < lstToPrint.Count) {
                    // We'll store the current header here in case we have to go to multiple pages.
                    if (lstToPrint[intCount] == "<HEADER>") {
                        blnHeader = true;
                        lstHeader = new List<string>();
                        intCount++;
                    } else if (lstToPrint[intCount] == "</HEADER>") {
                        blnHeader = false;
                        intCount++;
                    } else if (lstToPrint[intCount] == "<BREAK>") {
                        intCount++;
                        break;
                    } else if (blnHeader) {
                        lstHeader.Add(lstToPrint[intCount]);
                        intCount++;
                    } else {
                        float yPos;
                        if (intPageCount == 0) {
                            foreach (string s in lstHeader) {
                                yPos = topMargin + (intPageCount*printFont.GetHeight(ev.Graphics));
                                ev.Graphics.DrawString(s, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                                intPageCount++;
                            }
                        }
                        yPos = topMargin + (intPageCount*printFont.GetHeight(ev.Graphics));
                        ev.Graphics.DrawString(lstToPrint[intCount], printFont, Brushes.Black, leftMargin, yPos,
                                               new StringFormat());
                        intCount++;
                        intPageCount++;
                    }
                }
                // If more lines exist, print another page.
                if (intCount < lstToPrint.Count)
                    ev.HasMorePages = true;
                else {
                    ev.HasMorePages = false;
                    intCount = 0;
                }
            } catch (Exception ex) {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex);
            }
        }


        private void InitializeElectionType() {
            cmbElectionType = new ComboBox();
            cmbElectionType.Items.Add("Active");
            cmbElectionType.Items.Add("Inactive");
            cmbElectionType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbElectionType.FormattingEnabled = true;
            cmbElectionType.Location = new Point(13, 581);
            cmbElectionType.Name = "cmbElectionType";
            cmbElectionType.Size = new Size(172, 21);
            cmbElectionType.TabIndex = 11;
            Resize += new EventHandler(ResizeSumry);
            cmbElectionType.SelectedIndexChanged += new EventHandler(IndexChanged);
            Controls.Add(cmbElectionType);
        }

        private void ResizeSumry(object sender, EventArgs e) {
            try {
                cmbElectionType.Top = lstElections.Height + 18;
            } catch (Exception ex) {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex);
            }
        }

        private void IndexChanged(object sender, EventArgs e) {
            try {
                LoadElections();
            } catch (Exception ex) {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex);
            }
        }
    }
}