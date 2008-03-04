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
using System.Collections.Generic;
using System.Windows.Forms;
using Common.Logging;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.ui {
    internal sealed class VoteEnterer : Panel {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (VoteEnterer));

        private static readonly IList<string> excluded = new List<string>();

        private readonly IList<ContestDisplay> displays = new List<ContestDisplay>();

        static VoteEnterer() {
            excluded.Add("ID");
            excluded.Add("WardCount");
            excluded.Add("WardsReporting");
        }

        public VoteEnterer(Election election, County county, ContestCountyDAO contestCountyDAO,
                           ResponseValueDAO responseValueDAO) {
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
                    LOG.Error("Unalbe to locate contest county where countyID =" + county.ID +
                              " AND electionContestID =" + electionContest.ID);
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