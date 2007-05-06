using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.core;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    internal partial class frmCountyContactForm : Form
    {
        //ContestDAO contestDAO;
        ElectionDAO electionDAO;
        CountyDAO countyDAO;
        private Font printFont;
        IList<string> lstToPrint;
        IList<string> lstHeader;
        int intPages;
        int intCount;
        PrintDocument toPrint;
        public frmCountyContactForm(ElectionDAO electionDAO, CountyDAO countyDAO)
        {
            this.countyDAO = countyDAO;
            this.electionDAO = electionDAO;
            //this.contestDAO = contestDAO;
            InitializeComponent();
            printFont = new Font("Courier New", 10);
        }

        private void frmCountyContactForm_Load(object sender, EventArgs e)
        {
            try
            {
                toPrint = new PrintDocument();
                toPrint.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                CreateReport();
                ppcViewer.Document = toPrint;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void CreateReport()
        {
            lstToPrint = new List<string>();
            intPages = 0;
            intCount = 0;
            lstToPrint.Add("<HEADER>");
            lstToPrint.Add(System.DateTime.Now.ToString());
            lstToPrint.Add("                          COUNTY CONTACT LISTING");
            lstToPrint.Add("");
            lstToPrint.Add("</HEADER>");

            foreach (County c in countyDAO.findAll())
            {
                lstToPrint.Add(c.Name);
                foreach (CountyPhoneNumber cpn in c.PhoneNumbers)
                {
                    lstToPrint.Add("   " + cpn.Type.Name + ": (" + cpn.AreaCode + ")" + cpn.PhoneNumber +
                        ((cpn.Extension != "" && cpn.Extension != null)
                        ? ("(" + cpn.Extension + ")")
                        : ""));
                }
                foreach (CountyWebsite cw in c.Websites)
                {
                    lstToPrint.Add("   " + cw.URL);
                }
                foreach (CountyAttribute ca in c.Attributes)
                {
                    lstToPrint.Add("   " + ca.Type.Name + ": " + ca.Value);
                }
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                intPages++;
                float linesPerPage = 0;
                float yPos = 0;
                bool blnHeader = false;
                int intPageCount = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;

                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

                while (intPageCount < linesPerPage && intCount < lstToPrint.Count)
                {
                    if (lstToPrint[intCount] == "<HEADER>")
                    {
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
                    else
                    {
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (ppcViewer.StartPage > 0)
                {
                    ppcViewer.StartPage--;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        protected void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (ppcViewer.StartPage < intPages)
                {
                    ppcViewer.StartPage++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                intPages = 0;
                toPrint.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void frmCountyContactForm_Resize(object sender, EventArgs e)
        {
            try
            {
                btnUp.Left = this.Width - 40;
                btnDown.Left = this.Width - 40;
                ppcViewer.Width = this.Width - 53;
                ppcViewer.Height = this.Height - 81;
                btnPrint.Top = this.Height - 63;
                btnPrint.Left = this.Width - 116;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

    }
}