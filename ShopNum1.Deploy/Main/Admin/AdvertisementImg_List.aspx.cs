using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.AdXml;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvertisementImg_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();

            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("AdvertisementImg_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var operate = new DefaultAdvertismentOperate();
            if (operate.Delete(CheckGuid.Value) > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var operate = new DefaultAdvertismentOperate();
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            if (operate.Delete(commandArgument) > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("AdvertisementImg_Operate.aspx?guid=" + CheckGuid.Value);
        }
    }
}