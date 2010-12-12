using System.Collections.Generic;
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db {
    public interface IDefaultContestCountyDAO : IGenericDAO<DefaultContestCounty> {
        IList<DefaultContestCounty> find(long contestID);
    }
}