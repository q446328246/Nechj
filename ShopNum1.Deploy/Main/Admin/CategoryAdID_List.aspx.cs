using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryAdID_List : PageBase, IRequiresSessionState
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
            base.Response.Redirect("CategoryAdID_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int num =
                ((ShopNum1_CategoryAdID_Action) LogicFactory.CreateShopNum1_CategoryAdID_Action()).Delete(
                    CheckGuid.Value);
            if (num == -2)
            {
                MessageBox.Show("广告位下面有广告，请先删除广告后再删除广告位!");
            }
            else if (num > 0)
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
            var action = (ShopNum1_CategoryAdID_Action) LogicFactory.CreateShopNum1_CategoryAdID_Action();
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            if (action.Delete(commandArgument) > 0)
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
            base.Response.Redirect("CategoryAdID_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ButtonSearchDetail_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryAdID_SearchDetail.aspx?guid=" + CheckGuid.Value);
        }



        public string PageName(object object_0)
        {
            switch (object_0.ToString())
            {
                case "1":
                    return "商品分类";

                case "2":
                    return "分类信息分类";

                case "3":
                    return "供求分类";

                case "4":
                    return "店铺分类";

                case "5":
                    return "资讯分类";

                case "6":
                    return "品牌分类";
            }
            return "非法页面";
        }
    }
}