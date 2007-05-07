using NUnit.Framework;
using edu.uwec.cs.cs355.group4.et.core;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestCandidate {
        private Candidate _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new Candidate();
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestToStringWithNoPoliticalParty() {
            _unitUnderTest = new Candidate();
            _unitUnderTest.FirstName = "First";
            _unitUnderTest.MiddleName = "Middle";
            _unitUnderTest.LastName = "Last";
            string expectedString = "Last, First Middle";
            string resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
        }

        [Test()]
        public void TestToStringWithPoliticalParty() {
            _unitUnderTest.FirstName = "First";
            _unitUnderTest.MiddleName = "Middle";
            _unitUnderTest.LastName = "Last";
            PoliticalParty party = new PoliticalParty();
            party.Name = "Political Party Name";
            party.Abbreviation = "Abbreviation";
            _unitUnderTest.PoliticalParty = party;
            string expectedString = "Last, First Middle (Abbreviation)";
            string resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
        }


        [Test()]
        public void TestEqualsNull() {
            bool resultBoolean = _unitUnderTest.Equals(null);
            Assert.IsFalse(resultBoolean, "Equals method returned unexpected result.");
        }
    }
}