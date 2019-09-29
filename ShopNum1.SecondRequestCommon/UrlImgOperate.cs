namespace ShopNum1.Second
{
    using System;
    using System.IO;
    using System.Net;
    using System.Web;

    public class UrlImgOperate
    {
        private string a;
        private string b;
        private byte[] c;
        private FileInfo d;

        public UrlImgOperate()
        {
            this.a = string.Empty;
            this.b = string.Empty;
        }

        public UrlImgOperate(FileInfo fileInfo)
        {
            this.a = string.Empty;
            this.b = string.Empty;
            if (!((fileInfo != null) && fileInfo.Exists))
            {
                throw new ArgumentException("FileInfo is null or not exists!");
            }
            this.d = fileInfo;
        }

        public UrlImgOperate(string url)
        {
            this.a = string.Empty;
            this.b = string.Empty;
            if (url != null)
            {
                string path = "";
                string str2 = "";
                int startIndex = 0;
                int num2 = 0;
                if (!url.Contains("http://"))
                {
                    throw new ArgumentException("url format error!");
                }
                startIndex = url.IndexOf("http://") + 7;
                startIndex = url.IndexOf("/", startIndex) + 1;
                num2 = url.LastIndexOf("/") + 1;
                path = url.Substring(startIndex, num2 - startIndex);
                str2 = url.Substring(num2);
                if (str2 != "noImage.gif")
                {
                    path = "~/ImgUpload/";
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
                    }
                    if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(path) + str2))
                    {
                        WebClient client = new WebClient();
                        try
                        {
                            if (str2 != "noImage.gif")
                            {
                                client.DownloadFile(url, HttpContext.Current.Server.MapPath(path) + str2);
                            }
                        }
                        catch
                        {
                            return;
                        }
                    }
                    FileInfo info = new FileInfo(HttpContext.Current.Server.MapPath(path) + str2);
                    if (!((info != null) && info.Exists))
                    {
                        throw new ArgumentException("FileInfo is null or not exists!");
                    }
                    this.d = info;
                }
            }
        }

        public UrlImgOperate(string fileName, byte[] content)
        {
            this.a = string.Empty;
            this.b = string.Empty;
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName");
            }
            if ((content == null) || (content.Length == 0))
            {
                throw new ArgumentNullException("content");
            }
            this.a = fileName;
            this.c = content;
        }

        public UrlImgOperate(string fileName, byte[] content, string mimeType) : this(fileName, content)
        {
            if (string.IsNullOrEmpty(mimeType))
            {
                throw new ArgumentNullException("mimeType");
            }
            this.b = mimeType;
        }

        protected string DownImage(string url)
        {
            string path = "";
            string str2 = "";
            int startIndex = 0;
            int num2 = 0;
            if (url.Contains("http://"))
            {
                startIndex = url.IndexOf("http://") + 7;
                startIndex = url.IndexOf("/", startIndex) + 1;
                num2 = url.LastIndexOf("/") + 1;
                path = url.Substring(startIndex, num2 - startIndex);
                str2 = url.Substring(num2);
                path = "~/ImgUpload/";
                string str3 = HttpContext.Current.Server.MapPath(path);
                if (!Directory.Exists(str3))
                {
                    Directory.CreateDirectory(str3);
                }
                if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(path) + str2))
                {
                    new WebClient().DownloadFile(url, HttpContext.Current.Server.MapPath(path) + str2);
                }
                return (path + str2);
            }
            return "";
        }

        public byte[] GetContent()
        {
            if (((this.c == null) && (this.d != null)) && this.d.Exists)
            {
                using (Stream stream = this.d.OpenRead())
                {
                    this.c = new byte[stream.Length];
                    stream.Read(this.c, 0, this.c.Length);
                }
            }
            return this.c;
        }

        public string GetFileName()
        {
            if (((this.a != null) && (this.d != null)) && this.d.Exists)
            {
                this.a = this.d.FullName;
            }
            return this.a;
        }

        public string GetFileSuffix(byte[] fileData)
        {
            if ((fileData != null) && (fileData.Length >= 10))
            {
                if (((fileData[0] == 0x47) && (fileData[1] == 0x49)) && (fileData[2] == 70))
                {
                    return "GIF";
                }
                if (((fileData[1] == 80) && (fileData[2] == 0x4e)) && (fileData[3] == 0x47))
                {
                    return "PNG";
                }
                if ((((fileData[6] == 0x4a) && (fileData[7] == 70)) && (fileData[8] == 0x49)) && (fileData[9] == 70))
                {
                    return "JPG";
                }
                if ((fileData[0] == 0x42) && (fileData[1] == 0x4d))
                {
                    return "BMP";
                }
            }
            return null;
        }

        public string GetMimeType()
        {
            if (this.b == null)
            {
                this.b = this.GetMimeType(this.GetContent());
            }
            return this.b;
        }

        public string GetMimeType(byte[] fileData)
        {
            switch (this.GetFileSuffix(fileData))
            {
                case "JPG":
                    return "image/jpeg";

                case "GIF":
                    return "image/gif";

                case "PNG":
                    return "image/png";

                case "BMP":
                    return "image/bmp";
            }
            return "application/octet-stream";
        }

        public string GetMimeType(string fileName)
        {
            fileName = fileName.ToLower();
            if (fileName.EndsWith(".bmp", StringComparison.CurrentCulture))
            {
                return "image/bmp";
            }
            if (fileName.EndsWith(".gif", StringComparison.CurrentCulture))
            {
                return "image/gif";
            }
            if (fileName.EndsWith(".jpg", StringComparison.CurrentCulture) || fileName.EndsWith(".jpeg", StringComparison.CurrentCulture))
            {
                return "image/jpeg";
            }
            if (fileName.EndsWith(".png", StringComparison.CurrentCulture))
            {
                return "image/png";
            }
            return "application/octet-stream";
        }

        public string GetUrlFileName(string url)
        {
            if (url == null)
            {
                return "";
            }
            string str2 = "";
            int startIndex = 0;
            int num2 = 0;
            if (url.Contains("http://"))
            {
                startIndex = url.IndexOf("http://") + 7;
                startIndex = url.IndexOf("/", startIndex) + 1;
                num2 = url.LastIndexOf("/") + 1;
                url.Substring(startIndex, num2 - startIndex);
                str2 = url.Substring(num2);
            }
            return str2;
        }
    }
}

