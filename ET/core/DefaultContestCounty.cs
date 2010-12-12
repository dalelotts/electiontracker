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
using System.Reflection;
using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.core {
    public class DefaultContestCounty {
        private long id;
        private County county;
        private int wardCount;
        private int wardsReporting;
        private Contest contest;

        #region Properties

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }


        [RequiredProperty("Contest County County")]
        public virtual County County {
            get { return county; }
            set { county = value; }
        }


        [RequiredProperty("Contest County Election Contest")]
        public virtual Contest Contest {
            get { return contest; }
            set { contest = value; }
        }

        public virtual int WardCount {
            get { return wardCount; }
            set { wardCount = value; }
        }

        public virtual int WardsReporting {
            get { return wardsReporting; }
            set { wardsReporting = value; }
        }

        #endregion

        public override string ToString() {
            return contest != null ? contest.Name : "NULL COUNTY: UNKNOWN";
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            ContestCounty that = obj as ContestCounty;
            if (that == null) return false;
            if (id == 0 && that.ID == 0) {
                return base.Equals(obj);
            } else {
                return id.Equals(that.ID);
            }
        }

        public override int GetHashCode() {
            if (id == 0) {
                return base.GetHashCode();
            } else {
                string stringRepresentation = MethodBase.GetCurrentMethod().DeclaringType.FullName + "#" + id;
                return stringRepresentation.GetHashCode();
            }
        }
    }
}