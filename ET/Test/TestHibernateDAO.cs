using System;
using System.Collections.Generic;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.db {
    [TestFixture()]
    public class TestHibernateDAO {
        private MockDAO _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            Mockery mocks = new Mockery();
            ISessionFactory factory = (ISessionFactory) mocks.NewMock(typeof (ISessionFactory));
            _unitUnderTest = new MockDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorHibernateDAO() {
            ISessionFactory factory = null;
            MockDAO testHibernateDAO = new MockDAO(factory);
            Assert.IsNotNull(testHibernateDAO, "Constructor of type, HibernateDAO failed to create instance.");
            Assert.Fail("Create or modify test(s).");
        }

        [Test()]
        public void TestfindById() {
            Assert.Fail("Create or modify test(s).");
        }
    }

    internal class MockDAO : HibernateDAO<Object> {
        public MockDAO(ISessionFactory factory) : base(factory) {}

        protected override IList<Fault> performValidation(object entity) {
            return new List<Fault>();
        }
    }
}