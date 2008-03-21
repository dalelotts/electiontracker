using System.Collections.Generic;
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db {
    public interface ICandidateDAO : IGenericDAO<Candidate> {
        IList<Candidate> findActive();
        IList<Candidate> findInactive();
    }
}