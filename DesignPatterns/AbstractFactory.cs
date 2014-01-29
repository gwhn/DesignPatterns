using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    // abstract factory defines the contract
    public abstract class AbstractFactory
    {
        public abstract AbstractType Create();
    }

    // concrete factory derives from abstract factory and 
    // is responsible for creating the concrete type
    public class ConcreteFactory : AbstractFactory
    {
        public override AbstractType Create()
        {
            return new ConcreteType();
        }
    }

    // base class for concrete type created by concrete factory
    public abstract class AbstractType
    {
        public abstract void Foo();
    }

    public class ConcreteType : AbstractType
    {
        public override void Foo()
        {
            Console.WriteLine("Foo");
        }
    }

    [TestClass]
    public class AbstractFactoryTests
    {
        [TestMethod]
        public void CreateConcreteType()
        {
            var factory = new ConcreteFactory();
            var type = factory.Create();
            type.Foo();
            Assert.IsInstanceOfType(type, typeof(ConcreteType));
        }
    }
}
