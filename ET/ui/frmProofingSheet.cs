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

namespace KnightRider.ElectionTracker.ui {
    internal class frmProofingSheet : frmAbstractReport {
        private int intCount;
        private List<string> lstToPrint;
        private List<string> lstHeader;

        public frmProofingSheet(IElectionDAO electionDAO, IDAOTask<Election> loadTask)
            : base(electionDAO, loadTask)
        {
            blnLandscape = true;
        }

        protected override string GetTitle() {
            return "Proofing Sheet";
        }

        protected override IList<Election> GetElections() {
            return electionDAO.findActive(loadTask);
        }

        protected override void CreateReport(Election election) {
            intCount = 0;
            intPages = 0;
            lstToPrint = new List<string>();
            // TODO: Set up the print.

            lstToPrint.Add("<HEADER>");
            lstToPrint.Add(DateTime.Now + "");
            lstToPrint.Add("");
            lstToPrint.Add(CenterText("ELECTION PROOFING SHEET"));
            lstToPrint.Add(CenterText("ELECTION DATE " + election));
            lstToPrint.Add("");
            lstToPrint.Add("");
            lstToPrint.Add("CONTEST                     WARDS   COUNTY                  CANDIDATE");
            lstToPrint.Add("-------------------------   -----   ---------------------   ---------");
            lstToPrint.Add("</HEADER>");
            lstToPrint.Add("");

            List<ElectionContest> contests = new List<ElectionContest>(election.ElectionContests);

            contests.Sort(new ElectionContestComparer());

            foreach (ElectionContest contest in contests) {
                int wardCount = 0;
                int responseCount = 0;
                int countyCount = 0;
                int totalResponses = contest.Responses.Count;
                int totalCounties = contest.Counties.Count;
                bool printContestColumn = true;

                string contestName = FormatTextLength(contest.Contest.Name, 28);

                // If there are no responses or counties the while loop later
                // in this method will fail to print the contest name, so print it now.

                if (totalResponses == 0 && totalCounties == 0) {
                    lstToPrint.Add(contestName);
                    printContestColumn = false;
                }

                while (responseCount < totalResponses || countyCount < totalCounties) {
                    string contestColumn;
                    if (printContestColumn) {
                        printContestColumn = false;
                        contestColumn = FormatTextLength(contestName, 28);
                    } else {
                        contestColumn = FormatTextLength(" ", 28);
                    }

                    string countyColumn;
                    string wardColumn;
                    if (countyCount < totalCounties) {
                        ContestCounty currentCounty = contest.Counties[countyCount];
                        wardColumn = FormatTextLength(currentCounty.WardCount.ToString(), 5, false) + "   ";
                        countyColumn = FormatTextLength(currentCounty.County.Name, 24);
                        wardCount += currentCounty.WardCount;
                    } else {
                        wardColumn = FormatTextLength(" ", 8);
                        countyColumn = FormatTextLength(" ", 24);
                    }

                    string responseColumn;
                    if (responseCount < totalResponses) {
                        Response currentResponse = contest.Responses[responseCount];
                        responseColumn = FormatTextLength(currentResponse.ToString(), 30);
                    } else {
                        responseColumn = FormatTextLength(" ", 30);
                    }

                    lstToPrint.Add(contestColumn + wardColumn + countyColumn + responseColumn);
                    responseCount++;
                    countyCount++;
                }
                lstToPrint.Add(FormatTextLength(" ", 28) + "-----");
                lstToPrint.Add(FormatTextLength(" ", 16) + "Total Wards:" +
                               FormatTextLength(wardCount.ToString(), 5, false));
                lstToPrint.Add("");
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
                    if (lstToPrint[intCount] == "<HEADER>") {
                        lstHeader = new List<string>();
                        blnHeader = true;
                        intCount++;
                    } else if (lstToPrint[intCount] == "</HEADER>") {
                        blnHeader = false;
                        intCount++;
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

                    //break;
                }

                // If more lines exist, print another page.
                if (intCount < lstToPrint.Count)
                    ev.HasMorePages = true;
                else {
                    ev.HasMorePages = false;
                    intCount = 0;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }
    }

    internal class ElectionContestComparer : IComparer<ElectionContest> {
        public int Compare(ElectionContest x, ElectionContest y) {
            return x.Contest.Name.CompareTo(y.Contest.Name);
        }
    }
}