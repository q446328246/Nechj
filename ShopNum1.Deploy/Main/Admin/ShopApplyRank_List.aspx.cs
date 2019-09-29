using System;
using System.Web.SessionState;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopApplyRank_List : PageBase, IRequiresSessionState
    {
        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            var action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
            if (action.Check(CheckGuid.Value.Replace("'", ""), "1") > 0)
            {
                if (action.UpdataShopRank(CheckGuid.Value.Replace("'", "")) > 0)
                {
                    Num1GridViewShow.DataBind();
                    MessageShow.Visible = true;
                    MessageShow.ShowMessage("OperateYes");
                }
                else
                {
                    MessageShow.Visible = true;
                    MessageShow.ShowMessage("OperateNo");
                }
            }
            else
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("OperateNo");
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
            if (action.Delete(CheckGuid.Value.Replace("'", "")) > 0)
            {
                Num1GridViewShow.DataBind();
                MessageShow.Visible = true;
                MessageShow.ShowMessage("DelYes");
            }
            else
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("DelNo");
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Num1GridViewShow.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
        }
    }
}