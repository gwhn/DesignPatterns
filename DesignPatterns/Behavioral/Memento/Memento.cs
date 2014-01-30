using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Behavioral.Memento
{
    /// <summary>
    /// Without violating encapsulation, capture and externalize an object's internal state 
    /// so that the object can be restored to this state later.
    /// </summary>
    [TestClass]
    public class MementoTests
    {
        [TestMethod]
        public void Test()
        {
            var originator = new Originator {State = "On"};
            var caretaker = new Caretaker {Memento = originator.CreateMemento()};
            originator.State = "Off";
            Console.WriteLine(originator.State);
            originator.Memento = caretaker.Memento;
            Console.WriteLine(originator.State);
        }
    }

    public class Originator
    {
        public string State { get; set; }

        public Memento CreateMemento()
        {
            return new Memento(State);
        }

        public Memento Memento
        {
            set { State = value.State; }
        }
    }

    public class Caretaker
    {
        public Memento Memento { get; set; }
    }

    public class Memento
    {
        private readonly string _state;

        public Memento(string state)
        {
            _state = state;
        }

        public string State
        {
            get { return _state; }
        }
    }
}
