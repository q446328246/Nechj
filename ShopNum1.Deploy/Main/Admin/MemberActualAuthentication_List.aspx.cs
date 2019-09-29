using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class MemberActualAuthentication_List : PageBase, IRequiresSessionState
    {
        protected void butDel_Click(object sender, EventArgs e)
        {
            string strGuId = CheckGuid.Value;
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            if (action.DeleteRealName(strGuId) > 0)
            {
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
            BindData();
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string strGuId = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            if (action.DeleteRealName(strGuId) > 0)
            {
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
            BindData();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonSearchShop_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MemberActualAuthentication_Operate.aspx?guid=" + CheckGuid.Value);
        }

        public string Is(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "1")
            {
                return "审核已通过";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        private void BindData()
        {
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
            }
        }
    }
}