using System;

namespace ShopNum1.Deploy.PayReturn.CCBPay
{
    public partial class CCBPay_show : System.Web.UI.Page
    {
        protected string strOrderinfo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Label1.Text = "订单于：" + DateTime.Now.ToString() + "支付成功！";
                if (this.Session["orderNum"] != null)
                {
                    this.strOrderinfo = "商城订单号：<span class=\"span1\">" + this.Session["orderNum"].ToString() + "</span>";
                    this.Session.Remove("orderNum");
                }
            }
        }
    }
}