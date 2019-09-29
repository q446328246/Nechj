using System.Xml;
using System.Xml.Serialization;

namespace Microsoft.Xml.Serialization.GeneratedAssembly
{
    public sealed class ArrayOfObjectSerializer18 : XmlSerializer1
    {
        public override bool CanDeserialize(XmlReader xmlReader)
        {
            return xmlReader.IsStartElement("moInHeaders", "http://service.ewing.com");
        }

        protected override void Serialize(object objectToSerialize, XmlSerializationWriter writer)
        {
            ((XmlSerializationWriterISmsService) writer).Write10_moInHeaders((object[]) objectToSerialize);
        }
    }
}