using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class ContestTypeDAO : HibernateDAO<ContestType> {
        public ContestTypeDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(ContestType entity) {
            List<Fault> result = new List<Fault>();

            if (entity == null) {
                result.Add(new Fault(true, "ContestType is null."));
            } else {
                if (entity.Name == null) {
                    result.Add(new Fault(true, "ContestType name is null."));
                } else if (entity.Name == "") {
                    result.Add(new Fault(true, "ContestType name is empty."));
                }

                if (result.Count == 0) {
                    ISession currentSession = getCurrentSession();

                    IQuery validQuery =
                        currentSession.CreateSQLQuery("select * from contesttype where name = " + entity.Name + ";");

                    if (validQuery.List().Count > 0) {
                        result.Add(new Fault(true, "ContestType already exists"));
                    }
                }
            }


            return result;
        }
    }
}