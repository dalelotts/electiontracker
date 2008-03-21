using System.Collections.Generic;
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db.task {
    /// <summary>
    /// Causes the ElectionContests to be loaded within the context of a transaction.
    /// </summary>
    public class LoadElectionForReportWithResults : IDAOTask<Election> {
        public void perform(Election entity) {
            IList<ElectionContest> contests = entity.ElectionContests;
            for (int i = 0; i < contests.Count; i++) {
                ElectionContest contest = contests[i];
                for (int j = 0; j < contest.Counties.Count; j++) {
                    ContestCounty contestCounty = contest.Counties[j];
                    int phoneCount = contestCounty.County.PhoneNumbers.Count;
                    int webCount = contestCounty.County.Websites.Count;
                    int attributeCount = contestCounty.County.Attributes.Count;
                    int responseValueCount = contestCounty.ResponseValues.Count;
                }
                int responseCount = contest.Responses.Count;
            }
        }
    }
}