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
        private static readonly int LEFT = 5;

        private TextBox txtReporting;
        private Boolean _bDirty;
        private readonly Map<ResponseValue, TextBox> responseToTextBox;
        private readonly Map<long, ResponseValue> responseIDToResponseValue;
        private readonly ContestCounty contestCounty;
        private IContestCountyDAO contestCountyDAO;

        public ContestDisplay(ContestCounty contestCounty, IContestCountyDAO contestCountyDAO) {
            this.contestCounty = contestCounty;
            this.contestCountyDAO = contestCountyDAO;

            Width = 450;
            BorderStyle = BorderStyle.FixedSingle;
            Visible = true;

            Label lblContest = new Label();
            lblContest.Location = new Point(LEFT, LEFT);
            lblContest.Width = 300;
            lblContest.AutoSize = true;
            lblContest.Text = contestCounty.ElectionContest.Contest.Name;
            lblContest.TextAlign = ContentAlignment.MiddleLeft;
            lblContest.Font = new Font(lblContest.Font, FontStyle.Bold);
            Controls.Add(lblContest);

            Label lblWardCount = new Label();
            lblWardCount.Text = "/ " + contestCounty.WardCount;
            lblWardCount.Location = new Point(Width - 55, lblContest.Top);
            lblWardCount.Width = 25;
            lblWardCount.AutoSize = true;
            lblWardCount.TextAlign = ContentAlignment.MiddleLeft;
            lblWardCount.Anchor = ((AnchorStyles.Top) | AnchorStyles.Right);
            Controls.Add(lblWardCount);

            txtReporting = new TextBox();
            txtReporting.Width = 50;
            txtReporting.Location = new Point(lblWardCount.Left - txtReporting.Width - 5, lblContest.Top);
            txtReporting.Text = contestCounty.WardsReporting.ToString();
            txtReporting.Anchor = ((AnchorStyles.Top) | AnchorStyles.Right);
            txtReporting.Enter += new EventHandler(selectAllText);
            txtReporting.TextChanged += new EventHandler(DataChanged);
            txtReporting.KeyPress += new KeyPressEventHandler(BaseMDIChild.numericInputOnly);
            Controls.Add(txtReporting);

            Label lblReporting = new Label();
            lblReporting.Text = "Reporting Units: ";
            lblReporting.TextAlign = ContentAlignment.MiddleRight;
            lblReporting.Location = new Point(txtReporting.Left - lblReporting.Width - 10, lblContest.Top);
            lblReporting.Anchor = ((AnchorStyles.Top) | AnchorStyles.Right);
            Controls.Add(lblReporting);

            responseToTextBox = new Map<ResponseValue, TextBox>();
            responseIDToResponseValue = new Map<long, ResponseValue>();

            InitializeResponses();

            lblContest.SendToBack();
            lblReporting.BringToFront();

            Dirty = false;
        }

        private static void selectAllText(Object sender, EventArgs e) {
            if (sender is TextBox) {
                TextBox senderTextBox = (TextBox) sender;
                senderTextBox.SelectionStart = 0;
                senderTextBox.SelectionLength = senderTextBox.Text.Length;
            }
        }

        public Boolean Dirty {
            get { return _bDirty; }
            set { _bDirty = value; }
        }

        public IList<string> Persist() {
            List<string> result = new List<string>();
            if (!Dirty) return result;
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
                    result.Add(contestCounty.County + " county, " + contestCounty.ElectionContest.Contest.Name);
                    Dirty = false;
                }
            } catch (Exception ex) {
                LOG.Error("Persist", ex);
            }
            return result;
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
                i += LEFT;
                Label label = new Label();
                label.Text = response.ToString();
                label.BackColor = Color.Transparent;
                label.Width = 300;
                label.Location = new Point(LEFT, (txtReporting.Height + 1) + ((txtReporting.Height) * (responseToTextBox.Count + 1)) + i);
                Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Text = "NA";
                textBox.TextChanged += new EventHandler(DataChanged);
                textBox.Enter += new EventHandler(selectAllText);
                textBox.KeyPress += new KeyPressEventHandler(BaseMDIChild.numericInputOnly);
                textBox.Location = new Point(txtReporting.Left, label.Top);
                textBox.Width = txtReporting.Width;
                textBox.Anchor = ((AnchorStyles.Top) | AnchorStyles.Right);

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