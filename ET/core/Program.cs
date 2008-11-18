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
using System.IO;
using System.Xml;
using System.Windows.Forms;
using Common.Logging;
using KnightRider.ElectionTracker.ui;
using Spring.Context;
using Spring.Context.Support;

namespace KnightRider.ElectionTracker.core {
    internal static class Program {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (Program));

        private static String getBackupArguments()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("spring.xml");
            XmlNode provider = xDoc.GetElementsByTagName("db:provider").Item(0);
            XmlAttributeCollection attributes = provider.Attributes;
            String connectionStr = attributes.GetNamedItem("connectionString").Value;

            //parse: server=foo;database=bar;uid=baz;pwd=quux;
            String[] connectionInfo = connectionStr.Split(new char[] { ';' });

            String database = "";
            String uid = "";
            String pwd = "";

            foreach (String item in connectionInfo)
            {
                if (item.StartsWith("database="))
                {
                    database = item.Substring(9);
                }
                else if (item.StartsWith("uid="))
                {
                    uid = item.Substring(4);
                }
                else if (item.StartsWith("pwd="))
                {
                    pwd = item.Substring(4);
                }
            }

            return "--skip-opt -Q -u " + uid + " " + database + " -p " + pwd;
        }

        [STAThread]
        public static void Main(string[] args) {
            try
            {
                Directory.CreateDirectory("backups");
                String filename = @"backups\backup" + DateTime.Now.ToString("yyyy-MM-dd") + ".sql";

                if (!File.Exists(filename))
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.EnableRaisingEvents = false;
                    proc.StartInfo.FileName = "mysqldump";
                    proc.StartInfo.Arguments = getBackupArguments() + " > " + filename;
                    proc.Start();
                    proc.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
            }

            try {
                Application.EnableVisualStyles();
                IApplicationContext ctx = ContextRegistry.GetContext("spring.root");
                UIController controller = (UIController) ctx.GetObject("UIController");
                Application.Run(controller.getMDIForm());
            } catch (Exception ex) {
                LOG.Error(ex.Message, ex);
            }
        }
    }
}