using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DesignByContract;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.ui {
    public partial class BaseMDIChild : Form {
        public BaseMDIChild() {
            InitializeComponent();
        }

        internal static bool reportFaults(IList<Fault> faults) {
            Check.Assert(faults != null, "Null: faults");
            bool result = faults.Count == 0;
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

//        protected static void EnableControls(Control.ControlCollection controls, bool enabled) {
//            if (controls == null) return;
//            foreach (Control control in controls) {
//                if (control.Tag != null && control.Tag.ToString().Contains("lock=true")) {
//                    if (typeof (TextBox).Equals(control.GetType())) {
//                        ((TextBox) control).ReadOnly = !enabled;
//                    } else {
//                        control.Enabled = enabled;
//                    }
//                }
//                EnableControls(control.Controls, enabled);
//            }
//        }

        public virtual void btnEdit_Click(object sender, EventArgs e) {
            //EnableControls(Controls, true);
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

        public virtual void btnDelete_Click(object sender, EventArgs e) {
            
        }

        public virtual void cboGoTo_SelectedIndexChanged(object sender, EventArgs e) {
            //EnableControls(Controls, false);
        }
    }
}