using System.Collections;
using System.Drawing;
using System.Drawing.Text;

namespace ShopNum1.Common
{
    public static class WaterMarkFont
    {
        public static ArrayList Font()
        {
            var list = new ArrayList();
            var fonts = new InstalledFontCollection();
            foreach (FontFamily family in fonts.Families)
            {
                list.Add(family.Name);
            }
            return list;
        }
    }
}