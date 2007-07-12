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
    internal sealed class InactiveCandidateFilter : BaseTreeViewFilter {
        private readonly CandidateDAO dao;

        private const string name = "Candidates - Inactive";

        public InactiveCandidateFilter(CandidateDAO dao) : base(name) {
            this.dao = dao;
        }

        public override void apply(TreeNodeCollection nodes) {
            IList<Candidate> candidates = dao.findInactive();

            foreach (Candidate candidate in candidates) {
                TreeNode newNode =
                    nodes.Add(DBEntity.CANDIDATE + "=" + candidate.ID,
                              candidate.LastName + ", " + candidate.FirstName + " " + candidate.MiddleName);
                newNode.ToolTipText = candidate.Notes;
            }
        }
    }
}