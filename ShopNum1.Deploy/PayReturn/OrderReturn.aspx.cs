using System;
using System.Data;
using System.Web.Security;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class OrderReturn : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string text = base.Request["billno"];
            string text2 = base.Request["amount"];
            string text3 = base.Request["Currency_type"];
            string text4 = base.Request["date"];
            string text5 = base.Request["succ"];
            string arg_66_0 = base.Request["msg"];
            string arg_77_0 = base.Request["attach"];
            string text6 = base.Request["ipsbillno"];
            string a = base.Request["retencodetype"];
            string b = base.Request["signature"];
            string str = string.Concat(new string[]
		{
			text,
			text2,
			text4,
			text5,
			text6,
			text3
		});
            bool flag = false;
            if (a == "12")
            {
                ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
                DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("huanxun.aspx");
                string str2 = paymentKey.Rows[0]["SecretKey"].ToString();
                string a2 = FormsAuthentication.HashPasswordForStoringInConfigFile(str + str2, "MD5").ToLower();
                if (a2 == b)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                if (text5 != "Y")
                {
                    base.Response.Write("交易失败！");
                    base.Response.End();
                }
                else
                {
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text);
                    string text7 = dataTable.Rows[0]["MemLoginID"].ToString();
                    string text8 = dataTable.Rows[0]["Guid"].ToString();
                    string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                    dataTable.Rows[0]["OrderNumber"].ToString();
                    string value2 = dataTable.Rows[0]["PaymentStatus"].ToString();
                    if (Convert.ToInt32(value2) < 1)
                    {
                        shopNum1_OrderInfo_Action.SetPaymentStatus2(text8, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text2), Convert.ToDecimal(value));
                        if (this.CheckMember(text7) == 1)
                        {
                            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                            shopNum1_Member_Action.UpdateCostMoney(text7, Convert.ToDecimal(text2));
                        }
                        base.Response.Redirect("/main/Member/m_index.aspx");
                        base.Response.End();
                    }
                }
            }
            else
            {
                base.Response.Write("签名不正确！");
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

    }
}