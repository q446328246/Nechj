using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace ShopNum1.Common
{
    public abstract class XMLComponent
    {
        private string fileEncode = "utf-8";
        private string fileName = "MyFile.xml";
        private string fileOutputPath = "";
        private int indentation = 6;
        private string key = "ItemID";
        private string parentField = "Item";
        private string startElement = "channel";
        private string version = "2.0";
        public XmlDocument xmlDoc_Metone = new XmlDocument();

        public string FileEncode
        {
            get { return fileEncode; }
            set { fileEncode = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string FileOutPath
        {
            get { return fileOutputPath; }
            set
            {
                if (value.LastIndexOf(@"\") != (value.Length - 1))
                {
                    fileOutputPath = value + @"\";
                }
            }
        }

        public int Indentation
        {
            get { return indentation; }
            set { indentation = value; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string ParentField
        {
            get { return parentField; }
            set { parentField = value; }
        }

        public DataTable SourceDataTable { get; set; }

        public string StartElement
        {
            get { return startElement; }
            set { startElement = value; }
        }

        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        public string XslLink { get; set; }

        protected void AppendChildElement(string strName, string strInnerText, XmlElement parentElement)
        {
            AppendChildElement(strName, strInnerText, parentElement, xmlDoc_Metone);
        }

        protected void AppendChildElement(string strName, string strInnerText, XmlElement parentElement,
                                          XmlDocument xmlDocument)
        {
            XmlElement newChild = xmlDocument.CreateElement(strName);
            newChild.InnerText = strInnerText;
            parentElement.AppendChild(newChild);
        }

        protected void BulidXmlTree(XmlElement tempXmlElement, string location)
        {
            DataRow row = SourceDataTable.Select(Key + "=" + location)[0];
            XmlElement newChild = xmlDoc_Metone.CreateElement(ParentField);
            tempXmlElement.AppendChild(newChild);
            foreach (DataColumn column in SourceDataTable.Columns)
            {
                if (column.Caption.ToLower() != ParentField.ToLower())
                {
                    AppendChildElement(column.Caption.Trim().ToLower(), row[column.Caption.Trim()].ToString().Trim(),
                                       newChild);
                }
            }
            foreach (DataRow row2 in SourceDataTable.Select(ParentField + "=" + location))
            {
                if (SourceDataTable.Select("item=" + row2[Key]).Length >= 0)
                {
                    BulidXmlTree(newChild, row2[Key].ToString().Trim());
                }
            }
        }

        public void CreatePath()
        {
            string fileOutPath;
            if (FileOutPath != null)
            {
                fileOutPath = FileOutPath;
                if (!Directory.Exists(fileOutPath))
                {
                    Utils.CreateDir(fileOutPath);
                }
            }
            else
            {
                fileOutPath = @"C:\";
                string str2 = DateTime.Now.ToString("yyyy-M").Trim();
                if (!Directory.Exists(fileOutPath + str2))
                {
                    Utils.CreateDir(fileOutPath + @"\" + str2);
                }
            }
        }

        public abstract string WriteFile();
        public abstract StringBuilder WriteStringBuilder();
    }
}