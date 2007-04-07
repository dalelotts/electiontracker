using System;
using System.Windows.Forms;

namespace edu.uwec.cs.cs355.group4.et.ui {
    public partial class BaseMDIChild : Form {
        public BaseMDIChild() {
            InitializeComponent();
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