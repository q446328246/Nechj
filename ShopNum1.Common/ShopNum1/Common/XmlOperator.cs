using System;
using System.Data;
using System.IO;
using System.Xml;

namespace ShopNum1.Common
{
    public class XmlOperator : IDisposable
    {
        private bool _alreadyDispose;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!_alreadyDispose)
            {
                if (!isDisposing)
                {
                }
                _alreadyDispose = true;
            }
        }

        ~XmlOperator()
        {
            Dispose();
        }

        public static DataSet GetXml(string XmlPath)
        {
            var set = new DataSet();
            set.ReadXml(XmlPath);
            return set;
        }

        public static DataSet GetXmlData(string xmlPath, string XmlPathNode)
        {
            var document = new XmlDocument();
            document.Load(xmlPath);
            var set = new DataSet();
            var reader = new StringReader(document.SelectSingleNode(XmlPathNode).OuterXml);
            set.ReadXml(reader);
            return set;
        }

        public static string ReadXmlReturnNode(string XmlPath, string Node)
        {
            var document = new XmlDocument();
            document.Load(XmlPath);
            return document.GetElementsByTagName(Node).Item(0).InnerText;
        }

        public static XmlNodeList ReadXmlReturnNodeList(string XmlPath, string Node)
        {
            var document = new XmlDocument();
            document.Load(XmlPath);
            return document.SelectNodes(Node);
        }

        public static string ReadXmlReturnNodeText(string XmlPath, string Node)
        {
            var document = new XmlDocument();
            document.Load(XmlPath);
            return document.SelectSingleNode(Node).InnerText;
        }

        public static void XmlDeleteElement(string xmlPath, string MainNode, string key, string value)
        {
            var document = new XmlDocument();
            document.Load(xmlPath);
            foreach (XmlNode node in document.SelectSingleNode(MainNode).ChildNodes)
            {
                var oldChild = (XmlElement) node;
                if (oldChild.GetAttribute(key) == value)
                {
                    oldChild.RemoveAll();
                    document.SelectSingleNode(MainNode).RemoveChild(oldChild);
                }
            }
            document.Save(xmlPath);
        }

        public static void XmlInsertElement(string xmlPath, string MainNode, string Element, string Content)
        {
            var document = new XmlDocument();
            document.Load(xmlPath);
            XmlNode node = document.SelectSingleNode(MainNode);
            XmlElement newChild = document.CreateElement(Element);
            newChild.InnerText = Content;
            node.AppendChild(newChild);
            document.Save(xmlPath);
        }

        public static void XmlInsertElement(string xmlPath, string MainNode, string Element, string Attrib,
                                            string AttribContent, string Content)
        {
            var document = new XmlDocument();
            document.Load(xmlPath);
            XmlNode node = document.SelectSingleNode(MainNode);
            XmlElement newChild = document.CreateElement(Element);
            newChild.SetAttribute(Attrib, AttribContent);
            newChild.InnerText = Content;
            node.AppendChild(newChild);
            document.Save(xmlPath);
        }

        public static void XmlInsertElement(string xmlPath, string MainNode, string Node, string Attrib,
                                            string AttribValue, string Attrib2, string AttribValue2, string Attrib3,
                                            string AttribValue3)
        {
            var document = new XmlDocument();
            document.Load(xmlPath);
            XmlNode node = document.SelectSingleNode(MainNode);
            XmlElement newChild = document.CreateElement(Node);
            newChild.SetAttribute(Attrib, AttribValue);
            newChild.SetAttribute(Attrib2, AttribValue2);
            newChild.SetAttribute(Attrib3, AttribValue3);
            node.AppendChild(newChild);
            document.Save(xmlPath);
        }

        public static void XmlInsertNode(string xmlPath, string MailNode, string ChildNode, string Element,
                                         string Content)
        {
            var document = new XmlDocument();
            document.Load(xmlPath);
            XmlNode node = document.SelectSingleNode(MailNode);
            XmlElement newChild = document.CreateElement(ChildNode);
            node.AppendChild(newChild);
            XmlElement element2 = document.CreateElement(Element);
            element2.InnerText = Content;
            newChild.AppendChild(element2);
            document.Save(xmlPath);
        }

        public static void XmlNodeDelete(string xmlPath, string Node)
        {
            var document = new XmlDocument();
            document.Load(xmlPath);
            string xpath = Node.Substring(0, Node.LastIndexOf("/"));
            document.SelectSingleNode(xpath).RemoveChild(document.SelectSingleNode(Node));
            document.Save(xmlPath);
        }

        public static void XmlNodeReplace(string xmlPath, string Node, string Content)
        {
            var document = new XmlDocument();
            document.Load(xmlPath);
            document.SelectSingleNode(Node).InnerText = Content;
            document.Save(xmlPath);
        }
    }
}