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

using System.Reflection;
using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.core {
    public class Candidate {
        private long id;
        private string firstName;
        private string middleName;
        private string lastName;
        private string notes;
        private PoliticalParty politicalParty;
        private bool isActive = true;


        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Candidate First Name", minLength = 1, maxLength = 100)]
        public virtual string FirstName {
            get { return firstName; }
            set {
                firstName = value == null || value.Length == 0 ? null : value;
                ;
            }
        }

        public virtual string MiddleName {
            get { return middleName; }
            set {
                middleName = value == null || value.Length == 0 ? null : value;
                ;
            }
        }

        [RequiredProperty("Candidate Last Name", minLength = 1, maxLength = 100)]
        public virtual string LastName {
            get { return lastName; }
            set {
                lastName = value == null || value.Length == 0 ? null : value;
                ;
            }
        }

        public virtual string Notes {
            get { return notes; }
            set {
                notes = value == null || value.Length == 0 ? null : value;
                ;
            }
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
            string name = (lastName + ", " + firstName + " " + middleName).Trim();
            return name + (politicalParty != null ? " - " + politicalParty.Abbreviation : "");
        }


        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            Candidate that = obj as Candidate;
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