using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ShopNum1.Standard.VjWebservice
{
    [Serializable, XmlType(Namespace = "http://sdkhttp.eucp.b2m.cn/"), DesignerCategory("code"), DebuggerStepThrough,
     GeneratedCode("System.Xml", "2.0.50727.1433")]
    public class GClass0
    {
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string addSerial
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string addSerialRev
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string channelnumber
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string mobileNumber
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string sentTime
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string smsContent
        {
            get { return string_5; }
            set { string_5 = value; }
        }
    }
}