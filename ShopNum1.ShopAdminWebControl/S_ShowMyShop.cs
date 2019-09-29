using System.Data;
using System.Web.UI;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShowMyShop : BaseMemberWebControl
    {
        private string skinFilename = "S_ShowMyShop.ascx";

        public S_ShowMyShop()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string GetUrl()
        {
            DataTable shopIDByMemLoginID =
                LogicFactory.CreateShopNum1_ShopInfoList_Action().GetShopIDByMemLoginID(base.MemLoginID);
            string str = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (shopIDByMemLoginID.Rows.Count > 0)
            {
                str = shopIDByMemLoginID.Rows[0]["ShopUrl"].ToString();
                str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
                if (base.MemLoginID == "C0000001")
                {
                    str3 = "?category=1";
                }
                else 
                {
                    str3 = "?category=9";
                }
            }
            
            
            return ("http://" + str + str2+str3);
        }

        protected override void InitializeSkin(Control skin)
        {
            Page.Response.Redirect(GetUrl());
        }
    }
}