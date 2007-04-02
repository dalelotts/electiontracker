using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class CountyPhoneNumberDAO : HibernateDAO<CountyPhoneNumber> {
        public CountyPhoneNumberDAO(ISessionFactory factory) : base(factory) {}

        public override IList<Fault> validate(CountyPhoneNumber entity) {
            throw new NotImplementedException();
        }
    }
}