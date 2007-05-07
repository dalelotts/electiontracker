using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestElectionContestDAO
    {
        private ElectionContestDAO _unitUnderTest;
        private ISession session;
        private ISessionFactory factory;
        private ISQLQuery query;
        private ICriteria criteria;

        [SetUp()]
        public void SetUp() {
            Mockery mocks = new Mockery();
            session = (ISession)mocks.NewMock(typeof(ISession));
            factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            query = (ISQLQuery)mocks.NewMock(typeof(ISQLQuery));
            criteria = (ICriteria)mocks.NewMock(typeof(ICriteria));

            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateCriteria").Will(Return.Value(criteria));
            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));

            _unitUnderTest = new ElectionContestDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestFindContests()
        {

            IList<ElectionContest> list = new List<ElectionContest>();
            list.Add(new ElectionContest());

            Expect.AtLeastOnce.On(query).Method("AddEntity").Will(Return.Value(query));
            Expect.Once.On(query).Method("List").Will(Return.Value(list));
            IList <ElectionContest> lst = _unitUnderTest.findContests(new County());
            Assert.IsNotNull(lst);
        }

        [Test()]
        public void TestFindContestCounty()
        {
            IList<ContestCounty> list = new List<ContestCounty>();
            list.Add(new ContestCounty());

            Expect.AtLeastOnce.On(query).Method("AddEntity").Will(Return.Value(query));
            Expect.Once.On(query).Method("List").Will(Return.Value(list));

            ContestCounty cc = _unitUnderTest.findContestCounty(new County(), new ElectionContest());
            Assert.IsNotNull(cc);
        }

        [Test()]
        public void TestFindResponses()
        {
            IList<Response> list = new List<Response>();
            list.Add(new CandidateResponse());

            Expect.AtLeastOnce.On(query).Method("AddEntity").Will(Return.Value(query));
            Expect.Once.On(query).Method("List").Will(Return.Value(list));
            IList<Response> lst = _unitUnderTest.findResponses(new ElectionContest());
            Assert.IsNotNull(lst);

        }

        [Test()]
        public void TestFindVoteCount()
        {
            IList<ResponseValue> list = new List<ResponseValue>();
            ResponseValue rv = new ResponseValue();
            rv.VoteCount = 1;


            Expect.AtLeastOnce.On(query).Method("AddEntity").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("List").Will(Return.Value(list));

            int tst = _unitUnderTest.findVoteCount(new CandidateResponse(), new ContestCounty());
            Assert.IsTrue(tst == 0);

            list.Add(rv);
            tst = _unitUnderTest.findVoteCount(new CandidateResponse(), new ContestCounty());
            Assert.IsTrue(tst == 1);

        }

        [Test()]
        public void TestPerformValidation()
        {
            ElectionContest entity = new ElectionContest();
            IList<Fault> tstValidate = _unitUnderTest.validate(entity);
            Assert.IsNotNull(tstValidate);
        }

    }
}
