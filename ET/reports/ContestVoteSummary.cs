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
using System.Drawing;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.ui.util;
using KnightRider.ElectionTracker.util;

namespace KnightRider.ElectionTracker.reports {
    public class ContestVoteSummary : BaseReport<Election> {
        private static readonly IComparer<ElectionContest> CONTESTS_BY_NAME = new ElectionContestComparer();
        private static readonly IComparer<Response> RESPONSE_BY_VOTE_THEN_NAME = new ResponseComparer(true);
        private static readonly Font font = new Font("Courier New", 9);
        private const int ALL_RESPONSE_SPACE = 78;
        private const int COUNTY_COLUMN_WIDTH = 17;


        public ContestVoteSummary(IList<TreeViewFilter> filters) : base("Contest Vote Summary", true, filters) { }

        protected override bool performGenerate(Election entity) {
            
            header.Add(CenterText("CONTEST VOTE SUMMARY"));
            header.Add(CenterText(" ELECTION DATE " + entity.Date.ToShortDateString()));
            header.Add("");

            List<ElectionContest> contests = new List<ElectionContest>(entity.ElectionContests);
            contests.Sort(CONTESTS_BY_NAME);

            foreach (ElectionContest electionContest in contests) {

                body.Add("<KEEP_TOGETHER>");

                // First, determine the responses.  If there's more than three, we can only
                //  fit three, so pick the three most important.
                List<Response> responses = new List<Response>(electionContest.Responses);

                responses.Sort(RESPONSE_BY_VOTE_THEN_NAME);

                string candidateNames = "";
                
                int responseCount = Math.Min(3, responses.Count);

                int responseColumnWidth = ALL_RESPONSE_SPACE / responseCount;

                if (responseCount == 0) {
                    candidateNames = PadString("----------NO CANDIDATES----------", ALL_RESPONSE_SPACE);
                } else {
                    for (int i = 0; i < responseCount; i++) {
                        Response response = responses[i];
                        // Divide the available space equally for all candidates.
                        candidateNames += PadString(response.ToString(), responseColumnWidth, true);
                    }
                }

                
                body.Add(CenterText(" " + electionContest.Contest.Name + " ", '='));
                body.Add("");
                body.Add("County           " + candidateNames + "   Wards             Votes");

                foreach (ContestCounty cc in electionContest.Counties) {
                    string strVoteCounts = PadString(cc.County.Name, COUNTY_COLUMN_WIDTH);

                    for (int i = 0; i < responseCount; i++)
                    {
                        strVoteCounts += GetVoteNumbers(responses[i], cc, responseColumnWidth);
                    }

                    strVoteCounts += PadString(cc.WardsReporting + "/" + cc.WardCount, 7, false);

                    if (cc.WardCount > 0)
                        strVoteCounts += PadString("(" + (((double) cc.WardsReporting / (double) cc.WardCount) * 100).ToString("0.0") + "%)", 12, false);
                    else {
                        if (cc.WardsReporting > 0) {
                            strVoteCounts += PadString("(100.0%)", 12, false);
                        } else {
                            strVoteCounts += PadString("(0.0%)", 12, false);
                        }
                    }
                    strVoteCounts += PadString(" " + cc.GetTotalVotes(), 6, false);
                    body.Add(strVoteCounts);
                }
                body.Add("");

                string strTotals = "Totals           ";
                int totalVotes = electionContest.GetTotalVotes();

                for (int i = 0; i < responseCount; i++) {                    
                    int responseVotes = responses[i].GetTotalVotes();
                    string responseString = responseVotes.ToString();

                    if (totalVotes > 0) {
                        strTotals += PadString(PadString(responseString, 7, false) + PadString(" (" + ((double)responseVotes / (double)totalVotes).ToString("0.0" + "%)"), 12, false), responseColumnWidth);
                    } else {
                        strTotals += PadString(PadString(responseString, 7, false) + PadString("(" + "0.0%)", 12, false), responseColumnWidth);                        
                    }
                }

                strTotals += PadString(electionContest.GetWardsReporting() + "/" + electionContest.GetWardCount(), 7, false) + PadString("(" + (electionContest.GetWardsReportingPercentage() * 100).ToString("0.0") + "%)", 12, false) + PadString(totalVotes.ToString(), 6, false);
                body.Add(strTotals);
                body.Add("</KEEP_TOGETHER>");    
            }

            footer.Add(DateTime.Now.ToString());

            return true;
        }

        private static string GetVoteNumbers(Response response, ContestCounty contestCounty, int columnWidth) {
            ResponseValue resultValue = null;
            foreach (ResponseValue responseValue in contestCounty.ResponseValues) {
                if (responseValue.Response.ID == response.ID) {
                    resultValue = responseValue;
                    break;
                }
            }
            int voteCount = 0;
            double votePercentage = 0.0;
            if (resultValue != null) {
                voteCount = resultValue.VoteCount;
                votePercentage = Math.Round(resultValue.GetVotePercentage() * 100, 2);
            }

            return PadString(PadString(voteCount.ToString(), 7, false) + PadString(" (" + votePercentage + "%)", 12, false), columnWidth, true);            
        }

        public override Font Font() {
            return font;
        }
    }
}