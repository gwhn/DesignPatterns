using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Behavioral.Mediator
{
    /// <summary>
    /// Define an object that encapsulates how a set of objects interact. 
    /// Mediator promotes loose coupling by keeping objects from referring to each other explicitly, 
    /// and it lets you vary their interaction independently. 
    /// </summary>
    [TestClass]
    public class MediatorTests
    {
        [TestMethod]
        public void Test()
        {
            var mediator = new ConcreteMediator();
            var collaboratorA = new ConcreteCollaboratorA(mediator);
            var collaboratorB = new ConcreteCollaboratorB(mediator);
            mediator.CollaboratorA = collaboratorA;
            mediator.CollaboratorB = collaboratorB;
            collaboratorA.Send("Test request");
            collaboratorB.Send("Test response");
        }
    }

    public abstract class Mediator
    {
        public abstract void Send(string message, Collaborator collaborator);
    }

    public class ConcreteMediator : Mediator
    {
        private ConcreteCollaboratorA _collaboratorA;
        private ConcreteCollaboratorB _collaboratorB;

        public ConcreteCollaboratorA CollaboratorA
        {
            set { _collaboratorA = value; }
        }

        public ConcreteCollaboratorB CollaboratorB
        {
            set { _collaboratorB = value; }
        }

        public override void Send(string message, Collaborator collaborator)
        {
            if (collaborator == _collaboratorA)
            {
                _collaboratorB.Notify(message);
            }
            else
            {
                _collaboratorA.Notify(message);
            }
        }
    }

    public abstract class Collaborator
    {
        protected Mediator Mediator;

        protected Collaborator(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    public class ConcreteCollaboratorA : Collaborator
    {
        public ConcreteCollaboratorA(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine("CollaboratorA sent message:" + message);
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("CollaboratorA received message:" + message);
        }
    }

    public class ConcreteCollaboratorB : Collaborator
    {
        public ConcreteCollaboratorB(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            Console.WriteLine("CollaboratorB sent message:" + message);
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("CollaboratorB received message:" + message);
        }
    }
}
