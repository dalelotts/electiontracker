using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ResponseDAO : HibernateDAO<Response> {
        public ResponseDAO(ISessionFactory factory) : base(factory) {}

        public override IList<Fault> validate(Response entity) {
            throw new NotImplementedException();
        }
    }
}