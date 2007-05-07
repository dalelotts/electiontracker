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

            /*IQuery iqQuery = getCurrentSession().CreateSQLQuery("select * from county;").AddEntity(typeof(County));
            return iqQuery.List<County>();
            //sdegen hack v44 - Wasn't working.
            //*/return findByCriteria(new List<ICriterion>(), ORDER_BY_NAME);
        }

        protected override IList<Fault> performValidation(County entity)
        {
            IList<Fault> retVal = new List<Fault>();

            return retVal;
        }

        public IList<Contest> findContests(Election e, County cty)
        {
            // TODO: Implement fully.
            IList<Contest> lstContests = new List<Contest>();
            // TEST CODE BEGIN
            List<Contest> lst = new List<Contest>();
            Contest c = new Contest();
            c.Name = cty.Name + " Alderman";
            lstContests.Add(c);
            c = new Contest();
            c.Name = "Second Contest";
            lstContests.Add(c);
            c = new Contest();
            c.Name = "Third Contest";
            lstContests.Add(c);
            c = new Contest();
            c.Name = "Fourth Contest";
            lstContests.Add(c);
            c = new Contest();
            c.Name = "Fifth Contest";
            lstContests.Add(c);
            c = new Contest();
            c.Name = "Sixth Contest";
            lstContests.Add(c);
            // TEST CODE END
            return lstContests;
        }


    }
}