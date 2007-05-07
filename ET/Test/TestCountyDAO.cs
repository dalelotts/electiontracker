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
            IList<County> list = new List<County>();
            list.Add(new County());

            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateCriteria").Will(Return.Value(criteria));
            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("AddEntity").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("List").Will(Return.Value(list));
            _unitUnderTest = new CountyDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestValidate() {
            County entity = new County();

            entity.Name = null;
            IList<Fault> resultIList = _unitUnderTest.validate(entity);
            Assert.IsTrue(resultIList.Count == 1, "Expected count of one (null name).");

            entity.Name = "";
            resultIList = _unitUnderTest.validate(entity);
            Assert.IsTrue(resultIList.Count == 1, "Expected count of one (empty name).");

            entity.Name = "a";
            resultIList = _unitUnderTest.validate(entity);
            Assert.IsTrue(resultIList.Count > 0, "Returned count of 0 (should return at least 1 for duplicate County name).");
        
        }
    }
}