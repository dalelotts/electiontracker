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
    internal class CountyFilter : BaseTreeViewFilter {
        private readonly CountyDAO dao;

        private const string name = "Counties";

        public CountyFilter(CountyDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            IList<County> counties = dao.findAll();

            foreach (County county in counties) {
                string nodeText = county.Name;
                TreeNode newNode = nodes.Add(DBEntity.COUNTY + "=" + county.ID, nodeText);
                newNode.ToolTipText = county.Notes;
            }
        }
    }
}