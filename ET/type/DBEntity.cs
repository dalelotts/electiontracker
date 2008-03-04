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
using System.Collections.Generic;
using DesignByContract;

namespace KnightRider.ElectionTracker.type {
    internal sealed class DBEntity {
        private readonly string name;
        private readonly string label;

        public static readonly DBEntity CANDIDATE = new DBEntity("candidate", "Candidate");
        public static readonly DBEntity CONTEST = new DBEntity("contest", "Contest");
        public static readonly DBEntity CONTEST_COUNTY = new DBEntity("contest_county", "Contest County");
        public static readonly DBEntity COUNTY = new DBEntity("county", "County");
        public static readonly DBEntity ELECTION = new DBEntity("election", "Election");
        public static readonly DBEntity ELECTION_CONTEST = new DBEntity("election_contest", "Election Contest");
        public static readonly DBEntity POLITICAL_PARTY = new DBEntity("political_party", "Political Party");
        public static readonly DBEntity RESPONSE = new DBEntity("response", "Response");

        private static readonly IList<DBEntity> members = new List<DBEntity>();

        static DBEntity() {
            members.Add(ELECTION);
            members.Add(CANDIDATE);
            members.Add(POLITICAL_PARTY);
        }

        private DBEntity(string name, string label) {
            this.name = name;
            this.label = label;
        }

        public override string ToString() {
            return name;
        }

        public string Label {
            get { return label; }
        }

        public static DBEntity selectorFromName(string target) {
            Check.Require(members != null && members.Count > 0, "Empty:members");
            Check.Require(target != null && target.Length > 0, "Empty:target");
            foreach (DBEntity member in members) {
                if (member.name.Equals(target, StringComparison.OrdinalIgnoreCase)) return member;
            }
            throw new NoSuchMemberException(target);
        }

        public static IList<DBEntity> getMembers() {
            return new List<DBEntity>(members);
        }
    }
}