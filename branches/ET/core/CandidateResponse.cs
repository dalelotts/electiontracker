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
using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.core {
    internal class CandidateResponse : Response {
        private Candidate candidate;
        private string toStringResult = "NULL CANDIDATE: UNKNOWN";

        [RequiredProperty("Candidate")]
        public virtual Candidate Candidate {
            get { return candidate; }
            set {
                if (value == null) throw new ArgumentException("Null: candidate");
                candidate = value;
                toStringResult = candidate.ToString();
            }
        }

        public override string ToString() {
            return toStringResult + (IsIncumbent ? " (Inc.)" : "");
        }
    }
}