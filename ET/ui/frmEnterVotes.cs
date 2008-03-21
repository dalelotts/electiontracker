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
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;
using KnightRider.ElectionTracker.db.task;
using KnightRider.ElectionTracker.ui.util;
using KnightRider.ElectionTracker.util;

namespace KnightRider.ElectionTracker.ui {
    internal partial class frmEnterVotes : BaseMDIChild {
        private Map<String, VoteEnterer> countyToVoteEnterer;
        private readonly IElectionDAO electionDAO;
        private readonly IContestCountyDAO contestCountyDAO;
        private readonly ResponseValueDAO responseValueDAO;
        private readonly LoadElectionForUI loadElectionForUI;

        public frmEnterVotes(IElectionDAO electionDAO, IContestCountyDAO contestCountyDAO,
                             ResponseValueDAO responseValueDAO, LoadElectionForUI loadElectionForUI) {
            this.electionDAO = electionDAO;
            this.contestCountyDAO = contestCountyDAO;
            this.responseValueDAO = responseValueDAO;
            this.loadElectionForUI = loadElectionForUI;
            countyToVoteEnterer = new Map<String, VoteEnterer>();
            InitializeComponent();
            toolStrip1.Visible = false;
        }

        public void HideCurrentVoteEnterer() {
            foreach (VoteEnterer enterer in countyToVoteEnterer.Values) {
                enterer.Visible = false;
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
            IList<Election> elections = electionDAO.findActive(loadElectionForUI);
            foreach (Election election in elections) {
                cmbElections.Items.Add(new ListItemWrapper<Election>(election.Date.ToString("d"), election));
            }
            if (elections.Count > 0) cmbElections.SelectedIndex = 0;
        }

        private void cmbElections_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                LoadCounties(((ListItemWrapper<Election>) cmbElections.SelectedItem).Value);
            } catch (Exception ex) {
                reportException("cmbElections_SelectedIndexChanged", ex);
            }
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
            try {
                Election election = ((ListItemWrapper<Election>) cmbElections.SelectedItem).Value;
                County county = ((ListItemWrapper<County>) lstCounties.SelectedItem).Value;

                HideCurrentVoteEnterer();

                VoteEnterer enterer = countyToVoteEnterer.Get("" + election.ID + "_" + county.ID);

                if (enterer == null) {
                    enterer = new VoteEnterer(election, county, contestCountyDAO, responseValueDAO);
                    enterer.Height = gbContest.Height - 60;
                    enterer.Top = 18;
                    enterer.Left = 6;
                    enterer.Width = gbContest.Width - 10;
                    countyToVoteEnterer.Put("" + election.ID + "_" + county.ID, enterer);
                    gbContest.Controls.Add(enterer);
                }

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
                // TODO: Save contest information.
                foreach (VoteEnterer voteEnterer in countyToVoteEnterer.Values) {
                    voteEnterer.Persist();
                } // foreach(VoteEnterer...
            } catch (Exception ex) {
                reportException("btnSaveVotes_Click", ex);
            }
        }

        private void frmEnterVotes_Resize(object sender, EventArgs e) {
            try {
                gbCounty.Height = Height - 117;
                gbContest.Height = Height - 117;
                btnNext.Top = gbCounty.Height - 30;
                btnSaveVotes.Top = gbContest.Height - 30;
                gbContest.Width = Width - 231;
                btnSaveVotes.Left = gbContest.Width - 81;
                lstCounties.Height = gbCounty.Height - 60;

                // Resize vote enterer.
                foreach (String k in countyToVoteEnterer.Keys) {
                    countyToVoteEnterer.Get(k).Height = gbContest.Height - 60;
                    countyToVoteEnterer.Get(k).Width = gbContest.Width - 10;
                }
            } catch (Exception ex) {
                reportException("frmEnterVotes_Resize", ex);
            }
        }
    }
}