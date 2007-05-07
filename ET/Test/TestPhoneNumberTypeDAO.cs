using NHibernate;
using NUnit.Framework;
using NMock2;
using edu.uwec.cs.cs355.group4.et.core;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.db;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestPhoneNumberTypeDAO {
        private PhoneNumberTypeDAO _unitUnderTest;
        private ISessionFactory factory;
        private ISession session;
        private Mockery mocks;


        [SetUp()]
        public void SetUp() {
            mocks = new Mockery();
            session = (ISession)mocks.NewMock(typeof(ISession));
            factory = (ISessionFactory)mocks.NewMock(typeof(ISessionFactory));


            Expect.AtLeastOnce.On(factory).Method("OpenSession").Will(Return.Value(session));

            _unitUnderTest = new PhoneNumberTypeDAO(factory);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorPhoneNumberTypeDAO() {
            PhoneNumberTypeDAO testPhoneNumberTypeDAO = new PhoneNumberTypeDAO(factory);
            Assert.IsNotNull(testPhoneNumberTypeDAO,
                             "Constructor of type, PhoneNumberTypeDAO failed to create instance.");
        }

        [Test()]
        public void TestValidate()
        {
            ISQLQuery query = (ISQLQuery)mocks.NewMock(typeof(ISQLQuery));
            IList<PhoneNumberType> list = new List<PhoneNumberType>();
            

            Expect.AtLeastOnce.On(session).Method("CreateSQLQuery").Will(Return.Value(query));
            Expect.AtLeastOnce.On(query).Method("List").Will(Return.Value(list));

            PhoneNumberType entity = new PhoneNumberType();
            IList<Fault> lst = _unitUnderTest.validate(entity);
            Assert.IsTrue(lst.Count == 1);

            entity.Name = "a";
            lst = _unitUnderTest.validate(entity);
            Assert.IsTrue(lst.Count == 0);

            list.Add(new PhoneNumberType());
            lst = _unitUnderTest.validate(entity);
            Assert.IsTrue(lst.Count == 1);
        }

    }
}