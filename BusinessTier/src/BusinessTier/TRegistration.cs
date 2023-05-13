namespace BusinessTier
{
    using System;
    using System.Management;
    using System.Security.Cryptography;
    using System.Text;

    public class TRegistration
    {
        public static string Encryp(string strKey, string strID)
        {
            string str = "";
            MD5 md = new MD5CryptoServiceProvider();
            byte[] buffer2 = md.ComputeHash(Encoding.Default.GetBytes(strKey));
            for (int i = 0; i < buffer2.Length; i++)
            {
                str = str + $"{buffer2[i]:X2}";
            }
            string str2 = str.ToLower();
            string s = $"{str2.Substring(4, 5)}{strID}{str2.Substring(0x13, 5)}{strKey}";
            buffer2 = md.ComputeHash(Encoding.Default.GetBytes(s));
            str = "";
            for (int j = 0; j < buffer2.Length; j++)
            {
                str = str + $"{buffer2[j]:X2}";
            }
            return str.ToLower();
        }

        public static string GetCupID()
        {
            try
            {
                string str2 = null;
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementClass("Win32_Processor").GetInstances().GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        str2 = ((ManagementObject) enumerator.Current).Properties["ProcessorId"].Value.ToString();
                    }
                }
                return str2;
            }
            catch
            {
                return "";
            }
        }

        public static string GetHardDiskID()
        {
            try
            {
                string str2 = null;
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementClass("Win32_DiskDrive").GetInstances().GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        str2 = ((ManagementObject) enumerator.Current).Properties["Model"].Value.ToString();
                    }
                }
                return str2;
            }
            catch
            {
                return "";
            }
        }

        public static string GetNetCardMacAddress()
        {
            try
            {
                string str2 = null;
                foreach (ManagementObject obj2 in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    if ((bool) obj2["IPEnabled"])
                    {
                        str2 = obj2["MacAddress"].ToString();
                    }
                    obj2.Dispose();
                }
                return str2.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string GetUserID()
        {
            string netCardMacAddress = GetNetCardMacAddress();
            return Encryp(GetCupID(), GetHardDiskID().Trim() + netCardMacAddress.Trim());
        }
    }
}

