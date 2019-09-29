using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopVedioCommentChecked_Operate : PageBase, IRequiresSessionState
    {
        private string GoBack { get; set; }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (GoBack == "List")
            {
                base.Response.Redirect("ShopVedioComment_List.aspx");
            }
            else
            {
                base.Response.Redirect("ShopVedioCommentChecked_List.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            GoBack = (base.Request.QueryString["Type"] == null) ? "0" : base.Request.QueryString["Type"];
            DataTable table =
                ((ShopNum1_VedioCommentChecked_Action) LogicFactory.CreateShopNum1_VedioCommentChecked_Action())
                    .SearchByGuid(hiddenFieldGuid.Value);
            if ((table != null) && (table.Rows.Count > 0))
            {
                TextBoxContent.Text = table.Rows[0]["Comment"].ToString();
                TextBoxTitle.Text = table.Rows[0]["Title"].ToString();
                TextBoxTime.Text = table.Rows[0]["CommentTime"].ToString();
                TextBoxUser.Text = table.Rows[0]["MemLoginID"].ToString();
                TextBoxIP.Text = table.Rows[0]["IPAddress"].ToString();
                TextBoxVideo.Text = table.Rows[0]["Name"].ToString();
                TextBoxMember.Text = ShopSettings.GetValue("PersonShopUrl") + table.Rows[0]["ShopID"];
            }
        }
    }
}