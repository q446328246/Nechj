using System.Web.UI;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_PageGo : BaseShopWebControl
    {
        private string skinFilename = "S_PageGo.ascx";

        public S_PageGo()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            string text = Common.Common.ReqStr("pagetype");
            string text2 = text;
            switch (text2)
            {
                case "0":
                    Page.Response.Redirect("S_SellGoods_One.aspx?sign=go&op=add&step=one");
                    break;
                case "1":
                    Page.Response.Redirect("TbTop/TbAuthorization.aspx");
                    break;
                case "2":
                    Page.Response.Redirect("TbTop/TbStep_Set.aspx");
                    break;
                case "3":
                    Page.Response.Redirect("TbTop/TbProductCategory_List.aspx");
                    break;
                case "4":
                    Page.Response.Redirect("TbTop/TbToSite_Operate.aspx");
                    break;
                case "5":
                    Page.Response.Redirect("TbTop/TbPrdouctView.aspx");
                    break;
                case "6":
                    Page.Response.Redirect("TbTop/TbOrderView.aspx");
                    break;
                case "7":
                    Page.Response.Redirect("TbTop/TbRemoveShopBind.aspx");
                    break;
                case "8":
                    Page.Response.Redirect("TbTop/TbSetAppKey.aspx");
                    break;
            }
        }
    }
}