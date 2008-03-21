using System;

namespace KnightRider.ElectionTracker.util {
    internal class ValidationFailedException : Exception {
        public ValidationFailedException(string message) : base(message) {}
    }
}