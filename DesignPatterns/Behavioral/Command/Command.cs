using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Behavioral.Command
{
    /// <summary>
    /// Encapsulate a request as an object, thereby letting you parameterize clients with 
    /// different requests, queue or log requests, and support undoable operations.
    /// </summary>
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void Test()
        {
            var receiver = new Receiver();
            var command = new ConcreteCommand(receiver);
            var invoker = new Invoker {Command = command};
            invoker.ExecuteCommand();
        }
    }

    public class Receiver
    {
        public void Operation()
        {
            Console.WriteLine("Receiver.Operation");
        }
    }

    public abstract class Command
    {
        protected Receiver Receiver;

        protected Command(Receiver receiver)
        {
            Receiver = receiver;
        }

        public abstract void Execute();
    }

    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            Receiver.Operation();
        }
    }

    public class Invoker
    {
        private Command _command;

        public Command Command
        {
            set { _command = value; }
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}
