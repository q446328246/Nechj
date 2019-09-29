using System;
using System.Data;
using ShopNum1.Deploy.App_Code;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_ShopVideoCommentDetail : BaseMemberControl
    {
        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_Comment.aspx?type=1&pageid=1");
        }

        public void GetData(string guid)
        {
            DataTable videoCommentDetail =
                ((Shop_VideoComment_Action) LogicFactory.CreateShop_VideoComment_Action()).GetVideoCommentDetail(guid);
            if ((videoCommentDetail != null) && (videoCommentDetail.Rows.Count > 0))
            {
                RepeaterShow.DataSource = videoCommentDetail.DefaultView;
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