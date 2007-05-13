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
    internal abstract partial class frmAbstractReport : Form
    {
        protected ElectionDAO electionDAO;
        protected PrintDocument docToPrint;
        protected int intPages;
        protected Font printFont;
        protected bool blnLandscape;

        public frmAbstractReport(ElectionDAO electionDAO)
        {
            blnLandscape = false;
            this.electionDAO = electionDAO;
            InitializeComponent();
            printFont = new Font("Courier New", 10);
        }

        private int GetMarginSpot()
        {
            if (blnLandscape)
            {
                return 105;
            }
            else
            {
                return 75;
            }
        }


        protected  string CenterText(string text)
        {
            return CenterText(text, ' ');
        }

        protected static string FormatTextLength(string text, int length)        {
            int j = text.Length;
            if (j < length)            {
                for (int i = 0; i < length - j; i++)
                {
                    text = text + " ";
                }
                return text;
            }
            else            {
                return text.Substring(0, length);
            }
        }

        protected  string CenterText(string text, char space)
        {

            int length = text.Length;
            for (int i = 0; i <= ((GetMarginSpot() - length) / 2); i++)
            {
                text = "" + space + text + space;
            }
            return text;

        }

        protected  string AlignRight(string text)
        {
            int length = text.Length;
            for (int i = 0; i <= ((GetMarginSpot() - length)); i++)
            {
                text = " " + text;
            }
            return text;
        }

        public void LoadElections()
        {
            IList<Election> e = this.GetElections();
            lstElections.Items.Clear();
            foreach (Election election in e)
            {
                lstElections.Items.Add(new ListItemWrapper<Election>(election.Date.ToString(), election));
            }
        }
        #region Events



        protected void btnPrint_Click(object sender, EventArgs e){
            intPages = 0;
            docToPrint.Print();
        }

        protected void btnUp_Click(object sender, EventArgs e){
            if (ppcElection.StartPage > 0){
                ppcElection.StartPage--;
            }
        }

        protected void btnDown_Click(object sender, EventArgs e){
            if (ppcElection.StartPage < intPages)
            {
                ppcElection.StartPage++;
            }
        }

        protected void lstElections_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CreateReport(((ListItemWrapper<Election>)lstElections.SelectedItem).Value);
            }
            catch (Exception ex)
            {
                // Bad selection, just ignore.
            }
        }

        protected void ResizeForm(object sender, EventArgs e){
            lstElections.Height = this.Height - 115;
            btnPrint.Top = this.Height - 69;
            ppcElection.Width = this.Width - 237;
            ppcElection.Height = this.Height - 58;
            btnUp.Left = this.Width - 40;
            btnDown.Left = this.Width - 40;
        }

        protected void frmAbstractReport_Load(object sender, EventArgs e){
            LoadElections();
            this.Text = GetTitle();

        }
        #endregion

        #region Abstract
        protected abstract string GetTitle();
        protected abstract IList<Election> GetElections();
        protected abstract void CreateReport(Election elc);
        #endregion

    }
}