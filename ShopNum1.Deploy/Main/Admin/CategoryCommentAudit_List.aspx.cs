using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryCommentAudit_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_CategoryComment_Action) LogicFactory.CreateShopNum1_CategoryComment_Action();
            if (action.UpdateCategoryCommentAudit(CheckGuid.Value, "1") > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("Audit1Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit1No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_CategoryComment_Action) LogicFactory.CreateShopNum1_CategoryComment_Action();
            if (action.UpdateCategoryCommentAudit(CheckGuid.Value, "2") > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryComment_Operate.aspx?guid=" + CheckGuid.Value + "&&type=audit");
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "1")
            {
                return "ÒÑÉóºË";
            }
            if (object_0.ToString() == "0")
            {
                return "Î´ÉóºË";
            }
            return "ÉóºËÎ´Í¨¹ý";
        }

        private void BindData()
        {
            var item = new ListItem
                {
                    Text = "-È«²¿-",
                    Value = "-2"
                };
            DropDownListIsAudit.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "Î´ÉóºË",
                    Value = "0"
                };
            DropDownListIsAudit.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "ÉóºËÎ´Í¨¹ý",
                    Value = "2"
                };
            DropDownListIsAudit.Items.Add(item3);
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