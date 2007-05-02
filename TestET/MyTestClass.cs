using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TestET
{
    [TestFixture]
    public class MyTestClass
    {
        [Test]//telling NUnit that this function should be run during the tests 
        public void TestFunction()
        {
            Assertion.AssertEquals(1, 2);
        }

    } 

}
