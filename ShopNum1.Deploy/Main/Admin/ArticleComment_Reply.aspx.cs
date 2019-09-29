using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ArticleComment_Reply : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                if (hiddenGuid.Value != "0")
                {
                    GetEditInfo();
                }
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("ArticleComment_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var articleComment = new ShopNum1_ArticleComment();
            var action = (ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action();
            articleComment.Guid = new Guid(hiddenGuid.Value.Replace("'", ""));
            articleComment.ReplyUser = base.ShopNum1LoginID;
            articleComment.ReplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            articleComment.ReplyContent = TextBoxReplyContent.Text.Trim();
            articleComment.IsReply = 1;
            if (action.Update(articleComment) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "回复评论信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ArticleComment_Reply.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("EditYes");
                MessageShow.Visible = true;
                ButtonConfirm.Visible = false;
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        public string ChangeIsAudit(string strIsAudit)
        {
            if (strIsAudit == "0")
            {
                return "未审核";
            }
            if (strIsAudit == "1")
            {
                return "已审核";
            }
            return "";
        }

        public string ChangeIsReply(string strIsReply)
        {
            if (strIsReply == "0")
            {
                return "未回复";
            }
            if (strIsReply == "1")
            {
                return "已回复";
            }
            return "";
        }

        protected void GetEditInfo()
        {
            DataTable table =
                ((ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action()).SearchByGuid(
                    hiddenGuid.Value);
            TextBoxArticleGuidValue.Text = table.Rows[0]["ArticleTitle"].ToString();
            TextBoxTitleValue.Text = table.Rows[0]["Title"].ToString();
            TextBoxMemLoginIDValue.Text = table.Rows[0]["MemLoginID"].ToString();
            TextBoxSendTimeValue.Text = table.Rows[0]["SendTime"].ToString();
            TextBoxIPAddressValue.Text = table.Rows[0]["IPAddress"].ToString();
            TextBoxRankValue.Text = table.Rows[0]["Rank"].ToString();
            TextBoxReplyUserValue.Text = table.Rows[0]["ReplyUser"].ToString();
            TextBoxReplyTimeValue.Text = table.Rows[0]["ReplyTime"].ToString();
            TextBoxContent.Text = table.Rows[0]["Content"].ToString();
            TextBoxReplyContent.Text = table.Rows[0]["ReplyContent"].ToString();
            if (table.Rows[0]["IsReply"].ToString() == "1")
            {
                TextBoxIsReplyValue.Text = ChangeIsReply("1");
                TextBoxReplyContent.ReadOnly = true;
                ButtonConfirm.Enabled = false;
            }
            else
            {
                TextBoxIsReplyValue.Text = ChangeIsReply("0");
            }
            if (table.Rows[0]["IsAudit"].ToString() == "1")
            {
                TextBoxIsAuditValue.Text = ChangeIsAudit("1");
            }
            else
            {
                TextBoxIsAuditValue.Text = ChangeIsAudit("0");
            }
        }
    }
}