using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_SupplyDemandCommentDetail : BaseMemberWebControl
    {
        private Button ButtonGoBack;
        private Repeater RepeaterShow;
        private string skinFilename = "M_SupplyDemandCommentDetail.ascx";

        public M_SupplyDemandCommentDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private void ButtonGoBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_Comment.aspx?type=0&pageid=1");
        }

        public void GetData(string guid)
        {
            DataTable table =
                ((ShopNum1_SupplyDemandComment_Action) LogicFactory.CreateShopNum1_SupplyDemandComment_Action())
                    .SearchByGuid("'" + guid + "'");
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterShow.DataSource = table.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            ButtonGoBack = (Button) skin.FindControl("ButtonGoBack");
            ButtonGoBack.Click += ButtonGoBack_Click;
            if (Page.Request.QueryString["guid"] != null)
            {
                GetData(Page.Request.QueryString["guid"]);
            }
        }
    }
}