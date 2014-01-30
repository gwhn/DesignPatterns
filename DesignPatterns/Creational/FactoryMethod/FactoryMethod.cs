using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Creational.FactoryMethod
{
    /// <summary>
    /// Define an interface for creating an object, but let subclasses decide which class to instantiate. 
    /// Factory Method lets a class defer instantiation to subclasses. 
    /// </summary>
    [TestClass]
    public class FactoryMethodTests
    {
        [TestMethod]
        public void Test()
        {
            var creatorA = new ConcreteCreatorA();
            var productA = creatorA.FactoryMethod();
            Console.WriteLine(productA);

            var creatorB = new ConcreteCreatorB();
            var productB = creatorB.FactoryMethod();
            Console.WriteLine(productB);
        }
    }

    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    public class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    public abstract class Product { }

    public class ConcreteProductA : Product
    {
        public override string ToString()
        {
            return "ConcreteProductA";
        }
    }

    public class ConcreteProductB : Product
    {
        public override string ToString()
        {
            return "ConcreteProductB";
        }
    }
}
