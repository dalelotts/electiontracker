using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestfrmCountyContactForm {
        private frmCountyContactForm _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            ElectionDAO electionDAO = null;
            CountyDAO countyDAO = null;
            _unitUnderTest = new frmCountyContactForm(electionDAO, countyDAO);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorfrmCountyContactForm() {
            ElectionDAO electionDAO = null;
            CountyDAO countyDAO = null;
            frmCountyContactForm testfrmCountyContactForm = new frmCountyContactForm(electionDAO, countyDAO);
            Assert.IsNotNull(testfrmCountyContactForm,
                             "Constructor of type, frmCountyContactForm failed to create instance.");
        }
    }
}