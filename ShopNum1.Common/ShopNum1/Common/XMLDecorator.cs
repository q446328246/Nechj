using System.Text;

namespace ShopNum1.Common
{
    public class XMLDecorator : XMLComponent
    {
        protected XMLComponent ActualXMLComponent;
        private string strDecoratorName;

        public XMLDecorator(string str)
        {
            strDecoratorName = str;
        }

        public void GetSettingFromComponent(XMLComponent xc)
        {
            base.FileEncode = xc.FileEncode;
            base.FileOutPath = xc.FileOutPath;
            base.Indentation = xc.Indentation;
            base.SourceDataTable = xc.SourceDataTable;
            base.StartElement = xc.StartElement;
            base.Version = xc.Version;
            base.XslLink = xc.XslLink;
            base.Key = xc.Key;
            base.ParentField = xc.ParentField;
        }

        public void SetXMLComponent(XMLComponent xc)
        {
            ActualXMLComponent = xc;
            GetSettingFromComponent(xc);
        }

        public override string WriteFile()
        {
            if (ActualXMLComponent != null)
            {
                ActualXMLComponent.WriteFile();
            }
            return null;
        }

        public override StringBuilder WriteStringBuilder()
        {
            if (ActualXMLComponent != null)
            {
                return ActualXMLComponent.WriteStringBuilder();
            }
            return null;
        }
    }
}