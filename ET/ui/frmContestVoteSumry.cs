using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal class frmContestVoteSumry : frmAbstractReport {
        private int intCount;
        private IList<string> lstHeader;
        private IList<string> lstToPrint;
        private ComboBox cmbElectionType;

        public frmContestVoteSumry(ElectionDAO electionDAO, ContestCountyDAO contestCountyDAO) : base(electionDAO) {
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

        private int GetVoteTotals(ElectionContest ec, Response r) {
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

        /*
        private ResponseValue GetResponseValue(Response r, ContestCounty cc)
        {
            foreach (ResponseValue rv in cc.ResponseValues)
            {
                if (rv.Response.ID == r.ID)
                    return rv;
            }
            MessageBox.Show("RETURNING NULL " + r.ToString());
            return null;
        }*/


        private string GetVoteNumbers(Response r, ContestCounty cc) {
            ResponseValue res = null;
            foreach (ResponseValue rv in cc.ResponseValues) {
                if (rv.Response.ID == r.ID) {
                    res = rv;
                    break;
                }
            }
            if (res == null) {
                return "                     ";
            } else {
                return
                    FormatTextLength(res.VoteCount.ToString(), 6) + "(" +
                    FormatTextLength((res.GetVotePercentage()*100).ToString(), 4) + "%)        ";
            }
        }

        protected override void CreateReport(Election elc) {
            Response a, b, c;
            IList<Response> lstResponses;
            intCount = 0;
            intPages = 0;
            lstToPrint = new List<string>();
            string strHeaderNames;
            string strVoteCounts;
            string strTotals;

            IList<ElectionContest> lstContests = elc.ElectionContests;
            foreach (ElectionContest ec in lstContests) {
                a = b = c = null;
                // First, determine the responses.  If there's more than three, we can only
                //  fit three, so pick the three most important.
                lstResponses = ec.Responses;
                if (lstResponses.Count > 3) {
                    foreach (Response r in lstResponses) {
                        if (a == null)
                            a = r;
                        else if (GetVoteTotals(ec, c) <= GetVoteTotals(ec, r)) {
                            if (GetVoteTotals(ec, b) <= GetVoteTotals(ec, r)) {
                                if (GetVoteTotals(ec, a) <= GetVoteTotals(ec, r)) {
                                    c = b;
                                    b = a;
                                    a = r;
                                } else {
                                    c = b;
                                    b = r;
                                }
                            } else {
                                c = r;
                            }
                        }
                    }
                    lstResponses = new List<Response>();
                    lstResponses.Add(a);
                    lstResponses.Add(b);
                    lstResponses.Add(c);
                }
                if (lstResponses.Count > 0)
                    strHeaderNames = FormatTextLength(lstResponses[0].ToString(), 20) + " ";
                else
                    strHeaderNames = FormatTextLength(" ", 20) + " ";
                if (lstResponses.Count > 1)
                    strHeaderNames += FormatTextLength(lstResponses[1].ToString(), 20) + " ";
                else
                    strHeaderNames += FormatTextLength(" ", 20) + " ";
                if (lstResponses.Count > 2)
                    strHeaderNames += FormatTextLength(lstResponses[2].ToString(), 20) + " ";
                else
                    strHeaderNames += FormatTextLength(" ", 20) + " ";

                lstToPrint.Add("<HEADER>");
                lstToPrint.Add(DateTime.Now.ToString() + "");
                lstToPrint.Add("");
                lstToPrint.Add(CenterText(ec.Contest.Name));
                lstToPrint.Add(CenterText(elc.ToString()));
                lstToPrint.Add("");
                lstToPrint.Add("County           " + strHeaderNames + "Wards               Votes");

                lstToPrint.Add("</HEADER>");
                foreach (ContestCounty cc in ec.Counties) {
                    strVoteCounts = FormatTextLength(cc.County.Name, 17);
                    for (int i = 0; i <= 2; i++) {
                        if (lstResponses.Count > i)
                            strVoteCounts += GetVoteNumbers(lstResponses[i], cc);
                        else {
                            strVoteCounts += "                     ";
                        }
                    }
                    strVoteCounts += FormatTextLength("" + cc.WardsReporting, 3) + "/" +
                                     FormatTextLength("" + cc.WardCount, 3);
                    if (cc.WardCount > 0)
                        strVoteCounts +=
                            FormatTextLength(
                                "(" + (((double) cc.WardsReporting/(double) cc.WardCount)*100).ToString("0.0") + "%)",
                                13);
                    else {
                        if (cc.WardsReporting > 0) {
                            strVoteCounts += FormatTextLength("(100.0%)", 13);
                        } else {
                            strVoteCounts += FormatTextLength("(00.0%)", 13);
                        }
                    }
                    strVoteCounts += "" + cc.GetTotalVotes();
                    lstToPrint.Add(strVoteCounts);
                    //lstToPrint.Add(cc.County.Name + "     " + GetResponseValue(lstResponses[0], cc).GetVotePercentage().ToString());
                }
                lstToPrint.Add("");
                lstToPrint.Add("");
                strTotals = "Totals           ";
                for (int i = 0; i <= 2; i++) {
                    if (lstResponses.Count > i)
                        if (ec.GetTotalVotes() > 0) {
                            strTotals +=
                                FormatTextLength(
                                    FormatTextLength("" + GetVoteTotals(ec, lstResponses[i]), 5) + " (" +
                                    ((double) GetVoteTotals(ec, lstResponses[i])/(double) ec.GetTotalVotes()).ToString(
                                        "0.0" + "%)"), 21);
                        } else {
                            strTotals +=
                                FormatTextLength(
                                    FormatTextLength("" + GetVoteTotals(ec, lstResponses[i]), 5) + " (" + "00.0%)", 21);
                        }
                    else {
                        strTotals += "                     ";
                    }
                }
                strTotals += FormatTextLength("" + ec.GetWardsReporting(), 3) + "/" +
                             FormatTextLength("" + ec.GetWardCount(), 3) + "(" +
                             FormatTextLength((ec.GetWardsReportingPercentage()*100).ToString("0.0") + "%)", 12) +
                             ec.GetTotalVotes();
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
                float linesPerPage = 0;
                float yPos = 0;
                bool blnHeader = false;
                int intPageCount = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;

                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height/printFont.GetHeight(ev.Graphics);

                while (intPageCount < linesPerPage && intCount < lstToPrint.Count) {
                    // We'll store the current header here in case we have to go to multiple
                    //  pages.
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
                MessageBox.Show(message + "\n\n" + ex.ToString());
                //LOG.Error(message, ex);
            }
        }


        private void InitializeElectionType() {
            cmbElectionType = new ComboBox();
            cmbElectionType.Items.Add("Active");
            cmbElectionType.Items.Add("Inactive");
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
                MessageBox.Show(message + "\n\n" + ex.ToString());
                //LOG.Error(message, ex);
            }
        }

        private void IndexChanged(object sender, EventArgs e) {
            try {
                LoadElections();
            } catch (Exception ex) {
                string message = "Operation failed";
                MessageBox.Show(message + "\n\n" + ex.ToString());
                //LOG.Error(message, ex);
            }
        }
    }
}