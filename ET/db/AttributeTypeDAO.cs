using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class AttributeTypeDAO : HibernateDAO<AttributeType> {
        public AttributeTypeDAO(ISessionFactory factory) : base(factory) {}

        public override IList<Fault> validate(AttributeType entity) {
            return makeEmptyFaultList();
        }
    }
}