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
    internal class ContestCountyDAO : IContestCountyDAO {
        private readonly DelegateDAO<ContestCounty> delegateDAO;
        private static readonly Type objectType = typeof (ContestCounty);

        public ContestCountyDAO(HibernateTemplate factory) {
            delegateDAO = new DelegateDAO<ContestCounty>(factory);
        }


        public ContestCounty findById(object id, bool lockRecord, params IDAOTask<ContestCounty>[] tasks) {
            return delegateDAO.findById(id, lockRecord, tasks);
        }

        public IList<ContestCounty> findAll() {
            return delegateDAO.findAll();
        }

        public ContestCounty makePersistent(ContestCounty entity) {
            return delegateDAO.makePersistent(entity);
        }

        public void makeTransient(ContestCounty entity) {
            delegateDAO.makeTransient(entity);
        }

        public IList<Fault> canMakePersistent(ContestCounty entity) {
            return delegateDAO.canMakePersistent(entity);
        }

        public IList<Fault> canMakeTransient(ContestCounty entity) {
            return delegateDAO.canMakeTransient(entity);
        }

        public IList<ContestCounty> find(long countyID, long electionContestID) {
            FindHibernateDelegate<ContestCounty> findDelegate = delegate(ISession session)
                                                                    {
                                                                        IQuery query = session.CreateSQLQuery("select * from contestcounty where CountyID = " + countyID + " and ElectionContestID = " + electionContestID + ";").AddEntity(objectType);
                                                                        return query.List<ContestCounty>();
                                                                    };

            return delegateDAO.ExecuteFind(findDelegate);
        }
    }
}