using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test
{
    [TestFixture()]
    public class TestContestCountyDAO
    {
        private ContestCountyDAO _unitUnderTest;

        [SetUp()]
        public void SetUp()
        {
            Mockery mocks = new Mockery();

            ISession session = (ISession) mocks.NewMock(typeof (ISession));
            ISessionFactory factory = (ISessionFactory) mocks.NewMock(typeof (ISessionFactory));
            IQuery query = (ISQLQuery) mocks.NewMock(typeof (ISQLQuery));

            IList<ContestCounty> retlist = new List<ContestCounty>();
            ContestCounty forList = new ContestCounty();
            retlist.Add(forList);
            

            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("AddEntity").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("List").Will(Return.Value(retlist));
            _unitUnderTest = new ContestCountyDAO(factory);
        }

        [TearDown()]
        public void TearDown()
        {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestFind()
        {
            IList<ContestCounty> listFind = _unitUnderTest.find(1,1);
            Assert.IsTrue(listFind.Count == 1, "TestFind failed due to return list length");
        }

        [Test()]
        public void TestValidate()
        {
            ContestCounty entity = new ContestCounty();
            IList<Fault> faultlist = _unitUnderTest.validate(entity);
        }
    }
}
