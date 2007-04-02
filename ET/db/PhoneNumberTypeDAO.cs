using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using NHibernate.Expression;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class PhoneNumberTypeDAO : HibernateDAO<PhoneNumberType> {

        public PhoneNumberTypeDAO(ISessionFactory factory) : base(factory) {}

        public override IList<Fault> validate(PhoneNumberType entity) {
            return makeEmptyFaultList();
        }

    }
}