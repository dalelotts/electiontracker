using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using edu.uwec.cs.cs355.group4.et.db;
using System.Drawing;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.ui.util;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    class frmElectionReport : frmAbstractReport 
    {
        
        //private Font printFont;
        private List<string> lstToPrint;
        private List<string> lstHeader;
        private int intCount;
        private ContestCountyDAO contestCountyDAO;

        public frmElectionReport(ElectionDAO electionDAO, ContestCountyDAO contestCountyDAO) : base(electionDAO){
            lstHeader = new List<string>();
            this.contestCountyDAO = contestCountyDAO;
            
        }

        protected override IList<Election> GetElections()   {
            return electionDAO.findActive();
            
        }

        protected override string GetTitle()        {
            return "Tally Form";
        }

        protected override void CreateReport(Election elc)        {
            intCount = 0;
            intPages = 0;
            lstToPrint = new List<string>();

            List<County> lstCounties = new List<County>();
            // Establish what counties to print for.
            IList<ElectionContest> electionContests = elc.ElectionContests;
            foreach (ElectionContest contest in electionContests)            {
                IList<ContestCounty> contestCounties = contest.Counties;
                foreach (ContestCounty county in contestCounties)                {
                    if (!lstCounties.Contains(county.County))                    {
                        lstCounties.Add(county.County);
                    }
                }
            }
            foreach (County county in lstCounties)            {
                lstToPrint.Add("<HEADER>");
                lstToPrint.Add(System.DateTime.Now.ToString() + "      VOTE COUNTY TALLY SHEET");
                lstToPrint.Add("");
                lstToPrint.Add("");
                lstToPrint.Add(CenterText("ELECTION DATE " + elc.Date.ToString()));
                lstToPrint.Add(CenterText(county.Name));
                foreach (CountyPhoneNumber cpn in county.PhoneNumbers)                {
                    lstToPrint.Add(AlignRight("Phone: " + cpn.PhoneNumber));
                }
                lstToPrint.Add("");
                lstToPrint.Add("");
                lstToPrint.Add(AlignRight("Time Called: _________________"));
                lstToPrint.Add("");
                lstToPrint.Add("</HEADER>");

                // TODO: This could probably be better-done with some sort of
                // SQL or Hibernate query.
                foreach (ElectionContest ec in elc.ElectionContests)                {
                    foreach (ContestCounty cc in ec.Counties)                    {
                        if (cc.County.ID == county.ID)                        {
                            lstToPrint.Add("<CONTEST>");
                            // Good.
                            lstToPrint.Add(CenterText(" " + ec.Contest.Name + " ", '='));
                            lstToPrint.Add("");
                            foreach (Response r in ec.Responses)                            {
                                lstToPrint.Add("" + r.ToString());
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

            this.Controls.Remove(ppcElection);
            docToPrint = new PrintDocument();
            //docToPrint.DefaultPageSettings.Landscape = true;
            docToPrint.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            ppcElection = new PrintPreviewControl();
            ppcElection.Document = null;
            ppcElection.Document = docToPrint;


            this.ppcElection.Location = new System.Drawing.Point(190, 12);
            this.ppcElection.Name = "ppcElection";
            ppcElection.Width = this.Width - 237;
            ppcElection.Height = this.Height - 58;
            this.ppcElection.TabIndex = 3;
            //this.ppcElection.Click += new System.EventHandler(this.ppcElection_Click);
            this.Controls.Add(this.ppcElection);
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            intPages++;
            float linesPerPage = 0;
            float yPos = 0;
            int intContestSize = 0;
            bool blnHeader = false;
            int intPageCount = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            while (intPageCount < linesPerPage && intCount < lstToPrint.Count)            {
                // Check to see if we're putting a contest in.  If we are, make sure it fits
                //  on one page.  If not, break page.
                if (lstToPrint[intCount] == "<CONTEST>")                {
                    intContestSize = 0;
                    for (int i = intCount; i < lstToPrint.Count; i++)                    {
                        if (lstToPrint[i] == "</CONTEST>")                        {
                            break;
                        }
                        else                        {
                            intContestSize++;
                        }
                    }
                    if (intContestSize + intPageCount > linesPerPage)                    {
                        intCount++;
                        break;
                    }
                    else                    {
                        intCount++;
                    }
                }
                else if (lstToPrint[intCount] == "</CONTEST>")                {
                    intCount++;
                }
                // We'll store the current header here in case we have to go to multiple
                //  pages.
                else if (lstToPrint[intCount] == "<HEADER>")                {
                    blnHeader = true;
                    lstHeader = new List<string>();
                    intCount++;
                }
                else if (lstToPrint[intCount] == "</HEADER>")                {
                    blnHeader = false;
                    intCount++;
                }
                else if (lstToPrint[intCount] == "<BREAK>")                {
                    intCount++;
                    break;
                }
                else if (blnHeader)                {
                    lstHeader.Add(lstToPrint[intCount]);
                    intCount++;
                }
                else                {
                    if (intPageCount == 0)                    {
                        foreach (string s in lstHeader)                        {
                            yPos = topMargin + (intPageCount * printFont.GetHeight(ev.Graphics));
                            ev.Graphics.DrawString(s, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                            intPageCount++;
                        }
                    }
                    yPos = topMargin + (intPageCount * printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(lstToPrint[intCount], printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                    intCount++;
                    intPageCount++;
                }
            }

            // If more lines exist, print another page.
            if (intCount < lstToPrint.Count)
                ev.HasMorePages = true;
            else            {
                ev.HasMorePages = false;
                intCount = 0;
            }
        }
    }
}
