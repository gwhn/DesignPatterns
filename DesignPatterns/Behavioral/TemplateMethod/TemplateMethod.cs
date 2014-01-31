using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    /// <summary>
    /// Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. 
    /// Template Method lets subclasses redefine certain steps of an algorithm 
    /// without changing the algorithm's structure.
    /// </summary>
    [TestClass]
    public class TemplateMethodTests
    {
        [TestMethod]
        public void Test()
        {
            var typeA = new ConcreteTypeA();
            typeA.TemplateMethod();
            var typeB = new ConcreteTypeB();
            typeB.TemplateMethod();
        }
    }

    public abstract class AbstractType
    {
        public abstract void PrimitiveMethodA();
        public abstract void PrimitiveMethodB();

        public void TemplateMethod()
        {
            PrimitiveMethodA();
            PrimitiveMethodB();
        }
    }

    public class ConcreteTypeA : AbstractType
    {
        public override void PrimitiveMethodA()
        {
            Console.WriteLine("ConcreteTypeA.PrimitiveMethodA");
        }

        public override void PrimitiveMethodB()
        {
            Console.WriteLine("ConcreteTypeA.PrimitiveMethodB");
        }
    }

    public class ConcreteTypeB : AbstractType
    {
        public override void PrimitiveMethodA()
        {
            Console.WriteLine("ConcreteTypeB.PrimitiveMethodA");
        }

        public override void PrimitiveMethodB()
        {
            Console.WriteLine("ConcreteTypeB.PrimitiveMethodB");
        }
    }
}
