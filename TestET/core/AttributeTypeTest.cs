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
            test_AttributeType.ID = 1;
            test_AttributeType.Name = "Hello";

            long test_ID = test_AttributeType.ID;
            string test_Name = test_AttributeType.Name;

            
            Assert.AreEqual(1, test_ID);
            Assert.AreEqual("Hello", test_Name);

        }
    }
}
