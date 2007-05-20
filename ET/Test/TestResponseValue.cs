using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NUnit.Framework;
//using System.Collections.Generic;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestResponseValue
    {
        private ResponseValue _unitUnderTest;
        [SetUp()]
        public void SetUp(){
            _unitUnderTest = new ResponseValue();
            ContestCounty cc = new ContestCounty();
            _unitUnderTest.ContestCounty = cc;
        }

        [TearDown()]
        public void TearDown(){
            _unitUnderTest.ContestCounty = null;
            _unitUnderTest = null;
        }

        [Test()]
        public void TestGetVotePercentage(){
            _unitUnderTest.ContestCounty.ResponseValues = new List<ResponseValue>();
            ResponseValue rv = new ResponseValue();
            rv.VoteCount = 20;
            _unitUnderTest.ContestCounty.ResponseValues.Add(rv);
            _unitUnderTest.VoteCount = 80;
            _unitUnderTest.ContestCounty.ResponseValues.Add(_unitUnderTest);
            double expected = .8;
            double result = _unitUnderTest.GetVotePercentage();
            Assert.AreEqual(expected, result, "GetVotePercentage method failed.");
        }
    }
}
