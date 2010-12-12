using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db.task;

namespace KnightRider.ElectionTracker.db {
    internal interface IVoteEntryDAO : IGenericDAO<ResponseValue> {
        IList<Election> findActiveElections(IDAOTask<Election> task);
        IList<County> findCounties(Election election);
        IList<County> findContests(County county);
    }
}