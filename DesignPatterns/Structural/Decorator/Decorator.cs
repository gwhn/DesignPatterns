using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Structural.Decorator
{
    /// <summary>
    /// Attach additional responsibilities to an object dynamically. 
    /// Decorators provide a flexible alternative to subclassing for extending functionality.
    /// </summary>
    [TestClass]
    public class DecoratorTests
    {
        [TestMethod]
        public void Test()
        {
            var component = new ConcreteComponent();

            var decoratorA = new ConcreteDecoratorA {Component = component};
            decoratorA.Operation();

            var decoratorB = new ConcreteDecoratorB {Component = component};
            decoratorB.Operation();
        }
    }

    public abstract class Component
    {
        public abstract void Operation();
    }

    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation");
        }
    }

    public abstract class Decorator : Component
    {
        public Component Component { get; set; }

        public override void Operation()
        {
            if (Component != null)
            {
                Component.Operation();
            }
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation");
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedOperation();
            Console.WriteLine("ConcreteDecoratorA.Operation");
        }

        private void AddedOperation()
        {
            Console.WriteLine("ConcreteDecoratorB.AddedOperation");
        }
    }
}
