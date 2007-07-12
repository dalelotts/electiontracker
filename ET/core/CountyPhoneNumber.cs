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

        [RequiredProperty("County Phone Number Type")]
        public virtual PhoneNumberType Type {
            get { return type; }
            set { type = value; }
        }

        [RequiredProperty("County Phone Number Area Code")]
        public virtual string AreaCode {
            get { return areaCode; }
            set { areaCode = value; }
        }

        [RequiredProperty("County Phone Number")]
        public virtual string PhoneNumber {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public virtual string Extension {
            get { return extension; }
            set { extension = value; }
        }

        [RequiredProperty("County Phone Number County")]
        public virtual County County {
            get { return county; }
            set { county = value; }
        }

        public override string ToString() {
            return (type.Name + ": (" + areaCode + ") " + phoneNumber);
        }
    }
}