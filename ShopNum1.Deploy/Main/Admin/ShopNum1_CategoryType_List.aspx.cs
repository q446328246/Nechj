using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_CategoryType_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopNum1_CategoryType_Operate.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            if (action.DeleteTypeC(CheckGuid.Value) > 0)
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
            string commandArgument = button.CommandArgument;
            var action = (ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action();
            if (action.DeleteTypeC("'" + commandArgument + "'") > 0)
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
            base.Response.Redirect("ShopNum1_CategoryType_Operate.aspx?guid=" + CheckGuid.Value.Replace("'", ""));
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void DropDownListIsShowBing()
        {
            DropDownListIsShow.Items.Clear();
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "-1"
                };
            DropDownListIsShow.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "显示",
                    Value = "1"
                };
            DropDownListIsShow.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "不显示",
                    Value = "0"
                };
            DropDownListIsShow.Items.Add(item3);
        }

        protected string IsShow(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "不显示";
            }
            if (object_0.ToString() == "1")
            {
                return "显示";
            }
            return "非法状态";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                DropDownListIsShowBing();
                BindGrid();
            }
        }
    }
}