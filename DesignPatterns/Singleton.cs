using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    // seal the class so it cannot be inherited
    public sealed class Singleton
    {
        private static Singleton _instance;
        private static readonly object SyncRoot = new Object();

        private Singleton()
        {
            // must make the ctor private
        }

        public static Singleton Instance
        {
            get
            {
                // ensure thread safe
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

    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void GetInstance()
        {
            var instance = Singleton.Instance;
            Assert.AreSame(instance, Singleton.Instance);
        }
    }
}
