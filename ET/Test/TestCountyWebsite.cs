using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.core {
    [TestFixture()]
    public class TestCountyWebsite {
        private CountyWebsite _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new CountyWebsite();
            County county = new County();
            county.Name = "TestCountyWebsite:County";
            _unitUnderTest.County = county;
            _unitUnderTest.URL = "http://www.knightrider.com";
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestToString() {
            string expectedString = "http://www.knightrider.com";
            string resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
        }
    }
}