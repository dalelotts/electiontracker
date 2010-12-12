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
using System.Windows.Forms;

namespace KnightRider.ElectionTracker.events {
    internal abstract class DBEntityArgs<T> : EventArgs where T : Form {
        private static readonly Type objectType = typeof (T);
        private static readonly string objectName = objectType.ToString();

        private readonly long? id;

        public DBEntityArgs() {
            id = null;
        }

        public DBEntityArgs(long id) {
            this.id = id;
        }


        public long? ID {
            get { return id; }
        }

        public Type ObjectType {
            get { return objectType; }
        }

        public virtual string ObjectName {
            get { return objectName; }
        }
    }
}