using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.db {
    [TestFixture()]
    public class TestPoliticalPartyDAO {
        private PoliticalPartyDAO _unitUnderTest;
        private ISession session;
        private ISessionFactory factory;
        private ICriteria criteria;

        [SetUp()]
        public void SetUp() {
            Mockery mocks = new Mockery();
            factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            session = (ISession)mocks.NewMock(typeof(ISession));
            criteria = (ICriteria)mocks.NewMock(typeof(ICriteria));

            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateCriteria").Will(Return.Value(criteria));
            Expect.AtLeastOnce.On(criteria).Method("Add");
            Expect.AtLeastOnce.On(criteria).Method("AddOrder");

            _unitUnderTest = new PoliticalPartyDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorPoliticalPartyDAOFactory() {
            PoliticalPartyDAO testPoliticalPartyDAO = new PoliticalPartyDAO(factory);
            Assert.IsNotNull(testPoliticalPartyDAO, "Constructor of type, PoliticalPartyDAO failed to create instance.");

        }

        [Test()]
        public void TestfindActive() {
            IList<PoliticalParty> expectedIList = null;
            Expect.AtLeastOnce.On(criteria).Method("List").Will(Return.Value(expectedIList));

            
            IList<PoliticalParty> resultIList = null;
            resultIList = _unitUnderTest.findActive();
            Assert.AreEqual(expectedIList, resultIList, "findActive method returned unexpected result.");

        }

        [Test()]
        public void TestfindInactive() {
            IList<PoliticalParty> expectedIList = null;
            Expect.AtLeastOnce.On(criteria).Method("List").Will(Return.Value(expectedIList));

            IList<PoliticalParty> resultIList = null;
            resultIList = _unitUnderTest.findInactive();
            Assert.AreEqual(expectedIList, resultIList, "findInactive method returned unexpected result.");

        }
    }
}