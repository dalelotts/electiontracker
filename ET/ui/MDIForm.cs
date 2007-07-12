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
using Altea;
using edu.uwec.cs.cs355.group4.et.events;
using edu.uwec.cs.cs355.group4.et.type;
using edu.uwec.cs.cs355.group4.et.ui.util;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal partial class MDIForm : Form {
        public event GenericEventHandler<object, ShowAboutBoxArgs> showAboutBox;
        public event GenericEventHandler<IShowMessageSender, ShowMessageArgs> showMessage;
        public event GenericEventHandler<object, EnterVotesArgs> enterVotes;
        public event GenericEventHandler<object, CountyFormArgs> countyForm;
        public event GenericEventHandler<object, CandidateArgs> candidate;
        public event GenericEventHandler<object, ContestArgs> contest;
        public event GenericEventHandler<object, PoliticalPartyArgs> politicalParty;
        public event GenericEventHandler<object, ElectionArgs> election;
        public event GenericEventHandler<object, ElectionReportArgs> electionReport;
        public event GenericEventHandler<object, ProofingSheetArgs> proofingSheet;
        public event GenericEventHandler<object, CountyContactFormArgs> countyContactForm;
        public event GenericEventHandler<object, ContestVoteSumryArgs> contestVoteSumry;

        private static readonly ShowMessageArgs NOT_IMPLEMENTED_MESSAGE_ARGS =
            new ShowMessageArgs("This feature is not implemented yet.", "Not Implemented");

        internal MDIForm() {
            InitializeComponent();

            aboutToolStripMenuItem.Click += new EventHandler(AboutBoxHandler);
            voteResultsToolStripMenuItem.Click += new EventHandler(VoteResultsHandler);
            countyToolStripMenuItem.Click += new EventHandler(CountyFormHandler);
            candidateToolStripMenuItem.Click += new EventHandler(CandidateHandler);
            contestToolStripMenuItem.Click += new EventHandler(ContestHandler);
            politicalPartyToolStripMenuItem.Click += new EventHandler(PoliticalPartyHandler);
            electionToolStripMenuItem.Click += new EventHandler(ElectionHandler);
            electionReportToolStripMenuItem.Click += new EventHandler(ElectionReportHandler);
            proofingSheetToolStripMenuItem.Click += new EventHandler(ProofingSheetHandler);
            contestVoteSummaryToolStripMenuItem.Click += new EventHandler(ContestVoteSumryHandler);
            countyContactFormToolStripMenuItem.Click += new EventHandler(CountyContactFormHandler);

            ToolStripItemCollection menuStripItems = mainMenuStrip.Items;
            foreach (ToolStripItem menuStripItem in menuStripItems) {
                if (menuStripItem is ToolStripMenuItem) {
                    ToolStripItemCollection dropDownItems = ((ToolStripMenuItem) menuStripItem).DropDownItems;
                    foreach (ToolStripItem dropDownItem in dropDownItems) {
                        if (dropDownItem != aboutToolStripMenuItem && dropDownItem != voteResultsToolStripMenuItem &&
                            dropDownItem != countyToolStripMenuItem && dropDownItem != candidateToolStripMenuItem &&
                            dropDownItem != contestToolStripMenuItem && dropDownItem != politicalPartyToolStripMenuItem &&
                            dropDownItem != electionToolStripMenuItem && dropDownItem != electionReportToolStripMenuItem &&
                            dropDownItem != proofingSheetToolStripMenuItem &&
                            dropDownItem != countyContactFormToolStripMenuItem &&
                            dropDownItem != contestVoteSummaryToolStripMenuItem) {
                            dropDownItem.Click += new EventHandler(NotImplementedMessageHandler);
                        }
                    }
                }
            }
        }

        private void VoteResultsHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, EnterVotesArgs>(enterVotes, this, new EnterVotesArgs());
        }

        private void CountyFormHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, CountyFormArgs>(countyForm, this, new CountyFormArgs());
        }

        private void CandidateHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, CandidateArgs>(candidate, this, new CandidateArgs());
        }

        private void ContestHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, ContestArgs>(contest, this, new ContestArgs());
        }

        private void PoliticalPartyHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, PoliticalPartyArgs>(politicalParty, this, new PoliticalPartyArgs());
        }

        private void ElectionHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, ElectionArgs>(election, this, new ElectionArgs());
        }

        private void ElectionReportHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, ElectionReportArgs>(electionReport, this, new ElectionReportArgs());
        }

        private void CountyContactFormHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, CountyContactFormArgs>(countyContactForm, this, new CountyContactFormArgs());
        }

        private void ContestVoteSumryHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, ContestVoteSumryArgs>(contestVoteSumry, this, new ContestVoteSumryArgs());
        }

        private void ProofingSheetHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, ProofingSheetArgs>(proofingSheet, this, new ProofingSheetArgs());
        }

        public IList<TreeViewFilter> Filters {
            set {
                filterBar.Buttons.Clear();
                foreach (TreeViewFilter filter in value) {
                    OutlookBarButton button = new FilterButton(filter.ToString(), null, filter);
                    filterBar.Buttons.Add(button);
                }
                if (value.Count > 0) filterBar.Buttons[0].Selected = true;
            }
        }

        private void AboutBoxHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, ShowAboutBoxArgs>(showAboutBox, this, new ShowAboutBoxArgs());
        }

        private void NotImplementedMessageHandler(object sender, EventArgs e) {
            DefaultShowMessageSender messageSender = new DefaultShowMessageSender();
            EventUtil.RaiseEvent<IShowMessageSender, ShowMessageArgs>(showMessage, messageSender,
                                                                      NOT_IMPLEMENTED_MESSAGE_ARGS);
        }

        private void filterBar_ButtonClicked(object sender, EventArgs e) {
            try {
                mainTreeView.Nodes.Clear();
                ((FilterButton) filterBar.SelectedButton).Filter.apply(mainTreeView.Nodes);
                mainTreeView.ExpandAll();
                if (mainTreeView.Nodes.Count > 0) {
                    mainTreeView.Nodes[0].EnsureVisible();
                }
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void resizeHandler(object sender, EventArgs e) {
            mainTreeView.Height = filterBar.Top - mainTreeView.Top;
        }

        private void mainTreeView_DoubleClick(object sender, EventArgs e) {
            try {
                TreeNode node = mainTreeView.SelectedNode;
                if (node == null) return;
                string[] tokens = node.Name.Split(';');

                if (tokens.Length > 0) {
                    string idString = tokens[0]; // The first token is the ID token.
                    string[] entityID = idString.Split('=');
                    if (entityID.Length == 2) {
                        string entity = entityID[0].Trim();
                        long id = long.Parse(entityID[1]);

                        // To Do: Change to factory method.
                        if (DBEntity.CANDIDATE.ToString().Equals(entity)) {
                            CandidateArgs candidateArgs = new CandidateArgs(id);
                            EventUtil.RaiseEvent<object, CandidateArgs>(candidate, this, candidateArgs);
                        } else if (DBEntity.CONTEST.ToString().Equals(entity)) {
                            ContestArgs contestArgs = new ContestArgs(id);
                            EventUtil.RaiseEvent<object, ContestArgs>(contest, this, contestArgs);
                        } else if (DBEntity.COUNTY.ToString().Equals(entity)) {
                            CountyFormArgs countyFormArgs = new CountyFormArgs(id);
                            EventUtil.RaiseEvent<object, CountyFormArgs>(countyForm, this, countyFormArgs);
                        } else if (DBEntity.ELECTION.ToString().Equals(entity)) {
                            ElectionArgs electionArgs = new ElectionArgs(id);
                            EventUtil.RaiseEvent<object, ElectionArgs>(election, this, electionArgs);
                        } else if (DBEntity.POLITICAL_PARTY.ToString().Equals(entity)) {
                            PoliticalPartyArgs politicalPartyArgs = new PoliticalPartyArgs(id);
                            EventUtil.RaiseEvent<object, PoliticalPartyArgs>(politicalParty, this, politicalPartyArgs);
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}