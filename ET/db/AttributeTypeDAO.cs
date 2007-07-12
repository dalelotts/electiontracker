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

namespace edu.uwec.cs.cs355.group4.et.db {
    internal class AttributeTypeDAO : HibernateDAO<AttributeType> {
        public AttributeTypeDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performCanMakePersistent(AttributeType entity) {
            List<Fault> retVal = new List<Fault>();

            ISession currentSession = getCurrentSession();
            IQuery validQuery =
                currentSession.CreateSQLQuery("select * from attributetype where Name = " + entity.Name + ";");
            if (validQuery.List().Count > 0) {
                retVal.Add(new Fault(true, "Name entered for Attribute Type already exists"));
            }

            return retVal;
        }

        public override IList<Fault> canMakeTransient(AttributeType entity) {
            throw new NotImplementedException();
        }
    }
}