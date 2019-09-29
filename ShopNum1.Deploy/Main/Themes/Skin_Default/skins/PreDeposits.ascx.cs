using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Web;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.Payment;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Standard;
using ShopNum1.WebControl;
using ShopNum1MultiEntity;
using System.Web.UI.WebControls;
using ShopNum1.Common.ShopNum1.Common;
using System.Text;


namespace ShopNum1.Deploy.Main.Themes.Skin_Default.skins
{
    public partial class PreDeposits : BaseUserControl
    {

        //private RadioButtonList RadioButtonScore_hv;
        private byte byte_0;
        private DataSet dataSet_0;
        private DataSet dataSet_1;
        private DataTable dt;
        protected string JyFs;
        protected string Jf;
        private string string_0;
        private string string_2;
        private string string_3;
        private string string_4;
        private string string_5;
        private string string_6 = string.Empty;
        private string string_7 = string.Empty;

        private decimal MyScore_hv_txt;
        private decimal MyScore_pv_a_txt;
        private decimal MyScore_pv_b_txt;
        private decimal MyScore_hv;
        private decimal MyScore_pv_a;
        private decimal MyScore_pv_b;
        private decimal MyScore_pv_c;

        private decimal MYlabelScore_cv;
        private decimal MYlabelScore_max_hv;
        private decimal MYlabelScore_pv_cv_txt;
        private decimal MYlabelScore_cv_txt;
        private decimal MYlabelScore_max_hv_tx;
        private decimal ShouldPay;
        private decimal MYlabelScore_dv_txt;
        private decimal MyScore_dv;
        private decimal ShouldDv;

        private decimal Deduction_pv_b;
        private string OrderinfoId;
        private string MemLoginIDId;


        protected string allOrderguid;
        protected string allOrderordertype;
        protected string allOrdershop_category_id;



        #region 退款记录

        private decimal GZ_Score_hv;
        private decimal GZ_Score_pv_a;
        private decimal GZ_Score_pv_b;
        private decimal GZ_Score_pv_cv;
        private decimal GZ_Score_dv;
        private decimal GZ_PaymentPrice;
        private decimal GZ_reduce_score_hv;
        private decimal GZ_reduce_score_pv_a;
        private decimal GZ_reduce_score_pv_b;
        private decimal GZ_reduce_score_pv_cv;
        private decimal GZ_reduce_score_dv;
        private decimal GZ_reduce_PaymentPrice;
        private decimal GZ_reduce_score_TJ_hv;
        private string GZ_reduce_TJID;
        #endregion


        //消费的红包数量
        private decimal XiaoFei_hv;


        private string ProductGuid { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                string_2 = httpCookie.Values["MemLoginID"];
                var payUrlOperate = new PayUrlOperate();
                SortedDictionary<string, string> requestGet = GetRequestGet();

                if (requestGet.Count != 8)
                {

                    byte_0 = 1;

                }
                else
                {
                    if (Page.Request.QueryString["sign"] != null)
                    {
                        if (!payUrlOperate.CheckSign(requestGet, Page.Request.QueryString["sign"]))
                        {
                            byte_0 = 2;
                        }
                        else
                        {
                            if (Page.Request.QueryString["timetemp"] != null)
                            {
                                long num = Convert.ToInt64(Page.Request.QueryString["timetemp"]);
                                if (DateTime.Now.Ticks - num > 0L)
                                {
                                    byte_0 = 3;
                                    return;
                                }
                                string text = Page.Request.QueryString["memlogid"].Trim().Replace(" ", "+");
                                if (string_2.Trim().ToLower() != text.Trim().ToLower())
                                {
                                    byte_0 = 4;
                                    return;
                                }
                                //ButtonPay.Click += ButtonPay_Click;
                                if (Page.Request.QueryString["TradeID"] == null ||
                                    Page.Request.Cookies["MemberLoginCookie"] == null)
                                {
                                    Page.Response.Redirect("http://" + ShopSettings.siteDomain);
                                }
                                else
                                {
                                    method_0();
                                }
                                string nameById = Common.Common.GetNameById("PayPwd", "ShopNum1_Member",
                                                                            "    AND  MemLoginID='" + string_2 + "'");
                                if (string.IsNullOrEmpty(nameById))
                                {
                                    noPay.Visible = true;
                                }
                                else
                                {
                                    noPay.Visible = false;
                                }
                                try
                                {
                                    decimal num2 = Convert.ToDecimal(LabelShouldPay.Text);
                                    decimal num3 = Convert.ToDecimal(labelScore_cv.Text);
                                    decimal mmm4 = Convert.ToDecimal(labelScore_dv.Text);
                                    if ((num2.ToString() == "0.00" && num3.ToString() == "0.00" && mmm4.ToString() == "0.00") || (num2.ToString() == "0" && num3.ToString() == "0" && mmm4.ToString() == "0") || (num2.ToString() == "" && num3.ToString() == "" && mmm4.ToString() == ""))
                                    {
                                        Page.Response.Redirect("/Main/Member/M_Index.aspx");
                                        return;
                                    }
                                    return;
                                }
                                catch (Exception)
                                {
                                    Page.Response.Redirect("/Main/Member/M_Index.aspx");
                                    return;
                                }
                            }
                            byte_0 = 3;
                        }
                    }
                    else
                    {
                        byte_0 = 2;
                    }
                }
            }
            else
            {
                GetUrl.RedirectLogin();
            }
        }

        protected void ButtonPay_Click(object sender, EventArgs e)
        {



            var shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            if (ShopSettings.GetValue("IsMobileCheckPay") == "1")
            {
                int num = 0;
                try
                {
                    string nameById = Common.Common.GetNameById("mobile", "shopnum1_member",
                                                                " and memloginId='" + string_2 + "' and mobile!=''");
                    var shopNum1_MemberActivate_Action =
                        (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
                    if (shopNum1_MemberActivate_Action.CheckMobileCode(txtMobileCode.Text, nameById, "2") != "0")
                    {
                        num = 1;
                    }
                }
                catch
                {
                }
                if (num != 1)
                {
                    MessageBox.Show("手机验证码不正确！");
                    return;
                }
            }
            string payPwd = shopNum1_Member_Action.GetPayPwd(string_2);
            if (payPwd == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                        "<script>alert(\"请先设置交易密码才能进行支付交易！\");location.href='http://" +
                                                        ShopSettings.siteDomain +
                                                        "/Main/Account/a_index.aspx?toaurl=A_PwdSer.aspx';</script>");
            }
            else
            {
                string md5SecondHash = Common.Encryption.GetMd5SecondHash(TextBoxPayPass1word.Text.Trim());
                if (payPwd != md5SecondHash)
                {
                    MessageBox.Show("您输入的交易密码不正确！");
                }
                else
                {
                    if (JyFs == "唐江智付支付")
                    {
                        decimal num2 = Convert.ToDecimal(LabelShouldPay.Text);
                        if (num2 < 0 || num2 == 0)
                        {
                            MessageBox.Show("您的交易金额为0，不能使用智付支付，请在【我是买家】-【我的订单】-【查看】中修改支付方式为预存款支付，然后再进行支付！");
                        }
                        else
                        {
                            GetPayUrl();
                        }
                    }
                    else if (JyFs == "支付宝")
                    {
                        decimal num2 = Convert.ToDecimal(LabelShouldPay.Text);
                        if (num2 < 0 || num2 == 0)
                        {
                            MessageBox.Show("您的交易金额为0，不能使用支付宝，请在【我是买家】-【我的订单】-【查看】中修改支付方式为预存款支付，然后再进行支付！");
                        }
                        else
                        {
                            GetAliPayUrl();
                        }
                    }
                    else
                    {
                        try
                        {
                            #region 金币支付
                            var arg_122_0 =
                                (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                            decimal num2 = Convert.ToDecimal(LabelShouldPay.Text);
                            decimal nom3 = 0M;
                            decimal nom4 = 0M;
                            if (Jf == "兑换")
                            {
                                nom4 = 0M;
                                nom3 = Deduction_pv_b;
                            }
                            else
                            {
                                nom4 = Convert.ToDecimal(labelScore_dv.Text);
                            }
                            if (nom4 < 0)
                            {
                                nom4 = nom4 * (-1);
                            }
                            if ((num2.ToString() == "0.00" && nom3.ToString() == "0.00" && nom4.ToString() == "0.00") || (num2.ToString() == "0" && nom3.ToString() == "0" && nom4.ToString() == "0"))
                            {
                                Page.Response.Redirect("/Main/Member/M_Index.aspx");
                            }
                            else
                            {
                                ShopNum1_OrderInfo_Action orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                                ShopNum1_Member_Action memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                decimal num3 = Convert.ToDecimal(LabelAdvancePayment.Text);
                                string a = Page.Request.QueryString["type"];
                                string MemRankGuid = shopNum1_Member_Action.GetMemberRankGuid(string_2);

                                DataTable ServiceAgenttable = memaction.SearchMembertwo(MemLoginIDId);
                                decimal myBV = Convert.ToDecimal(ServiceAgenttable.Rows[0]["AdvancePayment"]);
                                decimal myDV = Convert.ToDecimal(ServiceAgenttable.Rows[0]["Score_dv"]);
                                decimal myPVA = Convert.ToDecimal(ServiceAgenttable.Rows[0]["Score_pv_a"]);


                                //if (MemRankGuid == MemberLevel.NORMAL_MEMBER_ID && (num2 > num3 || MYlabelScore_cv_txt * (-1) > MyScore_pv_b))
                                if (allOrdershop_category_id == "1" && num2 > myBV)
                                {
                                    MessageBox.Show("您当前帐户上面的人民币不足，无法支付!");
                                    TextBoxPayPass1word.Text = "";
                                }
                                else if (allOrdershop_category_id == "2" && num2 > myPVA)
                                {
                                    MessageBox.Show("您当前帐户上面的新能源链不足，无法支付!");
                                    TextBoxPayPass1word.Text = "";
                                }
                                else if (allOrdershop_category_id == "3" && num2 > myBV)
                                {
                                    MessageBox.Show("您当前帐户上面的人民币币不足，无法支付!");
                                    TextBoxPayPass1word.Text = "";
                                }
                                //else if (MemRankGuid != MemberLevel.NORMAL_MEMBER_ID && (num2 > num3 || MYlabelScore_cv_txt * (-1) > (MyScore_pv_a + MyScore_pv_b)))

                                //{
                                //    MessageBox.Show("您当前帐户上面的金额或积分不足，无法支付!");
                                //    TextBoxPayPass1word.Text = "";
                                //}
                                else
                                {
                                    DataTable dataTableStatus = orderaction.SearchOrderInfo(OrderinfoId);
                                    if (a == "product")
                                    {
                                        if (dataTableStatus.Rows[0]["PaymentStatus"].ToString() == "1")
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            string text = Page.Request.QueryString["TradeID"];
                                            string text2 = Page.Request.QueryString["IsAllPay"];
                                            //int num4 = shopNum1_Member_Action.PreDepositsPay(string_2, num2, num3, text, text2);
                                            int num4 = 1;
                                            if (num4 > 0)
                                            {

                                                string_5 = "金币（BV）支付";

                                                //201508091741198
                                                DataTable orderGuIdByTradeId = orderaction.GetOrderGuIdByTradeId(text);
                                                //dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(text, string_2);
                                                if (allOrdershop_category_id == "2")
                                                {
                                                    #region
                                                    //for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
                                                    //{
                                                    //    MyScore_hv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_hv"]) * Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["BuyNumber"]);

                                                    //    MyScore_pv_a_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_a"]) * Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["BuyNumber"]);
                                                    //    //要付款的积分
                                                    //    MYlabelScore_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_pv_a"]) * Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["BuyNumber"]);
                                                    //    //要付款的红包
                                                    //    MYlabelScore_max_hv_tx += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_hv"]) * Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["BuyNumber"]);
                                                    //}
                                                    #endregion

                                                    ShouldPay = num2;
                                                    ShouldDv = nom4;
                                                    orderaction.UpdateOrderSYhv(OrderinfoId, Deduction_pv_b);


                                                }
                                                else
                                                {
                                                    #region
                                                    //for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
                                                    //{
                                                    //    MyScore_hv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_hv"]) * Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["BuyNumber"]);

                                                    //    MyScore_pv_a_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_a"]) * Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["BuyNumber"]);
                                                    //    //要付款的积分
                                                    //    MYlabelScore_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_pv_a"]) * Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["BuyNumber"]);
                                                    //    //要付款的红包
                                                    //    MYlabelScore_max_hv_tx += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_hv"]) * Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["BuyNumber"]);
                                                    //}
                                                    //if ((MyScore_hv > (MYlabelScore_max_hv_tx * (-1))) || (MyScore_hv == (MYlabelScore_max_hv_tx * (-1))))
                                                    //{
                                                    //     ShouldPay = Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - (MYlabelScore_max_hv_tx * (-1));
                                                    //     XiaoFei_hv = MYlabelScore_max_hv_tx;
                                                    //}
                                                    //else
                                                    //{
                                                    //     ShouldPay = Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                                                    //     XiaoFei_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"])*-1;
                                                    //}
                                                    #endregion
                                                    ShouldPay = num2;
                                                    ShouldDv = nom4;
                                                    orderaction.UpdateOrderSYhv(OrderinfoId, Deduction_pv_b);
                                                    //ShouldPay = num2;
                                                    //ShouldDv = nom4;
                                                    //orderaction.UpdateOrderSYhv(OrderinfoId, Deduction_pv_b);
                                                    //if (allOrdershop_category_id == "1")
                                                    //{
                                                    //    MyScore_hv_txt = ShouldPay;
                                                    //}

                                                }


                                                if (text2 == "1")
                                                {

                                                    if (orderGuIdByTradeId.Rows.Count > 0)
                                                    {

                                                        //MoneyModifyLog(string_5);
                                                        //shopNum1_OrderInfo_Action.UpdateOrderStateTJ(OrderinfoId, MemLoginIDId, num2, DateTime.Now);
                                                        //OrderOperateLog(string_5, orderGuIdByTradeId.Rows[0]["guid"].ToString(),
                                                        //                orderGuIdByTradeId.Rows[0]["feeType"].ToString());

                                                        MoneyModifyLogGZ2019(allOrdershop_category_id, OrderinfoId, MemLoginIDId, ShouldPay, string_5, orderGuIdByTradeId.Rows[0]["guid"].ToString(), orderGuIdByTradeId.Rows[0]["feeType"].ToString(), DateTime.Now);


                                                        //MoneyModifyLog20160817(string_5, OrderinfoId, MemLoginIDId, num2, DateTime.Now, string_5, orderGuIdByTradeId.Rows[0]["guid"].ToString(),
                                                        //                orderGuIdByTradeId.Rows[0]["feeType"].ToString());



                                                        for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
                                                        {
                                                            string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
                                " and memloginid='" + orderGuIdByTradeId.Rows[i]["MemloginId"].ToString() + "'");

                                                            string nameById422212222 = Common.Common.GetNameById("mobile", "shopnum1_member",
                                " and memloginid='" + orderGuIdByTradeId.Rows[i]["ShopID"].ToString() + "'");

                                                            var shopNum1_OrderProduct_Action =
                                                                (ShopNum1_OrderProduct_Action)
                                                                LogicFactory.CreateShopNum1_OrderProduct_Action();
                                                            shopNum1_OrderProduct_Action.UpdateStock(
                                                                orderGuIdByTradeId.Rows[i]["guid"].ToString());
                                                            if (orderGuIdByTradeId.Rows[i]["FeeType"].ToString() == "2")
                                                            {
                                                                IsMMS(nameById42221,
                                                                      orderGuIdByTradeId.Rows[i]["IdentifyCode"].ToString(),
                                                                      orderGuIdByTradeId.Rows[i]["MemloginId"].ToString(),
                                                                      orderGuIdByTradeId.Rows[i]["Mobile"].ToString(),
                                                                      orderGuIdByTradeId.Rows[i]["ProductName"].ToString(),
                                                                      orderGuIdByTradeId.Rows[i]["BuyNumber"].ToString());
                                                            }
                                                            if (ShopSettings.GetValue("PayIsMMS") == "1")
                                                            {
                                                                method_3(orderGuIdByTradeId.Rows[i]["MemloginId"].ToString(),
                                                                         orderGuIdByTradeId.Rows[i]["ordernumber"].ToString(),
                                                                         orderGuIdByTradeId.Rows[i]["MemloginId"].ToString(),
                                                                         nameById42221);
                                                                if (orderGuIdByTradeId.Rows[i]["ShopID"].ToString() != "C0000001")
                                                                {
                                                                    method_3("卖家" + orderGuIdByTradeId.Rows[i]["ShopID"].ToString(),
                                                                             orderGuIdByTradeId.Rows[i]["ordernumber"].ToString() + "(您所卖出的)",
                                                                             orderGuIdByTradeId.Rows[i]["ShopID"].ToString(),
                                                                             nameById422212222);
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                                else
                                                {
                                                    //MoneyModifyLog(string_5);
                                                    //shopNum1_OrderInfo_Action.UpdateOrderStateTJ(OrderinfoId, MemLoginIDId, num2, DateTime.Now);
                                                    //OrderOperateLog(string_5, string_6, string_7);


                                                    //MoneyModifyLog20160817(string_5, OrderinfoId, MemLoginIDId, num2, DateTime.Now, string_5, string_6, string_7);
                                                    MoneyModifyLogGZ2019(allOrdershop_category_id, OrderinfoId, MemLoginIDId, ShouldPay, string_5, orderGuIdByTradeId.Rows[0]["guid"].ToString(), orderGuIdByTradeId.Rows[0]["feeType"].ToString(), DateTime.Now);

                                                    var shopNum1_OrderProduct_Action =
                                                        (ShopNum1_OrderProduct_Action)
                                                        LogicFactory.CreateShopNum1_OrderProduct_Action();
                                                    shopNum1_OrderProduct_Action.UpdateStock(string_6);
                                                    string nameById422211 = Common.Common.GetNameById("mobile", "shopnum1_member",
                             " and memloginid='" + orderGuIdByTradeId.Rows[0]["MemloginId"].ToString() + "'");

                                                    string nameById422212222 = Common.Common.GetNameById("mobile", "shopnum1_member",
                              " and memloginid='" + orderGuIdByTradeId.Rows[0]["ShopID"].ToString() + "'");

                                                    if (orderGuIdByTradeId.Rows[0]["FeeType"].ToString() == "2")
                                                    {

                                                        IsMMS(nameById422211,
                                                              orderGuIdByTradeId.Rows[0]["IdentifyCode"].ToString(),
                                                              orderGuIdByTradeId.Rows[0]["MemloginId"].ToString(),
                                                              orderGuIdByTradeId.Rows[0]["Mobile"].ToString(),
                                                              orderGuIdByTradeId.Rows[0]["ProductName"].ToString(),
                                                              orderGuIdByTradeId.Rows[0]["BuyNumber"].ToString());
                                                    }
                                                    if (ShopSettings.GetValue("PayIsMMS") == "1")
                                                    {
                                                        method_3(orderGuIdByTradeId.Rows[0]["MemloginId"].ToString(),
                                                                 orderGuIdByTradeId.Rows[0]["ordernumber"].ToString(),
                                                                 orderGuIdByTradeId.Rows[0]["MemloginId"].ToString(),
                                                                 nameById422211);

                                                        if (orderGuIdByTradeId.Rows[0]["ShopID"].ToString() != "C0000001")
                                                        {
                                                            method_3("卖家" + orderGuIdByTradeId.Rows[0]["ShopID"].ToString(),
                                                                          orderGuIdByTradeId.Rows[0]["ordernumber"].ToString() + "(您所卖出的)",
                                                                          orderGuIdByTradeId.Rows[0]["ShopID"].ToString(),
                                                                          nameById422212222);
                                                        }

                                                    }

                                                }
                                                if (ShopSettings.GetValue("PayIsEmail") == "1")
                                                {
                                                    IsEmail();
                                                }


                                                
                                                


                                                //DataTable table = orderaction.SerchOrderInfoAll(OrderinfoId);
                                                //string memid = table.Rows[0]["MemLoginID"].ToString();
                                                //String Guid1 = memaction.GetGuidByMemLoginID(memid);
                                                //DataTable tablemember = memaction.SearchMemberGuid(Guid1);
                                                //if (allOrdershop_category_id != "5" && allOrdershop_category_id != "2" && table.Rows[0]["OderStatus"].ToString() == "1")
                                                //{
                                                //    orderaction.Push3Gorder(OrderinfoId, tablemember.Rows[0]["MemLoginNO"].ToString(), table.Rows[0]["CreateTime"].ToString(), table.Rows[0]["PayTime"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]), Convert.ToDecimal(table.Rows[0]["Score_pv_a"]));
                                                //}
                                                #region 6.1的新逻辑
                                                //用户Score_sv=进货X5最大销售额   Score_cv=销售额度    Score_record_pv_a=普通商品购买次数
                                                //if (allOrdershop_category_id == "5")
                                                //{
                                                //    memaction.Update5XSV(tablemember.Rows[0]["MemLoginNO"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]));
                                                //    DataTable m5XSV = memaction.SearchMembertwo(memid);
                                                //    decimal jhe=Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"])*4;
                                                //    GZ_XinXiaoShouE gz = new GZ_XinXiaoShouE();
                                                //    gz.MemloginID = memid;
                                                //    gz.OrderNumber = table.Rows[0]["OrderNumber"].ToString();
                                                //    gz.DateTime = DateTime.Now;
                                                //    gz.ZJH_EDU = m5XSV.Rows[0]["FuwuzhanEdu"].ToString();
                                                //    gz.ZJ_EDU = "进货+" + jhe;
                                                //    gz.Y_EDU = (Convert.ToDecimal(m5XSV.Rows[0]["FuwuzhanEdu"]) - jhe).ToString();
                                                //    memaction.AddGZ_XinEDU(gz);

                                                //    //if (m5XSV.Rows[0]["MemberType"].ToString() == "2")
                                                //    //{
                                                //    //    if (Convert.ToDecimal(m5XSV.Rows[0]["Score_sv"]) > Convert.ToDecimal(m5XSV.Rows[0]["Score_cv"]))
                                                //    //    {
                                                //    //        DataTable mShop = memaction.SelectShopOfMemloginid(memid);
                                                //    //        if (mShop.Rows[0]["IsDeleted"].ToString() == "1")
                                                //    //        {
                                                //    //            memaction.UpdateShopIsDelete(memid);
                                                //    //        }
                                                //    //    }
                                                //    //}

                                                //}
                                                //if (isfuwuzhan == "1") 
                                                //{
                                                //    memaction.UpdateJianXinEDU(table.Rows[0]["ServiceAgent"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]));
                                                //    DataTable shopmem = memaction.SearchMembertwo(table.Rows[0]["ServiceAgent"].ToString());
                                                //    GZ_XinXiaoShouE gz = new GZ_XinXiaoShouE();
                                                //    gz.MemloginID = table.Rows[0]["ShopID"].ToString();
                                                //    gz.OrderNumber = table.Rows[0]["OrderNumber"].ToString();
                                                //    gz.DateTime = DateTime.Now;
                                                //    gz.ZJH_EDU = shopmem.Rows[0]["FuwuzhanEdu"].ToString();
                                                //    gz.ZJ_EDU = "卖出-" + table.Rows[0]["ShouldPayPrice"].ToString();
                                                //    gz.Y_EDU = (Convert.ToDecimal(shopmem.Rows[0]["FuwuzhanEdu"]) + Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"])).ToString();
                                                //    memaction.AddGZ_XinEDU(gz);
                                                //}
                                                //if (allOrdershop_category_id == "9")
                                                //{
                                                //    memaction.Update5XCV(table.Rows[0]["ShopID"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]));
                                                //    DataTable shopmem = memaction.SearchMembertwo(table.Rows[0]["ShopID"].ToString());
                                                //    GZ_XiaoShouE_mingxi gz = new GZ_XiaoShouE_mingxi();
                                                //    gz.MemloginID = table.Rows[0]["ShopID"].ToString();
                                                //    gz.OrderNumber = table.Rows[0]["OrderNumber"].ToString();
                                                //    gz.DateTime = DateTime.Now;
                                                //    gz.ZJH_xiaoshoue = shopmem.Rows[0]["Score_cvv"].ToString();
                                                //    gz.ZJ_xiaoshoue = "卖出+"+table.Rows[0]["ShouldPayPrice"].ToString();
                                                //    gz.Y_xiaoshoue = (Convert.ToDecimal(shopmem.Rows[0]["Score_cvv"]) - Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"])).ToString();
                                                //    memaction.AddGZ_XiaoShouE(gz);
                                                //}

                                                //if (tablemember.Rows[0]["MemberRankGuid"].ToString().ToUpper() == MemberLevel.NORMAL_MEMBER_ID.ToUpper() && Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]) >= 1000 && Convert.ToDecimal(table.Rows[0]["Score_pv_a"]) >= 1000 && (allOrdershop_category_id == "1" || allOrdershop_category_id == "9"))
                                                //{
                                                //    DataTable m5XSV = memaction.SearchMembertwo(memid);
                                                //    if (Convert.ToDecimal(m5XSV.Rows[0]["Score_record _pv_a"]) >= 2)
                                                //    {

                                                //        memaction.UpdateMemberRankGuid(memid, MemberLevel.VIP_MEMBER_ID);
                                                //    }
                                                //    else
                                                //    {
                                                //        memaction.UpdatememberZGX1(memid);
                                                //    }


                                                //}
                                                #endregion





                                                Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                                                        "<script>alert(\"您所买的商品,已经成功付款!您可以通知卖家及时发货\");location.href='http://" +
                                                                                        ShopSettings.siteDomain +
                                                                                        "/Main/Member/m_index.aspx?tomurl=M_OrderList.aspx';</script>");

                                            }
                                            else
                                            {
                                                MessageBox.Show("支付失败");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (a == "categoryad")
                                        {
                                            string tradeID = Page.Request.QueryString["TradeID"];
                                            int num4 = shopNum1_Member_Action.CategoryAdPay(string_2, num2, num3, tradeID);
                                            if (num4 > 0)
                                            {
                                                MoneyModifyLog("购买广告");
                                                Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                                                        "<script>alert(\"支付成功\");location.href='http://" +
                                                                                        ShopSettings.siteDomain +
                                                                                        "/Main/Member/m_index.aspx?tomurl=M_OrderList.aspx';</script>");
                                            }
                                            else
                                            {
                                                Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                                                        "<script>alert(\"支付失败\");window.close()</script>");
                                            }
                                        }
                                        else
                                        {
                                            if (a == "shoprank" || a == "shopensure")
                                            {
                                                string text = Page.Request.QueryString["TradeID"];
                                                int num4 = shopNum1_Member_Action.OtherOrderIDPay(string_2, num2, num3, text);
                                                if (num4 > 0)
                                                {
                                                    int num5 = 0;
                                                    if (string_0 == "1")
                                                    {
                                                        var shop_ShopApplyRank_Action =
                                                            (Shop_ShopApplyRank_Action)
                                                            ShopFactory.LogicFactory.CreateShop_ShopApplyRank_Action();
                                                        num5 = shop_ShopApplyRank_Action.UpdataShopRankPayStatusByID(string_4);
                                                        string_5 = "购买店铺等级";
                                                    }
                                                    else
                                                    {
                                                        if (string_0 == "2")
                                                        {
                                                            var shop_Ensure_Action =
                                                                (Shop_Ensure_Action)
                                                                ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                                                            num5 = shop_Ensure_Action.UpdataEnsurePayStatusByGuid(string_4);
                                                            string_5 = "购买店铺担保";
                                                        }
                                                    }
                                                    if (num5 > 0)
                                                    {
                                                        MoneyModifyLog(string_5);
                                                        Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                                                                "<script>alert(\"支付成功\");location.href='http://" +
                                                                                                ShopSettings.siteDomain +
                                                                                                "/Main/Member/m_index.aspx?tomurl=M_OrderList.aspx';</script>");
                                                    }
                                                    else
                                                    {
                                                        Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                                                                "<script>alert(\"支付失败\");window.close()</script>");
                                                    }
                                                }
                                                else
                                                {
                                                    Page.ClientScript.RegisterStartupScript(GetType(), "pop",
                                                                                            "<script>alert(\"支付失败\");window.close()</script>");
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }

            }


        }

        protected void MoneyModifyLogGZ2019(string shopCategoryID,string OrderNumber, string memLoginID, decimal shouldPay, string Olgmemo, string strOrdGuId, string strFeeType, DateTime paytime) 
        {

            ShopNum1_Member_Action memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            ShopNum1_OrderInfo_Action orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable table = orderaction.SerchOrderInfoAll(OrderinfoId);
            DataTable memberTable = memaction.SearchMembertwo(memLoginID);
            decimal myBV=Convert.ToDecimal(memberTable.Rows[0]["AdvancePayment"]);
            decimal myDV=Convert.ToDecimal(memberTable.Rows[0]["Score_dv"]);
            decimal myPVA=Convert.ToDecimal(memberTable.Rows[0]["Score_pv_a"]);


            decimal bv = 0;
            decimal dv = 0;
            decimal pva = 0;
            decimal dpva = 0;
            if (shopCategoryID == "1") 
            {
                bv = shouldPay;
                //dpva = Convert.ToDecimal(table.Rows[0]["Score_pv_a"]);
            }
            if (shopCategoryID == "2") 
            {
                 //dv = shouldPay;
                 pva = shouldPay;
            }
            if (shopCategoryID == "3")
            {
                bv = shouldPay;
            }

            ShopNum1_OrderRefund orderRefund = new ShopNum1_OrderRefund();
            orderRefund.MemloginID = memLoginID;
            orderRefund.Ordernumber = OrderNumber;
            orderRefund.PaymentPrice = bv;
            orderRefund.Score_hv = 0;
            orderRefund.Score_dv = dv;
            orderRefund.Score_pv_a = pva;
            orderRefund.Score_pv_b = 0;
            orderRefund.Score_pv_cv = 0;
            orderRefund.reduce_PaymentPrice = 0;
            orderRefund.reduce_score_dv = 0;
            orderRefund.reduce_score_hv = 0;
            orderRefund.reduce_score_pv_a = dpva;
            orderRefund.reduce_score_pv_b = 0;
            orderRefund.reduce_score_pv_cv = 0;
            orderRefund.reduce_TJhv = 0;
            orderRefund.TJMemloginID = "";



            ShopNum1_OrderRefund_Action orderrefundaction = (ShopNum1_OrderRefund_Action)LogicFactory.CreateShopNum1_OrderRefund_Action();


            



            var shopNum1_AdvancePaymentModifyLog_Action =
                (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();

            int fh = shopNum1_AdvancePaymentModifyLog_Action.OperateMoneyGz2019(myDV, myPVA, myBV, shopCategoryID, OrderNumber, memLoginID, shouldPay, dpva, paytime);
            if (fh == 1)
            {
                orderrefundaction.Add(orderRefund);
                OrderOperateLog(Olgmemo, strOrdGuId, strFeeType);
            }


        }

        protected void IsMMS(string OrderNumber, string strCode, string memloginID, string string_8,
                             string strProductName, string strBuyNum)
        {
            if (!(string_8.Trim() == "") && !(strCode == "0" | strCode == ""))
            {
                var orderInfo = new OrderInfo();
                orderInfo.Name = memloginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = ShopSettings.GetValue("Name");
                string text = "73370552-efdb-47ec-9e0f-f813261375b8";
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text, 0);
                if (editInfo != null && editInfo.Rows.Count > 0)
                {
                    string text2 = editInfo.Rows[0]["Remark"].ToString();
                    text2 = text2.Replace("{$Name}", orderInfo.Name);
                    text2 = text2.Replace("{$IdentifyCode}", strCode);
                    text2 = text2.Replace("{$OrderNumber}", orderInfo.OrderNumber);
                    text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
                    text2 = text2.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    text2 = text2.Replace("{$ProductName}", strProductName);
                    text2 = text2.Replace("{$BuyNum}", strBuyNum);
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    var sMS = new SMS();
                    string text3 = "";
                    text2 = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text2));
                    sMS.Send(string_8.Trim(), text2 + "【唐江宝宝】", out text3);
                    if (text3.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), mMsTitle, text2, 2,
                                                                      text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), mMsTitle, text2, 0,
                                                                      text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }
        protected void MoneyModifyLog20160817(string memo, string ordernumber, string memLoginID, decimal shouldPay, DateTime paytime, string Olgmemo, string strOrdGuId, string strFeeType)
        {

            var shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.hv_guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_a_guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_b_guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.hv_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_a_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_b_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.HuoDe_dv_Guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.XiaoFei_guid_Hou_cv = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.DeDao_guid_Hou_cv = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_b_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.TJ_HuoDe_GUID = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.OperateType = 3;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["AdvancePayment"]);
            shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(ShouldPay);
            shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["AdvancePayment"]) -
                                                                Convert.ToDecimal(ShouldPay);
            #region 退款记录
            GZ_PaymentPrice = ShouldPay;
            #endregion
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            String Guidmem = member_Action.GetGuidByMemLoginID(MemLoginIDId);
            DataTable tableTJ = member_Action.SearchMemberGuid(Guidmem);
            string MemLoginIDno = tableTJ.Rows[0]["MemLoginNO"].ToString();
            #region 2015.7.25
            decimal TJScore_pv_a;
            decimal TJScore_pv_b;
            decimal TJScore_pv_c;
            decimal TJScore_hv;
            string TJID;
            int TJtype;
            #endregion
            if (MemLoginIDno.ToUpper().IndexOf("C") != -1)
            {
                TJtype = 1;
                TJScore_pv_a = MyScore_pv_a;
                TJScore_pv_b = MyScore_pv_b;
                TJScore_pv_c = MyScore_pv_c;
                TJScore_hv = MyScore_hv;
                TJID = MemLoginIDId;
            }
            else
            {

                TJtype = 0;
                if (tableTJ.Rows[0]["Superior"].ToString() != null && tableTJ.Rows[0]["Superior"].ToString() != "")
                {
                    String TJGuid1 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                    DataTable TJtable = member_Action.SearchMemberGuid(TJGuid1);

                    TJScore_pv_a = Convert.ToDecimal(TJtable.Rows[0]["Score_pv_a"].ToString());
                    TJScore_pv_b = Convert.ToDecimal(TJtable.Rows[0]["Score_pv_b"].ToString());
                    TJScore_pv_c = Convert.ToDecimal(TJtable.Rows[0]["Score_pv_cv"].ToString());
                    TJScore_hv = Convert.ToDecimal(TJtable.Rows[0]["Score_hv"].ToString());
                    TJID = TJtable.Rows[0]["MemLoginID"].ToString();

                }
                else
                {
                    TJScore_pv_a = 0;
                    TJScore_pv_b = 0;
                    TJScore_pv_c = 0;
                    TJScore_hv = 0;
                    TJID = "";
                }
            }


            /*  shopNum1_AdvancePaymentModifyLog.Score_pv_a=MyScore_pv_a_txt+MyScore_pv_a;
              shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv_txt+ MyScore_hv;*/
            if (MyScore_dv >= ShouldDv)
            {
                shopNum1_AdvancePaymentModifyLog.Score_dv = MyScore_dv - ShouldDv;
                #region 退款记录
                GZ_Score_dv = ShouldDv;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_dv = ShouldDv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_Hou_dv = MyScore_dv - ShouldDv;
                #endregion
            }
            if (MyScore_dv < ShouldDv)
            {
                shopNum1_AdvancePaymentModifyLog.Score_dv = 0;
                #region 退款记录
                GZ_Score_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_Hou_dv = 0;
                #endregion

            }
            if (TJScore_pv_b > (MYlabelScore_cv_txt * (-1)) || TJScore_pv_b == (MYlabelScore_cv_txt * (-1)))
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = TJScore_pv_b - (MYlabelScore_cv_txt * (-1));
                shopNum1_AdvancePaymentModifyLog.Score_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.Score_pv_c = TJScore_pv_c;
                #region 退款记录
                GZ_Score_pv_b = MYlabelScore_cv_txt * (-1);
                GZ_Score_pv_a = 0;
                GZ_Score_pv_cv = 0;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b = (MYlabelScore_cv_txt * (-1));
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_b = TJScore_pv_b - (MYlabelScore_cv_txt * (-1));
                #endregion
            }
            if (TJScore_pv_b < (MYlabelScore_cv_txt * (-1)) && (TJScore_pv_a + TJScore_pv_b) >= (MYlabelScore_cv_txt * (-1)))
            {
                decimal poor = (MYlabelScore_cv_txt * (-1)) - TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = TJScore_pv_b - TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.Score_pv_a = TJScore_pv_a - poor;
                shopNum1_AdvancePaymentModifyLog.Score_pv_c = TJScore_pv_c;
                #region 退款记录
                GZ_Score_pv_b = TJScore_pv_b;
                GZ_Score_pv_a = poor;
                GZ_Score_pv_cv = 0;

                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_b = TJScore_pv_b - TJScore_pv_b;

                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a = poor;
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_a = TJScore_pv_a - poor;
                #endregion
            }
            if (TJScore_pv_b < (MYlabelScore_cv_txt * (-1)) && (TJScore_pv_a + TJScore_pv_b) < (MYlabelScore_cv_txt * (-1)))
            {
                decimal poor = (MYlabelScore_cv_txt * (-1)) - (TJScore_pv_b + TJScore_pv_a);
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = TJScore_pv_b - TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.Score_pv_a = TJScore_pv_a - TJScore_pv_a;

                shopNum1_AdvancePaymentModifyLog.Score_pv_c = TJScore_pv_c - poor;


                shopNum1_AdvancePaymentModifyLog.XiaoFei_Qian_cv = TJScore_pv_c;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_cv = poor;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_cv = TJScore_pv_c - poor;

                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_a = TJScore_pv_a - TJScore_pv_a;

                //差个 pv b
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_b = TJScore_pv_b - TJScore_pv_b;



                #region 退款记录
                GZ_Score_pv_b = TJScore_pv_b;
                GZ_Score_pv_a = TJScore_pv_a;
                GZ_Score_pv_cv = poor;
                #endregion

            }
            if (MyScore_hv > Deduction_pv_b || MyScore_hv == Deduction_pv_b)
            {
                shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv - Deduction_pv_b;
                #region 退款记录
                GZ_Score_hv = Deduction_pv_b;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_hv = Deduction_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_hv = MyScore_hv - Deduction_pv_b;
                #endregion
            }
            if (MyScore_hv < Deduction_pv_b && MyScore_hv > -1)
            {

                shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv - MyScore_hv;
                #region 退款记录
                GZ_Score_hv = MyScore_hv;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_hv = MyScore_hv - MyScore_hv;
                #endregion
            }
            //获得hv
            decimal myHuoDe_YuanYou_hv = MyScore_hv;
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_hv = myHuoDe_YuanYou_hv;
            shopNum1_AdvancePaymentModifyLog.Score_hv = shopNum1_AdvancePaymentModifyLog.Score_hv + MyScore_hv_txt;
            GZ_reduce_score_hv = MyScore_hv_txt;
            //推荐人同时获得红包

            if (TJtype == 0)
            {
                shopNum1_AdvancePaymentModifyLog.TJScore_hv = TJScore_hv + MyScore_hv_txt;
                GZ_reduce_score_TJ_hv = MyScore_hv_txt;

                shopNum1_AdvancePaymentModifyLog.TJ_HuoDe_YuanYou_hv = TJScore_hv;
                shopNum1_AdvancePaymentModifyLog.TJ_HuoDe_hv = MyScore_hv_txt;
                shopNum1_AdvancePaymentModifyLog.TJ_Huo_DeHou_hv = TJScore_hv + MyScore_hv_txt;

            }
            else if (TJtype == 1)
            {
                shopNum1_AdvancePaymentModifyLog.TJScore_hv = shopNum1_AdvancePaymentModifyLog.Score_hv + 0;
                GZ_reduce_score_TJ_hv = 0;

            }

            shopNum1_AdvancePaymentModifyLog.HuoDe_hv = MyScore_hv_txt;
            shopNum1_AdvancePaymentModifyLog.Huo_DeHou_hv = myHuoDe_YuanYou_hv + MyScore_hv_txt;
            //获得pv_a
            decimal myHuoDe_YuanYou_pv_a = shopNum1_AdvancePaymentModifyLog.Score_pv_a;
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_pv_a = myHuoDe_YuanYou_pv_a;

            shopNum1_AdvancePaymentModifyLog.Score_pv_a = shopNum1_AdvancePaymentModifyLog.Score_pv_a + MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Score_pv_c = shopNum1_AdvancePaymentModifyLog.Score_pv_c + MYlabelScore_pv_cv_txt;
            //520商品抵扣红包不扣pvb
            //DataTable productGuid520PVB = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).Select_520OfOrdernumber(OrderinfoId);
            //for (int i = 0; i < productGuid520PVB.Rows.Count; i++)
            //{
            //    if (productGuid520PVB.Rows[i]["ProductGuid"].ToString().ToUpper().Trim() == ShopSettings.TJ520.ToUpper() || productGuid520PVB.Rows[i]["ProductGuid"].ToString().ToUpper().Trim() == ShopSettings.TJ520_two.ToUpper())
            //    {
            //        Deduction_pv_b = 0;
            //    }

            //}
            if ((MyScore_pv_b_txt - Deduction_pv_b) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b;
                GZ_reduce_score_pv_b = 0;
            }
            else
            {


                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b + (MyScore_pv_b_txt - Deduction_pv_b);
                GZ_reduce_score_pv_b = MyScore_pv_b_txt - Deduction_pv_b;

            }

            //获得pv_cv
            shopNum1_AdvancePaymentModifyLog.DeDao_Qian_cv = TJScore_pv_c;
            shopNum1_AdvancePaymentModifyLog.DeDao_cv = MYlabelScore_pv_cv_txt;
            shopNum1_AdvancePaymentModifyLog.DeDao_Hou_cv = TJScore_pv_c + MYlabelScore_pv_cv_txt;

            //获得pv——b
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_pv_b = TJScore_pv_b;
            if ((MyScore_pv_b_txt - Deduction_pv_b) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = 0;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = MyScore_pv_b_txt - Deduction_pv_b;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b + (MyScore_pv_b_txt - Deduction_pv_b);
            }


            shopNum1_AdvancePaymentModifyLog.HuoDe_pv_a = MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_a = myHuoDe_YuanYou_pv_a + MyScore_pv_a_txt;

            shopNum1_AdvancePaymentModifyLog.OrderInfoOrderNumber = OrderinfoId;
            shopNum1_AdvancePaymentModifyLog.Offset_pv_b = Deduction_pv_b;
            #region 退款记录

            GZ_reduce_score_pv_a = MyScore_pv_a_txt;

            GZ_reduce_score_pv_cv = MYlabelScore_pv_cv_txt;

            GZ_reduce_TJID = TJID;
            GZ_reduce_score_dv = 0;
            GZ_reduce_PaymentPrice = 0;
            #endregion

            shopNum1_AdvancePaymentModifyLog.HuoDe_Mom = "消费获得";
            shopNum1_AdvancePaymentModifyLog.XiaoFei_Mom = "消费扣取";
            /*  shopNum1_AdvancePaymentModifyLog.Score_cv = MyScore_hv_txt + MyScore_hv;
              shopNum1_AdvancePaymentModifyLog.Score_max_hv = MyScore_hv_txt + MyScore_hv;*/

            shopNum1_AdvancePaymentModifyLog.Date =
                Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_AdvancePaymentModifyLog.Memo = memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID = string_2;
            shopNum1_AdvancePaymentModifyLog.CreateUser = string_2;
            shopNum1_AdvancePaymentModifyLog.TJmemID = TJID;
            shopNum1_AdvancePaymentModifyLog.CreateTime =
                Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;

            #region 退款操作
            ShopNum1_OrderRefund orderRefund = new ShopNum1_OrderRefund();
            orderRefund.MemloginID = MemLoginIDId;
            orderRefund.Ordernumber = OrderinfoId;
            orderRefund.PaymentPrice = GZ_PaymentPrice;
            orderRefund.Score_hv = GZ_Score_hv;
            orderRefund.Score_dv = GZ_Score_dv;
            orderRefund.Score_pv_a = GZ_Score_pv_a;
            orderRefund.Score_pv_b = GZ_Score_pv_b;
            orderRefund.Score_pv_cv = GZ_Score_pv_cv;
            orderRefund.reduce_PaymentPrice = GZ_reduce_PaymentPrice;
            orderRefund.reduce_score_dv = GZ_reduce_score_dv;
            orderRefund.reduce_score_hv = GZ_reduce_score_hv;
            orderRefund.reduce_score_pv_a = GZ_reduce_score_pv_a;
            orderRefund.reduce_score_pv_b = GZ_reduce_score_pv_b;
            orderRefund.reduce_score_pv_cv = GZ_reduce_score_pv_cv;
            orderRefund.reduce_TJhv = GZ_reduce_score_TJ_hv;
            orderRefund.TJMemloginID = GZ_reduce_TJID;

            ShopNum1_OrderRefund_Action orderrefundaction = (ShopNum1_OrderRefund_Action)LogicFactory.CreateShopNum1_OrderRefund_Action();


            #endregion



            var shopNum1_AdvancePaymentModifyLog_Action =
                (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();

            int fh = shopNum1_AdvancePaymentModifyLog_Action.OperateMoney_TJ20160817(shopNum1_AdvancePaymentModifyLog, ordernumber, memLoginID, shouldPay, paytime);
            if (fh == 1)
            {
                orderrefundaction.Add(orderRefund);
                OrderOperateLog(Olgmemo, strOrdGuId, strFeeType);
            }



        }
        protected void MoneyModifyLog(string memo)
        {

            var shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.hv_guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_a_guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_b_guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.hv_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_a_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_b_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.HuoDe_dv_Guid = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.XiaoFei_guid_Hou_cv = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.DeDao_guid_Hou_cv = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.pv_b_guid_two = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.TJ_HuoDe_GUID = System.Guid.NewGuid();
            shopNum1_AdvancePaymentModifyLog.OperateType = 3;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["AdvancePayment"]);
            shopNum1_AdvancePaymentModifyLog.OperateMoney = Convert.ToDecimal(ShouldPay);
            shopNum1_AdvancePaymentModifyLog.LastOperateMoney = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["AdvancePayment"]) -
                                                                Convert.ToDecimal(ShouldPay);
            #region 退款记录
            GZ_PaymentPrice = ShouldPay;
            #endregion
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            String Guidmem = member_Action.GetGuidByMemLoginID(MemLoginIDId);
            DataTable tableTJ = member_Action.SearchMemberGuid(Guidmem);
            string MemLoginIDno = tableTJ.Rows[0]["MemLoginNO"].ToString();
            #region 2015.7.25
            decimal TJScore_pv_a;
            decimal TJScore_pv_b;
            decimal TJScore_pv_c;
            decimal TJScore_hv;
            string TJID;
            int TJtype;
            #endregion
            if (MemLoginIDno.ToUpper().IndexOf("C") != -1)
            {
                TJtype = 1;
                TJScore_pv_a = MyScore_pv_a;
                TJScore_pv_b = MyScore_pv_b;
                TJScore_pv_c = MyScore_pv_c;
                TJScore_hv = MyScore_hv;
                TJID = MemLoginIDId;
            }
            else
            {

                TJtype = 0;
                if (tableTJ.Rows[0]["Superior"].ToString() != null && tableTJ.Rows[0]["Superior"].ToString() != "")
                {
                    String TJGuid1 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                    DataTable TJtable = member_Action.SearchMemberGuid(TJGuid1);

                    TJScore_pv_a = Convert.ToDecimal(TJtable.Rows[0]["Score_pv_a"].ToString());
                    TJScore_pv_b = Convert.ToDecimal(TJtable.Rows[0]["Score_pv_b"].ToString());
                    TJScore_pv_c = Convert.ToDecimal(TJtable.Rows[0]["Score_pv_cv"].ToString());
                    TJScore_hv = Convert.ToDecimal(TJtable.Rows[0]["Score_hv"].ToString());
                    TJID = TJtable.Rows[0]["MemLoginID"].ToString();

                }
                else
                {
                    TJScore_pv_a = 0;
                    TJScore_pv_b = 0;
                    TJScore_pv_c = 0;
                    TJScore_hv = 0;
                    TJID = "";
                }
            }


            /*  shopNum1_AdvancePaymentModifyLog.Score_pv_a=MyScore_pv_a_txt+MyScore_pv_a;
              shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv_txt+ MyScore_hv;*/
            if (MyScore_dv >= ShouldDv)
            {
                shopNum1_AdvancePaymentModifyLog.Score_dv = MyScore_dv - ShouldDv;
                #region 退款记录
                GZ_Score_dv = ShouldDv;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_dv = ShouldDv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_Hou_dv = MyScore_dv - ShouldDv;
                #endregion
            }
            if (MyScore_dv < ShouldDv)
            {
                shopNum1_AdvancePaymentModifyLog.Score_dv = 0;
                #region 退款记录
                GZ_Score_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_Hou_dv = 0;
                #endregion

            }
            if (TJScore_pv_b > (MYlabelScore_cv_txt * (-1)) || TJScore_pv_b == (MYlabelScore_cv_txt * (-1)))
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = TJScore_pv_b - (MYlabelScore_cv_txt * (-1));
                shopNum1_AdvancePaymentModifyLog.Score_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.Score_pv_c = TJScore_pv_c;
                #region 退款记录
                GZ_Score_pv_b = MYlabelScore_cv_txt * (-1);
                GZ_Score_pv_a = 0;
                GZ_Score_pv_cv = 0;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b = (MYlabelScore_cv_txt * (-1));
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_b = TJScore_pv_b - (MYlabelScore_cv_txt * (-1));
                #endregion
            }
            if (TJScore_pv_b < (MYlabelScore_cv_txt * (-1)) && (TJScore_pv_a + TJScore_pv_b) >= (MYlabelScore_cv_txt * (-1)))
            {
                decimal poor = (MYlabelScore_cv_txt * (-1)) - TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = TJScore_pv_b - TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.Score_pv_a = TJScore_pv_a - poor;
                shopNum1_AdvancePaymentModifyLog.Score_pv_c = TJScore_pv_c;
                #region 退款记录
                GZ_Score_pv_b = TJScore_pv_b;
                GZ_Score_pv_a = poor;
                GZ_Score_pv_cv = 0;

                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_b = TJScore_pv_b - TJScore_pv_b;

                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a = poor;
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_a = TJScore_pv_a - poor;
                #endregion
            }
            if (TJScore_pv_b < (MYlabelScore_cv_txt * (-1)) && (TJScore_pv_a + TJScore_pv_b) < (MYlabelScore_cv_txt * (-1)))
            {
                decimal poor = (MYlabelScore_cv_txt * (-1)) - (TJScore_pv_b + TJScore_pv_a);
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = TJScore_pv_b - TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.Score_pv_a = TJScore_pv_a - TJScore_pv_a;

                shopNum1_AdvancePaymentModifyLog.Score_pv_c = TJScore_pv_c - poor;


                shopNum1_AdvancePaymentModifyLog.XiaoFei_Qian_cv = TJScore_pv_c;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_cv = poor;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_cv = TJScore_pv_c - poor;

                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_a = TJScore_pv_a;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_a = TJScore_pv_a - TJScore_pv_a;

                //差个 pv b
                shopNum1_AdvancePaymentModifyLog.YuanYou_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b = TJScore_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_pv_b = TJScore_pv_b - TJScore_pv_b;



                #region 退款记录
                GZ_Score_pv_b = TJScore_pv_b;
                GZ_Score_pv_a = TJScore_pv_a;
                GZ_Score_pv_cv = poor;
                #endregion

            }
            if (MyScore_hv > Deduction_pv_b || MyScore_hv == Deduction_pv_b)
            {
                shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv - Deduction_pv_b;
                #region 退款记录
                GZ_Score_hv = Deduction_pv_b;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_hv = Deduction_pv_b;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_hv = MyScore_hv - Deduction_pv_b;
                #endregion
            }
            if (MyScore_hv < Deduction_pv_b && MyScore_hv > -1)
            {

                shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv - MyScore_hv;
                #region 退款记录
                GZ_Score_hv = MyScore_hv;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_hv = MyScore_hv - MyScore_hv;
                #endregion
            }
            //获得hv
            decimal myHuoDe_YuanYou_hv = MyScore_hv;
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_hv = myHuoDe_YuanYou_hv;
            shopNum1_AdvancePaymentModifyLog.Score_hv = shopNum1_AdvancePaymentModifyLog.Score_hv + MyScore_hv_txt;
            GZ_reduce_score_hv = MyScore_hv_txt;
            //推荐人同时获得红包

            if (TJtype == 0)
            {
                shopNum1_AdvancePaymentModifyLog.TJScore_hv = TJScore_hv + MyScore_hv_txt;
                GZ_reduce_score_TJ_hv = MyScore_hv_txt;

                shopNum1_AdvancePaymentModifyLog.TJ_HuoDe_YuanYou_hv = TJScore_hv;
                shopNum1_AdvancePaymentModifyLog.TJ_HuoDe_hv = MyScore_hv_txt;
                shopNum1_AdvancePaymentModifyLog.TJ_Huo_DeHou_hv = TJScore_hv + MyScore_hv_txt;

            }
            else if (TJtype == 1)
            {
                shopNum1_AdvancePaymentModifyLog.TJScore_hv = shopNum1_AdvancePaymentModifyLog.Score_hv + 0;
                GZ_reduce_score_TJ_hv = 0;

            }

            shopNum1_AdvancePaymentModifyLog.HuoDe_hv = MyScore_hv_txt;
            shopNum1_AdvancePaymentModifyLog.Huo_DeHou_hv = myHuoDe_YuanYou_hv + MyScore_hv_txt;
            //获得pv_a
            decimal myHuoDe_YuanYou_pv_a = shopNum1_AdvancePaymentModifyLog.Score_pv_a;
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_pv_a = myHuoDe_YuanYou_pv_a;

            shopNum1_AdvancePaymentModifyLog.Score_pv_a = shopNum1_AdvancePaymentModifyLog.Score_pv_a + MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Score_pv_c = shopNum1_AdvancePaymentModifyLog.Score_pv_c + MYlabelScore_pv_cv_txt;
            if ((MyScore_pv_b_txt - Deduction_pv_b) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b;
                GZ_reduce_score_pv_b = 0;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b + (MyScore_pv_b_txt - Deduction_pv_b);
                GZ_reduce_score_pv_b = MyScore_pv_b_txt - Deduction_pv_b;
            }

            //获得pv_cv
            shopNum1_AdvancePaymentModifyLog.DeDao_Qian_cv = TJScore_pv_c;
            shopNum1_AdvancePaymentModifyLog.DeDao_cv = MYlabelScore_pv_cv_txt;
            shopNum1_AdvancePaymentModifyLog.DeDao_Hou_cv = TJScore_pv_c + MYlabelScore_pv_cv_txt;

            //获得pv——b
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_pv_b = TJScore_pv_b;
            if ((MyScore_pv_b_txt - Deduction_pv_b) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = 0;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = MyScore_pv_b_txt - Deduction_pv_b;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b + (MyScore_pv_b_txt - Deduction_pv_b);
            }


            shopNum1_AdvancePaymentModifyLog.HuoDe_pv_a = MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_a = myHuoDe_YuanYou_pv_a + MyScore_pv_a_txt;

            shopNum1_AdvancePaymentModifyLog.OrderInfoOrderNumber = OrderinfoId;
            shopNum1_AdvancePaymentModifyLog.Offset_pv_b = Deduction_pv_b;
            #region 退款记录

            GZ_reduce_score_pv_a = MyScore_pv_a_txt;

            GZ_reduce_score_pv_cv = MYlabelScore_pv_cv_txt;

            GZ_reduce_TJID = TJID;
            GZ_reduce_score_dv = 0;
            GZ_reduce_PaymentPrice = 0;
            #endregion

            shopNum1_AdvancePaymentModifyLog.HuoDe_Mom = "消费获得";
            shopNum1_AdvancePaymentModifyLog.XiaoFei_Mom = "消费扣取";
            /*  shopNum1_AdvancePaymentModifyLog.Score_cv = MyScore_hv_txt + MyScore_hv;
              shopNum1_AdvancePaymentModifyLog.Score_max_hv = MyScore_hv_txt + MyScore_hv;*/

            shopNum1_AdvancePaymentModifyLog.Date =
                Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_AdvancePaymentModifyLog.Memo = memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID = string_2;
            shopNum1_AdvancePaymentModifyLog.CreateUser = string_2;
            shopNum1_AdvancePaymentModifyLog.TJmemID = TJID;
            shopNum1_AdvancePaymentModifyLog.CreateTime =
                Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;

            #region 退款操作
            ShopNum1_OrderRefund orderRefund = new ShopNum1_OrderRefund();
            orderRefund.MemloginID = MemLoginIDId;
            orderRefund.Ordernumber = OrderinfoId;
            orderRefund.PaymentPrice = GZ_PaymentPrice;
            orderRefund.Score_hv = GZ_Score_hv;
            orderRefund.Score_dv = GZ_Score_dv;
            orderRefund.Score_pv_a = GZ_Score_pv_a;
            orderRefund.Score_pv_b = GZ_Score_pv_b;
            orderRefund.Score_pv_cv = GZ_Score_pv_cv;
            orderRefund.reduce_PaymentPrice = GZ_reduce_PaymentPrice;
            orderRefund.reduce_score_dv = GZ_reduce_score_dv;
            orderRefund.reduce_score_hv = GZ_reduce_score_hv;
            orderRefund.reduce_score_pv_a = GZ_reduce_score_pv_a;
            orderRefund.reduce_score_pv_b = GZ_reduce_score_pv_b;
            orderRefund.reduce_score_pv_cv = GZ_reduce_score_pv_cv;
            orderRefund.reduce_TJhv = GZ_reduce_score_TJ_hv;
            orderRefund.TJMemloginID = GZ_reduce_TJID;

            ShopNum1_OrderRefund_Action orderrefundaction = (ShopNum1_OrderRefund_Action)LogicFactory.CreateShopNum1_OrderRefund_Action();

            orderrefundaction.Add(orderRefund);
            #endregion



            var shopNum1_AdvancePaymentModifyLog_Action =
                (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            //if (shopNum1_AdvancePaymentModifyLog.HuoDe_hv != 0 )
            //{
            //    shopNum1_AdvancePaymentModifyLog_Action.OperateHuoDeHv(shopNum1_AdvancePaymentModifyLog);
            //}
            shopNum1_AdvancePaymentModifyLog_Action.OperateMoney_TJ(shopNum1_AdvancePaymentModifyLog);
            //if (shopNum1_AdvancePaymentModifyLog.HuoDe_pv_a!=0)
            //{
            //    shopNum1_AdvancePaymentModifyLog_Action.OperateHuoDePv_a(shopNum1_AdvancePaymentModifyLog);
            //}
            //if (shopNum1_AdvancePaymentModifyLog.XiaoFei_hv!=0)
            //{
            //    shopNum1_AdvancePaymentModifyLog_Action.OperateKouHv(shopNum1_AdvancePaymentModifyLog);
            //}
            //if (shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a!=0)
            //{
            //    shopNum1_AdvancePaymentModifyLog_Action.OperateKouPv_a(shopNum1_AdvancePaymentModifyLog);  
            //}
            //if (shopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b!=0)
            //{
            //    shopNum1_AdvancePaymentModifyLog_Action.OperateKouPv_b(shopNum1_AdvancePaymentModifyLog);
            //}


        }

        protected void OrderOperateLog(string memo, string strOrdGuId, string strFeeType)
        {
            if (!string.IsNullOrEmpty(strOrdGuId))
            {
                var shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
                shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
                shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(strOrdGuId);
                shopNum1_OrderOperateLog.OderStatus = 1;
                shopNum1_OrderOperateLog.ShipmentStatus = 0;
                shopNum1_OrderOperateLog.PaymentStatus = 1;
                shopNum1_OrderOperateLog.CurrentStateMsg = "已付款";
                if (strFeeType.Equals("2"))
                {
                    shopNum1_OrderOperateLog.NextStateMsg = "等待买家消费";
                }
                else
                {
                    shopNum1_OrderOperateLog.NextStateMsg = "等待发货";
                }
                shopNum1_OrderOperateLog.Memo = memo;
                shopNum1_OrderOperateLog.OperateDateTime =
                    Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                shopNum1_OrderOperateLog.IsDeleted = 0;
                shopNum1_OrderOperateLog.CreateUser = string_2;
                var shopNum1_OrderOperateLog_Action =
                    (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
            }
        }
        protected void GetPayUrl()
        {
            string PaymentGuid = "1075526A-7C28-44D0-B5F8-FD1B6746F662";

            string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
            var payUrlOperate = new PayUrlOperate();
            string payUrl = "";
            if (Jf == "兑换")
            {
                payUrl = payUrlOperate.GetPayUrl(PaymentGuid, LabelShouldPay.Text,
                    ShopSettings.siteDomain, "0", OrderinfoId, Deduction_pv_b.ToString(), "1",
                    MemLoginIDId, MemLoginIDId, timetemp);
            }
            else
            {
                payUrl = payUrlOperate.GetPayUrl(PaymentGuid, LabelShouldPay.Text,
                    ShopSettings.siteDomain, labelScore_dv.Text, OrderinfoId, "0", "1",
                    MemLoginIDId, MemLoginIDId, timetemp);
            }

            if (payUrl.Length > 1000)
            {
                Encoding contentEncoding;
                if (payUrl.Split(new[]
                {
                    '|'
                })[0].IndexOf("UTF") != -1)
                {
                    contentEncoding = Encoding.UTF8;
                }
                else
                {
                    contentEncoding = Encoding.Default;
                }
                Page.Response.ContentEncoding = contentEncoding;
                Page.Response.Write(payUrl.Split(new[]
                {
                    '|'
                })[1]);
            }
            else
            {
                Page.Response.Redirect(payUrl);
            }
        }
        protected void GetAliPayUrl()
        {
            string PaymentGuid = "EB24C8E6-2959-452F-9332-CAEEEDD510BA";

            string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
            var payUrlOperate = new PayUrlOperate();
            string payUrl = "";
            if (Jf == "兑换")
            {
                payUrl = payUrlOperate.GetPayUrl(PaymentGuid, LabelShouldPay.Text,
                ShopSettings.siteDomain, "0", OrderinfoId, Deduction_pv_b.ToString(), "1",
                MemLoginIDId, MemLoginIDId, timetemp);
            }
            else
            {
                payUrl = payUrlOperate.GetPayUrl(PaymentGuid, LabelShouldPay.Text,
                    ShopSettings.siteDomain, labelScore_dv.Text, OrderinfoId, "0", "1",
                    MemLoginIDId, MemLoginIDId, timetemp);
            }

            if (payUrl.Length > 1000)
            {
                Encoding contentEncoding;
                if (payUrl.Split(new[]
                {
                    '|'
                })[0].IndexOf("UTF") != -1)
                {
                    contentEncoding = Encoding.UTF8;
                }
                else
                {
                    contentEncoding = Encoding.Default;
                }
                Page.Response.ContentEncoding = contentEncoding;
                Page.Response.Write(payUrl.Split(new[]
                {
                    '|'
                })[1]);
            }
            else
            {
                Page.Response.Redirect(payUrl);
            }
        }
        //获取并给各个txt负值
        protected void method_0()
        {
            /* DataTable shopProductEdit;*/

            HttpCookie cookieShopMemberLogin1 = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
            HttpCookie decodedCookieShopMemberLogin1 = HttpSecureCookie.Decode(cookieShopMemberLogin1);
            //会员登录ID
            string MemberLoginID1 = decodedCookieShopMemberLogin1.Values["MemLoginID"];
            ShopNum1_Member_Action memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

            //会员等级
            string memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID1);
            if (Page.Request.QueryString["Dinpay"] != null && Page.Request.QueryString["Dinpay"] != "")
            {
                if (Page.Request.QueryString["Dinpay"] == "2")
                {
                    JyFs = "支付宝";
                    xianshi.Visible = false;
                    zfBV.Visible = false;
                }
                if (Page.Request.QueryString["Dinpay"] == "1")
                {
                    JyFs = "唐江智付支付";
                    xianshi.Visible = false;
                    zfBV.Visible = false;
                }



            }
            else
            {
                JyFs = "金币(BV)支付";


            }
            Jf = "其他";
            string text = Page.Request.QueryString["TradeID"];
            IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
            OrderinfoId = text;
            MemLoginIDId = MemberLoginID1;
            Deduction_pv_b = 0M;

            //if (memberGuid.ToLower() == MemberLevel.NORMAL_MEMBER_ID.ToLower())
            //{
            //    shopNum1_OrderInfo_Action.UpdatePTScore_pv_b(text);
            //}


            object obj = Page.Request.QueryString["type"];
            if (1 == 1)
            {
                string a = (Page.Request.QueryString["IsAllPay"] == null) ? "-1" : Page.Request.QueryString["IsAllPay"];
                if ("1" == "1")
                {
                    string text2 = Page.Request.QueryString["TradeID"];

                    var shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action2.GetOrderGuIdByTradeId(text);

                    for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
                    {

                        MyScore_hv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_hv"]);
                        MyScore_pv_a_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_a"]);
                        MyScore_pv_b_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_b"]);
                        MYlabelScore_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_pv_a"]);
                        MYlabelScore_max_hv_tx += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_hv"]);
                        MYlabelScore_dv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_dv"]);
                        MYlabelScore_pv_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_cv"]);

                    }
                    LabelScore_pv_cv.Text = MYlabelScore_pv_cv_txt.ToString();
                    if (LabelScore_pv_cv.Text == "0" || LabelScore_pv_cv.Text == "0.00")
                    {
                        LabelScore_pv_cv.Visible = false;
                        pScore_pv_cv.Visible = false;
                    }
                    LabelScore_pv_a.Text = MyScore_pv_a_txt.ToString();
                    if (LabelScore_pv_a.Text == "0" || LabelScore_pv_a.Text == "0.00")
                    {
                        LabelScore_pv_a.Visible = false;
                        pScore_pv_a.Visible = false;
                    }

                    LabelScore_pv_b.Text = MyScore_pv_b_txt.ToString();
                    if (LabelScore_pv_b.Text == "0" || LabelScore_pv_b.Text == "0.00")
                    {
                        LabelScore_pv_b.Visible = false;
                        pScore_pv_b.Visible = false;
                    }
                    LabelScore_hv.Text = MyScore_hv_txt.ToString();
                    if (LabelScore_hv.Text == "0" || LabelScore_hv.Text == "0.00")
                    {
                        LabelScore_hv.Visible = false;
                        pScore_hv.Visible = false;
                    }
                    labelScore_cv.Text = (MYlabelScore_cv_txt * (-1)).ToString();
                    if (labelScore_cv.Text == "0" || labelScore_cv.Text == "0.00")
                    {
                        labelScore_cv.Visible = false;
                        pScore_cv.Visible = false;
                    }
                    labelScore_max_hv.Text = (MYlabelScore_max_hv_tx * (-1)).ToString();
                    if (labelScore_max_hv.Text == "0" || labelScore_max_hv.Text == "0.00")
                    {
                        labelScore_max_hv.Visible = false;
                        pScore_max_hv.Visible = false;
                    }
                    labelScore_dv.Text = (MYlabelScore_dv_txt * (-1)).ToString();
                    //if (labelScore_max_hv.Text == "0.00" || labelScore_max_hv.Text == "0")
                    //{
                    disable_hv.Visible = false;
                    disable_hvTS.Visible = false;

                    //}




                    dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(text, string_2);
                    DataTable allordertable = shopNum1_OrderInfo_Action.SelectOrderOfAll(text);
                    allOrderguid = allordertable.Rows[0]["Guid"].ToString();
                    allOrderordertype = allordertable.Rows[0]["OrderType"].ToString();
                    allOrdershop_category_id = allordertable.Rows[0]["shop_category_id"].ToString();
                    if (allOrdershop_category_id == "1")
                    {
                        disable_hv.Visible = false;
                        disable_hvTS.Visible = false;
                        DataTable MemberIDFirst = shopNum1_OrderInfo_Action2.GetOrderByMemberIDFirst(MemLoginIDId);
                        if (MemberIDFirst.Rows.Count > 0)
                        {
                            disable_hv.Visible = false;
                            disable_hvTS.Visible = false;
                        }
                    }

                    //我有的
                    MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                    MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                    MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                    MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                    MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                    //我有的
                    MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                    MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                    #region 抵扣红包后的显示价格
                    if ((MyScore_hv > (MYlabelScore_max_hv_tx * (-1))) || (MyScore_hv == (MYlabelScore_max_hv_tx * (-1))))
                    {

                        LabelHiddenShouldPay.Text = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - (MYlabelScore_max_hv_tx * (-1))).ToString();
                        LabelHiddenScore_dv.Text = "0.00";
                        decimal SPdv = Convert.ToDecimal(LabelHiddenShouldPay.Text);
                        if (allOrdershop_category_id == "9")
                        {
                            if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                            {
                                LabelHiddenShouldPay.Text = "0.00";
                                LabelHiddenScore_dv.Text = SPdv.ToString();
                            }
                            else
                            {
                                LabelHiddenShouldPay.Text = (SPdv - MyScore_dv).ToString();
                                LabelHiddenScore_dv.Text = MyScore_dv.ToString();
                            }
                        }

                    }
                    else
                    {
                        LabelHiddenShouldPay.Text = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - MyScore_hv).ToString();
                        LabelHiddenScore_dv.Text = "0.00";
                        decimal SPdv = Convert.ToDecimal(LabelHiddenShouldPay.Text);
                        if (allOrdershop_category_id == "9")
                        {
                            if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                            {
                                LabelHiddenShouldPay.Text = "0.00";
                                LabelHiddenScore_dv.Text = SPdv.ToString();
                            }
                            else
                            {
                                LabelHiddenShouldPay.Text = (SPdv - MyScore_dv).ToString();
                                LabelHiddenScore_dv.Text = MyScore_dv.ToString();
                            }
                        }

                    }
                    #endregion

                    /*  LabelScore_hv.Text = MyScore_hv_txt.ToString();
                      LabelScore_pv_a.Text = MyScore_pv_a_txt.ToString();*/
                    if (dataSet_0 != null && dataSet_0.Tables.Count == 2 &&
                        !(dataSet_0.Tables[0].Rows[0][0].ToString() == "-1"))
                    {
                        if (RadioButtonScore_hv.SelectedValue == "0")
                        {
                            #region 红包抵扣

                            LabelShouldPay.Text = dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
                            labelScore_dv.Text = "0.00";
                            decimal SPdv = Convert.ToDecimal(LabelShouldPay.Text);
                            
                            if (allOrdershop_category_id == "2")
                            {
                                LabelShouldPay.Text = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) / Convert.ToDecimal(QLX_NEC_BILI.GetNECbili())).ToString();
                                JyFs = "新能源链(LNEC)支付";
                                //if (MyScore_hv > SPdv || MyScore_hv == SPdv)
                                //{
                                //    LabelShouldPay.Text = "0.00";
                                //    labelScore_dv.Text = SPdv.ToString();
                                //    Deduction_pv_b = SPdv;
                                //    Jf = "兑换";
                                //}
                                //else
                                //{
                                //    LabelShouldPay.Text = (SPdv - MyScore_hv).ToString();
                                //    labelScore_dv.Text = MyScore_hv.ToString();
                                //    Deduction_pv_b = MyScore_hv;
                                //    Jf = "兑换";
                                //}

                            }
                            if (allOrdershop_category_id == "9")
                            {
                                if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                                {
                                    LabelShouldPay.Text = "0.00";
                                    labelScore_dv.Text = SPdv.ToString();
                                    Jf = "重销";
                                }
                                else
                                {
                                    LabelShouldPay.Text = (SPdv - MyScore_dv).ToString();
                                    labelScore_dv.Text = MyScore_dv.ToString();
                                    Jf = "重销";
                                }
                            }
                            #region
                            //if ((MYlabelScore_dv_txt * (-1)) != 0)
                            //{
                            //    LabelShouldPay.Text = Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]).ToString();
                            //    labelScore_dv.Text = ((MYlabelScore_dv_txt * (-1)) - (MYlabelScore_max_hv_tx * (-1))).ToString();
                            //    if (MyScore_dv < Convert.ToDecimal(labelScore_dv.Text))
                            //    {
                            //        LabelShouldPay.Text = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) + Convert.ToDecimal(labelScore_dv.Text) - MyScore_dv).ToString();
                            //        labelScore_dv.Text = MyScore_dv.ToString();
                            //    }
                            //}
                            //else
                            //{
                            //LabelShouldPay.Text = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"])- MyScore_hv).ToString();
                            //LabelShouldPay.Text = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - (MYlabelScore_max_hv_tx * (-1))).ToString();
                            //labelScore_dv.Text = "0.00";
                            //}
                            //Deduction_pv_b = (MYlabelScore_max_hv_tx * (-1));

                            string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                            string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                            LabelAdvancePayment.Text = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
                            if (allOrdershop_category_id == "2") 
                            {
                                LabelAdvancePayment.Text = dataSet_0.Tables[1].Rows[0]["Score_pv_a"].ToString();
                            }
                            string_3 = dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();

                            MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                            MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                            MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                            MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            #endregion

                            #endregion

                        }
                        else
                        {
                            #region 红包不抵扣

                            LabelShouldPay.Text = dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
                            labelScore_dv.Text = "0.00";
                            decimal SPdv = Convert.ToDecimal(LabelShouldPay.Text);
                            if (allOrdershop_category_id == "9")
                            {
                                if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                                {
                                    LabelShouldPay.Text = "0.00";
                                    labelScore_dv.Text = SPdv.ToString();
                                }
                                else
                                {
                                    LabelShouldPay.Text = (SPdv - MyScore_dv).ToString();
                                    labelScore_dv.Text = MyScore_dv.ToString();
                                }
                            }


                            Deduction_pv_b = 0;

                            string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                            string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                            LabelAdvancePayment.Text = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
                            string_3 = dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();


                            MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                            MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                            MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                            MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            #endregion
                        }
                        /* LabelScore_hv.Text = MyScore_hv.ToString();
                         LabelScore_pv_a.Text = MyScore_pv_a.ToString();*/


                    }
                }

            }

        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (byte_0 == 0)
            {
                base.Render(writer);
            }
            else
            {
                if (byte_0 == 1)
                {
                    writer.Write("<span style=\"color:red\">支付参数不对!</span><span class='gohome'><a href=\"http://" +
                                 ShopSettings.siteDomain + "\">返回首页</a></span>");
                }
                else
                {
                    if (byte_0 == 2)
                    {
                        writer.Write("<span style=\"color:red\">错误的签名!</span><span class='gohome'><a href=\"http://" +
                                     ShopSettings.siteDomain + "\">返回首页</a></span>");
                    }
                    else
                    {
                        if (byte_0 == 3)
                        {
                            writer.Write(
                                "<span style=\"color:red\">支付已经过期请重新点击支付!</span><span class='gohome'><a href=\"http://" +
                                ShopSettings.siteDomain + "\">返回首页</a></span>");
                        }
                        else
                        {
                            writer.Write(
                                "<span style=\"color:red\">非法的支付请求!</span><span class='gohome'><a href=\"http://" +
                                ShopSettings.siteDomain + "\">返回首页</a></span>");
                        }
                    }
                }
            }
        }

        public SortedDictionary<string, string> GetRequestGet()
        {
            var sortedDictionary = new SortedDictionary<string, string>();
            NameValueCollection queryString = HttpContext.Current.Request.QueryString;
            string[] allKeys = queryString.AllKeys;
            if (allKeys.Length == 9)
            {
                for (int i = 0; i < allKeys.Length - 1; i++)
                {
                    if (HttpContext.Current.Request.QueryString[allKeys[i]] != null)
                    {
                        if (allKeys[i].ToString() == "memlogid")
                        {
                            sortedDictionary.Add(allKeys[i], HttpContext.Current.Request.QueryString[allKeys[i]].Replace(' ', '+'));
                        }
                        else
                        {
                            sortedDictionary.Add(allKeys[i], HttpContext.Current.Request.QueryString[allKeys[i]]);
                        }
                    }
                }
                return sortedDictionary;
            }
            else
            {
                for (int i = 0; i < allKeys.Length; i++)
                {
                    if (HttpContext.Current.Request.QueryString[allKeys[i]] != null)
                    {
                        if (allKeys[i].ToString() == "memlogid")
                        {
                            sortedDictionary.Add(allKeys[i], HttpContext.Current.Request.QueryString[allKeys[i]].Replace(' ', '+'));
                        }
                        else
                        {
                            sortedDictionary.Add(allKeys[i], HttpContext.Current.Request.QueryString[allKeys[i]]);
                        }
                    }
                }
                return sortedDictionary;
            }
        }


        protected void IsMMS()
        {
            try
            {
                string guid = string.Empty;
                IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
                string text = Page.Request.QueryString["TradeID"];
                string a = Page.Request.QueryString["IsAllPay"];
                DataTable dataTable = null;

                if (a == "1")
                {
                    dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByTradeIDAndMemloginid(text, string_2);
                }
                else
                {
                    if (a == "0")
                    {
                        dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByOrderNumberAndMemloginid(text, string_2);
                    }
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    guid = dataTable.Rows[0]["guid"].ToString();
                    var shopNum1_OrderInfo_Action2 =
                        (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable orderInfoByGuid = shopNum1_OrderInfo_Action2.GetOrderInfoByGuid(guid);
                    string text2 = string.Empty;
                    if (orderInfoByGuid.Rows[0]["Tel"].ToString().Trim() == "")
                    {
                        if (!(orderInfoByGuid.Rows[0]["Mobile"].ToString().Trim() != ""))
                        {
                            return;
                        }
                        text2 = orderInfoByGuid.Rows[0]["Mobile"].ToString();
                    }
                    else
                    {
                        text2 = orderInfoByGuid.Rows[0]["Tel"].ToString();
                    }
                    var updateOrderStute = new UpdateOrderStute();
                    updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                    updateOrderStute.OrderNumber = Common.Common.GetNameById("mobile", "shopnum1_member",
                     " and memloginid='" + updateOrderStute.Name + "'");
                    updateOrderStute.ShopName = ShopSettings.GetValue("Name");
                    updateOrderStute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    updateOrderStute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string text3 = "204e827c-a610-4212-836e-709cd59cba83";
                    IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                    DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text3, 0);
                    string text4 = string.Empty;
                    string mMsTitle = string.Empty;
                    if (editInfo.Rows.Count > 0)
                    {
                        text4 = editInfo.Rows[0]["Remark"].ToString();
                        mMsTitle = editInfo.Rows[0]["Title"].ToString();
                        text4 = text4.Replace("{$Name}", updateOrderStute.Name);
                        text4 = text4.Replace("{$OrderNumber}", updateOrderStute.OrderNumber);
                        text4 = text4.Replace("{$ShopName}", updateOrderStute.ShopName);
                        text4 = text4.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    var sMS = new SMS();
                    string text5 = "";
                    text4 = updateOrderStute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(text4));
                    sMS.Send(text2.Trim(), text4 + "【唐江宝宝】", out text5);
                    if (text5.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(),
                                                                      text2, mMsTitle, text4, 2, text3);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(orderInfoByGuid.Rows[0]["MemLoginID"].ToString(),
                                                                      text2, mMsTitle, text4, 0, text3);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool method_1(string string_8)
        {
            bool result = false;
            var shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(string_8);
            if (dataTable.Rows.Count > 0 && string.Format("{0}", dataTable.Rows[0]["FeeType"]).Equals("1"))
            {
                string string_9 = string.Format("{0}", dataTable.Rows[0]["Name"]);
                string string_10 = string.Format("{0}", dataTable.Rows[0]["IdentifyCode"]);
                string string_11 = string.Format("{0}", dataTable.Rows[0]["Mobile"]);
                string string_12 = string.Format("{0}", dataTable.Rows[0]["MemLoginID"]);
                string string_13 = string.Format("{0}", dataTable.Rows[0]["ProductName"]);
                string string_14 = string.Format("{0}", dataTable.Rows[0]["BuyNumber"]);
                method_2(string_9, string_8, string_10, string_12, string_11, string_13, string_14);
                result = true;
            }
            return result;
        }

        protected void method_2(string string_8, string string_9, string string_10, string string_11, string string_12,
                                string string_13, string string_14)
        {
            if (!string.IsNullOrEmpty(string_12))
            {
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("73370552-EFDB-47EC-9E0F-F813261375B8", 0);
                if (editInfo.Rows.Count > 0)
                {
                    string text = editInfo.Rows[0]["Remark"].ToString();
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    text = text.Replace("{$Name}", string_8);
                    text = text.Replace("{$OrderNumber}", string_9);
                    text = text.Replace("{$IdentifyCode}", string_10);
                    text = text.Replace("{$ProductName}", string_13);
                    text = text.Replace("{$BuyNum}", string_14);
                    var orderInfo = new OrderInfo();
                    var sMS = new SMS();
                    text = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                    string empty = string.Empty;
                    sMS.Send(string_12, text + "【唐江宝宝】", out empty);
                    if (empty.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(string_11, string_12.Trim(), mMsTitle, text, 2,
                                                                      "73370552-EFDB-47EC-9E0F-F813261375B8");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(string_11, string_12.Trim(), mMsTitle, text, 0,
                                                                      "73370552-EFDB-47EC-9E0F-F813261375B8");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }

        protected void method_3(string string_8, string string_9, string string_10, string string_11)
        {
            if (!string.IsNullOrEmpty(string_11))
            {
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("204e827c-a610-4212-836e-709cd59cba83", 0);
                if (editInfo.Rows.Count > 0)
                {
                    string text = editInfo.Rows[0]["Remark"].ToString();
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    text = text.Replace("{$Name}", string_8);
                    text = text.Replace("{$OrderNumber}", string_9);
                    var orderInfo = new OrderInfo();
                    var sMS = new SMS();
                    text = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                    string empty = string.Empty;
                    sMS.Send(string_11, text + "【唐江宝宝】", out empty);
                    if (empty.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(string_10, string_11.Trim(), mMsTitle, text, 2,
                                                                      "204e827c-a610-4212-836e-709cd59cba83");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(string_10, string_11.Trim(), mMsTitle, text, 0,
                                                                      "204e827c-a610-4212-836e-709cd59cba83");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }

        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string MMsTitle, string strContent,
                                               int state, string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
                {
                    Guid = Guid.NewGuid(),
                    MMSTitle = MMsTitle,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")),
                    MMSGuid = new Guid(mmsGuid),
                    SendObjectMMS = strContent,
                    SendObject = memLoginID + "-" + mobile,
                    State = state
                };
        }

        protected void IsEmail()
        {
            try
            {
                string guid = string.Empty;
                IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
                string text = Page.Request.QueryString["TradeID"];
                string a = Page.Request.QueryString["IsAllPay"];
                DataTable dataTable = null;
                if (a == "1")
                {
                    dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByTradeIDAndMemloginid(text, string_2);
                }
                else
                {
                    if (a == "0")
                    {
                        dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByOrderNumberAndMemloginid(text, string_2);
                    }
                }
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    guid = dataTable.Rows[0]["guid"].ToString();
                    DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(guid);
                    if (orderInfoByGuid.Rows[0]["Email"] != null && !(orderInfoByGuid.Rows[0]["Email"].ToString() == ""))
                    {
                        string email = orderInfoByGuid.Rows[0]["Email"].ToString();
                        string value = ShopSettings.GetValue("Name");
                        var updateOrderStute = new UpdateOrderStute();
                        string memLoginID = updateOrderStute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                        updateOrderStute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                        updateOrderStute.OrderStatus =
                            OrderStatus.ChangeOrderStatus(orderInfoByGuid.Rows[0]["OderStatus"]);
                        updateOrderStute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        updateOrderStute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        updateOrderStute.ShopName = value;
                        string text2 = string.Empty;
                        string emailTitle = string.Empty;
                        string text3 = "204e827c-a610-4212-836e-709cd59cba83";
                        var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                        DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text3 + "'", 0);
                        if (editInfo.Rows.Count > 0)
                        {
                            text2 = editInfo.Rows[0]["Remark"].ToString();
                            emailTitle = editInfo.Rows[0]["Title"].ToString();
                        }
                        text2 = text2.Replace("{$Name}", updateOrderStute.Name);
                        text2 = text2.Replace("{{$OrderNumber}", updateOrderStute.OrderNumber);
                        text2 = text2.Replace("{$ShopName}", value);
                        text2 = text2.Replace("{$SendTime}",
                                              DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"));
                        string emailBody = updateOrderStute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(text2));
                        var sendEmail = new SendEmail();
                        sendEmail.Emails(email, memLoginID, emailTitle, text3, emailBody);
                    }
                }
            }
            catch (Exception)
            {
            }
        }





    }
}