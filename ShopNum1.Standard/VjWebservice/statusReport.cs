using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ShopNum1.Standard.VjWebservice
{
    [Serializable, XmlType(Namespace = "http://sdkhttp.eucp.b2m.cn/"), GeneratedCode("System.Xml", "2.0.50727.1433"),
     DebuggerStepThrough, DesignerCategory("code")]
    public class statusReport
    {
        private int int_0;
        private long long_0;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string errorCode
        {
            get { return string_0; }
            set { string_0 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string memo
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string mobile
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string receiveDate
        {
            get { return string_3; }
            set { string_3 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int reportStatus
        {
            get { return int_0; }
            set { int_0 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long seqID
        {
            get { return long_0; }
            set { long_0 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string serviceCodeAdd
        {
            get { return string_4; }
            set { string_4 = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string submitDate
        {
            get { return string_5; }
            set { string_5 = value; }
        }
    }
}