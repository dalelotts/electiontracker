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
    internal class AttributeTypeDAO : HibernateDAO<AttributeType> {
        public AttributeTypeDAO(HibernateTemplate factory) : base(factory) {}

        protected override IList<Fault> performCanMakePersistent(AttributeType entity) {
            FindHibernateDelegate<AttributeType> findDelegate = delegate(ISession session)
                                                                    {
                                                                        IQuery query =
                                                                            session.CreateSQLQuery(
                                                                                "select * from attributetype where Name = " +
                                                                                entity.Name + ";").AddEntity(objectType);
                                                                        return query.List<AttributeType>();
                                                                    };

            IList<AttributeType> duplicates = ExecuteFind(findDelegate);

            IList<Fault> result = new List<Fault>();

            if (duplicates.Count > 0) {
                result.Add(
                    new Fault(true,
                              "Duplicate Attribute Type: an attribute type named '" + entity.Name + "' already exists."));
            }
            return result;
        }

        public override IList<Fault> canMakeTransient(AttributeType entity) {
            return new List<Fault>();
        }
    }
}