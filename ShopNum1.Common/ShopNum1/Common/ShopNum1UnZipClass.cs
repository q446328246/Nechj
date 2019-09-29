using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace ShopNum1.Common
{
    public class ShopNum1UnZipClass
    {
        public static void UnZip(string FileToUpZip, string ZipedFolder, string Password)
        {
            if (File.Exists(FileToUpZip))
            {
                if (!Directory.Exists(ZipedFolder))
                {
                    Directory.CreateDirectory(ZipedFolder);
                }
                ZipInputStream stream = null;
                ZipEntry entry = null;
                FileStream stream2 = null;
                try
                {
                    stream = new ZipInputStream(File.OpenRead(FileToUpZip))
                        {
                            Password = Password
                        };
                    while ((entry = stream.GetNextEntry()) != null)
                    {
                        if (!(entry.Name != string.Empty))
                        {
                            continue;
                        }
                        string path = ZipedFolder + entry.Name;
                        if ((entry.Name.IndexOf("/") != -1) &&
                            !Directory.Exists(ZipedFolder + entry.Name.Substring(0, entry.Name.IndexOf("/"))))
                        {
                            Directory.CreateDirectory(ZipedFolder + entry.Name.Substring(0, entry.Name.IndexOf("/")));
                        }
                        path = path.Replace(@"\", "/");
                        if (path.EndsWith("/") || path.EndsWith(@"\"))
                        {
                            Directory.CreateDirectory(path);
                            continue;
                        }
                        stream2 = File.Create(path);
                        int count = 0x800;
                        var buffer = new byte[0x800];
                        goto Label_0124;
                        Label_0119:
                        stream2.Write(buffer, 0, count);
                        Label_0124:
                        count = stream.Read(buffer, 0, buffer.Length);
                        if (count > 0)
                        {
                            goto Label_0119;
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                            stream2.Dispose();
                        }
                    }
                }
                finally
                {
                    if (entry != null)
                    {
                        entry = null;
                    }
                    if (stream != null)
                    {
                        stream.Close();
                        stream.Dispose();
                    }
                    GC.Collect();
                    GC.Collect(1);
                }
            }
        }
    }
}