using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Visitor
{
    /// <summary>
    /// Represent an operation to be performed on the elements of an object structure. 
    /// Visitor lets you define a new operation without changing the classes of the 
    /// elements on which it operates. 
    /// </summary>
    [TestClass]
    public class VisitorTests
    {
        [TestMethod]
        public void Test()
        {
            var structure = new Structure();
            structure.Attach(new ConcreteElementA());
            structure.Attach(new ConcreteElementB());
            var visitorA = new ConcreteVisitorA();
            var visitorB = new ConcreteVisitorB();
            structure.Accept(visitorA);
            structure.Accept(visitorB);
        }
    }

    public class Structure
    {
        private readonly List<Element> _elements = new List<Element>();

        public void Attach(Element element)
        {
            _elements.Add(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (var element in _elements)
            {
                element.Accept(visitor);
            }
        }
    }

    public abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    public class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
    }

    public class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
    }

    public abstract class Visitor
    {
        public abstract void VisitConcreteElementA(ConcreteElementA element);
        public abstract void VisitConcreteElementB(ConcreteElementB element);
    }

    public class ConcreteVisitorA : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA element)
        {
            Console.WriteLine("{0} visited by {1}", element.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB element)
        {
            Console.WriteLine("{0} visited by {1}", element.GetType().Name, this.GetType().Name);
        }
    }

    public class ConcreteVisitorB : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA element)
        {
            Console.WriteLine("{0} visited by {1}", element.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteElementB element)
        {
            Console.WriteLine("{0} visited by {1}", element.GetType().Name, this.GetType().Name);
        }
    }
}
