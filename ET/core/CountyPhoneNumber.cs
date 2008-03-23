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
    public class CountyPhoneNumber {
        private long id;
        private PhoneNumberType type;
        private string areaCode;
        private string phoneNumber;
        private string extension;
        private County county;


        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Phone Number Type")]
        public virtual PhoneNumberType Type {
            get { return type; }
            set { type = value; }
        }

        [RequiredProperty("Area Code", minLength = 3, maxLength = 3, example = "715")]
        public virtual string AreaCode {
            get { return areaCode; }
            set { areaCode = value; }
        }

        [RequiredProperty("Phone Number", minLength = 8, maxLength = 8, example = "123-4567")]
        public virtual string PhoneNumber {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public virtual string Extension {
            get { return extension; }
            set { extension = value; }
        }

        [RequiredProperty("Phone Number County")]
        public virtual County County {
            get { return county; }
            set { county = value; }
        }

        public override string ToString() {
            return (type.Name + ": (" + areaCode + ") " + phoneNumber);
        }

        public override bool Equals(object obj) {
            if (obj == null) return false;
            if (this == obj) return true;
            CountyPhoneNumber that = obj as CountyPhoneNumber;
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