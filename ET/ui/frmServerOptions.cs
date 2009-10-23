using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace KnightRider.ElectionTracker.ui
{
    internal sealed partial class frmServerOptions : Form
    {
        private String host = "";
        private String uname = "";
        private String passwd = "";
        private String database = "";

        private String filename = "spring.xml";

        public frmServerOptions()
        {
            InitializeComponent();
        }

        private void ServerOptions_Load(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(filename);
                XmlNode provider = xDoc.GetElementsByTagName("db:provider").Item(0);
                XmlAttributeCollection attributes = provider.Attributes;
                String connectionStr = attributes.GetNamedItem("connectionString").Value;
                String[] connectionInfo = connectionStr.Split(new char[] { ';' });

                foreach (String item in connectionInfo)
                {
                    if (item.StartsWith("database="))
                    {
                        this.database = item.Substring(9);
                    }
                    else if (item.StartsWith("uid="))
                    {
                        this.uname = item.Substring(4);
                    }
                    else if (item.StartsWith("pwd="))
                    {
                        this.passwd = item.Substring(4);
                    }
                    else if (item.StartsWith("Server="))
                    {
                        this.host = item.Substring(7);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error with reading Xml file.");
            }

            this.txtDatabase.Text = this.database;
            this.txtHost.Text = this.host;
            this.txtPasswd.Text = this.passwd;
            this.txtUname.Text = this.uname;
        }

        private void txtUname_TextChanged(object sender, EventArgs e)
        {
            this.uname = txtUname.Text;
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            this.host = txtHost.Text;
        }

        private void txtpasswd_TextChanged(object sender, EventArgs e)
        {
            this.passwd = txtPasswd.Text;
        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            this.database = txtDatabase.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String connectionStr = "Server=" + this.host + ";database=" + this.database + ";uid=" + this.uname + ";pwd=" + this.passwd + ";";

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(filename);
                
                XmlNode provider = xDoc.GetElementsByTagName("db:provider").Item(0);

                XmlAttributeCollection attributes = provider.Attributes;
                attributes.GetNamedItem("connectionString").Value = connectionStr;

                xDoc.Save(filename);
            }
            catch
            {
                MessageBox.Show("Error with saving Xml file.");
            }

            MessageBox.Show("Settings saved, please restart the application.");
        }
    }
}
