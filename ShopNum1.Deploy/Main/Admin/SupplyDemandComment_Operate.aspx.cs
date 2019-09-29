using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class SupplyDemandComment_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                            ? "0"
                                            : base.Request.QueryString["guid"];
                BindData();
                if ((base.Request.QueryString["goback"] != null) && (base.Request.QueryString["goback"] == "sh"))
                {
                    ButtonSubmit.Visible = false;
                }
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if ((base.Request.QueryString["goback"] != null) && (base.Request.QueryString["goback"] == "sh"))
            {
                Page.Response.Redirect("SupplyDemandCommentAudit_List.aspx");
            }
            else
            {
                Page.Response.Redirect("SupplyDemandComment_List.aspx");
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_SupplyDemandComment_Action) LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
            if (
                action.ReplySupplyDemandComment(hiddenFieldGuid.Value.Replace("'", ""), TextBoxReplyContent.Text.Trim()) >
                0)
            {
                Page.Response.Redirect("SupplyDemandComment_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        public void BindData()
        {
            DataTable table =
                ((ShopNum1_SupplyDemandComment_Action) LogicFactory.CreateShopNum1_SupplyDemandComment_Action())
                    .SearchByGuid(hiddenFieldGuid.Value);
            TextBoxContent.Text = table.Rows[0]["Content"].ToString();
            TextBoxTitle.Text = table.Rows[0]["Title"].ToString();
            TextBoxTime.Text = table.Rows[0]["CreateTime"].ToString();
            TextBoxUser.Text = table.Rows[0]["CreateMerber"].ToString();
            TextBoxIP.Text = table.Rows[0]["CreateIP"].ToString();
            TextBoxSupplyTitle.Text = table.Rows[0]["CommentTitle"].ToString();
            FCKeditorDetail.Text = HttpContext.Current.Server.HtmlDecode(table.Rows[0]["ConmetContent"].ToString());
            TextBoxMember.Text = table.Rows[0]["AssociateMemberID"].ToString();
            TextBoxReplyContent.Text = table.Rows[0]["Reply"].ToString();
            if (table.Rows[0]["Reply"].ToString() != string.Empty)
            {
                TextBoxReplyContent.ReadOnly = true;
                ButtonSubmit.Enabled = false;
            }
            string str = (Page.Request.QueryString["type"] == null) ? "-1" : Page.Request.QueryString["type"];
            if (str == "audit")
            {
                TextBoxReplyContent.ReadOnly = true;
                ButtonSubmit.Visible = false;
            }
            ButtonSubmit.Text = "¸üÐÂ";
        }


    }
}