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
    public class ShengZhenCreateOrder : System.Web.UI.Page
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
        private string MemloginID;

        private string MemberLoginID { get; set; }

        private string MemberType { get; set; }

        private string ShopName { get; set; }
        private decimal QDSQPrice;//区代社区首次价格

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
        //OrderStatu               订单状态 0-已下单  1已付款  2已发货  3已完成交易






        //手机APP创建订单
        public string CreateOrder(string MemloginNO, decimal OrderPrice)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable memIdNo = member_Action.SelectMemberloginid_By_NO(MemloginNO);
            MemloginID = memIdNo.Rows[0]["MemLoginID"].ToString();
            string ServiceAgent = "C0000001";
            int ShopCategoryID = 1;
            int BuyNumber = 1;

            string ProductGuid = "682a514f-c178-4c82-914e-4d87c3459b94";
            //会员等级
            string memberGuid = member_Action.GetCurrentMemberRankGuid(MemloginID);


            //string PostPriceGZ = PostPriceDan(ShopCategoryID, ProductGuid, BuyNumber, MemloginID);


            #region 商品价格等信息



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
            if (ServiceAgent == "")
            {
                ServiceAgent = "";
            }
            //if (ServiceAgent == "C0000001" && ShopCategoryID == (int)CustomerCategory.大唐专区)
            //{
            //    ServiceAgent = "";
            //}
            if ((ShopCategoryID == (int)CustomerCategory.VIP专区 || ShopCategoryID == (int)CustomerCategory.BTC专区) && memberGuid != MemberLevel.NORMAL_MEMBER_ID && ServiceAgent == "C0000001")
            {
                ServiceAgent = "";
            }
            DataTable tbc = member_Action.SearchAreaAgentExist(ServiceAgent);
            if (tbc.Rows.Count > 0)
            {
                #region
                
                


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
                    shopNum1_OrderInfo.OrderNumber = order.CreateOrderNumber();
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
                    //                    IShopNum1_Address_Action shopNum1_Address_Action =
                    //LogicFactory.CreateShopNum1_Address_Action();
                    //                    DataTable Addresstable = shopNum1_Address_Action.Search(AddressGuid);
                    //                    if (Addresstable.Rows.Count > 0)
                    //                    {

                    shopNum1_OrderInfo.Name = "";
                    shopNum1_OrderInfo.Email = "";
                    shopNum1_OrderInfo.Address = "";
                    shopNum1_OrderInfo.Postalcode = "";
                    shopNum1_OrderInfo.Tel = "";
                    shopNum1_OrderInfo.Mobile = "";
                    shopNum1_OrderInfo.RegionCode = ""; //拿不准的数据
                    //}
                    //else
                    //{
                    //    return "6";
                    //}
                    shopNum1_OrderInfo.ClientToSellerMsg = "";
                    shopNum1_OrderInfo.DispatchType = 0;
                    shopNum1_OrderInfo.FeeType = 1;
                    shopNum1_OrderInfo.DispatchPrice = 0M;
                    //if (QDSQPrice != null && QDSQPrice != 0)
                    //{
                    //    shopNum1_OrderInfo.ShouldPayPrice = QDSQPrice;
                    //}
                    //else if (PostPrice == 0 && ShopCategoryID == 2)
                    //{
                    //    shopNum1_OrderInfo.ShouldPayPrice = (ShangPinPrice * Convert.ToInt32(BuyNumber)) + Convert.ToDecimal(PostPriceGZ);


                    //}
                    //else
                    //{
                    shopNum1_OrderInfo.ShouldPayPrice = OrderPrice;
                    //}

                    shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
                    shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
                    shopNum1_OrderInfo.InvoiceType = "";//拿不准的数据
                    shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

                    shopNum1_OrderInfo.OderStatus = 3;
                    //支付方式（1=预存款支付，2=智付支付）
                    //if (PayMentType == 1)
                    //{
                    shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
                    shopNum1_OrderInfo.PaymentName = "预存款支付";
                    //}
                    //else if (PayMentType == 2)
                    //{
                    //    shopNum1_OrderInfo.PaymentGuid = new Guid("1075526A-7C28-44D0-B5F8-FD1B6746F662");
                    //    shopNum1_OrderInfo.PaymentName = "唐江智付快捷支付";
                    //}
                    //else
                    //{
                    //    return "7";
                    //}

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
                    shopNum1_OrderProduct.Color = "";
                    shopNum1_OrderProduct.Size = "";
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
                    int num2 = shopNum1_OrderInfo_Action.ShenZhenAdd(shopNum1_OrderInfo, list);
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
                        return "订单创建成功！";
                    }

                    else
                    {
                        return "1";
                    }









                    #endregion

                
                #endregion
            }

            return "2";






            #endregion
        }



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
        protected string PostPriceDan(int ShopCategoryID, string ProductGuids, int BuyNumber, string MemloginID)
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
            if (ShopCategoryID == 5 || ShopCategoryID == 7 || ShopCategoryID == 9)
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

                }
                else if (num5 > Convert.ToDecimal(table.Rows[0]["FirstHeavy"]))
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

                    //PostpriceReulst = PostpriceReulst + "不使用红包免邮" + VIPPostage + "丨";

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
                    sMS.Send(strTel, text + "【唐江巴巴】", out empty);
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
                    sMS.Send(string_8.Trim(), text2 + "【唐江巴巴】", out text3);
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
    }
}