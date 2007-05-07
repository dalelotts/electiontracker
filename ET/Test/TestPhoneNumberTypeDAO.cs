using NHibernate;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.db {
    [TestFixture()]
    public class TestPhoneNumberTypeDAO {
        private PhoneNumberTypeDAO _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            ISessionFactory factory = null;
            _unitUnderTest = new PhoneNumberTypeDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorPhoneNumberTypeDAO() {
            ISessionFactory factory = null;
            PhoneNumberTypeDAO testPhoneNumberTypeDAO = new PhoneNumberTypeDAO(factory);
            Assert.IsNotNull(testPhoneNumberTypeDAO,
                             "Constructor of type, PhoneNumberTypeDAO failed to create instance.");
            Assert.Fail("Create or modify test(s).");
        }
    }
}