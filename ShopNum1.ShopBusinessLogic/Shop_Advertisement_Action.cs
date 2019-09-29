using System;
using System.Data;
using System.Web;
using System.Xml;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_Advertisement_Action : IShop_Advertisement_Action
    {
        //private string string_0;
        public XmlDocument xmlDoc;
        public string StrPath { get; set; }

        public string GetPath()
        {
            return HttpContext.Current.Server.MapPath(StrPath);
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(GetPath());
        }

        public DataTable Search(string pagename, string fileName)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(GetPath());
            DataTable result;
            if (pagename != "" && pagename != null && fileName == "-1")
            {
                DataRow[] array = dataSet.Tables[0].Select("pagename like '%" + pagename + "%'");
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
                if ((pagename == "" || pagename == null) && fileName != "-1")
                {
                    DataRow[] array = dataSet.Tables[0].Select(" filename='" + fileName + "'");
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
                    if (pagename != "" && pagename != null && fileName != "-1")
                    {
                        DataRow[] array = dataSet.Tables[0].Select(string.Concat(new[]
                        {
                            "pagename like '%",
                            pagename,
                            "%' AND filename='",
                            fileName,
                            "'"
                        }));
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
                }
            }
            return result;
        }

        public DataTable SelectByID(string guid)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(GetPath());
            DataRow[] array = dataSet.Tables[0].Select("guid = '" + guid + "'");
            DataTable result;
            if (array.Length > 0)
            {
                result = array.CopyToDataTable();
            }
            else
            {
                result = null;
            }
            return result;
        }

        public int Add(Advertisement advertisement)
        {
            LoadXml();
            XmlNode xmlNode = xmlDoc.SelectSingleNode("ads");
            XmlElement xmlElement = xmlDoc.CreateElement("ad");
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
            xmlNode.AppendChild(xmlElement);
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
            var dataSet = new DataSet();
            dataSet.ReadXml(GetPath());
            DataRow[] array = dataSet.Tables[0].Select("filename = '" + filename + "'");
            string result;
            if (array.Length > 0)
            {
                int num = int.Parse(array[array.Length - 1]["divid"].ToString().Replace("ad", "")) + 1;
                result = "ad" + (num + 1);
            }
            else
            {
                result = "ad1";
            }
            return result;
        }

        public DataTable ShowAD(string filename)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(GetPath());
            DataTable result;
            if (filename != "" && filename != null)
            {
                DataRow[] array = dataSet.Tables[0].Select("filename = '" + filename + "'");
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

        public DataTable ShowADByDivID(string divID)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(GetPath());
            DataTable result;
            if (dataSet == null || dataSet.Tables.Count == 0)
            {
                result = null;
            }
            else
            {
                DataRow[] array = dataSet.Tables[0].Select("divid = '" + divID + "'");
                if (array.Length > 0)
                {
                    result = array.CopyToDataTable();
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }

        public DataTable SearchPPT(string pagename)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml(GetPath());
            DataTable result;
            if (pagename != "" && pagename != null)
            {
                DataRow[] array = dataSet.Tables[0].Select("filename like '%" + pagename + "%'");
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
    }
}