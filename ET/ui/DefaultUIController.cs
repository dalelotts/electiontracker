using System;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.events;
using log4net;
using Spring.Context;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    internal class DefaultUIController : UIController, IApplicationContextAware {

        private static readonly ILog LOG = LogManager.GetLogger(typeof(DefaultUIController));

        private Form mdiForm;
        private IApplicationContext context;

        public Form MdiForm {
            set {
                if (mdiForm != null) throw new InvalidOperationException("MDIForm already set.");
                mdiForm = value;
            }
        }

        IApplicationContext IApplicationContextAware.ApplicationContext {
            get { return context; }
            set { context = value; }
        }

        Form UIController.getMDIForm() {
            return mdiForm;
        }

        private T makeMDIChildForm<T>() where T : Form {
            T form = (T) context.GetObject(typeof (T).ToString());
            form.MdiParent = mdiForm;
            context.PublishEvents(form);
            return form;
        }

        public void HandleShowAboutBoxEvents(object sender, ShowAboutBoxArgs args) {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show(mdiForm);
        }

        public void HandleShowMessageEvent(IShowMessageSender sender, ShowMessageArgs args) {
            sender.Result = MessageBox.Show(args.Text, args.Caption);
        }

        public void HandleEnterVotes(object sender, EnterVotesArgs args) {
            frmEnterVotes voteForm = makeMDIChildForm<frmEnterVotes>();
            voteForm.Show();
        }

        public void HandleCountyForm(object sender, CountyFormArgs args) {
            frmCounty frmCounty = makeMDIChildForm<frmCounty>();
            frmCounty.loadCounty(args.ID);
            frmCounty.Show();
        }

        public void HandleCandidate(object sender, CandidateArgs args) {
            frmCandidate candidateForm = makeMDIChildForm<frmCandidate>();
            candidateForm.loadCandidate(args.ID);
            candidateForm.Show();
        }

        public void HandleContest(object sender, ContestArgs args) {
            frmContest contestForm = makeMDIChildForm<frmContest>();
            contestForm.loadContest(args.ID);
            contestForm.Show();
        }

        public void HandlePoliticalParty(object sender, PoliticalPartyArgs args) {
            frmPoliticalParty politicalPartyForm = makeMDIChildForm<frmPoliticalParty>();
            politicalPartyForm.loadPoliticalParty(args.ID);
            politicalPartyForm.Show();
        }

        public void HandleElection(object sender, ElectionArgs args)
        {
            frmElection electionForm = makeMDIChildForm<frmElection>();
            electionForm.loadElection(args.ID);
            electionForm.Show();
        }

        public void HandleErrorMessage(object sender, ShowErrorMessageArgs args) {
            LOG.Info(args.Text, args.Exception);
            MessageBox.Show(args.Text, args.Caption);
        }

        public void HandleElectionReport(object sender, ElectionReportArgs args)
        {
            frmElectionReport electionReportForm = makeMDIChildForm<frmElectionReport>();
            electionReportForm.Show();
        }
    }
}