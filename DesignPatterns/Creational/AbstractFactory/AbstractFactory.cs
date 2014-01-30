using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Creational.AbstractFactory
{
    /// <summary>
    /// Provide an interface for creating families of related or 
    /// dependent objects without specifying their concrete classes. 
    /// </summary>
    [TestClass]
    public class AbstractFactoryTests
    {
        [TestMethod]
        public void Test()
        {
            var factoryA = new ConcreteFactoryA();
            var clientA = new Client(factoryA);
            clientA.Run();

            var factoryB = new ConcreteFactoryB();
            var clientB = new Client(factoryB);
            clientB.Run();
        }
    }

    public abstract class AbstractFactory
    {
        public abstract AbstractProduct CreateProduct();
    }

    public class ConcreteFactoryA : AbstractFactory
    {
        public override AbstractProduct CreateProduct()
        {
            return new Product1();
        }
    }

    public class ConcreteFactoryB : AbstractFactory
    {
        public override AbstractProduct CreateProduct()
        {
            return new Product2();
        }
    }

    public abstract class AbstractProduct
    {
        public abstract void Operation();
    }

    public class Product1 : AbstractProduct
    {
        public override void Operation()
        {
            Console.WriteLine("Product1.Operation");
        }
    }

    public class Product2 : AbstractProduct
    {
        public override void Operation()
        {
            Console.WriteLine("Product2.Operation");
        }
    }

    public class Client
    {
        private readonly AbstractProduct _product;

        public Client(AbstractFactory factory)
        {
            _product = factory.CreateProduct();
        }

        public void Run()
        {
            _product.Operation();
        }
    }
}
