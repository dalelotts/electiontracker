using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ResponseDAO : HibernateDAO<Response> {
        public ResponseDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(Response entity) {
            IList<Fault> retVal = new List<Fault>();

            return retVal;
        }
    }
}