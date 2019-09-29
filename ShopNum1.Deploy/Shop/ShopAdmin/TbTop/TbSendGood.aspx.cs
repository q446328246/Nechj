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
    public partial class TbSendGood : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //验证会员中心的cookies
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //退出
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
                string MemberType = decodedCookieMemberLogin.Values["MemberType"];
                if (MemberType != "2")
                {
                    //退出
                    GetUrl.RedirectTopLogin();
                    return;
                }
                //会员登录ID
            }

            hiddenFieldGuid.Value = Request.QueryString["tid"] == null ? "0" : Request.QueryString["tid"];

            if (!IsPostBack)
            {
                ProvinceBind();
                CitysBind();
                GetShipInfo(hiddenFieldGuid.Value.Replace("'", ""));
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            SendGoods();
        }

        public void SendGoods()
        {
            var trades = new List<TbTrade>();
            trades = GetTradeInfo(hiddenFieldGuid.Value);

            //卖家信息获取
            var Location = new List<TbLocation>();
            Location = GetSellerInfo();

            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            if (RadioButtonorder_type.SelectedValue == "3")
            {
                param.Add("order_type", "virtual_goods");
                param.Add("tid", hiddenFieldGuid.Value);
            }
            else
            {
                param.Add("tid", hiddenFieldGuid.Value);
                param.Add("order_type", "delivery_needed");
                param.Add("out_sid", TextBoxout_sid.Text);
                param.Add("company_code", Getcompanycode());
                param.Add("seller_name", trades[0].seller_name);
                param.Add("seller_area_id", GetAreaid()); //卖家所在地国家公布的标准地区码
                param.Add("seller_address", Location[0].address);
                param.Add("seller_zip", Location[0].zip);
                param.Add("seller_mobile", TextBoxseller_mobile.Text);
            }

            string strXml = TopAPI.Post("taobao.delivery.send", TopClient.AgentSession, param);
            var err = new ErrorRsp();
            var Shipping = new List<TbShipping>();
            new Parser().XmlToObject2(strXml, "delivery_send", "Shipping", Shipping, err);
            if (err.IsError) //判断是否更新过程中发生错误
            {
                MessageBox.Show(err.msg);
            }

            try
            {
                if (Shipping[0].is_success == "true")
                {
                    MessageBox.Show("发货成功");
                }
                else
                {
                    MessageBox.Show("发货失败");
                }
            }
            catch
            {
            }
        }

        //获取卖家所在地国家公布的标准地区码
        public string GetAreaid()
        {
            //卖家信息获取
            var Location = new List<TbLocation>();
            Location = GetSellerInfo();


            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            var Area = new List<TbArea>();
            param.Add("fields", "id,type,name,parent_id,zip");
            string strXml = string.Empty;
            strXml = TopAPI.Post("taobao.areas.get", TopClient.AgentSession, param);
            var err = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "areas_get", "areas/area", Area, err);
            string Areaid = string.Empty;

            for (int i = 0; i < Area.Count; i++)
            {
                if (Location[0].state == Area[i].name)
                {
                    Areaid = Area[i].parent_id;
                }
            }
            return Areaid;
        }

        //获取物流公司编码
        public string Getcompanycode()
        {
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            var logistics_companies = new List<TbLogistics_Companies>();
            param.Add("fields", "id,code,name");
            string strXml = string.Empty;
            strXml = TopAPI.Post("taobao.logistics.companies.get", TopClient.AgentSession, param);
            var err = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "logistics_companies_get", "logistics_companies/logistics_company",
                                      logistics_companies, err);
            if (err.IsError)
                return null;
            string code = "";
            for (int i = 0; i < logistics_companies.Count; i++)
            {
                if (DropDownListcompany_code.SelectedItem.Text == logistics_companies[i].name)
                {
                    code = logistics_companies[i].code;
                }
            }
            return code;
        }

        protected void RadioButtonorder_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonorder_type.SelectedValue == "3")
            {
                Panel1.Visible = false;
                nn.Visible = false;
            }
            else
            {
                nn.Visible = true;
                Panel1.Visible = true;
            }
            if (RadioButtonorder_type.SelectedValue == "2")
            {
                nn.Visible = false;
                mm.Visible = true;
            }
            else
            {
                //this.nn.Visible = true;
                mm.Visible = false;
            }
            if (RadioButtonorder_type.SelectedValue == "1")
            {
                date.Visible = true;
                dateTime.Visible = true;
            }
            else
            {
                date.Visible = false;
                dateTime.Visible = false;
            }
            if (RadioButtonorder_type.SelectedValue == "0")
            {
                Tr1.Visible = true;
            }
            else
            {
                Tr1.Visible = false;
            }
        }

        /// <summary>
        ///     省份绑定
        /// </summary>
        private void ProvinceBind()
        {
            //TbTbAddress_Action tbAddress = (TbTbAddress_Action)LogicTbFactory.CreateTbTbAddress_Action();
            //ddlProvince.DataSource = tbAddress.GetCitysByParent(1);
            //ddlProvince.DataTextField = "name";
            //ddlProvince.DataValueField = "Id";
            //ddlProvince.DataBind();
            //ddlProvince.SelectedIndex = 0;
        }


        /// <summary>
        ///     城市绑定
        /// </summary>
        /// <param name="Id"></param>
        private void CitysBind()
        {
            //int Id = Convert.ToInt32(ddlProvince.SelectedValue);
            //TbTbAddress_Action tbAddress = (TbTbAddress_Action)LogicTbFactory.CreateTbTbAddress_Action();
            //ddlCity.DataSource = tbAddress.GetCitysByParent(Id);
            //ddlCity.DataValueField = "Id";
            //ddlCity.DataTextField = "name";
            //ddlCity.DataBind();
        }


        /// <summary>
        ///     省份事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            CitysBind();
        }

        /// <summary>
        ///     更新发货信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            update();
        }

        //更新发货信息
        public void update()
        {
            var trades = new List<TbTrade>();
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            param.Add("tid", hiddenFieldGuid.Value);
            param.Add("receiver_name", TextBoxeller_name.Text);
            param.Add("receiver_phone", TextBoxseller_phone.Text);
            param.Add("receiver_mobile", TextBoxseller_mobile.Text);
            param.Add("receiver_state", ddlProvince.SelectedItem.ToString());
            param.Add("receiver_city", ddlCity.SelectedItem.ToString());
            //param.Add("receiver_district", this.ddlCity.SelectedItem.ToString());
            param.Add("receiver_address", TextBoxseller_address.Text);
            param.Add("receiver_zip", TextBoxseller_zip.Text);
            string strXml = string.Empty;
            strXml = TopAPI.Post("taobao.trade.shippingaddress.update", TopClient.AgentSession, param);
            //MessageBox.Show(strXml);
            var err = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "trade_shippingaddress_update", "trade", trades, err);
            if (err.IsError) //判断是否更新过程中发生错误
            {
                if (err.code == "520")
                {
                    MessageBox.Show("只能更新发货前的收获地址信息!");
                    return;
                }
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "error", string.Format("alert(\"添加商品失败！错误代码：{0}\\r错误原因：{1}\\r错误描述：{2}-{3}\");", err.code, err.msg, err.sub_code, err.sub_msg), true);
            }
        }

        /// <summary>
        ///     获取物流信息
        /// </summary>
        /// <returns></returns>
        public void GetShipInfo(string tid)
        {
            var trades = new List<TbTrade>();
            trades = GetTradeInfo(hiddenFieldGuid.Value);
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            param.Add("fields",
                      "seller_nick,buyer_nick,item_title,receiver_location,status,type,company_name,created,modified");
            param.Add("tid", tid);
            string strXml = TopAPI.Post("taobao.logistics.orders.detail.get", TopClient.AgentSession, param);
            var Location = new List<TbLocation>();
            var err = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "logistics_orders_detail_get", "shippings/shipping/location", Location,
                                      err);
            if (err.IsError)
                return;
            foreach (ListItem item in ddlProvince.Items)
            {
                if (item.Text == Location[0].state)
                {
                    ddlProvince.SelectedValue = item.Value;
                    CitysBind();
                }
            }
            TextBoxseller_zip.Text = Location[0].zip;
            TextBoxseller_address.Text = Location[0].address;
            TextBoxeller_name.Text = trades[0].receiver_name;
            TextBoxseller_phone.Text = trades[0].receiver_phone;
            TextBoxseller_mobile.Text = trades[0].receiver_mobile;
            TextBoxseller_mobile.Text = trades[0].receiver_mobile;
        }

        //获取
        public List<TbTrade> GetTradeInfo(string tid)
        {
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
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

        public List<TbLocation> GetSellerInfo()
        {
            var trades = new List<TbTrade>();
            trades = GetTradeInfo(hiddenFieldGuid.Value);
            var Location = new List<TbLocation>();
            var param = new Dictionary<string, string>(); //定义 API应用级输入参数
            param.Add("fields", "user_id,nick,seller_credit,location");
            param.Add("nick", trades[0].seller_nick);

            string strXml = TopAPI.Post("taobao.user.get", TopClient.AgentSession, param);
            var err = new ErrorRsp();
            new Parser().XmlToObject2(strXml, "user_get", "user/location", Location, err);
            if (err.IsError)
                return null;
            return Location;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("TbOrderView.aspx");
        }
    }
}