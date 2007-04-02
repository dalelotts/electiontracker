using System;

namespace edu.uwec.cs.cs355.group4.et.type {
    public sealed class NoSuchMemberException : ArgumentException {
        public NoSuchMemberException(string target) : base("No such memeber: " + target) {}
    }
}