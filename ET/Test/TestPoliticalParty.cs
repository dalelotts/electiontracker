using edu.uwec.cs.cs355.group4.et.core;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestPoliticalParty {
        private PoliticalParty _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new PoliticalParty();
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestToString() {
            string name = "TestName";
            string abbrev = "TN";
            string expectedString = "TestName (TN)";
            _unitUnderTest.Name = name;
            _unitUnderTest.Abbreviation = abbrev;
            string resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
        }
    }
}