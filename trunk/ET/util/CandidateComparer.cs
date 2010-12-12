using System.Collections.Generic;
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.util
{
   internal class CandidateComparer : Comparer<Candidate>
        {
            public override int Compare(Candidate x, Candidate y)
            {
                return x.LastName.CompareTo(y.LastName);
            }
        }
}
    
