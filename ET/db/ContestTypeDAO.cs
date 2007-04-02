using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ContestTypeDAO : HibernateDAO<ContestType> {
        public ContestTypeDAO(ISessionFactory factory) : base(factory) {}

        public override IList<Fault> validate(ContestType entity) {
            return makeEmptyFaultList();
        }
    }
}