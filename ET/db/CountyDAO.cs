/**
 *  Copyright (C) 2007 Knight Rider Consulting, Inc.
 *  support@knightrider.com
 *  http://www.knightrider.com
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  any later version.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see http://www.gnu.org/licenses/
 **/
using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using NHibernate;
using NHibernate.Expression;
using Spring.Data.NHibernate.Generic;

namespace KnightRider.ElectionTracker.db {
    internal class CountyDAO : HibernateDAO<County> {
        private static readonly IList<Order> ORDER_BY_NAME = new List<Order>();

        static CountyDAO() {
            ORDER_BY_NAME.Add(new Order("Name", true));
        }

        public CountyDAO(HibernateTemplate factory) : base(factory) {}

        public override IList<County> findAll() {
            return findByCriteria(new List<ICriterion>(), ORDER_BY_NAME);
        }

        protected override IList<Fault> performCanMakePersistent(County entity) {
            FindHibernateDelegate<County> findDelegate = delegate(ISession session)
                                                             {
                                                                 IQuery query =
                                                                     session.CreateSQLQuery(
                                                                         "select * from county where CountyName = '" +
                                                                         entity.Name + "' and CountyID != " + entity.ID +
                                                                         ";").AddEntity(objectType);
                                                                 return query.List<County>();
                                                             };

            IList<County> duplicates = ExecuteFind(findDelegate);

            IList<Fault> result = new List<Fault>();

            if (duplicates.Count > 0) {
                result.Add(
                    new Fault(true, "Duplicate County Name: a county named '" + entity.Name + "' already exists."));
            }

            return result;
        }

        public override IList<Fault> canMakeTransient(County entity) {
            return new List<Fault>();
        }
    }
}