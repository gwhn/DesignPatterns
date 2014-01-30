using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Structural.Bridge
{
    /// <summary>
    /// Decouple an abstraction from its implementation so that the two can vary independently.
    /// </summary>
    [TestClass]
    public class Bridge
    {
        [TestMethod]
        public void Test()
        {
            var abstraction = new RefinedAbstraction();

            abstraction.Implementor = new ConcreteImplementorA();
            abstraction.Operation();

            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.Operation();
        }
    }

    public abstract class Abstraction
    {
        public Implementor Implementor { get; set; }

        public virtual void Operation()
        {
            Implementor.Operation();
        }
    }

    public class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            Implementor.Operation();
        }
    }

    public abstract class Implementor
    {
        public abstract void Operation();
    }

    public class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA.Operation");
        }
    }

    public class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB.Operation");
        }
    }
}
