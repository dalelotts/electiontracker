using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.core;
using NHibernate;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.db {
    [TestFixture()]
    public class TestResponseValueDAO {
        private ResponseValueDAO _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            ISessionFactory factory = null;
            _unitUnderTest = new ResponseValueDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorResponseValueDAO() {
            ISessionFactory factory = null;
            ResponseValueDAO testResponseValueDAO = new ResponseValueDAO(factory);
            Assert.IsNotNull(testResponseValueDAO, "Constructor of type, ResponseValueDAO failed to create instance.");
            Assert.Fail("Create or modify test(s).");
        }

        [Test()]
        public void Testfind() {
            long responseID = 0;
            long contestCountyID = 10;
            IList<ResponseValue> expectedIList = null;
            IList<ResponseValue> resultIList = null;
            resultIList = _unitUnderTest.find(responseID, contestCountyID);
            Assert.AreEqual(expectedIList, resultIList, "find method returned unexpected result.");
            Assert.Fail("Create or modify test(s).");
        }
    }
}