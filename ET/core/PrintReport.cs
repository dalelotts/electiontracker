using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace edu.uwec.cs.cs355.group4.et.core
{
    class PrintReport
    {
        private PrintDocument doc;
        private String textToPrint;

        public PrintReport()
        {
            ;
        }

        public void print(String text)
        {
            PrintDialog pd = new PrintDialog();

            textToPrint = text;
            doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            Font printFont = new Font("Courier New", 12);
            e.Graphics.DrawString(textToPrint, printFont, Brushes.Black, 0, 0);
        }
    }
}
