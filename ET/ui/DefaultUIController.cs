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
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.events;
using log4net;
using Spring.Context;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal class DefaultUIController : UIController, IApplicationContextAware {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (DefaultUIController));
        private frmEnterVotes voteForm;
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
            if (voteForm == null || voteForm.Visible == false)
                voteForm = makeMDIChildForm<frmEnterVotes>();
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

        public void HandleProofingSheet(object sender, ProofingSheetArgs args) {
            frmProofingSheet proofingSheetForm = makeMDIChildForm<frmProofingSheet>();
            proofingSheetForm.Show();
        }

        public void HandleElection(object sender, ElectionArgs args) {
            frmElection electionForm = makeMDIChildForm<frmElection>();
            electionForm.loadElection(args.ID);
            electionForm.Show();
        }

        public void HandleErrorMessage(object sender, ShowErrorMessageArgs args) {
            LOG.Info(args.Text, args.Exception);
            MessageBox.Show(args.Text, args.Caption);
        }

        public void HandleElectionReport(object sender, ElectionReportArgs args) {
            frmElectionReport electionReportForm = makeMDIChildForm<frmElectionReport>();
            electionReportForm.Show();
        }

        public void HandleContestVoteSumry(object sender, ContestVoteSumryArgs args) {
            frmContestVoteSumry contestVoteSumry = makeMDIChildForm<frmContestVoteSumry>();
            contestVoteSumry.Show();
        }

        public void HandleCountyContactForm(object sender, CountyContactFormArgs args) {
            frmCountyContactForm countyContactForm = makeMDIChildForm<frmCountyContactForm>();
            countyContactForm.Show();
        }
    }
}