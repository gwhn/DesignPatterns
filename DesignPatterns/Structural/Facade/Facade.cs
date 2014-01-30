using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Structural.Facade
{
    /// <summary>
    /// Provide a unified interface to a set of interfaces in a subsystem. 
    /// Façade defines a higher-level interface that makes the subsystem easier to use.
    /// </summary>
    [TestClass]
    public class FacadeTests
    {
        [TestMethod]
        public void Test()
        {
            var facade = new Facade();
            facade.MethodA();
            facade.MethodB();
        }
    }

    public class Facade
    {
        private readonly SubSystemA _subSystemA = new SubSystemA();
        private readonly SubSystemB _subSystemB = new SubSystemB();
        private readonly SubSystemC _subSystemC = new SubSystemC();

        public void MethodA()
        {
            _subSystemA.Operation();
            _subSystemB.Operation();
        }

        public void MethodB()
        {
            _subSystemB.Operation();
            _subSystemC.Operation();
        }
    }

    internal class SubSystemA
    {
        public void Operation()
        {
            Console.WriteLine("SubSystemA.Operation");
        }
    }

    internal class SubSystemB
    {
        public void Operation()
        {
            Console.WriteLine("SubSystemB.Operation");
        }
    }

    internal class SubSystemC
    {
        public void Operation()
        {
            Console.WriteLine("SubSystemC.Operation");
        }
    }
}
