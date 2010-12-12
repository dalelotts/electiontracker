using System;
using NUnit.Framework;

namespace DesignByContract {
    [TestFixture()]
    public class TestAssertionException {
        [Test()]
        public void TestConstructorAssertionException() {
            AssertionException testAssertionException = new AssertionException();
            Assert.IsNotNull(testAssertionException,
                             "Constructor of type, AssertionException failed to create instance.");
        }

        [Test()]
        public void TestConstructorAssertionExceptionMessage() {
            string message = null;
            AssertionException testAssertionException = new AssertionException(message);
            Assert.IsNotNull(testAssertionException,
                             "Constructor of type, AssertionException failed to create instance.");
        }

        [Test()]
        public void TestConstructorAssertionExceptionMessageInner() {
            string message = "message";
            Exception inner = new Exception("inner");
            AssertionException testAssertionException = new AssertionException(message, inner);
            Assert.IsNotNull(testAssertionException,
                             "Constructor of type, AssertionException failed to create instance.");
            Assert.AreEqual(inner, testAssertionException.InnerException);
        }
    }
}