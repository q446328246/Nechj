using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace ShopNum1.Common
{
    public class RssXMLComponent : XMLComponent
    {
        private string strName;

        public RssXMLComponent(string s)
        {
            strName = s;
            base.FileEncode = "gb2312";
            base.Version = "2.0";
            base.StartElement = "channel";
        }

        public override string WriteFile()
        {
            base.CreatePath();
            string s =
                string.Format(
                    "<?xml version='1.0' encoding='{0}'?><?xml-stylesheet type=\"text/xsl\" href=\"{1}\"?><rss version='{2}'></rss>",
                    base.FileEncode, base.XslLink, base.Version);
            base.xmlDoc_Metone.Load(new StringReader(s));
            string str2 = "-1";
            foreach (DataRow row in base.SourceDataTable.Rows)
            {
                XmlElement element;
                if ((base.Key != null) && (base.ParentField != null))
                {
                    if ((row[base.ParentField].ToString().Trim() == "") ||
                        (row[base.ParentField].ToString().Trim() == "0"))
                    {
                        element = base.xmlDoc_Metone.CreateElement(base.StartElement);
                        base.xmlDoc_Metone.DocumentElement.AppendChild(element);
                        foreach (DataColumn column in base.SourceDataTable.Columns)
                        {
                            if (column.Caption.ToLower() == base.ParentField.ToLower())
                            {
                                str2 = row[base.Key].ToString().Trim();
                            }
                            else if ((row[base.ParentField].ToString().Trim() == "") ||
                                     (row[base.ParentField].ToString().Trim() == "0"))
                            {
                                base.AppendChildElement(column.Caption.ToLower(), row[column].ToString().Trim(),
                                                        element);
                            }
                        }
                        foreach (DataRow row2 in base.SourceDataTable.Select(base.ParentField + "=" + str2))
                        {
                            if (base.SourceDataTable.Select(base.ParentField + "=" + row2[base.Key]).Length >= 0)
                            {
                                base.BulidXmlTree(element, row2["ItemID"].ToString().Trim());
                            }
                        }
                    }
                }
                else
                {
                    element = base.xmlDoc_Metone.CreateElement(base.StartElement);
                    base.xmlDoc_Metone.DocumentElement.AppendChild(element);
                    foreach (DataColumn column in base.SourceDataTable.Columns)
                    {
                        base.AppendChildElement(column.Caption.ToLower(), row[column].ToString().Trim(), element);
                    }
                }
            }
            base.xmlDoc_Metone.Save(base.FileOutPath + base.FileName);
            return (base.FileOutPath + base.FileName);
        }

        public override StringBuilder WriteStringBuilder()
        {
            string s =
                string.Format(
                    "<?xml version='1.0' encoding='{0}'?><?xml-stylesheet type=\"text/xsl\" href=\"{1}\"?><rss version='{2}'></rss>",
                    base.FileEncode, base.XslLink, base.Version);
            base.xmlDoc_Metone.Load(new StringReader(s));
            string str2 = "-1";
            foreach (DataRow row in base.SourceDataTable.Rows)
            {
                XmlElement element;
                if ((base.Key != null) && (base.ParentField != null))
                {
                    if ((row[base.ParentField].ToString().Trim() == "") ||
                        (row[base.ParentField].ToString().Trim() == "0"))
                    {
                        element = base.xmlDoc_Metone.CreateElement(base.StartElement);
                        base.xmlDoc_Metone.DocumentElement.AppendChild(element);
                        foreach (DataColumn column in base.SourceDataTable.Columns)
                        {
                            if (column.Caption.ToLower() == base.ParentField.ToLower())
                            {
                                str2 = row[base.Key].ToString().Trim();
                            }
                            else if ((row[base.ParentField].ToString().Trim() == "") ||
                                     (row[base.ParentField].ToString().Trim() == "0"))
                            {
                                base.AppendChildElement(column.Caption.ToLower(), row[column].ToString().Trim(),
                                                        element);
                            }
                        }
                        foreach (DataRow row2 in base.SourceDataTable.Select(base.ParentField + "=" + str2))
                        {
                            if (base.SourceDataTable.Select(base.ParentField + "=" + row2[base.Key]).Length >= 0)
                            {
                                base.BulidXmlTree(element, row2["ItemID"].ToString().Trim());
                            }
                        }
                    }
                }
                else
                {
                    element = base.xmlDoc_Metone.CreateElement(base.StartElement);
                    base.xmlDoc_Metone.DocumentElement.AppendChild(element);
                    foreach (DataColumn column in base.SourceDataTable.Columns)
                    {
                        base.AppendChildElement(column.Caption.ToLower(), row[column].ToString().Trim(), element);
                    }
                }
            }
            return new StringBuilder().Append(base.xmlDoc_Metone.InnerXml);
        }
    }
}