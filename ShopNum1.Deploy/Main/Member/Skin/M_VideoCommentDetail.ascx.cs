using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_VideoCommentDetail : BaseMemberControl
    {
        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_Comment.aspx?type=2&pageid=1");
        }

        public void GetData(string guid)
        {
            DataTable videoCommentDetailByGuid =
                ((ShopNum1_VedioCommentChecked_Action) LogicFactory.CreateShopNum1_VedioCommentChecked_Action())
                    .GetVideoCommentDetailByGuid(guid);
            if ((videoCommentDetailByGuid != null) && (videoCommentDetailByGuid.Rows.Count > 0))
            {
                RepeaterShow.DataSource = videoCommentDetailByGuid.DefaultView;
                RepeaterShow.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["guid"] != null)
            {
                GetData(Page.Request.QueryString["guid"]);
            }
        }
    }
}
