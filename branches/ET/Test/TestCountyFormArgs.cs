using edu.uwec.cs.cs355.group4.et.events;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestCountyFormArgs
    {
        [Test()]
        public void TestCountyFormArgsConsOne()
        {
            CountyFormArgs cfa = new CountyFormArgs();
            Assert.IsNotNull(cfa);
        }

        [Test()]
        public void TestCountyFormArgsConsTwo()
        {
            CountyFormArgs cfa = new CountyFormArgs(1);
            Assert.IsNotNull(cfa);
        }

        [Test()]
        public void TestGetID()
        {
            CountyFormArgs cfa = new CountyFormArgs(1);
            Assert.AreEqual(cfa.ID, 1);
        }
    }
}
