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

namespace KnightRider.ElectionTracker.reports
{
    public class ContestVoteSummary : BaseReport<Election>
    {
        private static readonly IComparer<ElectionContest> CONTESTS_BY_NAME = new ElectionContestComparer();
        private static readonly IComparer<Response> RESPONSE_BY_VOTE_THEN_NAME = new ResponseComparer(true, false);
        private static readonly Font font = new Font("Courier New", 9);
        private const int ALL_RESPONSE_SPACE = 78;
        private const int COUNTY_COLUMN_WIDTH = 17;
        private const int RESPONSES_PER_ROW = 3;        // number of responses that fit in one row
        private const int COLUMN_PADDING = 5;
        private const int VOTE_COUNT_WIDTH = 7;
        private const int VOTE_PERCENTAGE_WIDTH = 12;


        public ContestVoteSummary(IList<TreeViewFilter> filters) : base("Contest Vote Summary", true, filters) { }

        protected override bool performGenerate(Election entity)
        {
            header.Add(CenterText("CONTEST VOTE SUMMARY"));
            header.Add(CenterText(" ELECTION DATE " + entity.Date.ToShortDateString()));
            header.Add("");

            List<ElectionContest> contests = new List<ElectionContest>(entity.ElectionContests);
            contests.Sort(CONTESTS_BY_NAME);

            foreach (ElectionContest electionContest in contests)
            {
                // First, determine the responses.  We need to display information for all candidates, 
                //  so will need to use all responses and generate multiple rows if needed
                List<Response> responses = new List<Response>(electionContest.Responses);

                responses.Sort(RESPONSE_BY_VOTE_THEN_NAME);

                string candidateNames = "";
                int responseCount = responses.Count;
                int currentRowNum = 0;

                // Special case for no candidates in contest
                if (responseCount == 0)
                {
                    body.Add("<KEEP_TOGETHER>");

                    candidateNames = PadString("----------NO CANDIDATES----------", ALL_RESPONSE_SPACE);

                    body.Add(CenterText(" " + electionContest.Contest.Name + " ", '='));
                    body.Add("");
                    body.Add("County           " + candidateNames + " Reporting Units     Votes");

                    body.Add("</KEEP_TOGETHER>");
                }

                while (responses.Count > 0)
                {
                    candidateNames = "";                        // initialize for next row

                    int responsesThisRow = 0;
                    currentRowNum++;

                    // determine number of candidates we will fit in this row
                    int currentResponseSpaceUsage = 0;
                    while ((currentResponseSpaceUsage < ALL_RESPONSE_SPACE) && (responsesThisRow < responses.Count))
                    {
                        int padding = 0;
                        if (((Response)(responses[responsesThisRow])).ToString().Length < VOTE_PERCENTAGE_WIDTH + VOTE_COUNT_WIDTH)
                        {
                            padding = VOTE_COUNT_WIDTH + VOTE_PERCENTAGE_WIDTH - ((Response)(responses[responsesThisRow])).ToString().Length;
                        }
 
                        if (((Response)(responses[responsesThisRow])).ToString().Length + padding + currentResponseSpaceUsage < ALL_RESPONSE_SPACE)
                        {
                            responsesThisRow++;
                            currentResponseSpaceUsage = currentResponseSpaceUsage + ((Response)(responses[responsesThisRow - 1])).ToString().Length;
                            candidateNames += PadString(((Response)(responses[responsesThisRow - 1])).ToString(), ((Response)(responses[responsesThisRow - 1])).ToString().Length + COLUMN_PADDING + padding, true);
                            currentResponseSpaceUsage = currentResponseSpaceUsage + COLUMN_PADDING + padding;  // Allow for space after name to separate columns;
                        }
                        else
                        {
                            if (responsesThisRow == 0)
                            {
                                // we have to put something in the row, otherwise we hang forever always looping to the next row and never advancing.
                                candidateNames += PadString(((Response)(responses[responsesThisRow])).ToString(), ALL_RESPONSE_SPACE - COLUMN_PADDING, true);
                                currentResponseSpaceUsage = ALL_RESPONSE_SPACE;
                                responsesThisRow++;
                            } else
                            {
                                // move on to next row
                                currentResponseSpaceUsage = ALL_RESPONSE_SPACE;
                            }
                        }
                    }

                    // pad candidate names such that the reporting units and votes column always align
                    candidateNames = PadString(candidateNames, ALL_RESPONSE_SPACE, true);

                    body.Add("<KEEP_TOGETHER>");

                    if (currentRowNum == 1)
                    {
                        body.Add(CenterText(" " + electionContest.Contest.Name + " ", '='));
                    }
                    else
                    {
                        body.Add(CenterText(" " + electionContest.Contest.Name + " - continued", '-'));
                    }
                    body.Add("");
                    body.Add("County           " + candidateNames + " Reporting Units       Votes");

                    foreach (ContestCounty cc in electionContest.Counties)
                    {
                        string strVoteCounts = PadString(cc.County.Name, COUNTY_COLUMN_WIDTH);
                        
                        for (int i = 0; i < responsesThisRow; i++)
                        {
                            int padding = 0;
                            if (((Response)(responses[i])).ToString().Length < VOTE_PERCENTAGE_WIDTH + VOTE_COUNT_WIDTH)
                            {
                                padding = VOTE_COUNT_WIDTH + VOTE_PERCENTAGE_WIDTH - ((Response)(responses[i])).ToString().Length;
                            }
                            int stringLength = 0;
                            if (((Response)(responses[i])).ToString().Length > ALL_RESPONSE_SPACE)
                            {
                                stringLength = ALL_RESPONSE_SPACE - COLUMN_PADDING;
                            }
                            else
                            {
                                stringLength = ((Response)(responses[i])).ToString().Length;
                            }
                            strVoteCounts += GetVoteNumbers(((Response)(responses[i])), cc, stringLength + COLUMN_PADDING + padding);
                        }
                       
                        strVoteCounts += PadString(cc.WardsReporting + "/" + cc.WardCount, (COUNTY_COLUMN_WIDTH + ALL_RESPONSE_SPACE - strVoteCounts.Length + COLUMN_PADDING), false);
                        

                        if (cc.WardCount > 0)
                        {
                            strVoteCounts += PadString("(" + (((double)cc.WardsReporting / (double)cc.WardCount) * 100).ToString("0.0") + "%)", VOTE_PERCENTAGE_WIDTH, false);
                        }
                        else
                        {
                            if (cc.WardsReporting > 0)
                            {
                                strVoteCounts += PadString("(100.0%)", VOTE_PERCENTAGE_WIDTH, false);
                            }
                            else
                            {
                                strVoteCounts += PadString("(0.0%)", 12, false);
                            }
                        }
                        strVoteCounts += PadString(" " + cc.GetTotalVotes(), COLUMN_PADDING + 6, false);
                        body.Add(strVoteCounts);
                    }
                    body.Add("");

                    string strTotals = "Totals           ";
                    int totalVotes = electionContest.GetTotalVotes();

                    for (int i = 0; i < responsesThisRow; i++)
                    {
                        int responseVotes = ((Response)(responses[i])).GetTotalVotes();
                        string responseString = responseVotes.ToString();

                        int padding = 0;
                        if (((Response)(responses[i])).ToString().Length < VOTE_PERCENTAGE_WIDTH + VOTE_COUNT_WIDTH)
                        {
                            padding = VOTE_COUNT_WIDTH + VOTE_PERCENTAGE_WIDTH - ((Response)(responses[i])).ToString().Length;
                        }

                        int stringLength = 0;
                        if (((Response)(responses[i])).ToString().Length > ALL_RESPONSE_SPACE)
                        {
                            stringLength = ALL_RESPONSE_SPACE - COLUMN_PADDING;
                        }
                        else
                        {
                            stringLength = ((Response)(responses[i])).ToString().Length;
                        }

                        if (totalVotes > 0)
                        {
                            strTotals += PadString(PadString(responseString, VOTE_COUNT_WIDTH
                                , false) + PadString(" (" + ((double)responseVotes / (double)totalVotes).ToString("0.0" + "%)"), VOTE_PERCENTAGE_WIDTH, false), stringLength + COLUMN_PADDING + padding);
                        }
                        else
                        {
                            strTotals += PadString(PadString(responseString, VOTE_COUNT_WIDTH, false) + PadString("(" + "0.0%)", VOTE_PERCENTAGE_WIDTH, false), stringLength + COLUMN_PADDING + padding);
                        }                       
                    }

                    strTotals += PadString(electionContest.GetWardsReporting() + "/" + electionContest.GetWardCount(), (COUNTY_COLUMN_WIDTH + ALL_RESPONSE_SPACE - strTotals.Length + COLUMN_PADDING), false);
                    strTotals += PadString("(" + (electionContest.GetWardsReportingPercentage() * 100).ToString("0.0") + "%)", VOTE_PERCENTAGE_WIDTH, false);
                    strTotals += PadString(totalVotes.ToString(), COLUMN_PADDING + 6, false);

                    body.Add(strTotals);

                    body.Add("");
                    body.Add("</KEEP_TOGETHER>");

                    responses.RemoveRange(0, responsesThisRow);
                }
            }

            footer.Add("Page ${Page}     " + DateTime.Now);

            return true;
        }

        private static string GetVoteNumbers(Response response, ContestCounty contestCounty, int columnWidth)
        {
            ResponseValue resultValue = null;
            foreach (ResponseValue responseValue in contestCounty.ResponseValues)
            {
                if (responseValue.Response.ID == response.ID)
                {
                    resultValue = responseValue;
                    break;
                }
            }
            int voteCount = 0;
            double votePercentage = 0.0;
            if (resultValue != null)
            {
                voteCount = resultValue.VoteCount;
                votePercentage = Math.Round(resultValue.GetVotePercentage() * 100, 2);
            }

            return PadString(PadString(voteCount.ToString(), VOTE_COUNT_WIDTH, false) + PadString(" (" + votePercentage + "%)", VOTE_PERCENTAGE_WIDTH, false), columnWidth, true);
        }

        public override Font Font()
        {
            return font;
        }
    }
}