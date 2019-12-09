using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.Api;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Web.Script.Serialization;
using System.Collections;
using Newtonsoft.Json.Linq;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1.Common;
using ShopNum1.Interface;
using ShopNum1.ShopInterface;
using ShopNum1.Standard;
using ShopNum1.Email;
using System.Resources;
using System.Security.Cryptography;
using System.Configuration;

namespace ShopNum1.Deploy.KCELogic
{
    public class Gz_LogicApi : System.Web.UI.Page
    {
        ShopNum1_Member_Action ShopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
        ShopNum1_OrderInfo_Action ShopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();


        protected string miyao = "EDpqF8c9Qz0WbcAoNlttRRV0FgPoAUV7";


        public string RJiaMi(string Mem)
        {
            return Encrypt(Mem + miyao).ToLower();
        }

        public string Encrypt(string plaintext)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(plaintext);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }
            return ret.PadLeft(32, '0');

            //string cl1 = plaintext;
            //string pwd = string.Empty;
            //MD5 md5 = MD5.Create();
            //byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl1));
            //for (int i = 0; i < s.Length; i++)
            //{
            //    pwd = pwd + s[i].ToString("X");
            //}
            //return pwd;
        }


        public string RenRenZhuanZhang(string MemLoginID, decimal NEC,string phone,string RenType) {
            string fh = string.Empty;
            string postCan = "&memid=" + MemLoginID;
            postCan += "&nec=" + NEC;
            postCan += "&phone=" + phone;
            postCan += "&keytoken=" + RJiaMi(MemLoginID);
            postCan += "&rentype=" + RenType;


            bool IsWHJDebug = false;
            try
            {
                IsWHJDebug = ConfigurationManager.AppSettings["IsWHJDebug"] == "1" ? true : false;
            }
            catch (Exception)
            {

            }

            string apiiiii = IsWHJDebug ? "http://wz.batj.club/app/index.php?i=8&c=entry&m=ewei_shopv2&do=mobile&r=index.renrenchongzhi" : "http://localhost:45566/app/index.php?i=3&c=entry&m=ewei_shopv2&do=mobile&r=index.renrenchongzhi";


            string fhone = GET(apiiiii + postCan);
            //string fhone = GET("http://wz.batj.club/app/index.php?i=8&c=entry&m=ewei_shopv2&do=mobile&r=index.renrenchongzhi" + postCan);
            //http://wz.batj.club/app/index.php?i=8&c=entry&m=ewei_shopv2&do=mobile&r=member.rank
            try
            {
                Root rt = StringHelper.Deserialize<Root>(fhone);
                if (rt.status == 1) {
                    fh = rt.result.message;
                }
            }
            catch (Exception)
            {

            }
            return fh;
        }


       
        public class Result
        {
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }

            public string message { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public int status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Result result { get; set; }
        }






        //创建ETH地址
        public string CreateETHAdress()
        {


            string postCan = "";
            //string fh = Post(postUrl);
            string fh = Post("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=new_account");



            //JObject studentsJson = JObject.Parse(fh);
            //string status = studentsJson["status"].ToString();


            return fh;

        }




        /// <summary>
        /// 获取eth和usdt的兑换比例。
        /// 请注意返回为0的数据均为不正常
        /// </summary>
        /// <returns></returns>
        public double SelectETHBili()
        {
            string cache_key = "eth_usdt_price"; // 缓存键值，需要唯一
            object cache2 = System.Web.HttpRuntime.Cache.Get(cache_key);
            if (cache2 != null)
            {
                // 如果有缓存，直接读取缓存即可
                double eth_usdt = Convert.ToDouble(cache2);
                return eth_usdt;
            }
            else
            {
                // 没有缓存，获取一次远程的实时价格
                string p = Post("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=get_exchange_rate&currency=eth");
                string file_path = Server.MapPath("/") + cache_key + ".txt";
                if (p != null && p.Trim() != "")
                {
                    //创建缓存,缓存时间10分钟
                    System.Web.HttpRuntime.Cache.Insert(cache_key, p, null, DateTime.Now.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);
                    // 保存该值到文本中
                    File.WriteAllText(file_path, p, Encoding.UTF8);
                    return Convert.ToDouble(p);
                }
                p = File.ReadAllText(file_path);
                if (p != null && p.Trim() != "")
                {
                    return Convert.ToDouble(p);
                }
                return 0;
            }
        }
        /// <summary>
        /// 返回USDT可以兑换ETH比例
        /// </summary>
        /// <param name="wei"></param>
        /// <returns></returns>
        public decimal SelectUSDTBili(int wei = 8)
        {
            double eth_usdt = SelectETHBili();
            if (eth_usdt == 0)
            {
                return 0;
            }
            return Convert.ToDecimal(String.Format("{0:N" + wei.ToString() + "}", (1 / eth_usdt).ToString()));
        }



        #region 续约理财基金订单

        public string ContractFinancialOrder(string MemloginID, string ordernumber, int xzBuyNumber, string PayPwd)
        {

            int ShopCategoryID = 4;




            #region 商品价格等信息
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //会员等级


            string memberGuid = member_Action.GetCurrentMemberRankGuid(MemloginID);


            //Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

            //DataTable shopProductEdit = shop_Product_Action.GetFinancialProduct(ProductGuid);

            //DataTable zongEtable = member_Action.Select_All_ZuLinPrice(MemloginID);
            //decimal zongE = 0M;
            //if (zongEtable != null && zongEtable.Rows.Count > 0 && zongEtable.Rows[0]["zongPrice"] != null && zongEtable.Rows[0]["zongPrice"].ToString() != "")
            //{
            //    zongE = Convert.ToDecimal(zongEtable.Rows[0]["zongPrice"].ToString());
            //}

            //#region
            ////得到积分
            DataTable shopProductEdit = ShopNum1_OrderInfo_Action.SerchLiCaiOrderInfoAll(ordernumber);




            #endregion
            int WorkDay = Convert.ToInt32(shopProductEdit.Rows[0]["WorkDay"]);
            decimal Profit = Convert.ToDecimal(shopProductEdit.Rows[0]["Profit"]);
            //string CalculationTime = Convert.ToString(shopProductEdit.Rows[0]["CalculationTime"]);
            //string CalculationEndTime = Convert.ToString(shopProductEdit.Rows[0]["CalculationEndTime"]);
            string ProductName = Convert.ToString(shopProductEdit.Rows[0]["ProductName"]);
            string ProductGuid = Convert.ToString(shopProductEdit.Rows[0]["ProductGuid"]);
            //decimal ShangPinPrice=Convert.ToDecimal(shopProductEdit.Rows[0]["ShouldPayPrice"]);
            //int BuyNumber = Convert.ToInt32(shopProductEdit.Rows[0]["BuyNumber"]);
            string englishName= Convert.ToString(shopProductEdit.Rows[0]["ProductName_EN"]);
            int BuyNumber = xzBuyNumber;
            decimal ShangPinPrice = xzBuyNumber;
            int shop_category_id = ShopCategoryID;







            #region 服务代理查询





            #region 添加订单





            ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
            shopNum1_OrderInfo.MemLoginID = MemloginID;

            shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");

            shopNum1_OrderInfo.Guid = Guid.NewGuid();
            Order order = new Order();
            shopNum1_OrderInfo.OrderNumber = "JJ" + order.CreateOrderNumberDD(MemloginID);
            shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
            shopNum1_OrderInfo.ShipmentStatus = 0;
            shopNum1_OrderInfo.PaymentStatus = 0;
            shopNum1_OrderInfo.PayMentMemLoginID = MemloginID;
            shopNum1_OrderInfo.OrderType = 0;
            shopNum1_OrderInfo.Score_dv = 0;

            shopNum1_OrderInfo.Score_hv = 0;


            shopNum1_OrderInfo.score_reduce_hv = 0;


            shopNum1_OrderInfo.Score_pv_a = 0;

            shopNum1_OrderInfo.score_reduce_pv_a = 0;

            shopNum1_OrderInfo.Score_pv_b = 0;

            shopNum1_OrderInfo.Score_cv = 0;
            shopNum1_OrderInfo.Score_max_hv = 0;
            shopNum1_OrderInfo.shop_category_id = shop_category_id;
            shopNum1_OrderInfo.AgentId = "";
            shopNum1_OrderInfo.ServiceAgent = MemloginID;
            shopNum1_OrderInfo.score_pv_cv = 0.02M;




            shopNum1_OrderInfo.Name = "续约理财基金不需要地址信息";
            shopNum1_OrderInfo.Email = "续约理财基金不需要地址信息";
            shopNum1_OrderInfo.Address = "续约理财基金不需要地址信息";
            shopNum1_OrderInfo.Postalcode = "续约理财基金不需要地址信息";
            shopNum1_OrderInfo.Tel = "续约理财基金不需要地址信息";
            shopNum1_OrderInfo.Mobile = "续约理财基金不需要地址信息";
            shopNum1_OrderInfo.RegionCode = "续约理财基金不需要地址信息"; //拿不准的数据


            shopNum1_OrderInfo.ClientToSellerMsg = "";

            shopNum1_OrderInfo.DispatchType = 0;
            shopNum1_OrderInfo.FeeType = 666;
            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
            shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice;

            //工作日
            shopNum1_OrderInfo.SuanLiDaySum = WorkDay;
            //每日收益
            shopNum1_OrderInfo.SuanLiUnitPrice = Profit;



            shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceType = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

            shopNum1_OrderInfo.OderStatus = 1;

            shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
            shopNum1_OrderInfo.PaymentName = "NEC支付";


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
            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice);
            shopNum1_OrderInfo.ProductPv_b = 0m;
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
            DataTable dataTable2 = shop_Product_Action1.GetFinancialProduct(ProductGuid);
            shopNum1_OrderInfo.ShopID = "C0000001";
            shopNum1_OrderInfo.ShopName = "NEC";
            var list = new List<ShopNum1_OrderProduct>();
            ShopNum1_OrderProduct shopNum1_OrderProduct = new ShopNum1_OrderProduct();
            shopNum1_OrderProduct.BuyNumber = BuyNumber;
            shopNum1_OrderProduct.shop_category_id = shop_category_id;
            shopNum1_OrderProduct.Guid = Guid.NewGuid();
            shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
            shopNum1_OrderProduct.ProductGuid = ProductGuid;
            shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
            shopNum1_OrderProduct.RepertoryNumber = "0";
            shopNum1_OrderProduct.MarketPrice = 0m;
            shopNum1_OrderProduct.ShopPrice = 0m;
            shopNum1_OrderProduct.score_pv_cv = 0;
            //IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
            //DataTable dataTable33 =
            //    shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["MemLoginID"].ToString());

            //shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
            shopNum1_OrderProduct.ProductImg = "";
            shopNum1_OrderProduct.OrderType = 0;

            //         string SurplusTotal = Common.Common.GetNameById("SurplusTotal", "Nec_LiCaiJiJin",
            //" And ProductId=" + shopNum1_OrderProduct.ProductGuid + "");
            //         if (Convert.ToDecimal(BuyNumber) > Convert.ToDecimal(SurplusTotal))
            //         {

            //             return "库存不足!";

            //         }
            shopNum1_OrderProduct.Attributes = "";
            shopNum1_OrderProduct.SpecificationName = "";//拿不准的数据
            shopNum1_OrderProduct.SpecificationValue = "";//拿不准的数据
            shopNum1_OrderProduct.setStock = "1";//为空扣库存   为1不扣
            shopNum1_OrderProduct.IsShipment = 0;
            shopNum1_OrderProduct.IsReal = 0;
            shopNum1_OrderProduct.ExtensionAttriutes = "";
            shopNum1_OrderProduct.IsJoinActivity = 0;
            shopNum1_OrderProduct.CreateTime =
                Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_OrderProduct.DetailedSpecifications = "";
            shopNum1_OrderProduct.MemLoginID = MemloginID;
            shopNum1_OrderProduct.ShopID = "C0000001";
            shopNum1_OrderProduct.ProductName = "续约" + ProductName;
            shopNum1_OrderProduct.Color = "";
            shopNum1_OrderProduct.Size = "";
            list.Add(shopNum1_OrderProduct);
            #endregion

            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action =
(ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();

            DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
            decimal MyNEC = Convert.ToDecimal(tableTJ.Rows[0]["Score_dv"].ToString());

            string mjpayPwd = ShopNum1_Member_Action.GetPayPwd(MemloginID);
            if (PayPwd == "")
            {

                return GetString("GZ2");
            }
            else
            {
                string md5SecondHash = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                if (mjpayPwd != md5SecondHash)
                {

                    return GetString("GZ3");

                }
                else
                {
                    if (shopNum1_OrderInfo.ShouldPayPrice > MyNEC)
                    {
                        return GetString("GZ5");
                    }
                    else
                    {
                        int num2 = shopNum1_OrderInfo_Action.AddLiCai(shopNum1_OrderInfo, list, DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(WorkDay + 1).ToString("yyyy-MM-dd"), MyNEC, englishName);
                        if (num2 > 0)
                        {

                            //return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;

                            return num2.ToString();

                        }

                        else
                        {

                            return GetString("GZ7");
                        }

                    }
                }
            }





















            #endregion
        }




        #endregion

        #region 支付租赁订单

        public string Pay(string OrderNumber, string MemloginID, string PayPwd)
        {


            DataTable OrderInfoTable = ShopNum1_OrderInfo_Action.SerchOrderInfoAll(OrderNumber);


            decimal ShouldPayPrice = Convert.ToDecimal(OrderInfoTable.Rows[0]["ShouldPayPrice"]);


            DataSet dataSet_0 = ShopNum1_OrderInfo_Action.CheckTradeState(OrderNumber, MemloginID);

            //我有的
            decimal MyUSDT = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["AdvancePayment"]);

            decimal MyNEC = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);

            if (dataSet_0 != null && dataSet_0.Tables.Count == 2 &&
                        !(dataSet_0.Tables[0].Rows[0][0].ToString() == "-1"))
            {
                DataTable dataTableStatus = ShopNum1_OrderInfo_Action.SearchOrderInfo(OrderNumber);
                if (dataTableStatus.Rows[0]["PaymentStatus"].ToString() == "1")
                {

                    return GetString("GZ1");
                }


            }

            string mjpayPwd = ShopNum1_Member_Action.GetPayPwd(MemloginID);
            if (PayPwd == "")
            {

                return GetString("GZ2");
            }
            else
            {
                string md5SecondHash = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                if (mjpayPwd != md5SecondHash)
                {

                    return GetString("GZ3");

                }
                else
                {



                    decimal num2 = Convert.ToDecimal(ShouldPayPrice);
                    decimal nom4 = 0M;


                    if ((num2.ToString() == "0.00" || num2.ToString() == "0") || (num2 < 0))
                    {

                        return GetString("GZ4");
                    }
                    else
                    {

                        if (ShouldPayPrice > MyNEC)
                        {

                            return GetString("GZ5");
                        }
                        else
                        {

                            DataTable dataTableStatus = ShopNum1_OrderInfo_Action.SearchOrderInfo(OrderNumber);
                            if (dataTableStatus.Rows[0]["PaymentStatus"].ToString() == "1")
                            {

                                return GetString("GZ6");
                            }
                            else
                            {




                                int fh = ShopNum1_OrderInfo_Action.NEC_PayOrderInfo(OrderNumber, MemloginID, DateTime.Now, ShouldPayPrice, MyNEC);
                                if (fh == 1)
                                {
                                    return fh.ToString();
                                }
                                else
                                {

                                    return GetString("GZ7");
                                }












                            }



                        }
                    }

                }

            }
        }

        public string WHJPay(string OrderNumber, string MemloginID)
        {


            DataTable OrderInfoTable = ShopNum1_OrderInfo_Action.SerchOrderInfoAll(OrderNumber);


            decimal ShouldPayPrice = Convert.ToDecimal(OrderInfoTable.Rows[0]["ShouldPayPrice"]);


            DataSet dataSet_0 = ShopNum1_OrderInfo_Action.CheckTradeState(OrderNumber, MemloginID);

            //我有的
            decimal MyUSDT = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["AdvancePayment"]);

            decimal MyNEC = Convert.ToDecimal(dataSet_0.Tables[1].Rows[0]["Score_dv"]);

            if (dataSet_0 != null && dataSet_0.Tables.Count == 2 &&
                        !(dataSet_0.Tables[0].Rows[0][0].ToString() == "-1"))
            {
                DataTable dataTableStatus = ShopNum1_OrderInfo_Action.SearchOrderInfo(OrderNumber);
                if (dataTableStatus.Rows[0]["PaymentStatus"].ToString() == "1")
                {

                    return GetString("GZ1");
                }


            }

            decimal num2 = Convert.ToDecimal(ShouldPayPrice);
            decimal nom4 = 0M;

            if ((num2.ToString() == "0.00" || num2.ToString() == "0") || (num2 < 0))
            {
                return GetString("GZ4");
            }
            else
            {
                if (ShouldPayPrice > MyNEC)
                {
                    return GetString("GZ5");
                }
                else
                {
                    DataTable dataTableStatus = ShopNum1_OrderInfo_Action.SearchOrderInfo(OrderNumber);
                    if (dataTableStatus.Rows[0]["PaymentStatus"].ToString() == "1")
                    {
                        return GetString("GZ6");
                    }
                    else
                    {
                        int fh = ShopNum1_OrderInfo_Action.NEC_PayOrderInfo(OrderNumber, MemloginID, DateTime.Now, ShouldPayPrice, MyNEC);
                        if (fh == 1)
                        {
                            return fh.ToString();
                        }
                        else
                        {
                            return GetString("GZ7");
                        }
                    }
                }
            }
        }





        #endregion
        #region 创建理财基金订单

        public string CreateFinancialOrder(string MemloginID, string ProductGuid, int BuyNumber, string PayPwd)
        {

            int ShopCategoryID = 4;




            #region 商品价格等信息
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //会员等级


            string memberGuid = member_Action.GetCurrentMemberRankGuid(MemloginID);


            Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

            DataTable shopProductEdit = shop_Product_Action.GetFinancialProduct(ProductGuid);

            //DataTable zongEtable = member_Action.Select_All_ZuLinPrice(MemloginID);
            //decimal zongE = 0M;
            //if (zongEtable != null && zongEtable.Rows.Count > 0 && zongEtable.Rows[0]["zongPrice"] != null && zongEtable.Rows[0]["zongPrice"].ToString() != "")
            //{
            //    zongE = Convert.ToDecimal(zongEtable.Rows[0]["zongPrice"].ToString());
            //}

            //#region
            ////得到积分

            int BuyLimited = Convert.ToInt32(shopProductEdit.Rows[0]["BuyLimited"]);
            if (BuyNumber < BuyLimited)
            {
                return GetString("GZ25") + BuyLimited;
            }
            if (BuyNumber % 100 != 0)
            {
                return GetString("GZ26");
            }

            decimal ShangPinPrice = BuyNumber;



            #endregion
            int WorkDay = Convert.ToInt32(shopProductEdit.Rows[0]["WorkDay"]);
            decimal Profit = Convert.ToDecimal(shopProductEdit.Rows[0]["Profit"]);
            string CalculationTime = Convert.ToString(shopProductEdit.Rows[0]["CalculationTime"]);
            string CalculationEndTime = Convert.ToString(shopProductEdit.Rows[0]["CalculationEndTime"]);
            string ProductName = Convert.ToString(shopProductEdit.Rows[0]["ProductName"]);
            string englishName= Convert.ToString(shopProductEdit.Rows[0]["ProductName_EN"]);
            int shop_category_id = ShopCategoryID;




            #region 服务代理查询





            #region 添加订单





            ShopNum1_OrderInfo shopNum1_OrderInfo = new ShopNum1_OrderInfo();
            shopNum1_OrderInfo.MemLoginID = MemloginID;

            shopNum1_OrderInfo.SuperiorRank = new Guid("00000000-0000-0000-0000-000000000000");

            shopNum1_OrderInfo.Guid = Guid.NewGuid();
            Order order = new Order();
            shopNum1_OrderInfo.OrderNumber = "JJ" + order.CreateOrderNumberDD(MemloginID);
            shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
            shopNum1_OrderInfo.ShipmentStatus = 0;
            shopNum1_OrderInfo.PaymentStatus = 0;
            shopNum1_OrderInfo.PayMentMemLoginID = MemloginID;
            shopNum1_OrderInfo.OrderType = 0;
            shopNum1_OrderInfo.Score_dv = 0;

            shopNum1_OrderInfo.Score_hv = 0;


            shopNum1_OrderInfo.score_reduce_hv = 0;


            shopNum1_OrderInfo.Score_pv_a = 0;

            shopNum1_OrderInfo.score_reduce_pv_a = 0;

            shopNum1_OrderInfo.Score_pv_b = 0;

            shopNum1_OrderInfo.Score_cv = 0;
            shopNum1_OrderInfo.Score_max_hv = 0;
            shopNum1_OrderInfo.shop_category_id = shop_category_id;
            shopNum1_OrderInfo.AgentId = BuyNumber.ToString();
            shopNum1_OrderInfo.ServiceAgent = MemloginID;
            shopNum1_OrderInfo.score_pv_cv = 0.02M;




            shopNum1_OrderInfo.Name = "理财基金不需要地址信息";
            shopNum1_OrderInfo.Email = "理财基金不需要地址信息";
            shopNum1_OrderInfo.Address = "理财基金不需要地址信息";
            shopNum1_OrderInfo.Postalcode = "理财基金不需要地址信息";
            shopNum1_OrderInfo.Tel = "理财基金不需要地址信息";
            shopNum1_OrderInfo.Mobile = "理财基金不需要地址信息";
            shopNum1_OrderInfo.RegionCode = "理财基金不需要地址信息"; //拿不准的数据


            shopNum1_OrderInfo.ClientToSellerMsg = "";

            shopNum1_OrderInfo.DispatchType = 0;
            shopNum1_OrderInfo.FeeType = 666;
            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
            shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice;

            //工作日
            shopNum1_OrderInfo.SuanLiDaySum = WorkDay;
            //每日收益
            shopNum1_OrderInfo.SuanLiUnitPrice = Profit;



            shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceType = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

            shopNum1_OrderInfo.OderStatus = 1;

            shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
            shopNum1_OrderInfo.PaymentName = "NEC支付";


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
            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice);
            shopNum1_OrderInfo.ProductPv_b = 0m;
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
            DataTable dataTable2 = shop_Product_Action1.GetFinancialProduct(ProductGuid);
            shopNum1_OrderInfo.ShopID = "C0000001";
            shopNum1_OrderInfo.ShopName = "NEC";
            var list = new List<ShopNum1_OrderProduct>();
            ShopNum1_OrderProduct shopNum1_OrderProduct = new ShopNum1_OrderProduct();
            shopNum1_OrderProduct.BuyNumber = BuyNumber;
            shopNum1_OrderProduct.shop_category_id = shop_category_id;
            shopNum1_OrderProduct.Guid = Guid.NewGuid();
            shopNum1_OrderProduct.OrderInfoGuid = shopNum1_OrderInfo.Guid.ToString();
            shopNum1_OrderProduct.ProductGuid = ProductGuid;
            shopNum1_OrderProduct.GroupPrice = Convert.ToDecimal("0.00");
            shopNum1_OrderProduct.RepertoryNumber = "0";
            shopNum1_OrderProduct.MarketPrice = 0m;
            shopNum1_OrderProduct.ShopPrice = 0m;
            shopNum1_OrderProduct.score_pv_cv = 0;
            //IShop_Ensure_Action shop_Ensure_Action = ShopFactory.LogicFactory.CreateShop_Ensure_Action();
            //DataTable dataTable33 =
            //    shop_Ensure_Action.SearchEnsureApply(shopProductEdit.Rows[0]["MemLoginID"].ToString());

            //shopNum1_OrderProduct.ProductImg = dataTable2.Rows[0]["OriginalImage"].ToString();
            shopNum1_OrderProduct.ProductImg = "";
            shopNum1_OrderProduct.OrderType = 0;

            string SurplusTotal = Common.Common.GetNameById("SurplusTotal", "Nec_LiCaiJiJin",
   " And ProductId=" + shopNum1_OrderProduct.ProductGuid + "");
            if (Convert.ToDecimal(BuyNumber) > Convert.ToDecimal(SurplusTotal))
            {

                return GetString("GZ27");

            }
            shopNum1_OrderProduct.Attributes = "";
            shopNum1_OrderProduct.SpecificationName = "";//拿不准的数据
            shopNum1_OrderProduct.SpecificationValue = "";//拿不准的数据
            shopNum1_OrderProduct.setStock = "0";//为空扣库存   为1不扣
            shopNum1_OrderProduct.IsShipment = 0;
            shopNum1_OrderProduct.IsReal = 0;
            shopNum1_OrderProduct.ExtensionAttriutes = "";
            shopNum1_OrderProduct.IsJoinActivity = 0;
            shopNum1_OrderProduct.CreateTime =
                Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            shopNum1_OrderProduct.DetailedSpecifications = "";
            shopNum1_OrderProduct.MemLoginID = MemloginID;
            shopNum1_OrderProduct.ShopID = "C0000001";
            shopNum1_OrderProduct.ProductName = ProductName;
            shopNum1_OrderProduct.Color = "";
            shopNum1_OrderProduct.Size = "";
            list.Add(shopNum1_OrderProduct);
            #endregion

            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action =
(ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();

            DataTable tableTJ = member_Action.SearchMembertwo(MemloginID);
            decimal MyNEC = Convert.ToDecimal(tableTJ.Rows[0]["Score_dv"].ToString());

            string mjpayPwd = ShopNum1_Member_Action.GetPayPwd(MemloginID);
            if (PayPwd == "")
            {

                return GetString("MG000021");
            }
            else
            {
                string md5SecondHash = Common.Encryption.GetMd5SecondHash(PayPwd.Trim());
                if (mjpayPwd != md5SecondHash)
                {

                    return GetString("MG000010");

                }
                else
                {
                    if (shopNum1_OrderInfo.ShouldPayPrice > MyNEC)
                    {
                        return GetString("GZ5");
                    }
                    else
                    {
                        int num2 = shopNum1_OrderInfo_Action.AddLiCai(shopNum1_OrderInfo, list, DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(WorkDay + 1).ToString("yyyy-MM-dd"), MyNEC, englishName);
                        if (num2 > 0)
                        {

                            //return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;

                            return num2.ToString();

                        }

                        else
                        {

                            return GetString("GZ7");
                        }

                    }
                }
            }





















            #endregion
        }




        #endregion

        #region 创建租赁订单

        public string CreateOrder(string MemloginID, string ProductGuid, int GuiGeType, int BuyNumber, string PayPwd)
        {

            int ShopCategoryID = 3;




            #region 商品价格等信息
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //会员等级


            string memberGuid = member_Action.GetCurrentMemberRankGuid(MemloginID);


            Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

            DataTable shopProductEdit = shop_Product_Action.GetShopProductEdit(ProductGuid, ShopCategoryID);

            DataTable zongEtable = member_Action.Select_All_ZuLinPrice(MemloginID);
            decimal zongE = 0M;
            if (zongEtable != null && zongEtable.Rows.Count > 0 && zongEtable.Rows[0]["zongPrice"] != null && zongEtable.Rows[0]["zongPrice"].ToString() != "")
            {
                zongE = Convert.ToDecimal(zongEtable.Rows[0]["zongPrice"].ToString());
            }

            #region
            //得到积分
            decimal ShangPinPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"]) * BuyNumber;

            if (ShangPinPrice + zongE > 1000000)
            {

                return GetString("GZ8");

            }

            #endregion
            int Day = Convert.ToInt32(shopProductEdit.Rows[0]["SuanLiDaySum"]);
            decimal UnitPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["SuanLiUnitPrice"]) * BuyNumber;
            decimal MYlabelScore_dv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]);
            decimal MYlabelScore_pv_b = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]);
            //string MYlabelAgentId = Convert.ToString(shopProductEdit.Rows[0]["agentId"]);

            int shop_category_id = Convert.ToInt32(shopProductEdit.Rows[0]["shop_category_id"]);

            #endregion


            #region 服务代理查询





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
            shopNum1_OrderInfo.OrderNumber = "ZL" + order.CreateOrderNumberDD(MemloginID);
            shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
            shopNum1_OrderInfo.ShipmentStatus = 0;
            shopNum1_OrderInfo.PaymentStatus = 0;
            shopNum1_OrderInfo.PayMentMemLoginID = shopProductEdit.Rows[0]["MemLoginID"].ToString();
            shopNum1_OrderInfo.OrderType = 0;
            shopNum1_OrderInfo.Score_dv = 0;

            shopNum1_OrderInfo.Score_hv = 0;


            shopNum1_OrderInfo.score_reduce_hv = 0;


            shopNum1_OrderInfo.Score_pv_a = 0;

            shopNum1_OrderInfo.score_reduce_pv_a = 0;

            shopNum1_OrderInfo.Score_pv_b = MYlabelScore_pv_b;

            shopNum1_OrderInfo.Score_cv = 0;
            shopNum1_OrderInfo.Score_max_hv = 0;
            shopNum1_OrderInfo.shop_category_id = shop_category_id;
            shopNum1_OrderInfo.AgentId = BuyNumber.ToString();
            shopNum1_OrderInfo.ServiceAgent = "C0000001";
            shopNum1_OrderInfo.score_pv_cv = 0.01M;




            shopNum1_OrderInfo.Name = "租赁不需要地址信息";
            shopNum1_OrderInfo.Email = "租赁不需要地址信息";
            shopNum1_OrderInfo.Address = "租赁不需要地址信息";
            shopNum1_OrderInfo.Postalcode = "租赁不需要地址信息";
            shopNum1_OrderInfo.Tel = "租赁不需要地址信息";
            shopNum1_OrderInfo.Mobile = "租赁不需要地址信息";
            shopNum1_OrderInfo.RegionCode = "租赁不需要地址信息"; //拿不准的数据


            shopNum1_OrderInfo.ClientToSellerMsg = "";

            shopNum1_OrderInfo.DispatchType = 0;
            shopNum1_OrderInfo.FeeType = 666;
            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
            shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice;
            if (GuiGeType.ToString().Trim() == "1".Trim())
            {

                shopNum1_OrderInfo.SuanLiDaySum = 60;
                //shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.005);
                //2.0需要的改动
                shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.004);
            }
            else if (GuiGeType.ToString().Trim() == "2".Trim())
            {
                shopNum1_OrderInfo.SuanLiDaySum = 180;
                //shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.007);
                //2.0需要的改动
                shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.0056);
            }
            else if (GuiGeType.ToString().Trim() == "3".Trim())
            {
                shopNum1_OrderInfo.SuanLiDaySum = 270;

                //shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.01);
                //2.0需要的改动
                shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.008);
            }



            shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceType = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

            shopNum1_OrderInfo.OderStatus = 0;

            shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
            shopNum1_OrderInfo.PaymentName = "NEC支付";


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
            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice);
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
            shopNum1_OrderProduct.score_pv_cv = 0;
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

                return GetString("GZ9");

            }
            string nameById2 = Common.Common.GetNameById("repertorycount", "shopnum1_shop_product",
   " And Guid='" + shopNum1_OrderProduct.ProductGuid + "'");
            if (nameById2 == "0")
            {

                return GetString("GZ10");

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
            string ProductName_EN = "";
            if (dataTable2.Rows[0]["ProductName_EN"].ToString() != null)
            {
                ProductName_EN = dataTable2.Rows[0]["ProductName_EN"].ToString();
            }

            var shopNum1_OrderInfo_Action =
(ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();

            int num2 = shopNum1_OrderInfo_Action.AddZuLin(shopNum1_OrderInfo, list, ProductName_EN);
            if (num2 > 0)
            {

                //return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;

                string fh = Pay(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID, PayPwd);
                return fh;

            }

            else
            {

                return GetString("GZ11");
            }









            #endregion











            #endregion
        }


        /// <summary>
        /// 商城用订单
        /// </summary>
        /// <param name="MemloginID"></param>
        /// <param name="ProductGuid"></param>
        /// <param name="GuiGeType"></param>
        /// <param name="BuyNumber"></param>
        /// <param name="PayPwd"></param>
        /// <returns></returns>
        public string WHJ_CreateOrder(string MemloginID, string ProductGuid, int GuiGeType, int BuyNumber)
        {

            int ShopCategoryID = 3;




            #region 商品价格等信息
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            //会员等级


            string memberGuid = member_Action.GetCurrentMemberRankGuid(MemloginID);


            Shop_Product_Action shop_Product_Action = (Shop_Product_Action)ShopFactory.LogicFactory.CreateShop_Product_Action();

            DataTable shopProductEdit = shop_Product_Action.GetShopProductEdit(ProductGuid, ShopCategoryID);

            DataTable zongEtable = member_Action.Select_All_ZuLinPrice(MemloginID);
            decimal zongE = 0M;
            if (zongEtable != null && zongEtable.Rows.Count > 0 && zongEtable.Rows[0]["zongPrice"] != null && zongEtable.Rows[0]["zongPrice"].ToString() != "")
            {
                zongE = Convert.ToDecimal(zongEtable.Rows[0]["zongPrice"].ToString());
            }

            #region
            //得到积分
            decimal ShangPinPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["ShopPrice"]) * BuyNumber;

            if (ShangPinPrice + zongE > 1000000)
            {

                return GetString("GZ8");

            }

            #endregion
            int Day = Convert.ToInt32(shopProductEdit.Rows[0]["SuanLiDaySum"]);
            decimal UnitPrice = Convert.ToDecimal(shopProductEdit.Rows[0]["SuanLiUnitPrice"]) * BuyNumber;
            decimal MYlabelScore_dv = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_dv"]);
            decimal MYlabelScore_pv_b = Convert.ToDecimal(shopProductEdit.Rows[0]["Score_pv_b"]);
            //string MYlabelAgentId = Convert.ToString(shopProductEdit.Rows[0]["agentId"]);

            int shop_category_id = Convert.ToInt32(shopProductEdit.Rows[0]["shop_category_id"]);

            #endregion


            #region 服务代理查询





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
            shopNum1_OrderInfo.OrderNumber = "ZL" + order.CreateOrderNumberDD(MemloginID);
            shopNum1_OrderInfo.TradeID = shopNum1_OrderInfo.OrderNumber;
            shopNum1_OrderInfo.ShipmentStatus = 0;
            shopNum1_OrderInfo.PaymentStatus = 0;
            shopNum1_OrderInfo.PayMentMemLoginID = shopProductEdit.Rows[0]["MemLoginID"].ToString();
            shopNum1_OrderInfo.OrderType = 0;
            shopNum1_OrderInfo.Score_dv = 0;

            shopNum1_OrderInfo.Score_hv = 0;


            shopNum1_OrderInfo.score_reduce_hv = 0;


            shopNum1_OrderInfo.Score_pv_a = 0;

            shopNum1_OrderInfo.score_reduce_pv_a = 0;

            shopNum1_OrderInfo.Score_pv_b = MYlabelScore_pv_b;

            shopNum1_OrderInfo.Score_cv = 0;
            shopNum1_OrderInfo.Score_max_hv = 0;
            shopNum1_OrderInfo.shop_category_id = shop_category_id;
            shopNum1_OrderInfo.AgentId = BuyNumber.ToString();
            shopNum1_OrderInfo.ServiceAgent = "C0000001";
            shopNum1_OrderInfo.score_pv_cv = 0.01M;




            shopNum1_OrderInfo.Name = "租赁不需要地址信息";
            shopNum1_OrderInfo.Email = "租赁不需要地址信息";
            shopNum1_OrderInfo.Address = "租赁不需要地址信息";
            shopNum1_OrderInfo.Postalcode = "租赁不需要地址信息";
            shopNum1_OrderInfo.Tel = "租赁不需要地址信息";
            shopNum1_OrderInfo.Mobile = "租赁不需要地址信息";
            shopNum1_OrderInfo.RegionCode = "租赁不需要地址信息"; //拿不准的数据


            shopNum1_OrderInfo.ClientToSellerMsg = "";

            shopNum1_OrderInfo.DispatchType = 0;
            shopNum1_OrderInfo.FeeType = 666;
            shopNum1_OrderInfo.DispatchPrice = Convert.ToDecimal(0.0);
            shopNum1_OrderInfo.ShouldPayPrice = ShangPinPrice;
            if (GuiGeType.ToString().Trim() == "1".Trim())
            {

                shopNum1_OrderInfo.SuanLiDaySum = 60;
                //shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.005);
                //2.0需要的改动
                shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.004);
            }
            else if (GuiGeType.ToString().Trim() == "2".Trim())
            {
                shopNum1_OrderInfo.SuanLiDaySum = 180;
                //shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.007);
                //2.0需要的改动
                shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.0056);
            }
            else if (GuiGeType.ToString().Trim() == "3".Trim())
            {
                shopNum1_OrderInfo.SuanLiDaySum = 270;

                //shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.01);
                //2.0需要的改动
                shopNum1_OrderInfo.SuanLiUnitPrice = ShangPinPrice * Convert.ToDecimal(0.008);
            }



            shopNum1_OrderInfo.InvoiceTitle = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceContent = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceType = "";//拿不准的数据
            shopNum1_OrderInfo.InvoiceTax = 0m;//拿不准的数据

            shopNum1_OrderInfo.OderStatus = 0;

            shopNum1_OrderInfo.PaymentGuid = new Guid("D7A29771-7640-4999-85DE-B3B493DA5970");
            shopNum1_OrderInfo.PaymentName = "NEC支付";


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
            shopNum1_OrderInfo.ProductPrice = Convert.ToDecimal(ShangPinPrice);
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
            shopNum1_OrderProduct.score_pv_cv = 0;
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

                return GetString("GZ9");

            }
            string nameById2 = Common.Common.GetNameById("repertorycount", "shopnum1_shop_product",
   " And Guid='" + shopNum1_OrderProduct.ProductGuid + "'");
            if (nameById2 == "0")
            {

                return GetString("GZ10");

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
            string ProductName_EN = "";
            if (dataTable2.Rows[0]["ProductName_EN"].ToString() != null)
            {
                ProductName_EN = dataTable2.Rows[0]["ProductName_EN"].ToString();
            }

            var shopNum1_OrderInfo_Action =
(ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();

            int num2 = shopNum1_OrderInfo_Action.AddZuLin(shopNum1_OrderInfo, list, ProductName_EN);
            if (num2 > 0)
            {

                //return shopNum1_OrderInfo.ShouldPayPrice.ToString() + "," + shopNum1_OrderInfo.shop_category_id.ToString() + "," + shopNum1_OrderInfo.TradeID + "," + shopNum1_OrderInfo.Guid;
                
                member_Action.ZhuanZhangNECJia(shopNum1_OrderInfo.MemLoginID, shopNum1_OrderInfo.ShouldPayPrice.Value, "商城锁仓商品");

                string fh = WHJPay(shopNum1_OrderInfo.OrderNumber, shopNum1_OrderInfo.MemLoginID);
                return fh;

            }

            else
            {

                return GetString("GZ11");
            }









            #endregion











            #endregion
        }



        #endregion





        #region 注册手机发送验证码接口
        public static string SendVerificationMsg(string url, string param)
        {
            string result = string.Empty;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(param);
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.KeepAlive = false;
            //webRequest.AllowAutoRedirect = true;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR  3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET ";
            webRequest.ContentLength = data.Length;
            webRequest.Timeout = 15000;
            try
            {
                Stream reqStream = webRequest.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
                WebResponse response = webRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), encoding);
                result = streamReader.ReadToEnd();
                response.Close();
            }
            catch (Exception)
            {
                result = "";
            }
            return result;
        }

        public bool SendFast(string mobile, string content)
        {
            bool flag = false;
            string url = "http://120.79.149.129:7799/sms.aspx";
            string con = HttpUtility.UrlEncode(content, Encoding.UTF8);
            string data = "action=send&userid=117&account=tj88&password=tj123321&mobile=" + mobile + "&content=" + con;
            string text2 = SendVerificationMsg(url, data);
            bool result;
            if (text2 == "")
            {
                result = false;
            }
            else
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(text2);
                XmlNode node = xml.ChildNodes[1].ChildNodes[0];
                if (node.InnerText.ToLower() == "success")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                result = flag;
            }
            return result;
        }

        #endregion
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        public int ConvertDateTimeIntTwo(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        public static class DecimalHelper
        {
            public static decimal CutDecimalWithN(decimal d, int n)
            {
                string strDecimal = d.ToString();
                int index = strDecimal.IndexOf(".");
                if (index == -1 || strDecimal.Length < index + n + 1)
                {
                    strDecimal = string.Format("{0:F" + n + "}", d);
                }
                else
                {
                    int length = index;
                    if (n != 0)
                    {
                        length = index + n + 1;
                    }
                    strDecimal = strDecimal.Substring(0, length);
                }
                return Decimal.Parse(strDecimal);
            }
        }


        public string UpdateCNY(string MemLoginID, decimal CNY, int ZJtype)
        {
            string TimeOut = ConvertDateTimeInt(DateTime.Now).ToString();
            string PostToken = ShopNum1.Common.MD5JiaMi.Md5JiaMi(ShopNum1.Common.MD5JiaMi.key + ShopNum1.Common.MD5JiaMi.secret + TimeOut);

            string postCanone = "type=AB&timestamp=" + TimeOut + "&currency_id=32&token=" + PostToken;
            //string fh = Post(postUrl);
            string fhone = PostDataGetHtml("http://www.ikex8.com/Api/Currency/newprice", postCanone);
            JObject studentsJsonone = JObject.Parse(fhone);
            //string CNYone = studentsJsonone["data"]["CNY"].ToString();
            string CNYone = "1";
            decimal CNYH = CNY / Convert.ToDecimal(CNYone);
            decimal CNY4 = DecimalHelper.CutDecimalWithN(CNYH, 4);

            string postCan = "type=AB&timestamp=" + TimeOut + "&currency_id=32&token=" + PostToken + "&member_id=K" + MemLoginID + "&number=" + CNY4 + "&flag=" + ZJtype;
            //string fh = Post(postUrl);
            string fh = PostDataGetHtml("http://www.ikex8.com/Api/Currency/edit_currency", postCan);
            JObject studentsJson = JObject.Parse(fh);
            string fhh = studentsJson["status"].ToString() + "," + studentsJson["msg"].ToString();
            return fhh;

        }



        /// <summary>
        /// 查询CNY估价
        /// </summary>
        /// <returns></returns>
        public string SelectCNYprice()
        {
            string TimeOut = ConvertDateTimeInt(DateTime.Now).ToString();
            string PostToken = ShopNum1.Common.MD5JiaMi.Md5JiaMi(ShopNum1.Common.MD5JiaMi.key + ShopNum1.Common.MD5JiaMi.secret + TimeOut);


            string postCan = "type=AB&timestamp=" + TimeOut + "&currency_id=32&token=" + PostToken;
            //string fh = Post(postUrl);
            string fh = PostDataGetHtml("http://www.ikex8.com/Api/Currency/newprice", postCan);
            JObject studentsJson = JObject.Parse(fh);
            string fhh = studentsJson["status"].ToString();
            string CNY = "";
            if (fhh == "1")
            {

                CNY = studentsJson["data"]["CNY"].ToString();
                return "1";
            }
            else
            {
                return fhh;
            }


        }

        /// <summary>
        /// 查询交易所钱包
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="PWD"></param>
        /// <param name="PayPWD"></param>
        /// <param name="Mobile"></param>
        /// <returns></returns>
        public string SelectMoneyBao(string memloginid)
        {
            string TimeOut = ConvertDateTimeInt(DateTime.Now).ToString();
            string PostToken = ShopNum1.Common.MD5JiaMi.Md5JiaMi(ShopNum1.Common.MD5JiaMi.key + ShopNum1.Common.MD5JiaMi.secret + TimeOut);
            string postCan = "type=AB&timestamp=" + TimeOut + "&member_id=K" + memloginid + "&currency_id=32&token=" + PostToken;
            string fh = PostDataGetHtml("http://www.ikex8.com/Api/Currency/check_user", postCan);
            JObject studentsJson = JObject.Parse(fh);
            string fhh = studentsJson["status"].ToString() + "," + studentsJson["msg"].ToString(); ;
            return fhh;
        }


        public string SynchronousAccount(string MemLoginID, string PWD, string PayPWD, string Mobile)
        {
            string TimeOut = ConvertDateTimeInt(DateTime.Now).ToString();
            string PostToken = ShopNum1.Common.MD5JiaMi.Md5JiaMi(ShopNum1.Common.MD5JiaMi.key + ShopNum1.Common.MD5JiaMi.secret + TimeOut);


            string postCan = "type=AB&timestamp=" + TimeOut + "&email=" + MemLoginID + "&phone=" + Mobile + "&pwd=" + PWD + "&pwdtrade=" + PayPWD + "&token=" + PostToken;
            //string fh = Post(postUrl);
            string fh = PostDataGetHtml("http://www.ikex8.com/Api/Reg/addKbReg", postCan);
            JObject studentsJson = JObject.Parse(fh);
            string status = studentsJson["status"].ToString();
            if (status == "1")
            {

                return "1";

            }
            else
            {

                return studentsJson["msg"].ToString();
            }
        }


        /// <summary>
        /// 注册接口
        /// </summary>
        /// <param name="Mobile">手机</param>
        /// <param name="MobileCode">验证码</param>
        /// <param name="PassWord">密码</param>
        /// <param name="IIPassWord">二级密码</param>
        /// <param name="Referee">推荐人</param>
        /// <returns>返回注册成败信息</returns>
        public string MemberRegister(string Mobile, string Name, string PassWord, string IIPassWord, string Referee, int mobileInt)
        {
            int result;
            Name = Name.Trim();
            Mobile = Mobile.Trim();
            PassWord = PassWord.Trim();
            IIPassWord = IIPassWord.Trim();
            Referee = Referee.Trim();
            ShopNum1_Member member = new ShopNum1_Member();
            string MemLoginID = "";
            for (int i = 0; i < 10000; i++)
            {
                MemLoginID = ShopNum1_Member_Action.GetGZMemberNumber();
                DataTable YzMemLoginID = ShopNum1_Member_Action.KceYzMember(MemLoginID);
                if (YzMemLoginID == null || YzMemLoginID.Rows.Count == 0)
                {
                    member.MemLoginID = MemLoginID;
                    i = 10000;
                }
            }
            if (!isNumberic(IIPassWord, out result))
            {
                return GetString("MG000042");
            }
            if (Mobile.Contains("+"))
            {
                Mobile = Mobile.Replace("+", "");
                mobileInt = 1;
            }
            else
            {
                mobileInt = 0;
            }
            if (Referee == "")
            {
                return GetString("MG000043");
            }
            if (Name == "")
            {
                return GetString("MG000044");
            }
            if (PassWord == "")
            {
                return GetString("MG000045");
            }
            if (IIPassWord == "")
            {
                return GetString("MG000046");
            }
            DataTable YzReferee = ShopNum1_Member_Action.KceYzReferee(Referee);
            string cccd = "";
            if (YzReferee == null || YzReferee.Rows.Count < 1)
            {
                return GetString("MG000043");
            }
            else
            {
                member.Superior = YzReferee.Rows[0]["MemLoginID"].ToString();
                cccd = YzReferee.Rows[0]["MemLoginID"].ToString();
            }
            member.Mobile = Mobile;
            member.RealName = "";
            member.Email = "";
            member.Name = Name;
            member.IsForbid = 0;
            member.MemberType = 1;
            member.IdentityCard = "";//用户身份证号
            member.MemLoginNO = member.MemLoginID;
            member.Pwd = ShopNum1.Common.Encryption.GetMd5Hash(PassWord);
            member.PayPwd = Common.Encryption.GetMd5SecondHash(IIPassWord);
            member.Guid = Guid.NewGuid();
            member.AdvancePayment = 0;
            member.AddressValue = "";
            member.AddressCode = "";
            member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            member.LoginDate = null;
            member.IsMobileActivation = 0;
            member.IsEmailActivation = "0";
            member.PromotionMemLoginID = "";
            member.Score_hv = 0;
            member.IsMailActivation = 0;
            member.MemberRank = 0;
            member.MemberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
            member.Score = 0;
            member.LastLoginIP = null;
            member.LoginTime = 1;
            member.AdvancePayment = 0;
            member.LockAdvancePayment = 0;
            member.LockSocre = 0;
            member.CostMoney = 0;
            member.mobiletype = mobileInt;
            member.RecoMember = member.Superior;
            member.Score1 = 0;
            member.Score2 = 0;
            member.Score3 = 0;
            member.Score4 = 0;
            member.Score5 = 0;
            member.Score6 = 0;

            ////string fh = Post(postUrl);
            string fh1 = "";
            //string fh2 = Post("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=new_account");
            //if (fh1 != "")
                if (1 == 1)
                {
                member.NECAddress = fh1.Trim();
                //member.NECAddress = fh2.Trim();
                member.ETHAddress = fh1.Trim();
                //member.NECAddress = "";
                if (ShopNum1_Member_Action.AddMJC(member) == 1)
                {
                    DataTable TJRtable = ShopNum1_Member_Action.SearchMembertwoWHJ(cccd,true);
                    DataTable ZJtable = ShopNum1_Member_Action.SearchMembertwoWHJ(member.MemLoginID,true);
                    string code = TJRtable.Rows[0]["RecoCode"].ToString() + ZJtable.Rows[0]["ID"].ToString() + ",";
                    ShopNum1_Member_Action.updateRecoCode(member.MemLoginID, code);
                    return "K" + member.MemLoginID;
                }
                else
                {
                    return GetString("MG000047");
                }
            }


            else
            {

                return GetString("MG000048");
            }


        }

        public string PayOrderInfoHouTaiYong(string MemLoginID, string OrderNumber)
        {
            DataTable MemberTable = ShopNum1_Member_Action.SearchMembertwo(MemLoginID);
            string MyIIPassWord = MemberTable.Rows[0]["PayPwd"].ToString();
            decimal MyCNY = Convert.ToDecimal(MemberTable.Rows[0]["AdvancePayment"]);
            decimal MyKb = Convert.ToDecimal(MemberTable.Rows[0]["Score_hv"]);
            decimal MyEdu = Convert.ToDecimal(MemberTable.Rows[0]["Score_pv_b"]);

            DataTable OrderTable = ShopNum1_OrderInfo_Action.SerchOrderInfoKCEAll(OrderNumber);
            string shopid = OrderTable.Rows[0]["MemLoginID"].ToString();
            string typeid = OrderTable.Rows[0]["ShipmentStatus"].ToString();
            string orderstatus = OrderTable.Rows[0]["OderStatus"].ToString();
            decimal Kb = Convert.ToDecimal(OrderTable.Rows[0]["ShouldPayPrice"]);
            decimal CNY = Convert.ToDecimal(OrderTable.Rows[0]["Score_pv_b"]);

            DataTable ShopTable = ShopNum1_Member_Action.SearchMembertwo(shopid);
            decimal ShopCNY = Convert.ToDecimal(ShopTable.Rows[0]["AdvancePayment"]);
            decimal ShopKb = Convert.ToDecimal(ShopTable.Rows[0]["Score_hv"]);
            decimal ShopEdu = Convert.ToDecimal(ShopTable.Rows[0]["Score_pv_b"]);




            if (MemLoginID == shopid)
            {
                return "您不能购买自己的订单!";
            }
            else
            {

                if (typeid == "1")
                {
                    if (Kb > MyKb)
                    {
                        return "您的K宝不足以支付此订单!";
                    }
                    else if (Kb > MyEdu)
                    {
                        return "您可用C2C额度不足，当前可用额度为：" + MyEdu + "";
                    }
                    else
                    {
                        #region 支付K宝
                        if (orderstatus == "1")
                        {
                            int fh = ShopNum1_OrderInfo_Action.KCE_PayOrderInfo(OrderNumber, MemLoginID, shopid, DateTime.Now, typeid, Kb, CNY, MyCNY, MyKb, MyEdu, ShopCNY, ShopKb, ShopEdu);
                            return fh.ToString();

                        }
                        else
                        {
                            return "订单状态异常!";
                        }
                        #endregion
                    }




                }
                else if (typeid == "2")
                {
                    if (CNY > MyCNY)
                    {
                        return "您的人民币不足以支付此订单!";
                    }
                    else
                    {
                        #region 支付人民币
                        if (orderstatus == "1")
                        {
                            int fh = ShopNum1_OrderInfo_Action.KCE_PayOrderInfo(OrderNumber, MemLoginID, shopid, DateTime.Now, typeid, Kb, CNY, MyCNY, MyKb, MyEdu, ShopCNY, ShopKb, ShopEdu);
                            return fh.ToString();

                        }
                        else
                        {
                            return "订单状态异常!";
                        }
                        #endregion
                    }
                }
                else
                {
                    return "订单不明确!";
                }
            }









        }


        protected bool isNumberic(string message, out int result)
        {
            //判断是否为整数字符串
            //是的话则将其转换为数字并将其设为out类型的输出值、返回true, 否则为false
            result = -1;   //result 定义为out 用来输出值
            try
            {
                //当数字字符串的为是少于4时，以下三种都可以转换，任选一种
                //如果位数超过4的话，请选用Convert.ToInt32() 和int.Parse()

                //result = int.Parse(message);
                //result = Convert.ToInt16(message);
                result = Convert.ToInt32(message);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 注册接口
        /// </summary>
        /// <param name="Mobile">手机</param>
        /// <param name="MobileCode">验证码</param>
        /// <param name="PassWord">密码</param>
        /// <param name="IIPassWord">二级密码</param>
        /// <param name="Referee">推荐人</param>
        /// <returns>返回注册成败信息</returns>
        public string Html5MemberRegister(string MemloginID, string Mobile, string Name, string PassWord, string IIPassWord, string Referee)
        {

            Name = Name.Trim();
            Mobile = Mobile.Trim();
            PassWord = PassWord.Trim();
            IIPassWord = IIPassWord.Trim();
            Referee = Referee.Trim();
            int mobileInt;

            if (Mobile.Contains("+"))
            {
                Mobile = Mobile.Replace("+", "");
                mobileInt = 1;
            }
            else
            {
                mobileInt = 0;
            }


            ShopNum1_Member member = new ShopNum1_Member();
            DataTable YzMemLoginID = ShopNum1_Member_Action.KceYzMember(MemloginID);
            if (YzMemLoginID == null || YzMemLoginID.Rows.Count == 0)
            {
                member.MemLoginID = MemloginID;

            }
            else
            {

                return GetString("GZ12");
            }

            if (Referee == "")
            {

                return GetString("GZ13");
            }
            if (Name == "")
            {

                return GetString("GZ14");
            }
            if (PassWord == "")
            {

                return GetString("GZ15");
            }
            if (IIPassWord == "")
            {

                return GetString("GZ16");
            }
            DataTable YzReferee = ShopNum1_Member_Action.KceYzReferee(Referee);
            string cccd = "";
            if (YzReferee == null || YzReferee.Rows.Count < 1)
            {

                return GetString("GZ17");
            }
            else
            {
                member.Superior = YzReferee.Rows[0]["MemLoginID"].ToString();
                cccd = YzReferee.Rows[0]["MemLoginID"].ToString();
            }
            member.MemLoginID = MemloginID;
            member.Mobile = Mobile;
            member.RealName = "";
            member.Email = "";
            member.Name = Name;
            member.IsForbid = 0;
            member.MemberType = 1;
            member.IdentityCard = "";//用户身份证号
            member.MemLoginNO = member.MemLoginID;
            member.Pwd = ShopNum1.Common.Encryption.GetMd5Hash(PassWord);
            member.PayPwd = Common.Encryption.GetMd5SecondHash(IIPassWord);
            member.Guid = Guid.NewGuid();
            member.AdvancePayment = 0;
            member.AddressValue = "";
            member.AddressCode = "";
            member.RegeDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            member.LoginDate = null;
            member.IsMobileActivation = 0;
            member.IsEmailActivation = "0";
            member.PromotionMemLoginID = "";
            member.Score_hv = 0;
            member.IsMailActivation = 0;
            member.MemberRank = 0;
            member.MemberRankGuid = new Guid("a6da75ad-e1ac-4df8-99ad-980294a16581");
            member.Score = 0;
            member.LastLoginIP = null;
            member.LoginTime = 1;
            member.AdvancePayment = 0;
            member.LockAdvancePayment = 0;
            member.LockSocre = 0;
            member.CostMoney = 0;
            member.mobiletype = mobileInt;
            member.RecoMember = member.Superior;
            member.Score1 = 0;
            member.Score2 = 0;
            member.Score3 = 0;
            member.Score4 = 0;
            member.Score5 = 0;
            member.Score6 = 0;

            //string fh = Post(postUrl);
            string fh1 = Post("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=new_account");
            //string fh2 = Post("http://api.ikex8.com/api.php?api_key=WGHaN3trZHGkUF7x&action=new_account");
            if (fh1 != "" )
            {
                member.ETHAddress = fh1.Trim();
                member.NECAddress = fh1.Trim();
                if (ShopNum1_Member_Action.AddMJC(member) == 1)
                {
                    DataTable TJRtable = ShopNum1_Member_Action.SearchMembertwo(cccd);
                    DataTable ZJtable = ShopNum1_Member_Action.SearchMembertwo(member.MemLoginID);
                    string code = TJRtable.Rows[0]["RecoCode"].ToString() + ZJtable.Rows[0]["ID"].ToString() + ",";
                    ShopNum1_Member_Action.updateRecoCode(member.MemLoginID, code);
                    return "S" + member.MemLoginID;
                }
                else
                {

                    return GetString("GZ18");
                }
            }


            else
            {
                return GetString("GZ19");

            }



        }
        /// <summary>
        /// 交易大厅查询买单
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="StartPage"></param>
        /// <param name="EndPage"></param>
        /// <returns></returns>
        public DataTable SelectOrderNumberBuy(string MemLoginID, string Number, string StartPage, string EndPage)
        {

            DataTable table = new DataTable();
            DataTable ZJtable = ShopNum1_Member_Action.SearchMembertwo(MemLoginID);
            string recomember = ZJtable.Rows[0]["RecoMember"].ToString();
            string Superior = ZJtable.Rows[0]["Superior"].ToString();
            string code = "";
            if (recomember == "")
            {
                for (int i = 0; i < 99999999; i++)
                {

                    DataTable TJRtable = ShopNum1_Member_Action.SearchMembertwo(Superior);
                    if (TJRtable.Rows[0]["RecoMember"].ToString() != "")
                    {
                        code = TJRtable.Rows[0]["RecoCode"].ToString();
                        i = 99999999;
                    }
                    else
                    {
                        Superior = TJRtable.Rows[0]["Superior"].ToString();
                    }
                }
            }
            else
            {
                DataTable TJRtable = ShopNum1_Member_Action.SearchMembertwo(recomember);
                code = TJRtable.Rows[0]["RecoCode"].ToString();
            }
            table = ShopNum1_OrderInfo_Action.SelectOrderNumberBuy(MemLoginID, Number, StartPage, EndPage, code);
            //table = ShopNum1_OrderInfo_Action.SelectOrderNumberBuy(MemLoginID, Number, StartPage, EndPage);
            return table;


        }
        /// <summary>
        /// 交易大厅查询卖单
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="StartPage"></param>
        /// <param name="EndPage"></param>
        /// <returns></returns>
        public DataTable SelectOrderNumberSell(string MemLoginID, string Number, string StartPage, string EndPage)
        {

            DataTable table = new DataTable();
            DataTable ZJtable = ShopNum1_Member_Action.SearchMembertwo(MemLoginID);
            string recomember = ZJtable.Rows[0]["RecoMember"].ToString();
            string Superior = ZJtable.Rows[0]["Superior"].ToString();
            string code = "";
            if (recomember == "")
            {
                for (int i = 0; i < 99999999; i++)
                {

                    DataTable TJRtable = ShopNum1_Member_Action.SearchMembertwo(Superior);
                    if (TJRtable.Rows[0]["RecoMember"].ToString() != "")
                    {
                        code = TJRtable.Rows[0]["RecoCode"].ToString();
                        i = 99999999;
                    }
                    else
                    {
                        Superior = TJRtable.Rows[0]["Superior"].ToString();
                    }
                }
            }
            else
            {
                DataTable TJRtable = ShopNum1_Member_Action.SearchMembertwo(recomember);
                code = TJRtable.Rows[0]["RecoCode"].ToString();
            }

            table = ShopNum1_OrderInfo_Action.SelectOrderNumberSell(MemLoginID, Number, StartPage, EndPage, code);
            //table = ShopNum1_OrderInfo_Action.SelectOrderNumberSell(MemLoginID, Number, StartPage, EndPage);

            return table;


        }

        public string PayOrderInfo(string MemLoginID, string OrderNumber, string IIPassWord)
        {
            DataTable MemberTable = ShopNum1_Member_Action.SearchMembertwo(MemLoginID);
            string MyIIPassWord = MemberTable.Rows[0]["PayPwd"].ToString();
            decimal MyUSDT = Convert.ToDecimal(MemberTable.Rows[0]["AdvancePayment"]);
            decimal MyNEC = Convert.ToDecimal(MemberTable.Rows[0]["Score_dv"]);

            DataTable OrderTable = ShopNum1_OrderInfo_Action.SerchOrderInfoKCEAll(OrderNumber);
            string shopid = OrderTable.Rows[0]["MemLoginID"].ToString();
            string typeid = OrderTable.Rows[0]["ShipmentStatus"].ToString();
            string orderstatus = OrderTable.Rows[0]["OderStatus"].ToString();
            decimal NEC = Convert.ToDecimal(OrderTable.Rows[0]["ShouldPayPrice"]);
            decimal USDT = Convert.ToDecimal(OrderTable.Rows[0]["Score_pv_b"]);

            DataTable ShopTable = ShopNum1_Member_Action.SearchMembertwo(shopid);
            decimal ShopUSDT = Convert.ToDecimal(ShopTable.Rows[0]["AdvancePayment"]);
            decimal ShopNEC = Convert.ToDecimal(ShopTable.Rows[0]["Score_hv"]);

            if (IIPassWord == "")
            {
                return GetString("MG000010");
            }
            else
            {
                string md5SecondHash = Common.Encryption.GetMd5SecondHash(IIPassWord.Trim());
                if (MyIIPassWord != md5SecondHash)
                {
                    return GetString("MG000010");

                }
                else
                {
                    if (MemLoginID == shopid)
                    {
                        return GetString("MG000032");
                    }
                    else
                    {

                        if (typeid == "1")
                        {
                            if (NEC > MyNEC)
                            {
                                return GetString("MG000013");
                            }
                            else
                            {
                                #region 支付NEC购买USDT
                                if (orderstatus == "1")
                                {
                                    int fh = ShopNum1_OrderInfo_Action.KCE_PayOrderInfo(OrderNumber, MemLoginID, shopid, DateTime.Now, typeid, NEC, USDT, MyUSDT, MyNEC, ShopUSDT, ShopNEC);
                                    return fh.ToString();

                                }
                                else
                                {
                                    return GetString("MG000033");
                                }
                                #endregion
                            }




                        }
                        else if (typeid == "2")
                        {
                            if (USDT > MyUSDT)
                            {
                                return GetString("MG000034");
                            }
                            else
                            {
                                #region 支付USDT购买NEC
                                if (orderstatus == "1")
                                {
                                    int fh = ShopNum1_OrderInfo_Action.KCE_PayOrderInfo(OrderNumber, MemLoginID, shopid, DateTime.Now, typeid, NEC, USDT, MyUSDT, MyNEC, ShopUSDT, ShopNEC);
                                    return fh.ToString();

                                }
                                else
                                {
                                    return GetString("MG000033");
                                }
                                #endregion
                            }
                        }
                        else
                        {
                            return GetString("MG000035");
                        }
                    }


                }
            }





        }
        public string PostDataGetHtml(string uri, string postData)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(postData);

                Uri uRI = new Uri(uri);
                HttpWebRequest req = WebRequest.Create(uRI) as HttpWebRequest;
                req.Method = "POST";
                req.KeepAlive = true;
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = data.Length;
                req.AllowAutoRedirect = true;

                Stream outStream = req.GetRequestStream();
                outStream.Write(data, 0, data.Length);
                outStream.Close();

                HttpWebResponse res = req.GetResponse() as HttpWebResponse;
                Stream inStream = res.GetResponseStream();
                StreamReader sr = new StreamReader(inStream, Encoding.UTF8);
                string htmlResult = sr.ReadToEnd();

                return htmlResult;
            }
            catch (Exception ex)
            {
                return "网络错误：" + ex.Message.ToString();
            }
        }
        public string Post(string url)
        {
            string strURL = url;

            //创建一个HTTP请求 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式 
            request.Method = "POST";
            //内容类型
            request.ContentType = "json";

            //设置参数，并进行URL编码 
            //虽然我们需要传递给服务器端的实际参数是JsonParas(格式：[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}])，
            //但是需要将该字符串参数构造成键值对的形式（注："paramaters=[{\"UserID\":\"0206001\",\"UserName\":\"ceshi\"}]"），
            //其中键paramaters为WebService接口函数的参数名，值为经过序列化的Json数据字符串
            //最后将字符串参数进行Url编码
            string paraUrlCoded = System.Web.HttpUtility.UrlEncode("paramaters");
            paraUrlCoded += "=" + System.Web.HttpUtility.UrlEncode("");

            byte[] payload;
            //将Json字符串转化为字节 
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength  
            request.ContentLength = payload.Length;
            //发送请求，获得请求流 

            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                Console.Write("连接服务器失败!");
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流

            String strValue = "";//strValue为http响应所返回的字符流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            Stream s = response.GetResponseStream();

            //服务器端返回的是一个XML格式的字符串，XML的Content才是我们所需要的Json数据

            StreamReader Reader = new StreamReader(s);

            strValue = Reader.ReadToEnd();//取出Content中的Json数据
            Reader.Close();
            s.Close();

            return strValue;//返回Json数据
        }

        public string GET(string url)
        {


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string jsonstr = stream.ReadLine();


            return jsonstr;//返回Json数据
        }


        /// <summary>
        /// 查询OK交易所价格
        /// </summary>
        /// 
        /// <returns></returns>
        public BtypePrice SelectBiZongPrice(string Bizhong)
        {
            

            string btype = Bizhong.Trim().ToUpper() + "-USDT";


            string fh = GET("https://www.okex.me/api/spot/v3/instruments/" + btype + "/ticker");
            JObject studentsJson = JObject.Parse(fh);
            string fhh = studentsJson["last"].ToString();
            decimal zfj = (Convert.ToDecimal(studentsJson["last"].ToString()) - Convert.ToDecimal(studentsJson["open_24h"].ToString())) / Convert.ToDecimal(studentsJson["open_24h"].ToString());
            BtypePrice bt = new BtypePrice();
            bt.Price = fhh;
            bt.ZFJ = zfj.ToString();
            return bt;
        }
        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public DataTable ToDataTableTwo(string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        //Columns
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        //Rows
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }
                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }

        /// <summary>
        /// 根据Url获取页面所有内容
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <returns>返回页面的内容</returns>
        public string GetContentFromUrl(string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;//获取或设置请求凭据
                Byte[] pageData = client.DownloadData(url); //下载数据
                string pageHtml = System.Text.Encoding.UTF8.GetString(pageData);
                return pageHtml;
            }
            catch (WebException ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 根据Url获取页面所有内容
        /// </summary>
        /// <param name="URL">请求的url</param>
        /// <returns>返回页面的内容</returns>
        public string GetContentFromUrl2(string URL)
        {
            try
            {
                string strBuff = "";
                int byteRead = 0;
                char[] cbuffer = new char[256];
                HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(new Uri(URL));
                HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
                Stream respStream = httpResp.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, System.Text.Encoding.UTF8);
                byteRead = respStreamReader.Read(cbuffer, 0, 256);
                while (byteRead != 0)
                {
                    string strResp = new string(cbuffer, 0, byteRead);
                    strBuff = strBuff + strResp;
                    byteRead = respStreamReader.Read(cbuffer, 0, 256);
                }
                respStream.Close();
                return strBuff;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static string HttpPost(string url, string body)
        {
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";

            byte[] buffer = encoding.GetBytes(body);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
        //获取头部信息
        public static string GetHttpHeader(string header_name)
        {
            string hn = string.Empty;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Headers[header_name]))
            {
                hn = HttpContext.Current.Request.Headers[header_name].ToString();
            }
            return hn;
        }

        public static string GetString(string key)
        {
            string language = Gz_LogicApi.GetHttpHeader("lang");
            string file_name;
            switch (language.ToUpper())
            {
                case "CN": file_name = "CN"; break;
                case "EN": file_name = "US"; break;
                default: file_name = "CN"; break;
            }
            ResourceManager resManager = new ResourceManager("ShopNum1.Deploy.KCELogic." + file_name, typeof(Gz_LogicApi).Assembly);
            return resManager.GetString(key);
        }
    }
}