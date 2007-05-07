using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class AttributeTypeDAO : HibernateDAO<AttributeType> {
        public AttributeTypeDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(AttributeType entity) {
            List<Fault> retVal = new List<Fault>();

            ISession currentSession = getCurrentSession();
            IQuery validQuery = currentSession.CreateSQLQuery("select * from attributetype where Name = " + entity.Name + ";");
            if (validQuery.List().Count > 0) {
                retVal.Add(new Fault(true, "Name entered for Attribute Type already exists"));
            }

            return retVal;
        }
    }
}