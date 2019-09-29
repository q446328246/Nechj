using System;
using System.Data;
using System.Web;
using System.Xml;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_DefaultAdImg_Action : IShopNum1_DefaultAdImg_Action, IDisposable
    {
        private DataTable dt;
        private string string_0 = HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/DefaultAdImg.xml");

        public string adpath
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        public DataTable DefaultData
        {
            get
            {
                if (dt == null)
                {
                    dt = GetDefaultAd();
                }
                return dt;
            }
            set { dt = value; }
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool Add(DefaultAdImg advertisement)
        {
            var document = new XmlDocument();
            document.Load(adpath);
            XmlNode node = document.SelectSingleNode("ads");
            XmlElement newChild = document.CreateElement("ad");
            newChild.SetAttribute("guid", advertisement.Guid);
            newChild.SetAttribute("title", advertisement.title);
            newChild.SetAttribute("pagename", advertisement.PageName);
            newChild.SetAttribute("filename", advertisement.FileName);
            newChild.SetAttribute("type", advertisement.Type);
            newChild.SetAttribute("imgsrc", advertisement.imgsrc);
            newChild.SetAttribute("href", advertisement.Href);
            newChild.SetAttribute("width", advertisement.Width);
            newChild.SetAttribute("height", advertisement.Height);
            newChild.SetAttribute("orderID", advertisement.orderID);
            node.AppendChild(newChild);
            try
            {
                document.Save(adpath);
                ResetAd();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string guids)
        {
            string[] array = guids.Replace("'", "").Split(new[]
            {
                ','
            });
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(adpath);
            XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
            for (int i = 0; i < array.Length; i++)
            {
                foreach (XmlNode xmlNode in childNodes)
                {
                    var xmlElement = (XmlElement) xmlNode;
                    if (xmlElement.GetAttribute("guid") == array[i])
                    {
                        xmlDocument.SelectSingleNode("ads").RemoveChild(xmlNode);
                        break;
                    }
                }
            }
            bool result;
            try
            {
                xmlDocument.Save(adpath);
                ResetAd();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public DataTable GetDefaultAd()
        {
            var set = new DataSet();
            set.ReadXml(adpath);
            return set.Tables[0];
        }

        public void ResetAd()
        {
            dt = null;
        }

        public DataTable SelectByID(string guid)
        {
            var set = new DataSet();
            set.ReadXml(adpath);
            DataRow[] source = set.Tables[0].Select("guid = '" + guid + "'");
            if (source.Length > 0)
            {
                return source.CopyToDataTable();
            }
            return null;
        }

        public bool Update(DefaultAdImg advertisement)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(adpath);
            XmlNodeList childNodes = xmlDocument.SelectSingleNode("ads").ChildNodes;
            foreach (XmlNode xmlNode in childNodes)
            {
                var xmlElement = (XmlElement) xmlNode;
                if (xmlElement.GetAttribute("guid") == advertisement.Guid)
                {
                    xmlElement.SetAttribute("guid", advertisement.Guid);
                    xmlElement.SetAttribute("title", advertisement.title);
                    xmlElement.SetAttribute("pagename", advertisement.PageName);
                    xmlElement.SetAttribute("filename", advertisement.FileName);
                    xmlElement.SetAttribute("type", advertisement.Type);
                    xmlElement.SetAttribute("imgsrc", advertisement.imgsrc);
                    xmlElement.SetAttribute("href", advertisement.Href);
                    xmlElement.SetAttribute("width", advertisement.Width);
                    xmlElement.SetAttribute("height", advertisement.Height);
                    xmlElement.SetAttribute("orderID", advertisement.orderID);
                    break;
                }
            }
            bool result;
            try
            {
                xmlDocument.Save(adpath);
                ResetAd();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}