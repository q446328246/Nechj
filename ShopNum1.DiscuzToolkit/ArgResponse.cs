using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    public class ArgResponse
    {
        [XmlElement("arg")] public Arg[] Args;
        [XmlAttribute("list")] public bool List;
    }
}