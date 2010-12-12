using System;
using System.Collections.Generic;
using edu.uwec.cs.cs355.group4.et.db;
using edu.uwec.cs.cs355.group4.et.ui;
using NUnit.Framework;
using AssertionException=DesignByContract.AssertionException;

namespace edu.uwec.cs.cs355.group4.et.Test {
    [TestFixture()]
    public class TestBaseMDIChild {
        private IList<Fault> errors;
        private IList<Fault> warnings;
        private BaseMDIChild _unitUnderTest;

        [SetUp()]
        public void SetUp() {
            _unitUnderTest = new BaseMDIChild();
            errors = new List<Fault>();
            warnings = new List<Fault>();

            errors.Add(new Fault(true, "This is an error fault."));
            errors.Add(new Fault(true, "This is another error fault."));

            warnings.Add(new Fault(false, "This is a warning fault."));
            warnings.Add(new Fault(false, "This is another warning fault."));
        }

        [TearDown()]
        public void TearDown() {
            _unitUnderTest = null;
        }

        [Test()]
        public void TestConstructorBaseMDIChild() {
            BaseMDIChild testBaseMDIChild = new BaseMDIChild();
            Assert.IsNotNull(testBaseMDIChild, "Constructor of type, BaseMDIChild failed to create instance.");
        }

        [Test()]
        public void TestreportFaultsNull() {
            try {
                BaseMDIChild.reportFaults(null);
                Assert.Fail("Expected AssertionException.");
            } catch (AssertionException ignored) {
                // Expected                      
            }
        }

        [Test()]
        public void TestreportFaultsWarnings() {
            BaseMDIChild.reportFaults(warnings);
            //Assert.IsTrue(result, "Expected result to be true.");
            // In this case result depends on the user so don't check it.
        }


        [Test()]
        public void TestreportFaultsErrors() {
            bool result = BaseMDIChild.reportFaults(errors);
            Assert.IsFalse(result, "Expected result to be false.");
        }

        [Test()]
        public void TestreportFaultsErrorsAndWarnings() {
            IList<Fault> both = new List<Fault>(errors);
            both.Add(warnings[0]);
            both.Add(warnings[1]);
            bool result = BaseMDIChild.reportFaults(both);
            Assert.IsFalse(result, "Expected result to be false.");
        }

        [Test()]
        public void TestbtnEdit_Click() {
            object sender = null;
            EventArgs e = null;
            _unitUnderTest.btnEdit_Click(sender, e);
        }

        [Test()]
        public void TestbtnAdd_Click() {
            object sender = null;
            EventArgs e = null;
            _unitUnderTest.btnAdd_Click(sender, e);
        }

        [Test()]
        public void TestbtnSave_Click() {
            object sender = null;
            EventArgs e = null;
            _unitUnderTest.btnSave_Click(sender, e);
        }

        [Test()]
        public void TestbtnReset_Click() {
            object sender = null;
            EventArgs e = null;
            _unitUnderTest.btnReset_Click(sender, e);
        }

        [Test()]
        public void TestbtnDelete_Click() {
            object sender = null;
            EventArgs e = null;
            _unitUnderTest.btnDelete_Click(sender, e);
        }

        [Test()]
        public void TestcboGoTo_SelectedIndexChanged() {
            object sender = null;
            EventArgs e = null;
            _unitUnderTest.cboGoTo_SelectedIndexChanged(sender, e);
        }
    }
}