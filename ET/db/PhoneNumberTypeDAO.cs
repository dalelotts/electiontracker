using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class PhoneNumberTypeDAO : HibernateDAO<PhoneNumberType> {
        public PhoneNumberTypeDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(PhoneNumberType entity) {
            IList<Fault> retVal = new List<Fault>();


            ISession currentSession = getCurrentSession();
            IQuery validQuery = currentSession.CreateSQLQuery("select * from phonenumbertype where Name = " + entity.Name + ";");
            if (validQuery.List().Count > 0)
            {
                retVal.Add(new Fault(true, "Name entered for Phone Number Type already exists"));
            }

            return retVal;
        }
    }
}