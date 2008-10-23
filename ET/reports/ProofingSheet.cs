/**
 *  Copyright (C) 2008 Knight Rider Consulting, Inc.
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
using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.ui.util;
using KnightRider.ElectionTracker.util;

namespace KnightRider.ElectionTracker.reports {
    public class ProofingSheet : BaseReport<Election> {
        private const int CONTEST_COLUMN_WIDTH = 25;
        private const int COUNTY_COLUMN_WIDTH = 17;
        private const int WARD_COLUMN_WIDTH = 9;
        private const string COLUMN_PADDING = "   ";

        private static readonly IComparer<ElectionContest> BY_NAME = new ElectionContestComparer();
        private int RESPONSE_COLUMN_WIDTH = 30;

        public ProofingSheet(IList<TreeViewFilter> filters) : base("Election Proofing Sheet", false, filters) { }

        protected override bool performGenerate(Election entity) {
            header.Add(CenterText("ELECTION PROOFING SHEET"));
            header.Add(CenterText("ELECTION DATE " + entity));
            header.Add("");
            header.Add("                                          REPORTING");
            header.Add("CONTEST                  COUNTY           UNITS       CANDIDATE");
            header.Add("----------------------   --------------   ---------   ----------------------");

            List<ElectionContest> contests = new List<ElectionContest>(entity.ElectionContests);

            contests.Sort(BY_NAME);

            foreach (ElectionContest contest in contests) {
                body.Add("<KEEP_TOGETHER>");

                int wardCount = 0;
                int responseCount = 0;
                int countyCount = 0;
                int totalResponses = contest.Responses.Count;
                int totalCounties = contest.Counties.Count;
                bool printContestColumn = true;

                string contestName = PadString(contest.Contest.Name, CONTEST_COLUMN_WIDTH);

                // If there are no responses or counties the while loop later
                // in this method will fail to print the contest name, so print it now.

                string contestColumn;
                string countyColumn;
                string wardColumn;
                string responseColumn;

                if (totalResponses == 0 && totalCounties == 0)
                {
                    contestColumn = PadString(contestName, CONTEST_COLUMN_WIDTH);
                    countyColumn = PadString("*** NO COUNTIES ***", COUNTY_COLUMN_WIDTH + WARD_COLUMN_WIDTH);
                    wardColumn = "";
                    responseColumn = "*** NO CANDIDATES ***";
                    body.Add(contestColumn + countyColumn + wardColumn + COLUMN_PADDING + responseColumn);
                    
                } else {
                    while (responseCount < totalResponses || countyCount < totalCounties) {
                        if (printContestColumn) {
                            printContestColumn = false;
                            contestColumn = PadString(contestName, CONTEST_COLUMN_WIDTH);
                        } else {
                            contestColumn = PadString(" ", CONTEST_COLUMN_WIDTH);
                        }

                        if (countyCount < totalCounties) {
                            ContestCounty currentCounty = contest.Counties[countyCount];
                            wardColumn = PadString(currentCounty.WardCount.ToString(), WARD_COLUMN_WIDTH, false);
                            countyColumn = PadString(currentCounty.County.Name, COUNTY_COLUMN_WIDTH);
                            wardCount += currentCounty.WardCount;
                        } else {
                            wardColumn = PadString(" ", WARD_COLUMN_WIDTH);
                            countyColumn = PadString(" ", COUNTY_COLUMN_WIDTH);
                        }

                        
                        if (responseCount < totalResponses) {
                            Response currentResponse = contest.Responses[responseCount];
                            responseColumn = PadString(currentResponse.ToString(), RESPONSE_COLUMN_WIDTH);
                        } else {
                            responseColumn = PadString(" ", RESPONSE_COLUMN_WIDTH);
                        }

                        body.Add(contestColumn + countyColumn + wardColumn + COLUMN_PADDING + responseColumn);
                        responseCount++;
                        countyCount++;
                    }
                }
                body.Add(PadString(" ", CONTEST_COLUMN_WIDTH + COUNTY_COLUMN_WIDTH) + PadString("", WARD_COLUMN_WIDTH, '-', true));
                body.Add(PadString(" ", CONTEST_COLUMN_WIDTH) + PadString("Total Reporting  ", COUNTY_COLUMN_WIDTH, false));
                body.Add(PadString(" ", CONTEST_COLUMN_WIDTH) + PadString("Units:  ", COUNTY_COLUMN_WIDTH, false) + PadString(wardCount.ToString(), WARD_COLUMN_WIDTH, false));
                body.Add("");
                body.Add("</KEEP_TOGETHER>");
            }

            footer.Add("Page ${Page}     " + DateTime.Now);

            return true;
        }
    }
}