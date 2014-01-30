using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Structural.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Behavioral.Observer
{
    /// <summary>
    /// Define a one-to-many dependency between objects so that when one object changes state, 
    /// all its dependents are notified and updated automatically.
    /// </summary>
    [TestClass]
    public class ObserverTests
    {
        [TestMethod]
        public void Test()
        {
            var subject = new ConcreteSubject();
            subject.Attach(new ConcreteObserver(subject, "x"));
            subject.Attach(new ConcreteObserver(subject, "y"));
            subject.Attach(new ConcreteObserver(subject, "z"));
            subject.State = "new state";
            subject.Notify();
        }
    }

    public abstract class Subject
    {
        private readonly List<Observer> _observers = new List<Observer>();
 
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    public class ConcreteSubject : Subject
    {
        public string State { get; set; }
    }

    public abstract class Observer
    {
        public abstract void Update();
    }

    public class ConcreteObserver : Observer
    {
        private readonly string _name;
        private string _observerState;

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            Subject = subject;
            _name = name;
        }

        public ConcreteSubject Subject { get; set; }

        public override void Update()
        {
            _observerState = Subject.State;
            Console.WriteLine("Observer {0} new state is {1}", _name, _observerState);
        }
    }
}
