using System;
using System.Data;
using System.Web;
using System.Xml;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_PageAdID_Action : IShopNum1_PageAdID_Action, IDisposable
    {
        public XmlDocument xmlDoc;

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int Add(PageAdID pageAdID)
        {
            LoadXml();
            XmlNode node = xmlDoc.SelectSingleNode("pages");
            XmlElement newChild = xmlDoc.CreateElement("page");
            newChild.SetAttribute("guid", pageAdID.Guid);
            newChild.SetAttribute("pagename", pageAdID.PageName);
            newChild.SetAttribute("filename", pageAdID.FileName);
            newChild.SetAttribute("divid", pageAdID.DivID);
            newChild.SetAttribute("content", pageAdID.Content);
            newChild.SetAttribute("width", pageAdID.Width);
            newChild.SetAttribute("height", pageAdID.Height);
            newChild.SetAttribute("imgsrc", pageAdID.ImgSrc);
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

        public int CheckDivID(string divid)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            if ((divid != "") && (divid != null))
            {
                if (set.Tables[0].Select("divid like '%" + divid + "%'").Length > 0)
                {
                    return 1;
                }
                return 0;
            }
            return 0;
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

        public string GetNewDivID()
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            DataTable table = set.Tables[0];
            int num = 0;
            int num2 = 0;
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    num2 = int.Parse(row["divid"].ToString().Replace("ad", "")) + 1;
                    if (num2 > num)
                    {
                        num = num2;
                    }
                }
                return ("ad" + num);
            }
            return "ad1";
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
            if ((guid != "") && (guid != null))
            {
                DataRow[] source = set.Tables[0].Select("guid= '" + guid + "'");
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

        public int Update(PageAdID pageAdID)
        {
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("pages").ChildNodes;
            foreach (XmlNode xmlNode in childNodes)
            {
                var xmlElement = (XmlElement) xmlNode;
                if (xmlElement.GetAttribute("guid") == pageAdID.Guid)
                {
                    xmlElement.SetAttribute("guid", pageAdID.Guid);
                    xmlElement.SetAttribute("pagename", pageAdID.PageName);
                    xmlElement.SetAttribute("filename", pageAdID.FileName);
                    xmlElement.SetAttribute("content", pageAdID.Content);
                    xmlElement.SetAttribute("width", pageAdID.Width);
                    xmlElement.SetAttribute("height", pageAdID.Height);
                    xmlElement.SetAttribute("imgsrc", pageAdID.ImgSrc);
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

        public string GetPath()
        {
            return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/PageAdID.xml");
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(GetPath());
        }
    }
}