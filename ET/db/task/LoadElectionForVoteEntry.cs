/**
 *  Copyright (C) 2008 Knight Rider Consulting, Inc.
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
using KnightRider.ElectionTracker.core;

namespace KnightRider.ElectionTracker.db.task {
    public class LoadElectionForVoteEntry : IDAOTask<Election> {
        public void perform(Election entity) {
            for (int i = 0; i < entity.ElectionContests.Count; i++) {
                ElectionContest electionContest = entity.ElectionContests[i];
                int responseCount = electionContest.Responses.Count;
                for (int j = 0; j < electionContest.Counties.Count; j++) {
                    ContestCounty contestCounty = electionContest.Counties[j];
                    County county = contestCounty.County;
                    int responseValueCount = contestCounty.ResponseValues.Count;
                }
            }
        }
    }
}