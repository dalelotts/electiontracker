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
    public class ElectionQuickScanSheet : BaseReport<Election> {
        public ElectionQuickScanSheet(IList<TreeViewFilter> filters) : base("Election Candidates' Quick Scan Sheet", false, filters) { }

        private static readonly IComparer<ElectionContest> CONTESTS_BY_NAME = new ElectionContestComparer();
        private static readonly IComparer<Response> RESPONSE_BY_VOTE_THEN_NAME = new ResponseComparer(true);

        private const int CONTEST_COLUMN_WIDTH = 20;
        private const int RESPONSE_COLUMN_WIDTH = 30;
        private const int REPORTING_COLUMN_WIDTH = 20;
        private const int VOTE_COUNT_WIDTH = 7;
        private const int VOTE_PERCENTAGE_WIDTH = 8;
        private const int VOTE_COLUMN_WIDTH = VOTE_COUNT_WIDTH + VOTE_PERCENTAGE_WIDTH;
        private const string COLUMN_PADDING = "   ";

        protected override bool performGenerate(Election entity) {
            header.Add(CenterText("ELECTION CANDIDATES' QUICK SCAN SHEET"));
            header.Add(CenterText(" ELECTION DATE " + entity.Date.ToShortDateString()));
            header.Add("");
            string contestHeader = PadString("CONTEST", CONTEST_COLUMN_WIDTH, true);
            string responseHeader = PadString("CANDIDATE", RESPONSE_COLUMN_WIDTH, true);
            string reportingHeader1 = PadString("% OF REPORTING", REPORTING_COLUMN_WIDTH, true);
            string reportingHeader2 = PadString("UNITS REPORTING", REPORTING_COLUMN_WIDTH, true);
            string votesHeader = "NUMBER OF VOTES";
            header.Add(PadString("", CONTEST_COLUMN_WIDTH) + PadString("", RESPONSE_COLUMN_WIDTH) + reportingHeader1);
            header.Add(contestHeader + responseHeader+ reportingHeader2 + votesHeader);
            List<ElectionContest> electionContests = new List<ElectionContest>(entity.ElectionContests);
            header.Add(CenterText("=", '='));

            electionContests.Sort(CONTESTS_BY_NAME);

            foreach (ElectionContest electionContest in electionContests) {
                body.Add("<KEEP_TOGETHER>");
                body.Add("");
                string contestColumn = PadString(electionContest.Contest.Name, CONTEST_COLUMN_WIDTH, true);
                string reportingColumn = PadString((electionContest.GetWardsReportingPercentage() * 100).ToString("0.0") + "%", REPORTING_COLUMN_WIDTH, true);

                List<Response> responses = new List<Response>(electionContest.Responses);

                responses.Sort(RESPONSE_BY_VOTE_THEN_NAME);

                int totalVotes = electionContest.GetTotalVotes();

                foreach (Response response in responses) {
                    string responseColumn = PadString(response.ToString(), RESPONSE_COLUMN_WIDTH, true);

                    int responseVotes = response.GetTotalVotes();
                    double percentage = 0.0;
                    if (totalVotes > 0) {
                        percentage = ((double) responseVotes / (double) totalVotes) * 100;
                    }

                    string voteColumn = PadString(responseVotes.ToString(), VOTE_COUNT_WIDTH, false) + PadString(" (" + percentage.ToString("0.0") + "%)", VOTE_PERCENTAGE_WIDTH, true);

                    body.Add(contestColumn + responseColumn + reportingColumn + voteColumn);

                    contestColumn = PadString(" ", CONTEST_COLUMN_WIDTH); // Only print the contest on the first line.
                    reportingColumn = PadString(" ", REPORTING_COLUMN_WIDTH); // Only print the % reporting units on the first line.
                }
                body.Add("</KEEP_TOGETHER>");
            }

            footer.Add("Page ${Page}     " + DateTime.Now);
            return true;
        }
    }
}