using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal sealed class ContestDisplay : Panel {

        private ContestCounty contestCounty;
        private readonly ContestCountyDAO contestCountyDAO;        
        private ResponseValueDAO responseValueDAO;
        private Label lblContest;
        private TextBox txtReporting;
        private Boolean _bDirty;
        private readonly IList<ResponseValue> responseValues;


        public ContestDisplay(ContestCounty contestCounty, ContestCountyDAO contestCountyDAO, ResponseValueDAO responseValueDAO) {
            this.responseValueDAO = responseValueDAO;
            
            this.contestCounty = contestCounty;
            this.contestCountyDAO = contestCountyDAO;

            lblContest = new Label();
            txtReporting = new TextBox();
            Width = 385;
            txtReporting.Left = Width - 55;
            txtReporting.Width = 30;
            BorderStyle = BorderStyle.FixedSingle;
            Visible = true;
            txtReporting.Text = contestCounty.WardsReporting.ToString();
            Controls.Add(txtReporting);
            lblContest.Width = 300;
            lblContest.Text = contestCounty.ElectionContest.Contest.Name;
            Controls.Add(lblContest);

            IList<Response> responses = contestCounty.ElectionContest.Responses;
            responseValues = new List<ResponseValue>(responses.Count);
            InitializeResponses(responses);
            Dirty = false;
        }


        public Boolean Dirty
        {
            get { return _bDirty; }
            set { _bDirty = value; }
        }

        public void Persist()
        {

            contestCounty.WardsReporting = int.Parse(txtReporting.Text);
            contestCountyDAO.makePersistent(contestCounty);

            foreach (ResponseValue value in responseValues) {
                responseValueDAO.makePersistent(value);
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
                label.Top = (lblContest.Height + 1) + ((lblContest.Height) * (responseValues.Count + 1));
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
                responseValues.Add(value);
                textBox.Text = value.VoteCount.ToString();
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