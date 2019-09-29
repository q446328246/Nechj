using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_Order_List : BaseShopWebControl
    {
        public static DataTable dt_OrderList = null;
        public static DataTable orderProduct = null;
        private HtmlGenericControl htmlGenericControl_0;
        private HtmlGenericControl htmlGenericControl_1;
        private HtmlInputHidden htmlInputHidden_0;

        private LinkButton linkButton_0;
        private string skinFilename = "S_Order_List.ascx";

        public S_Order_List()
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
            linkButton_0 = (LinkButton) skin.FindControl("btnSub");
            linkButton_0.Click += linkButton_0_Click;
            htmlInputHidden_0 = (HtmlInputHidden) skin.FindControl("hidOrderGuId");
            if (!Page.IsPostBack)
            {
                method_0();
                method_2();
            }
        }

        protected void linkButton_0_Click(object sender, EventArgs e)
        {
            var shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action) LogicFactory.CreateShopNum1_OrderInfo_Action();
            shopNum1_OrderInfo_Action.SetOderStatus1(htmlInputHidden_0.Value, 1, 1, 0, DateTime.Now);
            var shopNum1_OrderOperateLog_Action =
                (ShopNum1_OrderOperateLog_Action) LogicFactory.CreateShopNum1_OrderOperateLog_Action();
            var shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
            shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
            shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(htmlInputHidden_0.Value);
            shopNum1_OrderOperateLog.CreateUser = MemLoginID;
            shopNum1_OrderOperateLog.OderStatus = 1;
            shopNum1_OrderOperateLog.ShipmentStatus = 0;
            shopNum1_OrderOperateLog.PaymentStatus = 1;
            shopNum1_OrderOperateLog.CurrentStateMsg = "卖家已确认订单";
            shopNum1_OrderOperateLog.NextStateMsg = "等待卖家发货";
            shopNum1_OrderOperateLog.Memo = "";
            shopNum1_OrderOperateLog.OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_OrderOperateLog.IsDeleted = 0;
            shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
            method_2();
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
            stringBuilder.Append(" and shopid='" + MemLoginID + "' and BuyIsDeleted=0 and feetype!=2");
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
                stringBuilder.Append(" and paytime>='" + text2 + "'");
            }
            if (text3 != "")
            {
                stringBuilder.Append(" and paytime<='" + text3 + "'");
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

        public static string setShipmentState(string strState)
        {
            string result;
            switch (strState)
            {
                case "0":
                    result = "未发货";
                    return result;
                case "1":
                    result = "已发货";
                    return result;
                case "2":
                    result = "已收货";
                    return result;
                case "3":
                    result = "已退货";
                    return result;
                case "4":
                    result = "退货成功";
                    return result;
                case "5":
                    result = "卖家拒绝退货";
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
                    result = "已退款";
                    return result;
                }
                if (strState == "3")
                {
                    result = "退款成功";
                    return result;
                }
                if (strState == "4")
                {
                    result = "卖家拒绝退款";
                    return result;
                }
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
            DataTable dataTable = shopNum1_OrderInfo_Action.SelectOrderListGZ(PageSize.ToString(), num.ToString(),
                method_1(), "3",
                HttpUtility.HtmlDecode(
                    Common.Common.ReqStr("pn")));
            int recordCount = Convert.ToInt32(dataTable.Rows[0][0]);
            var pageListBll = new PageListBll("shop/ShopAdmin/S_Order_List.aspx", true);
            var pageList = new PageList1();
            pageList.PageSize = PageSize;
            pageList.PageID = num;
            pageList.RecordCount = recordCount;
            htmlGenericControl_0.InnerHtml = pageListBll.GetPageListNew_two(pageList);
            htmlGenericControl_1.InnerHtml = pageListBll.GetPageListNew_two(pageList);
            pageList.PageCount = pageList.RecordCount/pageList.PageSize;
            if (pageList.PageCount < pageList.RecordCount/(double) pageList.PageSize)
            {
                pageList.PageCount++;
            }
            if (num > pageList.PageCount)
            {
                num = pageList.PageCount;
            }
            dt_OrderList = shopNum1_OrderInfo_Action.SelectOrderListGZ(PageSize.ToString(), num.ToString(), method_1(),
                "2",
                HttpUtility.HtmlDecode(Common.Common.ReqStr("pn")));
            if (dt_OrderList.Rows.Count == 0)
            {
                dt_OrderList = null;
            }

            
        }

        public static DataTable dt_GetOrderProduct(string OrderGuId)
        {
            HttpCookie cookie2 = HttpSecureCookie.Decode(HttpContext.Current.Request.Cookies["MemberLoginCookie"]);
            var shopNum1_OrderProduct_Action =
             (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();

            if (cookie2 != null)
            {
                return shopNum1_OrderProduct_Action.SelectOrderProductByGuIdorAllAndMemloginId(cookie2.Values["MemLoginID"], OrderGuId,
              HttpUtility.HtmlDecode(
                  Common.Common.ReqStr("pn")));
            }
            else
            {
                return shopNum1_OrderProduct_Action.SelectOrderProductByGuIdorAllAndMemloginId("", OrderGuId,
              HttpUtility.HtmlDecode(
                  Common.Common.ReqStr("pn")));
            }

         
          
        }
    }
}