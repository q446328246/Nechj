using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class DefaultAd_List : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string AdType(object object_0)
        {
            string str = "";
            string str2 = object_0.ToString();
            switch (str2)
            {
                case null:
                    return str;

                case "0":
                    return "ÎÄ×Ö";

                case "1":
                    return "Í¼Æ¬";
            }
            if (!(str2 == "2"))
            {
                if (str2 == "3")
                {
                    str = "flash";
                }
                return str;
            }
            return "»ÃµÆÆ¬";
        }

        public void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("DefaultAd_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_DefaultAdImg_Action) LogicFactory.CreateShopNum1_DefaultAdImg_Action();
            if (action.Delete(CheckGuid.Value))
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
            var action = (ShopNum1_DefaultAdImg_Action) LogicFactory.CreateShopNum1_DefaultAdImg_Action();
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            if (action.Delete(commandArgument))
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
            base.Response.Redirect("DefaultAd_Operate.aspx?guid=" + CheckGuid.Value);
        }


    }
}