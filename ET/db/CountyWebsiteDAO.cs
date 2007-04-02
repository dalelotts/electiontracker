using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using NHibernate.Expression;

namespace edu.uwec.cs.cs355.group4.et.db
{
    class CountyWebsiteDAO : HibernateDAO<CountyWebsite>
    {

        private static readonly IList<Order> ORDER_BY_NAME = new List<Order>();

        static CountyWebsiteDAO()
        {
            ORDER_BY_NAME.Add(new Order("Name", true));
        }

        public override IList<CountyWebsite> findAll()
        {
            return findByCriteria(new List<ICriterion>(), ORDER_BY_NAME);
        }

        public CountyWebsiteDAO(ISessionFactory factory) : base(factory)
        {
        }

        public override IList<Fault> validate(CountyWebsite entity)
        {
            throw new NotImplementedException();
        }
    }
}
