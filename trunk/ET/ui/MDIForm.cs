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
using KnightRider.ElectionTracker.events;
using KnightRider.ElectionTracker.type;
using KnightRider.ElectionTracker.ui.util;

namespace KnightRider.ElectionTracker.ui {
    internal partial class MDIForm : Form {
        public event GenericEventHandler<object, ShowServerOptionsArgs> showServerOptions;
        public event GenericEventHandler<object, ShowAboutBoxArgs> showAboutBox;
        public event GenericEventHandler<object, EnterVotesArgs> enterVotes;
        public event GenericEventHandler<object, CountyFormArgs> countyForm;
        public event GenericEventHandler<object, CandidateArgs> candidate;
        public event GenericEventHandler<object, ContestArgs> contest;
        public event GenericEventHandler<object, PoliticalPartyArgs> politicalParty;
        public event GenericEventHandler<object, ElectionArgs> election;
        public event GenericEventHandler<object, ReportArgs> showReport;
        public event GenericEventHandler<Object, ShowErrorMessageArgs> showErrorMessage;

        internal MDIForm() {
            InitializeComponent();

            // ToDo: Inject and autowire the events for reports using spring.

            aboutToolStripMenuItem.Click += new EventHandler(AboutBoxHandler);
            ServerOptionsToolStrip.Click += new EventHandler(ServerOptionsHandler);
            voteResultsToolStripMenuItem.Click += new EventHandler(VoteResultsHandler);
            countyToolStripMenuItem.Click += new EventHandler(CountyFormHandler);
            candidateToolStripMenuItem.Click += new EventHandler(CandidateHandler);
            contestToolStripMenuItem.Click += new EventHandler(ContestHandler);
            politicalPartyToolStripMenuItem.Click += new EventHandler(PoliticalPartyHandler);
            electionToolStripMenuItem.Click += new EventHandler(ElectionHandler);
            countyContactFormToolStripMenuItem.Click += new EventHandler(CountyContactReportHandler);
            proofingSheetToolStripMenuItem.Click += new EventHandler(ProofingSheetReportHandler);
            voteCountyTallySheetToolStripMenuItem.Click += new EventHandler(VoteCountyTallySheetHandler);
            contestVoteSummaryToolStripMenuItem.Click += new EventHandler(ContestVoteSummaryHandler);
            electionQuickScanSheetToolStripMenuItem.Click += new EventHandler(ElectionQuickScanHandler);
        }

        private void ServerOptionsHandler(object sender, EventArgs e)
        {
            try
            {
                EventUtil.RaiseEvent<object, ShowServerOptionsArgs>(showServerOptions, this, new ShowServerOptionsArgs());
            }
            catch (Exception ex)
            {
                reportException("ServerOptionsHandler", ex);
            }
        }

        private void ElectionQuickScanHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, ReportArgs>(showReport, this, new ReportArgs("ElectionQuickScanSheet"));
            } catch (Exception ex) {
                reportException("ElectionQuickScanHandler", ex);
            }
        }

        private void ContestVoteSummaryHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, ReportArgs>(showReport, this, new ReportArgs("ContestVoteSummary"));
            } catch (Exception ex) {
                reportException("ContestVoteSummaryHandler", ex);
            }
        }

        private void VoteCountyTallySheetHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, ReportArgs>(showReport, this, new ReportArgs("VoteCountyTallySheet"));
            } catch (Exception ex) {
                reportException("VoteCountyTallySheetHandler", ex);
            }
        }

        private void ProofingSheetReportHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, ReportArgs>(showReport, this, new ReportArgs("ProofingSheet"));
            } catch (Exception ex) {
                reportException("ProofingSheetReportHandler", ex);
            }
        }

        private void CountyContactReportHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, ReportArgs>(showReport, this, new ReportArgs("CountyContactReport"));
            } catch (Exception ex) {
                reportException("CountyContactReportHandler", ex);
            }
        }

        private void VoteResultsHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, EnterVotesArgs>(enterVotes, this, new EnterVotesArgs());
            } catch (Exception ex) {
                reportException("VoteResultsHandler", ex);
            }
        }

        private void CountyFormHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, CountyFormArgs>(countyForm, this, new CountyFormArgs());
            } catch (Exception ex) {
                reportException("CountyFormHandler", ex);
            }
        }

        private void CandidateHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, CandidateArgs>(candidate, this, new CandidateArgs());
            } catch (Exception ex) {
                reportException("CandidateHandler", ex);
            }
        }

        private void ContestHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, ContestArgs>(contest, this, new ContestArgs());
            } catch (Exception ex) {
                reportException("ContestHandler", ex);
            }
        }

        private void PoliticalPartyHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, PoliticalPartyArgs>(politicalParty, this, new PoliticalPartyArgs());
            } catch (Exception ex) {
                reportException("PoliticalPartyHandler", ex);
            }
        }

        private void ElectionHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, ElectionArgs>(election, this, new ElectionArgs());
            } catch (Exception ex) {
                reportException("ElectionHandler", ex);
            }
        }


        public IList<TreeViewFilter> Filters {
            set {
                filterBar.Buttons.Clear();
                foreach (TreeViewFilter filter in value) {
                    OutlookBarButton button = new FilterButton(filter.ToString(), null, filter);
                    filterBar.Buttons.Add(button);
                }
            }
        }

        private void showHelpHandler(object sender, EventArgs e){
            EventUtil.RaiseEvent<object, ShowAboutBoxArgs>(showAboutBox, this, new ShowAboutBoxArgs());
        }
        private void AboutBoxHandler(object sender, EventArgs e) {
            try {
                EventUtil.RaiseEvent<object, ShowAboutBoxArgs>(showAboutBox, this, new ShowAboutBoxArgs());
            } catch (Exception ex) {
                reportException("AboutBoxHandler", ex);
            }
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
                reportException("filterBar_ButtonClicked", ex);
            }
        }

        private void resizeHandler(object sender, EventArgs e) {
            try {
                mainTreeView.Height = filterBar.Top - mainTreeView.Top;
            } catch (Exception ex) {
                reportException("resizeHandler", ex);
            }
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
                reportException("mainTreeView_DoubleClick", ex);
            }
        }

        private void reportException(string methodName, Exception ex) {
            string message = "Unable to complete the requested action.\n\nEncountered '" + ex.GetType() + "' exception in the '" + methodName + "' method.";
            ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
            EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
        }

        public void refreshCurrentFilter() {
            filterBar_ButtonClicked(null, null);
        }

        private void MDIForm_Shown(object sender, EventArgs e) {
            try {
                if (filterBar.Buttons.Count > 0) filterBar.Buttons[0].Selected = true;
            } catch (Exception ex) {
                reportException("MDIForm_Shown", ex);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String sHelpFile = "ElectionTracker.chm";
            String sStartupPath;
            sStartupPath = Application.StartupPath.ToString() + "help\\ElectionTracker.chm";
            //sHelpFile = Replace(sStartupPath, "\bin", "\hlp") & "\ElectionTracker.chm";
            hlpElectionTracker.HelpNamespace = sHelpFile;
            //hlpElectionTracker.SetHelpNavigator(this, HelpNavigator.TableOfContents);


            Help.ShowHelp(this, hlpElectionTracker.HelpNamespace);
        }

     }
}