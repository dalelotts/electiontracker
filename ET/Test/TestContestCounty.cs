using NUnit.Framework;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestContestCounty {
        private ContestCounty _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new ContestCounty();
            County county = new County();
            county.Name = "TestContestCounty";
            _unitUnderTest.County = county;

        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestToString() {
            string expectedString = "TestContestCounty";
            string resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
        }

        [Test()]
        public void TestGetAllVotes(){
            _unitUnderTest.ResponseValues = new List<ResponseValue>();
            ResponseValue r = new ResponseValue();
            r.VoteCount = 7;
            _unitUnderTest.ResponseValues.Add(r);
            r = new ResponseValue();
            r.VoteCount = 5;
            _unitUnderTest.ResponseValues.Add(r);
            int expected = 12;
            int result = _unitUnderTest.GetTotalVotes();
            Assert.AreEqual(expected, result, "GetAllVotes returned unexpected result.");
        }
    }
}