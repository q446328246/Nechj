using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryComment_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_CategoryComment_Action) LogicFactory.CreateShopNum1_CategoryComment_Action();
            if (action.DeleteCategoryComment(CheckGuid.Value) > 0)
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
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_CategoryComment_Action) LogicFactory.CreateShopNum1_CategoryComment_Action();
            if (action.DeleteCategoryComment(guids) > 0)
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryComment_Operate.aspx?guid=" + CheckGuid.Value + "&&type=list");
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "“—…Û∫À";
            }
            if (object_0.ToString() == "0")
            {
                return "Œ¥…Û∫À";
            }
            return "…Û∫ÀŒ¥Õ®π˝";
        }

        private void BindData()
        {
            var item = new ListItem
                {
                    Text = "“—…Û∫À",
                    Value = "1"
                };
            DropDownListIsAudit.Items.Add(item);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
                BindGrid();
            }
        }
    }
}