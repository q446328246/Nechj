using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopInfo : BaseShopWebControl
    {
        private Panel PanelClassify;
        private Panel PanelCompany;
        private Panel PanelShopMap;
        private Panel PanelShowSettings;
        private string skinFilename = "S_ShopInfo.ascx";

        public S_ShopInfo()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            PanelShowSettings = (Panel) skin.FindControl("PanelShowSettings");
            PanelCompany = (Panel) skin.FindControl("PanelCompany");
            PanelClassify = (Panel) skin.FindControl("PanelClassify");
            PanelShopMap = (Panel) skin.FindControl("PanelShopMap");
            if (Page.Request.QueryString["type"] == null)
            {
                PanelShowSettings.Visible = true;
            }
            else
            {
                string str = Page.Request.QueryString["type"];
                switch (str)
                {
                    case null:
                        break;

                    case "0":
                        PanelShowSettings.Visible = true;
                        return;

                    case "1":
                        PanelCompany.Visible = true;
                        return;

                    default:
                        if (!(str == "2"))
                        {
                            if (!(str == "3"))
                            {
                                break;
                            }
                            PanelShopMap.Visible = true;
                        }
                        else
                        {
                            PanelClassify.Visible = true;
                        }
                        return;
                }
                PanelShowSettings.Visible = true;
            }
        }
    }
}