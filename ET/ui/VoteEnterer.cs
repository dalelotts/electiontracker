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
using System.Collections.Generic;
using System.Windows.Forms;
using KnightRider.ElectionTracker.core;
using KnightRider.ElectionTracker.db;

namespace KnightRider.ElectionTracker.ui {
    internal sealed class VoteEnterer : Panel {
        private static readonly IList<string> excluded = new List<string>();

        private readonly IList<ContestDisplay> displays = new List<ContestDisplay>();

        static VoteEnterer() {
            excluded.Add("ID");
            excluded.Add("WardCount");
            excluded.Add("WardsReporting");
        }

        public VoteEnterer(IList<ContestCounty> contestCounties, IContestCountyDAO contestCountyDAO)
        {
            InitializeComponent();
            int currentTop = 0;
            foreach (ContestCounty contestCounty in contestCounties) {
                ContestDisplay display = new ContestDisplay(contestCounty, contestCountyDAO);
                display.Top = currentTop;
                currentTop += display.Height + 1;
                Controls.Add(display);
                displays.Add(display);
            }
            AutoScroll = true;
            BorderStyle = BorderStyle.Fixed3D;
        }

        public void Persist() {
            foreach (ContestDisplay display in displays) {
                display.Persist();
            }
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // VoteEnterer
            // 
            this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ResumeLayout(false);

        }
    }
}