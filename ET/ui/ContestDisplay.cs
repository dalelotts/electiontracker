using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.util;
using log4net;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal sealed class ContestDisplay : Panel {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (ContestDisplay));

        private readonly ContestCounty contestCounty;
        private readonly ContestCountyDAO contestCountyDAO;
        private ResponseValueDAO responseValueDAO;

        private TextBox txtReporting;
        private Boolean _bDirty;
        private readonly Map<ResponseValue, TextBox> responseToTextBox;

        public ContestDisplay(ContestCounty contestCounty, ContestCountyDAO contestCountyDAO,
                              ResponseValueDAO responseValueDAO) {
            this.contestCounty = contestCounty;
            this.responseValueDAO = responseValueDAO;
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

            IList<Response> responses = contestCounty.ElectionContest.Responses;
            responseToTextBox = new Map<ResponseValue, TextBox>();
            InitializeResponses(responses);

            lblContest.SendToBack();
            lblReporting.BringToFront();

            Dirty = false;
        }

        public Boolean Dirty {
            get { return _bDirty; }
            set { _bDirty = value; }
        }

        public void Persist() {
            try {
                contestCounty.WardsReporting = int.Parse(txtReporting.Text);

                // START HACK - For some reason this fixed the following exception
                // NHibernate.LazyInitializationException: Illegally attempted to associate a proxy with two open Sessions
                County county = contestCounty.County;
                string s = county.Name;
                ElectionContest electionContest = contestCounty.ElectionContest;
                Contest contest = electionContest.Contest;
                // END HACK

                IList<Fault> contestCountyFaults = contestCountyDAO.validate(contestCounty);
                bool persistData = BaseMDIChild.reportFaults(contestCountyFaults);


                //If there were no errors, persist data to the database
                if (persistData) {
                    contestCountyDAO.makePersistent(contestCounty);
                    //contestCountyDAO.flush();

                    foreach (KeyValuePair<ResponseValue, TextBox> entry in responseToTextBox) {
                        ResponseValue responseValue = entry.Key;
                        TextBox textBox = entry.Value;
                        responseValue.VoteCount = int.Parse(textBox.Text);

                        // START HACK - For some reason this fixed the following exception
                        // NHibernate.LazyInitializationException: Illegally attempted to associate a proxy with two open Sessions
                        Response response = responseValue.Response;
                        ElectionContest hack2 = response.ElectionContest;
                        string hack3 = responseValue.ContestCounty.County.Name;
                        // END HACK

                        IList<Fault> responseValueFaults = responseValueDAO.validate(responseValue);
                        bool persistResponseValue = BaseMDIChild.reportFaults(responseValueFaults);

                        //If there were no errors, persist data to the database
                        if (persistResponseValue) {
                            responseValueDAO.makePersistent(responseValue);
                        }
                    }
                }
                Dirty = false;
            } catch (Exception ex) {
                LOG.Error("Persist", ex);
            }
        }

        private void InitializeResponses(IList<Response> responses) {
            int i = 0;
            IList<string> excluded = new List<string>();
            excluded.Add("ID");
            excluded.Add("VoteCount");

            foreach (Response response in responses) {
                i += 5;
                Label label = new Label();
                label.Text = response.ToString();
                label.Left = 5;
                label.BackColor = Color.Transparent;
                label.Width = 300;
                label.Top = (txtReporting.Height + 1) + ((txtReporting.Height)*(responseToTextBox.Count + 1)) + i;
                Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Text = "NA";
                textBox.TextChanged += new EventHandler(DataChanged);
                textBox.Top = label.Top;
                textBox.Left = txtReporting.Left;
                textBox.Width = txtReporting.Width;
                // To Do: Find out why find by example does not work
//                ResponseValue example = new ResponseValue();
//                example.Response = response;
//                example.ContestCounty = contestCounty;

                IList<ResponseValue> values = responseValueDAO.find(response.ID, contestCounty.ID);

                ResponseValue value;

                if (values.Count == 0) {
                    value = new ResponseValue();
                    value.ContestCounty = contestCounty;
                    value.Response = response;
                    value.VoteCount = 0;
                } else {
                    value = values[values.Count - 1];
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