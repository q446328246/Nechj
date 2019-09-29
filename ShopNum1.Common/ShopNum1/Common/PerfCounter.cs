using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace ShopNum1.Common
{
    internal class PerfCounter
    {
        private readonly long freq;
        private long startTime;
        private long stopTime;

        public PerfCounter(bool startTimer)
        {
            if (!QueryPerformanceFrequency(out freq))
            {
                throw new Win32Exception();
            }
            if (startTimer)
            {
                Start();
            }
        }

        public double Duration
        {
            get { return (((stopTime - startTime))/((double) freq)); }
        }

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        public void Start()
        {
            Thread.Sleep(0);
            QueryPerformanceCounter(out startTime);
        }

        public void Stop()
        {
            QueryPerformanceCounter(out stopTime);
        }
    }
}