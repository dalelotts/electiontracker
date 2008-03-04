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

namespace KnightRider.ElectionTracker.ui {
    internal partial class frmCountyContactForm : Form {
        private CountyDAO countyDAO;
        private Font printFont;
        private IList<string> lstToPrint;
        private IList<string> lstHeader;
        private int intPages;
        private int intCount;
        private PrintDocument toPrint;

        public frmCountyContactForm(CountyDAO countyDAO) {
            this.countyDAO = countyDAO;
            InitializeComponent();
            printFont = new Font("Courier New", 10);
        }

        private void frmCountyContactForm_Load(object sender, EventArgs e) {
            try {
                toPrint = new PrintDocument();
                toPrint.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                CreateReport();
                ppcViewer.Document = toPrint;
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void CreateReport() {
            lstToPrint = new List<string>();
            intPages = 0;
            intCount = 0;
            lstToPrint.Add("<HEADER>");
            lstToPrint.Add(DateTime.Now.ToString());
            lstToPrint.Add("                          COUNTY CONTACT LISTING");
            lstToPrint.Add("");
            lstToPrint.Add("</HEADER>");

            foreach (County c in countyDAO.findAll()) {
                lstToPrint.Add(c.Name);
                foreach (CountyPhoneNumber cpn in c.PhoneNumbers) {
                    lstToPrint.Add("   " + cpn.Type.Name + ": (" + cpn.AreaCode + ")" + cpn.PhoneNumber +
                                   ((cpn.Extension != "" && cpn.Extension != null) ? ("(" + cpn.Extension + ")") : ""));
                }
                foreach (CountyWebsite cw in c.Websites) {
                    lstToPrint.Add("   " + cw.URL);
                }
                foreach (CountyAttribute ca in c.Attributes) {
                    lstToPrint.Add("   " + ca.Type.Name + ": " + ca.Value);
                }
            }
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

        protected void btnUp_Click(object sender, EventArgs e) {
            try {
                if (ppcViewer.StartPage > 0) {
                    ppcViewer.StartPage--;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }

        protected void btnDown_Click(object sender, EventArgs e) {
            try {
                if (ppcViewer.StartPage < intPages) {
                    ppcViewer.StartPage++;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e) {
            try {
                intPages = 0;
                toPrint.Print();
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void frmCountyContactForm_Resize(object sender, EventArgs e) {
            try {
                btnUp.Left = Width - 40;
                btnDown.Left = Width - 40;
                ppcViewer.Width = Width - 53;
                ppcViewer.Height = Height - 81;
                btnPrint.Top = Height - 63;
                btnPrint.Left = Width - 116;
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}