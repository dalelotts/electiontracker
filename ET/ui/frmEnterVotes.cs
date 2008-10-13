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
        private static readonly ContestCountyComparer BY_CONTEST_NAME = new ContestCountyComparer(true);

        private Map<long, County> countyIDToCounty;
        private Map<long, IList<ContestCounty>> countyIDContestCounty;
        private Map<long, VoteEnterer> countyIDToVoteEnterer;
        private readonly IElectionDAO electionDAO;
        private readonly IContestCountyDAO contestCountyDAO;
        private readonly ICountyDAO countyDAO;
        private readonly IDAOTask<Election> loadTask;
        private readonly IDAOTask<County> countyTask;

        private County currentCounty;

        public frmEnterVotes(IElectionDAO electionDAO, IContestCountyDAO contestCountyDAO, ICountyDAO countyDAO, IDAOTask<Election> loadTask, IDAOTask<County> countyTask) {
            this.electionDAO = electionDAO;
            this.contestCountyDAO = contestCountyDAO;
            this.countyDAO = countyDAO;
            this.loadTask = loadTask;
            this.countyTask = countyTask;
            InitializeComponent();
            countyIDToVoteEnterer = new Map<long, VoteEnterer>();
            countyIDToCounty = new Map<long, County>();
            countyIDContestCounty = new Map<long, IList<ContestCounty>>();
            toolStrip1.Visible = false;

            currentCounty = new County();           
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
                    Map<long, IList<ContestCounty>>.addValueToList(countyIDContestCounty, contestCounty.County.ID, contestCounty);
                }
            }

            foreach (KeyValuePair<long, IList<ContestCounty>> entry in countyIDContestCounty) {
                IList<ContestCounty> contestCounties = entry.Value;

                ((List<ContestCounty>) contestCounties).Sort(BY_CONTEST_NAME);

                VoteEnterer enterer = new VoteEnterer(contestCounties, contestCountyDAO);
                countyIDToVoteEnterer.Add(entry.Key, enterer);
            }

            refreshControls();
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
                County county = (County) lstCounties.SelectedItem;

                HideCurrentVoteEnterer();

                VoteEnterer enterer = countyIDToVoteEnterer.Get(county.ID);

                enterer.Location = new Point(10, 20);
                enterer.Width = gbContest.Width - 20;
                enterer.Height = btnSaveVotes.Location.Y - 30;

                gbContest.Controls.Add(enterer);

                // display county contact information
                lbl_electionDayNumber.Text = "";
                lbl_mainNumber.Text = "";
                currentCounty = countyDAO.findById(county.ID, false, countyTask);
                IList<CountyPhoneNumber> phoneNumbers = currentCounty.PhoneNumbers;
                foreach (CountyPhoneNumber phoneNumber in phoneNumbers)
                {
                    if(phoneNumber.Type.ToString().Equals("Election Day")){
                        lbl_electionDayNumber.Text = phoneNumber.AreaCode + "-" + phoneNumber.PhoneNumber;
                        if(phoneNumber.Extension != "" && phoneNumber.Extension != " " && phoneNumber.Extension != null) {
                            lbl_electionDayNumber.Text = lbl_electionDayNumber.Text.ToString() + " ext. " + phoneNumber.Extension;
                        }
                    } else if(phoneNumber.Type.ToString().Equals("Main")){
                        lbl_mainNumber.Text = phoneNumber.AreaCode + "-" + phoneNumber.PhoneNumber;
                        if(phoneNumber.Extension != "" && phoneNumber.Extension != " " && phoneNumber.Extension != null) {
                            lbl_mainNumber.Text = lbl_mainNumber.Text.ToString() + " ext. " + phoneNumber.Extension;
                        }
                    }
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
                List<string> result = new List<string>();
                foreach (VoteEnterer voteEnterer in countyIDToVoteEnterer.Values) {
                    result.AddRange(voteEnterer.Persist());
                }
                string message = "";
                foreach (string s in result) {
                    message += s + "\n";
                }
                MessageBox.Show(this, "The follow vote results were saved:\n" + message.Trim(), "Sucessful Save");
            } catch (Exception ex) {
                reportException("btnSaveVotes_Click", ex);
            }
        }
        private void frmEnterVotes_Closing(object sender, FormClosingEventArgs e)
        {
            Boolean canClose = true ;
            foreach (VoteEnterer VECheckDirty in countyIDToVoteEnterer.Values)
            {
                if (VECheckDirty.isDirty() )
                {
                    canClose = false;
                    break;
                }
            }
            if (!canClose)
            {
                DialogResult dr = MessageBox.Show("Do you want to save changes?", "Save Data", MessageBoxButtons.YesNo);

                if (dr.Equals(DialogResult.Yes))
                {
                    //need to save changes
                    try
                    {
                        List<string> result = new List<string>();
                        foreach (VoteEnterer voteEnterer in countyIDToVoteEnterer.Values)
                        {
                            result.AddRange(voteEnterer.Persist());
                        }
                        string message = "";
                        foreach (string s in result)
                        {
                            message += s + "\n";
                        }
                        MessageBox.Show(this, "The follow vote results were saved:\n" + message.Trim(), "Sucessful Save");
                    }
                    catch (Exception ex)
                    {
                        reportException("frmEnterVotes_Closing", ex);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lstCounties_MouseMove(object sender, MouseEventArgs e)
        {
            string tooltip = "";
        
            int index = lstCounties.IndexFromPoint(e.Location);
            if ((index >= 0) && (index < lstCounties.Items.Count))
            {
                try
                {
                    County county = (County)lstCounties.Items[index];

                    // display county contact notes information in a tooltip
                    currentCounty = countyDAO.findById(county.ID, false, countyTask);

                    tooltip = currentCounty.Notes;
                }
                catch (Exception ex)
                {
                    reportException("lstCounties_MouseMove", ex);
                }
            }

            toolTip1.SetToolTip(lstCounties, tooltip);
        }

    }
}