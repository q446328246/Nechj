using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace ShopNum1.Common
{
    public class TreeNodeComponent : XMLComponent
    {
        private string strName;

        public TreeNodeComponent(string s)
        {
            strName = s;
        }

        public override string WriteFile()
        {
            if (base.SourceDataTable != null)
            {
                string filename = base.FileOutPath + base.FileName;
                XmlTextWriter writer = null;
                Encoding encoding = Encoding.GetEncoding(base.FileEncode);
                base.CreatePath();
                writer = new XmlTextWriter(filename, encoding);
                try
                {
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = base.Indentation;
                    writer.Namespaces = false;
                    writer.WriteStartDocument();
                    writer.WriteStartElement(base.SourceDataTable.TableName);
                    string str2 = null;
                    foreach (DataRow row in base.SourceDataTable.Rows)
                    {
                        str2 = "  Text=\"" + row[0].ToString().Trim() + "\"   ImageUrl=\"../../editor/images/smilies/" +
                               row[1].ToString().Trim() + "\"";
                        writer.WriteStartElement("", base.StartElement + str2, "");
                        writer.WriteEndElement();
                        str2 = null;
                    }
                    writer.WriteEndElement();
                    writer.Flush();
                    base.SourceDataTable.Dispose();
                }
                catch (Exception exception)
                {
                    Console.WriteLine("异常：{0}", exception);
                }
                finally
                {
                    Console.WriteLine("对文件 {0} 的处理已完成。");
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
                return filename;
            }
            Console.WriteLine("对文件 {0} 的处理未完成。");
            return "";
        }

        public override StringBuilder WriteStringBuilder()
        {
            string s = string.Format("<?xml version='1.0' encoding='{0}'?><{3} ></{3}>",
                                     new object[]
                                         {base.FileEncode, base.XslLink, base.Version, base.SourceDataTable.TableName});
            base.xmlDoc_Metone.Load(new StringReader(s));
            foreach (DataRow row in base.SourceDataTable.Rows)
            {
                XmlElement newChild = base.xmlDoc_Metone.CreateElement(base.StartElement);
                base.xmlDoc_Metone.DocumentElement.AppendChild(newChild);
                foreach (DataColumn column in base.SourceDataTable.Columns)
                {
                    base.AppendChildElement(column.Caption.ToLower(), row[column].ToString().Trim(), newChild);
                }
            }
            return new StringBuilder().Append(base.xmlDoc_Metone.InnerXml);
        }
    }
}