using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestCountyDAO {
        private CountyDAO _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            Mockery mocks = new Mockery();
            ISession session = (ISession) mocks.NewMock(typeof (ISession));
            ISessionFactory factory = (ISessionFactory) mocks.NewMock(typeof (ISessionFactory));
            ISQLQuery query = (ISQLQuery) mocks.NewMock(typeof (ISQLQuery));
            ICriteria criteria = (ICriteria) mocks.NewMock(typeof (ICriteria));
            IList<Candidate> list = new List<Candidate>();
            IList<string> strlist = new List<string>();
            strlist.Add("a");


            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateCriteria").Will(Return.Value(criteria));
            Expect.AtLeastOnce.On(criteria).Method("List").Will(Return.Value(list));
            Expect.AtLeastOnce.On(criteria).Method("Add");
            Expect.AtLeastOnce.On(criteria).Method("AddOrder");
            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("List").Will(Return.Value(strlist));
            _unitUnderTest = new CountyDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestValidate() {}
    }
}