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
        IList<Fault> canMakePersistent(AttributeType entity);
        IList<Fault> canMakePersistent(PhoneNumberType entity);
        IList<County> findAll(params IDAOTask<County>[] tasks);
        IList<AttributeType> findAllAttributeTypes(params IDAOTask<AttributeType>[] tasks);
        IList<PhoneNumberType> findAllPhoneNumberTypes(params IDAOTask<PhoneNumberType>[] tasks);
        County findById(object id, bool lockRecord, params IDAOTask<County>[] tasks);
        County makePersistent(County entity);
        AttributeType makePersistent(AttributeType entity);
        PhoneNumberType makePersistent(PhoneNumberType entity);
        void makeTransient(County entity);
    }
}