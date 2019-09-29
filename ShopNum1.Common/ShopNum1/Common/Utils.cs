using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Xml;
using Microsoft.VisualBasic;

namespace ShopNum1.Common
{
    public class Utils
    {
        public const string ASSEMBLY_VERSION = "3.6.601";
        public const string ASSEMBLY_YEAR = "2011";
        public static readonly VersionInfo AssemblyFileVersion = new VersionInfo();

        private static readonly string[] browerNames = new[]
            {"MSIE", "Firefox", "Opera", "Netscape", "Safari", "Lynx", "Konqueror", "Mozilla"};

        private static readonly Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
        public static Regex RegexFont = new Regex("<font color=\".*?\">([\\s\\S]+?)</font>", GetRegexCompiledOptions());

        private static readonly string TemplateCookieName = string.Format("dnttemplateid_{0}_{1}_{2}",
                                                                          AssemblyFileVersion.FileMajorPart,
                                                                          AssemblyFileVersion.FileMinorPart,
                                                                          AssemblyFileVersion.FileBuildPart);


        public static class UnixTime
        {
            static DateTime unixEpoch = new DateTime(1970, 1, 1);
            public static UInt32 Now { get { return GetFromDateTime(DateTime.UtcNow); } }
            public static UInt32 GetFromDateTime(DateTime d) { return (UInt32)(d - unixEpoch).TotalSeconds; }
            public static DateTime ConvertToDateTime(UInt32 unixtime) { return unixEpoch.AddSeconds(unixtime); }
        }

        public static string[] Monthes
        {
            get
            {
                return new[]
                    {
                        "January", "February", "March", "April", "May", "June", "July", "August", "September", "October"
                        ,
                        "November", "December"
                    };
            }
        }

        public static string AdDeTime(int times)
        {
            return DateTime.Now.AddMinutes(times).ToString();
        }

        public static bool BackupFile(string sourceFileName, string destFileName)
        {
            return BackupFile(sourceFileName, destFileName, true);
        }

        public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
        {
            bool flag;
            if (!File.Exists(sourceFileName))
            {
                throw new FileNotFoundException(sourceFileName + "文件不存在！");
            }
            if (!(overwrite || !File.Exists(destFileName)))
            {
                return false;
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public static bool CheckColorValue(string color)
        {
            if (StrIsNullOrEmpty(color))
            {
                return false;
            }
            color = color.Trim().Trim(new[] {'#'});
            if ((color.Length != 3) && (color.Length != 6))
            {
                return false;
            }
            return !Regex.IsMatch(color, "[^0-9a-f]", RegexOptions.IgnoreCase);
        }

        public static string ChkSQL(string str)
        {
            return ((str == null) ? "" : str.Replace("'", "''"));
        }

        public static string CleanInput(string strIn)
        {
            return Regex.Replace(strIn.Trim(), @"[^\w\.@-]", "");
        }

        public static string ClearBR(string str)
        {
            Match match = null;
            for (match = RegexBr.Match(str); match.Success; match = match.NextMatch())
            {
                str = str.Replace(match.Groups[0].ToString(), "");
            }
            return str;
        }

        public static string ClearLastChar(string str)
        {
            return ((str == "") ? "" : str.Substring(0, str.Length - 1));
        }

        public static string ClearUBB(string sDetail)
        {
            return Regex.Replace(sDetail, @"\[[^\]]*?\]", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string ConvertSimpleFileName(string fullname, string repstring, int leftnum, int rightnum,
                                                   int charnum)
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string fileExtName = GetFileExtName(fullname);
            if (!StrIsNullOrEmpty(fileExtName))
            {
                int num = 0;
                int length = 0;
                length = fullname.LastIndexOf('.');
                str4 = fullname.Substring(0, length);
                num = str4.Length;
                if (length > charnum)
                {
                    str2 = str4.Substring(0, leftnum);
                    str3 = str4.Substring(num - rightnum, rightnum);
                    if ((repstring == "") || (repstring == null))
                    {
                        str = str2 + str3 + "." + fileExtName;
                    }
                    else
                    {
                        str = str2 + repstring + str3 + "." + fileExtName;
                    }
                    return str;
                }
            }
            return fullname;
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            var time = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0);
            TimeSpan span = (date - time);
            return Math.Floor(span.TotalSeconds);
        }

        public static bool CreateDir(string name)
        {
            return MakeSureDirectoryPathExists(name);
        }

        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }

        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length *= -1;
                    if ((startIndex - length) < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex -= length;
                    }
                }
                if (startIndex > str.Length)
                {
                    return "";
                }
            }
            else
            {
                if (length < 0)
                {
                    return "";
                }
                if ((length + startIndex) <= 0)
                {
                    return "";
                }
                length += startIndex;
                startIndex = 0;
            }
            if ((str.Length - startIndex) < length)
            {
                length = str.Length - startIndex;
            }
            return str.Substring(startIndex, length);
        }

        public static StringBuilder DataTableToJson(DataTable dt, bool dt_dispose)
        {
            var builder = new StringBuilder();
            builder.Append("[\r\n");
            var strArray = new string[dt.Columns.Count];
            int index = 0;
            string format = "{{";
            string str2 = "";
            foreach (DataColumn column in dt.Columns)
            {
                object obj2;
                strArray[index] = column.Caption.ToLower().Trim();
                format = format + "'" + column.Caption.ToLower().Trim() + "':";
                str2 = column.DataType.ToString().Trim().ToLower();
                if ((((str2.IndexOf("int") > 0) || (str2.IndexOf("deci") > 0)) ||
                     ((str2.IndexOf("floa") > 0) || (str2.IndexOf("doub") > 0))) || (str2.IndexOf("bool") > 0))
                {
                    obj2 = format;
                    format = string.Concat(new[] {obj2, "{", index, "}"});
                }
                else
                {
                    obj2 = format;
                    format = string.Concat(new[] {obj2, "'{", index, "}'"});
                }
                format = format + ",";
                index++;
            }
            if (format.EndsWith(","))
            {
                format = format.Substring(0, format.Length - 1);
            }
            format = format + "}},";
            index = 0;
            var args = new object[strArray.Length];
            foreach (DataRow row in dt.Rows)
            {
                string[] strArray2 = strArray;
                for (int i = 0; i < strArray2.Length; i++)
                {
                    args[index] = row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'");
                    string str3 = args[index].ToString();
                    if (str3 != null)
                    {
                        if (!(str3 == "True"))
                        {
                            if (str3 == "False")
                            {
                                args[index] = "false";
                            }
                        }
                        else
                        {
                            args[index] = "true";
                        }
                    }
                    index++;
                }
                index = 0;
                builder.Append(string.Format(format, args));
            }
            if (builder.ToString().EndsWith(","))
            {
                builder.Remove(builder.Length - 1, 1);
            }
            if (dt_dispose)
            {
                dt.Dispose();
            }
            return builder.Append("\r\n];");
        }

        public static StringBuilder DataTableToJSON(DataTable dt)
        {
            return DataTableToJson(dt, true);
        }

        public static string[] DistinctStringArray(string[] strArray)
        {
            return DistinctStringArray(strArray, 0);
        }

        public static string[] DistinctStringArray(string[] strArray, int maxElementLength)
        {
            var hashtable = new Hashtable();
            foreach (string str in strArray)
            {
                string str2 = str;
                if ((maxElementLength > 0) && (str2.Length > maxElementLength))
                {
                    str2 = str2.Substring(0, maxElementLength);
                }
                hashtable[str2.Trim()] = str;
            }
            var array = new string[hashtable.Count];
            hashtable.Keys.CopyTo(array, 0);
            return array;
        }

        public static string EncodeHtml(string strHtml)
        {
            if (strHtml != "")
            {
                strHtml = strHtml.Replace(",", "&def");
                strHtml = strHtml.Replace("'", "&dot");
                strHtml = strHtml.Replace(";", "&dec");
                return strHtml;
            }
            return "";
        }

        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        public static string[] FindNoUTF8File(string Path)
        {
            var builder = new StringBuilder();
            FileInfo[] files = new DirectoryInfo(Path).GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension.ToLower().Equals(".htm"))
                {
                    var sbInputStream = new FileStream(files[i].FullName, FileMode.Open, FileAccess.Read);
                    bool flag = IsUTF8(sbInputStream);
                    sbInputStream.Close();
                    if (!flag)
                    {
                        builder.Append(files[i].FullName);
                        builder.Append("\r\n");
                    }
                }
            }
            return SplitString(builder.ToString(), "\r\n");
        }

        public static string FormatBytesStr(int bytes)
        {
            double num;
            if (bytes > 0x40000000)
            {
                num = bytes/0x40000000;
                return (num.ToString("0") + "G");
            }
            if (bytes > 0x100000)
            {
                num = bytes/0x100000;
                return (num.ToString("0") + "M");
            }
            if (bytes > 0x400)
            {
                num = bytes/0x400;
                return (num.ToString("0") + "K");
            }
            return (bytes.ToString() + "Bytes");
        }

        public static string FormatDate(int date)
        {
            return FormatDate(date, false);
        }

        public static string FormatDate(int date, bool chnType)
        {
            string str = date.ToString();
            if ((date <= 0) || (str.Length != 8))
            {
                return str;
            }
            if (chnType)
            {
                return (str.Substring(0, 4) + "年" + str.Substring(4, 2) + "月" + str.Substring(6) + "日");
            }
            return (str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6));
        }

        public static string GetAjaxPageNumbers(int curPage, int countPage, string callback, int extendPage)
        {
            string str = "page";
            int num = 1;
            int num2 = 1;
            string str2 = "<a href=\"###\" onclick=\"" + string.Format(callback, "&" + str + "=1");
            string str3 = "<a href=\"###\" onclick=\"" +
                          string.Format(callback, string.Concat(new object[] {"&", str, "=", countPage}));
            str2 = str2 + "\">&laquo;</a>";
            str3 = str3 + "\">&raquo;</a>";
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage > extendPage)
            {
                if ((curPage - (extendPage/2)) > 0)
                {
                    if ((curPage + (extendPage/2)) < countPage)
                    {
                        num = curPage - (extendPage/2);
                        num2 = (num + extendPage) - 1;
                    }
                    else
                    {
                        num2 = countPage;
                        num = (num2 - extendPage) + 1;
                        str3 = "";
                    }
                }
                else
                {
                    num2 = extendPage;
                    str2 = "";
                }
            }
            else
            {
                num = 1;
                num2 = countPage;
                str2 = "";
                str3 = "";
            }
            var builder = new StringBuilder("");
            builder.Append(str2);
            for (int i = num; i <= num2; i++)
            {
                if (i == curPage)
                {
                    builder.Append("<span>");
                    builder.Append(i);
                    builder.Append("</span>");
                }
                else
                {
                    builder.Append("<a href=\"###\" onclick=\"");
                    builder.Append(string.Format(callback, str + "=" + i));
                    builder.Append("\">");
                    builder.Append(i);
                    builder.Append("</a>");
                }
            }
            builder.Append(str3);
            return builder.ToString();
        }

        public static string GetAssemblyCopyright()
        {
            return AssemblyFileVersion.LegalCopyright;
        }

        public static string GetAssemblyProductName()
        {
            return AssemblyFileVersion.ProductName;
        }

        public static string GetAssemblyVersion()
        {
            return string.Format("{0}.{1}.{2}", AssemblyFileVersion.FileMajorPart, AssemblyFileVersion.FileMinorPart,
                                 AssemblyFileVersion.FileBuildPart);
        }

        public static string GetClientBrower()
        {
            string str = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            if (!string.IsNullOrEmpty(str))
            {
                foreach (string str2 in browerNames)
                {
                    if (str.Contains(str2))
                    {
                        return str2;
                    }
                }
            }
            return "Other";
        }

        public static string GetClientOS()
        {
            string str = string.Empty;
            string input = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            if (input == null)
            {
                return "Other";
            }
            if (input.IndexOf("Win") > -1)
            {
                str = "Windows";
            }
            else
            {
                if (input.IndexOf("Mac") > -1)
                {
                    return "Mac";
                }
                if (input.IndexOf("Linux") > -1)
                {
                    return "Linux";
                }
                if (input.IndexOf("FreeBSD") > -1)
                {
                    return "FreeBSD";
                }
                if (input.IndexOf("SunOS") > -1)
                {
                    return "SunOS";
                }
                if (input.IndexOf("OS/2") > -1)
                {
                    return "OS/2";
                }
                if (input.IndexOf("AIX") > -1)
                {
                    return "AIX";
                }
                if (Regex.IsMatch(input, "(Bot|Crawl|Spider)"))
                {
                    str = "Spiders";
                }
                else
                {
                    str = "Other";
                }
            }
            return str;
        }

        public static string GetCookie(string strName)
        {
            if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null))
            {
                return HttpContext.Current.Request.Cookies[strName].Value;
            }
            return "";
        }

        public static string GetCookie(string strName, string key)
        {
            if (((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null)) &&
                (HttpContext.Current.Request.Cookies[strName][key] != null))
            {
                return HttpContext.Current.Request.Cookies[strName][key];
            }
            return "";
        }

        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string GetDate(string datetimestr, string replacestr)
        {
            if (datetimestr == null)
            {
                return replacestr;
            }
            if (datetimestr.Equals(""))
            {
                return replacestr;
            }
            try
            {
                datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
            }
            catch
            {
                return replacestr;
            }
            return datetimestr;
        }

        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetDateTime(int relativeday)
        {
            return DateTime.Now.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        public static string GetEmailHostName(string strEmail)
        {
            if (strEmail.IndexOf("@") < 0)
            {
                return "";
            }
            return strEmail.Substring(strEmail.LastIndexOf("@")).ToLower();
        }

        public static T GetEnum<T>(string value, T defValue)
        {
            try
            {
                return (T) Enum.Parse(typeof (T), value, true);
            }
            catch (ArgumentException)
            {
                return defValue;
            }
        }

        public static string GetFileExtName(string fileName)
        {
            if (StrIsNullOrEmpty(fileName) || (fileName.IndexOf('.') <= 0))
            {
                return "";
            }
            fileName = fileName.ToLower().Trim();
            return fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
        }

        public static string GetFilename(string url)
        {
            if (url == null)
            {
                return "";
            }
            string[] strArray = url.Split(new[] {'/'});
            return strArray[strArray.Length - 1].Split(new[] {'?'})[0];
        }

        public static string GetHttpWebResponse(string url)
        {
            return GetHttpWebResponse(url, string.Empty);
        }

        public static string GetHttpWebResponse(string url, string postData)
        {
            string str;
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Timeout = 0x4e20;
            HttpWebResponse response = null;
            try
            {
                var writer = new StreamWriter(request.GetRequestStream());
                writer.Write(postData);
                if (writer != null)
                {
                    writer.Close();
                }
                response = (HttpWebResponse) request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    str = reader.ReadToEnd();
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return str;
        }

        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }

        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else if (strSearch == stringArray[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            strPath = strPath.Replace("/", @"\");
            if (strPath.StartsWith(@"\"))
            {
                strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart(new[] {'\\'});
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }

        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage)
        {
            return GetPageNumbers(curPage, countPage, url, extendPage, "page");
        }

        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage, string pagetag)
        {
            return GetPageNumbers(curPage, countPage, url, extendPage, pagetag, null);
        }

        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage, string pagetag,
                                            string anchor)
        {
            if (pagetag == "")
            {
                pagetag = "page";
            }
            int num = 1;
            int num2 = 1;
            if (url.IndexOf("?") > 0)
            {
                url = url + "&";
            }
            else
            {
                url = url + "?";
            }
            string str = "<a href=\"" + url + "&" + pagetag + "=1";
            string str2 = string.Concat(new object[] {"<a href=\"", url, "&", pagetag, "=", countPage});
            if (anchor != null)
            {
                str = str + anchor;
                str2 = str2 + anchor;
            }
            str = str + "\">&laquo;</a>";
            str2 = str2 + "\">&raquo;</a>";
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage > extendPage)
            {
                if ((curPage - (extendPage/2)) > 0)
                {
                    if ((curPage + (extendPage/2)) < countPage)
                    {
                        num = curPage - (extendPage/2);
                        num2 = (num + extendPage) - 1;
                    }
                    else
                    {
                        num2 = countPage;
                        num = (num2 - extendPage) + 1;
                        str2 = "";
                    }
                }
                else
                {
                    num2 = extendPage;
                    str = "";
                }
            }
            else
            {
                num = 1;
                num2 = countPage;
                str = "";
                str2 = "";
            }
            var builder = new StringBuilder("");
            builder.Append(str);
            for (int i = num; i <= num2; i++)
            {
                if (i == curPage)
                {
                    builder.Append("<span>");
                    builder.Append(i);
                    builder.Append("</span>");
                }
                else
                {
                    builder.Append("<a href=\"");
                    builder.Append(url);
                    builder.Append(pagetag);
                    builder.Append("=");
                    builder.Append(i);
                    if (anchor != null)
                    {
                        builder.Append(anchor);
                    }
                    builder.Append("\">");
                    builder.Append(i);
                    builder.Append("</a>");
                }
            }
            builder.Append(str2);
            return builder.ToString();
        }

        public static string GetRealIP()
        {
            return ShopNum1Request.GetIP();
        }

        public static RegexOptions GetRegexCompiledOptions()
        {
            return RegexOptions.None;
        }

        public static string GetRootUrl(string forumPath)
        {
            int port = HttpContext.Current.Request.Url.Port;
            return string.Format("{0}://{1}{2}{3}",
                                 new object[]
                                     {
                                         HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host,
                                         ((port == 80) || (port == 0)) ? "" : (":" + port), forumPath
                                     });
        }

        public static string GetSourceTextByUrl(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Timeout = 0x4e20;
                var reader = new StreamReader(request.GetResponse().GetResponseStream());
                return reader.ReadToEnd();
            }
            catch
            {
                return "";
            }
        }

        public static string GetSpacesString(int spacesCount)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < spacesCount; i++)
            {
                builder.Append(" &nbsp;&nbsp;");
            }
            return builder.ToString();
        }

        public static string GetStandardDate(string fDate)
        {
            return GetStandardDateTime(fDate, "yyyy-MM-dd");
        }

        public static string GetStandardDateTime(string fDateTime)
        {
            return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }

        public static string GetStandardDateTime(string fDateTime, string formatStr)
        {
            if (fDateTime == "0000-0-0 0:00:00")
            {
                return fDateTime;
            }
            var result = new DateTime(0x76c, 1, 1, 0, 0, 0, 0);
            if (DateTime.TryParse(fDateTime, out result))
            {
                return result.ToString(formatStr);
            }
            return "N/A";
        }

        public static string GetStaticPageNumbers(int curPage, int countPage, string url, string expname, int extendPage)
        {
            return GetStaticPageNumbers(curPage, countPage, url, expname, extendPage, 0);
        }

        public static string GetStaticPageNumbers(int curPage, int countPage, string url, string expname, int extendPage,
                                                  int forumrewrite)
        {
            int num = 1;
            int num2 = 1;
            string str = "<a href=\"" + url + "-1" + expname + "\">&laquo;</a>";
            string str2 = string.Concat(new object[] {"<a href=\"", url, "-", countPage, expname, "\">&raquo;</a>"});
            if (forumrewrite == 1)
            {
                str = "<a href=\"" + url + "/1/list" + expname + "\">&laquo;</a>";
                str2 =
                    string.Concat(new object[] {"<a href=\"", url, "/", countPage, "/list", expname, "\">&raquo;</a>"});
            }
            if (forumrewrite == 2)
            {
                str = "<a href=\"" + url + "/\">&laquo;</a>";
                str2 = string.Concat(new object[] {"<a href=\"", url, "/", countPage, "/\">&raquo;</a>"});
            }
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage > extendPage)
            {
                if ((curPage - (extendPage/2)) > 0)
                {
                    if ((curPage + (extendPage/2)) < countPage)
                    {
                        num = curPage - (extendPage/2);
                        num2 = (num + extendPage) - 1;
                    }
                    else
                    {
                        num2 = countPage;
                        num = (num2 - extendPage) + 1;
                        str2 = "";
                    }
                }
                else
                {
                    num2 = extendPage;
                    str = "";
                }
            }
            else
            {
                num = 1;
                num2 = countPage;
                str = "";
                str2 = "";
            }
            var builder = new StringBuilder("");
            builder.Append(str);
            for (int i = num; i <= num2; i++)
            {
                if (i == curPage)
                {
                    builder.Append("<span>");
                    builder.Append(i);
                    builder.Append("</span>");
                }
                else
                {
                    builder.Append("<a href=\"");
                    if (forumrewrite == 1)
                    {
                        builder.Append(url);
                        if (i != 1)
                        {
                            builder.Append("/");
                            builder.Append(i);
                        }
                        builder.Append("/list");
                        builder.Append(expname);
                    }
                    else if (forumrewrite == 2)
                    {
                        builder.Append(url);
                        builder.Append("/");
                        if (i != 1)
                        {
                            builder.Append(i);
                            builder.Append("/");
                        }
                    }
                    else
                    {
                        builder.Append(url);
                        if (i != 1)
                        {
                            builder.Append("-");
                            builder.Append(i);
                        }
                        builder.Append(expname);
                    }
                    builder.Append("\">");
                    builder.Append(i);
                    builder.Append("</a>");
                }
            }
            builder.Append(str2);
            return builder.ToString();
        }

        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string str = p_SrcString;
            byte[] bytes = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char ch in Encoding.UTF8.GetChars(bytes))
            {
                if (!(((ch <= 'ࠀ') || (ch >= '一')) ? ((ch <= 0xac00) || (ch >= 0xd7a3)) : false))
                {
                    if (p_StartIndex >= p_SrcString.Length)
                    {
                        return "";
                    }
                    return p_SrcString.Substring(p_StartIndex,
                                                 ((p_Length + p_StartIndex) > p_SrcString.Length)
                                                     ? (p_SrcString.Length - p_StartIndex)
                                                     : p_Length);
                }
            }
            if (p_Length < 0)
            {
                return str;
            }
            byte[] sourceArray = Encoding.Default.GetBytes(p_SrcString);
            if (sourceArray.Length <= p_StartIndex)
            {
                return str;
            }
            int length = sourceArray.Length;
            if (sourceArray.Length > (p_StartIndex + p_Length))
            {
                length = p_Length + p_StartIndex;
            }
            else
            {
                p_Length = sourceArray.Length - p_StartIndex;
                p_TailString = "";
            }
            int num3 = p_Length;
            var numArray = new int[p_Length];
            byte[] destinationArray = null;
            int num4 = 0;
            for (int i = p_StartIndex; i < length; i++)
            {
                if (sourceArray[i] > 0x7f)
                {
                    num4++;
                    if (num4 == 3)
                    {
                        num4 = 1;
                    }
                }
                else
                {
                    num4 = 0;
                }
                numArray[i] = num4;
            }
            if ((sourceArray[length - 1] > 0x7f) && (numArray[p_Length - 1] == 1))
            {
                num3 = p_Length + 1;
            }
            destinationArray = new byte[num3];
            Array.Copy(sourceArray, p_StartIndex, destinationArray, 0, num3);
            return (Encoding.Default.GetString(destinationArray) + p_TailString);
        }

        public static string GetTemplateCookieName()
        {
            return TemplateCookieName;
        }

        public static string GetTextFromHTML(string HTML)
        {
            var regex = new Regex("</?(?!br|/?p|img)[^>]*>", RegexOptions.IgnoreCase);
            return regex.Replace(HTML, "");
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetTrueForumPath()
        {
            string path = HttpContext.Current.Request.Path;
            if (path.LastIndexOf("/") != path.IndexOf("/"))
            {
                return path.Substring(path.IndexOf("/"), path.LastIndexOf("/") + 1);
            }
            return "/";
        }

        public static string GetUnicodeSubString(string str, int len, string p_TailString)
        {
            str = str.TrimEnd(new char[0]);
            string str2 = string.Empty;
            int byteCount = Encoding.Default.GetByteCount(str);
            int length = str.Length;
            int num3 = 0;
            int num4 = 0;
            if (byteCount <= len)
            {
                return str;
            }
            for (int i = 0; i < length; i++)
            {
                if (Convert.ToInt32(str.ToCharArray()[i]) > 0xff)
                {
                    num3 += 2;
                }
                else
                {
                    num3++;
                }
                if (num3 > len)
                {
                    num4 = i;
                    break;
                }
                if (num3 == len)
                {
                    num4 = i + 1;
                    break;
                }
            }
            if (num4 >= 0)
            {
                str2 = str.Substring(0, num4) + p_TailString;
            }
            return str2;
        }

        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }

        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return (GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0);
        }

        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }

        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }

        public static bool InIPArray(string ip, string[] iparray)
        {
            string[] strArray = SplitString(ip, ".");
            for (int i = 0; i < iparray.Length; i++)
            {
                string[] strArray2 = SplitString(iparray[i], ".");
                int num2 = 0;
                for (int j = 0; j < strArray2.Length; j++)
                {
                    if (strArray2[j] == "*")
                    {
                        return true;
                    }
                    if ((strArray.Length <= j) || !(strArray2[j] == strArray[j]))
                    {
                        break;
                    }
                    num2++;
                }
                if (num2 == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public static string IntToStr(int intValue)
        {
            return Convert.ToString(intValue);
        }

        public static bool IsBase64String(string str)
        {
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }

        public static bool IsCompriseStr(string str, string stringarray, string strsplit)
        {
            if (!StrIsNullOrEmpty(stringarray))
            {
                str = str.ToLower();
                string[] strArray = SplitString(stringarray.ToLower(), strsplit);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (str.IndexOf(strArray[i]) > -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsDateString(string str)
        {
            return Regex.IsMatch(str, @"(\d{4})-(\d{1,2})-(\d{1,2})");
        }

        public static bool IsDouble(object Expression)
        {
            return Validator.IsDouble(Expression);
        }

        public static bool IsIE()
        {
            return (HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].IndexOf("MSIE") >= 0);
        }

        public static bool IsImgFilename(string filename)
        {
            filename = filename.Trim();
            if (filename.EndsWith(".") || (filename.IndexOf(".") == -1))
            {
                return false;
            }
            string str = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            return ((((str == "jpg") || (str == "jpeg")) || ((str == "png") || (str == "bmp"))) || (str == "gif"));
        }

        public static bool IsInt(string str)
        {
            return Regex.IsMatch(str, "^[0-9]*$");
        }

        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static bool IsIPSect(string ip)
        {
            return Regex.IsMatch(ip,
                                 @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){2}((2[0-4]\d|25[0-5]|[01]?\d\d?|\*)\.)(2[0-4]\d|25[0-5]|[01]?\d\d?|\*)$");
        }

        public static bool IsNumeric(object Expression)
        {
            return Validator.IsNumeric(Expression);
        }

        public static bool IsNumericArray(string[] strNumber)
        {
            return Validator.IsNumericArray(strNumber);
        }

        public static bool IsNumericList(string numList)
        {
            if (StrIsNullOrEmpty(numList))
            {
                return false;
            }
            return IsNumericArray(numList.Split(new[] {','}));
        }

        public static bool IsRuleTip(Hashtable NewHash, string ruletype, out string key)
        {
            key = "";
            foreach (DictionaryEntry entry in NewHash)
            {
                try
                {
                    foreach (string str in SplitString(entry.Value.ToString(), "\r\n"))
                    {
                        if (str != "")
                        {
                            string str2 = ruletype.Trim().ToLower();
                            if (str2 != null)
                            {
                                if (str2 != "email")
                                {
                                    if (!(str2 == "ip"))
                                    {
                                        if (str2 == "timesect")
                                        {
                                            string[] strArray3 = str.Split(new[] {'-'});
                                            if (!IsTime(strArray3[1]) || !IsTime(strArray3[0]))
                                            {
                                                throw new Exception();
                                            }
                                        }
                                    }
                                    else if (!IsIPSect(str))
                                    {
                                        throw new Exception();
                                    }
                                }
                                else if (!IsValidDoEmail(str))
                                {
                                    throw new Exception();
                                }
                            }
                        }
                    }
                }
                catch
                {
                    key = entry.Key.ToString();
                    return false;
                }
            }
            return true;
        }

        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, "^\\s*$|^c:\\\\con\\\\con$|[%,\\*\"\\s\\t\\<\\>\\&]|游客|^Guest");
        }

        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl,
                                 @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        private static bool IsUTF8(FileStream sbInputStream)
        {
            bool flag = true;
            long length = sbInputStream.Length;
            byte num2 = 0;
            for (int i = 0; i < length; i++)
            {
                var num4 = (byte) sbInputStream.ReadByte();
                if ((num4 & 0x80) != 0)
                {
                    flag = false;
                }
                if (num2 == 0)
                {
                    if (num4 >= 0x80)
                    {
                        do
                        {
                            num4 = (byte) (num4 << 1);
                            num2 = (byte) (num2 + 1);
                        } while ((num4 & 0x80) != 0);
                        num2 = (byte) (num2 - 1);
                        if (num2 == 0)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if ((num4 & 0xc0) != 0x80)
                    {
                        return false;
                    }
                    num2 = (byte) (num2 - 1);
                }
            }
            if (num2 > 0)
            {
                return false;
            }
            if (flag)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail,
                                 @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^[\w\.]+([-]\w+)*@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
        }

        public static string JsonCharFilter(string sourceStr)
        {
            sourceStr = sourceStr.Replace(@"\", @"\\");
            sourceStr = sourceStr.Replace("\b", "\\\b");
            sourceStr = sourceStr.Replace("\t", "\\\t");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\f", "\\\f");
            sourceStr = sourceStr.Replace("\r", "\\\r");
            return sourceStr.Replace("\"", "\\\"");
        }

        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string name);

        public static string mashSQL(string str)
        {
            return ((str == null) ? "" : str.Replace("'", "'"));
        }

        public static string MD5(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            bytes = new MD5CryptoServiceProvider().ComputeHash(bytes);
            string str2 = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str2 = str2 + bytes[i].ToString("x").PadLeft(2, '0');
            }
            return str2;
        }

        public static string MergeString(string source, string target)
        {
            return MergeString(source, target, ",");
        }

        public static string MergeString(string source, string target, string mergechar)
        {
            if (StrIsNullOrEmpty(target))
            {
                target = source;
                return target;
            }
            target = target + mergechar + source;
            return target;
        }

        public static string[] PadStringArray(string[] strArray, int minLength, int maxLength)
        {
            // This item is obfuscated and can not be translated.
            //int num3;
            //if (minLength > maxLength)
            //{
            //    int num = maxLength;
            //    maxLength = minLength;
            //    minLength = num;
            //}
            //int num2 = 0;
            //for (num3 = 0; num3 < strArray.Length; num3++)
            //{
            //    if ((minLength > -1) && (strArray[num3].Length < minLength))
            //    {
            //        strArray[num3] = null;
            //    }
            //    else
            //    {
            //        if (strArray[num3].Length > maxLength)
            //        {
            //            strArray[num3] = strArray[num3].Substring(0, maxLength);
            //        }
            //        num2++;
            //    }
            //}
            //string[] strArray2 = new string[num2];
            //num3 = 0;
            //int index = 0;
            //while (num3 >= strArray.Length)
            //{
            //Label_0070:
            //    if (0 == 0)
            //    {
            //        return strArray2;
            //    }
            //    if ((strArray[num3] != null) && (strArray[num3] != string.Empty))
            //    {
            //        strArray2[index] = strArray[num3];
            //        index++;
            //    }
            //    num3++;
            //}
            //goto Label_0070;
            return null;
        }

        public static string RemoveFontTag(string title)
        {
            Match match = RegexFont.Match(title);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return title;
        }

        public static string RemoveHtml(string content)
        {
            return Regex.Replace(content, "<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string RemoveUnsafeHtml(string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2",
                                    RegexOptions.IgnoreCase);
            return content;
        }

        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString,
                                           bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString,
                                 IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        public static string ReplaceStrToScript(string str)
        {
            return str.Replace(@"\", @"\\").Replace("'", @"\'").Replace("\"", "\\\"");
        }

        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream stream = null;
            var buffer = new byte[0x2710];
            try
            {
                stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                long length = stream.Length;
                HttpContext.Current.Response.ContentType = filetype;
                if (HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].IndexOf("MSIE") > -1)
                {
                    HttpContext.Current.Response.AddHeader("Content-Disposition",
                                                           "attachment;filename=" +
                                                           UrlEncode(filename.Trim()).Replace("+", " "));
                }
                else
                {
                    HttpContext.Current.Response.AddHeader("Content-Disposition",
                                                           "attachment;filename=" + filename.Trim());
                }
                while (length > 0L)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        int count = stream.Read(buffer, 0, 0x2710);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, count);
                        HttpContext.Current.Response.Flush();
                        buffer = new byte[0x2710];
                        length -= count;
                    }
                    else
                    {
                        length = -1L;
                    }
                }
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("Error : " + exception.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            HttpContext.Current.Response.End();
        }

        public static void RestartIISProcess()
        {
            try
            {
                var document = new XmlDocument();
                document.Load(GetMapPath("~/web.config"));
                var w = new XmlTextWriter(GetMapPath("~/web.config"), null)
                    {
                        Formatting = Formatting.Indented
                    };
                document.WriteTo(w);
                w.Flush();
                w.Close();
            }
            catch
            {
            }
        }

        public static bool RestoreFile(string backupFileName, string targetFileName)
        {
            return RestoreFile(backupFileName, targetFileName, null);
        }

        public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
        {
            try
            {
                if (!File.Exists(backupFileName))
                {
                    throw new FileNotFoundException(backupFileName + "文件不存在！");
                }
                if (backupTargetFileName != null)
                {
                    if (!File.Exists(targetFileName))
                    {
                        throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
                    }
                    File.Copy(targetFileName, backupTargetFileName, true);
                }
                File.Delete(targetFileName);
                File.Copy(backupFileName, targetFileName);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }

        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                char ch = str[i];
                if (!ch.Equals(" "))
                {
                    ch = str[i];
                }
                if (ch.Equals("\r") || (ch = str[i]).Equals("\n"))
                {
                    str.Remove(i, 1);
                }
            }
            return str;
        }

        public static int SafeInt32(object objNum)
        {
            if (objNum != null)
            {
                string expression = objNum.ToString();
                if (IsNumeric(expression))
                {
                    if (expression.Length > 9)
                    {
                        if (expression.StartsWith("-"))
                        {
                            return -2147483648;
                        }
                        return 0x7fffffff;
                    }
                    return int.Parse(expression);
                }
            }
            return 0;
        }

        public static string SBCCaseToNumberic(string SBCCase)
        {
            char[] chars = SBCCase.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(chars, i, 1);
                if ((bytes.Length == 2) && (bytes[1] == 0xff))
                {
                    bytes[0] = (byte) (bytes[0] + 0x20);
                    bytes[1] = 0;
                    chars[i] = Encoding.Unicode.GetChars(bytes)[0];
                }
            }
            return new string(chars);
        }

        public static string SHA256(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            var managed = new SHA256Managed();
            return Convert.ToBase64String(managed.ComputeHash(bytes));
        }

        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!StrIsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                {
                    return new[] {strContent};
                }
                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            return new string[0];
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem)
        {
            return SplitString(strContent, strSplit, ignoreRepeatItem, 0);
        }

        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            var strArray = new string[count];
            string[] strArray2 = SplitString(strContent, strSplit);
            for (int i = 0; i < count; i++)
            {
                if (i < strArray2.Length)
                {
                    strArray[i] = strArray2[i];
                }
                else
                {
                    strArray[i] = string.Empty;
                }
            }
            return strArray;
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem,
                                           int maxElementLength)
        {
            string[] strArray = SplitString(strContent, strSplit);
            return (ignoreRepeatItem ? DistinctStringArray(strArray, maxElementLength) : strArray);
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem,
                                           int minElementLength, int maxElementLength)
        {
            string[] strArray = SplitString(strContent, strSplit);
            if (ignoreRepeatItem)
            {
                strArray = DistinctStringArray(strArray);
            }
            return PadStringArray(strArray, minElementLength, maxElementLength);
        }

        public static int StrDateDiffHours(string time, int hours)
        {
            if (StrIsNullOrEmpty(time))
            {
                return 1;
            }
            DateTime time2 = TypeConverter.StrToDateTime(time, DateTime.Parse("1900-01-01"));
            if (time2.ToString("yyyy-MM-dd") == "1900-01-01")
            {
                return 1;
            }
            TimeSpan span = (DateTime.Now - time2.AddHours(hours));
            if (span.TotalHours > 2147483647.0)
            {
                return 0x7fffffff;
            }
            if (span.TotalHours < -2147483648.0)
            {
                return -2147483648;
            }
            return (int) span.TotalHours;
        }

        public static int StrDateDiffMinutes(string time, int minutes)
        {
            if (StrIsNullOrEmpty(time))
            {
                return 1;
            }
            DateTime time2 = TypeConverter.StrToDateTime(time, DateTime.Parse("1900-01-01"));
            if (time2.ToString("yyyy-MM-dd") == "1900-01-01")
            {
                return 1;
            }
            TimeSpan span = (DateTime.Now - time2.AddMinutes(minutes));
            if (span.TotalMinutes > 2147483647.0)
            {
                return 0x7fffffff;
            }
            if (span.TotalMinutes < -2147483648.0)
            {
                return -2147483648;
            }
            return (int) span.TotalMinutes;
        }

        public static int StrDateDiffSeconds(string time, int Sec)
        {
            if (StrIsNullOrEmpty(time))
            {
                return 1;
            }
            DateTime time2 = TypeConverter.StrToDateTime(time, DateTime.Parse("1900-01-01"));
            if (time2.ToString("yyyy-MM-dd") == "1900-01-01")
            {
                return 1;
            }
            TimeSpan span = (DateTime.Now - time2.AddSeconds(Sec));
            if (span.TotalSeconds > 2147483647.0)
            {
                return 0x7fffffff;
            }
            if (span.TotalSeconds < -2147483648.0)
            {
                return -2147483648;
            }
            return (int) span.TotalSeconds;
        }

        public static string StrFilter(string str, string bantext)
        {
            string oldValue = "";
            string newValue = "";
            string[] strArray = SplitString(bantext, "\r\n");
            for (int i = 0; i < strArray.Length; i++)
            {
                oldValue = strArray[i].Substring(0, strArray[i].IndexOf("="));
                newValue = strArray[i].Substring(strArray[i].IndexOf("=") + 1);
                str = str.Replace(oldValue, newValue);
            }
            return str;
        }

        public static string StrFormat(string str)
        {
            if (str == null)
            {
                return "";
            }
            str = str.Replace("\r\n", "<br />");
            str = str.Replace("\n", "<br />");
            return str;
        }

        public static bool StrIsNullOrEmpty(string str)
        {
            return ((str == null) || (str.Trim() == string.Empty));
        }

        public static bool StrToBool(object expression, bool defValue)
        {
            return TypeConverter.StrToBool(expression, defValue);
        }

        public static bool StrToBool(string expression, bool defValue)
        {
            return TypeConverter.StrToBool(expression, defValue);
        }

        public static float StrToFloat(object strValue, float defValue)
        {
            return TypeConverter.StrToFloat(strValue, defValue);
        }

        public static float StrToFloat(string strValue, float defValue)
        {
            return TypeConverter.StrToFloat(strValue, defValue);
        }

        public static int StrToInt(object expression, int defValue)
        {
            return TypeConverter.ObjectToInt(expression, defValue);
        }

        public static int StrToInt(string expression, int defValue)
        {
            return TypeConverter.StrToInt(expression, defValue);
        }

        public static Color ToColor(string color)
        {
            int num;
            int num2;
            char[] chArray;
            int blue = 0;
            color = color.TrimStart(new[] {'#'});
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            int length = color.Length;
            if (length != 3)
            {
                if (length != 6)
                {
                    return Color.FromName(color);
                }
                chArray = color.ToCharArray();
                num = Convert.ToInt32(chArray[0].ToString() + chArray[1].ToString(), 0x10);
                num2 = Convert.ToInt32(chArray[2].ToString() + chArray[3].ToString(), 0x10);
                blue = Convert.ToInt32(chArray[4].ToString() + chArray[5].ToString(), 0x10);
                return Color.FromArgb(num, num2, blue);
            }
            chArray = color.ToCharArray();
            num = Convert.ToInt32(chArray[0].ToString() + chArray[0].ToString(), 0x10);
            num2 = Convert.ToInt32(chArray[1].ToString() + chArray[1].ToString(), 0x10);
            blue = Convert.ToInt32(chArray[2].ToString() + chArray[2].ToString(), 0x10);
            return Color.FromArgb(num, num2, blue);
        }

        public static string ToSChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
        }

        public static string ToTChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
        }

        public void transHtml(string path, string outpath)
        {
            FileStream stream;
            var page = new Page();
            var writer = new StringWriter();
            page.Server.Execute(path, writer);
            if (File.Exists(page.Server.MapPath("") + @"\" + outpath))
            {
                File.Delete(page.Server.MapPath("") + @"\" + outpath);
                stream = File.Create(page.Server.MapPath("") + @"\" + outpath);
            }
            else
            {
                stream = File.Create(page.Server.MapPath("") + @"\" + outpath);
            }
            byte[] bytes = Encoding.Default.GetBytes(writer.ToString());
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
        }

        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public class VersionInfo
        {
            public int FileBuildPart
            {
                get { return 0x259; }
            }

            public int FileMajorPart
            {
                get { return 3; }
            }

            public int FileMinorPart
            {
                get { return 6; }
            }

            public string LegalCopyright
            {
                get { return "2011, ShopNum1 Inc."; }
            }

            public string ProductName
            {
                get { return "ShopNum1"; }
            }
        }
    }
}