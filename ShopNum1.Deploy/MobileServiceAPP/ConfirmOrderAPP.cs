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
using System.Configuration;
using Aop.Api.Util;


namespace ShopNum1.Deploy.MobileServiceAPP
{
    public class ConfirmOrderAPP : System.Web.UI.Page
    {
        #region 定义变量
        private decimal MYlabelscore_reduce_pv_cv;
        private decimal ShangPinPrice;
        private decimal MYlabelScore_pv_a;
        private decimal MYlabelscore_reduce_pv_a;
        private decimal MYlabelScore_hv;
        private decimal MYlabelscore_reduce_hv;
        private decimal MYlabelScore_dv;
        private decimal MYlabelScore_pv_b;
        private string MYlabelAgentId;
        private int shop_category_id;
        private string Shopid;


        private string MemberLoginID { get; set; }

        private string MemberType { get; set; }

        private string ShopName { get; set; }
        private decimal QDSQPrice;//区代社区首次价格

        #endregion


        //分享链接
        public Mobile_ShopNum1_FxUrl FxUrl(string MemberLoginID)
        {
            Mobile_ShopNum1_FxUrl Share = new Mobile_ShopNum1_FxUrl();

            Share.FxUrl__share_title = "会员" + MemberLoginID + "邀请您注册唐江宝宝";
            Share.FxUrl__share_url = "http://" + ShopSettings.siteDomain + "/Main/MemberRegister.aspx?recommendid=" + MemberLoginID;
            Share.FxUrl__share_icon = "http://" + ShopSettings.siteDomain + "/Main/Themes/Skin_Default/Images/logo.png";
            Share.FxUrl__share_description = "注册业务员的推广链接";
            return Share;
        }




        //取消订单
        public string CancelOrderNumber(string ordernumber)
        {
            var action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable allStatus = action.GetAllStatusByOrdernumber(ordernumber);
            if (allStatus.Rows.Count > 0)
            {
                if (allStatus.Rows[0]["OderStatus"].ToString() != "2" && allStatus.Rows[0]["OderStatus"].ToString() != "1")
                {
                    action.SetOderStatus1(allStatus.Rows[0]["Guid"].ToString(), 6, 0, 0, DateTime.Now);
                    if (ShopSettings.GetValue("CancelOrderIsEmail") == "1")
                    {
                        IsEmailTwo("CancelOrderIsEmail", allStatus.Rows[0]["Guid"].ToString());
                    }
                    if (ShopSettings.GetValue("CancelOrderIsMMS") == "1")
                    {
                        IsMMStwo("CancelOrderIsMMS", allStatus.Rows[0]["Guid"].ToString());
                    }
                    OrderOperateLog("取消订单", "买家取消订单", "无", allStatus.Rows[0]["Guid"].ToString(), allStatus.Rows[0]["MemLoginID"].ToString());
                    ((ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action()).UpdateReduceStock
                        (allStatus.Rows[0]["Guid"].ToString(), "0");
                    return "1";

                }
                else
                {
                    return "0";
                }
            }
            return "2";
        }
        #region 取消订单需要的
        protected void OrderOperateLog(string memo, string CurrentStateMsg, string NextStateMsg, string guid, string memloginid)
        {
            if (!string.IsNullOrEmpty(guid))
            {
                var orderOperateLog = new ShopNum1_OrderOperateLog
                {
                    Guid = Guid.NewGuid(),
                    OrderInfoGuid = new Guid(guid),
                    OderStatus = 1,
                    ShipmentStatus = 0,
                    PaymentStatus = 0,
                    CurrentStateMsg = CurrentStateMsg,
                    NextStateMsg = NextStateMsg,
                    Memo = memo,
                    OperateDateTime = DateTime.Now,
                    IsDeleted = 0,
                    CreateUser = memloginid
                };
                ((ShopNum1_OrderOperateLog_Action)LogicFactory.CreateShopNum1_OrderOperateLog_Action()).Add(
                    orderOperateLog);
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
                    result = "系统关闭订单";
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
        protected void IsEmailTwo(string strflag, string guid)
        {
            DataTable orderInfoByGuid =
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderInfoByGuid(guid);
            if ((orderInfoByGuid.Rows.Count <= 0) || (orderInfoByGuid.Rows[0]["Email"].ToString() != ""))
            {
                string str;
                string str6;
                string str5 = orderInfoByGuid.Rows[0]["Email"].ToString();
                string str7 = ShopSettings.GetValue("Name");
                var stute = new UpdateOrderStute();
                stute.Name = str6 = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                stute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                stute.OrderStatus = setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
                stute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                stute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                stute.ShopName = str7;
                string s = string.Empty;
                string str3 = string.Empty;
                if (strflag == "CancelOrderIsEmail")
                {
                    str = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
                }
                else
                {
                    str = "204e827c-a610-4212-836e-709cd59cba83";
                }
                DataTable editInfo =
                    ((ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action()).GetEditInfo("'" + str + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    s = editInfo.Rows[0]["Remark"].ToString();
                    str3 = editInfo.Rows[0]["Title"].ToString();
                }
                s =
                    s.Replace("{$Name}", stute.Name)
                        .Replace("{$OrderNumber}", stute.OrderNumber)
                        .Replace("{$ShopName}", stute.ShopName)
                        .Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                string str4 = stute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(s));
                new SendEmail().Emails(str5, str6, str3, str, str4);
            }
        }

        protected void IsMMStwo(string strflag, string guid)
        {
            DataTable orderInfoByGuid =
                ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).GetOrderInfoByGuid(guid);
            var action2 = (ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action();
            if ((orderInfoByGuid.Rows[0]["mobile"] != null) && (orderInfoByGuid.Rows[0]["mobile"].ToString() != ""))
            {
                string str2 = orderInfoByGuid.Rows[0]["mobile"].ToString();
                string str3 = ShopSettings.GetValue("Name");
                var stute = new UpdateOrderStute();
                stute.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                stute.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                stute.OrderStatus = setOrderState(orderInfoByGuid.Rows[0]["OderStatus"].ToString());
                stute.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                stute.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                stute.ShopName = str3;
                string s = string.Empty;
                string mmsGuid = "";
                if (strflag == "CancelOrderIsMMS")
                {
                    mmsGuid = "3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2";
                }
                else
                {
                    mmsGuid = "e77e5311-e0d2-4b6e-b16d-65db7f4ace40";
                }
                if (mmsGuid != "")
                {
                    ShopNum1_MMSGroupSend send;
                    DataTable editInfo =
                        ((ShopNum1_MMS_Action)LogicFactory.CreateShopNum1_MMS_Action()).GetEditInfo(mmsGuid, 0);
                    string mMsTitle = string.Empty;
                    if (editInfo.Rows.Count > 0)
                    {
                        s = editInfo.Rows[0]["Remark"].ToString();
                        mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    }
                    s =
                        s.Replace("{$Name}", stute.Name)
                            .Replace("{$OrderNumber}", stute.OrderNumber)
                            .Replace("{$ShopName}", stute.ShopName)
                            .Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    s = stute.ChangeUpdateOrderStute(Page.Server.HtmlDecode(s));
                    string retmsg = string.Empty;
                    new SMS().Send(str2.Trim(), s + "【唐江宝宝】", out retmsg);
                    if (retmsg.IndexOf("发送成功") != -1)
                    {
                        send = AddMMS(stute.Name, str2.Trim(), mMsTitle, s, 2, mmsGuid);
                        action2.AddMMSGroupSend(send);
                    }
                    else
                    {
                        send = AddMMS(stute.Name, str2.Trim(), mMsTitle, s, 0, mmsGuid);
                        action2.AddMMSGroupSend(send);
                    }
                }
            }
        }
        #endregion

        //ServiceAgent            服务代理
        //MemloginID               登陆用户
        //ShopCategoryID        专区编号
        //PayMentType            支付方式（1=预存款支付，2=智付支付）
        //ProductGuid              商品GUID
        //BuyNumber               购买数量
        //Color                       购买的颜色
        //Size                        购买的尺寸
        //AddressGuid              收货地址GUID
        //ShopID                    卖家编号
        //ProductGuids            多个商品GUID（以，隔开）




        //手机APP创建订单
        public string CreateOrder(string ServiceAgent, string MemloginID, int ShopCategoryID, int PayMentType, string ProductGuid, int BuyNumber, decimal PostPrice, string Color, string Size, string AddressGuid, string TextBoxMessage, string InvoiceType)
        {



            string PostPriceGZ = PostPriceDan(ShopCategoryID, ProductGuid, BuyNumber, MemloginID);


            #region 商品价格等信息
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //会员等级
            string memberGuid = member_Action.GetCurrentMemberRankGuid(MemloginID);


            Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

            DataTable shopProductEdit = shop_Product_Action.GetShopProductEdit(ProductGuid, ShopCategoryID);

            MYlabelscore_reduce_pv_cv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_cv"]);
            #region
            //得到积分
            ShangPinPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"]);
            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) >= 0)
            {
                MYlabelScore_pv_a = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) * Convert.ToDecimal(BuyNumber);
            }
            //可用积分
            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) < 0)
            {
                MYlabelscore_reduce_pv_a = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_cv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"])) * Convert.ToDecimal(BuyNumber);
            }
            //得到红包
            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) >= 0)
            {
                MYlabelScore_hv = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) * Convert.ToDecimal(BuyNumber);
            }
            //可用红包
            if ((Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) < 0)
            {
                MYlabelscore_reduce_hv = (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) + Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"])) * Convert.ToDecimal(BuyNumber);
            }
            #endregion
            MYlabelScore_dv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]) * Convert.ToDecimal(BuyNumber);
            MYlabelScore_pv_b = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(BuyNumber);
            MYlabelAgentId = Convert.ToString(shopProductEdit.Rows[0]["agentId"]);

            shop_category_id = Convert.ToInt32(shopProductEdit.Rows[0]["shop_category_id"]);

            #endregion


            #region 服务代理查询
            if (ShopCategoryID == (int)CustomerCategory.VIP专区)
            {
                DataTable tbc = member_Action.NewSearchAreaAgent(ServiceAgent);

                if (ServiceAgent == "")
                {
                    ServiceAgent = "C0000001";
                    #region
                    if (PayMentType == null || PayMentType == 0)
                    {
                        return "3";
                    }
                    else
                    {


                        #region 添加订单
                        string SuperiorRankGuid = "";
                        DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                        string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                        if (TJMemberNO != null && TJMemberNO != "")
                        {
                            String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                            DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                            SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                        }
                        ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                        shopNum1_OrderInfo.MemLoginID = MemloginID;
                        if (SuperiorRankGuid == "")
                        {
                            shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                        }
                        else
                        {
                            shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                        }
                        shopNum1_OrderInfo.Guid = Guid.NewGuid();
                        Order order = new Order();
                        shopNum1_OrderInfo.OrderNumber = "SJ" + order.CreateOrderNumber();
                        shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
                        shopNum1_OrderInfo.ShipmentStatus = 0;
                        shopNum1_OrderInfo.PaymentStatus = 0;
                        shopNum1_OrderInfo.PayMentMemLoginID = shopProductEdit.Rows[0]["MemLoginID"].ToString();
                        shopNum1_OrderInfo.OrderType = 0;
                        shopNum1_OrderInfo.Score_dv = 0;

                        shopNum1_OrderInfo.Score_hv = MYlabelScore_hv;


                        shopNum1_OrderInfo.score_reduce_hv = MYlabelscore_reduce_hv;


                        shopNum1_OrderInfo.Score_pv_a = MYlabelScore_pv_a;

                        shopNum1_OrderInfo.score_reduce_pv_a = MYlabelscore_reduce_pv_a;

                        shopNum1_OrderInfo.Score_pv_b = MYlabelScore_pv_b;

                        shopNum1_OrderInfo.Score_cv = 0;
                        shopNum1_OrderInfo.Score_max_hv = 0;
                        shopNum1_OrderInfo.shop_category_id = shop_category_id;
                        shopNum1_OrderInfo.AgentId = MYlabelAgentId;
                        shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                        shopNum1_OrderInfo.score_pv_cv = 0.01M;
                        IShopNum1_Address_Action shopNum1_Address_Action =
    LogicFactory.CreateShopNum1_Address_Action();
                        DataTable Addresstable = shopNum1_Address_Action.Search(AddressGuid);
                        try
                        {
                            int OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefault(AddressGuid);
                            ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefaultAndTwo(AddressGuid, MemloginID);
                        }
                        catch (Exception)
                        {


                        }

                        if (Addresstable.Rows.Count > 0)
                        {

                            if (Addresstable.Rows[0]["MemLoginID"].ToString().ToUpper() == MemloginID.ToUpper())
                            {
                                shopNum1_OrderInfo.Name = Addresstable.Rows[0]["Name"].ToString();
                                shopNum1_OrderInfo.Email = Addresstable.Rows[0]["Email"].ToString();
                                shopNum1_OrderInfo.Address = Addresstable.Rows[0]["AddressValue"].ToString() + Addresstable.Rows[0]["Address"].ToString();
                                shopNum1_OrderInfo.Postalcode = Addresstable.Rows[0]["Postalcode"].ToString();
                                shopNum1_OrderInfo.Tel = Addresstable.Rows[0]["Tel"].ToString();
                                shopNum1_OrderInfo.Mobile = Addresstable.Rows[0]["Mobile"].ToString();
                                shopNum1_OrderInfo.RegionCode = Addresstable.Rows[0]["AddressCode"].ToString(); //拿不准的数据

                            }
                            else
                            {
                                return "6";
                            }
                        }
                        else
                        {
                            return "6";
                        }
                        shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                        if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent != "C0000001")
                        {
                            shopNum1_OrderInfo.DispatchType = 0;
                            shopNum1_OrderInfo.FeeType = 1;
                            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                            shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber));
                        }
                        else
                        {
                            shopNum1_OrderInfo.DispatchType = 0;
                            shopNum1_OrderInfo.FeeType = 1;
                            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);
                            if (QDSQPrice != null && QDSQPrice != 0)
                            {
                                shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                            }
                            else if (PostPrice == 0 && ShopCategoryID == 2)
                            {
                                shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);


                            }
                            else
                            {
                                shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);
                            }
                        }

                        shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
                        shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
                        shopNum1_OrderInfo.InvoiceType = InvoiceType;//拿不准的数据
                        shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

                        shopNum1_OrderInfo.OderStatus = 0;
                        //支付方式（1=预存款支付，2=智付支付）
                        if (PayMentType == 1)
                        {
                            shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                            shopNum1_OrderInfo.PaymentName = "预存款支付";
                        }
                        else if (PayMentType == 2)
                        {
                            shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                            shopNum1_OrderInfo.PaymentName = "唐江智付快捷支付";
                        }
                        else if (PayMentType == 3)
                        {
                            shopNum1_OrderInfo.PaymentGuid = new Guid("EB24C8E6-2959-452F-9332-CAEEEDD510BA");
                            shopNum1_OrderInfo.PaymentName = "支付宝";
                        }
                        else
                        {
                            return "7";
                        }

                        shopNum1_OrderInfo.PaymentPrice = Convert.ToDecimal("0.00");
                        shopNum1_OrderInfo.SellerToClientMsg = "";
                        shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
                        shopNum1_OrderInfo.IsMemdelay = 0;
                        shopNum1_OrderInfo.OutOfStockOperate = "";
                        shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                        shopNum1_OrderInfo.PackName = "";
                        shopNum1_OrderInfo.PackPrice = 0m;
                        shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                        shopNum1_OrderInfo.BlessCardName = "";
                        shopNum1_OrderInfo.BlessCardPrice = 0m;
                        shopNum1_OrderInfo.BlessCardContent = "";
                        shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice) * Convert.ToDecimal(BuyNumber);
                        shopNum1_OrderInfo.ProductPv_b = MYlabelScore_pv_b;
                        shopNum1_OrderInfo.AlreadPayPrice = 0m;
                        shopNum1_OrderInfo.SurplusPrice = 0m;
                        shopNum1_OrderInfo.UseScore = 0;
                        shopNum1_OrderInfo.ScorePrice = 0m;

                        shopNum1_OrderInfo.JoinActiveType = -1;
                        shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                        shopNum1_OrderInfo.FromUrl = string.Empty;
                        shopNum1_OrderInfo.PayTime = null;
                        shopNum1_OrderInfo.DispatchTime = null;
                        shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                        shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        shopNum1_OrderInfo.PayMemo = "";
                        shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                        shopNum1_OrderInfo.BuyType = "";
                        shopNum1_OrderInfo.Discount = 0m;
                        shopNum1_OrderInfo.Deposit = 0m;
                        shopNum1_OrderInfo.JoinActiveType = 0;
                        shopNum1_OrderInfo.ActvieContent = "";
                        shopNum1_OrderInfo.UsedFavourTicket = "";
                        string text = string.Empty;
                        if (shopNum1_OrderInfo.FeeType == 2)
                        {
                            var random = new Random();
                            for (int i = 1; i < 7; i++)
                            {
                                text += random.Next(1, 9).ToString();
                            }
                        }
                        shopNum1_OrderInfo.IdentifyCode = text;
                        string value = ShopSettings.GetValue("IsRecommendCommisionOpen");
                        if (value == "true")
                        {
                            ShopSettings.GetValue("RecommendCommision");
                            double num = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                            shopNum1_OrderInfo.RecommendCommision =
                                Convert.ToDecimal(Convert.ToDouble(shopNum1_OrderInfo.ProductPrice) * num);
                        }
                        else
                        {
                            shopNum1_OrderInfo.RecommendCommision = 0m;
                        }
                        Shop_Product_Action shop_Product_Action1 = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                        DataTable dataTable2 = shop_Product_Action1.SearchProductShopByGuid_two(ProductGuid, ShopCategoryID);
                        shopNum1_OrderInfo.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                        shopNum1_OrderInfo.ShopName = dataTable2.Rows[0]["ShopName"].ToString();
                        var list = new List<ShopNum1_OrderProduct>();
                        ShopNum1_OrderProduct shopNum1_OrderProduct = new ShopNum1_OrderProduct();
                        shopNum1_OrderProduct.BuyNumber = BuyNumber;
                        shopNum1_OrderProduct.shop_category_id = shop_category_id;
                        shopNum1_OrderProduct.Guid = Guid.NewGuid();
                        shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
                        shopNum1_OrderProduct.ProductGuid = ProductGuid;
                        shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
                        shopNum1_OrderProduct.RepertoryNumber = dataTable2.Rows[0]["ProductNum"].ToString();
                        shopNum1_OrderProduct.MarketPrice = Convert.ToDecimal(dataTable2.Rows[0]["MarketPrice"].ToString());
                        shopNum1_OrderProduct.ShopPrice = Convert.ToDecimal(dataTable2.Rows[0]["ShopPrice"].ToString());
                        shopNum1_OrderProduct.score_pv_cv = MYlabelscore_reduce_pv_cv;
                        IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                        //DataTable dataTable33 =
                        //    shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["MemLoginID"].ToString());

                        //shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                        shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                        shopNum1_OrderProduct.OrderType = 0;
                        string nameById = Common.Common.GetNameById("memloginid", "shopnum1_orderinfo",
                string.Concat(new[]
                            {
                                " And memloginid='",
                                MemloginID,
                                "' And ordertype=4 And Oderstatus>-1 And Oderstatus<4 And guid in(select orderinfoguid from shopnum1_orderproduct where productguid='",
                                shopNum1_OrderProduct.ProductGuid,
                                "' and MemloginID='",
                                MemloginID,
                                "' And ProductState=1)"
                            }));
                        if (nameById != "")
                        {


                            return "8";
                        }
                        string nameById2 = Common.Common.GetNameById("repertorycount", "shopnum1_shop_product",
               " And Guid='" + shopNum1_OrderProduct.ProductGuid + "'");
                        if (nameById2 == "0")
                        {


                            return "9";
                        }
                        shopNum1_OrderProduct.Attributes =
                dataTable2.Rows[0]["setStock"].ToString();
                        shopNum1_OrderProduct.SpecificationName = "";//拿不准的数据
                        shopNum1_OrderProduct.SpecificationValue = "";//拿不准的数据
                        shopNum1_OrderProduct.setStock = dataTable2.Rows[0]["setStock"].ToString();
                        shopNum1_OrderProduct.IsShipment = 0;
                        shopNum1_OrderProduct.IsReal =
                            Convert.ToInt32(dataTable2.Rows[0]["IsReal"].ToString());
                        shopNum1_OrderProduct.ExtensionAttriutes = "";
                        shopNum1_OrderProduct.IsJoinActivity = 0;
                        shopNum1_OrderProduct.CreateTime =
                            Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        shopNum1_OrderProduct.DetailedSpecifications = "";
                        shopNum1_OrderProduct.MemLoginID = MemloginID;
                        shopNum1_OrderProduct.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                        shopNum1_OrderProduct.ProductName = dataTable2.Rows[0]["Name"].ToString();
                        shopNum1_OrderProduct.Color = Color;
                        shopNum1_OrderProduct.Size = Size;
                        list.Add(shopNum1_OrderProduct);
                        if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                        {
                            IsEmail(shopNum1_OrderInfo.Email, Shopid, shopNum1_OrderInfo.OrderNumber,
                                MemloginID, shopNum1_OrderInfo.Tel, shopNum1_OrderProduct.ProductName,
                                shopNum1_OrderInfo.Mobile);
                        }
                        if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                        {
                            string nameById5 = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                                " and memloginId='" + Shopid + "'");
                            IsMMS(nameById5, Shopid, MemloginID, shopNum1_OrderInfo.Tel,
                                shopNum1_OrderInfo.OrderNumber, shopProductEdit.Rows[0]["Name"].ToString().Trim(), shopNum1_OrderInfo.Mobile);
                        }
                        var shopNum1_OrderInfo_Action =
            (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                        string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
                                  " and memloginid='" + MemloginID + "'");
                        int num2 = shopNum1_OrderInfo_Action.Add(shopNum1_OrderInfo, list);
                        if (num2 > 0)
                        {
                            try
                            {
                                if (ShopSettings.GetValue("OrderIsEmail") == "1")
                                {
                                    IsEmail(shopNum1_OrderInfo.Guid.ToString(), shopNum1_OrderInfo.OrderNumber);
                                }
                                if (ShopSettings.GetValue("OrderIsMMS") == "1")
                                {
                                    IsMMS(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID,
                                        nameById42221);
                                }
                            }
                            catch (Exception)
                            {
                            }
                            return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;
                        }

                        else
                        {
                            return "1";
                        }









                        #endregion

                    }
                    #endregion
                }
                //if ((ShopCategoryID == (int)CustomerCategory.BTC专区) && memberGuid != MemberLevel.NORMAL_MEMBER_ID && ServiceAgent == "C0000001")
                //{
                //    ServiceAgent = "";
                //}

                else if (tbc.Rows.Count > 0)
                {
                    if (tbc.Rows[0]["MemberType"].ToString() == "2")
                    {
                        #region
                        if (PayMentType == null || PayMentType == 0)
                        {
                            return "3";
                        }
                        else
                        {


                            #region 添加订单
                            string SuperiorRankGuid = "";
                            DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                            string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                            if (TJMemberNO != null && TJMemberNO != "")
                            {
                                String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                                DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                                SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                            }
                            ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                            shopNum1_OrderInfo.MemLoginID = MemloginID;
                            if (SuperiorRankGuid == "")
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                            }
                            else
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                            }
                            shopNum1_OrderInfo.Guid = Guid.NewGuid();
                            Order order = new Order();
                            shopNum1_OrderInfo.OrderNumber = "SJ" + order.CreateOrderNumber();
                            shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
                            shopNum1_OrderInfo.ShipmentStatus = 0;
                            shopNum1_OrderInfo.PaymentStatus = 0;
                            shopNum1_OrderInfo.PayMentMemLoginID = shopProductEdit.Rows[0]["MemLoginID"].ToString();
                            shopNum1_OrderInfo.OrderType = 0;
                            shopNum1_OrderInfo.Score_dv = 0;

                            shopNum1_OrderInfo.Score_hv = MYlabelScore_hv;


                            shopNum1_OrderInfo.score_reduce_hv = MYlabelscore_reduce_hv;


                            shopNum1_OrderInfo.Score_pv_a = MYlabelScore_pv_a;

                            shopNum1_OrderInfo.score_reduce_pv_a = MYlabelscore_reduce_pv_a;

                            shopNum1_OrderInfo.Score_pv_b = MYlabelScore_pv_b;

                            shopNum1_OrderInfo.Score_cv = 0;
                            shopNum1_OrderInfo.Score_max_hv = 0;
                            shopNum1_OrderInfo.shop_category_id = shop_category_id;
                            shopNum1_OrderInfo.AgentId = MYlabelAgentId;
                            shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                            shopNum1_OrderInfo.score_pv_cv = 0.01M;
                            IShopNum1_Address_Action shopNum1_Address_Action =
        LogicFactory.CreateShopNum1_Address_Action();
                            DataTable Addresstable = shopNum1_Address_Action.Search(AddressGuid);
                            try
                            {
                                int OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefault(AddressGuid);
                                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefaultAndTwo(AddressGuid, MemloginID);
                            }
                            catch (Exception)
                            {


                            }

                            if (Addresstable.Rows.Count > 0)
                            {

                                if (Addresstable.Rows[0]["MemLoginID"].ToString().ToUpper() == MemloginID.ToUpper())
                                {
                                    shopNum1_OrderInfo.Name = Addresstable.Rows[0]["Name"].ToString();
                                    shopNum1_OrderInfo.Email = Addresstable.Rows[0]["Email"].ToString();
                                    shopNum1_OrderInfo.Address = Addresstable.Rows[0]["AddressValue"].ToString() + Addresstable.Rows[0]["Address"].ToString();
                                    shopNum1_OrderInfo.Postalcode = Addresstable.Rows[0]["Postalcode"].ToString();
                                    shopNum1_OrderInfo.Tel = Addresstable.Rows[0]["Tel"].ToString();
                                    shopNum1_OrderInfo.Mobile = Addresstable.Rows[0]["Mobile"].ToString();
                                    shopNum1_OrderInfo.RegionCode = Addresstable.Rows[0]["AddressCode"].ToString(); //拿不准的数据

                                }
                                else
                                {
                                    return "6";
                                }
                            }
                            else
                            {
                                return "6";
                            }
                            shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                            if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent != "C0000001")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                                shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber));
                            }
                            else
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);
                                if (QDSQPrice != null && QDSQPrice != 0)
                                {
                                    shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                                }
                                else if (PostPrice == 0 && ShopCategoryID == 2)
                                {
                                    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);


                                }
                                else
                                {
                                    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);
                                }
                            }

                            shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
                            shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
                            shopNum1_OrderInfo.InvoiceType = InvoiceType;//拿不准的数据
                            shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

                            shopNum1_OrderInfo.OderStatus = 0;
                            //支付方式（1=预存款支付，2=智付支付）
                            if (PayMentType == 1)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                                shopNum1_OrderInfo.PaymentName = "预存款支付";
                            }
                            else if (PayMentType == 2)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                                shopNum1_OrderInfo.PaymentName = "唐江智付快捷支付";
                            }
                            else if (PayMentType == 3)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("EB24C8E6-2959-452F-9332-CAEEEDD510BA");
                                shopNum1_OrderInfo.PaymentName = "支付宝";
                            }
                            else
                            {
                                return "7";
                            }

                            shopNum1_OrderInfo.PaymentPrice = Convert.ToDecimal("0.00");
                            shopNum1_OrderInfo.SellerToClientMsg = "";
                            shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
                            shopNum1_OrderInfo.IsMemdelay = 0;
                            shopNum1_OrderInfo.OutOfStockOperate = "";
                            shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.PackName = "";
                            shopNum1_OrderInfo.PackPrice = 0m;
                            shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BlessCardName = "";
                            shopNum1_OrderInfo.BlessCardPrice = 0m;
                            shopNum1_OrderInfo.BlessCardContent = "";
                            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice) * Convert.ToDecimal(BuyNumber);
                            shopNum1_OrderInfo.ProductPv_b = MYlabelScore_pv_b;
                            shopNum1_OrderInfo.AlreadPayPrice = 0m;
                            shopNum1_OrderInfo.SurplusPrice = 0m;
                            shopNum1_OrderInfo.UseScore = 0;
                            shopNum1_OrderInfo.ScorePrice = 0m;

                            shopNum1_OrderInfo.JoinActiveType = -1;
                            shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                            shopNum1_OrderInfo.FromUrl = string.Empty;
                            shopNum1_OrderInfo.PayTime = null;
                            shopNum1_OrderInfo.DispatchTime = null;
                            shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                            shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.PayMemo = "";
                            shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BuyType = "";
                            shopNum1_OrderInfo.Discount = 0m;
                            shopNum1_OrderInfo.Deposit = 0m;
                            shopNum1_OrderInfo.JoinActiveType = 0;
                            shopNum1_OrderInfo.ActvieContent = "";
                            shopNum1_OrderInfo.UsedFavourTicket = "";
                            string text = string.Empty;
                            if (shopNum1_OrderInfo.FeeType == 2)
                            {
                                var random = new Random();
                                for (int i = 1; i < 7; i++)
                                {
                                    text += random.Next(1, 9).ToString();
                                }
                            }
                            shopNum1_OrderInfo.IdentifyCode = text;
                            string value = ShopSettings.GetValue("IsRecommendCommisionOpen");
                            if (value == "true")
                            {
                                ShopSettings.GetValue("RecommendCommision");
                                double num = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                                shopNum1_OrderInfo.RecommendCommision =
                                    Convert.ToDecimal(Convert.ToDouble(shopNum1_OrderInfo.ProductPrice) * num);
                            }
                            else
                            {
                                shopNum1_OrderInfo.RecommendCommision = 0m;
                            }
                            Shop_Product_Action shop_Product_Action1 = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                            DataTable dataTable2 = shop_Product_Action1.SearchProductShopByGuid_two(ProductGuid, ShopCategoryID);
                            shopNum1_OrderInfo.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                            shopNum1_OrderInfo.ShopName = dataTable2.Rows[0]["ShopName"].ToString();
                            var list = new List<ShopNum1_OrderProduct>();
                            ShopNum1_OrderProduct shopNum1_OrderProduct = new ShopNum1_OrderProduct();
                            shopNum1_OrderProduct.BuyNumber = BuyNumber;
                            shopNum1_OrderProduct.shop_category_id = shop_category_id;
                            shopNum1_OrderProduct.Guid = Guid.NewGuid();
                            shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
                            shopNum1_OrderProduct.ProductGuid = ProductGuid;
                            shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
                            shopNum1_OrderProduct.RepertoryNumber = dataTable2.Rows[0]["ProductNum"].ToString();
                            shopNum1_OrderProduct.MarketPrice = Convert.ToDecimal(dataTable2.Rows[0]["MarketPrice"].ToString());
                            shopNum1_OrderProduct.ShopPrice = Convert.ToDecimal(dataTable2.Rows[0]["ShopPrice"].ToString());
                            shopNum1_OrderProduct.score_pv_cv = MYlabelscore_reduce_pv_cv;
                            IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                            //DataTable dataTable33 =
                            //    shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["MemLoginID"].ToString());

                            //shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                            shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                            shopNum1_OrderProduct.OrderType = 0;
                            string nameById = Common.Common.GetNameById("memloginid", "shopnum1_orderinfo",
                    string.Concat(new[]
                            {
                                " And memloginid='",
                                MemloginID,
                                "' And ordertype=4 And Oderstatus>-1 And Oderstatus<4 And guid in(select orderinfoguid from shopnum1_orderproduct where productguid='",
                                shopNum1_OrderProduct.ProductGuid,
                                "' and MemloginID='",
                                MemloginID,
                                "' And ProductState=1)"
                            }));
                            if (nameById != "")
                            {


                                return "8";
                            }
                            string nameById2 = Common.Common.GetNameById("repertorycount", "shopnum1_shop_product",
                   " And Guid='" + shopNum1_OrderProduct.ProductGuid + "'");
                            if (nameById2 == "0")
                            {


                                return "9";
                            }
                            shopNum1_OrderProduct.Attributes =
                    dataTable2.Rows[0]["setStock"].ToString();
                            shopNum1_OrderProduct.SpecificationName = "";//拿不准的数据
                            shopNum1_OrderProduct.SpecificationValue = "";//拿不准的数据
                            shopNum1_OrderProduct.setStock = dataTable2.Rows[0]["setStock"].ToString();
                            shopNum1_OrderProduct.IsShipment = 0;
                            shopNum1_OrderProduct.IsReal =
                                Convert.ToInt32(dataTable2.Rows[0]["IsReal"].ToString());
                            shopNum1_OrderProduct.ExtensionAttriutes = "";
                            shopNum1_OrderProduct.IsJoinActivity = 0;
                            shopNum1_OrderProduct.CreateTime =
                                Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderProduct.DetailedSpecifications = "";
                            shopNum1_OrderProduct.MemLoginID = MemloginID;
                            shopNum1_OrderProduct.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                            shopNum1_OrderProduct.ProductName = dataTable2.Rows[0]["Name"].ToString();
                            shopNum1_OrderProduct.Color = Color;
                            shopNum1_OrderProduct.Size = Size;
                            list.Add(shopNum1_OrderProduct);
                            if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                            {
                                IsEmail(shopNum1_OrderInfo.Email, Shopid, shopNum1_OrderInfo.OrderNumber,
                                    MemloginID, shopNum1_OrderInfo.Tel, shopNum1_OrderProduct.ProductName,
                                    shopNum1_OrderInfo.Mobile);
                            }
                            if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                            {
                                string nameById5 = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                                    " and memloginId='" + Shopid + "'");
                                IsMMS(nameById5, Shopid, MemloginID, shopNum1_OrderInfo.Tel,
                                    shopNum1_OrderInfo.OrderNumber, shopProductEdit.Rows[0]["Name"].ToString().Trim(), shopNum1_OrderInfo.Mobile);
                            }
                            var shopNum1_OrderInfo_Action =
                (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                            string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
                                      " and memloginid='" + MemloginID + "'");
                            int num2 = shopNum1_OrderInfo_Action.Add(shopNum1_OrderInfo, list);
                            if (num2 > 0)
                            {
                                try
                                {
                                    if (ShopSettings.GetValue("OrderIsEmail") == "1")
                                    {
                                        IsEmail(shopNum1_OrderInfo.Guid.ToString(), shopNum1_OrderInfo.OrderNumber);
                                    }
                                    if (ShopSettings.GetValue("OrderIsMMS") == "1")
                                    {
                                        IsMMS(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID,
                                            nameById42221);
                                    }
                                }
                                catch (Exception)
                                {
                                }
                                return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;
                            }

                            else
                            {
                                return "1";
                            }









                            #endregion

                        }
                        #endregion
                    }
                    else
                    {
                        return "222";
                    }
                }
                else
                {
                    return "111";
                }
            }
            else
            {
                ServiceAgent = "C0000001";
                #region
                if (PayMentType == null || PayMentType == 0)
                {
                    return "3";
                }
                else
                {


                    #region 添加订单
                    string SuperiorRankGuid = "";
                    DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                    string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                    if (TJMemberNO != null && TJMemberNO != "")
                    {
                        String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());
                        DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                        SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                    }
                    ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                    shopNum1_OrderInfo.MemLoginID = MemloginID;
                    if (SuperiorRankGuid == "")
                    {
                        shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                    }
                    else
                    {
                        shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                    }
                    shopNum1_OrderInfo.Guid = Guid.NewGuid();
                    Order order = new Order();
                    shopNum1_OrderInfo.OrderNumber = "SJ" + order.CreateOrderNumber();
                    shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
                    shopNum1_OrderInfo.ShipmentStatus = 0;
                    shopNum1_OrderInfo.PaymentStatus = 0;
                    shopNum1_OrderInfo.PayMentMemLoginID = shopProductEdit.Rows[0]["MemLoginID"].ToString();
                    shopNum1_OrderInfo.OrderType = 0;
                    shopNum1_OrderInfo.Score_dv = 0;

                    shopNum1_OrderInfo.Score_hv = MYlabelScore_hv;


                    shopNum1_OrderInfo.score_reduce_hv = MYlabelscore_reduce_hv;


                    shopNum1_OrderInfo.Score_pv_a = MYlabelScore_pv_a;

                    shopNum1_OrderInfo.score_reduce_pv_a = MYlabelscore_reduce_pv_a;

                    shopNum1_OrderInfo.Score_pv_b = MYlabelScore_pv_b;

                    shopNum1_OrderInfo.Score_cv = 0;
                    shopNum1_OrderInfo.Score_max_hv = 0;
                    shopNum1_OrderInfo.shop_category_id = shop_category_id;
                    shopNum1_OrderInfo.AgentId = MYlabelAgentId;
                    shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                    shopNum1_OrderInfo.score_pv_cv = 0.01M;
                    IShopNum1_Address_Action shopNum1_Address_Action =
LogicFactory.CreateShopNum1_Address_Action();
                    DataTable Addresstable = shopNum1_Address_Action.Search(AddressGuid);
                    try
                    {
                        int OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefault(AddressGuid);
                        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefaultAndTwo(AddressGuid, MemloginID);
                    }
                    catch (Exception)
                    {


                    }

                    if (Addresstable.Rows.Count > 0)
                    {

                        if (Addresstable.Rows[0]["MemLoginID"].ToString().ToUpper() == MemloginID.ToUpper())
                        {
                            shopNum1_OrderInfo.Name = Addresstable.Rows[0]["Name"].ToString();
                            shopNum1_OrderInfo.Email = Addresstable.Rows[0]["Email"].ToString();
                            shopNum1_OrderInfo.Address = Addresstable.Rows[0]["AddressValue"].ToString() + Addresstable.Rows[0]["Address"].ToString();
                            shopNum1_OrderInfo.Postalcode = Addresstable.Rows[0]["Postalcode"].ToString();
                            shopNum1_OrderInfo.Tel = Addresstable.Rows[0]["Tel"].ToString();
                            shopNum1_OrderInfo.Mobile = Addresstable.Rows[0]["Mobile"].ToString();
                            shopNum1_OrderInfo.RegionCode = Addresstable.Rows[0]["AddressCode"].ToString(); //拿不准的数据

                        }
                        else
                        {
                            return "6";
                        }
                    }
                    else
                    {
                        return "6";
                    }
                    shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                    if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent != "C0000001")
                    {
                        shopNum1_OrderInfo.DispatchType = 0;
                        shopNum1_OrderInfo.FeeType = 1;
                        shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                        shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber));
                    }
                    else
                    {
                        shopNum1_OrderInfo.DispatchType = 0;
                        shopNum1_OrderInfo.FeeType = 1;
                        shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);
                        if (QDSQPrice != null && QDSQPrice != 0)
                        {
                            shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                        }
                        else if (PostPrice == 0 && ShopCategoryID == 2)
                        {
                            shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);


                        }
                        else
                        {
                            shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);
                        }
                    }

                    shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
                    shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
                    shopNum1_OrderInfo.InvoiceType = InvoiceType;//拿不准的数据
                    shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

                    shopNum1_OrderInfo.OderStatus = 0;
                    //支付方式（1=预存款支付，2=智付支付）
                    if (PayMentType == 1)
                    {
                        shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                        shopNum1_OrderInfo.PaymentName = "预存款支付";
                    }
                    else if (PayMentType == 2)
                    {
                        shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                        shopNum1_OrderInfo.PaymentName = "唐江智付快捷支付";
                    }
                    else if (PayMentType == 3)
                    {
                        shopNum1_OrderInfo.PaymentGuid = new Guid("EB24C8E6-2959-452F-9332-CAEEEDD510BA");
                        shopNum1_OrderInfo.PaymentName = "支付宝";
                    }
                    else
                    {
                        return "7";
                    }

                    shopNum1_OrderInfo.PaymentPrice = Convert.ToDecimal("0.00");
                    shopNum1_OrderInfo.SellerToClientMsg = "";
                    shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));
                    shopNum1_OrderInfo.IsMemdelay = 0;
                    shopNum1_OrderInfo.OutOfStockOperate = "";
                    shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                    shopNum1_OrderInfo.PackName = "";
                    shopNum1_OrderInfo.PackPrice = 0m;
                    shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                    shopNum1_OrderInfo.BlessCardName = "";
                    shopNum1_OrderInfo.BlessCardPrice = 0m;
                    shopNum1_OrderInfo.BlessCardContent = "";
                    shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice) * Convert.ToDecimal(BuyNumber);
                    shopNum1_OrderInfo.ProductPv_b = MYlabelScore_pv_b;
                    shopNum1_OrderInfo.AlreadPayPrice = 0m;
                    shopNum1_OrderInfo.SurplusPrice = 0m;
                    shopNum1_OrderInfo.UseScore = 0;
                    shopNum1_OrderInfo.ScorePrice = 0m;

                    shopNum1_OrderInfo.JoinActiveType = -1;
                    shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                    shopNum1_OrderInfo.FromUrl = string.Empty;
                    shopNum1_OrderInfo.PayTime = null;
                    shopNum1_OrderInfo.DispatchTime = null;
                    shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                    shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_OrderInfo.PayMemo = "";
                    shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                    shopNum1_OrderInfo.BuyType = "";
                    shopNum1_OrderInfo.Discount = 0m;
                    shopNum1_OrderInfo.Deposit = 0m;
                    shopNum1_OrderInfo.JoinActiveType = 0;
                    shopNum1_OrderInfo.ActvieContent = "";
                    shopNum1_OrderInfo.UsedFavourTicket = "";
                    string text = string.Empty;
                    if (shopNum1_OrderInfo.FeeType == 2)
                    {
                        var random = new Random();
                        for (int i = 1; i < 7; i++)
                        {
                            text += random.Next(1, 9).ToString();
                        }
                    }
                    shopNum1_OrderInfo.IdentifyCode = text;
                    string value = ShopSettings.GetValue("IsRecommendCommisionOpen");
                    if (value == "true")
                    {
                        ShopSettings.GetValue("RecommendCommision");
                        double num = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                        shopNum1_OrderInfo.RecommendCommision =
                            Convert.ToDecimal(Convert.ToDouble(shopNum1_OrderInfo.ProductPrice) * num);
                    }
                    else
                    {
                        shopNum1_OrderInfo.RecommendCommision = 0m;
                    }
                    Shop_Product_Action shop_Product_Action1 = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();
                    DataTable dataTable2 = shop_Product_Action1.SearchProductShopByGuid_two(ProductGuid, ShopCategoryID);
                    shopNum1_OrderInfo.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                    shopNum1_OrderInfo.ShopName = dataTable2.Rows[0]["ShopName"].ToString();
                    var list = new List<ShopNum1_OrderProduct>();
                    ShopNum1_OrderProduct shopNum1_OrderProduct = new ShopNum1_OrderProduct();
                    shopNum1_OrderProduct.BuyNumber = BuyNumber;
                    shopNum1_OrderProduct.shop_category_id = shop_category_id;
                    shopNum1_OrderProduct.Guid = Guid.NewGuid();
                    shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
                    shopNum1_OrderProduct.ProductGuid = ProductGuid;
                    shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
                    shopNum1_OrderProduct.RepertoryNumber = dataTable2.Rows[0]["ProductNum"].ToString();
                    shopNum1_OrderProduct.MarketPrice = Convert.ToDecimal(dataTable2.Rows[0]["MarketPrice"].ToString());
                    shopNum1_OrderProduct.ShopPrice = Convert.ToDecimal(dataTable2.Rows[0]["ShopPrice"].ToString());
                    shopNum1_OrderProduct.score_pv_cv = MYlabelscore_reduce_pv_cv;
                    IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                    //DataTable dataTable33 =
                    //    shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["MemLoginID"].ToString());

                    //shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                    shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
                    shopNum1_OrderProduct.OrderType = 0;
                    string nameById = Common.Common.GetNameById("memloginid", "shopnum1_orderinfo",
            string.Concat(new[]
                            {
                                " And memloginid='",
                                MemloginID,
                                "' And ordertype=4 And Oderstatus>-1 And Oderstatus<4 And guid in(select orderinfoguid from shopnum1_orderproduct where productguid='",
                                shopNum1_OrderProduct.ProductGuid,
                                "' and MemloginID='",
                                MemloginID,
                                "' And ProductState=1)"
                            }));
                    if (nameById != "")
                    {


                        return "8";
                    }
                    string nameById2 = Common.Common.GetNameById("repertorycount", "shopnum1_shop_product",
           " And Guid='" + shopNum1_OrderProduct.ProductGuid + "'");
                    if (nameById2 == "0")
                    {


                        return "9";
                    }
                    shopNum1_OrderProduct.Attributes =
            dataTable2.Rows[0]["setStock"].ToString();
                    shopNum1_OrderProduct.SpecificationName = "";//拿不准的数据
                    shopNum1_OrderProduct.SpecificationValue = "";//拿不准的数据
                    shopNum1_OrderProduct.setStock = dataTable2.Rows[0]["setStock"].ToString();
                    shopNum1_OrderProduct.IsShipment = 0;
                    shopNum1_OrderProduct.IsReal =
                        Convert.ToInt32(dataTable2.Rows[0]["IsReal"].ToString());
                    shopNum1_OrderProduct.ExtensionAttriutes = "";
                    shopNum1_OrderProduct.IsJoinActivity = 0;
                    shopNum1_OrderProduct.CreateTime =
                        Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_OrderProduct.DetailedSpecifications = "";
                    shopNum1_OrderProduct.MemLoginID = MemloginID;
                    shopNum1_OrderProduct.ShopID = dataTable2.Rows[0]["MemLoginID"].ToString();
                    shopNum1_OrderProduct.ProductName = dataTable2.Rows[0]["Name"].ToString();
                    shopNum1_OrderProduct.Color = Color;
                    shopNum1_OrderProduct.Size = Size;
                    list.Add(shopNum1_OrderProduct);
                    if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                    {
                        IsEmail(shopNum1_OrderInfo.Email, Shopid, shopNum1_OrderInfo.OrderNumber,
                            MemloginID, shopNum1_OrderInfo.Tel, shopNum1_OrderProduct.ProductName,
                            shopNum1_OrderInfo.Mobile);
                    }
                    if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                    {
                        string nameById5 = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                            " and memloginId='" + Shopid + "'");
                        IsMMS(nameById5, Shopid, MemloginID, shopNum1_OrderInfo.Tel,
                            shopNum1_OrderInfo.OrderNumber, shopProductEdit.Rows[0]["Name"].ToString().Trim(), shopNum1_OrderInfo.Mobile);
                    }
                    var shopNum1_OrderInfo_Action =
        (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
                              " and memloginid='" + MemloginID + "'");
                    int num2 = shopNum1_OrderInfo_Action.Add(shopNum1_OrderInfo, list);
                    if (num2 > 0)
                    {
                        try
                        {
                            if (ShopSettings.GetValue("OrderIsEmail") == "1")
                            {
                                IsEmail(shopNum1_OrderInfo.Guid.ToString(), shopNum1_OrderInfo.OrderNumber);
                            }
                            if (ShopSettings.GetValue("OrderIsMMS") == "1")
                            {
                                IsMMS(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID,
                                    nameById42221);
                            }
                        }
                        catch (Exception)
                        {
                        }
                        return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;
                    }

                    else
                    {
                        return "1";
                    }









                    #endregion

                }
                #endregion
            }








            #endregion
        }



        //手机APP购物车创建订单
        public string CreateOrderCar(string ServiceAgent, string MemloginID, int ShopCategoryID, int PayMentType, string ProductGuids, string AddressGuid, string ShopID, string TextBoxMessage, string InvoiceType)
        {




            IShopNum1_Cart_Action ishopNum1_Cart_Action_0 = LogicFactory.CreateShopNum1_Cart_Action();
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string memberGuid = member_Action.GetCurrentMemberRankGuid(MemloginID);
            DataTable DataTableGuid = ishopNum1_Cart_Action_0.GetProductInfoByMemLoginID(MemloginID);
            StringBuilder guids = new StringBuilder();
            StringBuilder ProductGuIds = new StringBuilder();
            foreach (DataRow row in DataTableGuid.Rows)
            {
                guids.Append(row["guid"]);
                guids.Append(",");
                ProductGuIds.Append(row["ProductGuId"]);
                ProductGuIds.Append(",");
            }

            string ProductGuids1 = ProductGuIds.ToString().Remove(guids.Length - 1, 1);
            string ShopCarGuids = guids.ToString().Remove(guids.Length - 1, 1);
            string PostPriceGZ = PostPriceCar(ShopID, ShopCategoryID, ShopCarGuids, MemloginID);
            //DataTable dataTable1 = ishopNum1_Cart_Action_0.SearchShopByMemLoginID(MemloginID, ProductGuids1);


            DataTable productInfoByCartProductGuid =
                    ishopNum1_Cart_Action_0.GetProductInfoByProductGuids(MemloginID, ShopID, ProductGuids1);
            for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
            {

                ShangPinPrice += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["ShopPrice"].ToString()) * Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString());
            }
            if (ShopCategoryID == (int)CustomerCategory.VIP专区)
            {
                DataTable tbc = member_Action.NewSearchAreaAgent(ServiceAgent.Trim());

                if (ServiceAgent == "")
                {
                    ServiceAgent = "C0000001";
                    #region
                    if (PayMentType == null || PayMentType == 0)
                    {
                        return "3";
                    }
                    else
                    {
                        
                        
                            #region 创建购物车订单
                            string tel;
                            var list = new List<ShopNum1_OrderInfo>();
                            var list2 = new List<ShopNum1_OrderProduct>();
                            IShopNum1_Address_Action shopNum1_Address_Action = LogicFactory.CreateShopNum1_Address_Action();

                            Order order = new Order();
                            string orderid = "SJ" + order.CreateOrderNumber();
                            int num = 0;
                            DataTable dataTable = ishopNum1_Cart_Action_0.SearchShopByMemLoginID(MemloginID, ProductGuids1);
                            string SuperiorRankGuid = "";
                            DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                            string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                            if (TJMemberNO != null && TJMemberNO != "")
                            {

                                String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());

                                DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                                SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                            }
                            ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                            shopNum1_OrderInfo.MemLoginID = MemloginID;
                            if (SuperiorRankGuid == "")
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                            }
                            else
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                            }
                            shopNum1_OrderInfo.TradeID = orderid;
                            shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                            shopNum1_OrderInfo.OderStatus = 0;


                            shopNum1_OrderInfo.ShipmentStatus = 0;
                            shopNum1_OrderInfo.PaymentStatus = 0;
                            shopNum1_OrderInfo.OrderType = 0;
                            shopNum1_OrderInfo.PayMentMemLoginID = MemloginID;
                            shopNum1_OrderInfo.IsMinus = 0;
                            DataTable Addresstable = shopNum1_Address_Action.Search(AddressGuid);
                            try
                            {
                                int OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefault(AddressGuid);
                                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefaultAndTwo(AddressGuid, MemloginID);
                            }
                            catch (Exception)
                            {


                            }
                            if (Addresstable.Rows.Count > 0)
                            {

                                shopNum1_OrderInfo.Name = Addresstable.Rows[0]["Name"].ToString();
                                shopNum1_OrderInfo.Email = Addresstable.Rows[0]["Email"].ToString();
                                shopNum1_OrderInfo.Address = Addresstable.Rows[0]["AddressValue"].ToString() + Addresstable.Rows[0]["Address"].ToString();
                                shopNum1_OrderInfo.Postalcode = Addresstable.Rows[0]["Postalcode"].ToString();
                                shopNum1_OrderInfo.Tel = Addresstable.Rows[0]["Tel"].ToString();
                                shopNum1_OrderInfo.Mobile = Addresstable.Rows[0]["Mobile"].ToString();
                                shopNum1_OrderInfo.RegionCode = Addresstable.Rows[0]["AddressCode"].ToString(); //拿不准的数据
                                tel = Addresstable.Rows[0]["Tel"].ToString();

                            }
                            else
                            {
                                return "6";
                            }
                            //支付方式（1=预存款支付，2=智付支付）
                            if (PayMentType == 1)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                                shopNum1_OrderInfo.PaymentName = "预存款支付";
                            }
                            else if (PayMentType == 2)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                                shopNum1_OrderInfo.PaymentName = "唐江智付快捷支付";
                            }
                            else if (PayMentType == 3)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("EB24C8E6-2959-452F-9332-CAEEEDD510BA");
                                shopNum1_OrderInfo.PaymentName = "支付宝";
                            }
                            else
                            {
                                return "7";
                            }
                            shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                            shopNum1_OrderInfo.SellerToClientMsg = "";
                            shopNum1_OrderInfo.IsMemdelay = 0;
                            shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));

                            shopNum1_OrderInfo.InvoiceTitle = "";
                            shopNum1_OrderInfo.InvoiceContent = "";
                            shopNum1_OrderInfo.InvoiceType = InvoiceType;
                            shopNum1_OrderInfo.InvoiceTax = 0m;

                            shopNum1_OrderInfo.PaymentPrice = 0M;
                            shopNum1_OrderInfo.OutOfStockOperate = "";
                            shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.PackName = "";
                            shopNum1_OrderInfo.PackPrice = 0m;
                            shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BlessCardName = "";
                            shopNum1_OrderInfo.BlessCardPrice = 0m;
                            shopNum1_OrderInfo.BlessCardContent = "";
                            shopNum1_OrderInfo.AlreadPayPrice = 0m;
                            shopNum1_OrderInfo.SurplusPrice = 0m;
                            shopNum1_OrderInfo.UseScore = 0;
                            shopNum1_OrderInfo.ScorePrice = 0m;
                            shopNum1_OrderInfo.JoinActiveType = -1;
                            shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                            shopNum1_OrderInfo.FromUrl = string.Empty;
                            shopNum1_OrderInfo.PayTime = null;
                            shopNum1_OrderInfo.DispatchTime = null;
                            shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                            shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.PayMemo = "";
                            shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BuyType = "";
                            shopNum1_OrderInfo.Discount = 0m;
                            shopNum1_OrderInfo.Deposit = 0m;
                            shopNum1_OrderInfo.JoinActiveType = 0;
                            shopNum1_OrderInfo.ActvieContent = "";
                            shopNum1_OrderInfo.UsedFavourTicket = "";
                            shopNum1_OrderInfo.Guid = Guid.NewGuid();
                            shopNum1_OrderInfo.ShopID = ShopID;


                            string[] guid = ProductGuids1.Replace("'", "").Split(',');
                            for (int i = 0; i < guid.Length; i++)
                            {
                                Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

                                DataTable shopProductEdit = ishopNum1_Cart_Action_0.SearchShopByMemLoginID_Price(MemloginID, ShopCarGuids, guid[i], ShopCategoryID);

                                shopNum1_OrderInfo.score_pv_cv = 0.01M;
                                #region
                                //得到积分
                                //ShangPinPrice += Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) >= 0)
                                {
                                    shopNum1_OrderInfo.Score_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                }
                                //可用积分
                                if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) < 0)
                                {
                                    shopNum1_OrderInfo.score_reduce_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                }
                                //得到红包
                                if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"]) >= 0)
                                {
                                    shopNum1_OrderInfo.Score_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                }
                                //可用红包
                                if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) < 0)
                                {
                                    shopNum1_OrderInfo.score_reduce_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                }
                                #endregion
                                shopNum1_OrderInfo.Score_dv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                shopNum1_OrderInfo.Score_pv_b += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);

                                shopNum1_OrderInfo.ShopName = shopProductEdit.Rows[0]["SellName"].ToString();

                            }
                            shopNum1_OrderInfo.shop_category_id = ShopCategoryID;



                            if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                            {
                                IsEmail(shopNum1_OrderInfo.Email, ShopID, shopNum1_OrderInfo.OrderNumber,
                                    MemloginID, shopNum1_OrderInfo.Tel, "", shopNum1_OrderInfo.Mobile);
                            }
                            if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                            {
                                string nameById = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                                    " and memloginId='" + ShopID + "'");
                                IsMMS(nameById, ShopID, MemloginID, shopNum1_OrderInfo.Tel,
                                    shopNum1_OrderInfo.OrderNumber, "", shopNum1_OrderInfo.Mobile);
                            }
                            string value2 = ShopSettings.GetValue("IsRecommendCommisionOpen");
                            if (value2 == "true")
                            {
                                ShopSettings.GetValue("RecommendCommision");
                                double num3 = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                                shopNum1_OrderInfo.RecommendCommision =
                                    Convert.ToDecimal(Convert.ToDouble(ShangPinPrice) * num3);
                            }
                            else
                            {
                                shopNum1_OrderInfo.RecommendCommision = 0m;
                            }
                            shopNum1_OrderInfo.OrderNumber = shopNum1_OrderInfo.TradeID;
                            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice);
                            shopNum1_OrderInfo.ProductPv_b = shopNum1_OrderInfo.Score_pv_b;
                            if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent.ToUpper() != "C0000001")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                                shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice;
                            }
                            else
                            {
                                if (QDSQPrice != null && QDSQPrice != 0)
                                {
                                    shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                                    shopNum1_OrderInfo.DispatchType = 0;
                                    shopNum1_OrderInfo.FeeType = 1;
                                    shopNum1_OrderInfo.DispatchPrice = 0;
                                }
                                else if (Convert.ToDecimal(PostPriceGZ) == 0 && ShopCategoryID == 2)
                                {
                                    shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + Convert.ToDecimal(PostPriceGZ);
                                    shopNum1_OrderInfo.DispatchType = 0;
                                    shopNum1_OrderInfo.FeeType = 1;
                                    shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);

                                }
                                else
                                {
                                    shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + Convert.ToDecimal(PostPriceGZ);
                                    shopNum1_OrderInfo.DispatchType = 0;
                                    shopNum1_OrderInfo.FeeType = 1;
                                    shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);
                                }
                            }
                            list.Add(shopNum1_OrderInfo);

                            DataTable dataTable3 = new DataTable();
                            dataTable3 = ishopNum1_Cart_Action_0.SearchByMemLoginIDAndShopID(MemloginID, ShopID);
                            for (int i = 0; i < dataTable3.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dataTable3.Rows[i]["shop_category_id"]) == shopNum1_OrderInfo.shop_category_id)
                                {
                                    list2.Add(new ShopNum1_OrderProduct
                                    {
                                        ProductImg = dataTable3.Rows[i]["originalimge"].ToString(),
                                        OrderType = Convert.ToInt32(dataTable3.Rows[i]["carttype"].ToString()),
                                        Guid = Guid.NewGuid(),
                                        OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString(),
                                        ProductGuid = dataTable3.Rows[i]["ProductGuid"].ToString(),
                                        GroupPrice = Convert.ToDecimal("0.00"),
                                        SpecificationName = dataTable3.Rows[i]["SpecificationName"].ToString(),
                                        SpecificationValue = dataTable3.Rows[i]["SpecificationValue"].ToString(),
                                        setStock = dataTable3.Rows[i]["Attributes"].ToString(),
                                        ProductName = dataTable3.Rows[i]["Name"].ToString(),
                                        RepertoryNumber = dataTable3.Rows[i]["RepertoryNumber"].ToString(),
                                        BuyNumber = Convert.ToInt32(dataTable3.Rows[i]["BuyNumber"].ToString()),
                                        MarketPrice = Convert.ToDecimal(dataTable3.Rows[i]["MarketPrice"].ToString()),
                                        ShopPrice = Convert.ToDecimal(dataTable3.Rows[i]["ShopPrice"].ToString()),
                                        BuyPrice = Convert.ToDecimal(dataTable3.Rows[i]["BuyPrice"].ToString()),
                                        Attributes = dataTable3.Rows[i]["Attributes"].ToString(),
                                        IsShipment = Convert.ToInt32(dataTable3.Rows[i]["IsShipment"].ToString()),
                                        IsReal = Convert.ToInt32(dataTable3.Rows[i]["IsReal"].ToString()),
                                        ExtensionAttriutes = dataTable3.Rows[i]["ExtensionAttriutes"].ToString(),
                                        IsJoinActivity = Convert.ToInt32(dataTable3.Rows[i]["IsJoinActivity"].ToString()),
                                        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                        DetailedSpecifications = dataTable3.Rows[i]["DetailedSpecifications"].ToString(),
                                        MemLoginID = MemloginID,
                                        ShopID = dataTable3.Rows[i]["ShopID"].ToString(),
                                        shop_category_id = Convert.ToInt32(dataTable3.Rows[i]["shop_category_id"]),
                                        Size = dataTable3.Rows[i]["Size"].ToString(),
                                        Color = dataTable3.Rows[i]["Color"].ToString()

                                    });
                                }
                            }
                            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action =
              (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                            int num4 = shopNum1_OrderInfo_Action.Add(list, list2);
                            if (num4 > 0)
                            {


                                int num5 = ishopNum1_Cart_Action_0.DeleteByMemLoginID(MemloginID);


                                if (num5 > 0)
                                {
                                }
                                ShopNum1_Member_Action shopNum1_Member_Action =
                                    (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                DataTable memberInfoByMemLoginID =
                                    shopNum1_Member_Action.GetMemberInfoByMemLoginID(MemloginID);
                                if (memberInfoByMemLoginID.Rows.Count > 0)
                                {
                                    if (ShopSettings.GetValue("OrderIsEmail") == "1")
                                    {
                                        IsEmail(orderid.ToString(), MemloginID,
                                            memberInfoByMemLoginID.Rows[0]["email"].ToString());
                                    }
                                    if (ShopSettings.GetValue("SubmitOrderIsMMS") == "1")
                                    {
                                        IsMMS(orderid.ToString(), MemloginID, tel);
                                    }
                                }
                                return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + orderid.ToString() + "," + shopNum1_OrderInfo.Guid;

                            }

                            return "1";






                            #endregion
                        
                    }





                    #endregion
                }
                //if ((ShopCategoryID == (int)CustomerCategory.BTC专区) && memberGuid != MemberLevel.NORMAL_MEMBER_ID && ServiceAgent == "C0000001")
                //{

                //    ServiceAgent = "";
                //}

                else if (tbc.Rows.Count > 0)
                {
                    if (tbc.Rows[0]["MemberType"].ToString() == "2")
                    {
                        #region
                        if (PayMentType == null || PayMentType == 0)
                        {
                            return "3";
                        }
                        else
                        {

                            #region 创建购物车订单
                            string tel;
                            var list = new List<ShopNum1_OrderInfo>();
                            var list2 = new List<ShopNum1_OrderProduct>();
                            IShopNum1_Address_Action shopNum1_Address_Action = LogicFactory.CreateShopNum1_Address_Action();

                            Order order = new Order();
                            string orderid = "SJ" + order.CreateOrderNumber();
                            int num = 0;
                            DataTable dataTable = ishopNum1_Cart_Action_0.SearchShopByMemLoginID(MemloginID, ProductGuids1);
                            string SuperiorRankGuid = "";
                            DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                            string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                            if (TJMemberNO != null && TJMemberNO != "")
                            {

                                String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());

                                DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                                SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                            }
                            ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                            shopNum1_OrderInfo.MemLoginID = MemloginID;
                            if (SuperiorRankGuid == "")
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                            }
                            else
                            {
                                shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                            }
                            shopNum1_OrderInfo.TradeID = orderid;
                            shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                            shopNum1_OrderInfo.OderStatus = 0;


                            shopNum1_OrderInfo.ShipmentStatus = 0;
                            shopNum1_OrderInfo.PaymentStatus = 0;
                            shopNum1_OrderInfo.OrderType = 0;
                            shopNum1_OrderInfo.PayMentMemLoginID = MemloginID;
                            shopNum1_OrderInfo.IsMinus = 0;
                            DataTable Addresstable = shopNum1_Address_Action.Search(AddressGuid);
                            try
                            {
                                int OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefault(AddressGuid);
                                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefaultAndTwo(AddressGuid, MemloginID);
                            }
                            catch (Exception)
                            {


                            }
                            if (Addresstable.Rows.Count > 0)
                            {

                                shopNum1_OrderInfo.Name = Addresstable.Rows[0]["Name"].ToString();
                                shopNum1_OrderInfo.Email = Addresstable.Rows[0]["Email"].ToString();
                                shopNum1_OrderInfo.Address = Addresstable.Rows[0]["AddressValue"].ToString() + Addresstable.Rows[0]["Address"].ToString();
                                shopNum1_OrderInfo.Postalcode = Addresstable.Rows[0]["Postalcode"].ToString();
                                shopNum1_OrderInfo.Tel = Addresstable.Rows[0]["Tel"].ToString();
                                shopNum1_OrderInfo.Mobile = Addresstable.Rows[0]["Mobile"].ToString();
                                shopNum1_OrderInfo.RegionCode = Addresstable.Rows[0]["AddressCode"].ToString(); //拿不准的数据
                                tel = Addresstable.Rows[0]["Tel"].ToString();

                            }
                            else
                            {
                                return "6";
                            }
                            //支付方式（1=预存款支付，2=智付支付）
                            if (PayMentType == 1)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                                shopNum1_OrderInfo.PaymentName = "预存款支付";
                            }
                            else if (PayMentType == 2)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                                shopNum1_OrderInfo.PaymentName = "唐江智付快捷支付";
                            }
                            else if (PayMentType == 3)
                            {
                                shopNum1_OrderInfo.PaymentGuid = new Guid("EB24C8E6-2959-452F-9332-CAEEEDD510BA");
                                shopNum1_OrderInfo.PaymentName = "支付宝";
                            }
                            else
                            {
                                return "7";
                            }
                            shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                            shopNum1_OrderInfo.SellerToClientMsg = "";
                            shopNum1_OrderInfo.IsMemdelay = 0;
                            shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));

                            shopNum1_OrderInfo.InvoiceTitle = "";
                            shopNum1_OrderInfo.InvoiceContent = "";
                            shopNum1_OrderInfo.InvoiceType = InvoiceType;
                            shopNum1_OrderInfo.InvoiceTax = 0m;

                            shopNum1_OrderInfo.PaymentPrice = 0M;
                            shopNum1_OrderInfo.OutOfStockOperate = "";
                            shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.PackName = "";
                            shopNum1_OrderInfo.PackPrice = 0m;
                            shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BlessCardName = "";
                            shopNum1_OrderInfo.BlessCardPrice = 0m;
                            shopNum1_OrderInfo.BlessCardContent = "";
                            shopNum1_OrderInfo.AlreadPayPrice = 0m;
                            shopNum1_OrderInfo.SurplusPrice = 0m;
                            shopNum1_OrderInfo.UseScore = 0;
                            shopNum1_OrderInfo.ScorePrice = 0m;
                            shopNum1_OrderInfo.JoinActiveType = -1;
                            shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                            shopNum1_OrderInfo.FromUrl = string.Empty;
                            shopNum1_OrderInfo.PayTime = null;
                            shopNum1_OrderInfo.DispatchTime = null;
                            shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                            shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopNum1_OrderInfo.PayMemo = "";
                            shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                            shopNum1_OrderInfo.BuyType = "";
                            shopNum1_OrderInfo.Discount = 0m;
                            shopNum1_OrderInfo.Deposit = 0m;
                            shopNum1_OrderInfo.JoinActiveType = 0;
                            shopNum1_OrderInfo.ActvieContent = "";
                            shopNum1_OrderInfo.UsedFavourTicket = "";
                            shopNum1_OrderInfo.Guid = Guid.NewGuid();
                            shopNum1_OrderInfo.ShopID = ShopID;


                            string[] guid = ProductGuids1.Replace("'", "").Split(',');
                            for (int i = 0; i < guid.Length; i++)
                            {
                                Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

                                DataTable shopProductEdit = ishopNum1_Cart_Action_0.SearchShopByMemLoginID_Price(MemloginID, ShopCarGuids, guid[i], ShopCategoryID);

                                shopNum1_OrderInfo.score_pv_cv = 0.01M;
                                #region
                                //得到积分
                                //ShangPinPrice += Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) >= 0)
                                {
                                    shopNum1_OrderInfo.Score_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                }
                                //可用积分
                                if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) < 0)
                                {
                                    shopNum1_OrderInfo.score_reduce_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                }
                                //得到红包
                                if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"]) >= 0)
                                {
                                    shopNum1_OrderInfo.Score_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                }
                                //可用红包
                                if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) < 0)
                                {
                                    shopNum1_OrderInfo.score_reduce_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                }
                                #endregion
                                shopNum1_OrderInfo.Score_dv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                                shopNum1_OrderInfo.Score_pv_b += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);

                                shopNum1_OrderInfo.ShopName = shopProductEdit.Rows[0]["SellName"].ToString();

                            }
                            shopNum1_OrderInfo.shop_category_id = ShopCategoryID;



                            if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                            {
                                IsEmail(shopNum1_OrderInfo.Email, ShopID, shopNum1_OrderInfo.OrderNumber,
                                    MemloginID, shopNum1_OrderInfo.Tel, "", shopNum1_OrderInfo.Mobile);
                            }
                            if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                            {
                                string nameById = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                                    " and memloginId='" + ShopID + "'");
                                IsMMS(nameById, ShopID, MemloginID, shopNum1_OrderInfo.Tel,
                                    shopNum1_OrderInfo.OrderNumber, "", shopNum1_OrderInfo.Mobile);
                            }
                            string value2 = ShopSettings.GetValue("IsRecommendCommisionOpen");
                            if (value2 == "true")
                            {
                                ShopSettings.GetValue("RecommendCommision");
                                double num3 = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                                shopNum1_OrderInfo.RecommendCommision =
                                    Convert.ToDecimal(Convert.ToDouble(ShangPinPrice) * num3);
                            }
                            else
                            {
                                shopNum1_OrderInfo.RecommendCommision = 0m;
                            }
                            shopNum1_OrderInfo.OrderNumber = shopNum1_OrderInfo.TradeID;
                            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice);
                            shopNum1_OrderInfo.ProductPv_b = shopNum1_OrderInfo.Score_pv_b;
                            if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent.ToUpper() != "C0000001")
                            {
                                shopNum1_OrderInfo.DispatchType = 0;
                                shopNum1_OrderInfo.FeeType = 1;
                                shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                                shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice;
                            }
                            else
                            {
                                if (QDSQPrice != null && QDSQPrice != 0)
                                {
                                    shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                                    shopNum1_OrderInfo.DispatchType = 0;
                                    shopNum1_OrderInfo.FeeType = 1;
                                    shopNum1_OrderInfo.DispatchPrice = 0;
                                }
                                else if (Convert.ToDecimal(PostPriceGZ) == 0 && ShopCategoryID == 2)
                                {
                                    shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + Convert.ToDecimal(PostPriceGZ);
                                    shopNum1_OrderInfo.DispatchType = 0;
                                    shopNum1_OrderInfo.FeeType = 1;
                                    shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);

                                }
                                else
                                {
                                    shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + Convert.ToDecimal(PostPriceGZ);
                                    shopNum1_OrderInfo.DispatchType = 0;
                                    shopNum1_OrderInfo.FeeType = 1;
                                    shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);
                                }
                            }
                            list.Add(shopNum1_OrderInfo);

                            DataTable dataTable3 = new DataTable();
                            dataTable3 = ishopNum1_Cart_Action_0.SearchByMemLoginIDAndShopID(MemloginID, ShopID);
                            for (int i = 0; i < dataTable3.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dataTable3.Rows[i]["shop_category_id"]) == shopNum1_OrderInfo.shop_category_id)
                                {
                                    list2.Add(new ShopNum1_OrderProduct
                                    {
                                        ProductImg = dataTable3.Rows[i]["originalimge"].ToString(),
                                        OrderType = Convert.ToInt32(dataTable3.Rows[i]["carttype"].ToString()),
                                        Guid = Guid.NewGuid(),
                                        OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString(),
                                        ProductGuid = dataTable3.Rows[i]["ProductGuid"].ToString(),
                                        GroupPrice = Convert.ToDecimal("0.00"),
                                        SpecificationName = dataTable3.Rows[i]["SpecificationName"].ToString(),
                                        SpecificationValue = dataTable3.Rows[i]["SpecificationValue"].ToString(),
                                        setStock = dataTable3.Rows[i]["Attributes"].ToString(),
                                        ProductName = dataTable3.Rows[i]["Name"].ToString(),
                                        RepertoryNumber = dataTable3.Rows[i]["RepertoryNumber"].ToString(),
                                        BuyNumber = Convert.ToInt32(dataTable3.Rows[i]["BuyNumber"].ToString()),
                                        MarketPrice = Convert.ToDecimal(dataTable3.Rows[i]["MarketPrice"].ToString()),
                                        ShopPrice = Convert.ToDecimal(dataTable3.Rows[i]["ShopPrice"].ToString()),
                                        BuyPrice = Convert.ToDecimal(dataTable3.Rows[i]["BuyPrice"].ToString()),
                                        Attributes = dataTable3.Rows[i]["Attributes"].ToString(),
                                        IsShipment = Convert.ToInt32(dataTable3.Rows[i]["IsShipment"].ToString()),
                                        IsReal = Convert.ToInt32(dataTable3.Rows[i]["IsReal"].ToString()),
                                        ExtensionAttriutes = dataTable3.Rows[i]["ExtensionAttriutes"].ToString(),
                                        IsJoinActivity = Convert.ToInt32(dataTable3.Rows[i]["IsJoinActivity"].ToString()),
                                        CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                        DetailedSpecifications = dataTable3.Rows[i]["DetailedSpecifications"].ToString(),
                                        MemLoginID = MemloginID,
                                        ShopID = dataTable3.Rows[i]["ShopID"].ToString(),
                                        shop_category_id = Convert.ToInt32(dataTable3.Rows[i]["shop_category_id"]),
                                        Size = dataTable3.Rows[i]["Size"].ToString(),
                                        Color = dataTable3.Rows[i]["Color"].ToString()

                                    });
                                }
                            }
                            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action =
              (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                            int num4 = shopNum1_OrderInfo_Action.Add(list, list2);
                            if (num4 > 0)
                            {


                                int num5 = ishopNum1_Cart_Action_0.DeleteByMemLoginID(MemloginID);


                                if (num5 > 0)
                                {
                                }
                                ShopNum1_Member_Action shopNum1_Member_Action =
                                    (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                                DataTable memberInfoByMemLoginID =
                                    shopNum1_Member_Action.GetMemberInfoByMemLoginID(MemloginID);
                                if (memberInfoByMemLoginID.Rows.Count > 0)
                                {
                                    if (ShopSettings.GetValue("OrderIsEmail") == "1")
                                    {
                                        IsEmail(orderid.ToString(), MemloginID,
                                            memberInfoByMemLoginID.Rows[0]["email"].ToString());
                                    }
                                    if (ShopSettings.GetValue("SubmitOrderIsMMS") == "1")
                                    {
                                        IsMMS(orderid.ToString(), MemloginID, tel);
                                    }
                                }
                                return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + orderid.ToString() + "," + shopNum1_OrderInfo.Guid;

                            }

                            return "1";






                            #endregion
                            
                        }





                        #endregion
                    }
                    else 
                    {
                        return "222";
                    }
                }
                else
                {
                    return "2";
                }
            }
            else
            {
                ServiceAgent = "C0000001";
                #region
                if (PayMentType == null || PayMentType == 0)
                {
                    return "3";
                }
                else
                {

                    #region 创建购物车订单
                    string tel;
                    var list = new List<ShopNum1_OrderInfo>();
                    var list2 = new List<ShopNum1_OrderProduct>();
                    IShopNum1_Address_Action shopNum1_Address_Action = LogicFactory.CreateShopNum1_Address_Action();

                    Order order = new Order();
                    string orderid = "SJ" + order.CreateOrderNumber();
                    int num = 0;
                    DataTable dataTable = ishopNum1_Cart_Action_0.SearchShopByMemLoginID(MemloginID, ProductGuids1);
                    string SuperiorRankGuid = "";
                    DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
                    string TJMemberNO = tableTJ.Rows[0]["Superior"].ToString();
                    if (TJMemberNO != null && TJMemberNO != "")
                    {

                        String TJGuid2 = member_Action.GetGuidByMemLoginNO(tableTJ.Rows[0]["Superior"].ToString());

                        DataTable tableTJRank = member_Action.SearchMemberGuid(TJGuid2);
                        SuperiorRankGuid = tableTJRank.Rows[0]["MemberRankGuid"].ToString().ToUpper();
                    }
                    ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
                    shopNum1_OrderInfo.MemLoginID = MemloginID;
                    if (SuperiorRankGuid == "")
                    {
                        shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");
                    }
                    else
                    {
                        shopNum1_OrderInfo.SuperiorRank = new Guid(SuperiorRankGuid);
                    }
                    shopNum1_OrderInfo.TradeID = orderid;
                    shopNum1_OrderInfo.ServiceAgent = ServiceAgent;
                    shopNum1_OrderInfo.OderStatus = 0;


                    shopNum1_OrderInfo.ShipmentStatus = 0;
                    shopNum1_OrderInfo.PaymentStatus = 0;
                    shopNum1_OrderInfo.OrderType = 0;
                    shopNum1_OrderInfo.PayMentMemLoginID = MemloginID;
                    shopNum1_OrderInfo.IsMinus = 0;
                    DataTable Addresstable = shopNum1_Address_Action.Search(AddressGuid);
                    try
                    {
                        int OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefault(AddressGuid);
                        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefaultAndTwo(AddressGuid, MemloginID);
                    }
                    catch (Exception)
                    {


                    }
                    if (Addresstable.Rows.Count > 0)
                    {

                        shopNum1_OrderInfo.Name = Addresstable.Rows[0]["Name"].ToString();
                        shopNum1_OrderInfo.Email = Addresstable.Rows[0]["Email"].ToString();
                        shopNum1_OrderInfo.Address = Addresstable.Rows[0]["AddressValue"].ToString() + Addresstable.Rows[0]["Address"].ToString();
                        shopNum1_OrderInfo.Postalcode = Addresstable.Rows[0]["Postalcode"].ToString();
                        shopNum1_OrderInfo.Tel = Addresstable.Rows[0]["Tel"].ToString();
                        shopNum1_OrderInfo.Mobile = Addresstable.Rows[0]["Mobile"].ToString();
                        shopNum1_OrderInfo.RegionCode = Addresstable.Rows[0]["AddressCode"].ToString(); //拿不准的数据
                        tel = Addresstable.Rows[0]["Tel"].ToString();

                    }
                    else
                    {
                        return "6";
                    }
                    //支付方式（1=预存款支付，2=智付支付）
                    if (PayMentType == 1)
                    {
                        shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                        shopNum1_OrderInfo.PaymentName = "预存款支付";
                    }
                    else if (PayMentType == 2)
                    {
                        shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                        shopNum1_OrderInfo.PaymentName = "唐江智付快捷支付";
                    }
                    else if (PayMentType == 3)
                    {
                        shopNum1_OrderInfo.PaymentGuid = new Guid("EB24C8E6-2959-452F-9332-CAEEEDD510BA");
                        shopNum1_OrderInfo.PaymentName = "支付宝";
                    }
                    else
                    {
                        return "7";
                    }
                    shopNum1_OrderInfo.ClientToSellerMsg = TextBoxMessage;
                    shopNum1_OrderInfo.SellerToClientMsg = "";
                    shopNum1_OrderInfo.IsMemdelay = 0;
                    shopNum1_OrderInfo.ReceivedDays = int.Parse(ShopSettings.GetValue("DefaultReceivedDays"));

                    shopNum1_OrderInfo.InvoiceTitle = "";
                    shopNum1_OrderInfo.InvoiceContent = "";
                    shopNum1_OrderInfo.InvoiceType = InvoiceType;
                    shopNum1_OrderInfo.InvoiceTax = 0m;

                    shopNum1_OrderInfo.PaymentPrice = 0M;
                    shopNum1_OrderInfo.OutOfStockOperate = "";
                    shopNum1_OrderInfo.PackGuid = Guid.NewGuid();
                    shopNum1_OrderInfo.PackName = "";
                    shopNum1_OrderInfo.PackPrice = 0m;
                    shopNum1_OrderInfo.BlessCardGuid = Guid.NewGuid();
                    shopNum1_OrderInfo.BlessCardName = "";
                    shopNum1_OrderInfo.BlessCardPrice = 0m;
                    shopNum1_OrderInfo.BlessCardContent = "";
                    shopNum1_OrderInfo.AlreadPayPrice = 0m;
                    shopNum1_OrderInfo.SurplusPrice = 0m;
                    shopNum1_OrderInfo.UseScore = 0;
                    shopNum1_OrderInfo.ScorePrice = 0m;
                    shopNum1_OrderInfo.JoinActiveType = -1;
                    shopNum1_OrderInfo.FromAd = Guid.NewGuid();
                    shopNum1_OrderInfo.FromUrl = string.Empty;
                    shopNum1_OrderInfo.PayTime = null;
                    shopNum1_OrderInfo.DispatchTime = null;
                    shopNum1_OrderInfo.ShipmentNumber = string.Empty;
                    shopNum1_OrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_OrderInfo.ConfirmTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_OrderInfo.PayMemo = "";
                    shopNum1_OrderInfo.ActivityGuid = Guid.NewGuid();
                    shopNum1_OrderInfo.BuyType = "";
                    shopNum1_OrderInfo.Discount = 0m;
                    shopNum1_OrderInfo.Deposit = 0m;
                    shopNum1_OrderInfo.JoinActiveType = 0;
                    shopNum1_OrderInfo.ActvieContent = "";
                    shopNum1_OrderInfo.UsedFavourTicket = "";
                    shopNum1_OrderInfo.Guid = Guid.NewGuid();
                    shopNum1_OrderInfo.ShopID = ShopID;


                    string[] guid = ProductGuids1.Replace("'", "").Split(',');
                    for (int i = 0; i < guid.Length; i++)
                    {
                        Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

                        DataTable shopProductEdit = ishopNum1_Cart_Action_0.SearchShopByMemLoginID_Price(MemloginID, ShopCarGuids, guid[i], ShopCategoryID);

                        shopNum1_OrderInfo.score_pv_cv = 0.01M;
                        #region
                        //得到积分
                        //ShangPinPrice += Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                        if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) >= 0)
                        {
                            shopNum1_OrderInfo.Score_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                        }
                        //可用积分
                        if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) < 0)
                        {
                            shopNum1_OrderInfo.score_reduce_pv_a += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_a"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                        }
                        //得到红包
                        if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"]) >= 0)
                        {
                            shopNum1_OrderInfo.Score_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_hv"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                        }
                        //可用红包
                        if (Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) < 0)
                        {
                            shopNum1_OrderInfo.score_reduce_hv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_max_hv"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                        }
                        #endregion
                        shopNum1_OrderInfo.Score_dv += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);
                        shopNum1_OrderInfo.Score_pv_b += Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]) * Convert.ToDecimal(shopProductEdit.Rows[0]["BuyNumber"]);

                        shopNum1_OrderInfo.ShopName = shopProductEdit.Rows[0]["SellName"].ToString();

                    }
                    shopNum1_OrderInfo.shop_category_id = ShopCategoryID;



                    if (ShopSettings.GetValue("OrderToShopIsEmail") == "1")
                    {
                        IsEmail(shopNum1_OrderInfo.Email, ShopID, shopNum1_OrderInfo.OrderNumber,
                            MemloginID, shopNum1_OrderInfo.Tel, "", shopNum1_OrderInfo.Mobile);
                    }
                    if (ShopSettings.GetValue("OrderToShopIsMMS") == "1")
                    {
                        string nameById = Common.Common.GetNameById("Mobile", "ShopNum1_Member",
                            " and memloginId='" + ShopID + "'");
                        IsMMS(nameById, ShopID, MemloginID, shopNum1_OrderInfo.Tel,
                            shopNum1_OrderInfo.OrderNumber, "", shopNum1_OrderInfo.Mobile);
                    }
                    string value2 = ShopSettings.GetValue("IsRecommendCommisionOpen");
                    if (value2 == "true")
                    {
                        ShopSettings.GetValue("RecommendCommision");
                        double num3 = Convert.ToDouble(ShopSettings.GetValue("RecommendCommision")) / 100.0;
                        shopNum1_OrderInfo.RecommendCommision =
                            Convert.ToDecimal(Convert.ToDouble(ShangPinPrice) * num3);
                    }
                    else
                    {
                        shopNum1_OrderInfo.RecommendCommision = 0m;
                    }
                    shopNum1_OrderInfo.OrderNumber = shopNum1_OrderInfo.TradeID;
                    shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice);
                    shopNum1_OrderInfo.ProductPv_b = shopNum1_OrderInfo.Score_pv_b;
                    if (shopNum1_OrderInfo.ServiceAgent != "" && shopNum1_OrderInfo.ServiceAgent.ToUpper() != "C0000001")
                    {
                        shopNum1_OrderInfo.DispatchType = 0;
                        shopNum1_OrderInfo.FeeType = 1;
                        shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
                        shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice;
                    }
                    else
                    {
                        if (QDSQPrice != null && QDSQPrice != 0)
                        {
                            shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                            shopNum1_OrderInfo.DispatchType = 0;
                            shopNum1_OrderInfo.FeeType = 1;
                            shopNum1_OrderInfo.DispatchPrice = 0;
                        }
                        else if (Convert.ToDecimal(PostPriceGZ) == 0 && ShopCategoryID == 2)
                        {
                            shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + Convert.ToDecimal(PostPriceGZ);
                            shopNum1_OrderInfo.DispatchType = 0;
                            shopNum1_OrderInfo.FeeType = 1;
                            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);

                        }
                        else
                        {
                            shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice + Convert.ToDecimal(PostPriceGZ);
                            shopNum1_OrderInfo.DispatchType = 0;
                            shopNum1_OrderInfo.FeeType = 1;
                            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(PostPriceGZ);
                        }
                    }
                    list.Add(shopNum1_OrderInfo);

                    DataTable dataTable3 = new DataTable();
                    dataTable3 = ishopNum1_Cart_Action_0.SearchByMemLoginIDAndShopID(MemloginID, ShopID);
                    for (int i = 0; i < dataTable3.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dataTable3.Rows[i]["shop_category_id"]) == shopNum1_OrderInfo.shop_category_id)
                        {
                            list2.Add(new ShopNum1_OrderProduct
                            {
                                ProductImg = dataTable3.Rows[i]["originalimge"].ToString(),
                                OrderType = Convert.ToInt32(dataTable3.Rows[i]["carttype"].ToString()),
                                Guid = Guid.NewGuid(),
                                OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString(),
                                ProductGuid = dataTable3.Rows[i]["ProductGuid"].ToString(),
                                GroupPrice = Convert.ToDecimal("0.00"),
                                SpecificationName = dataTable3.Rows[i]["SpecificationName"].ToString(),
                                SpecificationValue = dataTable3.Rows[i]["SpecificationValue"].ToString(),
                                setStock = dataTable3.Rows[i]["Attributes"].ToString(),
                                ProductName = dataTable3.Rows[i]["Name"].ToString(),
                                RepertoryNumber = dataTable3.Rows[i]["RepertoryNumber"].ToString(),
                                BuyNumber = Convert.ToInt32(dataTable3.Rows[i]["BuyNumber"].ToString()),
                                MarketPrice = Convert.ToDecimal(dataTable3.Rows[i]["MarketPrice"].ToString()),
                                ShopPrice = Convert.ToDecimal(dataTable3.Rows[i]["ShopPrice"].ToString()),
                                BuyPrice = Convert.ToDecimal(dataTable3.Rows[i]["BuyPrice"].ToString()),
                                Attributes = dataTable3.Rows[i]["Attributes"].ToString(),
                                IsShipment = Convert.ToInt32(dataTable3.Rows[i]["IsShipment"].ToString()),
                                IsReal = Convert.ToInt32(dataTable3.Rows[i]["IsReal"].ToString()),
                                ExtensionAttriutes = dataTable3.Rows[i]["ExtensionAttriutes"].ToString(),
                                IsJoinActivity = Convert.ToInt32(dataTable3.Rows[i]["IsJoinActivity"].ToString()),
                                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                DetailedSpecifications = dataTable3.Rows[i]["DetailedSpecifications"].ToString(),
                                MemLoginID = MemloginID,
                                ShopID = dataTable3.Rows[i]["ShopID"].ToString(),
                                shop_category_id = Convert.ToInt32(dataTable3.Rows[i]["shop_category_id"]),
                                Size = dataTable3.Rows[i]["Size"].ToString(),
                                Color = dataTable3.Rows[i]["Color"].ToString()

                            });
                        }
                    }
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action =
      (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    int num4 = shopNum1_OrderInfo_Action.Add(list, list2);
                    if (num4 > 0)
                    {


                        int num5 = ishopNum1_Cart_Action_0.DeleteByMemLoginID(MemloginID);


                        if (num5 > 0)
                        {
                        }
                        ShopNum1_Member_Action shopNum1_Member_Action =
                            (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        DataTable memberInfoByMemLoginID =
                            shopNum1_Member_Action.GetMemberInfoByMemLoginID(MemloginID);
                        if (memberInfoByMemLoginID.Rows.Count > 0)
                        {
                            if (ShopSettings.GetValue("OrderIsEmail") == "1")
                            {
                                IsEmail(orderid.ToString(), MemloginID,
                                    memberInfoByMemLoginID.Rows[0]["email"].ToString());
                            }
                            if (ShopSettings.GetValue("SubmitOrderIsMMS") == "1")
                            {
                                IsMMS(orderid.ToString(), MemloginID, tel);
                            }
                        }
                        return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + orderid.ToString() + "," + shopNum1_OrderInfo.Guid;

                    }

                    return "1";






                    #endregion
                    
                }





                #endregion
            }






        }



        //充值
        public string MobileServiceRecharge(string MemloginID, decimal RechargeBV, int RechargeType, string UserName, string BankCard, int BankCardType)
        {
            //RechargeType          充值方式（1=线下支付，2=智付支付）
            //BankCardType          线下充值卡号（1=招行卡，2=农行卡）
            //MemloginID              充值用户
            //RechargeBV             充值金额
            //UserName                充值用户名
            //BankCard                充值卡号
            if (RechargeBV > 0)
            {
                ShopNum1_Member_Action memberaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                DataTable meminfo = memberaction.GetMemInfo(MemloginID);
                decimal meminfoBV = Convert.ToDecimal(meminfo.Rows[0]["AdvancePayment"].ToString());

                var advancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog
                {
                    Guid = System.Guid.NewGuid(),
                    OperateType = "1",//充值
                    CurrentAdvancePayment = meminfoBV,
                    OperateMoney = Convert.ToDecimal(RechargeBV),
                    OperateStatus = 0,
                    Date = DateTime.Now



                };
                if (RechargeType == 1)
                {
                    DataTable table = memberaction.SearchMembertwo(MemloginID);
                    //20号开启
                    if (table.Rows[0]["MemberRankGuid"].ToString().ToUpper().Trim() != "49844669-3893-413E-951E-77B2EBE4FE28")
                    {
                        return "6";
                    }
                    else
                    {
                        advancePaymentApplyLog.UserName = UserName;
                        advancePaymentApplyLog.BankCard = BankCard;
                        advancePaymentApplyLog.PaymentGuid = new Guid("1E7CC2D2-130E-4E62-9BE9-AA07F727ED4C");
                        advancePaymentApplyLog.PaymentName = "线下支付";
                        if (BankCardType == 1)
                        {
                            advancePaymentApplyLog.GetBamkCard = "重庆唐江电子商务有限公司（农行帐号：31070101040010424）中国农业银行重庆九龙坡支行营业部";
                        }
                        else if (BankCardType == 2)
                        {
                            advancePaymentApplyLog.GetBamkCard = "重庆唐江电子商务有限公司（农行帐号：31021101040007537）重庆市袁家岗支行";
                        }
                        else
                        {
                            return "1";
                        }
                    }
                }
                else if (RechargeType == 2)
                {
                    advancePaymentApplyLog.UserName = "其它支付方式支付无充值人姓名";
                    advancePaymentApplyLog.GetBamkCard = "其它支付方式支付";
                    advancePaymentApplyLog.BankCard = "其它支付方式支付无充值卡号";
                    advancePaymentApplyLog.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                    advancePaymentApplyLog.PaymentName = "唐江智付快捷支付";
                }
                else if (RechargeType == 3)
                {
                    advancePaymentApplyLog.UserName = "其它支付方式支付无充值人姓名";
                    advancePaymentApplyLog.GetBamkCard = "其它支付方式支付";
                    advancePaymentApplyLog.BankCard = "其它支付方式支付无充值卡号";
                    advancePaymentApplyLog.PaymentGuid = new Guid("EB24C8E6-2959-452F-9332-CAEEEDD510BA");
                    advancePaymentApplyLog.PaymentName = "支付宝";
                }
                else
                {
                    return "2";
                }
                string str2 = "C" + new Order().CreateOrderNumber();
                advancePaymentApplyLog.OrderNumber = str2;
                advancePaymentApplyLog.MemLoginID = MemloginID;
                advancePaymentApplyLog.Memo = "";
                advancePaymentApplyLog.UserMemo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                advancePaymentApplyLog.IsDeleted = 0;
                advancePaymentApplyLog.OrderStatus = 0;
                string str3 = GetID().ToString();
                advancePaymentApplyLog.ID = Convert.ToInt32(str3);



                ShopNum1_AdvancePaymentApplyLog_Action action =
                         (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                if (action.ApplyOperateMoney(advancePaymentApplyLog) > 0)
                {


                    #region 智付支付
                    string Merchant_code = "2000808866";
                    string Notify_url = ShopSettings.dinpaynotifr;
                    string Interface_version = "V3.0";
                    string Order_no = advancePaymentApplyLog.OrderNumber;
                    string Order_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string Order_amount = advancePaymentApplyLog.OperateMoney.ToString().Trim();
                    string Product_name = advancePaymentApplyLog.OrderNumber;
                    string Extra_return_param = "";
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

                    #endregion
                    #region 支付宝

                    //商品标题
                    string subject = "tjbb";
                    //订单编号
                    string out_trade_no = advancePaymentApplyLog.OrderNumber;
                    //订单金额
                    string total_amount = advancePaymentApplyLog.OperateMoney.ToString().Trim();
                    //商家产品码
                    string product_code = "QUICK_MSECURITY_PAY";
                    //↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑以上为业务参数↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

                    string appID = "";
                    //ShopSettings.MobilePayAppID;
                    //接口名称
                    string method = "alipay.trade.app.pay";
                    //请求编码
                    string charset = "utf-8";
                    //签名类型
                    string sign_type = "RSA2";
                    //签名
                    string Alipaysign = "";
                    //请求时间
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //接口版本
                    string version = "1.0";
                    //返回处理地址
                    string notify_url = "";
                    //"http://" + ShopSettings.siteDomain +ConfigurationManager.AppSettings["AlipayMobile"];
                    //string notify_url = "http://"+"test3.tj88.com/PayReturn/Alipay/AlipayMobileApp.aspx";
                    //业务请求集合
                    string biz_content = "";
                    //b备注
                    string body = "";
                    //私匙
                    string app_private_key = "";
                    //ConfigurationManager.AppSettings["MobilePayAppKey"];
                    //公匙
                    //string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA6hRjQernZWL3DSMLbD58XP+68s+1FAWRZTzPPDolcGzB3At76i7CBHehZVmD4KMbCDkbueyu9bjuYfl1FcWV9bovxyHWYuxlx12r/4mtBVWZV/Xey4OJjOoeVevk22MjhQhYJejWs9rI4ZLSw+hQlpEDL59AWYYy65dkg83pDHhDGXZsOKZNHeEkiwbbjv8dYKjQokY4hevdwFORsHJsvMVk55JWckv0uCqMa/flF9BtJJkUUYkW3cjTDEsOySzXV2TZZO5z4b4JzuFUQ50oy9c0CaQM3OD6cGuFWT8qMmTltW/E/BcVXTSMRkLE0AS0sw/DNZkEn9wim/OrhloeOQIDAQAB";

                    biz_content = "{\"timeout_express\":\"30m\",\"product_code\":\"" + product_code + "\",\"total_amount\":\"" + total_amount + "\",\"subject\":\"" + subject + "\",\"body\":\"" + body + "\",\"out_trade_no\":\"" + out_trade_no + "\"}";
                    string BMbiz_content = System.Web.HttpUtility.UrlEncode(biz_content, System.Text.Encoding.UTF8).Replace("%3a", "%3A").Replace("%2c", "%2C").Replace("%7d", "%7D").Replace("%2f", "%2F").Replace("%7b", "%7B");
                    string BMappID = System.Web.HttpUtility.UrlEncode(appID, System.Text.Encoding.UTF8).Replace("%3a", "%3A").Replace("%2c", "%2C").Replace("%7d", "%7D").Replace("%2f", "%2F").Replace("%7b", "%7B");
                    string BMcharset = System.Web.HttpUtility.UrlEncode(charset, System.Text.Encoding.UTF8).Replace("%3a", "%3A").Replace("%2c", "%2C").Replace("%7d", "%7D").Replace("%2f", "%2F").Replace("%7b", "%7B");
                    string BMmethod = System.Web.HttpUtility.UrlEncode(method, System.Text.Encoding.UTF8).Replace("%3a", "%3A").Replace("%2c", "%2C").Replace("%7d", "%7D").Replace("%2f", "%2F").Replace("%7b", "%7B");
                    string BMnotify_url = System.Web.HttpUtility.UrlEncode(notify_url, System.Text.Encoding.UTF8).Replace("%3a", "%3A").Replace("%2c", "%2C").Replace("%7d", "%7D").Replace("%2f", "%2F").Replace("%7b", "%7B");
                    string BMsign_type = System.Web.HttpUtility.UrlEncode(sign_type, System.Text.Encoding.UTF8).Replace("%3a", "%3A").Replace("%2c", "%2C").Replace("%7d", "%7D").Replace("%2f", "%2F").Replace("%7b", "%7B");
                    string BMtimestamp = System.Web.HttpUtility.UrlEncode(timestamp, System.Text.Encoding.UTF8).Replace("%3a", "%3A").Replace("%2c", "%2C").Replace("%7d", "%7D").Replace("%2f", "%2F").Replace("%7b", "%7B");
                    string BMversion = System.Web.HttpUtility.UrlEncode(version, System.Text.Encoding.UTF8).Replace("%3a", "%3A").Replace("%2c", "%2C").Replace("%7d", "%7D").Replace("%2f", "%2F").Replace("%7b", "%7B");

                    string AlipayString2 = "app_id=" + appID + "&biz_content=" + biz_content + "&charset=" + charset + "&method=" + method + "&notify_url=" + notify_url + "&sign_type=" + sign_type + "&timestamp=" + timestamp + "&version=" + version;

                    string AlipayString = "app_id=" + BMappID + "&biz_content=" + BMbiz_content + "&charset=" + BMcharset + "&method=" + BMmethod + "&notify_url=" + BMnotify_url + "&sign_type=" + BMsign_type + "&timestamp=" + BMtimestamp + "&version=" + BMversion;
                    //Alipaysign = AlipaySignature.RSASign(AlipayString2, app_private_key, charset, sign_type, false);

                    //string BMAlipaysign = System.Web.HttpUtility.UrlEncode(Alipaysign, System.Text.Encoding.UTF8);

                    //string returnstring = AlipayString + "&sign=" + BMAlipaysign.Replace("%3d", "%3D").Replace("%2f", "%2F").Replace("%2b", "%2B");
                    string returnstring = "无法使用";
                    //string xx = System.Web.HttpUtility.UrlEncode(returnstring, System.Text.Encoding.UTF8);

                    #endregion

                    if (advancePaymentApplyLog.PaymentName == "唐江智付快捷支付")
                    {

                        return xml;
                    }
                    else if (advancePaymentApplyLog.PaymentName == "支付宝")
                    {
                        return "支付宝" + returnstring;
                    }
                    else
                    {

                        return "4";
                    }
                }


                return "3";

            }

            return "5";


        }





        //手机APP邮费接口
        public PostPrice PostPrice(string ShopID)
        {

            PostPrice post = new PostPrice();


            ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
            DataTable table = PostageAction.SelectPrice(ShopID);
            post.FirstHeavyPrice = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
            post.AfterHeavyPrice = Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]);
            post.FirstHeavy = Convert.ToDecimal(table.Rows[0]["FirstHeavy"]);

            return post;
        }
        //手机APP购物车邮费接口
        public string PostPriceCar(string ShopID, int ShopCategoryID, string ProductGuids, string MemloginID)
        {
            PostPrice post = new PostPrice();

            IShopNum1_Cart_Action ishopNum1_Cart_Action_0 = LogicFactory.CreateShopNum1_Cart_Action();

            DataTable productInfoByCartProductGuid =
                 ishopNum1_Cart_Action_0.GetProductInfoByProductGuids(MemloginID, ShopID, ProductGuids);
            int num = 0;
            decimal MZPrice = Convert.ToDecimal(0.0);
            decimal num5 = Convert.ToDecimal(0.0);
            decimal Postage = Convert.ToDecimal(0.0);
            decimal HDFK = Convert.ToDecimal(1.1);
            decimal VIPYF = Convert.ToDecimal(1.2);
            decimal MYPostage = Convert.ToDecimal(0.0);
            decimal WLPostage = Convert.ToDecimal(0.0);
            decimal VIPPostage = Convert.ToDecimal(0.0);
            string PostpriceReulst = "";
            for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
            {
                num5 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["GoodsWeight"].ToString()) * Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString());
                MZPrice += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["ShopPrice"].ToString()) * Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["BuyNumber"].ToString());
            }
            if (ShopCategoryID == 1 || ShopCategoryID == 2 || ShopCategoryID == 9)
            {
                ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
                DataTable table = PostageAction.SelectPrice(ShopID.Trim());
                if (num5 != 0 && (num5 < Convert.ToDecimal(table.Rows[0]["FirstHeavy"]) || num5 == Convert.ToDecimal(table.Rows[0]["FirstHeavy"])))
                {
                    Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                    num = 1;
                    MYPostage = Postage;

                    if (ShopCategoryID == 5 || ShopCategoryID == 7)
                    {

                        if (MZPrice > 5000)
                        {
                            Postage = 0;
                            num = 0;
                            MYPostage = Postage;
                        }
                        else
                        {
                            Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                            num = 1;
                            MYPostage = Postage;
                            HDFK = 0;
                            WLPostage = 0M;

                        }
                    }
                    if (ShopCategoryID == 2)
                    {
                        if (MZPrice >= 10000)
                        {
                            VIPPostage = 0;
                            num = 1;
                            Postage = 0;
                            VIPYF = 1;
                        }
                        else
                        {
                            VIPPostage = decimal.Multiply(MZPrice, (decimal)0.01);
                            if (VIPPostage < 10)
                            {
                                VIPPostage = 10M;
                            }
                            num = 1;
                            Postage = 0;
                            VIPYF = 0;
                        }
                    }
                    if (ShopCategoryID == 1)
                    {
                        num = 0;
                    }

                }
                else
                {
                    Postage = ((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                    num = 1;
                    MYPostage = Postage;
                    if (ShopCategoryID == 5 || ShopCategoryID == 7)
                    {

                        if (MZPrice > 5000)
                        {
                            Postage = 0;
                            num = 0;
                            MYPostage = Postage;
                        }
                        else
                        {
                            Postage = ((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                            num = 1;
                            MYPostage = Postage;
                            HDFK = 0;
                            WLPostage = 0M;


                        }
                    }
                    if (ShopCategoryID == 2)
                    {
                        if (MZPrice >= 10000)
                        {
                            VIPPostage = 0;
                            num = 1;
                            Postage = 0;
                            VIPYF = 1;
                        }
                        else
                        {
                            VIPPostage = decimal.Multiply(MZPrice, (decimal)0.01);
                            if (VIPPostage < 10)
                            {
                                VIPPostage = 10M;
                            }
                            num = 1;
                            Postage = 0;
                            VIPYF = 0;
                        }
                    }
                    if (ShopCategoryID == 1)
                    {
                        num = 0;
                    }

                }

            }

            if (num == 1)
            {



                if (Postage != 0m)
                {

                    return Postage.ToString();


                }
                if (HDFK == 0m)
                {

                    return HDFK.ToString();

                }
                if (VIPYF == 0m)
                {

                    return VIPPostage.ToString();

                }

            }


            return "0";




        }

        public string PostPriceDan(int ShopCategoryID, string ProductGuids, int BuyNumber, string MemloginID)
        {
            PostPrice post = new PostPrice();

            Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

            DataTable productInfoByCartProductGuid = shop_Product_Action.GetShopProductEdit(ProductGuids, ShopCategoryID);
            int num = 0;
            decimal MZPrice = Convert.ToDecimal(0.0);
            decimal num5 = Convert.ToDecimal(0.0);
            decimal Postage = Convert.ToDecimal(0.0);
            decimal HDFK = Convert.ToDecimal(1.1);
            decimal VIPYF = Convert.ToDecimal(1.2);
            decimal MYPostage = Convert.ToDecimal(0.0);
            decimal WLPostage = Convert.ToDecimal(0.0);
            decimal VIPPostage = Convert.ToDecimal(0.0);
            string PostpriceReulst = "";
            for (int i = 0; i < productInfoByCartProductGuid.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(productInfoByCartProductGuid.Rows[i]["GoodsWeight"].ToString()))
                {
                    num5 += Convert.ToDecimal(productInfoByCartProductGuid.Rows[i]["GoodsWeight"].ToString()) * Convert.ToDecimal(BuyNumber);
                }
            }
            if (ShopCategoryID == 1 || ShopCategoryID == 2 || ShopCategoryID == 9)
            {
                string memberid = productInfoByCartProductGuid.Rows[0]["MemLoginID"].ToString();
                ShopNum1_PostageSettings_Action PostageAction = (ShopNum1_PostageSettings_Action)LogicFactory.CreateShopNum1_PostageSettings_Action();
                DataTable table = PostageAction.SelectPrice(memberid.Trim());
                if (num5 != 0 && (num5 < Convert.ToDecimal(table.Rows[0]["FirstHeavy"]) || num5 == Convert.ToDecimal(table.Rows[0]["FirstHeavy"])))
                {
                    Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                    num = 1;
                    MYPostage = Postage;

                    if (ShopCategoryID == 5 || ShopCategoryID == 7)
                    {

                        if (Convert.ToDecimal(productInfoByCartProductGuid.Rows[0]["ShopPrice"]) * Convert.ToInt32(BuyNumber) > 5000)
                        {
                            Postage = 0;
                            num = 0;
                            MYPostage = Postage;
                        }
                        else
                        {
                            Postage = Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                            num = 1;
                            MYPostage = Postage;
                            HDFK = 0;
                            WLPostage = 0M;

                        }
                    }
                    if (ShopCategoryID == 2)
                    {
                        if (Convert.ToDecimal(productInfoByCartProductGuid.Rows[0]["ShopPrice"]) * Convert.ToInt32(BuyNumber) >= 10000)
                        {
                            VIPPostage = 0;
                            num = 1;
                            Postage = 0;
                            VIPYF = 1;
                        }
                        else
                        {
                            VIPPostage = decimal.Multiply(Convert.ToDecimal(productInfoByCartProductGuid.Rows[0]["ShopPrice"]) * Convert.ToInt32(BuyNumber), (decimal)0.01);
                            if (VIPPostage < 10)
                            {
                                VIPPostage = 10M;
                            }
                            num = 1;
                            Postage = 0;
                            VIPYF = 0;
                        }
                    }
                    if (ShopCategoryID == 1)
                    {
                        num = 0;
                    }

                }
                else
                {
                    Postage = ((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                    num = 1;
                    MYPostage = Postage;
                    if (ShopCategoryID == 5 || ShopCategoryID == 7)
                    {

                        if (Convert.ToDecimal(productInfoByCartProductGuid.Rows[0]["ShopPrice"]) * Convert.ToInt32(BuyNumber) > 5000)
                        {
                            Postage = 0;
                            num = 0;
                            MYPostage = Postage;
                        }
                        else
                        {
                            Postage = ((num5 - Convert.ToDecimal(table.Rows[0]["FirstHeavy"])) / 1000) * Convert.ToDecimal(table.Rows[0]["AfterHeavyPrice"]) + Convert.ToDecimal(table.Rows[0]["FirstHeavyPrice"]);
                            num = 1;
                            MYPostage = Postage;
                            HDFK = 0;
                            WLPostage = 0M;


                        }
                    }
                    if (ShopCategoryID == 2)
                    {
                        if (Convert.ToDecimal(productInfoByCartProductGuid.Rows[0]["ShopPrice"]) * Convert.ToInt32(BuyNumber) >= 10000)
                        {
                            VIPPostage = 0;
                            num = 1;
                            Postage = 0;
                            VIPYF = 1;
                        }
                        else
                        {
                            VIPPostage = decimal.Multiply(Convert.ToDecimal(productInfoByCartProductGuid.Rows[0]["ShopPrice"]) * Convert.ToInt32(BuyNumber), (decimal)0.01);
                            if (VIPPostage < 10)
                            {
                                VIPPostage = 10M;
                            }
                            num = 1;
                            Postage = 0;
                            VIPYF = 0;
                        }
                    }
                    if (ShopCategoryID == 1)
                    {
                        num = 0;
                    }

                }

            }

            if (num == 1)
            {



                if (Postage != 0m)
                {

                    return Postage.ToString();


                }
                if (HDFK == 0m)
                {

                    return HDFK.ToString();

                }
                if (VIPYF == 0m)
                {

                    return VIPPostage.ToString();

                }

            }


            return "0";




        }























        protected void IsEmail(string strEmail, string strName, string OrderNumber, string strMemloginId,
    string strHomeTel, string strProductName, string strMobile)
        {
            if (!string.IsNullOrEmpty(strEmail))
            {
                string value = ShopSettings.GetValue("Name");
                var orderInfo = new OrderInfo();
                string memLoginID = orderInfo.Name = strMemloginId;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = value;
                string text = string.Empty;
                string emailTitle = string.Empty;
                string text2 = "457f965d-f1cc-45cf-b4a5-ddbbd6b7fdc0";
                var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text = editInfo.Rows[0]["Remark"].ToString();
                    emailTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text = text.Replace("{$Name}", strName);
                text = text.Replace("{$OrderNumber}", OrderNumber);
                text = text.Replace("{$MemLoginId}", strMemloginId);
                text = text.Replace("{$UserTel}", strHomeTel);
                text = text.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                text = text.Replace("{$ShopName}", orderInfo.ShopName);
                text = text.Replace("{$ProductName}", strProductName);
                text = text.Replace("{$UserMobile}", strMobile);
                string emailBody = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                var sendEmail = new SendEmail();
                sendEmail.Emails(strEmail, memLoginID, emailTitle, text2, emailBody);
            }
        }


        protected void IsMMS(string strTel, string strName, string strMemLoginId, string strHomeTel,
                string strOrderNumber, string strProductName, string strMobile)
        {
            if (!string.IsNullOrEmpty(strTel))
            {
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo("190d25f8-a9e9-4162-b4e8-0a3954c83473", 0);
                if (editInfo.Rows.Count > 0)
                {
                    string text = editInfo.Rows[0]["Remark"].ToString();
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    text = text.Replace("{$Name}", strName);
                    text = text.Replace("{$OrderNumber}", strOrderNumber);
                    text = text.Replace("{$MemLoginId}", strMemLoginId);
                    text = text.Replace("{$UserTel}", strHomeTel);
                    text = text.Replace("{$SendTime}", DateTime.Now.ToString());
                    text = text.Replace("{$ProductName}", strProductName);
                    text = text.Replace("{$UserMobile}", strMobile);
                    var orderInfo = new OrderInfo();
                    var sMS = new SMS();
                    text = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                    string empty = string.Empty;
                    sMS.Send(strTel, text + "【唐江宝宝】", out empty);
                    if (empty.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(strMemLoginId, strMobile.Trim(), text, mMsTitle, 2,
                            "190d25f8-a9e9-4162-b4e8-0a3954c83473");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(strMemLoginId, strMobile.Trim(), text, mMsTitle, 0,
                            "190d25f8-a9e9-4162-b4e8-0a3954c83473");
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }
        protected void IsEmail(string guid, string OrderNumber)
        {
            var shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable orderInfoByGuid = shopNum1_OrderInfo_Action.GetOrderInfoByGuid(guid);
            if (orderInfoByGuid.Rows[0]["Email"] != null && !(orderInfoByGuid.Rows[0]["Email"].ToString() == ""))
            {
                string email = orderInfoByGuid.Rows[0]["Email"].ToString();
                string value = ShopSettings.GetValue("Name");
                var orderInfo = new OrderInfo();
                string text = orderInfo.Name = orderInfoByGuid.Rows[0]["MemLoginID"].ToString();
                orderInfo.OrderNumber = orderInfoByGuid.Rows[0]["OrderNumber"].ToString();
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = value;
                string text2 = string.Empty;
                string emailTitle = string.Empty;
                string text3 = "ce05437f-75a7-4ee2-8014-4bd992357e51";
                var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text3 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text2 = editInfo.Rows[0]["Remark"].ToString();
                    emailTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text2 = text2.Replace("{$Name}", text);
                text2 = text2.Replace("{$OrderNumber}", OrderNumber);
                text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
                text2 = text2.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string emailBody = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text2));
                var sendEmail = new SendEmail();
                sendEmail.Emails(email, text, emailTitle, text3, emailBody);
            }
        }
        protected void IsEmail(string OrderNumber, string MemLoginID, string email)
        {
            if (email != null && !(email == ""))
            {
                string value = ShopSettings.GetValue("Name");
                var orderInfo = new OrderInfo();
                orderInfo.Name = MemLoginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = value;
                string text = string.Empty;
                string emailTitle = string.Empty;
                string text2 = "ce05437f-75a7-4ee2-8014-4bd992357e51";
                var shopNum1_Email_Action = (ShopNum1_Email_Action)LogicFactory.CreateShopNum1_Email_Action();
                DataTable editInfo = shopNum1_Email_Action.GetEditInfo("'" + text2 + "'", 0);
                if (editInfo.Rows.Count > 0)
                {
                    text = editInfo.Rows[0]["Remark"].ToString();
                    emailTitle = editInfo.Rows[0]["Title"].ToString();
                }
                text = text.Replace("{$Name}", MemLoginID);
                text = text.Replace("{$OrderNumber}", OrderNumber);
                text = text.Replace("{$ShopName}", "唐江国际商城");
                text = text.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string emailBody = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text));
                var sendEmail = new SendEmail();
                sendEmail.Emails(email, MemLoginID, emailTitle, text2, emailBody);
            }
        }
        protected void IsMMS(string OrderNumber, string memloginID, string string_8)
        {
            if (!(string_8.Trim() == ""))
            {
                var orderInfo = new OrderInfo();
                orderInfo.Name = memloginID;
                orderInfo.OrderNumber = OrderNumber;
                orderInfo.SysSendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                orderInfo.ShopName = ShopSettings.GetValue("Name");
                string text = "ce05437f-75a7-4ee2-8014-4bd992357e51";
                IShopNum1_MMS_Action shopNum1_MMS_Action = LogicFactory.CreateShopNum1_MMS_Action();
                DataTable editInfo = shopNum1_MMS_Action.GetEditInfo(text, 0);
                if (editInfo != null && editInfo.Rows.Count > 0)
                {
                    string text2 = editInfo.Rows[0]["Remark"].ToString();
                    text2 = text2.Replace("{$Name}", orderInfo.Name);
                    text2 = text2.Replace("{$OrderNumber}", orderInfo.OrderNumber);
                    text2 = text2.Replace("{$ShopName}", orderInfo.ShopName);
                    text2 = text2.Replace("{$SendTime}", DateTime.Now.ToString("yyyy-MM-dd"));
                    string mMsTitle = editInfo.Rows[0]["Title"].ToString();
                    var sMS = new SMS();
                    string text3 = "";
                    text2 = orderInfo.ChangeOrderInfo(Page.Server.HtmlDecode(text2));
                    sMS.Send(string_8.Trim(), text2 + "【唐江宝宝】", out text3);
                    if (text3.IndexOf("发送成功") != -1)
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), text2, mMsTitle, 2,
                            text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                    else
                    {
                        ShopNum1_MMSGroupSend emailGroupSend = AddMMS(memloginID, string_8.Trim(), text2, mMsTitle, 0,
                            text);
                        shopNum1_MMS_Action.AddMMSGroupSend(emailGroupSend);
                    }
                }
            }
        }
        protected ShopNum1_MMSGroupSend AddMMS(string memLoginID, string mobile, string strContent, string MMsTitle,
    int state, string mmsGuid)
        {
            return new ShopNum1_MMSGroupSend
            {
                Guid = Guid.NewGuid(),
                MMSTitle = MMsTitle,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                MMSGuid = new Guid(mmsGuid),
                SendObjectMMS = strContent,
                SendObject = memLoginID + "-" + mobile,
                State = state
            };
        }






        private readonly IShopNum1_SpecProudctDetail_Action ishopNum1_SpecProudctDetail_Action_0 =
         LogicFactory.CreateShopNum1_SpecProudctDetail_Action();

        private readonly IShopNum1_SpecProudct_Action ishopNum1_SpecProudct_Action_0 =
            LogicFactory.CreateShopNum1_SpecProudct_Action();
        /// <summary>
        /// 充值的
        /// </summary>
        /// <returns></returns>
        protected int GetID()
        {
            string columnName = "ID";
            string tableName = "ShopNum1_AdvancePaymentApplyLog";
            return (1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName));
        }
        private readonly IShopNum1_Spec_Action ishopNum1_Spec_Action_0 = LogicFactory.CreateShopNum1_Spec_Action();

        //MyMemLoginID 买家ID
        //category  专区号

        //Num  购买数量
        //guid   商品GUID

        public string AddShopCar(string MyMemLoginID, string category, string Num, string guid, string Size, string Color)
        {


            string MemRankGuid = null;
            string MemLinkCategory = null;

            //判断是否登陆，若没有登陆取会员等级为普通用户的Guid

            string memberrankguid =
              ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberRankGuid(MyMemLoginID);
            MemRankGuid = memberrankguid;

            //根据会员等级的Guid以及可看属性获得专区板块ID字符串
            DataTable linkCategory = LogicFactory.CreateMemberRank_LinkCategory_Action().GetRankLinkCategoryByID(MemRankGuid, "2");

            DataTable product = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetAllShop_Product(guid, category);


            MemLinkCategory = linkCategory.Rows[0]["Category_ID"].ToString();
            if (!MemLinkCategory.Contains(category))
            {
                return "1";
            }
            else
            {
                if ("0a40df84-860a-4594-bed7-5717069f3456".ToUpper() == guid.ToUpper())
                {
                    return "9";
                }
                else
                {
                    var cd = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();

                    MemberLoginID = MyMemLoginID;

                    if (cd.SelectShopCar(MemberLoginID).Rows.Count > 0)
                    {
                        if (Convert.ToString(cd.SelectShopCar(MemberLoginID).Rows[0]["shop_category_id"]) != category.ToString())
                        {
                            return "2";
                        }
                        else if (product.Rows[0]["MemLoginID"].ToString() != Convert.ToString(cd.SelectShopCar(MemberLoginID).Rows[0]["ShopID"]))
                        {
                            return "3";
                        }

                        else
                        {



                            bool flag = false;
                            try
                            {
                                if (int.Parse(Num) > 0)
                                {
                                    flag = true;
                                }
                                else
                                {
                                    return "4";
                                }
                                if (int.Parse(product.Rows[0]["RepertoryCount"].ToString()) < int.Parse(Num))
                                {
                                    return "5";

                                }
                                if (product.Rows[0]["MemLoginID"].ToString() == MyMemLoginID)
                                {
                                    return "6";

                                }

                            }
                            catch (Exception)
                            {
                                return "4";
                            }
                            if (flag)
                            {
                                DataTable specificationByProduct;
                                decimal a;
                                decimal b;
                                decimal c;
                                decimal dee;
                                if (Convert.ToDecimal(product.Rows[0]["RepertoryCount"].ToString()) == 0)
                                {

                                    a = Convert.ToDecimal(product.Rows[0]["Score_max_hv"].ToString()) * (-1);
                                }
                                else
                                {

                                    a = Convert.ToDecimal(product.Rows[0]["Score_hv"].ToString());
                                }
                                if (Convert.ToDecimal(product.Rows[0]["Score_pv_a"].ToString()) == 0)
                                {
                                    b = Convert.ToDecimal(product.Rows[0]["Score_cv"].ToString()) * (-1);
                                }
                                else
                                {
                                    b = Convert.ToDecimal(product.Rows[0]["Score_pv_a"].ToString());
                                }
                                c = Convert.ToDecimal(product.Rows[0]["Score_dv"].ToString()) * (-1);
                                dee = Convert.ToDecimal(product.Rows[0]["Score_pv_cv"].ToString());
                                var shopcart = new ShopNum1_Shop_Cart
                                {
                                    Guid = Guid.NewGuid(),
                                    MemLoginID = MyMemLoginID,
                                    ProductGuid = new Guid(guid),
                                    OriginalImge = product.Rows[0]["OriginalImage"].ToString(),
                                    Name = product.Rows[0]["Name"].ToString(),
                                    RepertoryNumber = product.Rows[0]["ProductNum"].ToString(),
                                    BuyNumber = int.Parse(Num),
                                    MarketPrice = decimal.Parse(product.Rows[0]["MarketPrice"].ToString()),
                                    shop_category_id = Convert.ToInt32(category),
                                    Score_dv = c,
                                    Score_hv = a,
                                    Score_pv_a = b,
                                    Size = Size,
                                    Color = Color,
                                    Score_pv_cv = dee,
                                    Score_pv_b = Convert.ToDecimal(product.Rows[0]["Score_pv_b"].ToString()),
                                    GoodsWeight = Convert.ToDecimal(product.Rows[0]["GoodsWeight"].ToString())
                                };
                                string text = product.Rows[0]["ShopPrice"].ToString();
                                if (!string.IsNullOrEmpty(guid))
                                {
                                    specificationByProduct =
                                        ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(guid,
                                            guid.Replace(":", ",")
                                                .Replace(";", "|")
                                                .TrimEnd(new[] { ';' })
                                                .TrimEnd(new[] { '|' }));
                                    if (((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0)) &&
                                        (specificationByProduct.Rows[0]["GoodsPrice"].ToString() != ""))
                                    {
                                        text = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
                                    }
                                }
                                shopcart.ShopPrice = decimal.Parse(text);
                                shopcart.Attributes = product.Rows[0]["setStock"].ToString();
                                if (!string.IsNullOrEmpty(guid))
                                {
                                    specificationByProduct =
                                        ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(guid,
                                            guid.Replace(":", ",")
                                                .Replace(";", "|")
                                                .TrimEnd(new[] { ';' })
                                                .TrimEnd(new[] { '|' }));
                                    if ((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0))
                                    {
                                        shopcart.BuyPrice = Convert.ToDecimal(specificationByProduct.Rows[0]["GoodsPrice"].ToString());
                                    }
                                    else
                                    {
                                        shopcart.BuyPrice = decimal.Parse(product.Rows[0]["ShopPrice"].ToString());
                                    }
                                }
                                else
                                {
                                    shopcart.BuyPrice = decimal.Parse(product.Rows[0]["ShopPrice"].ToString());
                                }
                                if (false)
                                {
                                    if (product.Rows[0]["IsSaled"].ToString() == "1")
                                    {
                                        shopcart.BuyPrice = decimal.Parse(product.Rows[0]["groupprice"].ToString());
                                    }
                                    else if (product.Rows[0]["IsSaled"].ToString() == "2")
                                    {
                                        decimal d = Convert.ToDecimal(product.Rows[0]["ShopPrice"].ToString()) * Convert.ToDecimal(product.Rows[0]["discount"].ToString());
                                        shopcart.BuyPrice = Math.Round(d, 2);
                                    }
                                }
                                if ("11" == "抢 购 价：")
                                {

                                }
                                shopcart.IsShipment = 0;
                                shopcart.IsReal = int.Parse(product.Rows[0]["IsReal"].ToString());
                                shopcart.ExtensionAttriutes = "";
                                shopcart.IsJoinActivity = 0;
                                shopcart.CartType = Convert.ToInt32(product.Rows[0]["IsSaled"].ToString());
                                shopcart.IsPresent = 0;
                                shopcart.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                shopcart.DetailedSpecifications = "";
                                shopcart.ShopID = product.Rows[0]["MemLoginID"].ToString();
                                shopcart.SellName = product.Rows[0]["ShopName"].ToString();
                                shopcart.FeeType = int.Parse(product.Rows[0]["FeeType"].ToString());
                                shopcart.shop_category_id = Convert.ToInt32(category);
                                if (product.Rows[0]["setstock"].ToString().Length > 1)
                                {
                                    if (product.Rows[0]["setstock"].ToString().Trim(new[] { ';' }) != "0")
                                    {
                                        shopcart.SpecificationValue =
                                            product.Rows[0]["setstock"].ToString().Trim(new[] { ';' }).Replace(":", ",").Replace(";", "|");
                                    }
                                    //if (HiddenFieldSpecName.Value.Trim(new[] { ';' }) != "0")
                                    //{
                                    //shopcart.SpecificationName =
                                    //    HiddenFieldSpecName.Value.TrimEnd(new[] { ';' }).Replace("/", "-").TrimEnd(new[] { '0' });

                                    shopcart.SpecificationName = "";   //看不懂 随意定的
                                    //}
                                }
                                if (product.Rows[0]["FeeType"].ToString() == "1")
                                {
                                    shopcart.Post_fee = 0;
                                    shopcart.Ems_fee = 0;
                                    shopcart.Express_fee = 0;
                                }
                                else
                                {
                                    shopcart.Post_fee = decimal.Parse(product.Rows[0]["Post_fee"].ToString());
                                    shopcart.Ems_fee = decimal.Parse(product.Rows[0]["Ems_fee"].ToString());
                                    shopcart.Express_fee = decimal.Parse(product.Rows[0]["Express_fee"].ToString());
                                }
                                var action = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
                                int num = 0;
                                if (shopcart.SellName != "")
                                {
                                    num = action.AddCart(shopcart);
                                }
                                else
                                {
                                    num = 1;
                                }
                                if (num > 0)
                                {

                                    return "添加成功!";
                                }
                                else
                                {
                                    return "7";
                                }
                            }
                            else
                            {
                                return "8";
                            }
                        }
                    }
                    else
                    {


                        bool flag = false;
                        try
                        {
                            if (int.Parse(Num) > 0)
                            {
                                flag = true;
                            }
                            else
                            {
                                return "4";
                            }
                            if (int.Parse(product.Rows[0]["RepertoryCount"].ToString()) < int.Parse(Num))
                            {
                                return "5";

                            }
                            if (product.Rows[0]["MemLoginID"].ToString() == MyMemLoginID)
                            {
                                return "6";

                            }
                        }
                        catch (Exception)
                        {
                            return "4";
                        }
                        if (flag)
                        {
                            DataTable specificationByProduct;
                            decimal a;
                            decimal b;
                            decimal c;
                            decimal dee;
                            if (Convert.ToDecimal(product.Rows[0]["RepertoryCount"].ToString()) == 0)
                            {

                                a = Convert.ToDecimal(product.Rows[0]["Score_max_hv"].ToString()) * (-1);
                            }
                            else
                            {

                                a = Convert.ToDecimal(product.Rows[0]["Score_hv"].ToString());
                            }
                            if (Convert.ToDecimal(product.Rows[0]["Score_pv_a"].ToString()) == 0)
                            {
                                b = Convert.ToDecimal(product.Rows[0]["Score_cv"].ToString()) * (-1);
                            }
                            else
                            {
                                b = Convert.ToDecimal(product.Rows[0]["Score_pv_a"].ToString());
                            }
                            c = Convert.ToDecimal(product.Rows[0]["Score_dv"].ToString()) * (-1);
                            dee = Convert.ToDecimal(product.Rows[0]["Score_pv_cv"].ToString());
                            var shopcart = new ShopNum1_Shop_Cart
                            {
                                Guid = Guid.NewGuid(),
                                MemLoginID = MyMemLoginID,
                                ProductGuid = new Guid(guid),
                                OriginalImge = product.Rows[0]["OriginalImage"].ToString(),
                                Name = product.Rows[0]["Name"].ToString(),
                                RepertoryNumber = product.Rows[0]["ProductNum"].ToString(),
                                BuyNumber = int.Parse(Num),
                                MarketPrice = decimal.Parse(product.Rows[0]["MarketPrice"].ToString()),
                                shop_category_id = Convert.ToInt32(category),
                                Score_dv = c,
                                Score_hv = a,
                                Score_pv_a = b,
                                Size = Size,
                                Color = Color,
                                Score_pv_cv = dee,
                                Score_pv_b = Convert.ToDecimal(product.Rows[0]["Score_pv_b"].ToString()),
                                GoodsWeight = Convert.ToDecimal(product.Rows[0]["GoodsWeight"].ToString())
                            };
                            string text = product.Rows[0]["ShopPrice"].ToString();
                            if (!string.IsNullOrEmpty(guid))
                            {
                                specificationByProduct =
                                    ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(guid,
                                        guid.Replace(":", ",")
                                            .Replace(";", "|")
                                            .TrimEnd(new[] { ';' })
                                            .TrimEnd(new[] { '|' }));
                                if (((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0)) &&
                                    (specificationByProduct.Rows[0]["GoodsPrice"].ToString() != ""))
                                {
                                    text = specificationByProduct.Rows[0]["GoodsPrice"].ToString();
                                }
                            }
                            shopcart.ShopPrice = decimal.Parse(text);
                            shopcart.Attributes = product.Rows[0]["setStock"].ToString();
                            if (!string.IsNullOrEmpty(guid))
                            {
                                specificationByProduct =
                                    ishopNum1_SpecProudct_Action_0.GetSpecificationByProduct(guid,
                                        guid.Replace(":", ",")
                                            .Replace(";", "|")
                                            .TrimEnd(new[] { ';' })
                                            .TrimEnd(new[] { '|' }));
                                if ((specificationByProduct != null) && (specificationByProduct.Rows.Count > 0))
                                {
                                    shopcart.BuyPrice = Convert.ToDecimal(specificationByProduct.Rows[0]["GoodsPrice"].ToString());
                                }
                                else
                                {
                                    shopcart.BuyPrice = decimal.Parse(product.Rows[0]["ShopPrice"].ToString());
                                }
                            }
                            else
                            {
                                shopcart.BuyPrice = decimal.Parse(product.Rows[0]["ShopPrice"].ToString());
                            }
                            if (false)
                            {
                                if (product.Rows[0]["IsSaled"].ToString() == "1")
                                {
                                    shopcart.BuyPrice = decimal.Parse(product.Rows[0]["groupprice"].ToString());
                                }
                                else if (product.Rows[0]["IsSaled"].ToString() == "2")
                                {
                                    decimal d = Convert.ToDecimal(product.Rows[0]["ShopPrice"].ToString()) * Convert.ToDecimal(product.Rows[0]["discount"].ToString());
                                    shopcart.BuyPrice = Math.Round(d, 2);
                                }
                            }
                            if ("11" == "抢 购 价：")
                            {

                            }
                            shopcart.IsShipment = 0;
                            shopcart.IsReal = int.Parse(product.Rows[0]["IsReal"].ToString());
                            shopcart.ExtensionAttriutes = "";
                            shopcart.IsJoinActivity = 0;
                            shopcart.CartType = Convert.ToInt32(product.Rows[0]["IsSaled"].ToString());
                            shopcart.IsPresent = 0;
                            shopcart.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            shopcart.DetailedSpecifications = "";
                            shopcart.ShopID = product.Rows[0]["MemLoginID"].ToString();
                            shopcart.SellName = product.Rows[0]["ShopName"].ToString();
                            shopcart.FeeType = int.Parse(product.Rows[0]["FeeType"].ToString());
                            shopcart.shop_category_id = Convert.ToInt32(category);
                            if (product.Rows[0]["setstock"].ToString().Length > 1)
                            {
                                if (product.Rows[0]["setstock"].ToString().Trim(new[] { ';' }) != "0")
                                {
                                    shopcart.SpecificationValue =
                                        product.Rows[0]["setstock"].ToString().Trim(new[] { ';' }).Replace(":", ",").Replace(";", "|");
                                }
                                //if (HiddenFieldSpecName.Value.Trim(new[] { ';' }) != "0")
                                //{
                                //shopcart.SpecificationName =
                                //    HiddenFieldSpecName.Value.TrimEnd(new[] { ';' }).Replace("/", "-").TrimEnd(new[] { '0' });

                                shopcart.SpecificationName = "";   //看不懂 随意定的
                                //}
                            }
                            if (product.Rows[0]["FeeType"].ToString() == "1")
                            {
                                shopcart.Post_fee = 0;
                                shopcart.Ems_fee = 0;
                                shopcart.Express_fee = 0;
                            }
                            else
                            {
                                shopcart.Post_fee = decimal.Parse(product.Rows[0]["Post_fee"].ToString());
                                shopcart.Ems_fee = decimal.Parse(product.Rows[0]["Ems_fee"].ToString());
                                shopcart.Express_fee = decimal.Parse(product.Rows[0]["Express_fee"].ToString());
                            }
                            var action = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
                            int num = 0;
                            if (shopcart.SellName != "")
                            {
                                num = action.AddCart(shopcart);
                            }
                            else
                            {
                                num = 1;
                            }
                            if (num > 0)
                            {

                                return "添加成功!";
                            }
                            else
                            {
                                return "7";
                            }

                        }
                        else
                        {
                            return "8";
                        }
                    }


                }
            }
        }
    }
}