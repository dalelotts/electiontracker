using edu.uwec.cs.cs355.group4.et.db;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestFault
    {
        private Fault _unitUnderTest;

        [SetUp()]
        public void SetUp()
        {
            _unitUnderTest = new Fault(true, "message");
        }

        [TearDown()]
        public void TearDown()
        {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestIsError()
        {
            Assert.IsTrue(_unitUnderTest.IsError);
        }

        [Test()]
        public void TestMessage()
        {
            Assert.AreEqual(_unitUnderTest.Message, "message");
        }

    }
}
