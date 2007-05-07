using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using edu.uwec.cs.cs355.group4.et.core;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestElectionContest
    {
        ElectionContest _unitUnderTest;
        [SetUp()]
        public void SetUp(){
            _unitUnderTest = new ElectionContest();
            Contest c = new Contest();
            c.Name = "TEST CONTEST";
            _unitUnderTest.Contest = c;
        }

        [TearDown()]
        public void TearDown()
        {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestToString()
        {
            string expectedString = "TEST CONTEST";
            string resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
        }

        [Test()]
        public void TestGetTotalVotes()
        {
            _unitUnderTest.Counties = new List<ContestCounty>();
            ContestCounty cc = new ContestCounty();
            cc.ResponseValues = new List<ResponseValue>();
            ResponseValue rv = new ResponseValue();
            rv.VoteCount = 7;
            cc.ResponseValues.Add(rv);
            rv = new ResponseValue();
            rv.VoteCount = 3;
            cc.ResponseValues.Add(rv);
            _unitUnderTest.Counties.Add(cc);
            cc = new ContestCounty();
            cc.ResponseValues = new List<ResponseValue>();
            rv = new ResponseValue();
            rv.VoteCount = 100;
            cc.ResponseValues.Add(rv);
            _unitUnderTest.Counties.Add(cc);
            int expected = 110;
            int result = _unitUnderTest.GetTotalVotes();
            Assert.AreEqual(expected, result, "GetTotalVotes method returned unexpected result.");
        }

        [Test()]
        public void TestGetWardsReporting()
        {
            _unitUnderTest.Counties = new List<ContestCounty>();
            ContestCounty cc = new ContestCounty();
            cc.WardsReporting = 7;
            _unitUnderTest.Counties.Add(cc);
            cc = new ContestCounty();
            cc.WardsReporting = 3;
            _unitUnderTest.Counties.Add(cc);
            int expected = 10;
            int result = _unitUnderTest.GetWardsReporting();
            Assert.AreEqual(expected, result, "GetWardsReporting method returned unexpected result.");
        }

        [Test()]
        public void TestGetWardCount()
        {
            _unitUnderTest.Counties = new List<ContestCounty>();
            ContestCounty cc = new ContestCounty();
            cc.WardCount = 17;
            _unitUnderTest.Counties.Add(cc);
            cc = new ContestCounty();
            cc.WardCount = 13;
            _unitUnderTest.Counties.Add(cc);
            int expected = 30;
            int result = _unitUnderTest.GetWardCount();
            Assert.AreEqual(expected, result, "GetWardCount method returned unexpected result.");
        }

        [Test()]
        public void TestGetWardsReportingPercentage()
        {
            _unitUnderTest.Counties = new List<ContestCounty>();
            ContestCounty cc = new ContestCounty();
            cc.WardCount = 17;
            cc.WardsReporting = 10;
            _unitUnderTest.Counties.Add(cc);
            cc = new ContestCounty();
            cc.WardCount = 13;
            cc.WardsReporting = 5;
            _unitUnderTest.Counties.Add(cc);
            double expected = .5;
            double result = _unitUnderTest.GetWardsReportingPercentage();
            Assert.AreEqual(expected, result, "GetWardsReportingPercentage method returned unexpected result.");
        }
    }
}
