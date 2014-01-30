using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    /// <summary>
    /// Avoid coupling the sender of a request to its receiver by giving more than one object a 
    /// chance to handle the request. 
    /// Chain the receiving objects and pass the request along the chain until an object handles it.
    /// </summary>
    [TestClass]
    public class ChainOfResponsibilityTests
    {
        [TestMethod]
        public void Test()
        {
            var handlerA = new ConcreteHandlerA();
            var handlerB = new ConcreteHandlerB();
            var handlerC = new ConcreteHandlerC();
            handlerA.Successor = handlerB;
            handlerB.Successor = handlerC;
            const string requests = "ABRACADABRA";
            foreach (var request in requests)
            {
                handlerA.Handle(request);
            }
        }
    }

    public abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void Handle(char request);
    }

    public class ConcreteHandlerA : Handler
    {
        public override void Handle(char request)
        {
            if (request == 'A')
            {
                Console.WriteLine("ConcreteHandlerA.Handle");
            }
            else if (Successor != null)
            {
                Successor.Handle(request);
            }
        }
    }

    public class ConcreteHandlerB : Handler
    {
        public override void Handle(char request)
        {
            if (request == 'B')
            {
                Console.WriteLine("ConcreteHandlerB.Handle");
            }
            else if (Successor != null)
            {
                Successor.Handle(request);
            }
        }
    }

    public class ConcreteHandlerC : Handler
    {
        public override void Handle(char request)
        {
            if (request == 'C')
            {
                Console.WriteLine("ConcreteHandlerC.Handle");
            }
            else if (Successor != null)
            {
                Successor.Handle(request);
            }
        }
    }
}
