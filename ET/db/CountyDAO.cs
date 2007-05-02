using System;
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

        public override IList<Fault> validate(County entity) {
            throw new NotImplementedException();
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