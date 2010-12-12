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
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db.task;
using NHibernate;
using Spring.Data.NHibernate.Generic;

namespace KnightRider.ElectionTracker.db {
    internal class DefaultContestCountyDAO : IDefaultContestCountyDAO {
        private readonly DelegateDAO<DefaultContestCounty> delegateDAO;
        private static readonly Type objectType = typeof (DefaultContestCounty);

        public DefaultContestCountyDAO(HibernateTemplate factory) {
            delegateDAO = new DelegateDAO<DefaultContestCounty>(factory);
        }


        public DefaultContestCounty findById(object id, bool lockRecord, params IDAOTask<DefaultContestCounty>[] tasks) {
            return delegateDAO.findById(id, lockRecord, tasks);
        }

        public IList<DefaultContestCounty> findAll() {
            return delegateDAO.findAll();
        }

        public DefaultContestCounty makePersistent(DefaultContestCounty entity) {
            return delegateDAO.makePersistent(entity);
        }

        public void makeTransient(DefaultContestCounty entity) {
            delegateDAO.makeTransient(entity);
        }

        public IList<Fault> canMakePersistent(DefaultContestCounty entity) {
            return delegateDAO.canMakePersistent(entity);
        }

        public IList<Fault> canMakeTransient(DefaultContestCounty entity) {
            return delegateDAO.canMakeTransient(entity);
        }

        public IList<DefaultContestCounty> find(long contestID) {
            FindHibernateDelegate<DefaultContestCounty> findDelegate = delegate(ISession session)
                                                                    {
                                                                        IQuery query = session.CreateSQLQuery("select * from defaultcontestcounty where ContestID = :contestID")
                                                                            .AddEntity(objectType)
                                                                            .SetInt64("contestID", contestID);
                                                                           
                                                                        return query.List<DefaultContestCounty>();
                                                                    };

            return delegateDAO.ExecuteFind(findDelegate);
        }
    }
}