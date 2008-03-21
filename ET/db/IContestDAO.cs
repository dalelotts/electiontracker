using System.Collections.Generic;
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db {
    public interface IContestDAO : IGenericDAO<Contest> {
        IList<Contest> findActive();
        IList<Contest> findInactive();
    }
}