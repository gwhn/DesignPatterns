using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Structural.Composite
{
    /// <summary>
    /// Compose objects into tree structures to represent part-whole hierarchies. 
    /// Composite lets clients treat individual objects and compositions of objects uniformly.
    /// </summary>
    [TestClass]
    public class CompositeTests
    {
        [TestMethod]
        public void Test()
        {
            var compositeA = new Composite("CompositeA");
            compositeA.Add(new Leaf("LeafA"));
            compositeA.Add(new Leaf("LeafB"));

            var compositeB = new Composite("CompositeB");
            compositeB.Add(new Leaf("LeafC"));
            compositeB.Add(new Leaf("LeafD"));

            compositeA.Add(compositeB);

            Console.WriteLine(compositeA);
        }
    }

    public abstract class Component
    {
        protected string Name;

        protected Component(string name)
        {
            Name = name;
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);

    }

    public class Composite : Component
    {
        private readonly List<Component> _children = new List<Component>();
 
        public Composite(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            if (_children.Contains(component))
            {
                _children.Remove(component);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Name);
            foreach (var child in _children)
            {
                sb.AppendLine(child.ToString());
            }
            return sb.ToString();
        }
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }

        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
