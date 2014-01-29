using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    public interface IInterface
    {
        void Foo();
    }

    public class FactoryMethod
    {
        public class ConcreteType : IInterface
        {
            public void Foo()
            {
                Console.WriteLine("Foo");
            }
        }

        public IInterface Create<T>() where T : IInterface, new()
        {
            return new T();
        }
    }

    [TestClass]
    public class FactoryMethodTests
    {
        [TestMethod]
        public void CreateConcreteType()
        {
            var factory = new FactoryMethod();
            var type = factory.Create<FactoryMethod.ConcreteType>();
            Assert.IsInstanceOfType(type, typeof(FactoryMethod.ConcreteType));
        }
    }
}
