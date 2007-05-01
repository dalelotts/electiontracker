using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui.util;
using System.Drawing.Printing;
using System.IO;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmElectionReport : Form {
        private int intPages;
        private ElectionDAO electionDAO;
        private PrintDocument docToPrint;
        private Font printFont;
        private List<string> lstToPrint;
        private int intCount;
        private ContestCountyDAO contestCountyDAO;

        public frmElectionReport(ElectionDAO electionDAO, ContestCountyDAO contestCountyDAO){
            InitializeComponent();
            this.contestCountyDAO = contestCountyDAO;
            this.electionDAO = electionDAO;
            printFont = new Font("Courier New", 10);
        }

        private void LoadElections(){
            IList<Election> elections = electionDAO.findActive();
            foreach (Election election in elections){
                lstElections.Items.Add(new ListItemWrapper<Election>(election.Date.ToString(), election));
            }
        }

        private void frmElectionReport_Load(object sender, EventArgs e){
            LoadElections();
        }

        private void lstElections_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateReport(((ListItemWrapper<Election>)lstElections.SelectedItem).Value);
        }

        private static string CenterText(string text)
        {
            return CenterText(text, ' ');
        }

        private static string CenterText(string text, char space)
        {
            
                int length = text.Length;
                for (int i = 0; i <= ((75 - length) / 2); i++)
                {
                    text = "" + space + text + space;
                }
                return text;
            
        }

        private static string AlignRight(string text)
        {
            int length = text.Length;
            for (int i = 0; i <= ((75 - length)); i++)
            {
                text = " " + text;
            }
            return text;
        }

        private void CreateReport(Election elc)
        {
            intCount = 0;
            intPages = 0;
            lstToPrint = new List<string>();
            
            List<County> lstCounties = new List<County>();
            // Establish what counties to print for.
            IList<ElectionContest> electionContests = elc.ElectionContests;
            foreach (ElectionContest contest in electionContests){
                IList<ContestCounty> contestCounties = contest.Counties;
                foreach (ContestCounty county in contestCounties){
                    if (!lstCounties.Contains(county.County)) {
                        lstCounties.Add(county.County);
                    }
                }
            }
            foreach (County county in lstCounties){
                lstToPrint.Add(System.DateTime.Now.ToString() + "      VOTE COUNTY TALLY SHEET");
                lstToPrint.Add("");
                lstToPrint.Add("");
                lstToPrint.Add(CenterText("ELECTION DATE " + elc.Date.ToString()));
                lstToPrint.Add(CenterText(county.Name));
                foreach (CountyPhoneNumber cpn in county.PhoneNumbers){
                    lstToPrint.Add(AlignRight("Phone: " + cpn.PhoneNumber));
                }
                lstToPrint.Add("");
                lstToPrint.Add("");
                lstToPrint.Add(AlignRight("Time Called: _________________"));
                lstToPrint.Add("");

                // TODO: This could probably be better-done with some sort of
                // SQL or Hibernate query.
                foreach (ElectionContest ec in elc.ElectionContests)
                {
                    foreach(ContestCounty cc in ec.Counties)
                    {
                        if (cc.County.ID == county.ID)
                        {
                            // Good.
                            lstToPrint.Add(CenterText(ec.Contest.Name, '='));
                            lstToPrint.Add("");
                            foreach(Response r in ec.Responses)
                            {
                                lstToPrint.Add("" + r.ToString());
                                lstToPrint.Add("Current Vote Count: _________________________");
                                lstToPrint.Add("");
                                lstToPrint.Add("");
                            }
                            lstToPrint.Add(AlignRight("Wards Reporting: _________________"));
                            lstToPrint.Add(AlignRight("Total Wards:        " + cc.WardCount+ "     "));
                            lstToPrint.Add("");
                        }
                    }
                }
  


                lstToPrint.Add("<BREAK>");
            }

            this.Controls.Remove(ppcElection);
            docToPrint = new PrintDocument();
            docToPrint.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            ppcElection = new PrintPreviewControl();
            ppcElection.Document = null;
            ppcElection.Document = docToPrint;

            
            this.ppcElection.Location = new System.Drawing.Point(190, 12);
            this.ppcElection.Name = "ppcElection";
            ppcElection.Width = this.Width - 237;
            ppcElection.Height = this.Height - 58;
            this.ppcElection.TabIndex = 3;
            this.ppcElection.Click += new System.EventHandler(this.ppcElection_Click);
            this.Controls.Add(this.ppcElection);

        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            intPages++;
            float linesPerPage = 0;
            float yPos = 0;
            int intPageCount = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            while (intPageCount < linesPerPage && intCount < lstToPrint.Count){
                if (lstToPrint[intCount] == "<BREAK>"){
                    intCount++;
                    break;
                }
                yPos = topMargin + (intPageCount * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(lstToPrint[intCount], printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                intCount++;
                intPageCount++;
            }

            // If more lines exist, print another page.
            if (intCount < lstToPrint.Count)
                ev.HasMorePages = true;
            else{
                ev.HasMorePages = false;
                intCount = 0;
            }
        }

        private void ppcElection_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            intPages = 0;
            docToPrint.Print();
        }

        private void frmElectionReport_Resize(object sender, EventArgs e)
        {
            lstElections.Height = this.Height - 89;
            btnPrint.Top = this.Height - 69;
            ppcElection.Width = this.Width - 237;
            ppcElection.Height = this.Height - 58;
            btnUp.Left = this.Width - 40;
            btnDown.Left = this.Width - 40;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (ppcElection.StartPage > 0)
            {
                ppcElection.StartPage--;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (ppcElection.StartPage < intPages)
            ppcElection.StartPage++;
        }
    }
}