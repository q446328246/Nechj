using System.IO;
using System.Xml;

namespace ShopNum1.Common
{
    public class Themes
    {
        public static void CopyFolder(string strFromPath, string strToPath, string strDirectory)
        {
            if (!Directory.Exists(strFromPath))
            {
                Directory.CreateDirectory(strFromPath);
            }
            string str = strFromPath.Substring(strFromPath.LastIndexOf(@"\") + 1,
                                               (strFromPath.Length - strFromPath.LastIndexOf(@"\")) - 1);
            if (!Directory.Exists(strToPath + @"\" + ((strDirectory == null) ? str : strDirectory)))
            {
                Directory.CreateDirectory(strToPath + @"\" + ((strDirectory == null) ? str : strDirectory));
            }
            string[] files = Directory.GetFiles(strFromPath);
            for (int i = 0; i < files.Length; i++)
            {
                string str2 = files[i].Substring(files[i].LastIndexOf(@"\") + 1,
                                                 (files[i].Length - files[i].LastIndexOf(@"\")) - 1);
                File.Copy(files[i], strToPath + @"\" + ((strDirectory == null) ? str : strDirectory) + @"\" + str2, true);
            }
            DirectoryInfo[] directories = new DirectoryInfo(strFromPath).GetDirectories();
            for (int j = 0; j < directories.Length; j++)
            {
                CopyFolder(strFromPath + @"\" + directories[j],
                           strToPath + @"\" + ((strDirectory == null) ? str : strDirectory), null);
            }
        }

        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir))
            {
                foreach (string str in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(str))
                    {
                        File.Delete(str);
                    }
                    else
                    {
                        DeleteFolder(str);
                    }
                }
                Directory.Delete(dir, true);
            }
        }

        public string GetValue(string fieldXmlPath, string nodeName)
        {
            foreach (XmlNode node in XmlOperator.ReadXmlReturnNodeList(fieldXmlPath, "SiteConfig"))
            {
                foreach (XmlNode node2 in node.ChildNodes)
                {
                    if (node2.Name == nodeName)
                    {
                        return node2.InnerText;
                    }
                }
            }
            return string.Empty;
        }
    }
}