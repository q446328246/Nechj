using System;
using System.Data;
using System.Web;
using System.Xml;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_Advertisement_Action : IShopNum1_Advertisement_Action, IDisposable
    {
        public XmlDocument xmlDoc;

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int Add(Advertisement advertisement)
        {
            LoadXml();
            XmlNode node = xmlDoc.SelectSingleNode("ads");
            XmlElement newChild = xmlDoc.CreateElement("ad");
            newChild.SetAttribute("guid", advertisement.Guid);
            newChild.SetAttribute("explain", advertisement.Explain);
            newChild.SetAttribute("pagename", advertisement.PageName);
            newChild.SetAttribute("filename", advertisement.FileName);
            newChild.SetAttribute("divid", advertisement.DivID);
            newChild.SetAttribute("type", advertisement.Type);
            newChild.SetAttribute("content", advertisement.Content);
            newChild.SetAttribute("href", advertisement.Href);
            newChild.SetAttribute("width", advertisement.Width);
            newChild.SetAttribute("height", advertisement.Height);
            node.AppendChild(newChild);
            try
            {
                xmlDoc.Save(GetPath());
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(string guids)
        {
            string[] array = guids.Replace("'", "").Split(new[]
            {
                ','
            });
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("ads").ChildNodes;
            for (int i = 0; i < array.Length; i++)
            {
                foreach (XmlNode xmlNode in childNodes)
                {
                    var xmlElement = (XmlElement) xmlNode;
                    if (xmlElement.GetAttribute("guid") == array[i])
                    {
                        xmlDoc.SelectSingleNode("ads").RemoveChild(xmlNode);
                        break;
                    }
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

        public string GetNewDivID(string filename)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            DataRow[] rowArray = set.Tables[0].Select("filename = '" + filename + "'");
            if (rowArray.Length > 0)
            {
                int num = int.Parse(rowArray[rowArray.Length - 1]["divid"].ToString().Replace("ad", "")) + 1;
                int num2 = num + 1;
                return ("ad" + num2);
            }
            return "ad1";
        }

        public string GetPath()
        {
            return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/Advertisement.xml");
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(GetPath());
        }

        public DataTable Search(string pagename, string fileName)
        {
            DataRow[] rowArray;
            var set = new DataSet();
            set.ReadXml(GetPath());
            if (((pagename != "") && (pagename != null)) && (fileName == "-1"))
            {
                rowArray = set.Tables[0].Select("pagename like '%" + pagename + "%'");
                if (rowArray.Length > 0)
                {
                    return rowArray.CopyToDataTable();
                }
                return null;
            }
            if (!(((pagename == "") || (pagename == null)) ? !(fileName != "-1") : true))
            {
                rowArray = set.Tables[0].Select(" filename='" + fileName + "'");
                if (rowArray.Length > 0)
                {
                    return rowArray.CopyToDataTable();
                }
                return null;
            }
            if (((pagename != "") && (pagename != null)) && (fileName != "-1"))
            {
                rowArray = set.Tables[0].Select("pagename like '%" + pagename + "%' AND filename='" + fileName + "'");
                if (rowArray.Length > 0)
                {
                    return rowArray.CopyToDataTable();
                }
                return null;
            }
            if (set.Tables.Count > 0)
            {
                return set.Tables[0];
            }
            return null;
        }

        public DataTable Search(string pagename, string fileName, string adID)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            string filterExpression = string.Empty;
            if (pagename != "-1")
            {
                filterExpression = "pagename like '%" + pagename.Trim() + "%' AND ";
            }
            if (fileName != "-1")
            {
                filterExpression = filterExpression + " filename='" + fileName.Trim() + "' AND ";
            }
            if (adID != "-1")
            {
                filterExpression = filterExpression + " divid like '%" + adID.Trim() + "%' AND";
            }
            filterExpression = filterExpression + " 1=1";
            DataRow[] source = set.Tables[0].Select(filterExpression);
            if (source.Length > 0)
            {
                return source.CopyToDataTable();
            }
            return null;
        }

        public DataTable Search1(string pagename, string fileName)
        {
            DataRow[] rowArray;
            var set = new DataSet();
            set.ReadXml(GetPath());
            if (((pagename != "") && (pagename != null)) && (fileName == "-1"))
            {
                rowArray = set.Tables[0].Select("divid like '%" + pagename + "%'");
                if (rowArray.Length > 0)
                {
                    return rowArray.CopyToDataTable();
                }
                return null;
            }
            if (!(((pagename == "") || (pagename == null)) ? !(fileName != "-1") : true))
            {
                rowArray = set.Tables[0].Select(" filename='" + fileName + "'");
                if (rowArray.Length > 0)
                {
                    return rowArray.CopyToDataTable();
                }
                return null;
            }
            if (((pagename != "") && (pagename != null)) && (fileName != "-1"))
            {
                rowArray = set.Tables[0].Select("divid like '%" + pagename + "%' AND filename='" + fileName + "'");
                if (rowArray.Length > 0)
                {
                    return rowArray.CopyToDataTable();
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
            DataRow[] source = set.Tables[0].Select("guid = '" + guid + "'");
            if (source.Length > 0)
            {
                return source.CopyToDataTable();
            }
            return null;
        }

        public DataTable ShowAD(string filename)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            if ((filename != "") && (filename != null))
            {
                DataRow[] source = set.Tables[0].Select("filename = '" + filename + "'");
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

        public DataTable ShowADByDivID(string divID)
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

        public DataTable ShowADByDivID(string divID, string type)
        {
            DataRow[] rowArray;
            var set = new DataSet();
            set.ReadXml(GetPath());
            if (((type == "-1") || (type == string.Empty)) || (type == null))
            {
                rowArray = set.Tables[0].Select("divid = '" + divID + "'");
            }
            else
            {
                rowArray = set.Tables[0].Select("divid = '" + divID + "' AND type='" + type + "'");
            }
            if (rowArray.Length > 0)
            {
                return rowArray.CopyToDataTable();
            }
            return null;
        }

        public int Update(Advertisement advertisement)
        {
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("ads").ChildNodes;
            foreach (XmlNode xmlNode in childNodes)
            {
                var xmlElement = (XmlElement) xmlNode;
                if (xmlElement.GetAttribute("guid") == advertisement.Guid)
                {
                    xmlElement.SetAttribute("guid", advertisement.Guid);
                    xmlElement.SetAttribute("explain", advertisement.Explain);
                    xmlElement.SetAttribute("pagename", advertisement.PageName);
                    xmlElement.SetAttribute("filename", advertisement.FileName);
                    xmlElement.SetAttribute("divid", advertisement.DivID);
                    xmlElement.SetAttribute("type", advertisement.Type);
                    xmlElement.SetAttribute("content", advertisement.Content);
                    xmlElement.SetAttribute("href", advertisement.Href);
                    xmlElement.SetAttribute("width", advertisement.Width);
                    xmlElement.SetAttribute("height", advertisement.Height);
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

        public DataTable SearchPPT(string pagename)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            if ((pagename != "") && (pagename != null))
            {
                DataRow[] source = set.Tables[0].Select("filename like '%" + pagename + "%'");
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
    }
}