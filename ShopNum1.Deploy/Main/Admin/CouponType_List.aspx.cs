using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CouponType_List : PageBase, IRequiresSessionState
    {
        public string strid = "-1";

        protected void BindGrid()
        {
            num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("CouponType_Operate.aspx?ID=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string[] strArray = CheckGuid.Value.Split(new[] {','});
            for (int i = 0; i < strArray.Length; i++)
            {
                if (
                    !string.IsNullOrEmpty(Common.Common.GetNameById("Guid", "ShopNum1_Shop_Coupon",
                                                                    "   AND  Type=" + strArray[i])))
                {
                    MessageBox.Show("请首先删除含有分类的优惠券！");
                    return;
                }
            }
            var action = (Shop_CouponType_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_CouponType_Action();
            if (action.Delete(CheckGuid.Value.Replace("'", "")) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除优惠劵分类",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "CouponType_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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
            var action = (Shop_CouponType_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_CouponType_Action();
            var button = (LinkButton) sender;
            string commandArgument = button.CommandArgument;
            if (
                !string.IsNullOrEmpty(Common.Common.GetNameById("Guid", "ShopNum1_Shop_Coupon",
                                                                "   AND  Type='" + commandArgument + "' ")))
            {
                MessageBox.Show("请首先删除含有分类的优惠券！");
            }
            else if (action.Delete("'" + commandArgument + "'") > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员删除优惠劵分类",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "CouponType_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
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
            base.Response.Redirect("CouponType_Operate.aspx?ID=" + CheckGuid.Value);
        }

        public string GetRight(string isshow)
        {
            if (isshow == "1")
            {
                return "images/shopNum1Admin-right.gif";
            }
            return "images/shopNum1Admin-wrong.gif";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }
    }
}