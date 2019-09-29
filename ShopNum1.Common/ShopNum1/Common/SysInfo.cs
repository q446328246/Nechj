using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ShopNum1.Common
{
    public class SysInfo
    {
        public static int GetCpuUsage()
        {
            return CpuUsage.Create().Query();
        }

        public abstract class CpuUsage
        {
            private static CpuUsage m_CpuUsage;

            public static CpuUsage Create()
            {
                if (m_CpuUsage == null)
                {
                    if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    {
                        if (Environment.OSVersion.Platform != PlatformID.Win32Windows)
                        {
                            throw new NotSupportedException();
                        }
                        m_CpuUsage = new CpuUsage9x();
                    }
                    else
                    {
                        m_CpuUsage = new CpuUsageNt();
                    }
                }
                return m_CpuUsage;
            }

            public abstract int Query();
        }

        internal sealed class CpuUsage9x : CpuUsage
        {
            private readonly RegistryKey m_StatData;

            public CpuUsage9x()
            {
                try
                {
                    RegistryKey key = Registry.DynData.OpenSubKey(@"PerfStats\StartStat", false);
                    if (key == null)
                    {
                        throw new NotSupportedException();
                    }
                    key.GetValue(@"KERNEL\CPUUsage");
                    key.Close();
                    m_StatData = Registry.DynData.OpenSubKey(@"PerfStats\StatData", false);
                    if (m_StatData == null)
                    {
                        throw new NotSupportedException();
                    }
                }
                catch (NotSupportedException exception)
                {
                    throw exception;
                }
                catch (Exception exception2)
                {
                    throw new NotSupportedException("Error while querying the system information.", exception2);
                }
            }

            ~CpuUsage9x()
            {
                try
                {
                    m_StatData.Close();
                }
                catch
                {
                }
                try
                {
                    RegistryKey key = Registry.DynData.OpenSubKey(@"PerfStats\StopStat", false);
                    key.GetValue(@"KERNEL\CPUUsage", false);
                    key.Close();
                }
                catch
                {
                }
            }

            public override int Query()
            {
                int num;
                try
                {
                    num = (int) m_StatData.GetValue(@"KERNEL\CPUUsage");
                }
                catch (Exception exception)
                {
                    throw new NotSupportedException("Error while querying the system information.", exception);
                }
                return num;
            }
        }

        internal sealed class CpuUsageNt : CpuUsage
        {
            private const int NO_ERROR = 0;
            private const int SYSTEM_BASICINFORMATION = 0;
            private const int SYSTEM_PERFORMANCEINFORMATION = 2;
            private const int SYSTEM_TIMEINFORMATION = 3;
            private readonly double processorCount;
            private long oldIdleTime;
            private long oldSystemTime;

            public CpuUsageNt()
            {
                var lpStructure = new byte[0x20];
                var buffer2 = new byte[0x138];
                var buffer3 = new byte[0x2c];
                if (NtQuerySystemInformation(3, lpStructure, lpStructure.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                if (NtQuerySystemInformation(2, buffer2, buffer2.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                if (NtQuerySystemInformation(0, buffer3, buffer3.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                oldIdleTime = BitConverter.ToInt64(buffer2, 0);
                oldSystemTime = BitConverter.ToInt64(lpStructure, 8);
                processorCount = buffer3[40];
            }

            [DllImport("ntdll")]
            private static extern int NtQuerySystemInformation(int dwInfoType, byte[] lpStructure, int dwSize,
                                                               IntPtr returnLength);

            public override int Query()
            {
                var lpStructure = new byte[0x20];
                var buffer2 = new byte[0x138];
                if (NtQuerySystemInformation(3, lpStructure, lpStructure.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                if (NtQuerySystemInformation(2, buffer2, buffer2.Length, IntPtr.Zero) != 0)
                {
                    throw new NotSupportedException();
                }
                double num2 = BitConverter.ToInt64(buffer2, 0) - oldIdleTime;
                double num3 = BitConverter.ToInt64(lpStructure, 8) - oldSystemTime;
                if (!(num3 == 0.0))
                {
                    num2 /= num3;
                }
                num2 = (100.0 - ((num2*100.0)/processorCount)) + 0.5;
                oldIdleTime = BitConverter.ToInt64(buffer2, 0);
                oldSystemTime = BitConverter.ToInt64(lpStructure, 8);
                return (int) num2;
            }
        }
    }
}