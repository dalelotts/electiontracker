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

        public frmElection(ElectionDAO electionDAO, ContestDAO contestDAO, CandidateDAO candidateDAO,
                           CountyDAO countyDAO) {
            try {
                InitializeComponent();

                this.electionDAO = electionDAO;
                currentElection = new Election();
                allContests = contestDAO.findAll();
                allCandidates = candidateDAO.findAll();
                allCounties = countyDAO.findAll();


                refreshGoToList();
                refreshControls();
            } catch (Exception ex) {
                string message = "Encountered exception in frmElection constructor";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void refreshControls() {
            chkActive.Checked = currentElection.IsActive;
            dtpDate.Value = currentElection.Date;
            txtNotes.Text = currentElection.Notes;
            refreshContestLists();
            refreshCountyLists();
            refreshCandidateLists();
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
                Election newElection = electionDAO.findById(id, false);
                if (newElection != null) {
                    currentElection = newElection;
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

        public override void btnAdd_Click(object sender, EventArgs e) {
            currentElection = new Election();
            refreshControls();
            base.btnAdd_Click(sender, e);
        }

        public override void btnSave_Click(object sender, EventArgs e) {
            try {
                currentElection.IsActive = chkActive.Checked;
                currentElection.Date = dtpDate.Value;
                currentElection.Notes = txtNotes.Text;
                electionDAO.makePersistent(currentElection);
                refreshControls();
                refreshGoToList();
            } catch (Exception ex) {
                string message = "Encountered exception in btnElectionSave_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            refreshControls();
            base.btnReset_Click(sender, e);
        }

        public override void btnDelete_Click(object sender, EventArgs e) {
            electionDAO.makeTransient(currentElection);
            currentElection = new Election();
            refreshControls();
            refreshGoToList();
            base.btnDelete_Click(sender, e);
        }

        public override void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            currentElection = (Election) cboGoTo.SelectedItem;
            refreshControls();
            base.cboGoTo_SelectedIndexChanged(sender, e);
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
                txtWards.Enabled = false;
                txtWards.Text = "";
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
                        if (lstAllCounties.SelectedItems.Count == 1){
                            // TODO: Error handling for invalid chars.
                            contestCounty.WardCount = int.Parse(txtWards.Text);
                            txtWards.Enabled = false;
                            txtWards.Text = "";
                        }
                        else{
                            contestCounty.WardCount = county.WardCount;
                        }
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
                txtWards.Enabled = false;
                txtWards.Text = "";
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
                txtWards.Enabled = false;
                txtWards.Text = "";
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
                currentElectionContest = (ElectionContest) lstElectionContestsDetails.SelectedItem;
                refreshCandidateLists();
                refreshCountyLists();
            } catch (Exception ex) {
                string message = "Encountered exception in lstElectionContestsDetails_SelectedIndexChanged";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void btnAddCustomResponse_Click(object sender, EventArgs e) {
            string text = txtCustomResponse.Text;
            if (text != null && text.Length > 0) {
                // To Do: Validate response text does not alread exist.
                CustomResponse response = new CustomResponse();
                response.Description = text;
                response.ElectionContest = currentElectionContest;
                currentElectionContest.Responses.Add(response);
                txtCustomResponse.Text = null;
                refreshCandidateLists();
            }
        }

        private void lstAllCounties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAllCounties.SelectedItems.Count == 1)
            {
                txtWards.Enabled = true;
                txtWards.Text = ((County)lstAllCounties.SelectedItems[0]).WardCount.ToString();
            }
            else
            {
                txtWards.Enabled = false;
                txtWards.Text = "";
            }
        }

        private void lstAllCounties_LostFocus(object sender, EventArgs e)
        {
            if (!txtWards.Focused)
            {

                txtWards.Enabled = false;
            }
        }

        private void lstContestCounties_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWards.Enabled = false;
            if (lstContestCounties.SelectedItems.Count == 1){
                txtWards.Text = ((ContestCounty)lstContestCounties.SelectedItems[0]).WardCount.ToString();
            }
            else{
                txtWards.Text = "";
            }
        }

        private void frmElection_Resize(object sender, EventArgs e)
        {
            tbDisplay.Height = this.Height - 76;
        }
    }
}