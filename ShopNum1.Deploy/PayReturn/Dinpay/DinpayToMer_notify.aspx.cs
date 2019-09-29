using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1MultiEntity;
using System.Text;
using System.Data;
using System.Threading;
using ShopNum1.Standard;
using ShopNum1.Email;
using ShopNum1.Interface;
using ShopNum1.Common;
using ShopNum1.Factory;
using System.IO;
using ShopNum1.Common.ShopNum1.Common;


namespace ShopNum1.Deploy.PayReturn.Dinpay
{
    public partial class DinpayToMer_notify : System.Web.UI.Page
    {
        private decimal MyScore_hv_txt;
        private decimal MyScore_pv_a_txt;
        private decimal MyScore_pv_b_txt;
        private decimal MYlabelScore_cv_txt;
        private decimal MYlabelScore_max_hv_tx;
        private decimal MYlabelScore_dv_txt;
        private decimal MYlabelScore_pv_cv_txt;
        private DataSet dataSet_0;
        private decimal MyScore_hv;
        private decimal MyScore_pv_a;
        private decimal MyScore_pv_b;
        private decimal MyScore_pv_c;
        private decimal MyScore_dv;
        private decimal MYlabelScore_cv;
        private decimal MYlabelScore_max_hv;
        private decimal ShouldDv;
        private decimal ShouldHv;
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


        private string OrderinfoId;
        private string MemLoginIDId;

        protected void Page_Load(object sender, EventArgs e)
        {
            //StreamWriter stream = new StreamWriter(@"d:\2.txt", true);

            try
            {
                //stream.WriteLine("begin");
                //获取智付反馈信息
                //商户号
                
                string merchant_code = Request.Form["merchant_code"].ToString().Trim();
                //stream.WriteLine("merchant_code=" + merchant_code);
                //通知类型
                string notify_type = Request.Form["notify_type"].ToString().Trim();
                //stream.WriteLine("notify_type=" + notify_type);
                //通知校验ID
                string notify_id = Request.Form["notify_id"].ToString().Trim();
                //stream.WriteLine("notify_id=" + notify_id);
                //接口版本
                string interface_version = Request.Form["interface_version"].ToString().Trim();
                //stream.WriteLine("interface_version=" + interface_version);
                //签名方式
                string sign_type = Request.Form["sign_type"].ToString().Trim();
                //stream.WriteLine("sign_type=" + sign_type);
                //签名
                string dinpaySign = Request.Form["sign"].ToString().Trim();
                //stream.WriteLine("dinpaySign=" + dinpaySign);
                //商家订单号
                string order_no = Request.Form["order_no"].ToString().Trim();
                //stream.WriteLine("order_no=" + order_no);
                //商家订单时间
                string order_time = Request.Form["order_time"].ToString().Trim();
                //stream.WriteLine("order_time=" + order_time);
                //商家订单金额
                string order_amount = Request.Form["order_amount"].ToString().Trim();
                //stream.WriteLine("order_amount=" + order_amount);
                //回传参数
                string extra_return_param = Request.Form["extra_return_param"];
                //stream.WriteLine("extra_return_param=" + extra_return_param);
                //智付交易定单号
                string trade_no = Request.Form["trade_no"].ToString().Trim();
                //stream.WriteLine("trade_no=" + trade_no);
                //智付交易时间
                string trade_time = Request.Form["trade_time"].ToString().Trim();
                //stream.WriteLine("trade_time=" + trade_time);
                //交易状态 SUCCESS 成功  FAILED 失败
                string trade_status = Request.Form["trade_status"].ToString().Trim();
                //stream.WriteLine("trade_status=" + trade_status);
                //银行交易流水号
                string bank_seq_no = Request.Form["bank_seq_no"];
                //stream.WriteLine("bank_seq_no=" + bank_seq_no);
                /**
                 *签名顺序按照参数名a到z的顺序排序，若遇到相同首字母，则看第二个字母，以此类推，
                *同时将商家支付密钥key放在最后参与签名，组成规则如下：
                *参数名1=参数值1&参数名2=参数值2&……&参数名n=参数值n&key=key值
                **/

                OrderinfoId = order_no;
                //组织订单信息
                string signStr = "";

                if (null != bank_seq_no && bank_seq_no != "")
                {
                    signStr = signStr + "bank_seq_no=" + bank_seq_no.ToString().Trim() + "&";
                }

                if (null != extra_return_param && extra_return_param != "")
                {
                    signStr = signStr + "extra_return_param=" + extra_return_param + "&";
                }
                signStr = signStr + "interface_version=V3.0" + "&";
                signStr = signStr + "merchant_code=" + merchant_code + "&";


                if (null != notify_id && notify_id != "")
                {
                    signStr = signStr + "notify_id=" + notify_id + "&notify_type=" + notify_type + "&";
                }

                signStr = signStr + "order_amount=" + order_amount + "&";
                signStr = signStr + "order_no=" + order_no + "&";
                signStr = signStr + "order_time=" + order_time + "&";
                signStr = signStr + "trade_no=" + trade_no + "&";
                signStr = signStr + "trade_status=" + trade_status + "&";

                if (null != trade_time && trade_time != "")
                {
                    signStr = signStr + "trade_time=" + trade_time + "&";
                }

                string key = "Q1anha1tangj1ang_Terr0qq";

                signStr = signStr + "key=" + key;
                string signInfo = signStr;

                //将组装好的信息MD5签名
                string sign = FormsAuthentication.HashPasswordForStoringInConfigFile(signInfo, "md5").ToLower(); //注意与支付签名不同  此处对String进行加密
                //stream.WriteLine("sign=" + sign);

                //比较智付返回的签名串与商家这边组装的签名串是否一致
                if (dinpaySign == sign)
                {
                    //验签成功，数据没有被篡改过
                    /*
                    此处更新订单支付状态
                    业务结束
                    注：请做好订单是否重复修改状态的判断，以免虚拟充值重复到账！！
                    */
                    if (trade_status == "SUCCESS")
                    {
                        //stream.WriteLine("1");
                        #region 充值订单
                        if (order_no.ToUpper().IndexOf("C") != -1)
                        {

                            //OrderinfoId = order_no;
                            //stream.WriteLine("1-1");
                            ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                            DataTable table = shopNum1_AdvancePaymentApplyLog_Action.SearchStatus(order_no);
                            if (table.Rows[0]["OperateStatus"].ToString() == "1")
                            {
                                //stream.WriteLine("充值订单重复");
                                Response.Write("SUCCESS");
                            }
                            else
                            {

                                string nameById = ShopNum1.Common.Common.GetNameById("OrderNumber", "ShopNum1_AdvancePaymentApplyLog", " And OrderNumber='" + order_no + "' And operatestatus=0");
                                //stream.WriteLine("1-2");
                                //File.AppendAllText(base.Server.MapPath("~/log/checklog.txt"), "\r\n\t" + order_no + "错误信息1：" + nameById, Encoding.UTF8);
                                //stream.WriteLine("1-3");
                                if (nameById != "" && nameById != "0")
                                {
                                    //stream.WriteLine("1-4");
                                    string nameById2 = ShopNum1.Common.Common.GetNameById("memloginid", "ShopNum1_AdvancePaymentApplyLog", " And ordernumber='" + order_no + "' And operatestatus=0");
                                    //stream.WriteLine("1-5");
                                    try
                                    {
                                        //stream.WriteLine("1");
                                        string nameById3 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + nameById2 + "'");
                                        //stream.WriteLine("1-6");
                                        //stream.WriteLine("2");
                                        this.AdvancePaymentModifyLogY(1, Convert.ToDecimal(nameById3), Convert.ToDecimal(order_amount), "智付及时到账会员充值", nameById2, Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                                        //stream.WriteLine("1-7");
                                        //stream.WriteLine("3");
                                        shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, order_no);
                                        File.AppendAllText(base.Server.MapPath("~/log/log.txt"), string.Concat(new string[]
								{
									"\r\n充值订单号：",
									order_no,
									"\r\n"
								}), Encoding.UTF8);
                                        //stream.WriteLine("1-8");
                                    }
                                    catch (Exception ex)
                                    {
                                        //stream.WriteLine("4");
                                        File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "错误信息：" + ex.Message, Encoding.UTF8);
                                    }
                                }
                                //stream.WriteLine("充值订单成功");
                                Response.Write("SUCCESS");
                            }
                            //stream.WriteLine("1-9");
                        }

                        #endregion
                        #region 商品订单
                        else
                        {

                            string[] Should = extra_return_param.Split(new char[1] { '|' });
                            ShouldDv = Convert.ToDecimal(Should[0]);
                            ShouldHv = Convert.ToDecimal(Should[1]);

                            // stream.WriteLine("2");
                            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                            ShopNum1_Member_Action memberrankguid_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();

                            DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(order_no);

                            //stream.WriteLine("2-2");
                            if (dataTable.Rows.Count > 0)
                            {
                                if (dataTable.Rows[0]["PaymentStatus"].ToString() == "1")
                                {
                                    //stream.WriteLine("商品订单重复");
                                    Response.Write("SUCCESS");
                                }
                                else
                                {
                                    shopNum1_OrderInfo_Action.UpdateOrderSYhv(order_no, ShouldHv);
                                    #region 如果会员等级为普通，订单不获得B积分
                                    string MemberLoginID = dataTable.Rows[0]["MemLoginID"].ToString();
                                    ////会员等级
                                    //string memberGuid = memberrankguid_Action.GetCurrentMemberRankGuid(MemberLoginID);
                                    //if (memberGuid.ToLower() == MemberLevel.NORMAL_MEMBER_ID.ToLower())
                                    //{
                                    //    shopNum1_OrderInfo_Action.UpdatePTScore_pv_b(order_no);
                                    //}
                                    #endregion
                                    #region 商品需要货币
                                    DataTable orderGuIdByTradeId = shopNum1_OrderInfo_Action.GetOrderGuIdByTradeId(order_no);
                                    for (int i = 0; i < orderGuIdByTradeId.Rows.Count; i++)
                                    {

                                        MyScore_hv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_hv"]);
                                        MyScore_pv_a_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_a"]);
                                        MyScore_pv_b_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_b"]);
                                        MYlabelScore_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["score_reduce_pv_a"]);
                                        MYlabelScore_max_hv_tx += Convert.ToDecimal("0.00");
                                        MYlabelScore_dv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_dv"]);
                                        MYlabelScore_pv_cv_txt += Convert.ToDecimal(orderGuIdByTradeId.Rows[i]["Score_pv_cv"]);

                                    }
                                    #endregion
                                    if (ShouldHv == 0 && dataTable.Rows[0]["shop_category_id"].ToString()=="1")
                                    {
                                        MyScore_hv_txt = Convert.ToDecimal(order_amount);
                                    }
                                    else 
                                    {
                                        MyScore_hv_txt = 0;
                                    }
                                    #region 会员拥有的货币
                                    dataSet_0 = shopNum1_OrderInfo_Action.CheckTradeState(order_no, MemberLoginID);
                                    MyScore_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                                    MyScore_pv_a = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                                    MyScore_pv_b = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_b"]);
                                    MyScore_pv_c = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_cv"]);
                                    MyScore_dv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);
                                    MYlabelScore_cv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_pv_a"]);
                                    MYlabelScore_max_hv = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_hv"]);
                                    #endregion
                                    
                                    MemLoginIDId = MemberLoginID;

                                    // stream.WriteLine("2-3");
                                    int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
                                    //stream.WriteLine("2-4");
                                    if (num < 1)
                                    {
                                        //stream.WriteLine("2-5");
                                        string text4 = dataTable.Rows[0]["MemLoginID"].ToString();
                                        //stream.WriteLine("2-6" + text4);
                                        string text5 = dataTable.Rows[0]["Guid"].ToString();
                                        //stream.WriteLine("2-7" + text5);
                                        string value2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                                        // stream.WriteLine("2-8" + value2);
                                        dataTable.Rows[0]["OrderNumber"].ToString();
                                        File.AppendAllText(base.Server.MapPath("~/log/log.txt"), string.Concat(new string[]
								{
									"\r\n订单号：",
									order_no,
									",交易号：",
									trade_no,
									",用户名：",
									text4,
									"\r\n"
								}), Encoding.UTF8);

                                        ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();

                                        string nameById3 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + text4 + "'");

                                        this.AdvancePaymentModifyLogY(1, Convert.ToDecimal(nameById3), Convert.ToDecimal(order_amount), "智付及时到账会员充值", text4, Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                                        string nameById4 = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + text4 + "'");



                                        this.AdvancePaymentModifyLog(3, Convert.ToDecimal(nameById4), Convert.ToDecimal(order_amount), "智付及时到账消费", text4, Convert.ToDateTime(DateTime.Now.ToLocalTime().AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss")), 0, order_no, text4, Convert.ToDecimal(value2), DateTime.Now, "已付款", "买家已付款", "等待卖家发货", text5, text4);

                                

                                        shopNum1_OrderProduct_Action.UpdateStock(text5);

                                        if (dataTable.Rows[0]["FeeType"].ToString() == "2")
                                        {

                                            this.IsMMS(dataTable.Rows[0]["ordernumber"].ToString(), dataTable.Rows[0]["IdentifyCode"].ToString(), dataTable.Rows[0]["MemloginId"].ToString(), dataTable.Rows[0]["Mobile"].ToString(), dataTable.Rows[0]["ProductName"].ToString(), dataTable.Rows[0]["BuyNumber"].ToString());

                                        }



                                        var orderaction = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                                        var memaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


                                        DataTable table = orderaction.SerchOrderInfoAll(OrderinfoId);
                                        string memid = table.Rows[0]["MemLoginID"].ToString();
                                        String Guid1 = memaction.GetGuidByMemLoginID(memid);
                                        DataTable tablemember = memaction.SearchMemberGuid(Guid1);
                                        if (table.Rows[0]["shop_category_id"].ToString() != "5")
                                        {
                                            orderaction.Push3Gorder(OrderinfoId, tablemember.Rows[0]["MemLoginNO"].ToString(), table.Rows[0]["CreateTime"].ToString(), table.Rows[0]["PayTime"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]), Convert.ToDecimal(table.Rows[0]["Score_pv_a"]));
                                        }
                                        #region 6.1的新逻辑
                                        //用户Score_sv=进货X5最大销售额   Score_cv=销售额度    Score_record_pv_a=普通商品购买次数
                                        if (table.Rows[0]["shop_category_id"].ToString() == "5")
                                        {
                                            memaction.Update5XSV(tablemember.Rows[0]["MemLoginNO"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]));
                                            DataTable m5XSV = memaction.SearchMembertwo(memid);
                                            if (m5XSV.Rows[0]["MemberType"].ToString() == "2")
                                            {
                                                if (Convert.ToDecimal(m5XSV.Rows[0]["Score_sv"]) > Convert.ToDecimal(m5XSV.Rows[0]["Score_cv"]))
                                                {
                                                    DataTable mShop = memaction.SelectShopOfMemloginid(memid);
                                                    if (mShop.Rows[0]["IsDeleted"].ToString() == "1")
                                                    {
                                                        memaction.UpdateShopIsDelete(memid);
                                                    }
                                                }
                                            }

                                        }
                                        if (table.Rows[0]["shop_category_id"].ToString() == "9")
                                        {
                                            memaction.Update5XCV(table.Rows[0]["ShopID"].ToString(), Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]));
                                        }

                                        if (tablemember.Rows[0]["MemberRankGuid"].ToString().ToUpper() == MemberLevel.NORMAL_MEMBER_ID.ToUpper() && Convert.ToDecimal(table.Rows[0]["ShouldPayPrice"]) >= 1000)
                                        {
                                            DataTable m5XSV = memaction.SearchMembertwo(memid);
                                            if (Convert.ToDecimal(m5XSV.Rows[0]["Score_record _pv_a"]) >= 2)
                                            {

                                                memaction.UpdateMemberRankGuid(memid, MemberLevel.VIP_MEMBER_ID);

                                            }
                                            else
                                            {
                                                memaction.UpdatememberZGX1(memid);
                                            }


                                        }
                                        #endregion
                                        Thread.Sleep(60);
                                    }
                                    //stream.WriteLine("商品订单成功");
                                    Response.Write("SUCCESS");
                                    // stream.WriteLine("2-19");
                                }
                            }
                            else
                            {
                                //stream.WriteLine("商品订单不存在");
                                Response.Write("SUCCESS");
                                // stream.WriteLine("2-20");
                            }

                        }
                        #endregion
                    }
                }
                else
                {
                    //验签失败 业务结束
                    base.Response.Write("ERROR");
                }
            }
            catch (Exception ex)
            {

                File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "错误信息：" + ex.Message + "订单号：" + OrderinfoId, Encoding.UTF8);
            }
            finally
            {
                //stream.Close();
            }
        }
        //Response.Write("SUCCESS");//必须打印SUCCESS来响应智付服务器以示商户已经正常收到智付服务器发送的异步数据通知，否则智付服务器将会在之后的时间内若干次发送同一笔订单的异步数据！！

        public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type, string ordernumber, string memLoginID, decimal shouldPay, DateTime paytime, string Olgmemo, string CurrentStateMsg, string NextStateMsg, string OrderGuId, string OlgMemLoginID)
        {
            ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(System.Guid.NewGuid());
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
            shopNum1_AdvancePaymentModifyLog.OperateType = OperateType;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = AdvancePayments;
            shopNum1_AdvancePaymentModifyLog.OperateMoney = payMoney;
            if (type == 1)
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments + payMoney;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments - payMoney;
            }
            #region 退款记录
            GZ_PaymentPrice = payMoney;
            #endregion

            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            String Guid1 = member_Action.GetGuidByMemLoginID(shopMemloginID);
            DataTable tableTJ = member_Action.SearchMemberGuid(Guid1);
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
            if (MyScore_dv > ShouldDv || MyScore_dv == ShouldDv)
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
                shopNum1_AdvancePaymentModifyLog.Score_dv = MyScore_dv - MyScore_dv;
                #region 退款记录
                GZ_Score_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_dv = MyScore_dv;
                shopNum1_AdvancePaymentModifyLog.HuoDe_Hou_dv = MyScore_dv - MyScore_dv;
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
            if (MyScore_hv > ShouldHv || MyScore_hv == ShouldHv)
            {
                shopNum1_AdvancePaymentModifyLog.Score_hv = MyScore_hv - ShouldHv;
                #region 退款记录
                GZ_Score_hv = ShouldHv;
                #endregion
                #region
                shopNum1_AdvancePaymentModifyLog.YuanYou_hv = MyScore_hv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_hv = ShouldHv;
                shopNum1_AdvancePaymentModifyLog.XiaoFei_Hou_hv = MyScore_hv - ShouldHv;
                #endregion
            }
            if (MyScore_hv < ShouldHv && MyScore_hv > -1)
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

            shopNum1_AdvancePaymentModifyLog.Score_pv_a = myHuoDe_YuanYou_pv_a + MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Score_pv_c = shopNum1_AdvancePaymentModifyLog.Score_pv_c + MYlabelScore_pv_cv_txt;
            if ((MyScore_pv_b_txt - ShouldHv) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b;
                GZ_reduce_score_pv_b = 0;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.Score_pv_b = shopNum1_AdvancePaymentModifyLog.Score_pv_b + (MyScore_pv_b_txt-ShouldHv);
                GZ_reduce_score_pv_b = (MyScore_pv_b_txt-ShouldHv);
            }
            //获得pv_cv
            shopNum1_AdvancePaymentModifyLog.DeDao_Qian_cv = TJScore_pv_c;
            shopNum1_AdvancePaymentModifyLog.DeDao_cv = MYlabelScore_pv_cv_txt;
            shopNum1_AdvancePaymentModifyLog.DeDao_Hou_cv = TJScore_pv_c + MYlabelScore_pv_cv_txt;

            //获得pv——b
            shopNum1_AdvancePaymentModifyLog.HuoDe_YuanYou_pv_b = TJScore_pv_b;
            if ((MyScore_pv_b_txt - ShouldHv) < 0)
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = 0;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.HuoDe_pv_b = MyScore_pv_b_txt - ShouldHv;
                shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_b = TJScore_pv_b + (MyScore_pv_b_txt - ShouldHv);
            }

            shopNum1_AdvancePaymentModifyLog.HuoDe_pv_a = MyScore_pv_a_txt;
            shopNum1_AdvancePaymentModifyLog.Huo_DeHou_pv_a = myHuoDe_YuanYou_pv_a + MyScore_pv_a_txt;

            shopNum1_AdvancePaymentModifyLog.OrderInfoOrderNumber = OrderinfoId;
            shopNum1_AdvancePaymentModifyLog.Offset_pv_b = ShouldHv;
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

            //orderrefundaction.Add(orderRefund);
            #endregion



            shopNum1_AdvancePaymentModifyLog.Date = time;
            shopNum1_AdvancePaymentModifyLog.Memo = Memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID = shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateUser = shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.TJmemID = TJID;
            shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(time);
            shopNum1_AdvancePaymentModifyLog.IsDeleted = 0;
            ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
 

            int fh = shopNum1_AdvancePaymentModifyLog_Action.OperateMoney_TJ20160817(shopNum1_AdvancePaymentModifyLog, ordernumber, memLoginID, shouldPay, paytime);
            if (fh == 1)
            {
                orderrefundaction.Add(orderRefund);
                OrderOperateLog(Olgmemo, CurrentStateMsg, NextStateMsg, OrderGuId, OlgMemLoginID);
            }



        }

        #region 原充值逻辑
        public void AdvancePaymentModifyLogY(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type)
        {
            ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid = new Guid?(Guid.NewGuid());
            
            shopNum1_AdvancePaymentModifyLog.OperateType = OperateType;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment = AdvancePayments;
            shopNum1_AdvancePaymentModifyLog.OperateMoney = payMoney;
            if (type == 1)
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments + payMoney;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney = AdvancePayments - payMoney;
            }
            shopNum1_AdvancePaymentModifyLog.OrderInfoOrderNumber = OrderinfoId;
            shopNum1_AdvancePaymentModifyLog.Date = time;
            shopNum1_AdvancePaymentModifyLog.Memo = Memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID = shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateUser = shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateTime = new DateTime?(time);
            shopNum1_AdvancePaymentModifyLog.IsDeleted = new int?(0);
            ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            shopNum1_AdvancePaymentModifyLog_Action.OperateMoneyCZGM(shopNum1_AdvancePaymentModifyLog);
        }
        #endregion

        protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string OrderGuId, string MemLoginID)
        {
            if (!string.IsNullOrEmpty(OrderGuId))
            {
                ShopNum1_OrderOperateLog shopNum1_OrderOperateLog = new ShopNum1_OrderOperateLog();
                shopNum1_OrderOperateLog.Guid = Guid.NewGuid();
                shopNum1_OrderOperateLog.OrderInfoGuid = new Guid(OrderGuId);
                shopNum1_OrderOperateLog.OderStatus = 1;
                shopNum1_OrderOperateLog.ShipmentStatus = 0;
                shopNum1_OrderOperateLog.PaymentStatus = 0;
                shopNum1_OrderOperateLog.CurrentStateMsg = CurrentStateMsg;
                shopNum1_OrderOperateLog.NextStateMsg = NextStateMsg;
                shopNum1_OrderOperateLog.Memo = memo;
                shopNum1_OrderOperateLog.OperateDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                shopNum1_OrderOperateLog.IsDeleted = 0;
                shopNum1_OrderOperateLog.CreateUser = MemLoginID;
                ShopNum1_OrderOperateLog_Action shopNum1_OrderOperateLog_Action = (ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action();
                shopNum1_OrderOperateLog_Action.Add(shopNum1_OrderOperateLog);
            }
        }
        protected void IsMMS(string OrderNumber, string strCode, string memloginID, string string_0, string strProductName, string strBuyNum)
        {
            if (!(string_0.Trim() == ""))
            {
                OrderInfo orderInfo = new OrderInfo();
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
                    SMS sMS = new SMS();
                    string text3 = "";
                    text2 = orderInfo.ChangeOrderInfo(this.Page.Server.HtmlDecode(text2));
                    sMS.Send(string_0.Trim(), text2 + "【唐江宝宝】", out text3);
                    if (text3.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = this.AddMMS(memloginID, string_0.Trim(), text2, mMsTitle, 2, text);
                        shopNum1_MMS_Action.AddMMSGroupSend(shopNum1_MMSGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = this.AddMMS(memloginID, string_0.Trim(), text2, mMsTitle, 0, text);
                        shopNum1_MMS_Action.AddMMSGroupSend(shopNum1_MMSGroupSend);
                    }
                }
            }
        }
        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string strContent, string MMsTitle, int state, string mmsGuid)
        {
            ShopNum1_MMSGroupSend shopNum1_MMSGroupSend = new ShopNum1_MMSGroupSend();
            shopNum1_MMSGroupSend.Guid = Guid.NewGuid();
            shopNum1_MMSGroupSend.MMSTitle = MMsTitle;
            shopNum1_MMSGroupSend.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_MMSGroupSend.MMSGuid = new Guid(mmsGuid);
            shopNum1_MMSGroupSend.SendObjectMMS = strContent;
            shopNum1_MMSGroupSend.SendObject = memLoginID + "-" + mobile;
            shopNum1_MMSGroupSend.State = state;
            return shopNum1_MMSGroupSend;
        }
    }

}
