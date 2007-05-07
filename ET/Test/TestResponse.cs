using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.core {
    [TestFixture()]
    public class TestResponse {
        private Response _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new MockResponse();
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestToString() {
            string expectedString = "MockResponse";
            string resultString = _unitUnderTest.ToString();
            Assert.AreEqual(expectedString, resultString, "ToString method returned unexpected result.");
        }

        [Test()]
        public void TestGetTotalVotes() {
            int expectedInt32 = 0;
            int resultInt32 = _unitUnderTest.GetTotalVotes();
            Assert.AreEqual(expectedInt32, resultInt32, "GetTotalVotes method returned unexpected result.");
        }
    }

    internal class MockResponse : Response {
        public override string ToString() {
            return "MockResponse";
        }
    }
}