using System;
using System.Data;
using System.Web;
using System.Xml;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_PageInfo_Action : IShopNum1_PageInfo_Action, IDisposable
    {
        public XmlDocument xmlDoc;

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int Add(PageInfo pageInfo)
        {
            LoadXml();
            XmlNode node = xmlDoc.SelectSingleNode("pages");
            XmlElement newChild = xmlDoc.CreateElement("page");
            newChild.SetAttribute("guid", pageInfo.Guid);
            newChild.SetAttribute("pagename", pageInfo.PageName);
            newChild.SetAttribute("filename", pageInfo.FileName);
            newChild.SetAttribute("pagenote", pageInfo.PageNote);
            newChild.SetAttribute("divid", pageInfo.divid);
            node.AppendChild(newChild);
            try
            {
                xmlDoc.Save(GetPath());
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Delete(string guids)
        {
            string[] strArray = guids.Replace("'", "").Split(new[] {','});
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("pages").ChildNodes;
            for (int i = 0; i < strArray.Length; i++)
            {
                XmlElement element;
                for (int j = 0; j < childNodes.Count; j++)
                {
                    element = (XmlElement) childNodes[j];
                    if (element.GetAttribute("guid") == strArray[i])
                    {
                        goto Label_0084;
                    }
                }
                continue;
                Label_0084:
                xmlDoc.SelectSingleNode("pages").RemoveChild(element);
            }
            try
            {
                xmlDoc.Save(GetPath());
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string GetPath()
        {
            return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/PageInfo.xml");
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(GetPath());
        }

        public DataTable Search(string pagename)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            if ((pagename != "") && (pagename != null))
            {
                DataRow[] source = set.Tables[0].Select("pagename like '%" + pagename + "%'");
                if (source.Length > 0)
                {
                    return source.CopyToDataTable();
                }
                return null;
            }
            if (set.Tables.Count > 0)
            {
                return set.Tables[0];
            }
            return null;
        }

        public DataTable SelectByID(string guid)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            DataTable table = set.Tables[0].DefaultView.ToTable();
            if (table.Rows.Count > 0)
            {
                if (0 >= table.Rows.Count)
                {
                    return table;
                }
                DataRow[] source = table.Select("guid like '" + guid + "%'");
                if (source.Length > 0)
                {
                    return source.CopyToDataTable();
                }
                return null;
            }
            return null;
        }

        public int Update(PageInfo pageInfo)
        {
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("pages").ChildNodes;
            foreach (XmlNode xmlNode in childNodes)
            {
                var xmlElement = (XmlElement) xmlNode;
                if (xmlElement.GetAttribute("guid") == pageInfo.Guid)
                {
                    xmlElement.SetAttribute("guid", pageInfo.Guid);
                    xmlElement.SetAttribute("pagename", pageInfo.PageName);
                    xmlElement.SetAttribute("filename", pageInfo.FileName);
                    xmlElement.SetAttribute("pagenote", pageInfo.PageNote);
                    break;
                }
            }
            int result;
            try
            {
                xmlDoc.Save(GetPath());
                result = 1;
            }
            catch (Exception)
            {
                result = 0;
            }
            return result;
        }

        public DataTable SelectBydivID(string divID)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            DataRow[] source = set.Tables[0].Select("divid = '" + divID + "'");
            if (source.Length > 0)
            {
                return source.CopyToDataTable();
            }
            return null;
        }
    }
}