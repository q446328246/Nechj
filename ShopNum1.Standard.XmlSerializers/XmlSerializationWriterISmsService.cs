using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly
{
    public class XmlSerializationWriterISmsService : XmlSerializationWriter
    {
        protected override void InitCallbacks()
        {
        }

        public void Write1_account(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
            int length = object_0.Length;
            base.WriteStartElement("account", "http://service.ewing.com", null, false);
            if (length > 0)
            {
                base.WriteNullableStringLiteral("in0", "http://service.ewing.com", (string) object_0[0]);
            }
            if (length > 1)
            {
                base.WriteNullableStringLiteral("in1", "http://service.ewing.com", (string) object_0[1]);
            }
            if (length > 2)
            {
                base.WriteNullableStringLiteral("in2", "http://service.ewing.com", (string) object_0[2]);
            }
            base.WriteEndElement();
        }

        public void Write10_moInHeaders(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
        }

        public void Write2_accountInHeaders(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
        }

        public void Write3_updatePassword(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
            int length = object_0.Length;
            base.WriteStartElement("updatePassword", "http://service.ewing.com", null, false);
            if (length > 0)
            {
                base.WriteNullableStringLiteral("in0", "http://service.ewing.com", (string) object_0[0]);
            }
            if (length > 1)
            {
                base.WriteNullableStringLiteral("in1", "http://service.ewing.com", (string) object_0[1]);
            }
            if (length > 2)
            {
                base.WriteNullableStringLiteral("in2", "http://service.ewing.com", (string) object_0[2]);
            }
            if (length > 3)
            {
                base.WriteNullableStringLiteral("in3", "http://service.ewing.com", (string) object_0[3]);
            }
            base.WriteEndElement();
        }

        public void Write4_updatePasswordInHeaders(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
        }

        public void Write5_report(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
            int length = object_0.Length;
            base.WriteStartElement("report", "http://service.ewing.com", null, false);
            if (length > 0)
            {
                base.WriteNullableStringLiteral("in0", "http://service.ewing.com", (string) object_0[0]);
            }
            if (length > 1)
            {
                base.WriteNullableStringLiteral("in1", "http://service.ewing.com", (string) object_0[1]);
            }
            if (length > 2)
            {
                base.WriteNullableStringLiteral("in2", "http://service.ewing.com", (string) object_0[2]);
            }
            base.WriteEndElement();
        }

        public void Write6_reportInHeaders(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
        }

        public void Write7_smsSend(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
            int length = object_0.Length;
            base.WriteStartElement("smsSend", "http://service.ewing.com", null, false);
            if (length > 0)
            {
                base.WriteNullableStringLiteral("in0", "http://service.ewing.com", (string) object_0[0]);
            }
            if (length > 1)
            {
                base.WriteNullableStringLiteral("in1", "http://service.ewing.com", (string) object_0[1]);
            }
            if (length > 2)
            {
                base.WriteNullableStringLiteral("in2", "http://service.ewing.com", (string) object_0[2]);
            }
            if (length > 3)
            {
                base.WriteNullableStringLiteral("in3", "http://service.ewing.com", (string) object_0[3]);
            }
            if (length > 4)
            {
                base.WriteNullableStringLiteral("in4", "http://service.ewing.com", (string) object_0[4]);
            }
            if (length > 5)
            {
                base.WriteNullableStringLiteral("in5", "http://service.ewing.com", (string) object_0[5]);
            }
            if (length > 6)
            {
                base.WriteNullableStringLiteral("in6", "http://service.ewing.com", (string) object_0[6]);
            }
            if (length > 7)
            {
                base.WriteNullableStringLiteral("in7", "http://service.ewing.com", (string) object_0[7]);
            }
            if (length > 8)
            {
                base.WriteNullableStringLiteral("in8", "http://service.ewing.com", (string) object_0[8]);
            }
            base.WriteEndElement();
        }

        public void Write8_smsSendInHeaders(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
        }

        public void Write9_mo(object[] object_0)
        {
            base.WriteStartDocument();
            base.TopLevelElement();
            int length = object_0.Length;
            base.WriteStartElement("mo", "http://service.ewing.com", null, false);
            if (length > 0)
            {
                base.WriteNullableStringLiteral("in0", "http://service.ewing.com", (string) object_0[0]);
            }
            if (length > 1)
            {
                base.WriteNullableStringLiteral("in1", "http://service.ewing.com", (string) object_0[1]);
            }
            if (length > 2)
            {
                base.WriteNullableStringLiteral("in2", "http://service.ewing.com", (string) object_0[2]);
            }
            base.WriteEndElement();
        }
    }
}