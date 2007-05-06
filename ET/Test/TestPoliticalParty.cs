using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using edu.uwec.cs.cs355.group4.et.core;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestPoliticalParty
    {
        PoliticalParty _unitUnderTest;
        [SetUp()]
        public void SetUp()
        {
            _unitUnderTest = new PoliticalParty();
        }

        [TearDown()]
        public void TearDown()
        {
            _unitUnderTest = null;
        }

        [Test()]

        public void TestToString()
        {
            _unitUnderTest.Name = "THE_NAME";
            _unitUnderTest.Abbreviation = "TST";
            string expected = "THE_NAME (TST)";
            string result = _unitUnderTest.ToString();
            Assert.AreEqual(expected, result, "Political Party ToString method failed.");
        }
    }
}
