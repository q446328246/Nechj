using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopOpenStep3 : BaseMemberWebControl
    {
        private Label LabelAuditFailedReason;
        private Label LabelAuditTime;
        private Label LabelOperateUser;
        private Label LabelShow;
        private HtmlGenericControl OpenLink;
        private HtmlGenericControl showCss;
        private HtmlGenericControl showFailedReason;
        private string skinFilename = "S_ShopOpenStep3.ascx";

        public S_ShopOpenStep3()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            OpenLink = (HtmlGenericControl) skin.FindControl("OpenLink");
            LabelShow = (Label) skin.FindControl("LabelShow");
            showCss = (HtmlGenericControl) skin.FindControl("showCss");
            showFailedReason = (HtmlGenericControl) skin.FindControl("showFailedReason");
            LabelOperateUser = (Label) skin.FindControl("LabelOperateUser");
            LabelAuditTime = (Label) skin.FindControl("LabelAuditTime");
            LabelAuditFailedReason = (Label) skin.FindControl("LabelAuditFailedReason");
            DataTable shopByMemLoginID =
                ((ShopNum1_ShopInfoList_Action) LogicFactory.CreateShopNum1_ShopInfoList_Action()).GetShopByMemLoginID(
                    base.MemLoginID);
            int num = 0;
            if ((shopByMemLoginID != null) && (shopByMemLoginID.Rows.Count > 0))
            {
                num = Convert.ToInt32(shopByMemLoginID.Rows[0]["IsAudit"].ToString());
                LabelOperateUser.Text = shopByMemLoginID.Rows[0]["OperateUser"].ToString();
                LabelAuditTime.Text = shopByMemLoginID.Rows[0]["AuditTime"].ToString();
                LabelAuditFailedReason.Text = shopByMemLoginID.Rows[0]["AuditFailedReason"].ToString();
            }
            if (num == 2)
            {
                showFailedReason.Visible = true;
                OpenLink.Visible = false;
                LabelShow.Text = "店铺审核未通过！";
                showCss.Attributes["class"] = "dianpsh1";
            }
        }
    }
}