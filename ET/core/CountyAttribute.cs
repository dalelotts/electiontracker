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
    public class CountyAttribute {
        private long id;
        private AttributeType type;
        private string value;
        private County county;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("County Attribute Type")]
        public virtual AttributeType Type {
            get { return type; }
            set { type = value; }
        }

        [RequiredProperty("County Attribute County")]
        public virtual County County {
            get { return county; }
            set { county = value; }
        }

        [RequiredProperty("County Attribute Value", minLength = 1, maxLength = 100)]
        public virtual string Value {
            get { return value; }
            set { this.value = value == null || value.Length == 0 ? null : value; }
        }

        public override string ToString() {
            return (type.Name + ": " + value);
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            CountyAttribute that = obj as CountyAttribute;
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