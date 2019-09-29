using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.TbBusinessEntity;
using ShopNum1.TbTopCommon;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbOrderView_Operate : Page
    {
        public string memo;

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
            }


            if (!TopClient.IsAgentLogin)
            {
                Response.Redirect("TbAuthorization.aspx");
            }
            if (!TopClient.isSessionTimeOut(Page, "agent"))
            {
                Response.Redirect("TbAuthorization.aspx");
            }

            hiddenFieldGuid.Value = Request.QueryString["guid"] == null ? "0" : Request.QueryString["guid"];


            if (!IsPostBack)
            {
                if (hiddenFieldGuid.Value != "0")
                {
                    //���ͷ�ʽ
                    GetShippings();
                    BindOrderData();
                    GroupRows(Num1GridView1, 6);
                    GroupRows(Num1GridView1, 7);
                    var trades1 = new List<TbTrade>();
                    trades1 = GetTradeInfo(hiddenFieldGuid.Value.Replace("'", ""));
                    if (trades1[0].seller_memo == string.Empty)
                    {
                        ButtonConfirm.Text = "���";
                    }
                    else
                    {
                        ButtonConfirm.Text = "����";
                    }
                }
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            var trades1 = new List<TbTrade>();
            trades1 = GetTradeInfo(hiddenFieldGuid.Value.Replace("'", ""));
            if (trades1[0].seller_memo == string.Empty)
            {
                #region //���

                var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
                param.Add("tid", hiddenFieldGuid.Value.Replace("'", ""));
                param.Add("memo", TextBoxNote.Text);
                string strXml = string.Empty;
                strXml = TopAPI.Post("taobao.trade.memo.add", TopClient.AgentSession, param);
                var err = new ErrorRsp();
                var tradeMemoRespons = new TradeMemoRespons();
                new Parser().XmlToObject2(strXml, "trade_memo_add", "trade", tradeMemoRespons, err);
                if (err.IsError) //�ж��Ƿ���¹����з�������
                {
                    //string dddfdfdfdf = dtAllNumIID.Rows[j]["num_iid"].ToString();
                    if (err.code == "520")
                    {
                        MessageBox.Show("���ҽ��ױ�ע�Ѿ�����!");
                        return;
                    }
                    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"�����Ʒʧ�ܣ�������룺{0}\\r����ԭ��{1}\\r����������{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
                }

                #endregion
            }
            else
            {
                var param1 = new Dictionary<string, string>(); //���� APIӦ�ü��������
                param1.Add("tid", hiddenFieldGuid.Value.Replace("'", ""));
                param1.Add("memo", TextBoxNote.Text);
                string strXml1 = TopAPI.Post("taobao.trade.memo.update", TopClient.AgentSession, param1);

                var tradeMemoRespons1 = new TradeMemoRespons();
                var err = new ErrorRsp();
                new Parser().XmlToObject2(strXml1, "trade_memo_update", "trade", tradeMemoRespons1, err);
            }
        }

        public void BindOrderData()
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            var err1 = new ErrorRsp();

            //���Ӷ�����Ϣ
            var Orders = new List<TbOrder>();
            Orders = GetChildOrders(hiddenFieldGuid.Value.Replace("'", ""));
            //�ø���������
            var trades = new List<TbTrade>();
            trades = GetTradeInfo(hiddenFieldGuid.Value.Replace("'", ""));
            //��������Ϣ
            var Location = new List<TbLocation>();
            Location = GetShipInfo(hiddenFieldGuid.Value.Replace("'", ""));

            var tradesShow = new List<TbTrade>(Orders.Count);

            for (int i = 0; i < Orders.Count; i++)
            {
                var TbTrade = new TbTrade();
                tradesShow.Add(TbTrade);
            }

            for (int i = 0; i < Orders.Count; i++)
            {
                tradesShow[i].tid = Orders[i].oid;
                tradesShow[i].pic_path = Orders[i].pic_path;
                tradesShow[i].title = Orders[i].title;
                tradesShow[i].status = trades[0].status;
                tradesShow[i].price = Orders[i].price;
                tradesShow[i].num = Orders[i].num;
                tradesShow[i].total_fee = trades[0].total_fee;
                // �����Ż�
                tradesShow[i].point_fee = Orders[i].total_fee;
                tradesShow[i].post_fee = trades[0].post_fee;
                LabelValueCreateTime.Text = trades[0].created;
                Labelvaluenick.Text = trades[0].buyer_nick;
                LabelValueName.Text = trades[0].receiver_name;
                LabelValueRegion.Text = trades[0].receiver_state + "&nbsp;&nbsp;" + trades[0].receiver_city;
                LabelValuePhone.Text = trades[0].receiver_phone;
                LabelValueOrderNum.Text = trades[0].tid;
                LabelValueZhifubao.Text = trades[0].buyer_alipay_no;
                LabelValueEmail.Text = trades[0].buyer_email;

                LabelValueZhifubaoNum.Text = trades[0].alipay_no;
                TextBoxNote.Text = trades[0].seller_memo;
                try
                {
                    if (Location != null)
                    {
                        LabelValueSAdress.Text = trades[0].receiver_name + "," + trades[0].receiver_mobile + "," +
                                                 trades[0].receiver_phone + "," + Location[0].state + Location[0].city +
                                                 Location[0].district + "," + Location[0].address + "," +
                                                 Location[0].zip;
                    }
                    else
                    {
                        LabelValueSAdress.Text = trades[0].receiver_state + "&nbsp;&nbsp;" + trades[0].receiver_city +
                                                 "&nbsp;&nbsp;" + trades[0].receiver_district;
                    }
                }
                catch
                {
                }
            }

            Num1GridView1.DataSource = tradesShow;
            Num1GridView1.DataBind();
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
        ///     ��ȡ�Ż����
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        private List<TbOrder> GetPromotionDetail(string tid)
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

        public string ChangePromotion(object Sprice, object total_fee)
        {
            decimal m = Convert.ToDecimal(Sprice) - Convert.ToDecimal(Convert.ToString(total_fee).Replace("-", ""));

            if (m != 0)
            {
                return "�Ż���" + m.ToString() + "Ԫ";
            }
            else
            {
                return "���Ż�";
            }
        }

        public static string Changestatus(object obj)
        {
            if (obj.ToString() == "TRADE_NO_CREATE_PAY")
            {
                return "û�д���֧��������";
            }
            else if (obj.ToString() == "WAIT_BUYER_PAY")
            {
                return "�ȴ�����";
            }
            else if (obj.ToString() == "WAIT_SELLER_SEND_GOODS")
            {
                return "����Ѹ���";
            }
            else if (obj.ToString() == "WAIT_BUYER_CONFIRM_GOODS")
            {
                return "��ȷ���ջ�";
            }
            else if (obj.ToString() == "TRADE_BUYER_SIGNED")
            {
                return "�����ǩ��";
            }
            else if (obj.ToString() == "TRADE_FINISHED")
            {
                return "���׳ɹ�";
            }
            else if (obj.ToString() == "TRADE_CLOSED")
            {
                return "���׹ر�";
            }
            else if (obj.ToString() == "TRADE_CLOSED_BY_TAOBAO")
            {
                return "���Ա��ر�";
            }
            else if (obj.ToString() == "ALL_WAIT_PAY")
            {
                return "ALL�ȴ�����";
            }
            else
            {
                return "ALL���׹ر�";
            }
        }

        /// <summary>
        ///     ��ȡ������Ϣ
        /// </summary>
        /// <returns></returns>
        public List<TbLocation> GetShipInfo(string tid)
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            param.Add("fields",
                      "seller_nick,buyer_nick,item_title,receiver_location,status,type,company_name,created,modified");
            param.Add("tid", tid);
            string strXml = TopAPI.Post("taobao.logistics.orders.detail.get", TopClient.AgentSession, param);
            var Location = new List<TbLocation>();
            var err = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "logistics_orders_detail_get", "shippings/shipping/location", Location,
                                      err);
            if (err.IsError)
                return null;
            return Location;
        }

        public List<TbShipping> GetShipInfo1(string tid)
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            param.Add("fields",
                      "seller_nick,buyer_nick,item_title,receiver_location,status,type,company_name,created,modified");
            param.Add("tid", tid);
            string strXml = TopAPI.Post("taobao.logistics.orders.detail.get", TopClient.AgentSession, param);
            var Shipings = new List<TbShipping>();
            var err = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "logistics_orders_detail_get", "shippings/shipping", Shipings, err);
            if (err.IsError)
                return null;
            return Shipings;
        }

        public void GetShippings()
        {
            //������Ϣ
            var Shippings = new List<TbShipping>();
            try
            {
                //������Ϣ
                Shippings = GetShipInfo1(hiddenFieldGuid.Value.Replace("'", ""));
                if (Shippings[0].type == "free")
                {
                    Label1ValueTrade.Text = "���Ұ���";
                }
                else if (Shippings[0].type == "post")
                {
                    Label1ValueTrade.Text = "ƽ��";
                }
                else if (Shippings[0].type == "express")
                {
                    Label1ValueTrade.Text = "���";
                }
                else if (Shippings[0].type == "ems")
                {
                    Label1ValueTrade.Text = "EMS";
                }
                else
                {
                    Label1ValueTrade.Text = "��һ�û����ȴ���";
                }
            }
            catch
            {
            }
        }

        public List<TbTrade> GetTradeInfo(string tid)
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            param.Add("fields",
                      "seller_nick, buyer_nick, title, type, created, tid, seller_rate,buyer_flag, buyer_rate, status, payment, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, buyer_memo, seller_memo, alipay_no, buyer_message, pic_path, num_iid, num, price, buyer_alipay_no, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone, buyer_email,seller_flag, seller_alipay_no, seller_mobile, seller_phone, seller_name, seller_email, available_confirm_fee, has_post_fee, timeout_action_time, snapshot_url, cod_fee, cod_status, shipping_type, trade_memo, is_3D,buyer_memo,buyer_email");
            param.Add("tid", tid);
            string strXml = TopAPI.Post("taobao.trade.fullinfo.get", TopClient.AgentSession, param);

            var trades = new List<TbTrade>();
            var err = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "trade_fullinfo_get", "trade", trades, err);
            if (err.IsError)
                return null;
            return trades;
        }

        public string GetUrl(object tid)
        {
            return "http://trade.taobao.com/trade/detail/trade_snap.htm?" + "tradeID=" + tid + "&&isArchive=false";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("TbOrderView.aspx");
        }

        /// <summary>
        ///     �ϲ�GridView��ĳ����ͬ��Ϣ���У���Ԫ��
        /// </summary>
        /// <param name="GridView1">GridView</param>
        /// <param name="cellNum">�ڼ���</param>
        public static void GroupRows(GridView GridView1, int cellNum)
        {
            int i = 0, rowSpanNum = 1;

            while (i < GridView1.Rows.Count - 1)
            {
                GridViewRow gvr = GridView1.Rows[i];

                for (++i; i < GridView1.Rows.Count; i++)
                {
                    GridViewRow gvrNext = GridView1.Rows[i];

                    if (gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text)
                    {
                        gvrNext.Cells[cellNum].Visible = false;

                        rowSpanNum++;
                    }

                    else
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;

                        rowSpanNum = 1;

                        break;
                    }

                    if (i == GridView1.Rows.Count - 1)
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                    }
                }
            }
        }

        #region //������Դ ��ʱ����

        public void BindData()
        {
            var param = new Dictionary<string, string>(); //���� APIӦ�ü��������
            var err1 = new ErrorRsp();
            var trades = new List<TbTrade>();
            var trades2 = new List<TbTrade>();
            //������Ϣ
            var Location = new List<TbLocation>();
            Location = GetShipInfo(hiddenFieldGuid.Value.Replace("'", ""));

            var trades1 = new List<TbTrade>();
            trades1 = GetTradeInfo(hiddenFieldGuid.Value.Replace("'", ""));

            var Orders = new List<TbOrder>();
            Orders = GetChildOrders(hiddenFieldGuid.Value.Replace("'", ""));

            var tradesData = new List<TbTrade>();
            string pagesize = "200";
            int total = 200;

            for (int i = 1; i < total/200 + 1; i++)
            {
                string strXml = string.Empty;
                param.Clear();
                param.Add("fields",
                          "buyer_nick,title, type,created,sid,tid, seller_rate,buyer_rate,buyer_alipay_no, status, payment, discount_fee, adjust_fee, post_fee, total_fee, pay_time, end_time, modified, consign_time, buyer_obtain_point_fee, point_fee, real_point_fee, received_payment, commission_fee, pic_path, num_iid, num, price, cod_fee, cod_status, shipping_type, receiver_name, receiver_state, receiver_city, receiver_district, receiver_address, receiver_zip, receiver_mobile, receiver_phone,orders");
                param.Add("pagesize", pagesize);
                //ÿһҳ��������
                param.Add("page_no", i.ToString());
                strXml = TopAPI.Post("taobao.trades.sold.get", TopClient.AgentSession, param);
                new Parser().XmlToObject2(strXml, "trades_sold_get", "trades/trade", trades, err1);
                total = new Parser().XmlToTotalResults(strXml, "trades_sold_get");
                if (err1.IsError) //�ж��Ƿ���¹����з�������
                {
                    return;
                }
                for (int k = 0; k < trades.Count; k++)
                {
                    if (trades[k].tid == hiddenFieldGuid.Value.Replace("'", ""))
                    {
                        trades2.Add(trades[k]);
                        tradesData = trades2;
                        for (int j = 0; j < tradesData.Count; j++)
                        {
                            tradesData[j].pic_path = Orders[0].pic_path;
                            tradesData[j].title = Orders[0].title;
                            tradesData[j].status = trades[k].status;
                            //tradesData[j].sid = trades[k].sid;

                            tradesData[j].price = trades[k].price;
                            tradesData[j].num = trades[k].num;
                            tradesData[j].total_fee = Orders[0].total_fee;
                            tradesData[j].buyer_nick = trades[k].buyer_nick;
                            tradesData[j].receiver_address = trades[k].receiver_address;
                            tradesData[j].receiver_zip = trades[k].receiver_zip;
                            tradesData[j].receiver_name = trades[k].receiver_name;
                            tradesData[j].receiver_mobile = trades[k].receiver_mobile;
                            tradesData[j].receiver_district = trades[k].receiver_district;
                            tradesData[j].receiver_city = trades[k].receiver_city;
                            tradesData[j].receiver_state = trades[k].receiver_state;
                            tradesData[j].receiver_phone = trades[k].receiver_phone;
                            tradesData[j].post_fee = trades[k].post_fee;
                            LabelValueCreateTime.Text = trades[k].created;
                            Labelvaluenick.Text = trades[k].buyer_nick;
                            LabelValueName.Text = trades[k].receiver_name;
                            LabelValueRegion.Text = trades[k].receiver_state + "&nbsp;&nbsp;" + trades[k].receiver_city;
                            LabelValuePhone.Text = trades[k].receiver_phone;
                            LabelValueOrderNum.Text = trades[k].tid;
                            LabelValueZhifubao.Text = trades1[0].buyer_alipay_no;
                            LabelValueEmail.Text = trades1[0].buyer_email;

                            LabelValueZhifubaoNum.Text = trades1[0].alipay_no;
                            TextBoxNote.Text = trades1[0].seller_memo;
                            //MessageBox.Show(trades[k].seller_memo);
                            //������Ϣ
                            try
                            {
                                if (Location != null)
                                {
                                    LabelValueSAdress.Text = trades[k].receiver_name + "," + trades[k].receiver_mobile +
                                                             "," + trades[k].receiver_phone + "," + Location[0].state +
                                                             Location[0].city + Location[0].district + "," +
                                                             Location[0].address + "," + Location[0].zip;
                                }
                                else
                                {
                                    LabelValueSAdress.Text = trades[k].receiver_state + "&nbsp;&nbsp;" +
                                                             trades[k].receiver_city + "&nbsp;&nbsp;" +
                                                             trades[k].receiver_district;
                                }
                            }
                            catch
                            {
                            }
                            //this.Label1ValueTrade.Text = "���Ұ���";
                        }
                        //string promotion_details=trades[k].promotion_details;;
                    }
                }
            }
            Num1GridView1.DataSource = tradesData;
            Num1GridView1.DataBind();
        }

        #endregion
    }
}