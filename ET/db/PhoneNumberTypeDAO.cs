using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class PhoneNumberTypeDAO : HibernateDAO<PhoneNumberType> {

        public PhoneNumberTypeDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(PhoneNumberType entity)
        {
            return makeEmptyFaultList();
        }

    }
}