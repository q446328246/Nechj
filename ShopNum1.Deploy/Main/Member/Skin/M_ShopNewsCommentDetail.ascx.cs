using System;
using System.Data;
using ShopNum1.Deploy.App_Code;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_ShopNewsCommentDetail : BaseMemberControl
    {
        protected void ButtonGoBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("M_Comment.aspx?type=4&pageid=1");
        }

        public void GetData(string guid)
        {
            DataTable newsCommentDetail =
                ((Shop_News_Action) LogicFactory.CreateShop_News_Action()).GetNewsCommentDetail(guid);
            if ((newsCommentDetail != null) && (newsCommentDetail.Rows.Count > 0))
            {
                RepeaterShow.DataSource = newsCommentDetail.DefaultView;
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