namespace Alif.Helpers
{
    using System;
    using System.Management;

    public abstract class SerialNumber
    {

        public static string HddSerialNumber()
        {

            ManagementObjectSearcher mcol = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");

            string result = String.Empty;

            foreach (ManagementObject strt in mcol.Get())
            {

                result += strt.GetPropertyValue("SerialNumber");

            }

            return result;
        }

        public static string GpuSerialNumber()
        {

            ManagementObjectSearcher mcol = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            string result = String.Empty;

            foreach (ManagementObject strt in mcol.Get())
            {
                
                    result += strt.GetPropertyValue("SerialNumber").ToString();
                
            }

            return result;
        }

    }
}
