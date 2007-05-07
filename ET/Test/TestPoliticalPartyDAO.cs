using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.db {
    [TestFixture()]
    public class TestPoliticalPartyDAO {
        private PoliticalPartyDAO _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            Mockery mocks = new Mockery();
            ISessionFactory factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            _unitUnderTest = new PoliticalPartyDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorPoliticalPartyDAOFactory() {
            ISessionFactory factory = null;
            PoliticalPartyDAO testPoliticalPartyDAO = new PoliticalPartyDAO(factory);
            Assert.IsNotNull(testPoliticalPartyDAO, "Constructor of type, PoliticalPartyDAO failed to create instance.");
            Assert.Fail("Create or modify test(s).");
        }

        [Test()]
        public void TestfindActive() {
            IList<PoliticalParty> expectedIList = null;
            IList<PoliticalParty> resultIList = null;
            resultIList = _unitUnderTest.findActive();
            Assert.AreEqual(expectedIList, resultIList, "findActive method returned unexpected result.");
            Assert.Fail("Create or modify test(s).");
        }

        [Test()]
        public void TestfindInactive() {
            IList<PoliticalParty> expectedIList = null;
            IList<PoliticalParty> resultIList = null;
            resultIList = _unitUnderTest.findInactive();
            Assert.AreEqual(expectedIList, resultIList, "findInactive method returned unexpected result.");
            Assert.Fail("Create or modify test(s).");
        }
    }
}