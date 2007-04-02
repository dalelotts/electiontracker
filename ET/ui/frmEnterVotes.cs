using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui.util;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    internal partial class frmEnterVotes : Form {
        private List<VoteEnterer> lstEntries;
        private ElectionDAO       electionDAO;
        private CountyDAO         countyDAO;
        private CandidateDAO      candidateDAO;
        private ResponseValueDAO  responseValueDAO;
        private ElectionContestDAO electionContestDAO;

        public frmEnterVotes(ElectionDAO  electionDAO,
                             CountyDAO    countyDAO,
                             CandidateDAO candidateDAO,
                             ResponseValueDAO  responseValueDAO,
                             ElectionContestDAO electionContestDAO){
            this.electionDAO  = electionDAO;
            this.countyDAO    = countyDAO;
            this.candidateDAO = candidateDAO;
            this.responseValueDAO = responseValueDAO;
            this.electionContestDAO = electionContestDAO;
            lstEntries = new List<VoteEnterer>();
            InitializeComponent();
        }                 

        public void HideCurrentVoteEnterer() {
            foreach (VoteEnterer ve in lstEntries) {
                if (ve.Visible) {
                    ve.Visible = false;
                }
            }
        }

        public VoteEnterer GetVoteEntererByCounty(County cty) {
            foreach (VoteEnterer ve in lstEntries) {
                if (ve.getCounty.Equals(cty)) {
                    return ve;
                }
            }
            return null;
        }

        private void frmEnterVotes_Load(object sender, EventArgs e) {
            LoadElections();
        }

        // Loads the elections into the listbox.
        private void LoadElections() {
            IList<Election> lstElections = electionDAO.findActiveWithCounties();
            ListItemWrapper<Election> cbiTemp = null;
            foreach (Election election in lstElections)
            {
                // Add them to the combo box.
                cbiTemp = new ListItemWrapper<Election>(election.Date.ToString(), election);
                cmbElections.Items.Add(cbiTemp);
            }

            if (lstElections.Count > 0) cmbElections.SelectedIndex = 0;
        }

        private void cmbElections_SelectedIndexChanged(object sender, EventArgs e) {
            LoadCounties(((ListItemWrapper<Election>)cmbElections.SelectedItem).Value);
        }

        private void LoadCounties(Election elc) {
            this.lstCounties.Items.Clear();
            IList<County>        lstCty  = electionDAO.findCounties(elc);
            ListItemWrapper<County> cbiTemp = null;
            foreach (County cty in lstCty)
            {
                cbiTemp = new ListItemWrapper<County>(cty.Name, cty);
                this.lstCounties.Items.Add(cbiTemp);
            }
            if (this.lstCounties.Items.Count > 0) this.lstCounties.SelectedIndex = 0;
        }

        private void lstCounties_SelectedIndexChanged(object sender, EventArgs e) {
            //DisplayContests(((ComboBoxItem<County>)this.lstCounties.SelectedItem).Value);
            County county = ((ListItemWrapper<County>)this.lstCounties.SelectedItem).Value;
            //lstElectionContests = electionContestDAO.findContests(county);

            HideCurrentVoteEnterer();
            if (!(VoteEnterer.CountyExists(county, lstEntries)))
            {
                // Haven't created a new vote display for this county yet.
                VoteEnterer ve = new VoteEnterer(responseValueDAO, electionContestDAO, county);
                ve.Height = gbContest.Height - 60;
                ve.Top = 18;
                ve.Left = 6;
                ve.Width = gbContest.Width - 10;
                gbContest.Controls.Add(ve);
                lstEntries.Add(ve);
            }
            else
            {
                VoteEnterer ve = GetVoteEntererByCounty(county);
                ve.Visible = true;
            }
        }

        // This subclass displays a contest and its votes associated
        // with it for vote entry purposes.
        public class ContestDisplay : Panel {
            private ContestCounty contestCounty;
            private ElectionContest electionContest;
            private ResponseValueDAO responseValueDAO;
            private IList<Response> lstResponses;
            private Hashtable htVotes;
            private Label lblContest;
            private TextBox txtReporting;
            private Boolean _bDirty;
            private ElectionContestDAO electionContestDAO;

            public Boolean Dirty {
                get { return _bDirty; }
                set { _bDirty = value; }
            }

            public void Persist()
            {
                TextBox t;
                foreach (Response r in lstResponses)
                {
                    t = (TextBox)htVotes[r];
                    contestCounty.WardsReporting = int.Parse(txtReporting.Text);
                    // TODO : Persist wards reporting value.
                    responseValueDAO.SaveVotes( r, contestCounty, int.Parse(t.Text));
                }
                Dirty = false;
            }

            public ContestDisplay(ElectionContestDAO ec, ResponseValueDAO  rv, ContestCounty cc, ElectionContest elec)
            {
                this.responseValueDAO = rv;
                this.electionContestDAO = ec;
                electionContest = elec;
                contestCounty = cc;
                lblContest = new Label();
                txtReporting = new TextBox();
                Width = 385;
                txtReporting.Left = Width - 55;
                txtReporting.Width = 30;
                BorderStyle = BorderStyle.FixedSingle;
                Visible = true;
                txtReporting.Text = cc.WardsReporting.ToString();
                Controls.Add(txtReporting);
                lblContest.Width = 300;
                lblContest.Text = electionContest.Contest.Name;
                Controls.Add(lblContest);
                lstResponses = null;
                InitializeResponses();
                Dirty = false;
            }

            private void InitializeResponses()
            {
                int i = 0;
                lstResponses = electionContestDAO.findResponses(electionContest);
                htVotes = new Hashtable();
                foreach (Response r in lstResponses){
                    Label l = new Label();
                    TextBox t = new TextBox();
                    t.Text = "NA";
                    t.TextChanged += new EventHandler(DataChanged);
                    l.Text = r.ToString();
                    l.Left = 5;
                    l.Width = 300;
                    l.Top = (lblContest.Height + 1) + ((lblContest.Height) * i++);
                    t.Top = l.Top;
                    t.Left = txtReporting.Left;
                    t.Width = txtReporting.Width;
                    Controls.Add(l);
                    Controls.Add(t);
                    htVotes.Add(r, t);
                    InitializeVoteCount(r, t);
                    Height = l.Top + l.Height + 1;
                }
            }

            private void InitializeVoteCount(Response r, TextBox t)
            {

                t.Text = (electionContestDAO.findVoteCount(r, contestCounty)).ToString();
            }

            // Event handler.  Marks the ContestDisplay as dirty.
            private void DataChanged(object sender, EventArgs e)
            {
                Dirty = true;
            }
        }

        // This subclass is a GUI collection of ContestDisplays.
        public class VoteEnterer : Panel {
            private int top;
            public IList<ContestDisplay> lstContestDisplays;
            private IList<ContestCounty> lstContestCounties;
            private ResponseValueDAO responseValueDAO;
            private IList<ElectionContest> lstElectionContests;
            private ElectionContestDAO electionContestDAO;
            public County cty;


            public County getCounty {
                get { return this.cty; }
            }

            public VoteEnterer(ResponseValueDAO rvd, ElectionContestDAO ec, County c)
            {
                ContestCounty ccTemp;
                this.cty = c;
                this.responseValueDAO = rvd;
                this.electionContestDAO = ec;
                lstContestDisplays = new List<ContestDisplay>();
                lstContestCounties = new List<ContestCounty>();
                lstElectionContests = electionContestDAO.findContests(c);
                foreach (ElectionContest elec in lstElectionContests)
                {
                    ccTemp = electionContestDAO.findContestCounty(c, elec);
                    lstContestCounties.Add(ccTemp);
                    lstContestDisplays.Add(new ContestDisplay(electionContestDAO, responseValueDAO, ccTemp, elec));
                }
                AutoScroll = true;
                BorderStyle = BorderStyle.FixedSingle;
                foreach (ContestDisplay cd in lstContestDisplays)
                {
                    cd.Top = top;
                    top = top + cd.Height + 1;
                    Controls.Add(cd);
                }
            }

            public static Boolean CountyExists(County cty, List<VoteEnterer> lst) {
                Boolean result = false;
                foreach (VoteEnterer ve2 in lst) {
                    if (ve2.getCounty.Equals(cty)) {
                        result = true;
                        break;
                    } // if...
                } // foreach...
                return result;
            } // public Boolean Exists()
        }

        private void btnNext_Click(object sender, EventArgs e) {
            if (lstCounties.SelectedIndex != lstCounties.Items.Count - 1) {
                lstCounties.SelectedIndex++;
                // TODO: "NEXT" Functionality.
            } else {
                // User clicked next and there isn't a next county to advance to.
                // TODO: What do we do here?
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            // TODO: Save contest information.
            foreach(VoteEnterer ve in lstEntries){
                foreach (ContestDisplay cd in ve.lstContestDisplays)
                {
                    if (cd.Dirty){
                        cd.Persist();
                    }
                } // foreach (ContestDisplay...
            } // foreach(VoteEnterer...
        } // btnSave_Click();
    }
}