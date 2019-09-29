using System;
using System.Data;
using System.Web;
using System.Xml;

namespace ShopNum1.AdXml
{
    public class DefaultAdvertismentOperate
    {
        private static DataTable dt;

        public static DataTable xmlDataTable
        {
            get
            {
                if (dt == null)
                {
                    var set = new DataSet();
                    set.ReadXml(HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/AdImage.xml"));
                    if ((set == null) || (set.Tables.Count == 0))
                    {
                        return null;
                    }
                    if (set.Tables.Count != 0)
                    {
                        dt = set.Tables[0];
                    }
                }
                return dt;
            }
            set { dt = value; }
        }

        public int Add(string title, string imgsrc, string href, string width, string height, string pageName,
                       string string_0)
        {
            var document = new XmlDocument();
            document.Load(GetPath());
            XmlNode node = document.SelectSingleNode("ads");
            XmlElement newChild = document.CreateElement("ad");
            newChild.SetAttribute("id", GetMaxId().ToString());
            newChild.SetAttribute("title", title);
            newChild.SetAttribute("imgsrc", imgsrc);
            newChild.SetAttribute("href", href);
            newChild.SetAttribute("width", width);
            newChild.SetAttribute("height", height);
            newChild.SetAttribute("pagename", pageName);
            newChild.SetAttribute("des", string_0);
            node.AppendChild(newChild);
      
            try
            {
                document.Save(GetPath());
                ResetDe();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(string guids)
        {
            string[] array = guids.Replace("'", "").Split(new char[]
			{
				','
			});
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(this.GetPath());
            XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
     
            for (int i = 0; i < array.Length; i++)
            {
                foreach (XmlNode xmlNode in childNodes)
                {
                    XmlElement xmlElement = (XmlElement)xmlNode;
                    if (xmlElement.GetAttribute("id") == array[i])
                    {
                        xmlDocument.SelectSingleNode("ads").RemoveChild(xmlNode);
                        break;
                    }
                }
            }
            int result;
            try
            {
                xmlDocument.Save(this.GetPath());
                DefaultAdvertismentOperate.ResetDe();
                result = 1;
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public static string GetAdPro(string string_0, string string_1)
        {
            string result;
            foreach (DataRow dataRow in DefaultAdvertismentOperate.xmlDataTable.Rows)
            {
                if (dataRow["id"].ToString() == string_0)
                {
                    try
                    {
                        result = dataRow[string_1].ToString();
                        return result;
                    }
                    catch
                    {
                        result = "";
                        return result;
                    }
                }
            }
            result = "";
            return result;
        }

        public int GetMaxId()
        {
            int num = 0;
            if (xmlDataTable == null)
            {
                return 1;
            }
            foreach (DataRow row in xmlDataTable.Rows)
            {
                if (Convert.ToInt32(row["id"]) > num)
                {
                    num = Convert.ToInt32(row["id"]);
                }
            }
            return (num + 1);
        }

        public string GetPath()
        {
            return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/AdImage.xml");
        }

        public DataTable GetXmlDataTable()
        {
            var set = new DataSet();
            set.ReadXml(HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/AdImage.xml"));
            if ((set == null) || (set.Tables.Count == 0))
            {
                return null;
            }
            return set.Tables[0];
        }

        public DataTable GetXmlDataTable1(string PageName)
        {
            var set = new DataSet();
            if ((PageName != "") && (PageName != null))
            {
                set.ReadXml(GetPath());
                DataRow[] source = set.Tables[0].Select("pagename like '%" + PageName + "%'");
                if (source.Length > 0)
                {
                    DataTable tmp = set.Tables[0].Clone();  // 复制DataRow的表结构
                    foreach (DataRow row in source)
                        tmp.Rows.Add(row);  // 将DataRow添加到DataTable中
                    return tmp;
                }
                return null;
            }
            if ((PageName == "") || (PageName == null))
            {
                set.ReadXml(HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/AdImage.xml"));
                if ((set == null) || (set.Tables.Count == 0))
                {
                    return null;
                }
                if (set.Tables.Count != 0)
                {
                    dt = set.Tables[0];
                }
                return set.Tables[0];
            }
            set.ReadXml(GetPath());
            if (set.Tables.Count > 0)
            {
                return set.Tables[0];
            }
            return null;
        }

        public static void ResetDe()
        {
            xmlDataTable = null;
        }

        public static DataTable SelecByID(string string_0)
        {
            DataRow[] source = xmlDataTable.Select("id= '" + string_0 + "'");
            if (source.Length > 0)
            {
                return source.CopyToDataTable<DataRow>();
            }
            return null;
        }

        public int Update(string string_0, string title, string imgsrc, string linkUrl)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(this.GetPath());
            XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
            foreach (XmlNode xmlNode in childNodes)
            {
                XmlElement xmlElement = (XmlElement)xmlNode;
                if (xmlElement.GetAttribute("id") == string_0.Replace("'", ""))
                {
                    xmlElement.SetAttribute("title", title);
                    xmlElement.SetAttribute("imgsrc", imgsrc);
                    xmlElement.SetAttribute("href", linkUrl);
                    break;
                }
            }
            int result;
            try
            {
                xmlDocument.Save(this.GetPath());
                DefaultAdvertismentOperate.ResetDe();
                result = 1;
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public int Update(string string_0, string title, string imgsrc, string linkUrl, string height, string width,
                          string pageName, string string_1)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(this.GetPath());
            XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
            foreach (XmlNode xmlNode in childNodes)
            {
                XmlElement xmlElement = (XmlElement)xmlNode;
                if (xmlElement.GetAttribute("id") == string_0.Replace("'", ""))
                {
                    xmlElement.SetAttribute("title", title);
                    xmlElement.SetAttribute("imgsrc", imgsrc);
                    xmlElement.SetAttribute("href", linkUrl);
                    xmlElement.SetAttribute("height", height);
                    xmlElement.SetAttribute("width", width);
                    xmlElement.SetAttribute("pagename", pageName);
                    xmlElement.SetAttribute("des", string_1);
                    break;
                }
            }
            int result;
            try
            {
                xmlDocument.Save(this.GetPath());
                DefaultAdvertismentOperate.ResetDe();
                result = 1;
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }
    }
}