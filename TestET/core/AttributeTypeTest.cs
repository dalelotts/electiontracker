using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using edu.uwec.cs.cs355.group4.et.core;

namespace TestET.core
{
    [TestFixture]
    public class AttributeTypeTest
    {
        [Test]
        public void testID()
        {
            AttributeType test_AttributeType = new AttributeType();
            string test_string = "Test";
            long test_long = 123;

            test_AttributeType.ID = test_long;
            test_AttributeType.Name = test_string;

            long test_ID = test_AttributeType.ID;
            string test_Name = test_AttributeType.Name;


            Assert.AreEqual(test_long, test_ID);
            Assert.AreEqual(test_string, test_Name);

        }
    }
}
