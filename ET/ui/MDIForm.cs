using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.events;
using edu.uwec.cs.cs355.group4.et.ui.util;

namespace edu.uwec.cs.cs355.group4.et.ui
{
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
        public event GenericEventHandler<Object, ShowErrorMessageArgs> showErrorMessage;

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

            ToolStripItemCollection menuStripItems = mainMenuStrip.Items;
            foreach (ToolStripItem menuStripItem in menuStripItems) {
                if (menuStripItem is ToolStripMenuItem) {
                    ToolStripItemCollection dropDownItems = ((ToolStripMenuItem) menuStripItem).DropDownItems;
                    foreach (ToolStripItem dropDownItem in dropDownItems) {
                        if (dropDownItem != aboutToolStripMenuItem && 
                            dropDownItem != voteResultsToolStripMenuItem && 
                            dropDownItem != countyToolStripMenuItem &&
                            dropDownItem != candidateToolStripMenuItem &&
                            dropDownItem != contestToolStripMenuItem &&
                            dropDownItem != politicalPartyToolStripMenuItem &&
                            dropDownItem != electionToolStripMenuItem &&
                            dropDownItem != electionReportToolStripMenuItem)
                        {
                            dropDownItem.Click += new EventHandler(NotImplementedMessageHandler);
                        }
                    }
                }
            }
        }

        private void VoteResultsHandler(object sender, EventArgs e) {
            EventUtil.RaiseEvent<object, EnterVotesArgs>(enterVotes, this, new EnterVotesArgs());
        }

        private void CountyFormHandler(object sender, EventArgs e)
        {
            EventUtil.RaiseEvent<object, CountyFormArgs>(countyForm, this, new CountyFormArgs());
        }

        private void CandidateHandler(object sender, EventArgs e)
        {
            EventUtil.RaiseEvent<object, CandidateArgs>(candidate, this, new CandidateArgs());
        }

        private void ContestHandler(object sender, EventArgs e)
        {
            EventUtil.RaiseEvent<object, ContestArgs>(contest, this, new ContestArgs());
        }

        private void PoliticalPartyHandler(object sender, EventArgs e)
        {
            EventUtil.RaiseEvent<object, PoliticalPartyArgs>(politicalParty, this, new PoliticalPartyArgs());
        }

        private void ElectionHandler(object sender, EventArgs e)
        {
            EventUtil.RaiseEvent<object, ElectionArgs>(election, this, new ElectionArgs());
        }

        private void ElectionReportHandler(object sender, EventArgs e)
        {
            EventUtil.RaiseEvent<object, ElectionReportArgs>(electionReport, this, new ElectionReportArgs());
        }

        public IList<TreeViewFilter> Filters {
            set {
                cboFilter.Items.Clear();
                foreach (TreeViewFilter filter in value) {
                    cboFilter.Items.Add(filter);
                }
                if (value.Count > 0) cboFilter.SelectedIndex = 0;
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

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox comboBox = (ComboBox) sender;
            TreeViewFilter filter = (TreeViewFilter) comboBox.SelectedItem;
            mainTreeView.Nodes.Clear();
            filter.apply(mainTreeView.Nodes);
        }

        private void btnExpand_Click(object sender, EventArgs e) {
            mainTreeView.ExpandAll();
        }

        private void btnCollapse_Click(object sender, EventArgs e) {
            mainTreeView.CollapseAll();
        }
    }
}