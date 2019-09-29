using System;
using System.Collections;
using System.Xml;

namespace ShopNum1.Common
{
    public class XmlCreate : IDisposable
    {
        private readonly XmlDocument xmlDoc = new XmlDocument();
        private bool _alreadyDispose;
        private XmlElement xmlElem;
        private XmlNode xmlNode;
        //private string xmlPath;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void CreateXmlRoot(string root)
        {
            xmlNode = xmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmlDoc.AppendChild(xmlNode);
            xmlElem = xmlDoc.CreateElement("", root, "");
            xmlDoc.AppendChild(xmlElem);
        }

        public void CreatXmlNode(string mainNode, string node)
        {
            XmlNode node2 = xmlDoc.SelectSingleNode(mainNode);
            XmlElement newChild = xmlDoc.CreateElement(node);
            node2.AppendChild(newChild);
        }

        public void CreatXmlNode(string mainNode, string node, string content)
        {
            XmlNode node2 = xmlDoc.SelectSingleNode(mainNode);
            XmlElement newChild = xmlDoc.CreateElement(node);
            newChild.InnerText = content;
            node2.AppendChild(newChild);
        }

        public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue)
        {
            XmlNode node = xmlDoc.SelectSingleNode(MainNode);
            XmlElement newChild = xmlDoc.CreateElement(Node);
            newChild.SetAttribute(Attrib, AttribValue);
            node.AppendChild(newChild);
        }

        public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue, string Content)
        {
            XmlNode node = xmlDoc.SelectSingleNode(MainNode);
            XmlElement newChild = xmlDoc.CreateElement(Node);
            newChild.SetAttribute(Attrib, AttribValue);
            newChild.InnerText = Content;
            node.AppendChild(newChild);
        }

        public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue, string Attrib2,
                                 string AttribValue2)
        {
            XmlNode node = xmlDoc.SelectSingleNode(MainNode);
            XmlElement newChild = xmlDoc.CreateElement(Node);
            newChild.SetAttribute(Attrib, AttribValue);
            newChild.SetAttribute(Attrib2, AttribValue2);
            node.AppendChild(newChild);
        }

        public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue, string Attrib2,
                                 string AttribValue2, string Content)
        {
            XmlNode node = xmlDoc.SelectSingleNode(MainNode);
            XmlElement newChild = xmlDoc.CreateElement(Node);
            newChild.SetAttribute(Attrib, AttribValue);
            newChild.SetAttribute(Attrib2, AttribValue2);
            newChild.InnerText = Content;
            node.AppendChild(newChild);
        }

        public void CreatXmlNode(string MainNode, string Node, string Attrib, string AttribValue, string Attrib2,
                                 string AttribValue2, string Attrib3, string AttribValue3)
        {
            XmlNode node = xmlDoc.SelectSingleNode(MainNode);
            XmlElement newChild = xmlDoc.CreateElement(Node);
            newChild.SetAttribute(Attrib, AttribValue);
            newChild.SetAttribute(Attrib2, AttribValue2);
            newChild.SetAttribute(Attrib3, AttribValue3);
            node.AppendChild(newChild);
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

        ~XmlCreate()
        {
            Dispose();
        }

        public static ArrayList GetSubElementByAttribute(string XmlPath, string FatherElenetName, string AttributeName,
                                                         int AttributeIndex, int ArrayLength)
        {
            var list = new ArrayList();
            var document = new XmlDocument();
            document.Load(XmlPath);
            foreach (XmlElement element in document.DocumentElement.ChildNodes)
            {
                if (element.Name == FatherElenetName)
                {
                    if (element.Attributes.Count < AttributeIndex)
                    {
                        return null;
                    }
                    if (element.Attributes[AttributeIndex].Value == AttributeName)
                    {
                        XmlNodeList childNodes = element.ChildNodes;
                        if (childNodes.Count > 0)
                        {
                            for (int i = 0; (i < ArrayLength) & (i < childNodes.Count); i++)
                            {
                                list.Add(childNodes[i].InnerText);
                            }
                        }
                    }
                }
            }
            return list;
        }

        public static ArrayList GetSubElementByAttribute(string XmlPath, string FatherElement, string AttributeName,
                                                         string AttributeValue, int ArrayLength)
        {
            var list = new ArrayList();
            var document = new XmlDocument();
            document.Load(XmlPath);
            XmlNodeList childNodes =
                document.DocumentElement.SelectNodes("//" + FatherElement + "[" + AttributeName + "='" + AttributeValue +
                                                     "']").Item(0).ChildNodes;
            for (int i = 0; (i < ArrayLength) & (i < childNodes.Count); i++)
            {
                list.Add(childNodes.Item(i).InnerText);
            }
            return list;
        }

        public void XmlSave(string path)
        {
            xmlDoc.Save(path);
        }
    }
}