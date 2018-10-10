using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessManager
{
    class Files
    {
        public static bool CompareFilesByHash(FileInfo first, FileInfo second)
        {
            byte[] firstHash = MD5.Create().ComputeHash(first.OpenRead());
            byte[] secondHash = MD5.Create().ComputeHash(second.OpenRead());

            for (int i = 0; i < firstHash.Length; i++)
            {
                if (firstHash[i] != secondHash[i])
                    return false;
            }
            return true;
        }
        public static string GetMD5Hash(string pathToFile)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(pathToFile))
                    {
                        byte[] bytes = md5.ComputeHash(stream);
                        string MD5 = "";
                        foreach (byte b in bytes)
                        {
                            MD5 += Convert.ToString(b);
                        }
                        return MD5;
                    }
                }
            }
            catch {  }
            return "";
        }
    }
}
