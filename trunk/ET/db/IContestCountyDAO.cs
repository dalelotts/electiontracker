using System.Collections.Generic;
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db {
    public interface IContestCountyDAO : IGenericDAO<ContestCounty> {
        IList<ContestCounty> find(long countyID, long electionContestID);
    }
}