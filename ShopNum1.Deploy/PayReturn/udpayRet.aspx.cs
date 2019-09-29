using System;
using System.Data;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using UdpaySecurity;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class udpayRet : Page, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string str = base.Request["txCode"];
            string str2 = base.Request["merchantId"];
            string str3 = base.Request["transDateTime"];
            string text = base.Request["orderId"];
            string str4 = base.Request["curCode"];
            string text2 = base.Request["amount"];
            string str5 = base.Request["merURL"];
            string str6 = base.Request["transType"];
            string str7 = base.Request["info1"];
            string str8 = base.Request["info12"];
            string str9 = base.Request["returnInfo"];
            string str10 = base.Request["whtFlow"];
            string text3 = base.Request["success"];
            string str11 = base.Request["errorType"];
            string sign = base.Request["sign"];
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("txCode=" + str);
            stringBuilder.Append("&merchantId=" + str2);
            stringBuilder.Append("&transDateTime=" + str3);
            stringBuilder.Append("&orderId=" + text);
            stringBuilder.Append("&curCode=" + str4);
            stringBuilder.Append("&amount=" + text2);
            stringBuilder.Append("&merURL=" + str5);
            stringBuilder.Append("&transType=" + str6);
            stringBuilder.Append("&info1=" + str7);
            stringBuilder.Append("&info2=" + str8);
            stringBuilder.Append("&returnInfo=" + str9);
            stringBuilder.Append("&whtFlow=" + str10);
            stringBuilder.Append("&success=" + text3);
            stringBuilder.Append("&errorType=" + str11);
            string pText = stringBuilder.ToString();
            UdpayRsa.LoadSignKey();
            if (UdpayRsa.VerifySigature(pText, sign) == 0 && text3 == "Y")
            {
                ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    string text4 = dataTable.Rows[0]["MemLoginID"].ToString();
                    string text5 = dataTable.Rows[0]["Guid"].ToString();
                    string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                    dataTable.Rows[0]["OrderNumber"].ToString();
                    shopNum1_OrderInfo_Action.SetPaymentStatus2(text5, 1, 1, 0, DateTime.Now, Convert.ToDecimal(text2), Convert.ToDecimal(value));
                    if (this.CheckMember(text4) == 1)
                    {
                        ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        shopNum1_Member_Action.UpdateCostMoney(text4, Convert.ToDecimal(text2));
                    }
                }
                base.Response.Write("成功");
            }
            else
            {
                base.Response.Write("shibai");
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