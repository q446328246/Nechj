using System.Collections;
using System.ComponentModel;

namespace ShopNum1.Control
{
    public class CanBeNullControlsConverter : StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var values = new ArrayList();
            values.Add("可为空");
            values.Add("必填");
            return new StandardValuesCollection(values);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}