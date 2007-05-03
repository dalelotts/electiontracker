using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ContestTypeDAO : HibernateDAO<ContestType> {
        public ContestTypeDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(ContestType entity)
        {
            return makeEmptyFaultList();
        }
    }
}