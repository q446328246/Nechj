using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_ShopNewsCommentDetail : BaseMemberWebControl
    {
        private Button ButtonGoBack;
        private Repeater RepeaterShow;
        private string skinFilename = "M_ShopNewsCommentDetail.ascx";

        public M_ShopNewsCommentDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private void ButtonGoBack_Click(object sender, EventArgs e)
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