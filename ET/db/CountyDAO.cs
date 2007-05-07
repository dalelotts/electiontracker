using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using NHibernate.Expression;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class CountyDAO : HibernateDAO<County> {
        
        private static readonly IList<Order> ORDER_BY_NAME = new List<Order>();

        static CountyDAO()
        {
            ORDER_BY_NAME.Add(new Order("Name", true));
        }

        public CountyDAO(ISessionFactory factory) : base(factory) {}

        public override IList<County> findAll() {
            return findByCriteria(new List<ICriterion>(), ORDER_BY_NAME);
        }

        protected override IList<Fault> performValidation(County entity)
        {
            IList<Fault> retVal = new List<Fault>();

            ISession currentSession = getCurrentSession();
            IQuery validQuery = currentSession.CreateSQLQuery("select * from county where CountyName = '" + entity.Name + "' and CountyID != " + entity.ID + ";").AddEntity(objectType);
            if (validQuery.List().Count > 0)
            {
                retVal.Add(new Fault(true, "Name entered for County already exists"));
            }


            return retVal;
        }
    }
}