using System;
using System.Collections.Generic;
using System.Text;
using edu.uwec.cs.cs355.group4.et.events;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestCandidateArgs
    {
        [Test()]
        public void TestCandidateArgsConsOne()
        {
            CandidateArgs ca = new CandidateArgs();
            Assert.IsNotNull(ca);
        }

        [Test()]
        public void TestCandidateArgsConsTwo()
        {
            CandidateArgs ca = new CandidateArgs(1);
            Assert.IsNotNull(ca);
        }

        [Test()]
        public void TestGetID()
        {
            CandidateArgs ca = new CandidateArgs(1);
            Assert.AreEqual(ca.ID, 1);
        }
    }
}
