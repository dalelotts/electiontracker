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
using System.Windows.Forms;
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

//                ElectionDAO electionDAO = (ElectionDAO) ctx.GetObject("ElectionDAO");
//
//
//                ContestCountyDAO contestCountyDAO = (ContestCountyDAO)ctx.GetObject("ContestCountyDAO");
//
//                IList<string> excluded = new List<string>();
//                excluded.Add("ID");
//                excluded.Add("WardCount");
//                excluded.Add("WardsReporting");
//
//                IList<Election> elections = electionDAO.findActive();
//
//                foreach (Election election in elections) {
//                    IList<ElectionContest> contests = election.ElectionContests;
//                    foreach (ElectionContest contest in contests) {
//                        IList<ContestCounty> counties = contest.Counties;
//                        foreach (ContestCounty county in counties) {
//                            Console.WriteLine(county.County.Name);
//
//                            ContestCounty example = new ContestCounty();
//                            example.County = county.County;
//                            example.ElectionContest = contest;
//
//                            IList<ContestCounty> contestCounties = contestCountyDAO.findByExample(example, excluded);
//
//                            foreach (ContestCounty contestCounty in contestCounties) {
//                                Console.WriteLine(contestCounty.County.Name);  
//                            }
//
//                        }
//                    }
//                }


                UIController controller = (UIController) ctx.GetObject("UIController");
                Application.Run(controller.getMDIForm());
            } catch (Exception ex) {
                LOG.Error(ex.Message, ex);
            }
        }
    }
}