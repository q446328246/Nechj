using System.Xml.Serialization;

namespace ShopNum1.DiscuzToolkit
{
    public class Location
    {
        [XmlElement("city")] public string City;
        [XmlElement("country")] public string Country;
        [XmlElement("state")] public string State;
        [XmlElement("street")] public string Street;
        [XmlElement("zip")] public string Zip;
    }
}