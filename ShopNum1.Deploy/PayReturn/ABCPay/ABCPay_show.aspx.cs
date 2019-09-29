using System;
using System.Web.SessionState;
using System.Web.UI;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class ABCPay_show : Page, IRequiresSessionState
    {
        public string strOrderinfo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string text = string.Format("{0}", base.Request["_result"]);
                string str = string.Format("{0}", base.Request["orderNO"]);
                string text2 = string.Empty;
                if (text.Equals("True"))
                {
                    text2 = string.Format("尊敬的客户：您好，订单于：{0}", DateTime.Now.ToString() + "支付成功！");
                }
                else
                {
                    text2 = string.Format("尊敬的客户：您好，订单于：{0}", DateTime.Now.ToString() + "支付失败！");
                }
                this.LabelTime.Text = text2;
                this.strOrderinfo = "商城订单号：<span class=\"span1\">" + str + "</span>";
            }
        }

    }
}