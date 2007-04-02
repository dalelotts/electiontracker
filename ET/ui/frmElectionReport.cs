using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmElectionReport : Form {
        public frmElectionReport(ElectionDAO electionDAO) {
            InitializeComponent();

            IList<Election> elections = electionDAO.findActive();
            foreach (Election election in elections) {
                rtbElectionReport.AppendText(election.Date.ToShortDateString() + "\n");

                IList<ElectionContest> electionContests = election.ElectionContests;

                foreach (ElectionContest electionContest in electionContests) {
                    rtbElectionReport.AppendText("   " + electionContest.Contest.Name + "\n");

                    IList<Response> responses = electionContest.Responses;

                    foreach (Response response in responses) {
                        rtbElectionReport.AppendText("      " + response + "   _____________ \n");
                    }

                    rtbElectionReport.AppendText("\n");
                }

                rtbElectionReport.AppendText("\n");
            }
            rtbElectionReport.AppendText("\n");
        }

        private void frmElectionReport_Load(object sender, EventArgs e) {}

        private void btnPrint_Click(object sender, EventArgs e) {
            PrintReport pr = new PrintReport();
            pr.print(rtbElectionReport.Text);
        }
    }
}