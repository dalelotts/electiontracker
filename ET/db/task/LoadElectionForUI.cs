using System.Collections.Generic;
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db.task {
    /// <summary>
    /// Causes the ElectionContests to be loaded within the context of a transaction.
    /// </summary>
    public class LoadElectionForUI : IDAOTask<Election> {
        public void perform(Election entity) {
            IList<ElectionContest> contests = entity.ElectionContests;
            for (int i = 0; i < contests.Count; i++) {
                ElectionContest contest = contests[i];
                int countyCount = contest.Counties.Count;
                int responseCount = contest.Responses.Count;
            }
        }
    }
}