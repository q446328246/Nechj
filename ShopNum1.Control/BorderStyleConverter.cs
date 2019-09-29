using System.ComponentModel;

namespace ShopNum1.Control
{
    public class BorderStyleConverter : StringConverter
    {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return
                new StandardValuesCollection(new[]
                    {
                        "none", "dotted", "dashed", "solid", "double", "groove", "ridge", "inset", "window-inset",
                        "outset"
                    });
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