using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db.task {
    public class LoadElectionForVoteEntry : IDAOTask<Election> {
        public void perform(Election entity) {
            for (int i = 0; i < entity.ElectionContests.Count; i++) {
                ElectionContest electionContest = entity.ElectionContests[i];
                int responseCount = electionContest.Responses.Count;
                for (int j = 0; j < electionContest.Counties.Count; j++) {
                    ContestCounty contestCounty = electionContest.Counties[j];
                    County county = contestCounty.County;
                    int responseValueCount = contestCounty.ResponseValues.Count;
                }
            }
        }
    }
}