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
        private readonly IDefaultContestCountyDAO dccDAO;

        private Election currentElection;
        private ElectionContest currentElectionContest;
        private Boolean dirty;

        //To Do: Add support for double clicking to add or remove contests, candidates, counties, etc.
        //To Do: Add support to re-order the candidates and counties so they always appear in the order displayed on this screen.


        public frmElection(IElectionDAO electionDAO, IContestDAO contestDAO, ICandidateDAO candidateDAO, ICountyDAO countyDAO, IDAOTask<Election> loadTask, IDefaultContestCountyDAO dccDAO) {

            try {
                InitializeComponent();
                this.electionDAO = electionDAO;
                this.loadTask = loadTask;
                this.dccDAO = dccDAO;
                currentElection = new Election();
                allContests = contestDAO.findAll();
                allCandidates = candidateDAO.findActive();
                allCounties = countyDAO.findAll();
                dirty = false;

                txtNotes.TextChanged += new EventHandler(DataChanged);
                txtCustomResponse.TextChanged += new EventHandler(DataChanged);
                lstContestCandidates.TextChanged += new EventHandler(DataChanged);
                lstElectionContests.TextChanged += new EventHandler(DataChanged);
                dgvContestCounties.TextChanged += new EventHandler(DataChanged);
                

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
        }

        public void loadElection(long? id) {
            if (id != null) {
                Election newElection = electionDAO.findById(id.Value, false, loadTask);
                if (newElection != null) {
                    currentElection = newElection;
                }
            }
            refreshControls();
            dirty = false;
        }

        private void refreshContestLists() {
            lstElectionContests.BeginUpdate();
            lstContestCandidate.BeginUpdate();
            lstContestCandidates.BeginUpdate();
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
            lstContestCandidates.EndUpdate();
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
                //get all the elections to check if there already exists an election with the same date.
                //IList<Election> testDate = electionDAO.findAll();
                //foreach (Election elec in testDate)
                //{
                //    if (elec.Date == currentElection.Date)
                //    {
                //        MessageBox.Show(this, "Unable to save:\n" + currentElection + " election already exists.\n Please edit the existing election, or delete it.", "Error in Saving");
                //        //exit this method since data already exists
                //        //Since we are exiting, there is no data saved.
                //        //If the data of this current election is checked elsewhere, this part of the code can be moved there.
                //        //NOTE: The date is checked upon save button click, which means that the user could still enter data.
                //        // so that upon selecting a date, a warning will show.
                //        // Or overwriting can be supported, in which the methods below need to be changed.
                //        return;
                //    }
                //}

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

            dgvContestCounties.Rows.Clear();
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

        private void btnAddAllContests_Click(object sender, EventArgs e) {
            try {
                currentElection.ElectionContests = new List<ElectionContest>(allContests.Count);
                foreach (Contest contest in allContests) {
                    ElectionContest electionContest = makeElectionContest(contest);
                    currentElection.ElectionContests.Add(electionContest);
                    IList<DefaultContestCounty> defContCounties = dccDAO.find(contest.ID);
                    foreach (DefaultContestCounty d in defContCounties)
                    {
                        ContestCounty contestCounty = new ContestCounty();
                        contestCounty.ElectionContest = electionContest;
                        contestCounty.County = d.County;
                        contestCounty.WardCount = d.WardCount;
                        contestCounty.WardsReporting = d.WardsReporting;
                        electionContest.Counties.Add(contestCounty);
                    }
                }
                refreshContestLists();
                refreshCandidateLists();
                DataChanged(sender, e);
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
                        IList<DefaultContestCounty> defContCounties = dccDAO.find(contest.ID);
                        foreach (DefaultContestCounty d in defContCounties)
                        {
                            ContestCounty contestCounty = new ContestCounty();
                            contestCounty.ElectionContest = electionContest;
                            contestCounty.County = d.County;
                            contestCounty.WardCount = d.WardCount;
                            contestCounty.WardsReporting = d.WardsReporting;
                            electionContest.Counties.Add(contestCounty);
                        }
                    }

                    refreshContestLists();
                    refreshCandidateLists();
                    DataChanged(sender, e);
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
                    refreshCandidateLists();
                    DataChanged(sender, e);
                }
            } catch (Exception ex) {
                reportException("btnRemoveContest_Click", ex);
            }
        }

        private void btnRemoveAllContests_Click(object sender, EventArgs e) {
            switch (MessageBox.Show("Do you want move all Contests?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
            case DialogResult.Yes:
                    try
                    {
                        if (currentElection.ElectionContests.Count > 0)
                        {
                            currentElection.ElectionContests = new List<ElectionContest>(allContests.Count);
                            refreshContestLists();
                            refreshCandidateLists();
                            DataChanged(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        reportException("btnRemoveAllContests_Click", ex);
                    }
                break;

            case DialogResult.No:
                break;

            case DialogResult.Cancel:
                break;
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
                    DataChanged(sender, e);
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
                        DataChanged(sender, e);
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
                        DataChanged(sender, e);
                    }
                }
            } catch (Exception ex) {
                reportException("btnRemoveCandidate_Click", ex);
            }
        }

        private void btnRemoveAllCandidates_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Do you want to move all Candidates?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    try
                    {
                        if (currentElectionContest != null)
                        {
                            currentElectionContest.Responses = new List<Response>(allCandidates.Count);
                            refreshCandidateLists();
                            DataChanged(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        reportException("btnRemoveAllCandidates_Click", ex);
                    }
                    break;

                case DialogResult.No:
                    break;

                case DialogResult.Cancel:
                    break;
            }
        }

        private void btnAddAllCounties_Click(object sender, EventArgs e) {
           
            if (currentElectionContest != null) {
               try {
                    foreach (County county in allCounties) {        				//go through the entire list of counties
                        ContestCounty contestCounty = new ContestCounty();			//setting up ContestCounty information
                        contestCounty.ElectionContest = currentElectionContest;
                        contestCounty.County = county;
                        contestCounty.WardCount = county.WardCount;
                        contestCounty.WardsReporting = 0;

                        bool exists = false;
                        int index = 0;
                        ContestCounty temp = new ContestCounty();
                        //checks to see if county already exists
                        Console.WriteLine("Print out test 01");
                        while (!exists && (index < currentElectionContest.Counties.Count)){ 
                            temp = currentElectionContest.Counties[index];              
                            if(temp.County.Name.Equals(contestCounty.County.Name)){		//check to see if it currently exists
                                exists = true;
                            }
                            index++;
                        }
                        Console.WriteLine("Print out test 02");
                        //if county doesn't exist, add county
                        if(!exists){
                            currentElectionContest.Counties.Add(contestCounty);
                        }
                        Console.WriteLine("Print out test 03");
                  /*
                   * This is a bit of a round about way of checking to see if a county has already
                   * been added to the list.  A simple .contains call on the list would normally
                   * suffice however the .contains implicitly calls .equals which compares based
                   * on the ContestCounty object's ID, not the name.
                   * If you observe, the original is dealing with two different classes:
                   * ContestCounty and County (I am usure as to why these two different classes exist)
                   * 
                   * As you can see the code takes a list of County objects and assigns their 
                   * attributes to a ContestCounty attribute.  This is fine for name, ward, etc.
                   * however a ContestCounty's ID differs from a County's ID (even though they may
                   * share the same name.  I am unsure why the original designers made this decision).
                   * I decided not to change the .equals method (and thus call .contains) for 
                   * ContestCounty because I was unsure of how it would affect the rest of the application
                   */
  
                    }
                    refreshCountyLists();
                    DataChanged(sender, e);
                
				} catch (Exception ex) {
					reportException("btnAddAllCounties_Click", ex);
				}
				Console.WriteLine("Print out test 04");
			}
		}

        private void btnAddCounty_Click(object sender, EventArgs e) {
            Console.WriteLine("Test-Add County Single"); 
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
                    DataChanged(sender, e);
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
                        DataChanged(sender, e);
                    }
                }
            } catch (Exception ex) {
                reportException("btnRemoveCounty_Click", ex);
            }
        }

        private void btnRemoveAllCounties_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Do you want to move all Counties?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    try
                    {
                        if (currentElectionContest != null)
                        {
                            currentElectionContest.Counties = new List<ContestCounty>(allCounties.Count);
                            refreshCountyLists();
                            DataChanged(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        reportException("btnRemoveAllCounties_Click", ex);
                    }
                    break;

                case DialogResult.No:
                    break;

                case DialogResult.Cancel:
                    break;
            }
        }

        private void lstContestCandidate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentElectionContest = (ElectionContest)lstContestCandidate.SelectedItem;
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
                    DataChanged(sender, e);
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
                    DataChanged(sender, e);
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
                    DataChanged(sender, e);
                }
            } catch (Exception ex) {
                reportException("btnResponseDown_Click", ex);
            }
        }

        private void lstContestCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                currentElectionContest = (ElectionContest)lstContestCounty.SelectedItem;
                refreshCountyLists();
                dirty = false;
            }
            catch (Exception ex)
            {
                reportException("lstElectionContestsDetails_SelectedIndexChanged", ex);
            }
        }

        private void btnSetIncumbent_Click(object sender, EventArgs e) {
            try {
                Response incumbent = (Response) lstContestCandidates.SelectedItem;
                if (incumbent == null) return;

                if (incumbent.IsIncumbent) {
                    incumbent.IsIncumbent = false;
                } else {
                    foreach (Response response in lstContestCandidates.Items) {
                        if (response.IsIncumbent) response.IsIncumbent = false;
                    }
                    incumbent.IsIncumbent = true;
                }
                refreshCandidateLists();
                DataChanged(sender, e);
            } catch (Exception ex) {
                reportException("btnSetIncumbent_Click", ex);
            }
        }

        private void dgvContestCounties_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            try {
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
            } catch (Exception ex) {
                reportException("dgvContestCounties_CellEndEdit", ex);
            }
        }
        // Event handler.  Marks the Candidate form as dirty.
        private void DataChanged(object sender, EventArgs e)
        {
            dirty = true;
        }
        private void frmElection_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check for dirty
            if (dirty)
            {
                DialogResult dr = MessageBox.Show("Do you want to save Election before closing?", "Election not saved", MessageBoxButtons.YesNo);
                if (String.Equals("Yes", dr.ToString()))
                {
                    btnSave_Click(sender, e);
                }

            }
        }

        private void btnClearVotes_Click(object sender, EventArgs e) {
            try {
                int temp = 0;

                foreach (ElectionContest curE in currentElection.ElectionContests)
                {
                    temp = temp + curE.GetTotalVotes();
                }

                if (temp == 0)
                {
                    DialogResult dr = MessageBox.Show("There are no votes to clear.", "Please try again.", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Are you SURE you want to clear this election's vote totals?", "Clear election vote results?", MessageBoxButtons.YesNo);
                    if (String.Equals("Yes", dr.ToString()))
                    {
                        //Clear the vote totals
                        //IList<Fault> faults = electionDAO.canMakePersistent(currentElection);
                        //bool persistData = reportFaults(faults);
                        //If there were no errors, persist data to the database

                        //if (persistData)
                        //{
                        currentElection = electionDAO.makePersistent(currentElection);
                        refreshControls();
                        raiseMakePersistentEvent();
                        currentElection.ResetTotalVotes();
                        //Display "Votes cleared."
                        MessageBox.Show(this, currentElection + " election votes cleared.", "Votes cleared.");
                        //}

                    }
                }
            }
            catch (Exception ex)
            {
                reportException("btnClearVotes_Click", ex);
            }

        }

        
    }
}
