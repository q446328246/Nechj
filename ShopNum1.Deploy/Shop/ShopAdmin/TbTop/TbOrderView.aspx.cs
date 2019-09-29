using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.TbBusinessEntity;
using ShopNum1.TbTopCommon;
using PageListBll = ShopNum1.TbTopCommon.PageListBll;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbOrderView : Page
    {
        private string ShopName; //店铺名称
        public string MemLoginID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //验证会员中心的cookies
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //退出
                Common.GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
                string MemberType = decodedCookieMemberLogin.Values["MemberType"];

                if (MemberType != "2")
                {
                    //退出

                    Common.GetUrl.RedirectTopLogin();
                    return;
                }
                //会员登录ID
                MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"];
            }

            bool isExisit = CheckMemberID(MemLoginID);
            if (!isExisit)
            {
                Response.Redirect("TbAuthorization.aspx");
            }
            if (!IsPostBack)
            {
                BindOrderList("0");
            }
            else
            {
                if (Page.Request.Form["pageid"] != null && Page.Request.Form["pageid"] != "0")
                {
                    ///页数
                    string pageid = Page.Request.Form["pageid"];
                    BindOrderList(pageid);
                }
            }
        }

        private bool CheckMemberID(string MemLoginID)
        {
            try
            {
                ShopName =
                    HttpUtility.UrlDecode(
                        HttpContext.Current.Request.Cookies[TopConfig.AgentCookiesName]["visitor_nick"]);
            }
            catch
            {
                ShopName = "";
            }


            var tbSystem = (ShopNum1_TbSystem_Action) LogicTbFactory.CreateShopNum1_TbSystem_Action();
            if (tbSystem.GetTbSysem(MemLoginID, ShopName) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            BindOrderList("0");
        }

        private void BindOrderList(string pageid)
        {
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            string strXml = string.Empty;
            var err = new ErrorRsp();
            var orders = new List<TbOrder>();
            var trades = new List<TbTrade>();
            ///订单号不为空的时候
            if (txtOrderID.Text.Trim() != "")
            {
                param.Add("fields",
                          "seller_nick, buyer_nick, title, type, created, tid, seller_rate, buyer_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,orders");
                param.Add("tid", txtOrderID.Text.Trim());
                strXml = TopAPI.Post("taobao.trade.get", TopClient.AgentSession, param);
                new Parser().XmlToObject2(strXml, "trade_get", "trade", trades, err);
                if (err.IsError)
                    return;
                RepeaterOrder.DataSource = trades;
                //RepeaterOrder.DataKeyField = "tid";
                RepeaterOrder.DataBind();
                return;
            }
            var pagelist = new PageList();
            pagelist.PageSize = 10;
            pagelist.PageID = int.Parse(pageid);

            //paglist.RecordCount
            //需返回的字段列表。
            param.Clear();
            param.Add("fields",
                      "buyer_nick, type,created,sid,tid, seller_rate, buyer_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,orders");
            if (txtbuyer.Text.Trim() != "")
            {
                param.Add("buyer_nick", txtbuyer.Text.Trim());
            }

            DateTime time1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            DateTime time2 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (txtStartTime.Text.Trim() != "")
            {
                try
                {
                    time1 = Convert.ToDateTime(txtStartTime.Text.Trim());
                }

                catch
                {
                    MessageBox.Show("开始时间格式不对");

                    txtStartTime.Focus();
                    return;
                }
            }
            if (txtEndTime.Text.Trim() != "")
            {
                try
                {
                    time2 = Convert.ToDateTime(txtEndTime.Text.Trim());
                }

                catch
                {
                    MessageBox.Show("结束时间格式不对");

                    txtEndTime.Focus();
                    return;
                }
            }
            if (txtStartTime.Text.Trim() != "" && txtEndTime.Text.Trim() != "")
            {
                if (time1 > time2)
                {
                    MessageBox.Show("开始时间应该比结束时间早!");
                    txtStartTime.Focus();
                    return;
                }
                param.Add("start_created", time1.ToString("yyyy-MM-dd"));
                param.Add("end_created", time2.ToString("yyyy-MM-dd"));
            }
            if (ddlOrderState.SelectedValue != "0")
            {
                param.Add("status", ddlOrderState.SelectedValue);
            }
            if (ddlRateState.SelectedValue != "0")
            {
                param.Add("rate_status", ddlRateState.SelectedValue);
            }
            if (ddlistdelivery.SelectedValue != "0")
            {
                param.Add("type", ddlistdelivery.SelectedValue);
            }

            //每页条数。取值范围:大于零的整数;最大值：200；默认值：40。 
            param.Add("page_size", pagelist.PageSize.ToString());
            //页码。取值范围:大于零的整数;默认值为1，即返回第一页数据。 
            param.Add("page_no", pagelist.PageID.ToString());
            strXml = TopAPI.Post("taobao.trades.sold.get", TopClient.AgentSession, param);

            new Parser().XmlToObject2(strXml, "trades_sold_get", "trades/trade", trades, err);


            int total = new Parser().XmlToTotalResults(strXml, "trades_sold_get");
            pagelist.RecordCount = total;
            if (err.IsError) //判断是否更新过程中发生错误
            {
                if (err.code == "41")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "msg", "alert(\"请重新选择时间范围,前后三个月\");",
                                                            true);
                    txtEndTime.Text = "";
                    txtStartTime.Text = "";
                    txtStartTime.Focus();
                    return;
                }
            }

            RepeaterOrder.DataSource = trades;
            //RepeaterOrder.DataKeyField = "tid";
            RepeaterOrder.DataBind();
            var pagelistHtmlCreate = new PageListBll();
            pagelistHtmlCreate.ShowRecordCount = true;
            pagelistDiv.InnerHtml = pagelistHtmlCreate.GetPageList(pagelist);
        }

        protected void RepOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "close")
            {
                var divReason = (HtmlGenericControl) e.Item.FindControl("divReason");
                divReason.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else if (e.CommandName == "closeOk")
            {
                var txtCloseReason = (TextBox) e.Item.FindControl("txtCloseReason");
                string tid = "";
                string reason = txtCloseReason.Text.Trim();
                if (CloseTrade(tid, reason))
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert('关闭成功')", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert('关闭失败')", true);
                }
            }
        }

        /// <summary>
        ///     卖家发货
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="company_code"></param>
        /// <param name="out_sid"></param>
        /// <param name="seller_name"></param>
        /// <param name="seller_area_id"></param>
        /// <param name="sell_address"></param>
        /// <param name="sell_zip"></param>
        /// <param name="seller_phone"></param>
        /// <param name="sell_mobile"></param>
        /// <param name="order_type"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        private bool SendOrder
            (
            decimal tid,
            string company_code,
            string out_sid,
            string seller_name,
            string seller_area_id,
            string sell_address,
            string sell_zip,
            string seller_phone,
            string sell_mobile,
            string order_type,
            string memo
            )
        {
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            //需返回的字段列表。
            param.Add("fields", "pid,modified");
            param.Add("tid", tid.ToString());
            param.Add("company_code", company_code);
            param.Add("out_sid", out_sid);
            param.Add("seller_name", seller_name);
            param.Add("seller_area_id", seller_area_id);
            param.Add("sell_address", sell_address);
            param.Add("sell_zip", company_code);
            param.Add("seller_phone", seller_phone);
            param.Add("sell_mobile", sell_mobile);
            param.Add("order_type", order_type);
            param.Add("memo", memo);

            string strXml = TopAPI.Post("taobao.delivery.send", TopClient.AgentSession, param);
            var err = new ErrorRsp();
            var delivery = new DeliveryResponse();
            new Parser().XmlToObject2(strXml, "delivery_send", delivery, err);
            if (err.IsError) //判断是否更新过程中发生错误
            {
                //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
                ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "error",
                                                        string.Format(
                                                            "alert(\"操作失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");",
                                                            err.code,
                                                            err.msg, err.sub_code, err.sub_msg), true);
                return false;
            }
            return true;
        }

        /// <summary>
        ///     获取子订单
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        private List<TbOrder> GetChildOrders(string tid)
        {
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            param.Add("fields", "orders");
            param.Add("tid", tid);
            string strXml = TopAPI.Post("taobao.trade.get", TopClient.AgentSession, param);
            var orders = new List<TbOrder>();
            var err = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "trade_get", "trade/orders/order", orders, err);
            if (err.IsError)
                return null;
            return orders;
        }

        /// <summary>
        ///     关闭一笔交易，只能关闭主订单并且是未付款的交易
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="close_reason"></param>
        /// <returns></returns>
        private bool CloseTrade
            (
            string tid,
            string close_reason
            )
        {
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            //需返回的字段列表。
            param.Add("tid", tid);
            param.Add("close_reason", close_reason);
            var err = new ErrorRsp();
            string strXml = TopAPI.Post("taobao.trade.close", TopClient.AgentSession, param);
            //ShopNum1.Common.MessageBox.Show(strXml);
            var xml = new XmlDocument();
            xml.LoadXml(strXml);
            try
            {
                new Parser().XmlErrorToObject2(xml, err);
                return !err.IsError;
            }
            catch
            {
                return false;
            }
        }


        protected void RepOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var RepeaterChildOrder = (Repeater) e.Item.FindControl("RepeaterChildOrder");
                var LinkButton_Tid = (LinkButton) e.Item.FindControl("LinkButton_Tid");
                string tid = LinkButton_Tid.CommandArgument;
                RepeaterChildOrder.DataSource = GetChildOrders(tid);
                RepeaterChildOrder.DataBind();
                var LinkButtonClose = (LinkButton) e.Item.FindControl("LinkButtonClose");
                var LinkButtonSend = (LinkButton) e.Item.FindControl("LinkButtonSend");
                if (LinkButtonSend.CommandArgument == " WAIT_SELLER_SEND_GOODS")
                {
                    LinkButtonSend.Visible = true;
                }
                else
                {
                    LinkButtonSend.Visible = false;
                }
                if (LinkButtonClose.CommandArgument == "WAIT_BUYER_PAY")
                {
                    LinkButtonClose.Visible = true;
                }
                else
                {
                    LinkButtonClose.Visible = false;
                }
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Response.Redirect("TbOrderView_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CloseTrade(CheckGuid.Value.Replace("'", ""), DropDownListReasons.SelectedItem.ToString()))
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert('关闭成功')", true);
                return;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert('关闭失败')", true);
            }
            BindOrderList("0");
        }

        public string GetUrl(object oid)
        {
            return "http://trade.taobao.com/trade/detail/trade_snap.htm?" + "tradeID=" + oid + "&&isArchive=false";
        }

        protected void btnSendProduct_Click(object sender, EventArgs e)
        {
            var trades = new List<TbTrade>();
            trades = GetTrade(CheckGuid.Value.Replace("'", ""));

            if (trades[0].status != "WAIT_SELLER_SEND_GOODS")
            {
                MessageBox.Show("请选择买家已付款的订单");
            }
            else
            {
                Page.Response.Redirect("TbSendGood.aspx?tid=" + CheckGuid.Value.Replace("'", ""));
            }
        }

        public List<TbTrade> GetTrade(string tid)
        {
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            string strXml = string.Empty;
            var err = new ErrorRsp();
            var trades = new List<TbTrade>();
            param.Add("fields",
                      "seller_nick, buyer_nick, title, type, created, tid, seller_rate, buyer_rate, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,orders");
            param.Add("tid", tid);
            strXml = TopAPI.Post("taobao.trade.get", TopClient.AgentSession, param);

            new Parser().XmlToObject2(strXml, "trade_get", "trade", trades, err);
            if (err.IsError)
                return null;
            return trades;
        }
    }
}