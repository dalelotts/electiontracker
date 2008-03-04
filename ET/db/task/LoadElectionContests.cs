using System.Collections.Generic;
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db.task
{
    /// <summary>
    /// Causes the ElectionContests to be loaded within the context of a transaction.
    /// </summary>
    class LoadElectionContests : IDAOTask<Election> {
        public void perform(Election entity) {
            IList<ElectionContest> ignored = entity.ElectionContests;
            int i = ignored.Count;
        }
    }
}
