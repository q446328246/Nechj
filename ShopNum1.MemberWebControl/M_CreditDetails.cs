using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_CreditDetails : BaseMemberWebControl
    {
        private Panel PanelRankScoreModifyLog;
        private Panel PanelScoreModifyLog;
        private string skinFilename = "M_CreditDetails.ascx";

        public M_CreditDetails()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            PanelRankScoreModifyLog = (Panel) skin.FindControl("PanelRankScoreModifyLog");
            PanelScoreModifyLog = (Panel) skin.FindControl("PanelScoreModifyLog");
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