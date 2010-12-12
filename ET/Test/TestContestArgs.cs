using edu.uwec.cs.cs355.group4.et.events;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestContestArgs
    {
        [Test()]
        public void TestContestArgsConsOne()
        {
            ContestArgs ca = new ContestArgs();
            Assert.IsNotNull(ca);
        }

        [Test()]
        public void TestContestArgsConsTwo()
        {
            ContestArgs ca = new ContestArgs(1);
            Assert.IsNotNull(ca);
        }

        [Test()]
        public void TestGetID()
        {
            ContestArgs ca = new ContestArgs(1);
            Assert.AreEqual(ca.ID, 1);
        }
    }
}
