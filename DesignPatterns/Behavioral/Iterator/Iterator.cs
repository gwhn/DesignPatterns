using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Behavioral.Iterator
{
    /// <summary>
    /// Provide a way to access the elements of an aggregate object sequentially 
    /// without exposing its underlying representation.
    /// </summary>
    [TestClass]
    public class IteratorTests
    {
        [TestMethod]
        public void Test()
        {
            var aggregate = new ConcreteAggregate();
            aggregate[0] = "Item 1";
            aggregate[1] = "Item 2";
            aggregate[2] = "Item 3";
            var iterator = new ConcreteIterator(aggregate);
            Console.WriteLine(iterator.First());
            while (!iterator.IsDone)
            {
                Console.WriteLine(iterator.Next());
            }
            Console.WriteLine(iterator.Current);
            iterator.First();
            Console.WriteLine(iterator.Current);
        }
    }

    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    public class ConcreteAggregate : Aggregate
    {
        private readonly List<object> _items = new List<object>();

        public int Count
        {
            get { return _items.Count; }
        }

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }

    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone { get; }
        public abstract object Current { get; }
    }

    public class ConcreteIterator : Iterator
    {
        private readonly ConcreteAggregate _aggregate;

        private int _current = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public override object First()
        {
            _current = 0;
            return Current;
        }

        public override object Next()
        {
            var obj = default(object);
            if (!IsDone)
            {
                obj = _aggregate[++_current];
            }
            return obj;
        }

        public override bool IsDone
        {
            get { return _current >= _aggregate.Count - 1; }
        }

        public override object Current
        {
            get { return _aggregate[_current]; }
        }
    }
}
