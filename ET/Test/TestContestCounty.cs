using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.core {
    [TestFixture()]
    public class TestContestCounty {
        private ContestCounty _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new ContestCounty();
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
    }
}