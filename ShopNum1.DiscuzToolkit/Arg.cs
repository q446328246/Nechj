using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    public class Arg
    {
        [XmlElement("key")] public string Key;
        [XmlElement("value")] public string Value;

        public Arg()
        {
        }

        public Arg(string string_0, string value)
        {
            Key = string_0;
            Value = value;
        }
    }
}