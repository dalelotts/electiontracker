using System;
using System.Collections.Generic;
using System.Text;
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db.task
{
    class LoadDefaultContestCountyForUI : IDAOTask<DefaultContestCounty>
    {
        public void perform(DefaultContestCounty entity)
        {
           Contest contest = entity.Contest;
           County county = entity.County;
           int wardsReporting = entity.WardsReporting;
           int wardCount = entity.WardCount;
        }
    }
}
