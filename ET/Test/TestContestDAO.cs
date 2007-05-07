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
    public class TestContestDAO
    {
        private ContestDAO _unitUnderTest;

        [SetUp()]
        public void SetUp()
        {
            Mockery mocks = new Mockery();
            ISession session = (ISession)mocks.NewMock(typeof(ISession));
            ISessionFactory factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            ISQLQuery query = (ISQLQuery)mocks.NewMock(typeof(ISQLQuery));
            ICriteria criteria = (ICriteria)mocks.NewMock(typeof(ICriteria));
            IList<Contest> list = new List<Contest>();
            list.Add(new Contest());


            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));
            Expect.AtLeastOnce.On(session).Method("CreateCriteria").Will(Return.Value(criteria));
            Expect.AtLeastOnce.On(criteria).Method("List").Will(Return.Value(list));
            Expect.AtLeastOnce.On(criteria).Method("Add");
            Expect.AtLeastOnce.On(criteria).Method("AddOrder");
            Expect.AtLeastOnce.On(query).Method("List").Will(Return.Value(list));
            _unitUnderTest = new ContestDAO(factory);
        }

        [TearDown()]
        public void TearDown()
        {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestFindActive()
        {
            IList<Contest> testListOne;
            testListOne = _unitUnderTest.findActive();
            Assert.IsTrue(testListOne != null);
        }

        [Test()]
        public void TestFindInactive()
        {
            IList<Contest> testListTwo;
            testListTwo = _unitUnderTest.findInactive();
            Assert.IsTrue(testListTwo != null);
        }

        [Test()]
        public void TestFindAll()
        {
            IList<Contest> testListThree;
            testListThree = _unitUnderTest.findAll();
            Assert.IsTrue(testListThree != null);
        }

        [Test()]
        public void TestValidate()
        {
            IList<Fault> retList;
            Contest entity = new Contest();

            // Name is null, contest type is valid
            entity.Name = null;
            entity.ContestType = new ContestType();
            retList = _unitUnderTest.validate(entity);
            Assert.IsTrue(retList.Count == 1, "Expected count of one.");

            // Name is empty, contest type is valid
            entity.Name = "";
            retList = _unitUnderTest.validate(entity);
            Assert.IsTrue(retList.Count == 1, "Expected count of one.");

            // Name is valid, contest type is invalid (null)
            entity.Name = "a";
            entity.ContestType = null;
            retList = _unitUnderTest.validate(entity);
            Assert.IsTrue(retList.Count == 1, "Expected count of one.");

            // Name and contest type are valid, but entity is a duplicate
            entity.Name = "a";
            entity.ContestType = new ContestType();
            retList = _unitUnderTest.validate(entity);
            Assert.IsTrue(retList.Count == 1, "Expected count of one.");
        }

    }
}
