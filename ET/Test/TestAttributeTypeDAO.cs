using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using edu.uwec.cs.cs355.group4.et.db;
using NHibernate;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.test.db {
    [TestFixture()]
    public class TestAttributeTypeDAO {
        private AttributeTypeDAO _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            ISessionFactory factory = null;
            _unitUnderTest = new AttributeTypeDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestValidate() {
            AttributeType entity = new AttributeType();
            IList<Fault> expectedIList = new List<Fault>();
            IList<Fault> resultIList = null;
            resultIList = _unitUnderTest.validate(entity);
            Assert.AreEqual(expectedIList, resultIList, "validate method returned unexpected result.");
            Assert.Fail("Create or modify test(s).");
        }
    }
}