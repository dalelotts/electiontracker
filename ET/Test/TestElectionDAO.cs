using System;
using System.Collections.Generic;
using System.Text;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestElectionDAO
    {

        private ElectionDAO _unitUnderTest;
        private ISession session;
        private ISessionFactory factory;
        private ISQLQuery query;
        private ICriteria criteria;

        [SetUp()]
        public void SetUp()
        {
            Mockery mocks = new Mockery();
            session = (ISession)mocks.NewMock(typeof(ISession));
            factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            query = (ISQLQuery)mocks.NewMock(typeof(ISQLQuery));
            criteria = (ICriteria)mocks.NewMock(typeof(ICriteria));

            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateCriteria").Will(Return.Value(criteria));
            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));

            _unitUnderTest = new ElectionDAO(factory);
        }

        [TearDown()]
        public void TearDown()
        {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestFindActive()
        {

            IList<Election> list = new List<Election>();
            list.Add(new Election());

            Expect.Once.On(criteria).Method("Add");
            Expect.Once.On(criteria).Method("AddOrder");
            Expect.Once.On(criteria).Method("List").Will(Return.Value(list));
            IList<Election> lst = _unitUnderTest.findActive();
            Assert.IsNotNull(lst);
        }

        [Test()]
        public void TestFindInactive()
        {
            IList<Election> list = new List<Election>();
            list.Add(new Election());

            Expect.Once.On(criteria).Method("Add");
            Expect.Once.On(criteria).Method("AddOrder");
            Expect.Once.On(criteria).Method("List").Will(Return.Value(list));
            IList<Election> lst = _unitUnderTest.findInactive();
            Assert.IsNotNull(lst);
        }

        [Test()]
        public void TestValidate()
        {
            Election entity = new Election();
            

            IList<Fault> lst = _unitUnderTest.validate(entity);
            Assert.IsTrue(lst.Count == 0);
        }

        [Test()]
        public void TestFindCounties()
        {
            IList<County> list = new List<County>();
            list.Add(new County());

            Expect.Once.On(query).Method("AddEntity").Will(Return.Value(query));
            Expect.Once.On(query).Method("List").Will(Return.Value(list));
            IList<County> lst = _unitUnderTest.findCounties(new Election());
            Assert.IsNotNull(lst);
        }

    }
}
