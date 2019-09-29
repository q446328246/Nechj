using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using tenpay;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class Tenpayshow_url : Page, IRequiresSessionState
    {

        private void method_0(object sender, EventArgs e)
        {
            string key = string.Empty;
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("TenpayMed.aspx");
            if (paymentKey != null && paymentKey.Rows.Count > 0)
            {
                key = paymentKey.Rows[0]["SecretKey"].ToString();
            }
            MediPayResponse mediPayResponse = new MediPayResponse(this.Context);
            mediPayResponse.setKey(key);
            if (mediPayResponse.isTenpaySign())
            {
                string parameter = mediPayResponse.getParameter("retcode");
                string parameter2 = mediPayResponse.getParameter("status");
                string parameter3 = mediPayResponse.getParameter("mch_vno");
                string parameter4 = mediPayResponse.getParameter("total_fee");
                if ("0".Equals(parameter))
                {
                    if (int.Parse(parameter2) == 3)
                    {
                        ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                        DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(parameter3);
                        dataTable.Rows[0]["MemLoginID"].ToString();
                        string text = dataTable.Rows[0]["Guid"].ToString();
                        string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                        dataTable.Rows[0]["OrderNumber"].ToString();
                        shopNum1_OrderInfo_Action.SetPaymentStatus2(text, 1, 1, 0, DateTime.Now, Convert.ToDecimal(parameter4), Convert.ToDecimal(value));
                        string str = "支付成功";
                        base.Response.Write(str + "<br/>");
                        base.Response.Write("商家定单号:" + parameter3 + "(根据此定单号进行查询)<br/>");
                        this.Page.Response.Redirect("~/index.aspx?MemberUrl=" + HttpUtility.UrlEncode("OrderDetail.aspx?guid=" + text));
                    }
                    else
                    {
                        string str = "异常错误";
                        base.Response.Write(str + "<br/>");
                    }
                }
                else
                {
                    base.Response.Write("支付失败");
                }
            }
            else
            {
                base.Response.Write("认证签名失败");
            }
        }
        protected int CheckMember(string strValue)
        {
            int result = 0;
            try
            {
                Guid guid = new Guid(strValue);
            }
            catch
            {
                result = 1;
            }
            return result;
        }
        public bool CheckProductLine()
        {
            ShopSettings shopSettings = new ShopSettings();
            string fieldXmlPath = this.Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
            return bool.Parse(shopSettings.GetValue(fieldXmlPath, "AgentProductLine"));
        }

    }
}