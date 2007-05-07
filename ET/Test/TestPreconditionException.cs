using System;
using NUnit.Framework;

namespace DesignByContract {
    [TestFixture()]
    public class TestPreconditionException {
        private PreconditionException _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new PreconditionException();
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorPreconditionException() {
            PreconditionException testPreconditionException = new PreconditionException();
            Assert.IsNotNull(testPreconditionException,
                             "Constructor of type, PreconditionException failed to create instance.");
            Assert.Fail("Create or modify test(s).");
        }

        [Test()]
        public void TestConstructorPreconditionExceptionMessage() {
            string message = null;
            PreconditionException testPreconditionException = new PreconditionException(message);
            Assert.IsNotNull(testPreconditionException,
                             "Constructor of type, PreconditionException failed to create instance.");
            Assert.Fail("Create or modify test(s).");
        }

        [Test()]
        public void TestConstructorPreconditionExceptionMessageInner() {
            string message = null;
            Exception inner = null;
            PreconditionException testPreconditionException = new PreconditionException(message, inner);
            Assert.IsNotNull(testPreconditionException,
                             "Constructor of type, PreconditionException failed to create instance.");
            Assert.Fail("Create or modify test(s).");
        }
    }
}