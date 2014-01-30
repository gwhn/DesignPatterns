using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Structural.Flyweight
{
    /// <summary>
    /// Use sharing to support large numbers of fine-grained objects efficiently. 
    /// </summary>
    [TestClass]
    public class FlyweightTests
    {
        [TestMethod]
        public void Test()
        {
            var factory = new FlyweightFactory();
            factory["A"].Operation();
            factory["B"].Operation();
            factory["C"].Operation();
        }
    }

    public class FlyweightFactory
    {
        private readonly Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            _flyweights.Add("A", new ConcreteFlyweightA());
            _flyweights.Add("B", new ConcreteFlyweightB());
            _flyweights.Add("C", new ConcreteFlyweightC());
        }

        public Flyweight this[string key]
        {
            get { return _flyweights[key]; }
        }
    }

    public abstract class Flyweight
    {
        public abstract void Operation();
    }

    public class ConcreteFlyweightA : Flyweight
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteFlyweightA.Operation");
        }
    }

    public class ConcreteFlyweightB : Flyweight
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteFlyweightB.Operation");
        }
    }

    public class ConcreteFlyweightC : Flyweight
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteFlyweightC.Operation");
        }
    }
}
