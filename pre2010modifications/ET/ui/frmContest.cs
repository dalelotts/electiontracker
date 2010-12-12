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

namespace KnightRider.ElectionTracker.ui
{
    internal partial class frmContest : BaseMDIChild
    {
        private readonly IDAOTask<DefaultContestCounty> loadTask;
        private readonly IContestDAO contestDAO;
        private Contest currentContest;
        private Boolean dirty;
        private Boolean cancelClose;
        private IList<County> allCounties;
        private IList<DefaultContestCounty> defaultContestCounties;
        private readonly IDefaultContestCountyDAO dccDAO;
        IList<DefaultContestCounty> remCounties = new List<DefaultContestCounty>();
        public override void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                IList<Fault> faults = contestDAO.canMakeTransient(currentContest);
                if (reportFaults(faults))
                {
                    foreach (DefaultContestCounty dcc in defaultContestCounties)
                    {
                        IList<Fault> dccFaults = dccDAO.canMakeTransient(dcc);
                        if (reportFaults(dccFaults))
                        {
                            dccDAO.makeTransient(dcc);
                        }
                    }
                    contestDAO.makeTransient(currentContest);
                    currentContest = new Contest();
                    refreshControls();
                    raiseMakeTransientEvent();
                }
            }
            catch (Exception ex)
            {
                reportException("btnDelete_Click", ex);
            }
        }

        public frmContest(IContestDAO contestDAO, ICountyDAO countyDAO, IDefaultContestCountyDAO dccDAO, IDAOTask<DefaultContestCounty> loadTask)
        {
            InitializeComponent();
            this.contestDAO = contestDAO;
            this.dccDAO = dccDAO;
            this.loadTask = loadTask;
            currentContest = new Contest();
            allCounties = countyDAO.findAll();
            defaultContestCounties = dccDAO.find(currentContest.ID);
            refreshCountyLists();
            //set up text boxes with a hanlder for text changed
            txtName.TextChanged += new EventHandler(DataChanged);
            txtNotes.TextChanged += new EventHandler(DataChanged);
            dirty = false;
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                currentContest = new Contest();
                refreshControls();
                base.btnAdd_Click(sender, e);
            }
            catch (Exception ex)
            {
                reportException("btnAdd_Click", ex);
            }
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                currentContest.IsActive = chkActive.Checked;
                currentContest.IsFinal = chkFinal.Checked;
                currentContest.Name = txtName.Text;
                currentContest.Notes = txtNotes.Text;

                //Validate the current data and get a list of faults.
                IList<Fault> faults = contestDAO.canMakePersistent(currentContest);
                bool persistData = reportFaults(faults);

                //If there were no errors, persist data to the database
                if (persistData)
                {
                    currentContest = contestDAO.makePersistent(currentContest);
                    foreach (DefaultContestCounty dcc in defaultContestCounties)
                    {
                        IList<Fault> dccFaults = dccDAO.canMakePersistent(dcc);
                        if (reportFaults(dccFaults))
                        {
                            dccDAO.makePersistent(dcc);
                        }
                    }
                    //try to delete any default contest counties that need to be deleted


                    foreach (DefaultContestCounty d in remCounties)
                    {
                        dccDAO.makeTransient(d);
                        defaultContestCounties.Remove(d);

                    }
                    refreshControls();
                    raiseMakePersistentEvent();
                    MessageBox.Show(this, currentContest + " saved.", "Sucessful Save");
                }
                else
                {
                    cancelClose = true;
                }

                refreshCountyLists();


            }
            catch (Exception ex)
            {
                reportException("btnSave_Click", ex);
            }
        }

        private void refreshControls()
        {
            txtName.Text = currentContest.Name;
            txtNotes.Text = currentContest.Notes;

            chkActive.Checked = currentContest.IsActive;
            chkFinal.Checked = currentContest.IsFinal;
            foreach (County county in allCounties)
            {
                lstAllCounties.Items.Add(county);
            }
            refreshCountyLists();
        }

        public override void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                currentContest = currentContest.ID == 0 ? new Contest() : contestDAO.findById(currentContest.ID, false);
                refreshControls();
                base.btnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                reportException("btnReset_Click", ex);
            }
        }

        public void loadContest(long? id)
        {
            if (id.HasValue)
            {
                Contest contest = contestDAO.findById(id.Value, false);
                if (contest != null)
                {
                    currentContest = contest;
                    IList<DefaultContestCounty> dccs = dccDAO.find(currentContest.ID);
                    foreach (DefaultContestCounty dcc in dccs)
                    {
                        dcc.Contest = currentContest;
                        defaultContestCounties.Add(dccDAO.findById(dcc.ID, false, loadTask));
                    }
                }
            }
            refreshControls();
            dirty = false;
        }

        // Event handler.  Marks the Candidate form as dirty.
        private void DataChanged(object sender, EventArgs e)
        {
            dirty = true;
        }

        private void frmContest_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check to see if the form is dirty and if it is, then ask to save
            //check for dirty
            if (dirty)
            {
                DialogResult dr = MessageBox.Show("Do you want to save Contest before closing?", "Contest not saved", MessageBoxButtons.YesNo);
                if (String.Equals("Yes", dr.ToString()))
                {
                    cancelClose = false;
                    btnSave_Click(sender, e);
                    if (cancelClose)
                    {
                        e.Cancel = true;
                    }
                }

            }
        }

        private void chkFinal_CheckedChanged(object sender, EventArgs e)
        {
            currentContest.IsFinal = chkFinal.Checked;
        }
        private void refreshCountyLists()
        {
            lstAllCounties.Items.Clear();
            dgvContestCounties.Rows.Clear();

            foreach (County county in allCounties)
            {
                lstAllCounties.Items.Add(county);
            }

            foreach (DefaultContestCounty dcc in defaultContestCounties)
            {
                DataGridViewTextBoxCell countyCell = new DataGridViewTextBoxCell();
                countyCell.Value = dcc.County;

                DataGridViewTextBoxCell wardCountCell = new DataGridViewTextBoxCell();
                wardCountCell.Value = dcc.WardCount;
                wardCountCell.Tag = dcc.WardCount;

                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(countyCell);
                row.Cells.Add(wardCountCell);

                dgvContestCounties.Rows.Add(row);
                lstAllCounties.Items.Remove(dcc.County);
            }
        }

        private void btnAddAllCounties_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (County county in allCounties)
                {
                    DefaultContestCounty defaultContestCounty = new DefaultContestCounty();
                    defaultContestCounty.Contest = currentContest;
                    defaultContestCounty.County = county;
                    defaultContestCounty.WardCount = county.WardCount;
                    defaultContestCounty.WardsReporting = 0;
                    defaultContestCounties.Add(defaultContestCounty);
                }
                refreshCountyLists();
                DataChanged(sender, e);
            }
            catch (Exception ex)
            {
                reportException("btnAddAllCounties_Click", ex);
            }
        }

        private void btnAddCounty_Click(object sender, EventArgs e)
        {
            try
            {
                ListBox.SelectedObjectCollection counties = lstAllCounties.SelectedItems;
                if (counties.Count > 0)
                {
                    foreach (County county in counties)
                    {
                        DefaultContestCounty defaultContestCounty = new DefaultContestCounty();
                        defaultContestCounty.Contest = currentContest;
                        defaultContestCounty.County = county;
                        defaultContestCounty.WardCount = county.WardCount;
                        defaultContestCounty.WardsReporting = 0;
                        defaultContestCounties.Add(defaultContestCounty);
                    }
                    refreshCountyLists();
                    DataChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                reportException("btnAddCounty_Click", ex);
            }
        }

        private void btnRemoveCounty_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentContest != null)
                {
                    if (dgvContestCounties.SelectedRows.Count > 0)
                    {

                        foreach (DataGridViewRow row in dgvContestCounties.SelectedRows)
                        {
                            foreach (DefaultContestCounty dcc in defaultContestCounties)
                            {
                                if (dcc.County.Equals((County)row.Cells[0].Value))
                                {
                                    dgvContestCounties.Rows.Remove(row);
                                    remCounties.Add(dcc);
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                reportException("btnRemoveCounty_Click", ex);
            }
        }

        private void btnRemoveAllCounties_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Do you want to move all Counties?", "Confirm",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    try
                    {
                        if (currentContest != null)
                        {
                            remCounties = defaultContestCounties;
                            defaultContestCounties = new List<DefaultContestCounty>(allCounties.Count);
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
    }
}
