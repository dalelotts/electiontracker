using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db.task;

namespace KnightRider.ElectionTracker.db {
    public interface ICountyDAO {
        IList<Fault> canMakePersistent(County entity);
        IList<Fault> canMakePersistent(CountyAttribute entity);
        IList<Fault> canMakePersistent(CountyPhoneNumber entity);
        IList<Fault> canMakePersistent(CountyWebsite entity);
        IList<Fault> canMakeTransient(County entity);
        IList<County> findAll(params IDAOTask<County>[] tasks);
        County findById(object id, bool lockRecord, params IDAOTask<County>[] tasks);
        County makePersistent(County entity);
        void makeTransient(County entity);
    }
}