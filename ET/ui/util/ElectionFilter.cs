using System.Collections.Generic;
using System.Windows.Forms;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class ElectionFilter : BaseTreeViewFilter {
        private readonly ElectionDAO dao;

        private const string name = "Elections";
        private readonly bool? isActive;

        public ElectionFilter(ElectionDAO dao) : base(name) {
            this.dao = dao;
            isActive = null;
        }


        public ElectionFilter(ElectionDAO dao, bool isActive) : base(name + " - " + (isActive ? "Active" : "Inactive")) {
            this.dao = dao;
            this.isActive = isActive;
        }

        public override void apply(TreeNodeCollection nodes) {
            IList<Election> activeElections = GetElections();

            foreach (Election election in activeElections) {
                string electionKey = DBEntity.ELECTION + "=" + election.ID;
                TreeNode electionNode = nodes.Add(electionKey, election.ToString());
                electionNode.ToolTipText = election.Notes;

                TreeNode contestsNode = electionNode.Nodes.Add(electionKey + ";" + "contests", "Contests");

                IList<ElectionContest> electionContests = election.ElectionContests;
                foreach (ElectionContest electionContest in electionContests) {
                    string electionContestKey = electionKey + ";" + DBEntity.ELECTION_CONTEST + "=" + electionContest.ID;
                    TreeNode electionContestNode =
                        contestsNode.Nodes.Add(electionContestKey, electionContest.Contest.Name);
                    electionContestNode.ToolTipText = electionContest.Contest.Notes;

                    TreeNode responsesNode =
                        electionContestNode.Nodes.Add(electionContestKey + ";" + "responses", "Responses");

                    IList<Response> responses = electionContest.Responses;
                    foreach (Response response in responses) {
                        string responseKey = electionContestKey + ";" + DBEntity.RESPONSE + "=" + response.ID;
                        responsesNode.Nodes.Add(responseKey, response.ToString());
                    }

                    TreeNode countiesNode =
                        electionContestNode.Nodes.Add(electionContestKey + ";" + "counties", "Counties");

                    IList<ContestCounty> contestCounties = electionContest.Counties;
                    foreach (ContestCounty contestCounty in contestCounties) {
                        string contestCountyKey = electionContestKey + ";" + DBEntity.CONTEST_COUNTY + "=" +
                                                  contestCounty.ID;
                        TreeNode contestCountyNode =
                            countiesNode.Nodes.Add(contestCountyKey,
                                                   contestCounty.County.Name + " (" + contestCounty.WardCount +
                                                   " Wards) ");
                        contestCountyNode.ToolTipText = contestCounty.County.Notes;
                    }
                }
            }
        }

        private IList<Election> GetElections() {
            if (!isActive.HasValue) {
                return dao.findAll();
            } else if (isActive.Value) {
                return dao.findActive();
            } else {
                return dao.findInactive();
            }
        }
    }
}