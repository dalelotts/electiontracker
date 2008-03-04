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
using Spring.Data.NHibernate.Generic;

namespace KnightRider.ElectionTracker.db {
    internal class ContestTypeDAO : HibernateDAO<ContestType> {
        public ContestTypeDAO(HibernateTemplate factory) : base(factory) {}

        protected override IList<Fault> performCanMakePersistent(ContestType entity) {
            FindHibernateDelegate<ContestType> findDelegate = delegate(ISession session)
                                                                  {
                                                                      IQuery query =
                                                                          session.CreateSQLQuery(
                                                                              "select * from contesttype where contesttypename = " +
                                                                              entity.Name + " and ContestTypeID != " +
                                                                              entity.ID + ";").AddEntity(objectType);
                                                                      return query.List<ContestType>();
                                                                  };

            IList<ContestType> duplicates = ExecuteFind(findDelegate);

            IList<Fault> result = new List<Fault>();

            if (duplicates.Count > 0) {
                result.Add(
                    new Fault(true, "Duplicate Content Type: a contest type named '" + entity.Name + "' already exists."));
            }
            return result;
        }

        public override IList<Fault> canMakeTransient(ContestType entity) {
            return new List<Fault>();
        }
    }
}