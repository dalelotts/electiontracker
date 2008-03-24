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
using KnightRider.ElectionTracker.util;

namespace KnightRider.ElectionTracker.reports {
    public class ElectionQuickScanSheet : BaseReport<Election> {
        public ElectionQuickScanSheet() : base("Election Candidates' Quick Scan Sheet", false) {}

        private static readonly IComparer<ElectionContest> CONTESTS_BY_NAME = new ElectionContestComparer();
        private static readonly IComparer<Response> RESPONSE_BY_VOTE_THEN_NAME = new ResponseComparer(true);

        private const int CONTEST_COLUMN_WIDTH = 20;
        private const int RESPONSE_COLUMN_WIDTH = 30;
        private const int REPORTING_COLUMN_WIDTH = 10;
        private const int VOTE_COLUMN_WIDTH = 10;
        private const string COLUMN_PADDING = "   ";

        protected override bool performGenerate(Election entity) {
            header.Add(CenterText("ELECTION CANDIDATES' QUICK SCAN SHEET"));
            header.Add(CenterText(" ELECTION DATE " + entity.Date.ToShortDateString()));
            header.Add("");
            string contestHeader = FormatTextLength("CONTEST", CONTEST_COLUMN_WIDTH, true);
            string responseHeader = FormatTextLength("CANDIDATE", RESPONSE_COLUMN_WIDTH - 7, true);
            string reportingHeader = FormatTextLength("% WARDS REPORTING", REPORTING_COLUMN_WIDTH + 7, true);
            string votesHeader = "  % OF VOTE";
            header.Add(contestHeader + COLUMN_PADDING + responseHeader + COLUMN_PADDING + reportingHeader + COLUMN_PADDING + votesHeader);
            List<ElectionContest> electionContests = new List<ElectionContest>(entity.ElectionContests);
            header.Add(CenterText("=", '='));

            electionContests.Sort(CONTESTS_BY_NAME);

            foreach (ElectionContest electionContest in electionContests) {
                body.Add("<KEEP_TOGETHER>");
                body.Add("");
                string contestColumn = FormatTextLength(electionContest.Contest.Name, CONTEST_COLUMN_WIDTH, true);
                string reportingColumn = FormatTextLength((electionContest.GetWardsReportingPercentage() * 100).ToString("0.0") + "%", REPORTING_COLUMN_WIDTH, false);

                List<Response> responses = new List<Response>(electionContest.Responses);

                responses.Sort(RESPONSE_BY_VOTE_THEN_NAME);

                int totalVotes = electionContest.GetTotalVotes();

                foreach (Response response in responses) {
                    string responseColumn = FormatTextLength(response.ToString(), RESPONSE_COLUMN_WIDTH, true);

                    int responseVotes = response.GetTotalVotes();
                    double percentage = 0.0;
                    if (totalVotes > 0) {
                        percentage = ((double) responseVotes / (double) totalVotes) * 100;
                    }

                    string voteColumn = FormatTextLength(percentage.ToString("0.0") + "%", VOTE_COLUMN_WIDTH, false);

                    body.Add(contestColumn + COLUMN_PADDING + responseColumn + COLUMN_PADDING + reportingColumn + COLUMN_PADDING + voteColumn);

                    contestColumn = FormatTextLength(" ", CONTEST_COLUMN_WIDTH); // Only print the contest on the first line.
                    reportingColumn = FormatTextLength(" ", REPORTING_COLUMN_WIDTH); // Only print the % reporting wards on the first line.
                }
                body.Add("</KEEP_TOGETHER>");
            }

            footer.Add(DateTime.Now.ToString());
            return true;
        }
    }
}