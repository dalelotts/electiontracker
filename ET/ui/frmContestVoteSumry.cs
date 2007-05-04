using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.db;
using System.Drawing.Printing;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.ui.util;

namespace edu.uwec.cs.cs355.group4.et.ui
{
    class frmContestVoteSumry : frmAbstractReport 
    {
        frmContestVoteSumry(ElectionDAO electionDAO)
            : base(electionDAO) { }

        protected override string GetTitle()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override IList<Election> GetElections()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void CreateReport(Election elc)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
