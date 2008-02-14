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
using Common.Logging;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui.util;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal abstract partial class frmAbstractReport : Form {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (frmAbstractReport));

        protected ElectionDAO electionDAO;
        protected PrintDocument docToPrint;
        protected int intPages;
        protected Font printFont;
        protected bool blnLandscape;

        public frmAbstractReport(ElectionDAO electionDAO) {
            blnLandscape = false;
            this.electionDAO = electionDAO;
            InitializeComponent();
            printFont = new Font("Courier New", 10);
        }

        private int GetMarginSpot() {
            if (blnLandscape) {
                return 105;
            } else {
                return 75;
            }
        }


        protected string CenterText(string text) {
            return CenterText(text, ' ');
        }

        protected static string FormatTextLength(string text, int length, bool padRight) {
            int textLength = text.Length;
            string result = text;
            if (textLength > length) {
                result = text.Substring(0, length);
            } else {
                while (result.Length < length) {
                    if (padRight) {
                        result = result + " ";
                    } else {
                        result = " " + result;
                    }
                }
            }
            return result;
        }

        protected static string FormatTextLength(string text, int length) {
            return FormatTextLength(text, length, true);
        }

        protected string CenterText(string text, char space) {
            int length = text.Length;
            for (int i = 0; i <= ((GetMarginSpot() - length)/2); i++) {
                text = "" + space + text + space;
            }
            return text;
        }

        protected string AlignRight(string text) {
            int length = text.Length;
            for (int i = 0; i <= ((GetMarginSpot() - length)); i++) {
                text = " " + text;
            }
            return text;
        }

        public void LoadElections() {
            IList<Election> e = GetElections();
            lstElections.Items.Clear();
            foreach (Election election in e) {
                lstElections.Items.Add(new ListItemWrapper<Election>(election.ToString(), election));
            }
        }

        #region Events

        protected void btnPrint_Click(object sender, EventArgs e) {
            intPages = 0;
            docToPrint.Print();
        }

        protected void btnUp_Click(object sender, EventArgs e) {
            if (ppcElection.StartPage > 0) {
                ppcElection.StartPage--;
            }
        }

        protected void btnDown_Click(object sender, EventArgs e) {
            if (ppcElection.StartPage < intPages) {
                ppcElection.StartPage++;
            }
        }

        protected void lstElections_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                CreateReport(((ListItemWrapper<Election>) lstElections.SelectedItem).Value);
            } catch (Exception ex) {
                // Bad selection, just ignore.
                LOG.Error(ex);
            }
        }

        protected void ResizeForm(object sender, EventArgs e) {
            lstElections.Height = Height - 115;
            btnPrint.Top = Height - 69;
            ppcElection.Width = Width - 237;
            ppcElection.Height = Height - 58;
            btnUp.Left = Width - 40;
            btnDown.Left = Width - 40;
        }

        protected void frmAbstractReport_Load(object sender, EventArgs e) {
            LoadElections();
            Text = GetTitle();
        }

        #endregion

        #region Abstract

        protected abstract string GetTitle();
        protected abstract IList<Election> GetElections();
        protected abstract void CreateReport(Election election);

        #endregion
    }
}