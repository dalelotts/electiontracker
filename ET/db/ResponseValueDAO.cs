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
    internal class ResponseValueDAO : HibernateDAO<ResponseValue> {
        public ResponseValueDAO(HibernateTemplate factory) : base(factory) {}

        protected override IList<Fault> performCanMakePersistent(ResponseValue entity) {
            IList<Fault> retVal = new List<Fault>();
            return retVal;
        }


        public IList<ResponseValue> find(long responseID, long contestCountyID) {
            FindHibernateDelegate<ResponseValue> findDelegate = delegate(ISession session)
                                                                    {
                                                                        IQuery query =
                                                                            session.CreateSQLQuery(
                                                                                "select * from responsevalue where ResponseID = " +
                                                                                responseID + " and ContestCountyID = " +
                                                                                contestCountyID + ";").AddEntity(
                                                                                objectType);
                                                                        return query.List<ResponseValue>();
                                                                    };

            return ExecuteFind(findDelegate);
        }

        public override IList<Fault> canMakeTransient(ResponseValue entity) {
            return new List<Fault>();
        }
    }
}