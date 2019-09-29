using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AdvanceSettlementApplyLog_Operate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public string ChangeOperateStatus(string operateStatus)
        {
            if (operateStatus == "0")
            {
                return " 未发放";// LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "0");
            }
            if (operateStatus == "1")
            {
                return " 已发放";// LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "1");
            }
            if (operateStatus == "2")
            {
                return " 不满足发放条件";// LocalizationUtil.GetChangeMessage("AdvancePaymentApplyLog_List", "OperateStatus", "1");
            }
            return "确认状态";
        }

        protected void ButtonProportionBylink_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument.ToString();

            if (id != "" && id != null)
            {

                ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = new ShopNum1_AdvancePaymentApplyLog_Action();

                int num = shopNum1_AdvancePaymentApplyLog_Action.UpdateJsZt(id);

                if (num >2)
                {
                    Response.Write("<script>alert('结算成功')</script>");

                    Num1GridViewShow.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('不满足发放条件')</script>");
                    Num1GridViewShow.DataBind();
                }
            }

        }

        protected void ButtonIdentificationBylink_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument.ToString();

            if (id != "" && id != null)
            {

                ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = new ShopNum1_AdvancePaymentApplyLog_Action();

                int num = shopNum1_AdvancePaymentApplyLog_Action.IdentificationJsZt(id);

                if (num != -1)
                {
                    Response.Write("<script>alert('状态已更改')</script>");

                    Num1GridViewShow.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('操作失败')</script>");
                }
            }

        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument.ToString();

            if (id != "" && id != null)
            {

                ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = new ShopNum1_AdvancePaymentApplyLog_Action();

                int num = shopNum1_AdvancePaymentApplyLog_Action.DeleteJs(id);

                if (num != -1)
                {
                    Response.Write("<script>alert('删除成功')</script>");

                    Num1GridViewShow.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('删除失败')</script>");
                }
            }

        }

        protected void Num1GridViewShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string id =e.CommandArgument.ToString();

            //if (id != "" && id != null)
            //{

            //    ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = new ShopNum1_AdvancePaymentApplyLog_Action();

            //    int num = shopNum1_AdvancePaymentApplyLog_Action.UpdateJsZt(id);

            //    if (num == 2)
            //    {
            //        Response.Write("<script>alert('结算成功')</script>");
            //    }
            //    else
            //    {
            //        Response.Write("<script>alert('结算失败，此单已结算')</script>");
            //    }
            //}
        }

    }
}