using System;
using NUnit.Framework;

namespace DesignByContract {
    [TestFixture()]
    public class TestPostconditionException {
        private PostconditionException _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new PostconditionException();
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorPostconditionException() {
            PostconditionException testPostconditionException = new PostconditionException();
            Assert.IsNotNull(testPostconditionException,
                             "Constructor of type, PostconditionException failed to create instance.");
        }

        [Test()]
        public void TestConstructorPostconditionExceptionMessage() {
            string message = "Message";
            PostconditionException testPostconditionException = new PostconditionException(message);
            Assert.IsNotNull(testPostconditionException,
                             "Constructor of type, PostconditionException failed to create instance.");
        }

        [Test()]
        public void TestConstructorPostconditionExceptionMessageInner() {
            string message = "Message";
            Exception inner = new Exception("inner");
            PostconditionException testPostconditionException = new PostconditionException(message, inner);
            Assert.IsNotNull(testPostconditionException,
                             "Constructor of type, PostconditionException failed to create instance.");
            Assert.AreEqual(inner, testPostconditionException.InnerException);
        }
    }
}