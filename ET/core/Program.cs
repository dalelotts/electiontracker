using System;
using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui;
using log4net;
using log4net.Config;
using Spring.Context;
using Spring.Context.Support;

namespace edu.uwec.cs.cs355.group4.et.core {
    internal static class Program {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (Program));

        [STAThread]
        public static void Main(string[] args) {
            try {
                Application.EnableVisualStyles();
                XmlConfigurator.Configure();
                IApplicationContext ctx = ContextRegistry.GetContext();

                ElectionDAO electionDAO = (ElectionDAO) ctx.GetObject("ElectionDAO");

                IList<Election> elections = electionDAO.findActive();

                foreach (Election election in elections) {
                    IList<ElectionContest> contests = election.ElectionContests;
                    foreach (ElectionContest contest in contests) {
                        IList<ContestCounty> counties = contest.Counties;
                        foreach (ContestCounty county in counties) {
                            Console.WriteLine(county.County.Name);
                        }
                    }
                }


                UIController controller = (UIController) ctx.GetObject("UIController");
                Application.Run(controller.getMDIForm());
            } catch (Exception ex) {
                LOG.Error(ex.Message, ex);
            }
        }
    }
}