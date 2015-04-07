using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestMethod1()
        {
            int a = 2;
            int b = 1;
            Assert.AreEqual(a, b);
        }
    }
}