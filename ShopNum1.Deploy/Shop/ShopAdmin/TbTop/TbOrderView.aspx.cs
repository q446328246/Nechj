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
        private string ShopName; //��������
        public string MemLoginID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //��֤��Ա���ĵ�cookies
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //�˳�
                Common.GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
                string MemberType = decodedCookieMemberLogin.Values["MemberType"];

                if (MemberType != "2")
                {
                    //�˳�

                    Common.GetUrl.RedirectTopLogin();
                    return;
                }
                //��Ա��¼ID
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
                    ///ҳ��
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
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            string strXml = string.Empty;
            var err = new ErrorRsp();
            var orders = new List<TbOrder>();
            var trades = new List<TbTrade>();
            ///�����Ų�Ϊ�յ�ʱ��
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
            //�践�ص��ֶ��б�
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
                    MessageBox.Show("��ʼʱ���ʽ����");

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
                    MessageBox.Show("����ʱ���ʽ����");

                    txtEndTime.Focus();
                    return;
                }
            }
            if (txtStartTime.Text.Trim() != "" && txtEndTime.Text.Trim() != "")
            {
                if (time1 > time2)
                {
                    MessageBox.Show("��ʼʱ��Ӧ�ñȽ���ʱ����!");
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

            //ÿҳ������ȡֵ��Χ:�����������;���ֵ��200��Ĭ��ֵ��40�� 
            param.Add("page_size", pagelist.PageSize.ToString());
            //ҳ�롣ȡֵ��Χ:�����������;Ĭ��ֵΪ1�������ص�һҳ���ݡ� 
            param.Add("page_no", pagelist.PageID.ToString());
            strXml = TopAPI.Post("taobao.trades.sold.get", TopClient.AgentSession, param);

            new Parser().XmlToObject2(strXml, "trades_sold_get", "trades/trade", trades, err);


            int total = new Parser().XmlToTotalResults(strXml, "trades_sold_get");
            pagelist.RecordCount = total;
            if (err.IsError) //�ж��Ƿ���¹����з�������
            {
                if (err.code == "41")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "msg", "alert(\"������ѡ��ʱ�䷶Χ,ǰ��������\");",
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
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert('�رճɹ�')", true);
                    return;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert('�ر�ʧ��')", true);
                }
            }
        }

        /// <summary>
        ///     ���ҷ���
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
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            //�践�ص��ֶ��б�
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
            if (err.IsError) //�ж��Ƿ���¹����з�������
            {
                //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
                ScriptManager.RegisterClientScriptBlock(Page, typeof (Page), "error",
                                                        string.Format(
                                                            "alert(\"����ʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");",
                                                            err.code,
                                                            err.msg, err.sub_code, err.sub_msg), true);
                return false;
            }
            return true;
        }

        /// <summary>
        ///     ��ȡ�Ӷ���
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        private List<TbOrder> GetChildOrders(string tid)
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
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
        ///     �ر�һ�ʽ��ף�ֻ�ܹر�������������δ����Ľ���
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
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            //�践�ص��ֶ��б�
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
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert('�رճɹ�')", true);
                return;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "msg", "alert('�ر�ʧ��')", true);
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
                MessageBox.Show("��ѡ������Ѹ���Ķ���");
            }
            else
            {
                Page.Response.Redirect("TbSendGood.aspx?tid=" + CheckGuid.Value.Replace("'", ""));
            }
        }

        public List<TbTrade> GetTrade(string tid)
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
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