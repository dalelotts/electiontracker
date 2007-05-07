using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.core;
using System.Text;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestCandidateDAO
    {
        private CandidateDAO _unitUnderTest;

        [SetUp()]
        public void SetUp()
        {
            Mockery mocks = new Mockery();
            ISession session = (ISession)mocks.NewMock(typeof(ISession));
            ISessionFactory factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            ISQLQuery query = (ISQLQuery)mocks.NewMock(typeof(ISQLQuery));
            ICriteria criteria = (ICriteria)mocks.NewMock(typeof(ICriteria));
            IList<Candidate> list = new List<Candidate>();
            IList<string> strlist = new List<string>();
            strlist.Add("a");


            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateCriteria").Will(Return.Value(criteria));
            Expect.AtLeastOnce.On(criteria).Method("List").Will(Return.Value(list));
            Expect.AtLeastOnce.On(criteria).Method("Add");
            Expect.AtLeastOnce.On(criteria).Method("AddOrder");
            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("AddEntity").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("List").Will(Return.Value(strlist));
            _unitUnderTest = new CandidateDAO(factory);
        }

        [TearDown()]
        public void TearDown()
        {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestFindActive()
        {
            IList<Candidate> testListOne;
            testListOne = _unitUnderTest.findActive();
            Assert.IsTrue(testListOne != null);
        }

        [Test()]
        public void TestFindInactive()
        {
            IList<Candidate> testListTwo;
            testListTwo = _unitUnderTest.findInactive();
            Assert.IsTrue(testListTwo != null);
        }

        [Test()]
        public void TestFindAll()
        {
            IList<Candidate> testListThree;
            testListThree = _unitUnderTest.findAll();
            Assert.IsTrue(testListThree != null);
        }


        [Test()]
        public void TestValidate()
        {
            // Test performValidation with LastName empty string
            IList<Fault> retList;
            Candidate entity = new Candidate();
            entity.LastName = "";
            entity.FirstName = "a";
            retList = _unitUnderTest.validate(entity);
            Assert.IsTrue(retList.Count == 1, "Expected count of one.");

            // Test performValidation with LastName null string
            entity = new Candidate();
            entity.LastName = null;
            entity.FirstName = "a";
            retList = _unitUnderTest.validate(entity);
            Assert.IsTrue(retList.Count == 1, "Expected count of one.");

            // Test performValidation with FirstName empty string
            entity = new Candidate();
            entity.LastName = "a";
            entity.FirstName = "";
            retList = _unitUnderTest.validate(entity);
            Assert.IsTrue(retList.Count == 1, "Expected count of one.");

            // Test performValidation with FirstName null string
            entity = new Candidate();
            entity.LastName = "a";
            entity.FirstName = null;
            retList = _unitUnderTest.validate(entity);
            Assert.IsTrue(retList.Count == 1, "Expected count of one.");

            // Test performValidation with database invalidation
            entity = new Candidate();
            entity.LastName = "a";
            entity.FirstName = "a";
            retList = _unitUnderTest.validate(entity);
            Assert.IsTrue(retList.Count == 1, "Expected count of one.");
        }
    }
}
