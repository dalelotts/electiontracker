using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.events;
using log4net;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmElection : BaseMDIChild {

        public event GenericEventHandler<Object, ShowErrorMessageArgs> showErrorMessage;

        private static readonly ILog LOG = LogManager.GetLogger(typeof (frmElection));

        private readonly ElectionDAO electionDAO;

        private readonly IList<Contest> allContests;
        private readonly IList<Candidate> allCandidates;
        private readonly IList<County> allCounties;

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
                refreshContestLists();

                allCandidates = candidateDAO.findAll();
                refreshCandidateLists();

                allCounties = countyDAO.findAll();
                refreshCountyLists();

            } catch (Exception ex) {
                string message = "Encountered exception in frmElection constructor";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        public void loadElection(long? id) {
            if (id != null) {
                Election newElection = electionDAO.findById(id, false);
                if (newElection != null) {
                    currentElection = new Election();
                    refreshCandidateLists();
                    refreshContestLists();
                    refreshCountyLists();
                }
            }
        }

        private void refreshContestLists() {
            lstElectionContests.Items.Clear();
            lstElectionContestsDetails.Items.Clear();
            lstAllContests.Items.Clear();

            foreach (Contest contest in allContests) {
                lstAllContests.Items.Add(contest);
            }

            foreach (ElectionContest electionContest in currentElection.ElectionContests) {
                lstElectionContests.Items.Add(electionContest);
                lstElectionContestsDetails.Items.Add(electionContest);
                lstAllContests.Items.Remove(electionContest.Contest);
            }
        }

        private void refreshCountyLists() {
            lstAllCounties.Items.Clear();
            foreach (County county in allCounties) {
                lstAllCounties.Items.Add(county);
            }

            lstContestCounties.Items.Clear();

            if (currentElectionContest != null) {
                foreach (ContestCounty contestCounty in currentElectionContest.Counties) {
                    lstContestCounties.Items.Add(contestCounty);
                    lstAllCounties.Items.Remove(contestCounty.County);
                }
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

                    if (response.GetType().Equals(typeof (CandidateResponse))) {
                        lstAllCandidates.Items.Remove(((CandidateResponse) response).Candidate);
                    }
                }
            }
        }

        private void btnElectionSave_Click(object sender, EventArgs e) {
            try {
                currentElection.IsActive = chkActive.Checked;
                currentElection.Date = dtpDate.Value;
                currentElection.Notes = txtNotes.Text;
                electionDAO.makePersistent(currentElection);

            } catch (Exception ex) {
                string message = "Encountered exception in btnElectionSave_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
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
                string message = "Encountered exception in btnAddAllContests_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
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
                string message = "Encountered exception in btnAddContest_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
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
                string message = "Encountered exception in btnRemoveContest_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void btnRemoveAllContests_Click(object sender, EventArgs e) {
            try {
                if (currentElection.ElectionContests.Count > 0) {
                    currentElection.ElectionContests = new List<ElectionContest>(allContests.Count);
                    refreshContestLists();
                }
            } catch (Exception ex) {
                string message = "Encountered exception in btnRemoveAllContests_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
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
                string message = "Encountered exception in btnAddAllCandidates_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
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
                string message = "Encountered exception in btnAddCandidate_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void btnRemoveCandidate_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    ListBox.SelectedObjectCollection selectedItems = lstContestCandidates.SelectedItems;
                    if (selectedItems.Count > 0) {
                        foreach (Response response in selectedItems) {
                            currentElectionContest.Responses.Remove(response);
                        }
                        refreshCandidateLists();
                    }
                }
            } catch (Exception ex) {
                string message = "Encountered exception in btnRemoveCandidate_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void btnRemoveAllCandidates_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    currentElectionContest.Responses = new List<Response>(allCandidates.Count);
                    refreshCandidateLists();
                }
            } catch (Exception ex) {
                string message = "Encountered exception in btnRemoveAllCandidates_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
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
                string message = "Encountered exception in btnAddAllCounties_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void btnAddCounty_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    foreach (County county in lstAllCounties.SelectedItems) {
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
                string message = "Encountered exception in btnAddCounty_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void btnRemoveCounty_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    ListBox.SelectedObjectCollection selectedItems = lstContestCounties.SelectedItems;
                    if (selectedItems.Count > 0) {
                        foreach (ContestCounty contestCounty in selectedItems) {
                            currentElectionContest.Counties.Remove(contestCounty);                            
                        }
                        refreshCountyLists();
                    }
                }
            } catch (Exception
                ex) {
                string message = "Encountered exception in btnRemoveCounty_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void btnRemoveAllCounties_Click(object sender, EventArgs e) {
            try {
                if (currentElectionContest != null) {
                    currentElectionContest.Counties = new List<ContestCounty>(allCounties.Count);
                    refreshCountyLists();
                }
            } catch (Exception ex) {
                string message = "Encountered exception in btnRemoveAllCounties_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void lstElectionContestsDetails_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                currentElectionContest = (ElectionContest)lstElectionContestsDetails.SelectedItem;
                refreshCandidateLists();
                refreshCountyLists();
            } catch (Exception ex) {
                string message = "Encountered exception in lstElectionContestsDetails_SelectedIndexChanged";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void tabDetails_Click(object sender, EventArgs e)
        {

        }
    }
}