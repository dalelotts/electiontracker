using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;
using NMock2;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestAttributeTypeDAO {
        private AttributeTypeDAO _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            Mockery mocks = new Mockery();
            ISession session = (ISession) mocks.NewMock(typeof (ISession));
            ISessionFactory factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));
            ISQLQuery query = (ISQLQuery)mocks.NewMock(typeof(ISQLQuery));
            IList<string> list = new List<string>();
            list.Add("Daytime Phone");
            

            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));
            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("List").Will(Return.Value(list));
            _unitUnderTest = new AttributeTypeDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }
        
        [Test()]
        public void TestValidate() {
            AttributeType entity = new AttributeType();
            entity.Name = "";
            IList<Fault> resultIList = _unitUnderTest.validate(entity);

            Assert.IsTrue(resultIList.Count ==1, "Expected count of one (empty string).");


            AttributeType entityTwo = new AttributeType();
            resultIList = _unitUnderTest.validate(entity);

            Assert.IsTrue(resultIList.Count == 1, "Expected count of one (null string).");


            AttributeType entityThree = new AttributeType();
            entityThree.Name = "Daytime Phone";
            resultIList = _unitUnderTest.validate(entity);

            Assert.IsTrue(resultIList.Count == 1, "Expected count of one (database duplicate).");
        }
    }
}