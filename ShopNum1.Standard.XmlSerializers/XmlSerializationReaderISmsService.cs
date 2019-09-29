using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly
{
    public class XmlSerializationReaderISmsService : XmlSerializationReader
    {
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6;

        protected override void InitCallbacks()
        {
        }

        protected override void InitIDs()
        {
            string_0 = base.Reader.NameTable.Add("out");
            string_1 = base.Reader.NameTable.Add("http://service.ewing.com");
            string_2 = base.Reader.NameTable.Add("reportResponse");
            string_3 = base.Reader.NameTable.Add("accountResponse");
            string_4 = base.Reader.NameTable.Add("updatePasswordResponse");
            string_5 = base.Reader.NameTable.Add("smsSendResponse");
            string_6 = base.Reader.NameTable.Add("moResponse");
        }

        public object[] Read1_accountResponse()
        {
            base.Reader.MoveToContent();
            var o = new object[1];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.IsStartElement(string_3, string_1))
                {
                    var flagArray = new bool[1];
                    if (base.Reader.IsEmptyElement)
                    {
                        base.Reader.Skip();
                        base.Reader.MoveToContent();
                        continue;
                    }
                    base.Reader.ReadStartElement();
                    base.Reader.MoveToContent();
                    int num3 = 0;
                    int num4 = base.ReaderCount;
                    while (base.Reader.NodeType != XmlNodeType.EndElement)
                    {
                        if (base.Reader.NodeType == XmlNodeType.None)
                        {
                            break;
                        }
                        if (base.Reader.NodeType == XmlNodeType.Element)
                        {
                            if ((!flagArray[0] && (base.Reader.LocalName == string_0)) &&
                                (base.Reader.NamespaceURI == string_1))
                            {
                                if (base.ReadNull())
                                {
                                    o[0] = null;
                                }
                                else
                                {
                                    o[0] = base.Reader.ReadElementString();
                                }
                                flagArray[0] = true;
                            }
                            else
                            {
                                base.UnknownNode(o, "http://service.ewing.com:out");
                            }
                        }
                        else
                        {
                            base.UnknownNode(o, "http://service.ewing.com:out");
                        }
                        base.Reader.MoveToContent();
                        base.CheckReaderCount(ref num3, ref num4);
                    }
                    base.ReadEndElement();
                }
                else
                {
                    base.UnknownNode(null, "http://service.ewing.com:accountResponse");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }

        public object[] Read10_moResponseOutHeaders()
        {
            base.Reader.MoveToContent();
            var o = new object[0];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.NodeType == XmlNodeType.Element)
                {
                    base.UnknownNode(o, "");
                }
                else
                {
                    base.UnknownNode(o, "");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }

        public object[] Read2_accountResponseOutHeaders()
        {
            base.Reader.MoveToContent();
            var o = new object[0];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.NodeType == XmlNodeType.Element)
                {
                    base.UnknownNode(o, "");
                }
                else
                {
                    base.UnknownNode(o, "");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }

        public object[] Read3_updatePasswordResponse()
        {
            base.Reader.MoveToContent();
            var o = new object[1];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.IsStartElement(string_4, string_1))
                {
                    var flagArray = new bool[1];
                    if (base.Reader.IsEmptyElement)
                    {
                        base.Reader.Skip();
                        base.Reader.MoveToContent();
                        continue;
                    }
                    base.Reader.ReadStartElement();
                    base.Reader.MoveToContent();
                    int num3 = 0;
                    int num4 = base.ReaderCount;
                    while (base.Reader.NodeType != XmlNodeType.EndElement)
                    {
                        if (base.Reader.NodeType == XmlNodeType.None)
                        {
                            break;
                        }
                        if (base.Reader.NodeType == XmlNodeType.Element)
                        {
                            if ((!flagArray[0] && (base.Reader.LocalName == string_0)) &&
                                (base.Reader.NamespaceURI == string_1))
                            {
                                if (base.ReadNull())
                                {
                                    o[0] = null;
                                }
                                else
                                {
                                    o[0] = base.Reader.ReadElementString();
                                }
                                flagArray[0] = true;
                            }
                            else
                            {
                                base.UnknownNode(o, "http://service.ewing.com:out");
                            }
                        }
                        else
                        {
                            base.UnknownNode(o, "http://service.ewing.com:out");
                        }
                        base.Reader.MoveToContent();
                        base.CheckReaderCount(ref num3, ref num4);
                    }
                    base.ReadEndElement();
                }
                else
                {
                    base.UnknownNode(null, "http://service.ewing.com:updatePasswordResponse");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }

        public object[] Read4_Item()
        {
            base.Reader.MoveToContent();
            var o = new object[0];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.NodeType == XmlNodeType.Element)
                {
                    base.UnknownNode(o, "");
                }
                else
                {
                    base.UnknownNode(o, "");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }

        public object[] Read5_reportResponse()
        {
            base.Reader.MoveToContent();
            var o = new object[1];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.IsStartElement(string_2, string_1))
                {
                    var flagArray = new bool[1];
                    if (base.Reader.IsEmptyElement)
                    {
                        base.Reader.Skip();
                        base.Reader.MoveToContent();
                        continue;
                    }
                    base.Reader.ReadStartElement();
                    base.Reader.MoveToContent();
                    int num3 = 0;
                    int num4 = base.ReaderCount;
                    while (base.Reader.NodeType != XmlNodeType.EndElement)
                    {
                        if (base.Reader.NodeType == XmlNodeType.None)
                        {
                            break;
                        }
                        if (base.Reader.NodeType == XmlNodeType.Element)
                        {
                            if ((!flagArray[0] && (base.Reader.LocalName == string_0)) &&
                                (base.Reader.NamespaceURI == string_1))
                            {
                                if (base.ReadNull())
                                {
                                    o[0] = null;
                                }
                                else
                                {
                                    o[0] = base.Reader.ReadElementString();
                                }
                                flagArray[0] = true;
                            }
                            else
                            {
                                base.UnknownNode(o, "http://service.ewing.com:out");
                            }
                        }
                        else
                        {
                            base.UnknownNode(o, "http://service.ewing.com:out");
                        }
                        base.Reader.MoveToContent();
                        base.CheckReaderCount(ref num3, ref num4);
                    }
                    base.ReadEndElement();
                }
                else
                {
                    base.UnknownNode(null, "http://service.ewing.com:reportResponse");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }

        public object[] Read6_reportResponseOutHeaders()
        {
            base.Reader.MoveToContent();
            var o = new object[0];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.NodeType == XmlNodeType.Element)
                {
                    base.UnknownNode(o, "");
                }
                else
                {
                    base.UnknownNode(o, "");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }

        public object[] Read7_smsSendResponse()
        {
            base.Reader.MoveToContent();
            var o = new object[1];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.IsStartElement(string_5, string_1))
                {
                    var flagArray = new bool[1];
                    if (base.Reader.IsEmptyElement)
                    {
                        base.Reader.Skip();
                        base.Reader.MoveToContent();
                        continue;
                    }
                    base.Reader.ReadStartElement();
                    base.Reader.MoveToContent();
                    int num3 = 0;
                    int num4 = base.ReaderCount;
                    while (base.Reader.NodeType != XmlNodeType.EndElement)
                    {
                        if (base.Reader.NodeType == XmlNodeType.None)
                        {
                            break;
                        }
                        if (base.Reader.NodeType == XmlNodeType.Element)
                        {
                            if ((!flagArray[0] && (base.Reader.LocalName == string_0)) &&
                                (base.Reader.NamespaceURI == string_1))
                            {
                                if (base.ReadNull())
                                {
                                    o[0] = null;
                                }
                                else
                                {
                                    o[0] = base.Reader.ReadElementString();
                                }
                                flagArray[0] = true;
                            }
                            else
                            {
                                base.UnknownNode(o, "http://service.ewing.com:out");
                            }
                        }
                        else
                        {
                            base.UnknownNode(o, "http://service.ewing.com:out");
                        }
                        base.Reader.MoveToContent();
                        base.CheckReaderCount(ref num3, ref num4);
                    }
                    base.ReadEndElement();
                }
                else
                {
                    base.UnknownNode(null, "http://service.ewing.com:smsSendResponse");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }

        public object[] Read8_smsSendResponseOutHeaders()
        {
            base.Reader.MoveToContent();
            var o = new object[0];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.NodeType == XmlNodeType.Element)
                {
                    base.UnknownNode(o, "");
                }
                else
                {
                    base.UnknownNode(o, "");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }

        public object[] Read9_moResponse()
        {
            base.Reader.MoveToContent();
            var o = new object[1];
            base.Reader.MoveToContent();
            int whileIterations = 0;
            int readerCount = base.ReaderCount;
            while (base.Reader.NodeType != XmlNodeType.EndElement)
            {
                if (base.Reader.NodeType == XmlNodeType.None)
                {
                    return o;
                }
                if (base.Reader.IsStartElement(string_6, string_1))
                {
                    var flagArray = new bool[1];
                    if (base.Reader.IsEmptyElement)
                    {
                        base.Reader.Skip();
                        base.Reader.MoveToContent();
                        continue;
                    }
                    base.Reader.ReadStartElement();
                    base.Reader.MoveToContent();
                    int num3 = 0;
                    int num4 = base.ReaderCount;
                    while (base.Reader.NodeType != XmlNodeType.EndElement)
                    {
                        if (base.Reader.NodeType == XmlNodeType.None)
                        {
                            break;
                        }
                        if (base.Reader.NodeType == XmlNodeType.Element)
                        {
                            if ((!flagArray[0] && (base.Reader.LocalName == string_0)) &&
                                (base.Reader.NamespaceURI == string_1))
                            {
                                if (base.ReadNull())
                                {
                                    o[0] = null;
                                }
                                else
                                {
                                    o[0] = base.Reader.ReadElementString();
                                }
                                flagArray[0] = true;
                            }
                            else
                            {
                                base.UnknownNode(o, "http://service.ewing.com:out");
                            }
                        }
                        else
                        {
                            base.UnknownNode(o, "http://service.ewing.com:out");
                        }
                        base.Reader.MoveToContent();
                        base.CheckReaderCount(ref num3, ref num4);
                    }
                    base.ReadEndElement();
                }
                else
                {
                    base.UnknownNode(null, "http://service.ewing.com:moResponse");
                }
                base.Reader.MoveToContent();
                base.CheckReaderCount(ref whileIterations, ref readerCount);
            }
            return o;
        }
    }
}