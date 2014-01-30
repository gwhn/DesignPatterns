using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Creational.Prototype
{
    /// <summary>
    /// Specify the kind of objects to create using a prototypical instance, 
    /// and create new objects by copying this prototype.
    /// </summary>
    [TestClass]
    public class PrototypeTests
    {
        [TestMethod]
        public void Test()
        {
            var prototype = new ConcretePrototype("test id");
            var clone = prototype.Clone();
            Console.WriteLine(clone.Id);
            Assert.IsTrue(clone.Id == prototype.Id);
        }
    }

    public interface IPrototype<out T> where T : new()
    {
        T Clone();
    }

    public class ConcretePrototype : IPrototype<ConcretePrototype>
    {
        public ConcretePrototype()
        {
            Id = "Unknown";
        }

        public ConcretePrototype(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public ConcretePrototype Clone()
        {
            return (ConcretePrototype) MemberwiseClone();
        }
    }
}
