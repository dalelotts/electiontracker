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
using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using NHibernate.Expression;

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class CountyDAO : HibernateDAO<County> {
        private static readonly IList<Order> ORDER_BY_NAME = new List<Order>();

        static CountyDAO() {
            ORDER_BY_NAME.Add(new Order("Name", true));
        }

        public CountyDAO(ISessionFactory factory) : base(factory) {}

        public override IList<County> findAll() {
            return findByCriteria(new List<ICriterion>(), ORDER_BY_NAME);
        }

        protected override IList<Fault> performCanMakePersistent(County entity) {
            IList<Fault> retVal = new List<Fault>();

            ISession currentSession = getCurrentSession();
            IQuery validQuery =
                currentSession.CreateSQLQuery("select * from county where CountyName = '" + entity.Name +
                                              "' and CountyID != " + entity.ID + ";").AddEntity(objectType);
            if (validQuery.List().Count > 0) {
                retVal.Add(new Fault(true, "Name entered for County already exists"));
            }


            return retVal;
        }

        public override IList<Fault> canMakeTransient(County entity) {
            return new List<Fault>();
        }
    }
}