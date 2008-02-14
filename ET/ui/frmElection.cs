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
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmElection : BaseMDIChild {
        private readonly ElectionDAO electionDAO;
        private readonly IList<Contest> allContests;
        private readonly IList<Candidate> allCandidates;
        private readonly IList<County> allCounties;
        //private readonly ResponseDAO responseDAO;
        private readonly IList<ElectionContest> addedContests;

        private Election currentElection;
        private ElectionContest currentElectionContest;


        //To Do: Add support for double clicking to add or remove contests, candidates, counties, etc.
        //To Do: Add support to re-order the candidates and counties so they always appear in the order displayed on this screen.

        public frmElection(ElectionDAO electionDAO, ContestDAO contestDAO, CandidateDAO candidateDAO, CountyDAO countyDAO) {
            try {
                InitializeComponent();
                this.electionDAO = electionDAO;
                currentElection = new Election();
                allContests = contestDAO.findAll();
                allCandidates = candidateDAO.findAll();
                allCounties = countyDAO.findAll();
                addedContests = new List<ElectionContest>();

                refreshGoToList();
                refreshControls();
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
                Election newElection = electionDAO.findById(id.Value, false);
                if (newElection != null) {
                    currentElection = newElection;
                    refreshCandidateLists();
                    refreshContestLists();
                    refreshCountyLists();
                }
            }
            refreshControls();
        }

        private void refreshContestLists() {
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
        }

        private void refreshCountyLists() {
            Dictionary<County, int> mapCounts = new Dictionary<County, int>();

            object[] o = new object[2];
            int i;
            foreach (DataGridViewRow row in dgvCounties.Rows) {
                if (Int32.TryParse(row.Cells[1].Value.ToString(), out i)) {
                    mapCounts.Add(((County) row.Cells[0].Value), i);
                }
            }
            dgvCounties.Rows.Clear();
            foreach (County county in allCounties) {
                o[0] = county;

                if (mapCounts.TryGetValue(county, out i)) {
                    o[1] = i;
                } else {
                    o[1] = county.WardCount;
                }
                dgvCounties.Rows.Add(o);
            }
            foreach (DataGridViewRow row in dgvContestCounties.Rows) {
                if (Int32.TryParse(row.Cells[1].Value.ToString(), out i)) {
                    ((ContestCounty) row.Cells[0].Value).WardCount = i;
                }
            }
            dgvContestCounties.Rows.Clear();

            if (currentElectionContest != null) {
                dgvContestCounties.Rows.Clear();
                List<ContestCounty> selectedCounties = new List<ContestCounty>(currentElectionContest.Counties);
                selectedCounties.Sort(new ContestCountyComparer());

                foreach (ContestCounty contestCounty in selectedCounties) {
                    o[0] = contestCounty;
                    o[1] = contestCounty.WardCount;
                    dgvContestCounties.Rows.Add(o);
                    foreach (DataGridViewRow row in dgvCounties.Rows) {
                        if (((County) row.Cells[0].Value).ID == contestCounty.County.ID) {
                            dgvCounties.Rows.Remove(row);
                            break;
                        }
                    }
                }
            }
        }

        private class ContestCountyComparer : IComparer<ContestCounty> {
            public int Compare(ContestCounty x, ContestCounty y) {
                return x.County.Name.CompareTo(y.County.Name);
            }
        }

        private void refreshCandidateLists() {
            lstAllCandidates.Items.Clear();
            foreach (Candidate candidate in allCandidates) {
                lstAllCandidates.Items.Add(candidate);
            }

            lstContestCandidates.Items.Clear();

            if (currentElectionContest != null) {
                foreach (Response response in currentElectionContest.Responses) {
                    lstContestCandidates.Items.Add(response);
//                    for (int i = 0; i < lstDeletedResponses.Count; i++) {
//                        // sdegen 5-10-07 - Inheritance messes up Hibernate's persistence of 
//                        //  responses- mainly in deletions.  So we handle it manually now.
//                        if (lstDeletedResponses[i].GetType().Equals(typeof (CandidateResponse)) &&
//                            response.GetType().Equals(typeof (CandidateResponse))) {
//                            CandidateResponse cr;
//                            cr = (CandidateResponse) lstDeletedResponses[i];
//                            if (cr.Candidate.ID == ((CandidateResponse) response).Candidate.ID) {
//                                lstDeletedResponses.RemoveAt(i);
//                            }
//                        }
//                        if (lstDeletedResponses[i].GetType().Equals(typeof (CustomResponse)) &&
//                            response.GetType().Equals(typeof (CustomResponse))) {
//                            if (((CustomResponse) response).Description ==
//                                ((CustomResponse) lstDeletedResponses[i]).Description) {
//                                lstDeletedResponses.RemoveAt(i);
//                            }
//                        }
//                    }
//
                    if (response.GetType().Equals(typeof (CandidateResponse))) {
                        lstAllCandidates.Items.Remove(((CandidateResponse) response).Candidate);
                    }
                }
            }
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
//            foreach (Response r in lstDeletedResponses) {
//                responseDAO.Delete(r);
//            }
            refreshCountyLists();
            addedContests.Clear();
            foreach (ElectionContest ec in currentElection.ElectionContests) {
                foreach (Response r in ec.Responses) {
                    r.SortOrder = ec.Responses.IndexOf(r);
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
                }
                //lstDeletedResponses.Clear();
            } catch (Exception ex) {
                reportException("btnSave_Click", ex);
            }
        }


        public override void btnReset_Click(object sender, EventArgs e) {
            try {
                resetControls();
                base.btnReset_Click(sender, e);
            } catch (Exception ex) {
                reportException("btnReset_Click", ex);
            }
        }

        private void resetControls() {
            chkActive.Checked = currentElection.IsActive;
            dtpDate.Value = currentElection.Date;
            txtNotes.Text = currentElection.Notes;

            resetContestLists();
            refreshCountyLists();
            refreshCandidateLists();
        }

        private void resetContestLists() {
            lstElectionContests.Items.Clear();
            lstContestCandidate.Items.Clear();
            lstContestCandidate.Items.Clear();
            lstAllContests.Items.Clear();

            foreach (Contest contest in allContests) {
                lstAllContests.Items.Add(contest);
            }

            IList<ElectionContest> removeList = new List<ElectionContest>();
            foreach (ElectionContest electionContest in currentElection.ElectionContests) {
                if (!addedContests.Contains(electionContest)) {
                    lstElectionContests.Items.Add(electionContest);
                    lstContestCandidate.Items.Add(electionContest);
                    lstContestCounty.Items.Add(electionContest);
                    lstAllContests.Items.Remove(electionContest.Contest);

                    int removeAt = 0;
                    foreach (Contest c in lstAllContests.Items) {
                        if (c.Name == electionContest.Contest.Name)
                            removeAt = lstAllContests.Items.IndexOf(c);
                    }
                    lstAllContests.Items.RemoveAt(removeAt);
                } else {
                    removeList.Add(electionContest);
                }
            }

            foreach (ElectionContest ec in removeList) {
                currentElection.ElectionContests.Remove(ec);
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
                    addedContests.Add(electionContest);
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
                        addedContests.Add(electionContest);
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
                if (currentElectionContest != null) {
                    foreach (DataGridViewRow row in dgvCounties.SelectedRows) {
                        County county;
                        county = (County) row.Cells[0].Value;
                        ContestCounty contestCounty;
                        contestCounty = new ContestCounty();
                        contestCounty.ElectionContest = currentElectionContest;
                        contestCounty.County = county;
                        int i;
                        if (Int32.TryParse(row.Cells[1].Value.ToString(), out i)) {
                            contestCounty.WardCount = i;
                        } else {
                            contestCounty.WardCount = 0;
                        }
                        contestCounty.WardsReporting = 0;
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

        private void llstContestCandidate_SelectedIndexChanged(object sender, EventArgs e) {
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

        private void frmElection_Resize(object sender, EventArgs e) {
            try {
                tbDisplay.Height = Height - 76;
            } catch (Exception ex) {
                reportException("frmElection_Resize", ex);
            }
        }

        private void btnResponseUp_Click(object sender, EventArgs e) {
            try {
                Object o = lstContestCandidates.SelectedItem;
                int ind = lstContestCandidates.SelectedIndex;
                if (ind > 0) {
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
    }
}