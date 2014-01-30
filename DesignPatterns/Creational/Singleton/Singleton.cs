using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Creational.Singleton
{
    /// <summary>
    /// Ensure a class has only one instance and provide a global point of access to it. 
    /// </summary>
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void Test()
        {
            var instanceA = Singleton.Instance;
            var instanceB = Singleton.Instance;
            Assert.AreSame(instanceA, instanceB);
        }
    }

    public class Singleton
    {
        private static Singleton _instance;
        private static readonly object SyncRoot = new object();

        protected Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (SyncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }
    }
}
