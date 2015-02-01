using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JML.SteelIce.Tests
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void SayHello_Test()
        {
            Console.WriteLine("Hello you");
        }
    }
}
