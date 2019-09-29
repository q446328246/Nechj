using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;

namespace ShopNum1.Common
{
    public class ShopNum1Zip
    {
        public static bool Zip(string FileToZip, string ZipedFile, string Password)
        {
            if (Directory.Exists(FileToZip))
            {
                return ZipFileDictory(FileToZip, ZipedFile, Password);
            }
            return (File.Exists(FileToZip) && ZipFile(FileToZip, ZipedFile, Password));
        }

        private static bool ZipFile(string FileToZip, string ZipedFile, string Password)
        {
            if (!File.Exists(FileToZip))
            {
                throw new FileNotFoundException("指定要压缩的文件: " + FileToZip + " 不存在!");
            }
            FileStream baseOutputStream = null;
            ZipOutputStream stream2 = null;
            ZipEntry entry = null;
            bool flag = true;
            try
            {
                baseOutputStream = File.OpenRead(FileToZip);
                var buffer = new byte[baseOutputStream.Length];
                baseOutputStream.Read(buffer, 0, buffer.Length);
                baseOutputStream.Close();
                baseOutputStream = File.Create(ZipedFile);
                stream2 = new ZipOutputStream(baseOutputStream)
                    {
                        Password = Password
                    };
                entry = new ZipEntry(Path.GetFileName(FileToZip));
                stream2.PutNextEntry(entry);
                stream2.SetLevel(6);
                stream2.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                flag = false;
            }
            finally
            {
                if (entry != null)
                {
                    entry = null;
                }
                if (stream2 != null)
                {
                    stream2.Finish();
                    stream2.Close();
                }
                if (baseOutputStream != null)
                {
                    baseOutputStream.Close();
                    baseOutputStream = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
            return flag;
        }

        private static bool ZipFileDictory(string FolderToZip, ZipOutputStream s, string ParentFolderName)
        {
            bool flag = true;
            ZipEntry entry = null;
            FileStream stream = null;
            var crc = new Crc32();
            try
            {
                entry = new ZipEntry(Path.Combine(ParentFolderName, Path.GetFileName(FolderToZip) + "/"));
                s.PutNextEntry(entry);
                s.Flush();
                foreach (string str in Directory.GetFiles(FolderToZip))
                {
                    stream = File.OpenRead(str);
                    var buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    entry =
                        new ZipEntry(Path.Combine(ParentFolderName,
                                                  Path.GetFileName(FolderToZip) + "/" + Path.GetFileName(str)))
                            {
                                DateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                Size = stream.Length
                            };
                    stream.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    s.PutNextEntry(entry);
                    s.Write(buffer, 0, buffer.Length);
                }
            }
            catch
            {
                flag = false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
                if (entry != null)
                {
                    entry = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
            foreach (string str2 in Directory.GetDirectories(FolderToZip))
            {
                if (!ZipFileDictory(str2, s, Path.Combine(ParentFolderName, Path.GetFileName(FolderToZip))))
                {
                    return false;
                }
            }
            return flag;
        }

        public static bool ZipFileDictory(string FolderToZip, string ZipedFile, string Password)
        {
            if (!Directory.Exists(FolderToZip))
            {
                return false;
            }
            var s = new ZipOutputStream(File.Create(ZipedFile));
            s.SetLevel(6);
            s.Password = Password;
            bool flag2 = ZipFileDictory(FolderToZip, s, "");
            s.Finish();
            s.Close();
            return flag2;
        }
    }
}