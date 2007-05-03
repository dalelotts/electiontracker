using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class AttributeTypeDAO : HibernateDAO<AttributeType> {
        public AttributeTypeDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(AttributeType entity) {
            List<Fault> result = new List<Fault>();

            string name = entity.Name;

            if (name == null) {
                result.Add(new Fault(true, "AttributeType name is null."));
            } else if (name == "") {
                result.Add(new Fault(true, "AttributeType name is empty."));
            } else {
                ISession currentSession = getCurrentSession();
                IQuery validQuery =
                    getCurrentSession().CreateSQLQuery("select * from attributetype where Name = " + name + ";");
                if (validQuery.List().Count > 0) {
                    result.Add(new Fault(true, "Name entered for Attribute Type already exists"));
                }
            }

            return result;
        }
    }
}