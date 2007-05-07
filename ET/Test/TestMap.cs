using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.util {
    [TestFixture()]
    public class TestMap {
        private Map<object, object> _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new Map<object, object>();
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestPut() {
            _unitUnderTest.Put(null, null);
        }
    }
}