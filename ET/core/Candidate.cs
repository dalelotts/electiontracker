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

using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.core {
    public class Candidate {
        private long? id;
        private string firstName;
        private string middleName;
        private string lastName;
        private string notes;
        private PoliticalParty politicalParty;
        private bool isActive = true;


        public virtual long ID {
            get { return id.HasValue ? id.Value : 0; }
            set { id = value; }
        }

        [RequiredProperty("Candidate First Name")]
        public virtual string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }

        public virtual string MiddleName {
            get { return middleName; }
            set { middleName = value; }
        }

        [RequiredProperty("Candidate Last Name")]
        public virtual string LastName {
            get { return lastName; }
            set { lastName = value; }
        }

        public virtual string Notes {
            get { return notes; }
            set { notes = value; }
        }

        public virtual PoliticalParty PoliticalParty {
            get { return politicalParty; }
            set { politicalParty = value; }
        }

        public virtual bool IsActive {
            get { return isActive; }
            set { isActive = value; }
        }

        public override string ToString() {
            string name = lastName + ", " + firstName + " " + middleName;
            return name + (politicalParty != null ? " (" + politicalParty.Abbreviation + ")" : "");
        }


        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            if (!GetType().Equals(obj.GetType())) return false;
            Candidate that = (Candidate) obj;
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