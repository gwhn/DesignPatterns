using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    public class Prototype : IPrototype<Prototype>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Prototype Clone()
        {
            return (Prototype) MemberwiseClone();
        }
    }

    public interface IPrototype<out T>
    {
        T Clone();
    }

    [TestClass]
    public class PrototypeTests
    {
        [TestMethod]
        public void Clone()
        {
            var type = new Prototype();
            var copy = type.Clone();
            Assert.IsTrue(type.Id == copy.Id);
            Assert.IsTrue(type.Name == copy.Name);
        }
    }
}
