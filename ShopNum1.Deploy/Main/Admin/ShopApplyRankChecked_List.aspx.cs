using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopApplyRankChecked_List : PageBase, IRequiresSessionState
    {
        protected HttpApplication ApplicationInstance
        {
            get { return Context.ApplicationInstance; }
        }

        protected DefaultProfile Profile
        {
            get { return (DefaultProfile) Context.Profile; }
        }

        protected void BindProductIsAduit()
        {
            DropDownListIsAudit.Items.Clear();
            DropDownListIsAudit.Items.Add(new ListItem("-全部-", "-2"));
            DropDownListIsAudit.Items.Add(new ListItem("审核未通过", "2"));
            DropDownListIsAudit.Items.Add(new ListItem("未审核", "0"));
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            var action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
            if (action.Check(CheckGuid.Value.Replace("'", ""), "1") > 0)
            {
                string[] strArray = CheckGuid.Value.Replace("'", "").Split(new[] {','});
                int num2 = 0;
                for (int i = 0; i < strArray.Length; i++)
                {
                    num2 += action.UpdataShopRank(strArray[i]);
                }
                if (num2 == strArray.Length)
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
            var action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
            if (action.Check(CheckGuid.Value.Replace("'", ""), "2") > 0)
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

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
            if (action.Delete("'" + CheckGuid.Value.Replace("'", "") + "'") > 0)
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

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string iD = "'" + button.CommandArgument + "'";
            var action = (Shop_ShopApplyRank_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
            if (action.Delete(iD) > 0)
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

        protected string IsAudit(object object_0)
        {
            if (object_0.ToString() == "0")
            {
                return "未审核";
            }
            if (object_0.ToString() == "1")
            {
                return "已通过";
            }
            if (object_0.ToString() == "2")
            {
                return "审核未通过";
            }
            return "非法状态";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindProductIsAduit();
            }
        }
    }

}