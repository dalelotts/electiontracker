using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestResponseDAO {
        private ResponseDAO _unitUnderTest;
        private ISessionFactory factory;
        private ISession session;
        private Mockery mocks;

        [SetUp()]
        public void SetUp() {
            mocks = new Mockery();
            session = (ISession)mocks.NewMock(typeof(ISession));
            factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            

            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            

            _unitUnderTest = new ResponseDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorResponseDAO() {
            ResponseDAO testResponseDAO = new ResponseDAO(factory);
            Assert.IsNotNull(testResponseDAO, "Constructor of type, ResponseDAO failed to create instance.");
        }

        [Test()]
        public void TestValidate()
        {
            Response entity = new CandidateResponse();
            IList<Fault> lst = _unitUnderTest.validate(entity);

            Assert.IsTrue(lst.Count == 1);

            entity.ElectionContest = new ElectionContest();
            lst = _unitUnderTest.validate(entity);
            Assert.IsTrue(lst.Count == 0);
        }
    }
}