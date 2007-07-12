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
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class ActiveElectionFilter : BaseTreeViewFilter {
        private readonly ElectionDAO dao;

        private const string name = "Elections - Active";

        public ActiveElectionFilter(ElectionDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            IList<Election> activeElections = dao.findActive();

            foreach (Election election in activeElections) {
                string electionKey = DBEntity.ELECTION + "=" + election.ID;
                TreeNode electionNode = nodes.Add(electionKey, election.ToString());
                electionNode.ToolTipText = election.Notes;

                TreeNode contestsNode =
                    electionNode.Nodes.Add(electionKey + ";" + "contests", "Contests");

                IList<ElectionContest> electionContests = election.ElectionContests;
                foreach (ElectionContest electionContest in electionContests) {
                    string electionContestKey = electionKey + ";" + DBEntity.ELECTION_CONTEST + "=" + electionContest.ID;
                    TreeNode electionContestNode = contestsNode.Nodes.Add(electionContestKey, electionContest.Contest.Name);
                    electionContestNode.ToolTipText = electionContest.Contest.Notes;

                    TreeNode responsesNode = electionContestNode.Nodes.Add(electionContestKey + ";" + "responses", "Responses");

                    IList<Response> responses = electionContest.Responses;
                    foreach (Response response in responses) {
                        string responseKey = electionContestNode + ";" + DBEntity.RESPONSE + "=" + response.ID;
                        responsesNode.Nodes.Add(responseKey, response.ToString());
                    }

                    TreeNode countiesNode = electionContestNode.Nodes.Add(electionContestKey + ";" + "counties", "Counties");

                    IList<ContestCounty> contestCounties = electionContest.Counties;
                    foreach (ContestCounty contestCounty in contestCounties) {
                        string contestCountyKey = electionContestNode + ";" + DBEntity.CONTEST_COUNTY + "=" + contestCounty.ID;
                        TreeNode contestCountyNode = countiesNode.Nodes.Add(contestCountyKey, contestCounty.County.Name + " (" + contestCounty.WardCount + " Wards) ");
                        contestCountyNode.ToolTipText = contestCounty.County.Notes;
                    }                    
                }
            }
        }
    }
}