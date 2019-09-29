using System;
using System.IO;
using System.Net;
using System.Web;

namespace ShopNum1.TbTopCommon
{
    public class FileItem
    {
        private readonly FileInfo fileInfo_0;
        private byte[] byte_0;
        private string string_0;
        private string string_1;

        public FileItem()
        {
            string_0 = string.Empty;
            string_1 = string.Empty;
        }

        public FileItem(FileInfo fileInfo)
        {
            string_0 = string.Empty;
            string_1 = string.Empty;
            if (!((fileInfo != null) && fileInfo.Exists))
            {
                throw new ArgumentException("FileInfo is null or not exists!");
            }
            fileInfo_0 = fileInfo;
        }

        public FileItem(string string_2)
        {
            string_0 = string.Empty;
            string_1 = string.Empty;
            if (string_2 != null)
            {
                string path = "";
                string str2 = "";
                int startIndex = 0;
                int num2 = 0;
                if (!string_2.Contains("http://"))
                {
                    throw new ArgumentException("url format error!");
                }
                startIndex = string_2.IndexOf("http://") + 7;
                startIndex = string_2.IndexOf("/", startIndex) + 1;
                num2 = string_2.LastIndexOf("/") + 1;
                path = string_2.Substring(startIndex, num2 - startIndex);
                str2 = string_2.Substring(num2);
                if (str2 != "noImage.gif")
                {
                    path = "~/ImgUpload/";
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                    }
                    if (!File.Exists(HttpContext.Current.Server.MapPath(path) + str2))
                    {
                        var client = new WebClient();
                        try
                        {
                            if (str2 != "noImage.gif")
                            {
                                client.DownloadFile(string_2, HttpContext.Current.Server.MapPath(path) + str2);
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                    var info = new FileInfo(HttpContext.Current.Server.MapPath(path) + str2);
                    if (!((info != null) && info.Exists))
                    {
                        throw new ArgumentException("FileInfo is null or not exists!");
                    }
                    fileInfo_0 = info;
                }
            }
        }

        public FileItem(string fileName, byte[] content)
        {
            string_0 = string.Empty;
            string_1 = string.Empty;
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }
            if ((content == null) || (content.Length == 0))
            {
                throw new ArgumentNullException("content");
            }
            string_0 = fileName;
            byte_0 = content;
        }

        public FileItem(string string_2, string path)
        {
            string_0 = string.Empty;
            string_1 = string.Empty;
            if (string_2 != null)
            {
                string str = "";
                int startIndex = 0;
                int num2 = 0;
                if (!string_2.Contains("http://"))
                {
                    throw new ArgumentException("url format error!");
                }
                startIndex = string_2.IndexOf("http://") + 7;
                startIndex = string_2.IndexOf("/", startIndex) + 1;
                num2 = string_2.LastIndexOf("/") + 1;
                str = string_2.Substring(num2);
                if (str != "noImage.gif")
                {
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                    }
                    if (!File.Exists(HttpContext.Current.Server.MapPath(path) + str))
                    {
                        var client = new WebClient();
                        try
                        {
                            if (str != "noImage.gif")
                            {
                                client.DownloadFile(string_2, HttpContext.Current.Server.MapPath(path) + str);
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                    }
                    var info = new FileInfo(HttpContext.Current.Server.MapPath(path) + str);
                    if (!((info != null) && info.Exists))
                    {
                        throw new ArgumentException("FileInfo is null or not exists!");
                    }
                    fileInfo_0 = info;
                }
            }
        }

        public FileItem(string fileName, byte[] content, string mimeType) : this(fileName, content)
        {
            if (string.IsNullOrEmpty(mimeType))
            {
                throw new ArgumentNullException("mimeType");
            }
            string_1 = mimeType;
        }

        public static bool DownImage(string string_2, string path)
        {
            string str = "";
            int startIndex = 0;
            int num2 = 0;
            if (string_2.Contains("http://"))
            {
                startIndex = string_2.IndexOf("http://") + 7;
                startIndex = string_2.IndexOf("/", startIndex) + 1;
                num2 = string_2.LastIndexOf("/") + 1;
                str = string_2.Substring(num2);
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                }
                if (!File.Exists(HttpContext.Current.Server.MapPath(path) + str))
                {
                    new WebClient().DownloadFile(string_2, HttpContext.Current.Server.MapPath(path) + str);
                }
                return true;
            }
            return false;
        }

        public bool DownImage(string string_2, string path, out string imgpath)
        {
            imgpath = string.Empty;
            string str = "";
            int startIndex = 0;
            int num2 = 0;
            if (string_2.Contains("http://"))
            {
                startIndex = string_2.IndexOf("http://") + 7;
                startIndex = string_2.IndexOf("/", startIndex) + 1;
                num2 = string_2.LastIndexOf("/") + 1;
                str = string_2.Substring(num2);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                }
                if (!File.Exists(path + @"\" + str))
                {
                    new WebClient().DownloadFile(string_2, path + @"\" + str);
                }
                imgpath = str;
                return true;
            }
            return false;
        }

        public byte[] GetContent()
        {
            if (((byte_0 == null) && (fileInfo_0 != null)) && fileInfo_0.Exists)
            {
                using (Stream stream = fileInfo_0.OpenRead())
                {
                    byte_0 = new byte[stream.Length];
                    stream.Read(byte_0, 0, byte_0.Length);
                }
            }
            return byte_0;
        }

        public string GetFileName()
        {
            if (((string_0 != null) && (fileInfo_0 != null)) && fileInfo_0.Exists)
            {
                string_0 = fileInfo_0.FullName;
            }
            return string_0;
        }

        public string GetMimeType()
        {
            if (string_1 == null)
            {
                string_1 = Sys.GetMimeType(GetContent());
            }
            return string_1;
        }

        public static string GetUrlFileName(string string_2)
        {
            if (string_2 == null)
            {
                return "";
            }
            string str2 = "";
            int startIndex = 0;
            int num2 = 0;
            if (string_2.Contains("http://"))
            {
                startIndex = string_2.IndexOf("http://") + 7;
                startIndex = string_2.IndexOf("/", startIndex) + 1;
                num2 = string_2.LastIndexOf("/") + 1;
                string_2.Substring(startIndex, num2 - startIndex);
                str2 = string_2.Substring(num2);
            }
            return str2;
        }
    }
}