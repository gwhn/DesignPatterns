using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Structural.Proxy
{
    /// <summary>
    /// Provide a surrogate or placeholder for another object to control access to it.
    /// </summary>
    [TestClass]
    public class ProxyTests
    {
        [TestMethod]
        public void Test()
        {
            var proxy = new Proxy();
            proxy.Request();
        }
    }

    public interface ISubject
    {
        void Request();
    }

    public class ConcreteSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("ConcreteSubject.Request");
        }
    }

    public class Proxy : ISubject
    {
        private ISubject _subject;

        public void Request()
        {
            if (_subject == null)
            {
                _subject = new ConcreteSubject();
            }
            _subject.Request();
        }
    }
}
