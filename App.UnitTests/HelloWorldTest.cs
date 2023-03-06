using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.UnitTests
{
    internal class HelloWorldTest
    {
        [Test]
        public void OutputTest()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            App.HelloWorld.Main(null);
            string output = stringWriter.ToString().Trim();
            Assert.AreEqual("Hello World!", output);
        }
    }
}
