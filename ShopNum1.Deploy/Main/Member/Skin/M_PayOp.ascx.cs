using System;
using System.Data;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1.Payment;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_PayOp : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string str = Common.Common.ReqStr("orderguid");
                string str2 = Common.Common.ReqStr("mid");
                string str3 = Common.Common.ReqStr("ordertype");
                string str4 = Common.Common.ReqStr("sign");
                string prNames = HttpUtility.HtmlDecode(Common.Common.ReqStr("pname"));
                if ((((str4 == "welcomeshopnum1") & (str != "")) & (str2 != "")) && (str3 != ""))
                {
                    DataTable table =
                        ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).Search1(str.Trim());
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        table.Rows[0]["ShopID"].ToString();
                        string shouldPayPrice = table.Rows[0]["ShouldPayPrice"].ToString();
                        string strTradeID = table.Rows[0]["OrderNumber"].ToString();
                        string paymentGuid = table.Rows[0]["PaymentGuid"].ToString();
                        string ZF = "";
                        if (paymentGuid.ToUpper() == "1075526A-7C28-44D0-B5F8-FD1B6746F662".ToUpper())
                        {
                            paymentGuid = "D7A29771-7640-4999-85DE-B3B493DA5970";
                            ZF = "&Dinpay=1";
                        }
                        if (paymentGuid.ToUpper() == "EB24C8E6-2959-452F-9332-CAEEEDD510BA".ToUpper())
                        {
                            paymentGuid = "D7A29771-7640-4999-85DE-B3B493DA5970";
                            ZF = "&Dinpay=2";
                        }

                        string str9 = table.Rows[0]["PaymentStatus"].ToString();
                        var action1 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        if (str9 == "0")
                        {
                            string payMentMemloginID = table.Rows[0]["PayMentMemLoginID"].ToString();
                            string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
                            var operate = new PayUrlOperate();
                            string payurl = operate.GetPayUrl(paymentGuid, shouldPayPrice,
                                ShopSettings.siteDomain, prNames, strTradeID,
                                "product", "0", payMentMemloginID, base.MemLoginID,
                                timetemp);
                            payurl = payurl + ZF;
                            Page.Response.Redirect(payurl);
                        }
                        else
                        {
                            Page.Response.Redirect("M_OrderDetail.aspx?guid=" + str + "&orderType=" + str3 + "&");
                        }
                    }
                }
                else
                {
                    Page.Response.Redirect("M_OrderDetail.aspx?guid=" + str + "&orderType=" + str3 + "&");
                }
            }
            else
            {
                Page.Response.Redirect("http://" + ShopSettings.siteDomain);
            }
        }
    }
}