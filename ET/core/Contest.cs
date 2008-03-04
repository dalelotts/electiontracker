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

using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.core {
    public class Contest {
        private long? id;
        private string name;
        private ContestType contestType;
        private string notes;
        private bool isActive = true;


        public virtual long ID {
            get { return id.HasValue ? id.Value : 0; }
            set { id = value; }
        }

        [RequiredProperty("Contest Name")]
        public virtual string Name {
            get { return name; }
            set { name = value; }
        }

        [RequiredProperty("Contest Type")]
        public virtual ContestType ContestType {
            get { return contestType; }
            set { contestType = value; }
        }

        public virtual string Notes {
            get { return notes; }
            set { notes = value; }
        }

        public virtual bool IsActive {
            get { return isActive; }
            set { isActive = value; }
        }

        public override string ToString() {
            return Name;
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            if (!GetType().Equals(obj.GetType())) return false;
            Contest that = (Contest) obj;
            if (id.HasValue && that.id.HasValue) {
                return id.Equals(that.id);
            } else {
                return false;
            }
        }

        public override int GetHashCode() {
            return id.HasValue ? (int) id.Value : base.GetHashCode();
        }
    }
}