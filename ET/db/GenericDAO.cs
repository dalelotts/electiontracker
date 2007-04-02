using System;
using System.Collections.Generic;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal interface GenericDAO<T> {
        T findById(Object id, bool lockRecord);

        IList<T> findAll();

        IList<T> findByExample(T exampleInstance, IList<String> excludedProperties);

        T makePersistent(T entity);

        void makeTransient(T entity);

        IList<Fault> validate(T entity);
    }
}