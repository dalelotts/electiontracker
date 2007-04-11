using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui.util;
using edu.uwec.cs.cs355.group4.et.util;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmEnterVotes : Form {

        private Map<long , VoteEnterer> countyToVoteEnterer;
        private readonly ElectionDAO electionDAO;
        private readonly ContestCountyDAO contestCountyDAO;
        private readonly ResponseValueDAO responseValueDAO;


        public frmEnterVotes(ElectionDAO electionDAO, ContestCountyDAO contestCountyDAO, ResponseValueDAO responseValueDAO) {
            this.electionDAO = electionDAO;
            this.contestCountyDAO = contestCountyDAO;
            this.responseValueDAO = responseValueDAO;
            countyToVoteEnterer = new Map<long, VoteEnterer>();
            InitializeComponent();
        }

        public void HideCurrentVoteEnterer() {
            foreach (VoteEnterer enterer in countyToVoteEnterer.Values) {
                enterer.Visible = false;
            }
        }

        private void frmEnterVotes_Load(object sender, EventArgs e) {
            LoadElections();
        }

        // Loads the elections into the listbox.
        private void LoadElections() {
            IList<Election> elections = electionDAO.findActive();
            foreach (Election election in elections) {
                cmbElections.Items.Add(new ListItemWrapper<Election>(election.Date.ToString(), election));
            }
            if (elections.Count > 0) cmbElections.SelectedIndex = 0;
        }

        private void cmbElections_SelectedIndexChanged(object sender, EventArgs e) {
            LoadCounties(((ListItemWrapper<Election>) cmbElections.SelectedItem).Value);
        }

        private void LoadCounties(Election election) {
            lstCounties.Items.Clear();
            IDictionary<long, County> counties = new Dictionary<long, County>();

            IList<ElectionContest> electionContests = election.ElectionContests;
            foreach (ElectionContest contest in electionContests) {
                IList<ContestCounty> contestCounties = contest.Counties;
                foreach (ContestCounty county in contestCounties) {
                    if (!counties.ContainsKey(county.County.ID)) {
                        counties.Add(county.County.ID, county.County);
                    }
                }
            }

            foreach (KeyValuePair<long, County> county in counties) {
                lstCounties.Items.Add(new ListItemWrapper<County>(county.Value.Name, county.Value));
            }
            if (lstCounties.Items.Count > 0) lstCounties.SelectedIndex = 0;
        }

        private void lstCounties_SelectedIndexChanged(object sender, EventArgs e) {
            Election election = ((ListItemWrapper<Election>) cmbElections.SelectedItem).Value;
            County county = ((ListItemWrapper<County>) lstCounties.SelectedItem).Value;
            
            HideCurrentVoteEnterer();

            VoteEnterer enterer = countyToVoteEnterer.Get(county.ID);

            if (enterer == null) {
                enterer = new VoteEnterer(election, county, contestCountyDAO, responseValueDAO);
                enterer.Height = gbContest.Height - 60;
                enterer.Top = 18;
                enterer.Left = 6;
                enterer.Width = gbContest.Width - 10;               
                countyToVoteEnterer.Put(county.ID, enterer);
                gbContest.Controls.Add(enterer);
            }

            enterer.Visible = true;
        }

        // This subclass displays a contest and its votes associated
        // with it for vote entry purposes.

        // This subclass is a GUI collection of ContestDisplays.

        private void btnNext_Click(object sender, EventArgs e) {
            // ToDo: prompt user with yes / no message box before moving to 
            // next county if enterer is dirty.

            if (lstCounties.SelectedIndex != lstCounties.Items.Count - 1) {
                lstCounties.SelectedIndex++;
            } else {
                lstCounties.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            // TODO: Save contest information.
            foreach (VoteEnterer voteEnterer in countyToVoteEnterer.Values) {
                voteEnterer.Persist();
            } // foreach(VoteEnterer...
        }

        private void frmEnterVotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            responseValueDAO.flush();
            contestCountyDAO.flush();
            electionDAO.flush();
        } // btnSave_Click();
    }
}