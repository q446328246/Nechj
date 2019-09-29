using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_LifeOrder_List : BaseShopWebControl
    {
        public static DataTable dt_OrderList = null;
        private HtmlGenericControl htmlGenericControl_0;
        private HtmlGenericControl htmlGenericControl_1;
        
        private string skinFilename = "S_LifeOrder_List.ascx";

        public S_LifeOrder_List()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageSize { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            htmlGenericControl_0 = (HtmlGenericControl) skin.FindControl("pageDiv1");
            htmlGenericControl_1 = (HtmlGenericControl) skin.FindControl("pageDiv2");
            if (!Page.IsPostBack)
            {
                method_0();
                method_2();
            }
        }

        protected void method_0()
        {
            if (Common.Common.ReqStr("sign") == "del" && Common.Common.ReqStr("del") != "")
            {
                var shopNum1_OrderInfo_Action =
                    (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
                shopNum1_OrderInfo_Action.DeleteOrderInfoByOrdernum(Common.Common.ReqStr("del"), 0, MemLoginID);
            }
        }

        private string method_1()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(" and shopid='" + MemLoginID + "' and BuyIsDeleted=0 and FeeType = 2");
            string text = Common.Common.ReqStr("ord");
            string text2 = Common.Common.ReqStr("sd");
            string text3 = Common.Common.ReqStr("ed");
            string text4 = HttpUtility.HtmlDecode(Common.Common.ReqStr("mid"));
            string text5 = Common.Common.ReqStr("ostate");
            string text6 = Common.Common.ReqStr("sstate");
            string a = Common.Common.ReqStr("pstate");
            string a2 = Common.Common.ReqStr("quit");
            if (text != "")
            {
                stringBuilder.Append(" and ordernumber='" + text + "'");
            }
            if (text2 != "")
            {
                stringBuilder.Append(" and createtime>='" + text2 + "'");
            }
            if (text3 != "")
            {
                stringBuilder.Append(" and createtime<='" + text3 + "'");
            }
            if (text4 != "")
            {
                stringBuilder.Append(" and memloginid like '%" + text4 + "%'");
            }
            if (a2 != "")
            {
                stringBuilder.Append(" and oderstatus>3");
            }
            else
            {
                if (Common.Common.ReqStr("stype") != "0" && Common.Common.ReqStr("stype") != "" && text5 != "")
                {
                    if (text6 == "4")
                    {
                        stringBuilder.Append(" and shipmentstatus=4 ");
                    }
                    else
                    {
                        if (a == "3")
                        {
                            stringBuilder.Append(" and paymentstatus=3 ");
                        }
                        else
                        {
                            if (text5 == "1")
                            {
                                stringBuilder.Append(" and oderstatus=1 ");
                            }
                            else
                            {
                                if (Common.Common.ReqStr("iscomment") == "0")
                                {
                                    stringBuilder.Append(" and  oderstatus=" + text5 + " and IsBuyComment=0");
                                }
                                else
                                {
                                    if (text6 != "")
                                    {
                                        stringBuilder.Append(" and oderstatus=" + text5);
                                    }
                                    else
                                    {
                                        stringBuilder.Append(" and shipmentstatus=" + text6 + " and oderstatus=" + text5);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return stringBuilder.ToString();
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
                    result = "等待买家消费";
                    return result;
                case "3":
                    result = "已消费";
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

        protected void method_2()
        {
            var shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            int num = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            DataTable dataTable = shopNum1_OrderInfo_Action.SelectOrderList(PageSize.ToString(), num.ToString(),
                method_1(), "3",
                HttpUtility.HtmlDecode(
                    Common.Common.ReqStr("pn")));
            int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
            var pageListBll = new PageListBll("shop/ShopAdmin/S_LifeOrder_List.aspx", true);
            var pageList = new PageList1();
            pageList.PageSize = PageSize;
            pageList.PageID = num;
            pageList.RecordCount = recordCount;
            htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew(pageList);
            htmlGenericControl_1.InnerHtml = pageListBll.GetPageListNew(pageList);
            pageList.PageCount = pageList.RecordCount/pageList.PageSize;
            if (pageList.PageCount < pageList.RecordCount/(double) pageList.PageSize)
            {
                pageList.PageCount++;
            }
            if (num > pageList.PageCount)
            {
                num = pageList.PageCount;
            }
            dt_OrderList = shopNum1_OrderInfo_Action.SelectOrderList(PageSize.ToString(), num.ToString(), method_1(),
                "2",
                HttpUtility.HtmlDecode(Common.Common.ReqStr("pn")));
            if (dt_OrderList.Rows.Count == 0)
            {
                dt_OrderList = null;
            }
        }

        public static DataTable dt_GetOrderProduct(string OrderGuId)
        {
            var shopNum1_OrderProduct_Action =
                (ShopNum1_OrderProduct_Action) LogicFactory.CreateShopNum1_OrderProduct_Action();
            return shopNum1_OrderProduct_Action.SelectOrderProductByGuIdorAll(OrderGuId,
                HttpUtility.HtmlDecode(
                    Common.Common.ReqStr("pn")));
        }
    }
}