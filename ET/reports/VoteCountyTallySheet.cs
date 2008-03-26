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
    internal class VoteCountyTallySheet : BaseReport<Election> {
        public VoteCountyTallySheet(IList<TreeViewFilter> filters) : base("Vote County Tally Sheet", false, filters) { }

        private static readonly IComparer<ContestCounty> BY_CONTEST_NAME = new ContestCountyComparer(true);
        private static readonly IComparer<County> COUNTY_BY_NAME = new CountyComparer();

        protected override bool performGenerate(Election entity) {
            Map<long, County> countyIDToCounty = new Map<long, County>();
            Map<long, IList<ContestCounty>> countyIDContestCounty = new Map<long, IList<ContestCounty>>();

            // Establish what counties to print for.
            IList<ElectionContest> electionContests = entity.ElectionContests;
            foreach (ElectionContest contest in electionContests) {
                IList<ContestCounty> contestCounties = contest.Counties;
                foreach (ContestCounty contestCounty in contestCounties) {
                    countyIDToCounty.Put(contestCounty.County.ID, contestCounty.County);
                    Map<long, IList<ContestCounty>>.addValueToList(countyIDContestCounty, contestCounty.County.ID, contestCounty);
                }
            }

            header.Add(CenterText("VOTE COUNTY TALLY SHEET"));
            header.Add(CenterText(" ELECTION DATE " + entity.Date.ToShortDateString()));
            header.Add("");

            List<County> counties = new List<County>(countyIDToCounty.Values);

            counties.Sort(COUNTY_BY_NAME);

            foreach (County county in counties) {
                body.Add("<GROUP>");
                body.Add("<GROUP_HEADER>");

                body.Add(CenterText(county.Name));
                foreach (CountyPhoneNumber phoneNumber in county.PhoneNumbers) {
                    body.Add(AlignRight(phoneNumber.Type.Name + ": " + phoneNumber.AreaCode + "-" + phoneNumber.PhoneNumber));
                }
                foreach (CountyWebsite website in county.Websites) {
                    body.Add(AlignRight("Website: " + website.URL));
                }
                foreach (CountyAttribute attribute in county.Attributes) {
                    body.Add(AlignRight(attribute.Type.Name + ": " + attribute.Value));
                }
                body.Add("");
                body.Add("");
                body.Add(AlignRight("Time Called: _________________"));
                body.Add("");
                body.Add("</GROUP_HEADER>");

                List<ContestCounty> contestCounties = new List<ContestCounty>(countyIDContestCounty.Get(county.ID));

                contestCounties.Sort(BY_CONTEST_NAME);

                foreach (ContestCounty contestCounty in contestCounties) {
                    body.Add("<KEEP_TOGETHER>");
                    ElectionContest electionContest = contestCounty.ElectionContest;
                    body.Add(CenterText(" " + electionContest.Contest.Name + " ", '='));
                    body.Add("");
                    foreach (Response response in electionContest.Responses) {
                        string responseColumn = PadString(response.ToString(), 51, true);
                        body.Add(responseColumn + "_________________________");
                        body.Add("");
                        body.Add("");
                    }
                    body.Add(AlignRight("Wards Reporting: ______________" + PadString(" of " + contestCounty.WardCount, 10, '_', false)));
                    body.Add("</KEEP_TOGETHER>");
                }
                body.Add("</GROUP>");
                body.Add("<PAGE_BREAK/>");
            }

            footer.Add(DateTime.Now.ToString());

            return true;
        }
    }
}