using edu.uwec.cs.cs355.group4.et.core;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestCandidateResponse {
        private CandidateResponse _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new CandidateResponse();
            Candidate candidate = new Candidate();
            candidate.FirstName = "Test";
            candidate.LastName = "Candidate";
            _unitUnderTest.Candidate = candidate;
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestToString() {
            string expectedString = "Test Candidate";
            string resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
        }
    }
}