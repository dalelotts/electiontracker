using System;
using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db.task;

namespace KnightRider.ElectionTracker.db {
    public interface IElectionDAO : IGenericDAO<Election> {
        IList<Election> findActive();

        IList<Election> findInactive();
    }
}