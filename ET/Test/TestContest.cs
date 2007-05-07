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
            string expectedString = "TestContest";
            _unitUnderTest.Name = expectedString;
            string resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
        }

        [Test()]
        public void TestEqualsReflexive() {
            _unitUnderTest.ID = 1;
            bool expectedBoolean = true;
            bool resultBoolean = _unitUnderTest.Equals(_unitUnderTest);
            Assert.AreEqual(expectedBoolean, resultBoolean, "Equals method returned unexpected result.");
        }

        [Test()]
        public void TestEqualsSymmetric()
        {
            _unitUnderTest.ID = 1;
            Contest c2 = new Contest();
            c2.ID = 1;
            bool expectedBoolean = true;
            bool resultBoolean = _unitUnderTest.Equals(c2);
            Assert.AreEqual(expectedBoolean, resultBoolean, "Equals method returned unexpected result.");
        }

        [Test()]
        public void TestEqualsTransitive()
        {
            _unitUnderTest.ID = 1;
            Contest c2 = new Contest();
            c2.ID = 1;
            Contest c3 = new Contest();
            c3.ID = 1;
            bool expectedBoolean = true;
            bool ab = _unitUnderTest.Equals(c2);
            bool bc = c2.Equals(c3);
            bool ac = _unitUnderTest.Equals(c3);
            bool resultBoolean = (ab && bc && ac);
            Assert.AreEqual(expectedBoolean, resultBoolean, "Equals method returned unexpected result.");
        }
    }
}