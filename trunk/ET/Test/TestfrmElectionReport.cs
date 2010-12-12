using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui;
using NUnit.Framework;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestfrmElectionReport {
        private frmElectionReport _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            ElectionDAO electionDAO = null;
            ContestCountyDAO contestCountyDAO = null;
            _unitUnderTest = new frmElectionReport(electionDAO, contestCountyDAO);
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorfrmElectionReport() {
            ElectionDAO electionDAO = null;
            ContestCountyDAO contestCountyDAO = null;
            frmElectionReport testfrmElectionReport = new frmElectionReport(electionDAO, contestCountyDAO);
            Assert.IsNotNull(testfrmElectionReport, "Constructor of type, frmElectionReport failed to create instance.");
        }
    }
}