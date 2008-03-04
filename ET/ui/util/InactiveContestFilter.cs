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
using KnightRider.ElectionTracker.type;

namespace KnightRider.ElectionTracker.ui.util {
    internal class InactiveContestFilter : BaseTreeViewFilter {
        private static readonly string name = "Contest - Inactive";

        private readonly ContestDAO dao;

        public InactiveContestFilter(ContestDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            IList<Contest> contests = dao.findInactive();

            foreach (Contest contest in contests) {
                string nodeText = contest.Name;
                TreeNode newNode = nodes.Add(DBEntity.CONTEST + "=" + contest.ID, nodeText);
                newNode.ToolTipText = contest.Notes;
            }
        }
    }
}