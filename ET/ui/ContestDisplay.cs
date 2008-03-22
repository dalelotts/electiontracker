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
using System.Windows.Forms;
using Common.Logging;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;
using KnightRider.ElectionTracker.util;

namespace KnightRider.ElectionTracker.ui {
    internal sealed class ContestDisplay : Panel {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (ContestDisplay));

        private TextBox txtReporting;
        private Boolean _bDirty;
        private readonly Map<ResponseValue, TextBox> responseToTextBox;
        private readonly Map<long, ResponseValue> responseIDToResponseValue;
        private readonly ContestCounty contestCounty;
        private IContestCountyDAO contestCountyDAO;

        public ContestDisplay(ContestCounty contestCounty, IContestCountyDAO contestCountyDAO)
        {
            this.contestCounty = contestCounty;
            this.contestCountyDAO = contestCountyDAO;

            Width = 450;
            BorderStyle = BorderStyle.FixedSingle;
            Visible = true;


            Label lblContest = new Label();
            lblContest.Left = 5;
            lblContest.Width = 300;
            lblContest.Text = contestCounty.ElectionContest.Contest.Name;
            Controls.Add(lblContest);

            Label lblWardCount = new Label();
            lblWardCount.Text = " / " + contestCounty.WardCount;
            lblWardCount.Left = Width - 55;
            lblWardCount.Width = 25;
            lblWardCount.AutoSize = true;
            lblWardCount.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(lblWardCount);

            txtReporting = new TextBox();
            txtReporting.Width = 30;
            txtReporting.Left = lblWardCount.Left - txtReporting.Width - 10;
            txtReporting.Text = contestCounty.WardsReporting.ToString();
            Controls.Add(txtReporting);

            Label lblReporting = new Label();
            lblReporting.Text = "Wards Reporting: ";
            lblReporting.TextAlign = ContentAlignment.MiddleRight;
            lblReporting.Left = txtReporting.Left - lblReporting.Width - 10;
            Controls.Add(lblReporting);

            responseToTextBox = new Map<ResponseValue, TextBox>();
            responseIDToResponseValue = new Map<long, ResponseValue>();

            InitializeResponses();

            lblContest.SendToBack();
            lblReporting.BringToFront();

            Dirty = false;
        }

        public Boolean Dirty {
            get { return _bDirty; }
            set { _bDirty = value; }
        }

        public void Persist() {
            if (!Dirty) return;
            try {
                contestCounty.WardsReporting = int.Parse(txtReporting.Text);

                foreach (KeyValuePair<ResponseValue, TextBox> entry in responseToTextBox) {
                    ResponseValue responseValue = entry.Key;
                    TextBox textBox = entry.Value;
                    responseValue.VoteCount = int.Parse(textBox.Text);
                }

                IList<Fault> contestCountyFaults = contestCountyDAO.canMakePersistent(contestCounty);
                bool persistData = BaseMDIChild.reportFaults(contestCountyFaults);

                //If there were no errors, persist data to the database
                if (persistData) {
                    contestCountyDAO.makePersistent(contestCounty);
                    Dirty = false;
                }
            } catch (Exception ex) {
                LOG.Error("Persist", ex);
            }
        }

        private void InitializeResponses() {
            int i = 0;
            IList<string> excluded = new List<string>();
            excluded.Add("ID");
            excluded.Add("VoteCount");

            foreach (ResponseValue responseValue in contestCounty.ResponseValues) {
                responseIDToResponseValue.Put(responseValue.Response.ID, responseValue);
            }

            IList<Response> responses = contestCounty.ElectionContest.Responses;

            foreach (Response response in responses) {
                i += 5;
                Label label = new Label();
                label.Text = response.ToString();
                label.Left = 5;
                label.BackColor = Color.Transparent;
                label.Width = 300;
                label.Top = (txtReporting.Height + 1) + ((txtReporting.Height) * (responseToTextBox.Count + 1)) + i;
                Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Text = "NA";
                textBox.TextChanged += new EventHandler(DataChanged);
                textBox.Top = label.Top;
                textBox.Left = txtReporting.Left;
                textBox.Width = txtReporting.Width;

                ResponseValue value = responseIDToResponseValue.Get(response.ID);
                if (value == null) {
                    value = new ResponseValue();
                    value.ContestCounty = contestCounty;
                    value.Response = response;
                    value.VoteCount = 0;
                    contestCounty.ResponseValues.Add(value);
                }

                textBox.Text = value.VoteCount.ToString();
                responseToTextBox.Put(value, textBox);
                Controls.Add(textBox);
                Height = label.Top + label.Height + 1;
            }
        }

        // Event handler.  Marks the ContestDisplay as dirty.
        private void DataChanged(object sender, EventArgs e) {
            Dirty = true;
        }
    }
}