using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.db;
using System.Drawing.Printing;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.ui.util;


namespace edu.uwec.cs.cs355.group4.et.ui
{
    class frmProofingSheet : frmAbstractReport
    {
        private int intCount;
        private List<string> lstToPrint;
        private List<string> lstHeader;
        public frmProofingSheet(ElectionDAO electionDAO) : base(electionDAO){
            blnLandscape = true;
        }

        protected override string GetTitle()
        {
            return "Proofing Sheet";
        }

        protected override IList<Election> GetElections(){
            return electionDAO.findActive();
        }

        protected override void CreateReport(Election elc)
        {
            intCount = 0;
            intPages = 0;
            lstToPrint = new List<string>();

            // TODO: Set up the print.

            lstToPrint.Add("<HEADER>");
            lstToPrint.Add(System.DateTime.Now.ToString() + "");
            lstToPrint.Add("");
            lstToPrint.Add(CenterText("ELECTION PROOFING SHEET"));
            lstToPrint.Add(CenterText("ELECTION DATE " + elc.Date.ToString()));
            lstToPrint.Add("");
            lstToPrint.Add("");
            lstToPrint.Add("CONTEST                     WARDS   COUNTY                  RESPONSE  ");
            lstToPrint.Add("-------                     -----   ------                  --------  ");
            lstToPrint.Add("</HEADER>");
            lstToPrint.Add("");

            int intResponses;
            int intCounties;
            int i, j;
            bool b;
            string strCountyPart, strResponsePart, strContestPart;
            IList<ElectionContest> electionContests = elc.ElectionContests;
            foreach (ElectionContest contest in electionContests){
                b = true;
                i = j = 0;
                intResponses = contest.Responses.Count;
                intCounties = contest.Counties.Count;
                while (i < intResponses || j < intCounties)                {
                    if (b){
                        b = false;
                        strContestPart = FormatTextLength(contest.Contest.Name, 30);
                    }
                    else{
                        strContestPart = FormatTextLength(" ", 30);
                    }
                    if (i < intResponses){
                        strResponsePart = FormatTextLength(contest.Responses[i].ToString(), 30);
                    }
                    else{
                        strResponsePart = FormatTextLength(" ", 30);
                    }
                    if (j < intCounties){
                        strCountyPart = FormatTextLength("" + contest.Counties[j].WardCount, 6) + 
                                        FormatTextLength(contest.Counties[j].County.Name, 24);
                    }
                    else{
                        strCountyPart = FormatTextLength(" ", 30);
                    }
                    lstToPrint.Add(strContestPart + strCountyPart + strResponsePart);             
                    i++; j++;
                }
                lstToPrint.Add("");
            }


            // Set up print preview control.
            this.Controls.Remove(ppcElection);
            docToPrint = new PrintDocument();
            docToPrint.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            ppcElection = new PrintPreviewControl();
            ppcElection.Document = null;
            ppcElection.Document = docToPrint;
            this.docToPrint.DefaultPageSettings.Landscape = true;
            this.ppcElection.Location = new System.Drawing.Point(190, 12);
            this.ppcElection.Name = "ppcElection";
            ppcElection.Width = this.Width - 237;
            ppcElection.Height = this.Height - 58;
            this.ppcElection.TabIndex = 3;
            this.Controls.Add(this.ppcElection);
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            intPages++;
            float linesPerPage = 0;
            float yPos = 0;
            //int intContestSize = 0;
            bool blnHeader = false;
            int intPageCount = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
            while (intPageCount < linesPerPage && intCount < lstToPrint.Count)
            {
                if (lstToPrint[intCount] == "<HEADER>")                {
                    lstHeader = new List<string>();
                    blnHeader = true;
                    intCount++;
                }
                else if (lstToPrint[intCount] == "</HEADER>")
                {
                    blnHeader = false;
                    intCount++;
                }
                else if (blnHeader)
                {
                    lstHeader.Add(lstToPrint[intCount]);
                    intCount++;
                }
                else{
                    if (intPageCount == 0)
                    {
                        foreach (string s in lstHeader)
                        {
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
                
                //break;
            }

            // If more lines exist, print another page.
            if (intCount < lstToPrint.Count)
                ev.HasMorePages = true;
            else
            {
                ev.HasMorePages = false;
                intCount = 0;
            }
        }
    }
}
