using System;
using System.Data;
using System.Web;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Payment;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_PayOp : BaseMemberWebControl
    {
        private string skinFilename = "M_PayOp.ascx";

        public M_PayOp()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
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
                        ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).Search1(str.Trim());
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        table.Rows[0]["ShopID"].ToString();
                        string shouldPayPrice = table.Rows[0]["ShouldPayPrice"].ToString();
                        string strTradeID = table.Rows[0]["OrderNumber"].ToString();
                        string paymentGuid = table.Rows[0]["PaymentGuid"].ToString();
                        string str9 = table.Rows[0]["PaymentStatus"].ToString();
                        var action1 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                        if (str9 == "0")
                        {
                            string payMentMemloginID = table.Rows[0]["PayMentMemLoginID"].ToString();
                            string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
                            var operate = new PayUrlOperate();
                            Page.Response.Redirect(operate.GetPayUrl(paymentGuid, shouldPayPrice,
                                ShopSettings.siteDomain, prNames, strTradeID,
                                "product", "0", payMentMemloginID, base.MemLoginID,
                                timetemp));
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