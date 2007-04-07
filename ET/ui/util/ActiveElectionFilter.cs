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
                string nodeText = election.Date.ToString("dddd, MMMM dd yyyy");
                string electionKey = DBEntity.ELECTION + "=" + election.ID;
                TreeNode electionNode = nodes.Add(electionKey, nodeText);
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
                        TreeNode contestCountyNode = countiesNode.Nodes.Add(contestCountyKey, contestCounty.County.Name);
                        contestCountyNode.ToolTipText = "(" + contestCounty.WardCount + " Wards) " + contestCounty.County.Notes;
                    }                    
                }
            }
        }
    }
}