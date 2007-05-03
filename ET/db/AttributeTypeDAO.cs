using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class AttributeTypeDAO : HibernateDAO<AttributeType> {
        public AttributeTypeDAO(ISessionFactory factory) : base(factory) {}

        public override IList<Fault> validate(AttributeType entity) {
            List<Fault> result = new List<Fault>();
            long ID;
            string name;

            if (entity == null) 
            {
                result.Add(new Fault(true, "AttributeType passed is null."));
            } else {
                ID = entity.ID;
                name = entity.Name;

                if (name == null)
                {
                    result.Add(new Fault(true, "AttributeType name is null."));
                }
                else if (name == "")
                {
                    result.Add(new Fault(true, "AttributeType name is empty."));
                }
                else
                {
                    ISession currentSession = getCurrentSession();
                    IQuery validQuery = getCurrentSession().CreateSQLQuery("select * from attributetype where Name = " + name +
                                                   ";");
                    if (validQuery.List().Count > 0)
                    {
                        result.Add(new Fault(true, "Name entered for Attribute Type already exists"));
                    }
                }

            }

            

            

            return result;
        }
    }
}