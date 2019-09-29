using System;
using System.Data;
using System.Web;
using System.Xml;
using ShopNum1.Interface;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_ExtendSiteMota_Action : IShopNum1_ExtendSiteMota_Action, IDisposable
    {
        private static DataTable dt;
        private static DataTable dataTable_1;
        private string string_0 = "~/Settings/SetMeto.xml";
        public XmlDocument xmlDoc;

        public static DataTable MetoTable
        {
            get
            {
                if (dt == null)
                {
                    var set = new DataSet();
                    set.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/SetMeto.xml"));
                    if ((set != null) && (set.Tables.Count > 0))
                    {
                        dt = set.Tables[0];
                    }
                }
                return dt;
            }
        }

        public static DataTable MetoTable1
        {
            get
            {
                if (dataTable_1 == null)
                {
                    var set = new DataSet();
                    set.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
                    if ((set != null) && (set.Tables.Count > 0))
                    {
                        dataTable_1 = set.Tables[0];
                    }
                }
                return dataTable_1;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int Add(string name, string title, string keywords, string string_1, string path)
        {
            if (check(name, path))
            {
                string_0 = path;
                LoadXml();
                XmlNode node = xmlDoc.SelectSingleNode("SiteMeta");
                XmlElement newChild = xmlDoc.CreateElement("Meta");
                newChild.SetAttribute("PageName", name);
                newChild.SetAttribute("Title", title);
                newChild.SetAttribute("KeyWords", keywords);
                newChild.SetAttribute("Description", string_1);
                node.AppendChild(newChild);
                try
                {
                    xmlDoc.Save(BindData());
                    return 1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            return 0;
        }

        public bool check(string PageName, string path)
        {
            var set = new DataSet();
            set.ReadXml(BindData());
            if (set.Tables[0].Select("PageName = '" + PageName + "'").Length > 0)
            {
                return false;
            }
            return true;
        }

        public int delete(string names, string path)
        {
            string[] array = names.Replace("'", "").Split(new[]
            {
                ','
            });
            string_0 = path;
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("SiteMeta").ChildNodes;
            for (int i = 0; i < array.Length; i++)
            {
                foreach (XmlNode xmlNode in childNodes)
                {
                    var xmlElement = (XmlElement) xmlNode;
                    if (xmlElement.GetAttribute("PageName") == array[i])
                    {
                        xmlDoc.SelectSingleNode("SiteMeta").RemoveChild(xmlNode);
                        break;
                    }
                }
            }
            int result;
            try
            {
                xmlDoc.Save(BindData());
                result = 1;
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public int edit(string name, string title, string keywords, string string_1, string path)
        {
            string_0 = path;
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("SiteMeta").ChildNodes;
            foreach (XmlNode xmlNode in childNodes)
            {
                var xmlElement = (XmlElement) xmlNode;
                if (xmlElement.GetAttribute("PageName") == name)
                {
                    xmlElement.SetAttribute("PageName", name);
                    xmlElement.SetAttribute("Title", title);
                    xmlElement.SetAttribute("KeyWords", keywords);
                    xmlElement.SetAttribute("Description", string_1);
                    break;
                }
            }
            int result;
            try
            {
                xmlDoc.Save(BindData());
                result = 1;
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public DataTable SearchMetoList(string pagename)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(BindData());
            DataTable result;
            if (pagename != "" && pagename != null)
            {
                DataRow[] array = dataSet.Tables[0].Select("PageName like '%" + pagename + "%'");
                if (array.Length > 0)
                {
                    result = array.CopyToDataTable();
                }
                else
                {
                    result = null;
                }
            }
            else
            {
                if (dataSet.Tables.Count > 0)
                {
                    result = dataSet.Tables[0];
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }

        public DataTable SearchMetoList(string pagename, string path)
        {
            var dataSet = new DataSet();
            string_0 = path;
            dataSet.ReadXml(BindData());
            DataTable result;
            if (pagename != "" && pagename != null)
            {
                DataRow[] array = dataSet.Tables[0].Select("PageName like '%" + pagename + "%'");
                if (array.Length > 0)
                {
                    result = array.CopyToDataTable();
                }
                else
                {
                    result = null;
                }
            }
            else
            {
                if (dataSet.Tables.Count > 0)
                {
                    result = dataSet.Tables[0];
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }

        public DataTable SelectByName(string PageName, string path)
        {
            try
            {
                var set = new DataSet();
                string_0 = path;
                set.ReadXml(BindData());
                DataRow[] source = set.Tables[0].Select("PageName = '" + PageName + "'");
                if (source.Length > 0)
                {
                    return source.CopyToDataTable();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(BindData());
        }

        private string BindData()
        {
            return HttpContext.Current.Server.MapPath(string_0);
        }

        public static void ResetMeto()
        {
            dt = null;
        }
    }
}