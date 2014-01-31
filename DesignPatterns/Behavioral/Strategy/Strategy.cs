using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy
{
    /// <summary>
    /// Define a family of algorithms, encapsulate each one, and make them interchangeable. 
    /// Strategy lets the algorithm vary independently from clients that use it.
    /// </summary>
    [TestClass]
    public class StrategyTests
    {
        [TestMethod]
        public void Test()
        {
            var context = new Context(new ConcreteStrategyA());
            context.Operation();
            context = new Context(new ConcreteStrategyB());
            context.Operation();
            context = new Context(new ConcreteStrategyC());
            context.Operation();
        }
    }

    public class Context
    {
        private Strategy _strategy;

        public Context(Strategy strategy)
        {
            _strategy = strategy;
        }

        public void Operation()
        {
            _strategy.Operation();
        }
    }

    public abstract class Strategy
    {
        public abstract void Operation();
    }

    public class ConcreteStrategyA : Strategy
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteStrategyA.Operation");
        }
    }

    public class ConcreteStrategyB : Strategy
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteStrategyB.Operation");
        }
    }

    public class ConcreteStrategyC : Strategy
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteStrategyC.Operation");
        }
    }
}
