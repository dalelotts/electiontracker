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
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;
using KnightRider.ElectionTracker.db.task;
using KnightRider.ElectionTracker.ui.util;

namespace KnightRider.ElectionTracker.ui {
    internal abstract partial class frmAbstractReport : Form {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (frmAbstractReport));

        protected readonly IElectionDAO electionDAO;
        protected readonly LoadElectionForReport loadTask;
        protected PrintDocument docToPrint;
        protected int intPages;
        protected Font printFont;
        protected bool blnLandscape;

        public frmAbstractReport(IElectionDAO electionDAO, LoadElectionForReport loadElectionForReport) {
            blnLandscape = false;
            this.electionDAO = electionDAO;
            loadTask = loadElectionForReport;
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