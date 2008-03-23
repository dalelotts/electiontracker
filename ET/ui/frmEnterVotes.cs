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
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;
using KnightRider.ElectionTracker.db.task;
using KnightRider.ElectionTracker.ui.util;
using KnightRider.ElectionTracker.util;

namespace KnightRider.ElectionTracker.ui {
    internal partial class frmEnterVotes : BaseMDIChild {

        private static readonly ContestCountyComparer CONTEST_COUNTY_COMPARER = new ContestCountyComparer();

        private Map<long, VoteEnterer> countyIDToVoteEnterer;
        private readonly IElectionDAO electionDAO;
        private readonly IContestCountyDAO contestCountyDAO;
        private readonly IDAOTask<Election> loadTask;
        private Map<long, County> countyIDToCounty;
        private Map<long, IList<ContestCounty>> countyIDContestCounty;

        public frmEnterVotes(IElectionDAO electionDAO, IContestCountyDAO contestCountyDAO, IDAOTask<Election> loadTask) {
            this.electionDAO = electionDAO;
            this.contestCountyDAO = contestCountyDAO;
            this.loadTask = loadTask;
            InitializeComponent();
            countyIDToVoteEnterer = new Map<long, VoteEnterer>();
            countyIDToCounty = new Map<long, County>();
            countyIDContestCounty = new Map<long, IList<ContestCounty>>();
            toolStrip1.Visible = false;
        }

        public void HideCurrentVoteEnterer() {
            foreach (VoteEnterer enterer in countyIDToVoteEnterer.Values) {
                enterer.Visible = false;
                gbContest.Controls.Remove(enterer);
            }
        }

        private void frmEnterVotes_Load(object sender, EventArgs e) {
            try {
                LoadElections();
            } catch (Exception ex) {
                reportException("frmEnterVotes_Load", ex);
            }
        }

        // Loads the elections into the listbox.
        private void LoadElections() {
            IList<Election> elections = electionDAO.findActive(loadTask);
            foreach (Election election in elections) {
                cboElections.Items.Add(new ListItemWrapper<Election>(election.Date.ToString("d"), election));
            }
            if (elections.Count > 0) cboElections.SelectedIndex = 0;
        }

        private void cmbElections_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                loadElection(((ListItemWrapper<Election>) cboElections.SelectedItem).Value);
            } catch (Exception ex) {
                reportException("cboElections_SelectedIndexChanged", ex);
            }
        }

        private void loadElection(Election election) {
            HideCurrentVoteEnterer();
            countyIDToCounty.Clear();
            countyIDContestCounty.Clear();
            countyIDToVoteEnterer.Clear();

            for (int i = 0; i < election.ElectionContests.Count; i++) {
                ElectionContest electionContest = election.ElectionContests[i];
                for (int j = 0; j < electionContest.Counties.Count; j++) {
                    ContestCounty contestCounty = electionContest.Counties[j];
                    countyIDToCounty.Put(contestCounty.County.ID, contestCounty.County);
                    addElectionContestToMap(countyIDContestCounty, contestCounty.County.ID, contestCounty);
                }
            }

            foreach (KeyValuePair<long, IList<ContestCounty>> entry in countyIDContestCounty) {
                IList<ContestCounty> contestCounties = entry.Value;
                
                ((List<ContestCounty>) contestCounties).Sort(CONTEST_COUNTY_COMPARER);
                
                VoteEnterer enterer = new VoteEnterer(contestCounties, contestCountyDAO);
                countyIDToVoteEnterer.Add(entry.Key, enterer);
            }

            refreshControls();
        }

        private class ContestCountyComparer : IComparer<ContestCounty> {
            public int Compare(ContestCounty x, ContestCounty y) {
                return x.ElectionContest.Contest.Name.CompareTo(y.ElectionContest.Contest.Name);
            }
        }

        private static void addElectionContestToMap<T, V>(Map<T, IList<V>> map, T key, V value) {
            IList<V> valueList = map.Get(key);
            if (valueList == null) valueList = new List<V>();
            valueList.Add(value);
            map.Put(key, valueList);
        }

        private void refreshControls() {
            refreshCountyListbox();
        }

        private void refreshCountyListbox() {
            lstCounties.Items.Clear();
            foreach (KeyValuePair<long, County> entry in countyIDToCounty) {
                lstCounties.Items.Add(entry.Value);
            }
            if (lstCounties.Items.Count > 0) lstCounties.SelectedIndex = 0;
        }

        private void lstCounties_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                County county = (County)lstCounties.SelectedItem;

                HideCurrentVoteEnterer();

                VoteEnterer enterer = countyIDToVoteEnterer.Get(county.ID);

                enterer.Location = new Point(10, 20);
                enterer.Width = gbContest.Width - 20;
                enterer.Height = btnSaveVotes.Location.Y - 30;

                gbContest.Controls.Add(enterer);
                enterer.Visible = true;
            } catch (Exception ex) {
                reportException("lstCounties_SelectedIndexChanged", ex);
            }
        }

        // This subclass displays a contest and its votes associated
        // with it for vote entry purposes.

        // This subclass is a GUI collection of ContestDisplays.

        private void btnNext_Click(object sender, EventArgs e) {
            try {
                // ToDo: prompt user with yes / no message box before moving to 
                // next county if enterer is dirty.

                if (lstCounties.SelectedIndex != lstCounties.Items.Count - 1) {
                    lstCounties.SelectedIndex++;
                } else {
                    lstCounties.SelectedIndex = 0;
                }
            } catch (Exception ex) {
                reportException("btnNext_Click", ex);
            }
        }

        private void btnSaveVotes_Click(object sender, EventArgs e) {
            try {
                List<string> result = new List<string>();
                foreach (VoteEnterer voteEnterer in countyIDToVoteEnterer.Values)
                {
                    result.AddRange(voteEnterer.Persist());
                }
                string message = "";
                foreach (string s in result) {
                    message += s + "\n";
                }
                MessageBox.Show(this, "The follow vote results were saved:\n" + message.Trim() , "Sucessful Save");
            } catch (Exception ex) {
                reportException("btnSaveVotes_Click", ex);
            }
        }
    }
}