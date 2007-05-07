using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.core {
    [TestFixture()]
    public class TestCountyWebsite {
        private CountyWebsite _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new CountyWebsite();
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