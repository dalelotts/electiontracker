using NHibernate;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.db {
    [TestFixture()]
    public class TestResponseDAO {
        private ResponseDAO _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            ISessionFactory factory = null;
            _unitUnderTest = new ResponseDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorResponseDAO() {
            ISessionFactory factory = null;
            ResponseDAO testResponseDAO = new ResponseDAO(factory);
            Assert.IsNotNull(testResponseDAO, "Constructor of type, ResponseDAO failed to create instance.");
            Assert.Fail("Create or modify test(s).");
        }
    }
}