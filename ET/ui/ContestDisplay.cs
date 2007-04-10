using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.util;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal sealed class ContestDisplay : Panel {
        private ContestCounty contestCounty;
        private readonly ContestCountyDAO contestCountyDAO;
        private ResponseValueDAO responseValueDAO;
        
        private TextBox txtReporting;
        private Boolean _bDirty;
        private readonly Map<ResponseValue, TextBox> responseToTextBox;


        public ContestDisplay(long countyID, long electionContestID, ContestCountyDAO contestCountyDAO,
                              ResponseValueDAO responseValueDAO) {
            this.responseValueDAO = responseValueDAO;
            this.contestCountyDAO = contestCountyDAO;

            Width = 450;
            BorderStyle = BorderStyle.FixedSingle;
            Visible = true;

            IList<ContestCounty> contestCounties = contestCountyDAO.find(countyID, electionContestID);

            if (contestCounties.Count != 1)
                throw new ArgumentException("County is not a member of this contest", "countyID");

            contestCounty = contestCounties[0];

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
            contestCounty.WardsReporting = int.Parse(txtReporting.Text);
            contestCountyDAO.makePersistent(contestCounty);

            foreach (KeyValuePair<ResponseValue, TextBox> entry in responseToTextBox) {
                ResponseValue responseValue = entry.Key;
                TextBox textBox = entry.Value;
                responseValue.VoteCount = int.Parse(textBox.Text);
                responseValueDAO.makePersistent(responseValue);
            }
            Dirty = false;
        }

        private void InitializeResponses(IList<Response> responses) {
            IList<string> excluded = new List<string>();
            excluded.Add("ID");
            excluded.Add("VoteCount");

            foreach (Response response in responses) {
                Label label = new Label();
                label.Text = response.ToString();
                label.Left = 5;
                label.Width = 300; 
                label.Top = (txtReporting.Height + 1) + ((txtReporting.Height) * (responseToTextBox.Count + 1));
                Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Text = "NA";
                textBox.TextChanged += new EventHandler(DataChanged);
                textBox.Top = label.Top;
                textBox.Left = txtReporting.Left;
                textBox.Width = txtReporting.Width;

                ResponseValue example = new ResponseValue();
                example.Response = response;
                example.ContestCounty = contestCounty;

                IList<ResponseValue> values = responseValueDAO.findByExample(example, excluded);

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