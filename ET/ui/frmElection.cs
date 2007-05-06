using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.events;
using log4net;
using edu.uwec.cs.cs355.group4.et.util;
namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class frmElection : BaseMDIChild {
        public event GenericEventHandler<Object, ShowErrorMessageArgs> showErrorMessage;

        private static readonly ILog LOG = LogManager.GetLogger(typeof (frmElection));

        private readonly ElectionDAO electionDAO;

        private readonly IList<Contest> allContests;
        private readonly IList<Candidate> allCandidates;
        private readonly IList<County> allCounties;

        private readonly IList<ElectionContest> addedContests;

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

                addedContests = new List<ElectionContest>();

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
            refreshControls();
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
                    //lstAllContests.Items.Remove(electionContest.Contest);
                    int removeAt = 0;
                    foreach (Contest c in lstAllContests.Items)
                    {
                        if (c.Name == electionContest.Contest.Name)
                            removeAt = lstAllContests.Items.IndexOf(c);
                    }
                    lstAllContests.Items.RemoveAt(removeAt);
            }
        }

        private void refreshCountyLists() {
            Dictionary<County, int> mapCounts = new Dictionary<County, int>();
            object[] o = new object[2];
            int i;
            foreach (DataGridViewRow row in dgvCounties.Rows){
                if (Int32.TryParse(row.Cells[1].Value.ToString(), out i))
                {
                    mapCounts.Add(((County)row.Cells[0].Value), i);
                }
            }
            dgvCounties.Rows.Clear();
            foreach (County county in allCounties){
                o[0] = county;
                i = 0;
                if (mapCounts.TryGetValue(county, out i)){
                    o[1] = i;
                }
                else{
                    o[1] = county.WardCount;
                }
                dgvCounties.Rows.Add(o);
            }
            lstContestCounties.Items.Clear();

            if (currentElectionContest != null){
                foreach (ContestCounty contestCounty in currentElectionContest.Counties){
                    lstContestCounties.Items.Add(contestCounty);
                    foreach(DataGridViewRow row in dgvCounties.Rows){
                        if (((County)row.Cells[0].Value).ID == contestCounty.County.ID){
                            dgvCounties.Rows.Remove(row);
                            break;
                        }
                    }
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
            addedContests.Clear();
            foreach (ElectionContest ec in currentElection.ElectionContests){
                foreach (Response r in ec.Responses){
                    r.SortOrder = ec.Responses.IndexOf(r);
                }
            }
            try {
                currentElection.IsActive = chkActive.Checked;
                currentElection.Date = dtpDate.Value;
                currentElection.Notes = txtNotes.Text;

                IList<Fault> faultLst = electionDAO.validate(currentElection);
                bool persistData = true;

                //Go through the list of faults and display warnings and errors.
                foreach (Fault fault in faultLst)
                {
                    if (persistData)
                    {
                        if (fault.IsError)
                        {
                            persistData = false;
                            MessageBox.Show("Error: " + fault.Message);
                        }
                        else
                        {
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result = MessageBox.Show("Warning: " + fault.Message + "\n\nWould you like to save anyway?", "Warning Message", buttons);
                            if (result == DialogResult.No)
                            {
                                persistData = false;
                            }
                        }
                    }
                }
                
                //If there were no errors, persist data to the database
                if (persistData)
                {
                    electionDAO.makePersistent(currentElection);
                    refreshControls();
                    refreshGoToList();
                }
            } catch (Exception ex) {
                string message = "Encountered exception in btnElectionSave_Click";
                LOG.Error(message, ex);
                ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
                EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
            }
        }

        private void resetContestTab()
        {
        }

        public override void btnReset_Click(object sender, EventArgs e) {
            resetControls();
            base.btnReset_Click(sender, e);
        }

        private void resetControls()
        {
            chkActive.Checked = currentElection.IsActive;
            dtpDate.Value = currentElection.Date;
            txtNotes.Text = currentElection.Notes;

            resetContestLists();
            refreshCountyLists();
            refreshCandidateLists();
        }

        private void resetContestLists()
        {
            lstElectionContests.Items.Clear();
            lstElectionContestsDetails.Items.Clear();
            lstAllContests.Items.Clear();

            foreach (Contest contest in allContests)
            {
                lstAllContests.Items.Add(contest);
            }

            IList<ElectionContest> removeList = new List<ElectionContest>();
            foreach (ElectionContest electionContest in currentElection.ElectionContests)
            {
                if (!addedContests.Contains(electionContest))
                {
                    lstElectionContests.Items.Add(electionContest);
                    lstElectionContestsDetails.Items.Add(electionContest);
                    lstAllContests.Items.Remove(electionContest.Contest);

                    int removeAt = 0;
                    foreach (Contest c in lstAllContests.Items)
                    {
                        if (c.Name == electionContest.Contest.Name)
                            removeAt = lstAllContests.Items.IndexOf(c);
                    }
                    lstAllContests.Items.RemoveAt(removeAt);
                }
                else
                {
                    removeList.Add(electionContest);
                }
            }

            foreach (ElectionContest ec in removeList)
            {
                currentElection.ElectionContests.Remove(ec);
            }
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
                    addedContests.Add(electionContest);
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
                        addedContests.Add(electionContest);
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
            County county;
            //MessageBox.Show("" + dgvCounties.SelectedRows.Count );
            int i;
            ContestCounty contestCounty;
            try{
                if (currentElectionContest != null)
                {
                    foreach (DataGridViewRow row in dgvCounties.SelectedRows)
                    {
                        county = (County)row.Cells[0].Value;
                        contestCounty = new ContestCounty();
                        contestCounty.ElectionContest = currentElectionContest;
                        contestCounty.County = county;
                        if (Int32.TryParse(row.Cells[1].Value.ToString(), out i)){
                            contestCounty.WardCount = i;
                        }
                        else{
                            contestCounty.WardCount = 0;
                        }
                        contestCounty.WardsReporting = 0;
                        currentElectionContest.Counties.Add(contestCounty);

                    }
                    refreshCountyLists();
                }
            }
            catch (Exception ex)
            {
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

        private void frmElection_Resize(object sender, EventArgs e)
        {
            tbDisplay.Height = this.Height - 76;
        }

        private void btnResponseUp_Click(object sender, EventArgs e)
        {
            Object o = lstContestCandidates.SelectedItem;
            int ind = lstContestCandidates.SelectedIndex;
            int ind2;
            if (ind > 0)
            {
                lstContestCandidates.Items.RemoveAt(ind);
                lstContestCandidates.Items.Insert(ind - 1, o);
                lstContestCandidates.SelectedIndex = ind - 1;
                ind2 = currentElectionContest.Responses.IndexOf((Response)o);
                currentElectionContest.Responses.RemoveAt(ind2);
                currentElectionContest.Responses.Insert(ind2 - 1, (Response)o);
            }
        }

        private void btnResponseDown_Click(object sender, EventArgs e)
        {
            Object o = lstContestCandidates.SelectedItem;
            int ind = lstContestCandidates.SelectedIndex;
            int ind2;
            if (ind < lstContestCandidates.Items.Count - 1)
            {
                lstContestCandidates.Items.RemoveAt(ind);
                lstContestCandidates.Items.Insert(ind+1, o);
                lstContestCandidates.SelectedIndex = ind+1;
                ind2 = currentElectionContest.Responses.IndexOf((Response)o);
                currentElectionContest.Responses.RemoveAt(ind2);
                currentElectionContest.Responses.Insert(ind2 + 1, (Response)o);
            }
        }

        private void dgvCounties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}