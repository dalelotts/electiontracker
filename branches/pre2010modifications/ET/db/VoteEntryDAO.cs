using System;
using System.Collections.Generic;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db.task;
using Spring.Data.NHibernate.Generic;

namespace KnightRider.ElectionTracker.db {
    public class VoteEntryDAO : IVoteEntryDAO {
        private readonly DelegateDAO<ResponseValue> reponseValueDAO;
        private readonly IElectionDAO electionDAO;

        public VoteEntryDAO(HibernateTemplate factory, IElectionDAO electionDAO) {
            reponseValueDAO = new DelegateDAO<ResponseValue>(factory);
            this.electionDAO = electionDAO;
        }

        public IList<Election> findActiveElections(IDAOTask<Election> task) {
            return electionDAO.findActive(task);
        }

        public IList<County> findCounties(Election election) {
            throw new NotImplementedException();
        }

        public IList<County> findContests(County county) {
            throw new NotImplementedException();
        }

        public ResponseValue findById(object id, bool lockRecord, params IDAOTask<ResponseValue>[] tasks) {
            throw new NotImplementedException();
        }

        public IList<ResponseValue> findAll() {
            throw new NotImplementedException();
        }

        public ResponseValue makePersistent(ResponseValue entity) {
            throw new NotImplementedException();
        }

        public void makeTransient(ResponseValue entity) {
            throw new NotImplementedException();
        }

        public IList<Fault> canMakePersistent(ResponseValue entity) {
            throw new NotImplementedException();
        }

        public IList<Fault> canMakeTransient(ResponseValue entity) {
            throw new NotImplementedException();
        }
    }
}