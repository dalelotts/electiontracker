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
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.type;

namespace edu.uwec.cs.cs355.group4.et.ui.util {
    internal class ElectionFilter : BaseTreeViewFilter {
        private readonly ElectionDAO dao;

        private const string name = "Elections";
        private readonly bool? isActive;

        public ElectionFilter(ElectionDAO dao) : base(name) {
            this.dao = dao;
            isActive = null;
        }


        public ElectionFilter(ElectionDAO dao, bool isActive) : base(name + " - " + (isActive ? "Active" : "Inactive")) {
            this.dao = dao;
            this.isActive = isActive;
        }

        public override void apply(TreeNodeCollection nodes) {
            IList<Election> activeElections = GetElections();

            foreach (Election election in activeElections) {
                string electionKey = DBEntity.ELECTION + "=" + election.ID;
                TreeNode electionNode = nodes.Add(electionKey, election.ToString());
                electionNode.ToolTipText = election.Notes;
            }
        }

        private IList<Election> GetElections() {
            if (!isActive.HasValue) {
                return dao.findAll();
            } else if (isActive.Value) {
                return dao.findActive();
            } else {
                return dao.findInactive();
            }
        }
    }
}