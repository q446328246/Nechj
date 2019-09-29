using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Email;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFeeTemplate;
using ShopNum1.ShopInterface;
using ShopNum1.Standard;
using ShopNum1MultiEntity;
using ShopNum1.Common.ShopNum1.Common;
using System.Text;
using ShopNum1.Payment;
using System.Web.Security;

namespace ShopNum1.Deploy.MobileServiceAPP
{
    public class WeiXinServicePay_Bv : System.Web.UI.Page
    {


        #region 方法定义
        ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();
        ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action2 = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
        ShopNum1_OrderOperateLog_Action arg_122_0 =
                            (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
        #endregion
        #region 全局变量
        private DataSet dataSet_0;
        private string OrderinfoId;
        private string MemLoginIDId;
        private decimal MyScore_hv_txt;
        private decimal MyScore_pv_a_txt;
        private decimal MyScore_pv_b_txt;
        private decimal MYlabelScore_cv_txt;
        private decimal MYlabelScore_max_hv_tx;
        private decimal MYlabelScore_dv_txt;
        private decimal MYlabelScore_pv_cv_txt;
        private string allOrderguid;
        private string allOrderordertype;
        private string allOrdershop_category_id;
        private decimal MyScore_hv;
        private decimal MyScore_pv_a;
        private decimal MyScore_pv_b;
        private decimal MyScore_pv_c;
        private decimal MyScore_dv;
        private decimal MYlabelScore_cv;
        private decimal MYlabelScore_max_hv;
        private string LabelShouldPay;
        private string labelScore_dv;
        private string LabelAdvancePayment;
        private decimal Deduction_pv_b;
        private string string_6;
        private string string_7;
        private string string_3;
        private string PaymentGuid;
        private string string_5;
        private decimal ShouldPay;
        private decimal ShouldDv;
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
        private string MemloginID;
        #endregion


        /// <summary>
        /// 微信支付接口
        /// </summary>
        /// <param name="OrderNumber">订单编号</param>
        /// <param name="MemloginID">买家ID</param>
        /// <param name="ScoreHvType">是否使用红包（0=使用，1=不使用）</param>
        /// <param name="PayPwd">支付密码</param>
        /// <returns></returns>
        public string Pay(string OrderNumber, string OpenID, string ScoreHvType, string PayPwd)
        {

            DataTable memOpenID = shopNum1_Member_Action.SelectMemberByOpenId(OpenID);

            MemloginID = memOpenID.Rows[0]["MemLoginID"].ToString();

            OrderinfoId = OrderNumber;
            MemLoginIDId = MemloginID;
            DataTable orderGuIdByTradeId2 = shopNum1_OrderInfo_Action2.GetOrderGuIdByTradeId(OrderNumber);
            for (int i = 0; i < orderGuIdByTradeId2.Rows.Count; i++)
            {

                MyScore_hv_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_hv"]);
                MyScore_pv_a_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_pv_a"]);
                MyScore_pv_b_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_pv_b"]);
                MYlabelScore_cv_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["score_reduce_pv_a"]);
                MYlabelScore_max_hv_tx += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["score_reduce_hv"]);
                MYlabelScore_dv_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_dv"]);
                MYlabelScore_pv_cv_txt += Convert.ToDecimal(orderGuIdByTradeId2.Rows[i]["Score_pv_cv"]);
                PaymentGuid = orderGuIdByTradeId2.Rows[i]["PaymentGuid"].ToString();
            }
            dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(OrderNumber, MemloginID);
            DataTable allordertable = shopNum1_OrderInfo_Action.SelectOrderOfAll(OrderNumber);
            allOrderguid = allordertable.Rows[0]["Guid"].ToString();
            allOrderordertype = allordertable.Rows[0]["OrderType"].ToString();
            allOrdershop_category_id = allordertable.Rows[0]["shop_category_id"].ToString();
            //我有的
            MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
            MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
            MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
            MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
            MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
            MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
            MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
            if (dataSet_0 != null && dataSet_0.Tables.Count == 2 &&
                        !(dataSet_0.Tables[0].Rows[0][0].ToString() == "-1"))
            {
                DataTable dataTableStatus = shopNum1_OrderInfo_Action.SearchOrderInfo(OrderinfoId);
                if (dataTableStatus.Rows[0]["PaymentStatus"].ToString() == "1")
                {
                    return "7";
                }
                else
                {
                    if (ScoreHvType == "0")
                    {
                        #region 红包抵扣
                        if ((MyScore_hv > (MYlabelScore_max_hv_tx * (-1))) || (MyScore_hv == (MYlabelScore_max_hv_tx * (-1))))
                        {
                            LabelShouldPay = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - (MYlabelScore_max_hv_tx * (-1))).ToString();
                            labelScore_dv = "0.00";
                            decimal SPdv = Convert.ToDecimal(LabelShouldPay);
                            if (allOrdershop_category_id == "2" || allOrdershop_category_id == "9")
                            {
                                if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                                {
                                    LabelShouldPay = "0.00";
                                    labelScore_dv = SPdv.ToString();
                                }
                                else
                                {
                                    LabelShouldPay = (SPdv - MyScore_dv).ToString();
                                    labelScore_dv = MyScore_dv.ToString();
                                }
                            }
                            Deduction_pv_b = (MYlabelScore_max_hv_tx * (-1));

                            string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                            string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                            LabelAdvancePayment = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
                            string_3 = dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();

                            MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                            MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                            MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                            MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                        }
                        else
                        {
                            LabelShouldPay = (Convert.ToDecimal(dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"]) - MyScore_hv).ToString();
                            labelScore_dv = "0.00";
                            decimal SPdv = Convert.ToDecimal(LabelShouldPay);
                            if (allOrdershop_category_id == "2")
                            {
                                if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                                {
                                    LabelShouldPay = "0.00";
                                    labelScore_dv = SPdv.ToString();
                                }
                                else
                                {
                                    LabelShouldPay = (SPdv - MyScore_dv).ToString();
                                    labelScore_dv = MyScore_dv.ToString();
                                }
                            }
                            Deduction_pv_b = MyScore_hv;

                            string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                            string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                            LabelAdvancePayment = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
                            string_3 = dataSet_0.Tables[0].Rows[0]["PayMentMemLoginID"].ToString();

                            MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                            MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                            MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                            MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                            MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                            MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                        }
                        #endregion
                    }
                    else if (ScoreHvType == "1")
                    {
                        #region 红包不抵扣

                        LabelShouldPay = dataSet_0.Tables[0].Rows[0]["ShouldPayPrice"].ToString();
                        labelScore_dv = "0.00";
                        decimal SPdv = Convert.ToDecimal(LabelShouldPay);
                        if (allOrdershop_category_id == "2" || allOrdershop_category_id == "9")
                        {
                            if (MyScore_dv > SPdv || MyScore_dv == SPdv)
                            {
                                LabelShouldPay = "0.00";
                                labelScore_dv = SPdv.ToString();
                            }
                            else
                            {
                                LabelShouldPay = (SPdv - MyScore_dv).ToString();
                                labelScore_dv = MyScore_dv.ToString();
                            }
                        }


                        Deduction_pv_b = 0;

                        string_6 = dataSet_0.Tables[0].Rows[0]["orderguid"].ToString();
                        string_7 = dataSet_0.Tables[0].Rows[0]["feeType"].ToString();
                        LabelAdvancePayment = dataSet_0.Tables[1].Rows[0]["AdvancePayment"].ToString();
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
                    else
                    {
                        return "3";
                    }
                }

            }

            string mjpayPwd = shopNum1_Member_Action.GetPayPwd(MemloginID);
            if (PayPwd == "")
            {
                return "1";
            }
            else
            {
                string md5SecondHash = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                if (mjpayPwd != md5SecondHash)
                {
                    return "2";

                }
                else
                {
                    if (PaymentGuid.ToUpper() == "1075526A-7C28-44D0-B5F8-FD1B6746F662")
                    {
                        decimal num2 = Convert.ToDecimal(LabelShouldPay);
                        if (num2 < 0 || num2 == 0)
                        {

                            return "4";
                        }
                        else
                        {
                            //string timetemp = DateTime.Now.AddMinutes(10.0).Ticks.ToString();
                            //var payUrlOperate = new PayUrlOperate();
                            //string payUrl = payUrlOperate.GetPayUrl(PaymentGuid, LabelShouldPay,
                            //    ShopSettings.siteDomain, labelScore_dv, OrderinfoId, Deduction_pv_b.ToString(), "1",
                            //    MemLoginIDId, MemLoginIDId, timetemp);
                            ////payUrl += "&mobile=1";
                            //string sb = LabelShouldPay.ToString() + "," + labelScore_dv.ToString() + "," + Deduction_pv_b.ToString();
                            //return sb;

                            string Merchant_code = "2000808866";
                            string Notify_url = ShopSettings.dinpaynotifr;
                            string Interface_version = "V3.0";
                            string Order_no = OrderinfoId;
                            string Order_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            string Order_amount = LabelShouldPay.ToString();
                            string Product_name = OrderinfoId;
                            string Extra_return_param = labelScore_dv.ToString() + "|" + Deduction_pv_b.ToString();
                            string Product_code = "";
                            string Product_desc = "";
                            string Product_num = "";
                            string Redo_flag = "0";

                            //string Merchant_code = "2000808866";
                            //string Notify_url = "http://192.168.1.178:3080/return/return.jsp";
                            //string Interface_version = "V3.0";
                            //string Order_no = "1448522258797";
                            //string Order_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            //string Order_amount = LabelShouldPay.ToString();
                            //string Product_name = OrderinfoId;
                            //string Extra_return_param = labelScore_dv.ToString() + "|" + Deduction_pv_b.ToString();
                            //string Product_code = "";
                            //string Product_desc = "";
                            //string Product_num = "";
                            //string Redo_flag = "0";
                            #region 加密ABCDEFGHIJKLMNOPQRSTUVWXYZ
                            string sign = "";
                            if (Extra_return_param != "")
                            {
                                sign = sign + "extra_return_param=" + Extra_return_param + "&";
                            }
                            if (Interface_version != "")
                            {
                                sign = sign + "interface_version=" + Interface_version + "&";
                            }
                            if (Merchant_code != "")
                            {
                                sign = sign + "merchant_code=" + Merchant_code + "&";
                            }
                            if (Notify_url != "")
                            {
                                sign = sign + "notify_url=" + Notify_url + "&";
                            }
                            if (Order_amount != "")
                            {
                                sign = sign + "order_amount=" + Order_amount + "&";
                            }
                            if (Order_no != "")
                            {
                                sign = sign + "order_no=" + Order_no + "&";
                            }
                            if (Order_time != "")
                            {
                                sign = sign + "order_time=" + Order_time + "&";
                            }
                            if (Product_code != "")
                            {
                                sign = sign + "product_code=" + Product_code + "&";
                            }
                            if (Product_desc != "")
                            {
                                sign = sign + "Product_desc=" + Product_desc + "&";
                            }
                            if (Product_name != "")
                            {
                                sign = sign + "product_name=" + Product_name + "&";
                            }
                            if (Product_num != "")
                            {
                                sign = sign + "product_num=" + Product_num + "&";
                            }
                            if (Redo_flag != "")
                            {
                                sign = sign + "redo_flag=" + Redo_flag + "&";
                            }
                            string key = "Q1anha1tangj1ang_Terr0qq";
                            sign = sign + "key=" + key;
                            string singInfo = sign;
                            //Response.Write("singInfo=" + singInfo + "<br>");


                            //签名
                            string sign1 = FormsAuthentication.HashPasswordForStoringInConfigFile(singInfo, "md5").ToLower();
                            #endregion

                            // 组织报文
                            String xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                                    + "<dinpay><request>"
                                    + "<merchant_code>" + Merchant_code + "</merchant_code>"
                                    + "<notify_url>" + Notify_url + "</notify_url>"
                                    + "<interface_version>" + Interface_version + "</interface_version>"
                                    + "<sign_type>MD5</sign_type>"
                                    + "<sign>" + sign1 + "</sign>"
                                    + "<trade>"
                                    + "<order_no>" + Order_no + "</order_no>"
                                    + "<order_time>" + Order_time + "</order_time>"
                                    + "<order_amount>" + Order_amount + "</order_amount>"
                                    + "<product_name>" + Product_name + "</product_name>"
                                    + "<product_code>" + Product_code + "</product_code>"
                                    + "<extra_return_param>" + Extra_return_param + "</extra_return_param>"
                                    + "<product_desc>" + Product_desc + "</product_desc>"
                                    + "<product_num>" + Product_num + "</product_num>"
                                    + "<redo_flag>" + Redo_flag + "</redo_flag>"
                                    + "</trade></request></dinpay>";

                            return xml;



                        }
                    }
                    else
                    {
                        decimal num2 = Convert.ToDecimal(LabelShouldPay);
                        decimal nom4 = Convert.ToDecimal(labelScore_dv);
                        if (nom4 < 0)
                        {
                            nom4 = nom4 * (-1);
                        }
                        if ((num2.ToString() == "0.00" && nom4.ToString() == "0.00") || (num2.ToString() == "0" && nom4.ToString() == "0"))
                        {
                            return "5";
                        }
                        else
                        {
                            decimal num3 = Convert.ToDecimal(LabelAdvancePayment);
                            string MemRankGuid = shopNum1_Member_Action.GetMemberRankGuid(MemloginID);
                            if (num2 > num3)
                            {
                                return "6";
                            }
                            else
                            {

                                DataTable dataTableStatus = shopNum1_OrderInfo_Action.SearchOrderInfo(OrderinfoId);
                                if (dataTableStatus.Rows[0]["PaymentStatus"].ToString() == "1")
                                {
                                    return "7";
                                }
                                else
                                {
                                    string_5 = "金币（BV）支付";
                                    DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action.GetOrderGuIdByTradeId(OrderinfoId);
                                    ShouldPay = num2;
                                    ShouldDv = nom4;
                                    shopNum1_OrderInfo_Action2.UpdateOrderSYhv(OrderinfoId, Deduction_pv_b);
                                    #region
                                    if (orderGuIdByTradeId.Rows.Count > 0)
                                    {


                                        
                                            MoneyModifyLog20160817(string_5, OrderinfoId, MemLoginIDId, num2, DateTime.Now, string_5, orderGuIdByTradeId.Rows[0]["guid"].ToString(),
                                                            orderGuIdByTradeId.Rows[0]["feeType"].ToString());


                                            
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
                                    
                                    #endregion
                                  
                                    
                                    return "8";

                                }




                            }
                        }
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
        protected void IsMMS()
        {
            try
            {
                string guid = string.Empty;
                IShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = LogicFactory.CreateShopNum1_OrderInfo_Action();

                DataTable dataTable = null;


                dataTable = shopNum1_OrderInfo_Action.GetOrderGuidByOrderNumberAndMemloginid(OrderinfoId, MemLoginIDId);

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
            shopNum1_AdvancePaymentModifyLog.MemLoginID = MemLoginIDId;
            shopNum1_AdvancePaymentModifyLog.CreateUser = MemLoginIDId;
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
                shopNum1_OrderOperateLog.CreateUser = MemLoginIDId;
                var shopNum1_OrderOperateLog_Action =
                    (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
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


    }
}