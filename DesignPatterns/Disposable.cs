using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns
{
    public class Disposable : IDisposable
    {
        private bool _disposed;

        // Avoid using finalizable objects unless using unmanaged resources
        ~Disposable()
        {
            Dispose(false);
        }

        public void Foo()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Already disposed");
            }
            Console.WriteLine("Foo");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // do disposal here
                // avoid throwing exceptions here
            }
            
            _disposed = true;
        }
    }

    [TestClass]
    public class DisposableTest
    {
        [TestMethod]
        public void ExplicitDisposal()
        {
            var obj = new Disposable();
            obj.Foo();
            obj.Dispose();
        }

        [TestMethod]
        public void ImplicitDisposal()
        {
            using (var obj = new Disposable())
            {
                obj.Foo();
            }
        }
    }
}
