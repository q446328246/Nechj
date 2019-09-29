using System;
using System.Data;
using System.Text;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_OrderList : BaseMemberControl
    {
        public static DataTable dt_OrderList = null;


        public int PageSize { get; set; }

        public static DataTable dt_GetOrderProduct(string OrderGuId)
        {
            HttpCookie cookie2 = HttpSecureCookie.Decode(HttpContext.Current.Request.Cookies["MemberLoginCookie"]);
            var action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();

            if (cookie2 != null)
            {
                return action.SelectOrderProductByGuIdorAllAndBuyerId(cookie2.Values["MemLoginID"], OrderGuId, HttpUtility.HtmlDecode(Common.Common.ReqStr("pn")));
            }
            else
            {
                return action.SelectOrderProductByGuIdorAllAndBuyerId("", OrderGuId, HttpUtility.HtmlDecode(Common.Common.ReqStr("pn")));
            }



        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                method_2();
            }
        }

        protected void BindData()
        {
            if ((Common.Common.ReqStr("sign") == "del") && (Common.Common.ReqStr("del") != ""))
            {
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).DeleteOrderInfoByOrdernum(
                    Common.Common.ReqStr("del"), 1, base.MemLoginID);
            }
            var action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            string ordernumber = Common.Common.ReqStr("ordernumber");
            if ((ordernumber != ""))
            {
                try
                {
                    DataTable dt = action.SelectOrdernumber(ordernumber);
                    string MemLoginID = dt.Rows[0]["MemLoginID"].ToString();
                    string CreateTime = dt.Rows[0]["CreateTime"].ToString();
                    string paytime = dt.Rows[0]["paytime"].ToString();
                    string ShouldPayPrice = dt.Rows[0]["ShouldPayPrice"].ToString();
                    string Score_pv_a = dt.Rows[0]["Score_pv_a"].ToString();
                    string OderStatus = dt.Rows[0]["OderStatus"].ToString();
                    string MemLoginNo = (action.GetMemLoginNo(MemLoginID)).Rows[0]["MemLoginNo"].ToString();

                    if (Convert.ToInt32(OderStatus) > 0 && Convert.ToInt32(OderStatus) < 4)
                    {
                        int count = action.AddProductByBTC(ordernumber, MemLoginNo, CreateTime, paytime, ShouldPayPrice, Score_pv_a);
                        if (count == 1)
                        {
                            MessageBox.Show("同步积分成功！");
                        }
                        if (count==0)
                        {
                            MessageBox.Show("同步积分失败，积分已存在！");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }

            }
        }

        private string method_1()
        {
            var builder = new StringBuilder();
            builder.Append(" and memloginId='" + base.MemLoginID + "' and BuyIsDeleted=0 and feetype!=2");
            string str = Common.Common.ReqStr("st");
            string str2 = str;
            switch (str2)
            {
                case null:
                    break;

                case "0":
                    builder.Append(" and oderstatus='" + str + "'");
                    break;

                case "1":
                    builder.Append(" and oderstatus='" + str + "'");
                    break;

                case "2":
                    builder.Append(" and oderstatus='" + str + "'");
                    break;

                default:
                    if (!(str2 == "3"))
                    {
                        if (str2 == "4")
                        {
                            builder.Append(" and oderstatus>3 ");
                        }
                    }
                    else
                    {
                        builder.Append(" and oderstatus='" + str + "'");
                    }
                    break;
            }
            string str7 = Common.Common.ReqStr("ord");
            string str3 = Common.Common.ReqStr("sd");
            string str6 = Common.Common.ReqStr("ed");
            string str4 = HttpUtility.HtmlDecode(Common.Common.ReqStr("sn"));
            if (str7 != "")
            {
                builder.Append(" and ordernumber='" + str7 + "'");
            }
            if (str3 != "")
            {
                builder.Append(" and createtime>='" + str3 + "'");
            }
            if (str6 != "")
            {
                builder.Append(" and createtime<='" + str6 + "'");
            }
            if (str4 != "")
            {
                builder.Append(" and shopname like '%" + str4 + "%'");
            }
            return builder.ToString();
        }

        protected void method_2()
        {
            var action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            int num = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(
                    action.SelectOrderList(PageSize.ToString(), num.ToString(), method_1(), "3",
                        HttpUtility.HtmlDecode(Common.Common.ReqStr("pn"))).Rows[0][0]);
            var bll = new PageListBll("main/member/M_OrderList.aspx", true);
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = num,
                RecordCount = num3
            };
            pageDiv1.InnerHtml = bll.GetPageListNew(pl);
            pageDiv2.InnerHtml = bll.GetPageListNew(pl);
            dt_OrderList = action.SelectOrderList(PageSize.ToString(), num.ToString(), method_1(), "2",
                HttpUtility.HtmlDecode(Common.Common.ReqStr("pn")));
            if (dt_OrderList.Rows.Count == 0)
            {
                dt_OrderList = null;
            }
        }

        public static string setOrderState(string strState)
        {
            string result;
            switch (strState)
            {
                case "0":
                    result = "等待买家付款";
                    return result;
                case "1":
                    result = "等待卖家发货";
                    return result;
                case "2":
                    result = "等待买家确认收货";
                    return result;
                case "3":
                    result = "<font color=\"green\">交易成功</font>";
                    return result;
                case "4":
                    result = "系统订单关闭";
                    return result;
                case "5":
                    result = "卖家关闭订单";
                    return result;
                case "6":
                    result = "买家关闭订单";
                    return result;
            }
            result = "非法状态";
            return result;
        }

        public static string setPaymentState(string strState)
        {
            string result;
            if (strState != null)
            {
                if (strState == "0")
                {
                    result = "未付款";
                    return result;
                }
                if (strState == "1")
                {
                    result = "已付款";
                    return result;
                }
                if (strState == "2")
                {
                    result = "退款成功";
                    return result;
                }
                if (strState == "3")
                {
                    result = "卖家拒绝退款";
                    return result;
                }
            }
            result = "非法状态";
            return result;
        }

        public static string setShipmentState(string strState)
        {
            string result;
            if (strState != null)
            {
                if (strState == "0")
                {
                    result = "未发货";
                    return result;
                }
                if (strState == "1")
                {
                    result = "已发货";
                    return result;
                }
                if (strState == "2")
                {
                    result = "已收货";
                    return result;
                }
                if (strState == "3")
                {
                    result = "退货";
                    return result;
                }
            }
            result = "非法状态";
            return result;
        }
    }
}