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

namespace KnightRider.ElectionTracker.events {
    public class ShowMessageArgs : EventArgs {
        private readonly string text;
        private readonly string caption;


        public ShowMessageArgs(string text, string caption) {
            this.text = text;
            this.caption = caption;
        }

        public string Text {
            get { return text; }
        }

        public string Caption {
            get { return caption; }
        }
    }
}