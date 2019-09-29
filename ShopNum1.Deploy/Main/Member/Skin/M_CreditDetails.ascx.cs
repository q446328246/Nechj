using System;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_CreditDetails : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (((Common.Common.ReqStr("type") == "") ? "0" : Common.Common.ReqStr("type")))
            {
                case "0":
                    PanelScoreModifyLog.Visible = true;
                    PanelRankScoreModifyLog.Visible = false;
                    break;

                case "1":
                    PanelScoreModifyLog.Visible = false;
                    PanelRankScoreModifyLog.Visible = true;
                    break;
            }
        }
    }
}