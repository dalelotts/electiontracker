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
    internal class frmElectionReport : frmAbstractReport {
        private List<string> lstToPrint;
        private List<string> lstHeader;
        private int intCount;

        public frmElectionReport(IElectionDAO electionDAO, LoadElectionForReport loadElectionForReport)
            : base(electionDAO, loadElectionForReport) {
            lstHeader = new List<string>();
        }

        protected override IList<Election> GetElections() {
            return electionDAO.findActive(loadTask);
        }

        protected override string GetTitle() {
            return "Tally Form";
        }

        protected override void CreateReport(Election election) {
            intCount = 0;
            intPages = 0;
            lstToPrint = new List<string>();

            List<County> lstCounties = new List<County>();
            // Establish what counties to print for.
            IList<ElectionContest> electionContests = election.ElectionContests;
            foreach (ElectionContest contest in electionContests) {
                IList<ContestCounty> contestCounties = contest.Counties;
                foreach (ContestCounty county in contestCounties) {
                    if (!lstCounties.Contains(county.County)) {
                        lstCounties.Add(county.County);
                    }
                }
            }
            foreach (County county in lstCounties) {
                lstToPrint.Add("<HEADER>");
                lstToPrint.Add(DateTime.Now + "      VOTE COUNTY TALLY SHEET");
                lstToPrint.Add("");
                lstToPrint.Add("");
                lstToPrint.Add(CenterText("ELECTION DATE " + election.Date.ToShortDateString()));
                lstToPrint.Add(CenterText(county.Name));
                foreach (CountyPhoneNumber phoneNumber in county.PhoneNumbers) {
                    lstToPrint.Add(
                        AlignRight(phoneNumber.Type.Name + ": " + phoneNumber.AreaCode + "-" + phoneNumber.PhoneNumber));
                }
                foreach (CountyWebsite website in county.Websites) {
                    lstToPrint.Add(AlignRight("Website: " + website.URL));
                }
                foreach (CountyAttribute attribute in county.Attributes) {
                    lstToPrint.Add(AlignRight(attribute.Type.Name + ": " + attribute.Value));
                }
                lstToPrint.Add("");
                lstToPrint.Add("");
                lstToPrint.Add(AlignRight("Time Called: _________________"));
                lstToPrint.Add("");
                lstToPrint.Add("</HEADER>");

                // TODO: This could probably be better-done with some sort of
                // SQL or Hibernate query.
                foreach (ElectionContest ec in election.ElectionContests) {
                    foreach (ContestCounty cc in ec.Counties) {
                        if (cc.County.ID == county.ID) {
                            lstToPrint.Add("<CONTEST>");
                            // Good.
                            lstToPrint.Add(CenterText(" " + ec.Contest.Name + " ", '='));
                            lstToPrint.Add("");
                            foreach (Response r in ec.Responses) {
                                lstToPrint.Add("" + r);
                                lstToPrint.Add("Current Vote Count: _________________________");
                                lstToPrint.Add("");
                                lstToPrint.Add("");
                            }
                            lstToPrint.Add(AlignRight("Wards Reporting: _________________"));
                            lstToPrint.Add(AlignRight("Total Wards:        " + cc.WardCount + "     "));
                            lstToPrint.Add("");
                            lstToPrint.Add("</CONTEST>");
                        }
                    }
                }
                lstToPrint.Add("<BREAK>");
            }

            Controls.Remove(ppcElection);
            docToPrint = new PrintDocument();
            docToPrint.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            ppcElection = new PrintPreviewControl();
            ppcElection.Document = null;
            ppcElection.Document = docToPrint;


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
                    // Check to see if we're putting a contest in.  If we are, make sure it fits
                    //  on one page.  If not, break page.
                    if (lstToPrint[intCount] == "<CONTEST>") {
                        int intContestSize;
                        intContestSize = 0;
                        for (int i = intCount; i < lstToPrint.Count; i++) {
                            if (lstToPrint[i] == "</CONTEST>") {
                                break;
                            } else {
                                intContestSize++;
                            }
                        }
                        if (intContestSize + intPageCount > linesPerPage) {
                            intCount++;
                            break;
                        } else {
                            intCount++;
                        }
                    } else if (lstToPrint[intCount] == "</CONTEST>") {
                        intCount++;
                    }
                        // We'll store the current header here in case we have to go to multiple pages.
                    else if (lstToPrint[intCount] == "<HEADER>") {
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
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}