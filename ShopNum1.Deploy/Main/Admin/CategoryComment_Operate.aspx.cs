using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryComment_Operate : PageBase, IRequiresSessionState
    {
        private readonly ShopNum1_CategoryComment_Action shopNum1_CategoryComment_Action_0 =
            ((ShopNum1_CategoryComment_Action) LogicFactory.CreateShopNum1_CategoryComment_Action());

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            switch (((Page.Request.QueryString["type"] == null) ? "-1" : Page.Request.QueryString["type"]))
            {
                case "audit":
                    Page.Response.Redirect("CategoryCommentAudit_List.aspx");
                    break;

                case "list":
                    Page.Response.Redirect("CategoryComment_List.aspx");
                    break;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (
                shopNum1_CategoryComment_Action_0.CategoryCommentReply(hiddenFieldGuid.Value.Replace("'", ""),
                                                                       TextBoxReplyContent.Text.Trim()) > 0)
            {
                Page.Response.Redirect("CategoryComment_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        public void BindData()
        {
            DataTable categoryCommentByGuid =
                shopNum1_CategoryComment_Action_0.GetCategoryCommentByGuid(hiddenFieldGuid.Value);
            TextBoxContent.Text = categoryCommentByGuid.Rows[0]["Content"].ToString();
            TextBoxTitle.Text = categoryCommentByGuid.Rows[0]["Title"].ToString();
            TextBoxTime.Text = categoryCommentByGuid.Rows[0]["CreateTime"].ToString();
            TextBoxUser.Text = categoryCommentByGuid.Rows[0]["CreateMember"].ToString();
            TextBoxIP.Text = categoryCommentByGuid.Rows[0]["CreateIP"].ToString();
            FCKeditorContent.Value=
                HttpContext.Current.Server.HtmlDecode(categoryCommentByGuid.Rows[0]["CategoryInfo"].ToString());
            TextBoxMember.Text = categoryCommentByGuid.Rows[0]["AssociatedMemberID"].ToString();
            TextBoxReplyContent.Text = categoryCommentByGuid.Rows[0]["Reply"].ToString();
            if (categoryCommentByGuid.Rows[0]["Reply"].ToString() != string.Empty)
            {
                TextBoxReplyContent.ReadOnly = true;
                ButtonConfirm.Enabled = false;
            }
            string str = (Page.Request.QueryString["type"] == null) ? "-1" : Page.Request.QueryString["type"];
            if (str == "audit")
            {
                TextBoxReplyContent.ReadOnly = true;
                ButtonConfirm.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
    }
}