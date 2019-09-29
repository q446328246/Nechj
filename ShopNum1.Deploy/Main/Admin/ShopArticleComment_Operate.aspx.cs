using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopArticleComment_Operate : PageBase, IRequiresSessionState
    {
        private string GoBack { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            GoBack = (base.Request.QueryString["Type"] == null) ? "0" : base.Request.QueryString["Type"];
            DataTable table =
                ((ShopNum1_ShopArticleComment_Action)LogicFactory.CreateShopNum1_ShopArticleComment_Action())
                    .SearchByGuid(hiddenFieldGuid.Value);
            if ((table != null) && (table.Rows.Count > 0))
            {
                TextBoxContent.Text = table.Rows[0]["Content"].ToString();
                TextBoxTitle.Text = table.Rows[0]["Title"].ToString();
                TextBoxTime.Text = table.Rows[0]["CommentTime"].ToString();
                TextBoxUser.Text = table.Rows[0]["MemLoginID"].ToString();
                TextBoxIP.Text = table.Rows[0]["IPAddress"].ToString();
                TextBoxArticle.Text = table.Rows[0]["ArticleTitle"].ToString();
                string str = Common.Common.GetNameById("MemLoginID", "ShopNum1_ShopInfo",
                                                       "    AND  ShopID='" + table.Rows[0]["ShopID"] + "'");
                if (!string.IsNullOrEmpty(str))
                {
                    TextBoxMember.Text = str;
                }
                TextBoxReply.Text = table.Rows[0]["ReplyContent"].ToString();
                if (table.Rows[0]["IsReply"].ToString() == "1")
                {
                    TextBoxReply.ReadOnly = true;
                    ButtonConfirm.Enabled = false;
                }
            }
            if (GoBack == "Audit")
            {
                ButtonConfirm.Visible = false;
                inputReset.Visible = false;
                TextBoxReply.Visible = false;
                LabelReply.Visible = false;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (GoBack == "Audit")
            {
                base.Response.Redirect("ShopArticleCommentAudit_List.aspx");
            }
            else if (GoBack == "List")
            {
                base.Response.Redirect("ShopArticleComment_List.aspx");
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var articleComment = new ShopNum1_ArticleComment
                {
                    ReplyUser = base.ShopNum1LoginID,
                    ReplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    ReplyContent = TextBoxReply.Text.Trim(),
                    IsReply = 1
                };
            var action = (ShopNum1_ShopArticleComment_Action) LogicFactory.CreateShopNum1_ShopArticleComment_Action();
            if (action.Update(articleComment) > 0)
            {
                MessageShow.ShowMessage("EditYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }


    }
}