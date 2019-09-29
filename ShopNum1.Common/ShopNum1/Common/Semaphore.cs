using System;
using System.Threading;

namespace ShopNum1.Common
{
    public class Semaphore
    {
        private readonly object _semLock;
        private int _count;

        public Semaphore() : this(1)
        {
        }

        public Semaphore(int count)
        {
            _semLock = new object();
            if (count < 0)
            {
                throw new ArgumentException("Semaphore must have a count of at least 0.", "count");
            }
            _count = count;
        }

        public void AddOne()
        {
            V();
        }

        public void P()
        {
            lock (_semLock)
            {
                while (_count <= 0)
                {
                    Monitor.Wait(_semLock, -1);
                }
                _count--;
            }
        }

        public void Reset(int count)
        {
            lock (_semLock)
            {
                _count = count;
            }
        }

        public void V()
        {
            lock (_semLock)
            {
                _count++;
                Monitor.Pulse(_semLock);
            }
        }

        public void WaitOne()
        {
            P();
        }
    }
}