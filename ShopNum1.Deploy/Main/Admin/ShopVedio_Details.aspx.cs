using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopVedio_Details : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string guid = base.Request.QueryString["guid"];
            DataTable shopVideoByGuid =
                ((ShopNum1_VedioCommentChecked_Action) LogicFactory.CreateShopNum1_VedioCommentChecked_Action())
                    .GetShopVideoByGuid(guid);
            if ((shopVideoByGuid != null) && (shopVideoByGuid.Rows.Count > 0))
            {
                this.TextBoxCreateTime.Text = shopVideoByGuid.Rows[0]["CreateTime"].ToString();
                TextBoxTitle.Text = shopVideoByGuid.Rows[0]["Title"].ToString();
                this.Image.ImageUrl = shopVideoByGuid.Rows[0]["ImgAdd"].ToString();
                this.TextBoxVideo.Text = shopVideoByGuid.Rows[0]["VideoAdd"].ToString();
                this.LiteralShowVodie.Text = shopVideoByGuid.Rows[0]["VideoAdd"].ToString();
                this.TextBoxKeywords.Text = shopVideoByGuid.Rows[0]["KeyWords"].ToString();
                this.TextBoxCategoryGuid.Text = shopVideoByGuid.Rows[0]["name"].ToString();
                this.TextBoxMemberLoginID.Text = shopVideoByGuid.Rows[0]["MemLoginID"].ToString();
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (
                !(string.IsNullOrEmpty(Page.Request.QueryString["type"]) ||
                  !(Page.Request.QueryString["type"] == "Checked")))
            {
                Page.Response.Redirect("ShopVedioChecked_List.aspx");
            }
            else
            {
                Page.Response.Redirect("ShopVedio_List.aspx");
            }
        }
    }
}