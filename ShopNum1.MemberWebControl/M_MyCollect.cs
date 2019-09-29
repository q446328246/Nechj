using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_MyCollect : BaseMemberWebControl
    {
        private Panel PanelMemberProductCollect;
        private Panel PanelShopCollect;
        private string skinFilename = "M_MyCollect.ascx";

        public M_MyCollect()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            PanelMemberProductCollect = (Panel) skin.FindControl("PanelMemberProductCollect");
            PanelShopCollect = (Panel) skin.FindControl("PanelShopCollect");
            switch (((Common.Common.ReqStr("type") == "") ? "0" : Common.Common.ReqStr("type")))
            {
                case "0":
                    PanelMemberProductCollect.Visible = true;
                    PanelShopCollect.Visible = false;
                    break;

                case "1":
                    PanelMemberProductCollect.Visible = false;
                    PanelShopCollect.Visible = true;
                    break;
            }
        }
    }
}