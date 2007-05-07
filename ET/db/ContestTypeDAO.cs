using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ContestTypeDAO : HibernateDAO<ContestType> {
        public ContestTypeDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(ContestType entity) {
            List<Fault> result = new List<Fault>();

            ISession currentSession = getCurrentSession();
            IQuery validQuery = currentSession.CreateSQLQuery("select * from contesttype where contesttypename = " + entity.Name + " and ContestTypeID != " + entity.ID + ";");

            if (validQuery.List().Count > 0)
            {
                result.Add(new Fault(true, "ContestType already exists"));
            }

            return result;
        }
    }
}