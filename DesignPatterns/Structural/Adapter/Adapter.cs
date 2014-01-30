using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Structural.Adapter
{
    /// <summary>
    /// Convert the interface of a class into another interface clients expect. 
    /// Adapter lets classes work together that couldn't otherwise because of incompatible interfaces. 
    /// </summary>
    [TestClass]
    public class AdapterTests
    {
        [TestMethod]
        public void Test()
        {
            var target = new Adapter();
            target.Request();
        }
    }

    public class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Target.Request");
        }
    }

    public class Adapter : Target
    {
        private readonly Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    internal class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Adaptee.SpecificRequest");
        }
    }
}
