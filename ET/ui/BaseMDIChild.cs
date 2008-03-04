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
using DesignByContract;
using KnightRider.ElectionTracker.db;
using KnightRider.ElectionTracker.events;

namespace KnightRider.ElectionTracker.ui {
    public partial class BaseMDIChild : Form {
        public event GenericEventHandler<Object, ShowErrorMessageArgs> showErrorMessage;
        public event GenericEventHandler<Object, MakePersistentArgs> makePersistent;
        public event GenericEventHandler<Object, MakeTransientArgs> makeTransient;

        public BaseMDIChild() {
            InitializeComponent();
        }

        internal static bool reportFaults(IList<Fault> faults) {
            Check.Assert(faults != null, "Null: faults");
            if (faults.Count == 0) return true;
            bool result = false;
            bool encounteredError = false;
            string message = "";
            //Go through the list of faults and build message for user.
            foreach (Fault fault in faults) {
                if (fault.IsError) {
                    encounteredError = true;
                    message += "Error: " + fault.Message;
                } else {
                    message += "Warning: " + fault.Message;
                }
                message += "\n\n";
            }

            if (encounteredError) {
                message += "Please correct the above errors and try again.";
                MessageBox.Show(message, "Validation Failure", MessageBoxButtons.OK);
            } else {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult messageResult =
                    MessageBox.Show(message + "Would you like to save anyway?", "Validation Failure", buttons);
                if (messageResult == DialogResult.Yes) {
                    result = true;
                }
            }

            return result;
        }

        public virtual void btnAdd_Click(object sender, EventArgs e) {
            //EnableControls(Controls, true);
        }

        public virtual void btnSave_Click(object sender, EventArgs e) {
            //EnableControls(Controls, false);
        }

        public virtual void btnReset_Click(object sender, EventArgs e) {
            //EnableControls(Controls, false);
        }

        public virtual void btnDelete_Click(object sender, EventArgs e) {}

        public virtual void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            //EnableControls(Controls, false);
        }

        protected void reportException(string methodName, Exception ex) {
            string message = "Unable to complete the requested action.\n\nEncountered '" + ex.GetType() +
                             "' exception in the '" + methodName + "' method.";
            ShowErrorMessageArgs args = new ShowErrorMessageArgs(message, ex);
            EventUtil.RaiseEvent<Object, ShowErrorMessageArgs>(showErrorMessage, this, args);
        }

        protected void raiseMakePersistentEvent() {
            MakePersistentArgs args = new MakePersistentArgs();
            EventUtil.RaiseEvent<Object, MakePersistentArgs>(makePersistent, this, args);
        }

        protected void raiseMakeTransientEvent() {
            MakeTransientArgs args = new MakeTransientArgs();
            EventUtil.RaiseEvent<Object, MakeTransientArgs>(makeTransient, this, args);
        }
    }
}