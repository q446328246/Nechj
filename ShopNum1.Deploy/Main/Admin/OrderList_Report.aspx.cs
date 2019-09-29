using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class OrderList_Report : PageBase, IRequiresSessionState
    {
        private void method_5()
        {
            try
            {
                HttpCookie cookie = base.Request.Cookies["OrderListReportCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                string orderNumber = cookie2.Values["OrderNumber"].ToString();
                string memLoginID = cookie2.Values["MemLoginID"].ToString();
                string address = cookie2.Values["Address"].ToString();
                string postalcode = cookie2.Values["Postalcode"].ToString();
                string mobile = cookie2.Values["Mobile"].ToString();
                string email = cookie2.Values["Email"].ToString();
                string str7 = cookie2.Values["Tel"].ToString();
                string name = cookie2.Values["Name"].ToString();
                string shopID = cookie2.Values["ShopID"].ToString();
                string shopName = cookie2.Values["ShopName"].ToString();
                string orderStatus = cookie2.Values["orderStatus"].ToString();
                decimal num = 0M;
                decimal num2 = 0M;
                if (cookie2.Values["ShouldPayPrice1"].ToString() != string.Empty)
                {
                    num = Convert.ToDecimal(cookie2.Values["ShouldPayPrice1"].ToString());
                }
                if (cookie2.Values["ShouldPayPrice2"].ToString() != string.Empty)
                {
                    num2 = Convert.ToDecimal(cookie2.Values["ShouldPayPrice2"].ToString());
                }
                string str14 = cookie2.Values["CreateTime1"].ToString();
                string str15 = cookie2.Values["CreateTime2"].ToString();
                string str19 = cookie2.Values["PageCheck"].ToString();
                string ordernum = cookie2.Values["Guids"].ToString();
                string orderType = cookie2.Values["OrderType"].ToString();
                string strCondition = cookie2.Values["Condition"].ToString();
                ShopNum1_OrderInfo_Action action = new ShopNum1_OrderInfo_Action();
                DataTable table = null;
                if (str19 == "1")
                {
                    table = action.SearchOrderInfoByOrdernum(ordernum, orderType, strCondition);
                }
                else
                {
                    table = action.Search(orderNumber, memLoginID, name, address, postalcode, str7, mobile, email, num, num2, str14, str15, 0, shopID, shopName, orderStatus, orderType);
                }
                if ((table != null) && (table.Rows.Count > 0))
                {
                    base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                    base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                    base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">订单号</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺ID</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺名称</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >订单类型</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >详细地址</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >邮编</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >手机号码</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >电子邮件</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >联系电话</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">下单日期</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">付款日期</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">收货人</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">购买人</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">支付方式</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">商品单价</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">应付金额</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">专区号</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">订单状态</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">商品名</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">数量</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">小记</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">推荐人</td>");
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        base.Response.Write("<tr>");
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>".Replace("{OrderNumber}", table.Rows[i]["OrderNumber"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ShopID}</td>".Replace("{ShopID}", table.Rows[i]["ShopID"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ShopName}</td>".Replace("{ShopName}", table.Rows[i]["ShopName"].ToString()));
                        string newValue = string.Empty;
                        string key = table.Rows[i]["OrderType"].ToString();
                        if (key != null)
                        {
                            if (key != "0")
                            {
                                if (!(key == "2"))
                                {
                                    if (key == "1")
                                    {
                                        newValue = "团购订单";
                                    }
                                }
                                else
                                {
                                    newValue = "抢购订单";
                                }
                            }
                            else
                            {
                                newValue = "普通订单";
                            }
                        }
                        string str17 = table.Rows[i]["Feetype"].ToString();
                        if (str17 == "2")
                        {
                            newValue = "生活服务订单";
                        }
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {OrderTypes}</td>".Replace("{OrderTypes}", newValue));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Address}</td>".Replace("{Address}", table.Rows[i]["Address"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Postalcode}</td>".Replace("{Postalcode}", table.Rows[i]["Postalcode"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Mobile}</td>".Replace("{Mobile}", table.Rows[i]["Mobile"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Email}</td>".Replace("{Email}", table.Rows[i]["Email"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Tel}</td>".Replace("{Tel}", table.Rows[i]["Tel"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {CreateTime}</td>".Replace("{CreateTime}", table.Rows[i]["CreateTime"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {PayTime}</td>".Replace("{PayTime}", table.Rows[i]["PayTime"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Name}</td>".Replace("{Name}", table.Rows[i]["Name"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {MemLoginID}</td>".Replace("{MemLoginID}", table.Rows[i]["MemLoginID"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {PaymentName}</td>".Replace("{PaymentName}", table.Rows[i]["PaymentName"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ShopPrice}</td>".Replace("{ShopPrice}", table.Rows[i]["ShopPrice"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ShouldPayPrice}</td>".Replace("{ShouldPayPrice}", table.Rows[i]["ShouldPayPrice"].ToString()));

                    DataTable  table232 = action.selectSuperior(table.Rows[i]["MemLoginID"].ToString());
                    string tre22 = "";

                    if (table232.Rows[0]["MemberRankGuid"].ToString().ToUpper()=="197B6B51-3EB3-452E-BD03-D560577A34D2".ToUpper())
                    {
                        tre22 = table232.Rows[0]["Superior"].ToString();
                    }
                    else
                    {
                        tre22 = table.Rows[i]["MemLoginID"].ToString();
                    }
                        string str12 = string.Empty;
                        key = table.Rows[i]["OderStatus"].ToString();
                        if (key != null)
                        {
                            int num3;
                            if (Class5.dictionary_0 == null)
                            {
                                Dictionary<string, int> dictionary1 = new Dictionary<string, int>(7);
                                dictionary1.Add("0", 0);
                                dictionary1.Add("1", 1);
                                dictionary1.Add("2", 2);
                                dictionary1.Add("3", 3);
                                dictionary1.Add("4", 4);
                                dictionary1.Add("5", 5);
                                dictionary1.Add("6", 6);
                                Class5.dictionary_0 = dictionary1;
                            }
                            string str144 = "";
                            switch (Convert.ToInt32(table.Rows[i]["shop_category_id"]))
                            {
                                case 1:
                                    str144 = "大唐专区";
                                    break;
                                case 2:
                                    str144 = "VIP专区";
                                    break;
                                case 3:
                                    str144 = "积分专区";
                                    break;
                                case 4:
                                    str144 = "区代首次购买";
                                    break;
                                case 5:
                                    str144 = "区代专区";
                                    break;
                                case 6:
                                    str144 = "社区首次购买";
                                    break;
                                case 7:
                                    str144 = "社区专区";
                                    break;
                                case 9:
                                    str144 = "BTC专区";
                                    break;
                            }
                            base.Response.Write("<td style=\"background-color:#FFF\"> {shop_category_id}</td>".Replace("{shop_category_id}", str144));
                            if (Class5.dictionary_0.TryGetValue(key, out num3))
                            {
                                switch (num3)
                                {
                                    case 0:
                                        str12 = "等待买家付款";
                                        break;

                                    case 1:
                                        if (!(str17 == "2"))
                                        {
                                            goto Label_08DA;
                                        }
                                        str12 = "等待买家消费";
                                        break;

                                    case 2:
                                        if (!(str17 == "2"))
                                        {
                                            goto Label_08FD;
                                        }
                                        str12 = "等待卖家确认";
                                        break;

                                    case 3:
                                        str12 = "交易成功";
                                        break;

                                    case 4:
                                        str12 = "系统关闭订单";
                                        break;

                                    case 5:
                                        str12 = "卖家关闭订单";
                                        break;

                                    case 6:
                                        str12 = "买家关闭订单";
                                        break;
                                }
                            }
                        }
                        goto Label_0928;
                    Label_08DA:
                        if (!(table.Rows[i].IsNull("RefundType")) && !(table.Rows[i].IsNull("Rec")))
                        {
                            if (Convert.ToInt32(table.Rows[i]["RefundType"]) == 0 && Convert.ToInt32(table.Rows[i]["Rec"]) == 1)
                            {
                                str12 = "买家申请退款";
                            }
                            else
                            {
                                str12 = "等待卖家发货";
                            }
                           
                        }
                        else
                        {
                            str12 = "等待卖家发货";
                        }
                        
                        goto Label_0928;
                    Label_08FD:
                        str12 = "等待买家确认收货";
                    Label_0928:
                        base.Response.Write("<td style=\"background-color:#FFF\"> {strOderStatusDisply}</td>".Replace("{strOderStatusDisply}", str12));
                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ProductName}</td>".Replace("{ProductName}", table.Rows[i]["ProductName"].ToString()));
                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {BuyNumber}</td>".Replace("{BuyNumber}", table.Rows[i]["BuyNumber"].ToString()));
                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ShopTotal}</td>".Replace("{ShopTotal}", table.Rows[i]["ShopTotal"].ToString()));

                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Superior}</td>".Replace("{Superior}", tre22));
                        base.Response.Write("</tr>");
                    }
                    base.Response.Write("</table>");
                }
                HttpCookie cookie3 = base.Request.Cookies["OrderListReportCookie"];
                cookie3.Expires = DateTime.Now.AddDays(-99.0);
                base.Response.Cookies.Add(cookie3);
            }
            catch (Exception)
            {
            }
        }

        private void MJC_method_5()
        {
            try
            {
                HttpCookie cookie = base.Request.Cookies["OrderListReportCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                string orderNumber = cookie2.Values["OrderNumber"].ToString();
                string memLoginID = cookie2.Values["MemLoginID"].ToString();
                string address = cookie2.Values["Address"].ToString();
                string postalcode = cookie2.Values["Postalcode"].ToString();
                string mobile = cookie2.Values["Mobile"].ToString();
                string email = cookie2.Values["Email"].ToString();
                string str7 = cookie2.Values["Tel"].ToString();
                string name = cookie2.Values["Name"].ToString();
                string shopID = cookie2.Values["ShopID"].ToString();
                string shopName = cookie2.Values["ShopName"].ToString();
                string orderStatus = cookie2.Values["orderStatus"].ToString();
                decimal num = 0M;
                decimal num2 = 0M;
                if (cookie2.Values["ShouldPayPrice1"].ToString() != string.Empty)
                {
                    num = Convert.ToDecimal(cookie2.Values["ShouldPayPrice1"].ToString());
                }
                if (cookie2.Values["ShouldPayPrice2"].ToString() != string.Empty)
                {
                    num2 = Convert.ToDecimal(cookie2.Values["ShouldPayPrice2"].ToString());
                }
                string str14 = cookie2.Values["CreateTime1"].ToString();
                string str15 = cookie2.Values["CreateTime2"].ToString();
                string str19 = cookie2.Values["PageCheck"].ToString();
                string ordernum = cookie2.Values["Guids"].ToString();
                string orderType = cookie2.Values["OrderType"].ToString();
                string strCondition = cookie2.Values["Condition"].ToString();
                ShopNum1_OrderInfo_Action action = new ShopNum1_OrderInfo_Action();
                DataTable table = null;
                if (str19 == "1")
                {
                    table = action.MJC_SearchOrderInfoByOrdernum(ordernum, orderType, strCondition);
                }
                else
                {
                    table = action.MJC_Search(orderNumber, memLoginID, name, address, postalcode, str7, mobile, email, num, num2, str14, str15, 0, shopID, shopName, orderStatus, orderType);
                }
                if ((table != null) && (table.Rows.Count > 0))
                {
                    base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                    base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                    base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">订单号</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >挂单人</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >手机号码</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >下单时间</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >支付时间</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >订单总额</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >买单人</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >状态</td>");
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        base.Response.Write("<tr>");
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>".Replace("{OrderNumber}", table.Rows[i]["OrderNumber"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {MemLoginID}</td>".Replace("{MemLoginID}", table.Rows[i]["MemLoginID"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {mobile}</td>".Replace("{mobile}", table.Rows[i]["mobile"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {CreateTime}</td>".Replace("{CreateTime}", table.Rows[i]["CreateTime"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {PayTime}</td>".Replace("{PayTime}", table.Rows[i]["PayTime"].ToString()));

                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ShouldpayPrice}</td>".Replace("{ShouldpayPrice}", table.Rows[i]["ShouldpayPrice"].ToString()));

                        string tre22 = "";
                        if (table.Rows[i]["OderStatus"].ToString() == "1")
                        {
                            tre22 = "挂单人已扣款";
                        }
                        else if (table.Rows[i]["OderStatus"].ToString() == "2")
                        {
                            tre22 = "交易成功";
                        }
                        else if (table.Rows[i]["OderStatus"].ToString() == "3")
                        {
                            tre22 = "取消订单";
                        }
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ServiceAgent}</td>".Replace("{ServiceAgent}", table.Rows[i]["ServiceAgent"].ToString()));

                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {OderStatus}</td>".Replace("{OderStatus}", tre22));
                        
                        base.Response.Write("</tr>");
                    }
                    base.Response.Write("</table>");
                }
                HttpCookie cookie3 = base.Request.Cookies["OrderListReportCookie"];
                cookie3.Expires = DateTime.Now.AddDays(-99.0);
                base.Response.Cookies.Add(cookie3);
            }
            catch (Exception)
            {
            }
        }



        private void method_6()
        {
            try
            {
                HttpCookie cookie = base.Request.Cookies["OrderListReportCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                string orderNumber = cookie2.Values["OrderNumber"].ToString();
                string memLoginID = cookie2.Values["MemLoginID"].ToString();
                string address = cookie2.Values["Address"].ToString();
                string postalcode = cookie2.Values["Postalcode"].ToString();
                string mobile = cookie2.Values["Mobile"].ToString();
                string email = cookie2.Values["Email"].ToString();
                string str7 = cookie2.Values["Tel"].ToString();
                string name = cookie2.Values["Name"].ToString();
                string shopID = cookie2.Values["ShopID"].ToString();
                string shopName = cookie2.Values["ShopName"].ToString();
                string orderStatus = cookie2.Values["orderStatus"].ToString();
                decimal num = 0M;
                decimal num2 = 0M;
                if (cookie2.Values["ShouldPayPrice1"].ToString() != string.Empty)
                {
                    num = Convert.ToDecimal(cookie2.Values["ShouldPayPrice1"].ToString());
                }
                if (cookie2.Values["ShouldPayPrice2"].ToString() != string.Empty)
                {
                    num2 = Convert.ToDecimal(cookie2.Values["ShouldPayPrice2"].ToString());
                }
                string str14 = cookie2.Values["CreateTime1"].ToString();
                string str15 = cookie2.Values["CreateTime2"].ToString();
                string str19 = cookie2.Values["PageCheck"].ToString();
                string ordernum = cookie2.Values["Guids"].ToString();
                string   orderType= cookie2.Values["OrderType"].ToString();

                string strCondition;
                strCondition = cookie2.Values["Condition"].ToString();
                StringBuilder sb = new StringBuilder(strCondition);
                sb.Replace("shop_category_id", "soi.shop_category_id");
                strCondition = sb.ToString();
                int zt = Convert.ToInt32(cookie2.Values["Reportx_State"]);
                ShopNum1_OrderInfo_Action action = new ShopNum1_OrderInfo_Action();
                DataTable table = null;
                if (str19 == "1")
                {
                    if (zt == 4)
                    {
                        table = action.SearchOrderInfoByOrdernumFinanceTK(ordernum, orderType, strCondition);
                    }
                    else
                    {
                        table = action.SearchOrderInfoByOrdernumFinanceeeeeeeeeeeeeeeeee(ordernum, orderType, strCondition);
                    }
                    }
                else
                {
                    table = action.Search(orderNumber, memLoginID, name, address, postalcode, str7, mobile, email, num, num2, str14, str15, 0, shopID, shopName, orderStatus, orderType);
                }
                if ((table != null) && (table.Rows.Count > 0))
                {
                    base.Response.Write("<table width=\"100%\" border=\"1\" cellspacing=\"1\" cellpadding=\"0\" style=\"background-color:#999\">");
                    base.Response.Write("<tr style=\"color:#FFF;font-weight:bold; text-align:center\">");
                    base.Response.Write(" <td height=\"30\" align=\"center\" style=\"background-color:#6699cc\">订单号</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺ID</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >店铺名称</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\" >手机号码</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">下单日期</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">支付日期</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">专区号</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">订单状态</td>");
                    if (zt == 4)
                    {
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">退款时间</td>");
                    }
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">购买人ID</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">支付方式</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">邮费</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">产品金额</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">订单总额</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">抵扣红包</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">实付金额</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">Score_pv_a</td>");
                    base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">Score_pv_b</td>");
                    if (zt == 3)
                    {
                        base.Response.Write("<td  style=\"background-color:#6699cc;text-align:center\">零售价</td>");
                    }
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        base.Response.Write("<tr>");
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\" style=\"vnd.ms-excel.numberformat:@\"> {OrderNumber}</td>".Replace("{OrderNumber}", table.Rows[i]["OrderNumber"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ShopID}</td>".Replace("{ShopID}", table.Rows[i]["ShopID"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ShopName}</td>".Replace("{ShopName}", table.Rows[i]["ShopName"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Mobile}</td>".Replace("{Mobile}", table.Rows[i]["Mobile"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {CreateTime}</td>".Replace("{CreateTime}", table.Rows[i]["CreateTime"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {PayTime}</td>".Replace("{PayTime}", table.Rows[i]["PayTime"].ToString()));
                        string newValue = string.Empty;
                        string key = table.Rows[i]["OrderType"].ToString();
                        if (key != null)
                        {
                            if (key != "0")
                            {
                                if (!(key == "2"))
                                {
                                    if (key == "1")
                                    {
                                        newValue = "团购订单";
                                    }
                                }
                                else
                                {
                                    newValue = "抢购订单";
                                }
                            }
                            else
                            {
                                newValue = "普通订单";
                            }
                        }
                        string str17 = table.Rows[i]["Feetype"].ToString();
                        if (str17 == "2")
                        {
                            newValue = "生活服务订单";
                        }
                       

                        DataTable table232 = action.selectSuperior(table.Rows[i]["MemLoginID"].ToString());
                        string tre22 = "";

                        if (table232.Rows[0]["MemberRankGuid"].ToString().ToUpper() == "197B6B51-3EB3-452E-BD03-D560577A34D2".ToUpper())
                        {
                            tre22 = table232.Rows[0]["Superior"].ToString();
                        }
                        else
                        {
                            tre22 = table.Rows[i]["MemLoginID"].ToString();
                        }
                        string str12 = string.Empty;
                        key = table.Rows[i]["OderStatus"].ToString();
                        if (key != null)
                        {
                            int num3;
                            if (Class5.dictionary_0 == null)
                            {
                                Dictionary<string, int> dictionary1 = new Dictionary<string, int>(7);
                                dictionary1.Add("0", 0);
                                dictionary1.Add("1", 1);
                                dictionary1.Add("2", 2);
                                dictionary1.Add("3", 3);
                                dictionary1.Add("4", 4);
                                dictionary1.Add("5", 5);
                                dictionary1.Add("6", 6);
                                Class5.dictionary_0 = dictionary1;
                            }
                            string str144 = "";
                            switch (Convert.ToInt32(table.Rows[i]["shop_category_id"]))
                            {
                                case 1:
                                    str144 = "大唐专区";
                                    break;
                                case 2:
                                    str144 = "VIP专区";
                                    break;
                                case 3:
                                    str144 = "积分专区";
                                    break;
                                case 4:
                                    str144 = "区代首次购买";
                                    break;
                                case 5:
                                    str144 = "区代专区";
                                    break;
                                case 6:
                                    str144 = "社区首次购买";
                                    break;
                                case 7:
                                    str144 = "社区专区";
                                    break;
                                case 9:
                                    str144 = "BTC专区";
                                    break;
                            }
                            base.Response.Write("<td style=\"background-color:#FFF\"> {shop_category_id}</td>".Replace("{shop_category_id}", str144));

                            

                            if (Class5.dictionary_0.TryGetValue(key, out num3))
                            {
                                switch (num3)
                                {
                                    case 0:
                                        str12 = "等待买家付款";
                                        break;

                                    case 1:
                                        if (!(str17 == "2"))
                                        {
                                            goto Label_08DA;
                                        }
                                        str12 = "等待买家消费";
                                        break;

                                    case 2:
                                        if (!(str17 == "2"))
                                        {
                                            goto Label_08FD;
                                        }
                                        str12 = "等待卖家确认";
                                        break;

                                    case 3:
                                        str12 = "交易成功";
                                        break;

                                    case 4:
                                        str12 = "系统关闭订单";
                                        break;

                                    case 5:
                                        str12 = "卖家关闭订单";
                                        break;

                                    case 6:
                                        str12 = "买家关闭订单";
                                        break;
                                }
                            }
                        }
                        goto Label_0928;
                    Label_08DA:
                       
                        
                        
                            str12 = "等待卖家发货";
                        

                        goto Label_0928;
                    Label_08FD:
                        str12 = "等待买家确认收货";
                    Label_0928:
                        base.Response.Write("<td style=\"background-color:#FFF\"> {strOderStatusDisply}</td>".Replace("{strOderStatusDisply}", str12));
                        if (zt == 4)
                        {
                            base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {OperateDateTime}</td>".Replace("{OperateDateTime}", table.Rows[i]["OperateDateTime"].ToString()));
                        }
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {MemLoginID}</td>".Replace("{MemLoginID}", table.Rows[i]["MemLoginID"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {PaymentName}</td>".Replace("{PaymentName}", table.Rows[i]["PaymentName"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {DispatchPrice}</td>".Replace("{DispatchPrice}", table.Rows[i]["DispatchPrice"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ProductAllPrice}</td>".Replace("{ProductAllPrice}", table.Rows[i]["ProductAllPrice"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {ShouldPayPrice}</td>".Replace("{ShouldPayPrice}", table.Rows[i]["ShouldPayPrice"].ToString()));
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Deduction_hv}</td>".Replace("{Deduction_hv}", table.Rows[i]["Deduction_hv"].ToString()));

                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {PaidPrice}</td>".Replace("{PaidPrice}", table.Rows[i]["PaidPrice"].ToString()));
                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Score_pv_a}</td>".Replace("{Score_pv_a}", table.Rows[i]["Score_pv_a"].ToString()));
                    base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {Score_pv_b}</td>".Replace("{Score_pv_b}", table.Rows[i]["Score_pv_b"].ToString()));
                    if (zt == 3)
                    {
                        base.Response.Write("<td style=\"background-color:#FFF;text-align:center\"> {myprice}</td>".Replace("{myprice}", table.Rows[i]["myprice"].ToString()));
                    }
                        base.Response.Write("</tr>");
                    }
                    base.Response.Write("</table>");
                }
                HttpCookie cookie3 = base.Request.Cookies["OrderListReportCookie"];
                cookie3.Expires = DateTime.Now.AddDays(-99.0);
                base.Response.Cookies.Add(cookie3);
            }
            catch (Exception)
            {
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.Cookies["AdminLoginCookie"] == null)
            {
                base.Response.Write("<script type=\"text/javascript\">window.top.location.href='Login.aspx';</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                base.Response.Clear();
                if (base.Request.QueryString["Type"] != null)
                {
                    string str = base.Request.QueryString["Type"].ToString();
                    if (str == "xls")
                    {
                        base.Response.ContentType = "Application/ms-excel";
                        base.Response.ContentEncoding = Encoding.UTF8;
                    }
                    else
                    {
                        base.Response.ContentType = "text/HTML";
                        base.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                    }
                    base.Response.AppendHeader("Content-Disposition", "attachment;filename=\"CTCOrderListReport_" + DateTime.Now.ToString("yyyymmddhhmm") + "." + str + "\"");

                    HttpCookie cookie4 = base.Request.Cookies["OrderListReportCookie"];
                    HttpCookie cookie5 = HttpSecureCookie.Decode(cookie4);
                    int zt = Convert.ToInt32(cookie5.Values["Reportx_State"]);
                    if (zt == 1 || zt == 2)
                    {
                        this.method_5();
                    }
                    else if (zt == 3||zt==4)
                    { 
                        this.method_6();
                    }
                    else if (zt == 5 || zt == 6)
                    {
                        this.MJC_method_5();
                    }

                    Thread.Sleep(100);
                    base.Response.Flush();
                    base.Response.Close();
                    base.Response.End();
                }
            }
        }
    }
}