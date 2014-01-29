using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    public class Factory
    {
        public void Construct(AbstractBuilder builder)
        {
            builder.Step1();
            builder.Step2();
        }
    }

    public abstract class AbstractBuilder
    {
        public abstract void Step1();
        public abstract void Step2();
    }

    public class ConcreteBuilder : AbstractBuilder
    {
        public override void Step1()
        {
            Console.WriteLine("Step1");
        }

        public override void Step2()
        {
            Console.WriteLine("Step2");
        }
    }

    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void Construct()
        {
            var factory = new Factory();
            var builder = new ConcreteBuilder();
            factory.Construct(builder);
        }
    }
}
