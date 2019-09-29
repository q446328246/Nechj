using System.Collections.Generic;

namespace ShopNum1.WeiXinCommon.model
{
    public class MenuButton
    {
        public List<MenuButton> SubButton = new List<MenuButton>();

        public string Name { get; set; }

        public string Sort { get; set; }

        public string Value { get; set; }
    }
}