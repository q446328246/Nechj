using System;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_MyCollect : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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