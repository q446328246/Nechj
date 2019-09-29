using System;
using System.Collections;
using System.Threading;

namespace ShopNum1.Common
{
    public class ManagedThreadPool
    {
        private const int _maxWorkerThreads = 10;
        private static int _inUseThreads;
        private static readonly object _poolLock = new object();
        private static Queue _waitingCallbacks;
        private static Semaphore _workerThreadNeeded;
        private static ArrayList _workerThreads;

        static ManagedThreadPool()
        {
            Initialize();
        }

        public static int ActiveThreads
        {
            get { return _inUseThreads; }
        }

        public static int MaxThreads
        {
            get { return 10; }
        }

        public static int WaitingCallbacks
        {
            get
            {
                lock (_poolLock)
                {
                    return _waitingCallbacks.Count;
                }
            }
        }

        private static void Initialize()
        {
            _waitingCallbacks = new Queue();
            _workerThreads = new ArrayList();
            _inUseThreads = 0;
            _workerThreadNeeded = new Semaphore(0);
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(ProcessQueuedItems);
                _workerThreads.Add(thread);
                thread.Name = "ManagedPoolThread #" + i.ToString();
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private static void ProcessQueuedItems()
        {
            while (true)
            {
                _workerThreadNeeded.WaitOne();
                WaitingCallback callback = null;
                lock (_poolLock)
                {
                    if (_waitingCallbacks.Count > 0)
                    {
                        try
                        {
                            callback = (WaitingCallback) _waitingCallbacks.Dequeue();
                        }
                        catch
                        {
                        }
                    }
                }
                if (callback != null)
                {
                    try
                    {
                        Interlocked.Increment(ref _inUseThreads);
                        callback.Callback(callback.State);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        Interlocked.Decrement(ref _inUseThreads);
                    }
                }
            }
        }

        public static void QueueUserWorkItem(WaitCallback callback)
        {
            QueueUserWorkItem(callback, null);
        }

        public static void QueueUserWorkItem(WaitCallback callback, object state)
        {
            var callback2 = new WaitingCallback(callback, state);
            lock (_poolLock)
            {
                _waitingCallbacks.Enqueue(callback2);
            }
            _workerThreadNeeded.AddOne();
        }

        public static void Reset()
        {
            lock (_poolLock)
            {
                try
                {
                    foreach (object obj3 in _waitingCallbacks)
                    {
                        var callback = (WaitingCallback) obj3;
                        if (callback.State is IDisposable)
                        {
                            ((IDisposable) callback.State).Dispose();
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    foreach (Thread thread in _workerThreads)
                    {
                        if (thread != null)
                        {
                            thread.Abort("reset");
                        }
                    }
                }
                catch
                {
                }
                Initialize();
            }
        }

        private class WaitingCallback
        {
            private readonly WaitCallback _callback;
            private readonly object _state;

            public WaitingCallback(WaitCallback callback, object state)
            {
                _callback = callback;
                _state = state;
            }

            public WaitCallback Callback
            {
                get { return _callback; }
            }

            public object State
            {
                get { return _state; }
            }
        }
    }
}