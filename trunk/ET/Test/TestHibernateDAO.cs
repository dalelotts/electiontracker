using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestHibernateDAO {
        private MockDAO _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            Mockery mocks = new Mockery();
            ISession session = (ISession)mocks.NewMock(typeof(ISession));
            ISessionFactory factory = (ISessionFactory) mocks.NewMock(typeof (ISessionFactory));
            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            
            _unitUnderTest = new MockDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorHibernateDAO() {
            Mockery mocks = new Mockery();
            ISessionFactory factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            ISession session = (ISession)mocks.NewMock(typeof(ISession));
            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            MockDAO testHibernateDAO = new MockDAO(factory);
            Assert.IsNotNull(testHibernateDAO, "Constructor of type (HibernateDAO) failed to create instance.");
        }
    }

    internal class MockDAO : HibernateDAO<Object> {
        public MockDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(object entity) {
            return new List<Fault>();
        }
    }
}