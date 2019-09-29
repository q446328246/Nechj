using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Microsoft.VisualBasic;

namespace ShopNum1.DiscuzCommon
{
    public class Utils
    {
        private static readonly FileVersionInfo fileVersionInfo_0 =
            FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);

        private static readonly Regex regex_0 = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
        public static Regex RegexFont = new Regex("<font color=\".*?\">([\\s\\S]+?)</font>", GetRegexCompiledOptions());

        private static readonly string string_0 = string.Format("dnttemplateid_{0}_{1}_{2}",
                                                                fileVersionInfo_0.FileMajorPart,
                                                                fileVersionInfo_0.FileMinorPart,
                                                                fileVersionInfo_0.FileBuildPart);

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

        public static string ChkSQL(string string_1)
        {
            if (string_1 == null)
            {
                return "";
            }
            string_1 = string_1.Replace("'", "''");
            return string_1;
        }

        public static string CleanInput(string strIn)
        {
            return Regex.Replace(strIn.Trim(), @"[^\w\.@-]", "");
        }

        public static string ClearBR(string string_1)
        {
            Match match = null;
            for (match = regex_0.Match(string_1); match.Success; match = match.NextMatch())
            {
                string_1 = string_1.Replace(match.Groups[0].ToString(), "");
            }
            return string_1;
        }

        public static string ClearLastChar(string string_1)
        {
            if (string_1 == "")
            {
                return "";
            }
            return string_1.Substring(0, string_1.Length - 1);
        }

        public static bool CreateDir(string name)
        {
            return MakeSureDirectoryPathExists(name);
        }

        public static string CutString(string string_1, int startIndex)
        {
            return CutString(string_1, startIndex, string_1.Length);
        }

        public static string CutString(string string_1, int startIndex, int length)
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
                if (startIndex > string_1.Length)
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
            if ((string_1.Length - startIndex) < length)
            {
                length = string_1.Length - startIndex;
            }
            return string_1.Substring(startIndex, length);
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
                    var stream = new FileStream(files[i].FullName, FileMode.Open, FileAccess.Read);
                    bool flag = smethod_0(stream);
                    stream.Close();
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

        public static string GetAssemblyCopyright()
        {
            return fileVersionInfo_0.LegalCopyright;
        }

        public static string GetAssemblyProductName()
        {
            return fileVersionInfo_0.ProductName;
        }

        public static string GetAssemblyVersion()
        {
            return string.Format("{0}.{1}.{2}", fileVersionInfo_0.FileMajorPart, fileVersionInfo_0.FileMinorPart,
                                 fileVersionInfo_0.FileBuildPart);
        }

        public static string GetCookie(string strName)
        {
            if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null))
            {
                return HttpContext.Current.Request.Cookies[strName].Value;
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

        public static string GetFilename(string string_1)
        {
            if (string_1 == null)
            {
                return "";
            }
            string[] strArray = string_1.Split(new[] {'/'});
            return strArray[strArray.Length - 1].Split(new[] {'?'})[0];
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
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }

        public static string GetPageNumbers(int curPage, int countPage, string string_1, int extendPage)
        {
            return GetPageNumbers(curPage, countPage, string_1, extendPage, "page");
        }

        public static string GetPageNumbers(int curPage, int countPage, string string_1, int extendPage, string pagetag)
        {
            return GetPageNumbers(curPage, countPage, string_1, extendPage, pagetag, null);
        }

        public static string GetPageNumbers(int curPage, int countPage, string string_1, int extendPage, string pagetag,
                                            string anchor)
        {
            if (pagetag == "")
            {
                pagetag = "page";
            }
            int num = 1;
            int num3 = 1;
            if (string_1.IndexOf("?") > 0)
            {
                string_1 = string_1 + "&";
            }
            else
            {
                string_1 = string_1 + "?";
            }
            string str = "<a href=\"" + string_1 + "&" + pagetag + "=1";
            string str2 = string.Concat(new object[] {"<a href=\"", string_1, "&", pagetag, "=", countPage});
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
                        num3 = (num + extendPage) - 1;
                    }
                    else
                    {
                        num3 = countPage;
                        num = (num3 - extendPage) + 1;
                        str2 = "";
                    }
                }
                else
                {
                    num3 = extendPage;
                    str = "";
                }
            }
            else
            {
                num = 1;
                num3 = countPage;
                str = "";
                str2 = "";
            }
            var builder = new StringBuilder("");
            builder.Append(str);
            for (int i = num; i <= num3; i++)
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
                    builder.Append(string_1);
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

        public static string GetPostPageNumbers(int countPage, string string_1, string expname, int extendPage)
        {
            int num = 1;
            int num2 = 1;
            int num3 = 1;
            string str = "<a href=\"" + string_1 + "-1" + expname + "\">&laquo;</a>";
            string str2 = string.Concat(new object[] {"<a href=\"", string_1, "-", countPage, expname, "\">&raquo;</a>"});
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
                if ((num3 - (extendPage/2)) > 0)
                {
                    if ((num3 + (extendPage/2)) < countPage)
                    {
                        num = num3 - (extendPage/2);
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
                builder.Append("<a href=\"");
                builder.Append(string_1);
                builder.Append("-");
                builder.Append(i);
                builder.Append(expname);
                builder.Append("\">");
                builder.Append(i);
                builder.Append("</a>");
            }
            builder.Append(str2);
            return builder.ToString();
        }

        public static string GetRealIP()
        {
            return DNTRequest.GetIP();
        }

        public static RegexOptions GetRegexCompiledOptions()
        {
            return RegexOptions.None;
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
            return Convert.ToDateTime(fDateTime).ToString(formatStr);
        }

        public static string GetStaticPageNumbers(int curPage, int countPage, string string_1, string expname,
                                                  int extendPage)
        {
            int num = 1;
            int num2 = 1;
            string str = "<a href=\"" + string_1 + "-1" + expname + "\">&laquo;</a>";
            string str2 = string.Concat(new object[] {"<a href=\"", string_1, "-", countPage, expname, "\">&raquo;</a>"});
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
                    builder.Append(string_1);
                    builder.Append("-");
                    builder.Append(i);
                    builder.Append(expname);
                    builder.Append("\">");
                    builder.Append(i);
                    builder.Append("</a>");
                }
            }
            builder.Append(str2);
            return builder.ToString();
        }

        public static int GetStringLength(string string_1)
        {
            return Encoding.Default.GetBytes(string_1).Length;
        }

        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string str = p_SrcString;
            if (Regex.IsMatch(p_SrcString, "[ࠀ-一]+") || Regex.IsMatch(p_SrcString, "[가-힣]+"))
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
            if (p_Length < 0)
            {
                return str;
            }
            byte[] bytes = Encoding.Default.GetBytes(p_SrcString);
            if (bytes.Length <= p_StartIndex)
            {
                return str;
            }
            int length = bytes.Length;
            if (bytes.Length > (p_StartIndex + p_Length))
            {
                length = p_Length + p_StartIndex;
            }
            else
            {
                p_Length = bytes.Length - p_StartIndex;
                p_TailString = "";
            }
            int num4 = p_Length;
            var numArray = new int[p_Length];
            byte[] destinationArray = null;
            int num2 = 0;
            for (int i = p_StartIndex; i < length; i++)
            {
                if (bytes[i] > 0x7f)
                {
                    num2++;
                    if (num2 == 3)
                    {
                        num2 = 1;
                    }
                }
                else
                {
                    num2 = 0;
                }
                numArray[i] = num2;
            }
            if ((bytes[length - 1] > 0x7f) && (numArray[p_Length - 1] == 1))
            {
                num4 = p_Length + 1;
            }
            destinationArray = new byte[num4];
            Array.Copy(bytes, p_StartIndex, destinationArray, 0, num4);
            return (Encoding.Default.GetString(destinationArray) + p_TailString);
        }

        public static string GetTemplateCookieName()
        {
            return string_0;
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

        public static string HtmlDecode(string string_1)
        {
            return HttpUtility.HtmlDecode(string_1);
        }

        public static string HtmlEncode(string string_1)
        {
            return HttpUtility.HtmlEncode(string_1);
        }

        public static bool InArray(string string_1, string[] stringarray)
        {
            return InArray(string_1, stringarray, false);
        }

        public static bool InArray(string string_1, string stringarray)
        {
            return InArray(string_1, SplitString(stringarray, ","), false);
        }

        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return (GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0);
        }

        public static bool InArray(string string_1, string stringarray, string strsplit)
        {
            return InArray(string_1, SplitString(stringarray, strsplit), false);
        }

        public static bool InArray(string string_1, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(string_1, SplitString(stringarray, strsplit), caseInsensetive);
        }

        public static bool InIPArray(string string_1, string[] iparray)
        {
            string[] strArray = SplitString(string_1, ".");
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

        public static bool IsBase64String(string string_1)
        {
            return Regex.IsMatch(string_1, @"[A-Za-z0-9\+\/\=]");
        }

        public static bool IsCompriseStr(string string_1, string stringarray, string strsplit)
        {
            if ((stringarray != "") && (stringarray != null))
            {
                string_1 = string_1.ToLower();
                string[] strArray = SplitString(stringarray.ToLower(), strsplit);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (string_1.IndexOf(strArray[i]) > -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsDateString(string string_1)
        {
            return Regex.IsMatch(string_1, @"(\d{4})-(\d{1,2})-(\d{1,2})");
        }

        public static bool IsDouble(object Expression)
        {
            return TypeParse.IsDouble(Expression);
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

        public static bool IsInt(string string_1)
        {
            return Regex.IsMatch(string_1, "^[0-9]*$");
        }

        public static bool IsIP(string string_1)
        {
            return Regex.IsMatch(string_1, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static bool IsIPSect(string string_1)
        {
            return Regex.IsMatch(string_1,
                                 @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){2}((2[0-4]\d|25[0-5]|[01]?\d\d?|\*)\.)(2[0-4]\d|25[0-5]|[01]?\d\d?|\*)$");
        }

        public static bool IsNumeric(object Expression)
        {
            return TypeParse.IsNumeric(Expression);
        }

        public static bool IsNumericArray(string[] strNumber)
        {
            return TypeParse.IsNumericArray(strNumber);
        }

        public static bool IsRuleTip(Hashtable NewHash, string ruletype, out string string_1)
        {
            string_1 = "";
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
                    string_1 = entry.Key.ToString();
                    return false;
                }
            }
            return true;
        }

        public static bool IsSafeSqlString(string string_1)
        {
            return !Regex.IsMatch(string_1, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        public static bool IsSafeUserInfoString(string string_1)
        {
            return !Regex.IsMatch(string_1, "^\\s*$|^c:\\\\con\\\\con$|[%,\\*\"\\s\\t\\<\\>\\&]|游客|^Guest");
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

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail,
                                 @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail,
                                 @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string string_1);

        public static string mashSQL(string string_1)
        {
            if (string_1 == null)
            {
                return "";
            }
            string_1 = string_1.Replace("'", "'");
            return string_1;
        }

        public static string MD5(string string_1)
        {
            byte[] bytes = Encoding.Default.GetBytes(string_1);
            bytes = new MD5CryptoServiceProvider().ComputeHash(bytes);
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str = str + bytes[i].ToString("x").PadLeft(2, '0');
            }
            return str;
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
            string pattern = "<[^>]*>";
            return Regex.Replace(content, pattern, string.Empty, RegexOptions.IgnoreCase);
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

        public static string ReplaceStrToScript(string string_1)
        {
            string_1 = string_1.Replace(@"\", @"\\");
            string_1 = string_1.Replace("'", @"\'");
            string_1 = string_1.Replace("\"", "\\\"");
            return string_1;
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
                HttpContext.Current.Response.AddHeader("Content-Disposition",
                                                       "attachment;filename=" +
                                                       UrlEncode(filename.Trim()).Replace("+", " "));
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

        public static string RTrim(string string_1)
        {
            for (int i = string_1.Length; i >= 0; i--)
            {
                char ch = string_1[i];
                if (!ch.Equals(" "))
                {
                    ch = string_1[i];
                }
                if (ch.Equals("\r") || (ch = string_1[i]).Equals("\n"))
                {
                    string_1.Remove(i, 1);
                }
            }
            return string_1;
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

        public static string SHA256(string string_1)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(string_1);
            var managed = new SHA256Managed();
            return Convert.ToBase64String(managed.ComputeHash(bytes));
        }

        private static bool smethod_0(FileStream fileStream_0)
        {
            bool flag = true;
            long length = fileStream_0.Length;
            byte num2 = 0;
            for (int i = 0; i < length; i++)
            {
                var num4 = (byte) fileStream_0.ReadByte();
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

        public static string Spaces(int nSpaces)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < nSpaces; i++)
            {
                builder.Append(" &nbsp;&nbsp;");
            }
            return builder.ToString();
        }

        public static string[] SplitString(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0)
            {
                return new[] {strContent};
            }
            return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
        }

        public static string[] SplitString(string strContent, string strSplit, int p_3)
        {
            var strArray = new string[p_3];
            string[] strArray2 = SplitString(strContent, strSplit);
            for (int i = 0; i < p_3; i++)
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

        public static int StrDateDiffHours(string time, int hours)
        {
            if ((time == "") || (time == null))
            {
                return 1;
            }
            TimeSpan span = (DateTime.Now - DateTime.Parse(time).AddHours(hours));
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
            if ((time == "") || (time == null))
            {
                return 1;
            }
            TimeSpan span = (DateTime.Now - DateTime.Parse(time).AddMinutes(minutes));
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

        public static int StrDateDiffSeconds(string Time, int Sec)
        {
            TimeSpan span = (DateTime.Now - DateTime.Parse(Time).AddSeconds(Sec));
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

        public static string StrFilter(string string_1, string bantext)
        {
            string oldValue = "";
            string newValue = "";
            string[] strArray = SplitString(bantext, "\r\n");
            for (int i = 0; i < strArray.Length; i++)
            {
                oldValue = strArray[i].Substring(0, strArray[i].IndexOf("="));
                newValue = strArray[i].Substring(strArray[i].IndexOf("=") + 1);
                string_1 = string_1.Replace(oldValue, newValue);
            }
            return string_1;
        }

        public static string StrFormat(string string_1)
        {
            if (string_1 == null)
            {
                return "";
            }
            string_1 = string_1.Replace("\r\n", "<br />");
            string_1 = string_1.Replace("\n", "<br />");
            return string_1;
        }

        public static bool StrToBool(object Expression, bool defValue)
        {
            return TypeParse.StrToBool(Expression, defValue);
        }

        public static float StrToFloat(object strValue, float defValue)
        {
            return TypeParse.StrToFloat(strValue, defValue);
        }

        public static int StrToInt(object Expression, int defValue)
        {
            return TypeParse.StrToInt(Expression, defValue);
        }

        public static Color ToColor(string color)
        {
            char[] chArray2;
            int num3;
            int num4;
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
                chArray2 = color.ToCharArray();
                num3 = Convert.ToInt32(chArray2[0].ToString() + chArray2[1].ToString(), 0x10);
                num4 = Convert.ToInt32(chArray2[2].ToString() + chArray2[3].ToString(), 0x10);
                blue = Convert.ToInt32(chArray2[4].ToString() + chArray2[5].ToString(), 0x10);
                return Color.FromArgb(num3, num4, blue);
            }
            chArray2 = color.ToCharArray();
            num3 = Convert.ToInt32(chArray2[0].ToString() + chArray2[0].ToString(), 0x10);
            num4 = Convert.ToInt32(chArray2[1].ToString() + chArray2[1].ToString(), 0x10);
            blue = Convert.ToInt32(chArray2[2].ToString() + chArray2[2].ToString(), 0x10);
            return Color.FromArgb(num3, num4, blue);
        }

        public static string ToSChinese(string string_1)
        {
            return Strings.StrConv(string_1, VbStrConv.SimplifiedChinese, 0);
        }

        public static string ToTChinese(string string_1)
        {
            return Strings.StrConv(string_1, VbStrConv.TraditionalChinese, 0);
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

        public static string UrlDecode(string string_1)
        {
            return HttpUtility.UrlDecode(string_1);
        }

        public static string UrlEncode(string string_1)
        {
            return HttpUtility.UrlEncode(string_1);
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
    }
}