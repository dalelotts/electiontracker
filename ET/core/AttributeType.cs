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
    public class AttributeType {
        private long id;
        private string name;

        public virtual long ID {
            get { return id; }
            set { id = value; }
        }

        [RequiredProperty("Attribute Type Name")]
        public virtual string Name {
            get { return name; }
            set { name = value; }
        }
    }
}