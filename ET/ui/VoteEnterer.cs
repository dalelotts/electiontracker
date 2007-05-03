using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using log4net;

namespace edu.uwec.cs.cs355.group4.et.ui {
    internal sealed class VoteEnterer : Panel {

        private static readonly ILog LOG = LogManager.GetLogger(typeof(VoteEnterer));

        private static readonly IList<string> excluded = new List<string>();

        private readonly IList<ContestDisplay> displays = new List<ContestDisplay>();

        static VoteEnterer() {
            excluded.Add("ID");
            excluded.Add("WardCount");
            excluded.Add("WardsReporting");
        }

        public VoteEnterer(Election election, County county, ContestCountyDAO contestCountyDAO, ResponseValueDAO responseValueDAO) {
            int currentTop = 0;

            foreach (ElectionContest electionContest in election.ElectionContests) {
                // To Do: Figure out why query by example does not work.
//                ContestCounty example = new ContestCounty();
//                example.County = county;
//                example.ElectionContest = electionContest;
//                IList<ContestCounty> contestCounties = contestCountyDAO.findByExample(example, excluded);

                IList<ContestCounty> contestCounties = contestCountyDAO.find(county.ID, electionContest.ID);

                if (contestCounties.Count == 1) {
                    ContestDisplay display = new ContestDisplay(contestCounties[0], contestCountyDAO, responseValueDAO);
                    display.Top = currentTop;
                    currentTop += display.Height + 1;
                    Controls.Add(display);
                    displays.Add(display);
                } else {
                    LOG.Error("Unalbe to locate contest county where countyID =" + county.ID + " AND electionContestID =" + electionContest.ID);
                }
            }
            AutoScroll = true;
            BorderStyle = BorderStyle.FixedSingle;
        }

        public void Persist() {
            foreach (ContestDisplay display in displays) {
                display.Persist();
            }
        }
    }
}