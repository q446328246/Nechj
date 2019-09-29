﻿using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_SaleOrderList : BaseMemberWebControl
    {
        public static DataTable dt_OrderList = null;
        private HtmlGenericControl pageDiv1;
        private HtmlGenericControl pageDiv2;
        private string skinFilename = "M_SaleOrderList.ascx";

        public M_SaleOrderList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageSize { get; set; }

        public static DataTable dt_GetSaleOrderProduct(string OrderGuId)
        {
            var action = (ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action();
            return action.SelectOrderProductByGuIdorAll(OrderGuId, HttpUtility.HtmlDecode(Common.Common.ReqStr("pn")));
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv1 = (HtmlGenericControl) skin.FindControl("pageDiv1");
            pageDiv2 = (HtmlGenericControl) skin.FindControl("pageDiv2");
            if (!Page.IsPostBack)
            {
                BindData();
                method_2();
            }
        }

        protected void BindData()
        {
            if ((Common.Common.ReqStr("sing") == "del") && (Common.Common.ReqStr("del") != ""))
            {
                ((ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action()).DeleteOrderInfoByOrdernum(
                    Common.Common.ReqStr("del"), 1, base.MemLoginID);
            }
        }

        private string method_1()
        {
            var builder = new StringBuilder();
            builder.Append(" and memloginId='" + base.MemLoginID + "' and Ordertype!=0 and isdeleted=0");
            string str = Common.Common.ReqStr("st");
            string str2 = str;
            switch (str2)
            {
                case null:
                    break;

                case "0":
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
            string str3 = Common.Common.ReqStr("ord");
            string str4 = Common.Common.ReqStr("sd");
            string str5 = Common.Common.ReqStr("ed");
            string str6 = HttpUtility.HtmlDecode(Common.Common.ReqStr("sn"));
            if (str3 != "")
            {
                builder.Append(" and ordernumber='" + str3 + "'");
            }
            if (str4 != "")
            {
                builder.Append(" and createtime>='" + str4 + "'");
            }
            if (str5 != "")
            {
                builder.Append(" and createtime<='" + str5 + "'");
            }
            if (str6 != "")
            {
                builder.Append(" and shopname like '%" + str6 + "%'");
            }
            return builder.ToString();
        }

        protected void method_2()
        {
            var action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            int num = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(
                    action.SelectOrderList(PageSize.ToString(), num.ToString(), method_1(), "3",
                        HttpUtility.HtmlDecode(Common.Common.ReqStr("pn"))).Rows[0][0]);
            var bll = new PageListBll("main/member/M_SaleOrderList.aspx", true);
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
                    result = "交易成功";
                    return result;
                case "4":
                    result = "订单关闭";
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