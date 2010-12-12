using System;
using NUnit.Framework;

namespace DesignByContract {
    [TestFixture()]
    public class TestInvariantException {
        private InvariantException _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new InvariantException();
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorInvariantException() {
            InvariantException testInvariantException = new InvariantException();
            Assert.IsNotNull(testInvariantException,
                             "Constructor of type, InvariantException failed to create instance.");
        }

        [Test()]
        public void TestConstructorInvariantExceptionMessage() {
            string message = null;
            InvariantException testInvariantException = new InvariantException(message);
            Assert.IsNotNull(testInvariantException,
                             "Constructor of type, InvariantException failed to create instance.");
        }

        [Test()]
        public void TestConstructorInvariantExceptionMessageInner() {
            string message = null;
            Exception inner = new Exception("Inner");
            InvariantException testInvariantException = new InvariantException(message, inner);
            Assert.IsNotNull(testInvariantException,
                             "Constructor of type, InvariantException failed to create instance.");
            Assert.AreEqual(inner, testInvariantException.InnerException);
        }
    }
}