using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.core {
    [TestFixture()]
    public class TestContest {
        private Contest _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new Contest();
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestToString() {
            string expectedString = null;
            string resultString = null;
            resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
            Assert.Fail("Create or modify test(s).");
        }

        [Test()]
        public void TestEquals() {
            object obj = null;
            bool expectedBoolean = true;
            bool resultBoolean = false;
            resultBoolean = _unitUnderTest.Equals(obj);
            Assert.AreEqual(expectedBoolean, resultBoolean, "Equals method returned unexpected result.");
            Assert.Fail("Create or modify test(s).");
        }
    }
}