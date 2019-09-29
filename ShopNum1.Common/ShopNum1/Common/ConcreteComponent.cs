using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace ShopNum1.Common
{
    internal class ConcreteComponent : XMLComponent
    {
        private string strName;

        public ConcreteComponent(string s)
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
                    writer.WriteProcessingInstruction("xml-stylesheet", "type='text/xsl' href='" + base.XslLink + "'");
                    writer.WriteStartElement(base.SourceDataTable.TableName);
                    writer.WriteAttributeString("", "version", null, base.Version);
                    foreach (DataRow row in base.SourceDataTable.Rows)
                    {
                        writer.WriteStartElement("", base.StartElement, "");
                        foreach (DataColumn column in base.SourceDataTable.Columns)
                        {
                            writer.WriteStartElement("", column.Caption.Trim().ToLower(), "");
                            writer.WriteString(row[column].ToString().Trim());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
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