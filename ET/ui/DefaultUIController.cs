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
using System.Reflection;
using System.Windows.Forms;
using Common.Logging;
using KnightRider.ElectionTracker.events;
using Spring.Context;
using Spring.Objects.Events.Support;

namespace KnightRider.ElectionTracker.ui {
    internal class DefaultUIController : UIController, IApplicationContextAware {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (DefaultUIController));
        private Form voteEntryForm;
        private Form mdiForm;
        private IApplicationContext context;

        public Form MdiForm {
            set {
                if (mdiForm != null) throw new InvalidOperationException("MDIForm already set.");
                mdiForm = value;
                wireSubscriberToPublisher(mdiForm, typeof (DefaultUIController), this);
            }
        }

        IApplicationContext IApplicationContextAware.ApplicationContext {
            get { return context; }
            set { context = value; }
        }

        Form UIController.getMDIForm() {
            return mdiForm;
        }

        public void HandleMakePersistent(object sender, MakePersistentArgs args) {
            ((MDIForm) mdiForm).refreshCurrentFilter();
        }

        public void HandleMakeTransient(object sender, MakeTransientArgs args) {
            ((MDIForm) mdiForm).refreshCurrentFilter();
        }

        private Form makeMDIChildForm(string objectName) {
            try {
                Form form = (Form) context.GetObject(objectName);
                form.MdiParent = mdiForm;
                wireTextBoxTrimOnLeave(form);
                wireSubscriberToPublisher(form, GetType(), this);
                return form;
            } catch (Exception ex) {
                LOG.Error("makeMDIChildForm(" + objectName + ")", ex);
                string message = "Unable to create MDI Child form named " + objectName + "\n\nPlease contact tech support and inform them that there is a configuration issue with the application.\n\nDetailed information about this error was logged to " + Application.StartupPath + "\\logs\\";
                MessageBox.Show(message, "Spring Configuration Issue");
                return null;
            }
        }

        public void HandleShowAboutBoxEvents(object sender, ShowAboutBoxArgs args) {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show(mdiForm);
        }

        public void HandleShowServerOptionsEvents(object sender, ShowServerOptionsArgs args)
        {
            frmServerOptions t = new frmServerOptions();
            t.Show(mdiForm);
        }

        public void HandleShowMessageEvent(IShowMessageSender sender, ShowMessageArgs args) {
            sender.Result = MessageBox.Show(args.Text, args.Caption);
        }

        public void HandleEnterVotes(object sender, EnterVotesArgs args) {
            if (voteEntryForm == null || voteEntryForm.Visible == false)
                voteEntryForm = makeMDIChildForm(args.ObjectName);
            if (voteEntryForm != null) voteEntryForm.Show();
        }

        public void HandleCountyForm(object sender, CountyFormArgs args) {
            frmCounty form = (frmCounty) makeMDIChildForm(args.ObjectName);
            if (form != null) {
                form.loadCounty(args.ID);
                form.Show();
            }
        }

        public void HandleCandidate(object sender, CandidateArgs args) {
            frmCandidate form = (frmCandidate) makeMDIChildForm(args.ObjectName);
            if (form != null) {
                form.loadCandidate(args.ID);
                form.Show();
            }
        }

        public void HandleReport(object sender, ReportArgs args) {
            Form form = makeMDIChildForm(args.ReportName);
            if (form != null) form.Show();
        }

        public void HandleContest(object sender, ContestArgs args) {
            frmContest form = (frmContest) makeMDIChildForm(args.ObjectName);
            if (form != null) {
                form.loadContest(args.ID);
                form.Show();
            }
        }

        public void HandlePoliticalParty(object sender, PoliticalPartyArgs args) {
            frmPoliticalParty form = (frmPoliticalParty) makeMDIChildForm(args.ObjectName);
            if (form != null) {
                form.loadPoliticalParty(args.ID);
                form.Show();
            }
        }


        public void HandleElection(object sender, ElectionArgs args) {
            frmElection form = (frmElection) makeMDIChildForm(args.ObjectName);
            if (form != null) {
                form.loadElection(args.ID);
                form.Show();
            }
        }

        public void HandleErrorMessage(object sender, ShowErrorMessageArgs args) {
            string message = args.Text;
            LOG.Error(message, args.Exception);
            message += "\n\nPlease try again.\n\nDetailed information about this error was logged to " + Application.StartupPath + "\\logs\\";
            MessageBox.Show(message, args.Caption);
        }

        private static void trimTextBoxOnLeave(Object sender, EventArgs e) {
            if (sender is TextBox) {
                TextBox senderTextBox = (TextBox) sender;
                senderTextBox.Text = senderTextBox.Text.Trim();
            }
        }

        private static void wireTextBoxTrimOnLeave(Form form) {
            foreach (Control control in form.Controls) {
                wireTextBoxTrimOnLeave(control);
            }
        }

        private static void wireTextBoxTrimOnLeave(Control control) {
            if (control is TextBox) {
                control.Leave += new EventHandler(trimTextBoxOnLeave);
            }
            foreach (Control childControl in control.Controls) {
                wireTextBoxTrimOnLeave(childControl);
            }
        }

        private static void wireSubscriberToPublisher(object currentPublisher, Type currentSubscriberType, object subscriber) {
            Type currentPublisherType = currentPublisher.GetType();
            EventInfo[] events = currentPublisherType.GetEvents();
            foreach (EventInfo currentEvent in events) {
                Type eventHandlerType = currentEvent.EventHandlerType;
                MethodInfo invoke = eventHandlerType.GetMethod("Invoke");
                MethodInfo eventHandler = EventManipulationUtils.GetMethodInfoMatchingSignature(invoke, currentSubscriberType);

                if (eventHandler != null && eventHandler.IsPublic) {
                    currentEvent.AddEventHandler(currentPublisher, EventManipulationUtils.GetHandlerDelegate(eventHandlerType, subscriber, eventHandler));
                }
            }
        }
    }
}