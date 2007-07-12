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
namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class ListItemWrapper<T> {
        private readonly string displayText;
        private readonly T value;


        public ListItemWrapper(string displayText, T value) {
            this.displayText = displayText;
            this.value = value;
        }

        public override string ToString() {
            return displayText;
        }

        public T Value {
            get { return value; }
        }
    }
}