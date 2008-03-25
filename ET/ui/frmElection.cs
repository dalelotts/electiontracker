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
using System.Windows.Forms;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;
using KnightRider.ElectionTracker.db.task;
using KnightRider.ElectionTracker.util;

namespace KnightRider.ElectionTracker.ui {
    internal partial class frmElection : BaseMDIChild {
        private static readonly ContestCountyComparer BY_COUNTY_NAME = new ContestCountyComparer(false);

        private readonly IDAOTask<Election> loadTask;
        private readonly IElectionDAO electionDAO;
        private readonly IList<Contest> allContests;
        private readonly IList<Candidate> allCandidates;
        private readonly IList<County> allCounties;

        private Election currentElection;
        private ElectionContest currentElectionContest;


        //To Do: Add support for double clicking to add or remove contests, candidates, counties, etc.
        //To Do: Add support to re-order the candidates and counties so they always appear in the order displayed on this screen.


        public frmElection(IElectionDAO electionDAO, IContestDAO contestDAO, ICandidateDAO candidateDAO, ICountyDAO countyDAO, IDAOTask<Election> loadTask) {
            try {
                InitializeComponent();
                this.electionDAO = electionDAO;
                this.loadTask = loadTask;
                currentElection = new Election();
                allContests = contestDAO.findAll();
                allCandidates = candidateDAO.findAll();
                allCounties = countyDAO.findAll();
            } catch (Exception ex) {
                reportException("frmElection constructor", ex);
            }
        }

        private void refreshControls() {
            chkActive.Checked = currentElection.IsActive;
            dtpDate.Value = currentElection.Date;
            txtNotes.Text = currentElection.Notes;
            refreshContestLists();
            refreshCountyLists();
            refreshCandidateLists();
            refreshGoToList();
        }

        private void refreshGoToList() {
            IList<Election> elections = electionDAO.findAll();
            cboGoTo.Items.Clear();
            foreach (Election election in elections) {
                cboGoTo.Items.Add(election);
            }
        }

        public void loadElection(long? id) {
            if (id != null) {
                Election newElection = electionDAO.findById(id.Value, false, loadTask);
                if (newElection != null) {
                    currentElection = newElection;
                }
            }
            refreshControls();
        }

        private void refreshContestLists() {
            lstElectionContests.BeginUpdate();
            lstContestCandidate.BeginUpdate();
            lstContestCounty.BeginUpdate();
            lstAllContests.BeginUpdate();

            lstElectionContests.Items.Clear();
            lstContestCandidate.Items.Clear();
            lstContestCounty.Items.Clear();
            lstAllContests.Items.Clear();

            foreach (Contest contest in allContests) {
                lstAllContests.Items.Add(contest);
            }

            foreach (ElectionContest electionContest in currentElection.ElectionContests) {
                lstElectionContests.Items.Add(electionContest);
                lstContestCandidate.Items.Add(electionContest);
                lstContestCounty.Items.Add(electionContest);
                lstAllContests.Items.Remove(electionContest.Contest);
            }

            lstAllContests.EndUpdate();
            lstContestCounty.EndUpdate();
            lstContestCandidate.EndUpdate();
            lstElectionContests.EndUpdate();
        }

        private void refreshCountyLists() {
            lstAllCounties.Items.Clear();
            dgvContestCounties.Rows.Clear();

            foreach (County county in allCounties) {
                lstAllCounties.Items.Add(county);
            }

            if (currentElectionContest != null) {
                List<ContestCounty> selectedCounties = new List<ContestCounty>(currentElectionContest.Counties);

                selectedCounties.Sort(BY_COUNTY_NAME);

                foreach (ContestCounty contestCounty in selectedCounties) {
                    DataGridViewTextBoxCell countyCell = new DataGridViewTextBoxCell();
                    countyCell.Value = contestCounty;

                    DataGridViewTextBoxCell wardCountCell = new DataGridViewTextBoxCell();
                    wardCountCell.Value = contestCounty.WardCount;
                    wardCountCell.Tag = contestCounty.WardCount;

                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(countyCell);
                    row.Cells.Add(wardCountCell);

                    dgvContestCounties.Rows.Add(row);
                    lstAllCounties.Items.Remove(contestCounty.County);
                }
            }
        }

        private void refreshCandidateLists() {
            lstAllCandidates.BeginUpdate();
            lstContestCandidates.BeginUpdate();

            lstAllCandidates.Items.Clear();
            foreach (Candidate candidate in allCandidates) {
                lstAllCandidates.Items.Add(candidate);
            }

            lstContestCandidates.Items.Clear();

            if (currentElectionContest != null) {
                foreach (Response response in currentElectionContest.Responses) {
                    lstContestCandidates.Items.Add(response);
                    if (response is CandidateResponse) {
                        lstAllCandidates.Items.Remove(((CandidateResponse) response).Candidate);
                    }
                }
            }
            lstContestCandidates.EndUpdate();
            lstAllCandidates.EndUpdate();
        }

        public override void btnAdd_Click(object sender, EventArgs e) {
            try {
                currentElection = new Election();
                refreshControls();
                base.btnAdd_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnAdd_Click", ex);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            refreshCountyLists();

            foreach (ElectionContest electionContest in currentElection.ElectionContests) {
                foreach (Response response in electionContest.Responses) {
                    response.SortOrder = electionContest.Responses.IndexOf(response);
                }
            }
            try {
                currentElection.IsActive = chkActive.Checked;
                currentElection.Date = dtpDate.Value;
                currentElection.Notes = txtNotes.Text;

                IList<Fault> faults = electionDAO.canMakePersistent(currentElection);
                bool persistData = reportFaults(faults);

                //If there were no errors, persist data to the database
                if (persistData) {
                    currentElection = electionDAO.makePersistent(currentElection);
                    refreshControls();
                    raiseMakePersistentEvent();
                    MessageBox.Show(this, currentElection + " election saved.", "Sucessful Save");
                }
            } catch (Exception ex) {
                reportException("btnSave_Click", ex);
            }
        }


        public override void btnReset_Click(object sender, EventArgs e) {
            try {
                currentElection = currentElection.ID == 0 ? new Election() : electionDAO.findById(currentElection.ID, false, loadTask);
                currentElectionContest = null;
                refreshControls();
                base.btnReset_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnReset_Click", ex);
            }
        }


        public override void btnDelete_Click(object sender, EventArgs e) {
            try {
                IList<Fault> faults = electionDAO.canMakeTransient(currentElection);
                if (reportFaults(faults)) {
                    electionDAO.makeTransient(currentElection);
                    currentElection = new Election();
                    refreshControls();
                    raiseMakeTransientEvent();
                }
            } catch (Exception ex) {
                reportException("btnDelete_Click", ex);
            }
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                currentElection = (Election) cboGoTo.SelectedItem;
                refreshControls();
                base.cboGoTo_SelectedIndexChanged(sender, e);
            } catch (Exception ex) {
                reportException("cboGoTo_SelectedIndexChanged", ex);
            }
        }

        private void btnAddAllContests_Click(object sender, EventArgs e) {
            try {
                currentElection.ElectionContests = new List<ElectionContest>(allContests.Count);
                foreach (Contest contest in allContests) {
                    ElectionContest electionContest = makeElectionContest(contest);
                    currentElection.ElectionContests.Add(electionContest);
                }
                refreshContestLists();
            } catch (Exception ex) {
                reportException("btnAddAllContests_Click", ex);
            }
        }

        private ElectionContest makeElectionContest(Contest contest) {
            ElectionContest electionContest = new ElectionContest();
            electionContest.Election = currentElection;
            electionContest.Contest = contest;
            electionContest.Counties = new List<ContestCounty>(allCounties.Count);
            electionContest.Responses = new List<Response>(allCandidates.Count);
            return electionContest;
        }

        private void btnAddContest_Click(object sender, EventArgs e) {
            try {
                ListBox.SelectedObjectCollection selectedItems = lstAllContests.SelectedItems;

                if (selectedItems.Count > 0) {
                    foreach (Contest contest in selectedItems) {
                        ElectionContest electionContest = makeElectionContest(contest);
                        currentElection.ElectionContests.Add(electionContest);
                    }

                    refreshContestLists();
                }
            } catch (Exception ex) {
                reportException("btnAddContest_Click", ex);
            }
        }

        private void btnRemoveContest_Click(object sender, EventArgs e) {
            try {
                ListBox.SelectedObjectCollection selectedtems = lstElectionContests.SelectedItems;

                if (selectedtems.Count > 0) {
                    foreach (ElectionContest electionContest in selectedtems) {
                        currentElection.ElectionContests.Remove(electionContest);
                    }
                    refreshContestLists();
                }
            } catch (Exception ex) {
                reportException("btnRemoveContest_Click", ex);
            }
        }

        private void btnRemoveAllContests_Click(object sender, EventArgs e) {
            try {
                if (currentElection.ElectionContests.Count > 0) {
                    currentElection.ElectionContests = new List<ElectionContest>(allContests.Count);
                    refreshContestLists();
                }
            } catch (Exception ex) {
                reportException("btnRemoveAllContests_Click", ex);
            }
        }

        private void btnAddAllCandidates_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    foreach (Candidate candidate in allCandidates) {
                        CandidateResponse candidateResponse = new CandidateResponse();
                        candidateResponse.Candidate = candidate;
                        candidateResponse.ElectionContest = currentElectionContest;
                        currentElectionContest.Responses.Add(candidateResponse);
                    }
                    refreshCandidateLists();
                }
            } catch (Exception ex) {
                reportException("btnAddAllCandidates_Click", ex);
            }
        }

        private void btnAddCandidate_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    ListBox.SelectedObjectCollection selectedItems = lstAllCandidates.SelectedItems;
                    if (selectedItems.Count > 0) {
                        foreach (Candidate candidate in selectedItems) {
                            CandidateResponse candidateResponse = new CandidateResponse();
                            candidateResponse.Candidate = candidate;
                            candidateResponse.ElectionContest = currentElectionContest;
                            currentElectionContest.Responses.Add(candidateResponse);
                        }
                        refreshCandidateLists();
                    }
                }
            } catch (Exception ex) {
                reportException("btnAddCandidate_Click", ex);
            }
        }

        private void btnRemoveCandidate_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    ListBox.SelectedObjectCollection selectedItems = lstContestCandidates.SelectedItems;
                    if (selectedItems.Count > 0) {
                        foreach (Response response in selectedItems) {
                            currentElectionContest.Responses.Remove(response);
                            //lstDeletedResponses.Add(response);
                        }
                        refreshCandidateLists();
                    }
                }
            } catch (Exception ex) {
                reportException("btnRemoveCandidate_Click", ex);
            }
        }

        private void btnRemoveAllCandidates_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    currentElectionContest.Responses = new List<Response>(allCandidates.Count);
                    refreshCandidateLists();
                }
            } catch (Exception ex) {
                reportException("btnRemoveAllCandidates_Click", ex);
            }
        }

        private void btnAddAllCounties_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    foreach (County county in allCounties) {
                        ContestCounty contestCounty = new ContestCounty();
                        contestCounty.ElectionContest = currentElectionContest;
                        contestCounty.County = county;
                        contestCounty.WardCount = county.WardCount;
                        contestCounty.WardsReporting = 0;
                        currentElectionContest.Counties.Add(contestCounty);
                    }
                    refreshCountyLists();
                }
            } catch (Exception ex) {
                reportException("btnAddAllCounties_Click", ex);
            }
        }

        private void btnAddCounty_Click(object sender, EventArgs e) {
            try {
                ListBox.SelectedObjectCollection counties = lstAllCounties.SelectedItems;
                if (counties.Count > 0) {
                    foreach (County county in counties) {
                        ContestCounty contestCounty = new ContestCounty();
                        contestCounty.ElectionContest = currentElectionContest;
                        contestCounty.County = county;
                        contestCounty.WardCount = county.WardCount;
                        currentElectionContest.Counties.Add(contestCounty);
                    }
                    refreshCountyLists();
                }
            } catch (Exception ex) {
                reportException("btnAddCounty_Click", ex);
            }
        }

        private void btnRemoveCounty_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    if (dgvContestCounties.SelectedRows.Count > 0) {
                        foreach (DataGridViewRow row in dgvContestCounties.SelectedRows) {
                            currentElectionContest.Counties.Remove((ContestCounty) row.Cells[0].Value);
                        }
                        refreshCountyLists();
                    }
                }
            } catch (Exception ex) {
                reportException("btnRemoveCounty_Click", ex);
            }
        }

        private void btnRemoveAllCounties_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    currentElectionContest.Counties = new List<ContestCounty>(allCounties.Count);
                    refreshCountyLists();
                }
            } catch (Exception ex) {
                reportException("btnRemoveAllCounties_Click", ex);
            }
        }

        private void lstContestCandidate_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                currentElectionContest = (ElectionContest) lstContestCandidate.SelectedItem;
                refreshCandidateLists();
            } catch (Exception ex) {
                reportException("lstElectionContestsDetails_SelectedIndexChanged", ex);
            }
        }

        private void btnAddCustomResponse_Click(object sender, EventArgs e) {
            try {
                string text = txtCustomResponse.Text;
                if (text != null && text.Length > 0) {
                    // To Do: Validate response text does not already exist.
                    CustomResponse response = new CustomResponse();
                    response.Description = text;
                    response.ElectionContest = currentElectionContest;
                    currentElectionContest.Responses.Add(response);
                    txtCustomResponse.Text = null;
                    refreshCandidateLists();
                }
            } catch (Exception ex) {
                reportException("btnAddCustomResponse_Click", ex);
            }
        }

        private void btnResponseUp_Click(object sender, EventArgs e) {
            try {
                int ind = lstContestCandidates.SelectedIndex;
                if (ind > 0) {
                    Object o = lstContestCandidates.SelectedItem;
                    lstContestCandidates.Items.RemoveAt(ind);
                    lstContestCandidates.Items.Insert(ind - 1, o);
                    lstContestCandidates.SelectedIndex = ind - 1;
                    int ind2 = currentElectionContest.Responses.IndexOf((Response) o);
                    currentElectionContest.Responses.RemoveAt(ind2);
                    currentElectionContest.Responses.Insert(ind2 - 1, (Response) o);
                }
            } catch (Exception ex) {
                reportException("btnResponseUp_Click", ex);
            }
        }

        private void btnResponseDown_Click(object sender, EventArgs e) {
            try {
                Object o = lstContestCandidates.SelectedItem;
                int ind = lstContestCandidates.SelectedIndex;
                if (ind < lstContestCandidates.Items.Count - 1) {
                    lstContestCandidates.Items.RemoveAt(ind);
                    lstContestCandidates.Items.Insert(ind + 1, o);
                    lstContestCandidates.SelectedIndex = ind + 1;
                    int ind2 = currentElectionContest.Responses.IndexOf((Response) o);
                    currentElectionContest.Responses.RemoveAt(ind2);
                    currentElectionContest.Responses.Insert(ind2 + 1, (Response) o);
                }
            } catch (Exception ex) {
                reportException("btnResponseDown_Click", ex);
            }
        }

        private void lstContestCounty_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                currentElectionContest = (ElectionContest) lstContestCounty.SelectedItem;
                refreshCountyLists();
            } catch (Exception ex) {
                reportException("lstElectionContestsDetails_SelectedIndexChanged", ex);
            }
        }

        private void btnSetIncumbent_Click(object sender, EventArgs e) {
            Response incumbent = (Response) lstContestCandidates.SelectedItem;
            if (incumbent != null && !incumbent.IsIncumbent) {
                foreach (Response response in lstContestCandidates.Items) {
                    if (response.IsIncumbent) response.IsIncumbent = false;
                }
                incumbent.IsIncumbent = true;
                refreshCandidateLists();
            }
        }

        private void dgvContestCounties_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            DataGridViewRow row = dgvContestCounties.CurrentRow;

            DataGridViewCell wardCell = row.Cells["wardCountColumn"];
            object wardValue = wardCell.Value;
            int wardCount;
            if (int.TryParse(wardValue.ToString(), out wardCount)) {
                DataGridViewCell countyCell = row.Cells["countyColumn"];
                ContestCounty contestCounty = (ContestCounty) countyCell.Value;
                contestCounty.WardCount = wardCount;
                wardCell.Tag = wardCount;
            } else {
                MessageBox.Show(this, "Ward count must be a number. " + wardValue + " is not a valid number.", "Invalid ward count");
                wardCell.Value = wardCell.Tag;
            }
        }
    }
}