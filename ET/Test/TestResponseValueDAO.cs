using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestResponseValueDAO {
        private ResponseValueDAO _unitUnderTest;
        private ISession session;
        private ISessionFactory factory;
        private Mockery mocks;

        [SetUp()]
        public void SetUp() {
            mocks = new Mockery();
            session = (ISession)mocks.NewMock(typeof(ISession));
            factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            ISQLQuery query = (ISQLQuery)mocks.NewMock(typeof(ISQLQuery));
            IList<ResponseValue> list = null;

            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("AddEntity").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("List").Will(Return.Value(list));
            _unitUnderTest = new ResponseValueDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorResponseValueDAO() {
            ResponseValueDAO testResponseValueDAO = new ResponseValueDAO(factory);
            Assert.IsNotNull(testResponseValueDAO, "Constructor of type, ResponseValueDAO failed to create instance.");
        }

        [Test()]
        public void Testfind() {
            long responseID = 0;
            long contestCountyID = 10;
            IList<ResponseValue> expectedIList = null;
            IList<ResponseValue> resultIList = _unitUnderTest.find(responseID, contestCountyID);
            Assert.AreEqual(expectedIList, resultIList, "find method returned unexpected result.");
        }
    }
}