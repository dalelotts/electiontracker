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
    internal class ResponseValueDAO : HibernateDAO<ResponseValue> {
        public ResponseValueDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performCanMakePersistent(ResponseValue entity) {
            IList<Fault> retVal = new List<Fault>();
            return retVal;
        }


        public IList<ResponseValue> find(long responseID, long contestCountyID) {
            IQuery query =
                getCurrentSession().CreateSQLQuery("select * from responsevalue where ResponseID = " + responseID +
                                                   " and ContestCountyID = " + contestCountyID + ";").AddEntity(
                    objectType);
            return query.List<ResponseValue>();
        }

        public override IList<Fault> canMakeTransient(ResponseValue entity) {
            throw new NotImplementedException();
        }
    }
}