using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;
namespace ShopNum1.Deploy.Api
{
    /// <summary>
    /// Address 的摘要说明
    /// </summary>
    public class Address : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string code = context.Request.QueryString["AddressCode"] == null
                              ? "0"
                              : context.Request.QueryString["AddressCode"];

            string Type = context.Request.QueryString["type"] == null ? "" : context.Request.QueryString["type"];

            string yzm = context.Request.QueryString["YzCode"] == null ? "" : context.Request.QueryString["YzCode"];

            string num = context.Request.QueryString["num"] == null ? "" : context.Request.QueryString["num"];

            string name = context.Request.QueryString["name"] == null
                              ? ""
                              : HttpUtility.HtmlDecode(context.Request.QueryString["name"]);

            string AddressCode = context.Request.QueryString["code"] == null ? "" : context.Request.QueryString["code"];

            string phone = context.Request.QueryString["phone"] == null ? "" : context.Request.QueryString["phone"];

            string postCode = context.Request.QueryString["postCode"] == null ? "" : context.Request.QueryString["postCode"];

            string adress = context.Request.QueryString["adress"] == null
                                ? ""
                                : HttpUtility.HtmlDecode(context.Request.QueryString["adress"]);

            string email = context.Request.QueryString["email"] == null ? "" : context.Request.QueryString["email"];

            string productGuid = context.Request.QueryString["productGuid"] == null
                                     ? ""
                                     : context.Request.QueryString["productGuid"];


            string proGuid = context.Request.QueryString["proguid"] == null ? "" : context.Request.QueryString["proguid"];
            switch (Type)
            {
                case "adress":
                    context.Response.Write(BindRegionCode(code)); //获取收货地址 三级联动
                    break;
                case "Yzm":
                    context.Response.Write(GetSafecode(yzm)); //验证码
                    break;
                case "order":
                    context.Response.Write(CreateOrder(num, name, AddressCode, phone, postCode, adress, email, productGuid));
                    //验证码
                    break;
                case "kc":
                    context.Response.Write(GetRepertoryCount(proGuid)); //验证码
                    break;
                default:
                    ;
                    break;
            }
        }

        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        //获得库存
        public string GetRepertoryCount(string guid)
        {
            var Shop_ScoreProductNew_Action =
                (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            DataTable dataRepertoryCount = Shop_ScoreProductNew_Action.GetInfoByGuid(guid);
            if (dataRepertoryCount != null && dataRepertoryCount.Rows.Count > 0)
            {
                return dataRepertoryCount.Rows[0]["RepertoryCount"].ToString();
            }
            else
            {
                return "";
            }
        }

        //生成红包订单    
        public string CreateOrder(string num, string name, string code, string phone, string postCode, string adress,
                                  string email, string productGuid)
        {
            string msg = string.Empty;
            string MemLoginID = string.Empty;
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookieShopNum1MemberLogin = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieShopNum1MemberLogin = HttpSecureCookie.Decode(cookieShopNum1MemberLogin);

                //求商品信息
                var Shop_ScoreProductNew_Action =
                    (ShopNum1_Shop_ScoreProduct_Action)LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
                DataTable dataTable = Shop_ScoreProductNew_Action.GetInfoByGuid(productGuid, 1, 1, 0);
                MemLoginID = decodedCookieShopNum1MemberLogin.Values["MemLoginID"];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    var ScoreOrderInfo = new ShopNum1_ScoreOrderInfo();
                    var ord = new Order();
                    string newOrder = ord.CreateOrderNumber();
                    ScoreOrderInfo.Address = code + "|" + adress;
                    ScoreOrderInfo.ConfirmTime = Convert.ToDateTime("1900-1-1");
                    ScoreOrderInfo.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    ScoreOrderInfo.Email = email;
                    ScoreOrderInfo.Guid = Guid.NewGuid();
                    ScoreOrderInfo.IsDeleted = 0;
                    ScoreOrderInfo.MemLoginID = MemLoginID;
                    ScoreOrderInfo.Mobile = phone;
                    ScoreOrderInfo.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    ScoreOrderInfo.ModifyUser = MemLoginID;
                    ScoreOrderInfo.Name = name;
                    ScoreOrderInfo.OderStatus = 0;
                    ScoreOrderInfo.OrderNumber = newOrder;
                    ScoreOrderInfo.Postalcode = postCode;
                    ScoreOrderInfo.ShopMemLoginID = dataTable.Rows[0]["MemLoginID"].ToString(); //商家
                    ScoreOrderInfo.ShopName = ""; //商家名称
                    ScoreOrderInfo.Tel = phone;
                    int allScore = Convert.ToInt32(dataTable.Rows[0]["Score"].ToString()) * Convert.ToInt32(num);
                    ScoreOrderInfo.TotalScore = allScore; //总分
                    ScoreOrderInfo.UserMsg = "兑换红包";

                    //商品
                    var listOrderProduct = new List<ShopNum1_ScoreOrderProduct>();
                    var ScoreOrderProduct = new ShopNum1_ScoreOrderProduct();
                    ScoreOrderProduct.BuyNumber = Convert.ToInt32(num);
                    ScoreOrderProduct.Guid = Guid.NewGuid();
                    ScoreOrderProduct.Name = dataTable.Rows[0]["Name"].ToString(); //商品名
                    ScoreOrderProduct.OrderNumber = newOrder;
                    ScoreOrderProduct.ProductGuid = new Guid(productGuid);
                    ScoreOrderProduct.RepertoryNumber = dataTable.Rows[0]["RepertoryNumber"].ToString(); //商品型号
                    ScoreOrderProduct.Score = allScore; //红包

                    listOrderProduct.Add(ScoreOrderProduct);
                    var ScoreOrderInfo_Action =
                        (ShopNum1_ScoreOrderInfo_Action)LogicFactory.CreateShopNum1_ScoreOrderInfo_Action();

                    try
                    {
                        int check = ScoreOrderInfo_Action.Add(ScoreOrderInfo, listOrderProduct);
                        if (check > 0)
                        {
                            //订单生成成功后扣除红包
                            ScoreOrderInfo_Action.UseUserScore(MemLoginID, allScore.ToString());

                            //生成日志
                            //获取当前红包
                            int UserScore = 0;
                            DataTable dataScore = Shop_ScoreProductNew_Action.GetScoreByMemLoginID(MemLoginID);
                            if (dataScore != null && dataScore.Rows.Count > 0)
                            {
                                UserScore = Convert.ToInt32(dataScore.Rows[0]["Score"]) + allScore;
                            }

                            int lastScore = Convert.ToInt32(dataScore.Rows[0]["Score"]);
                            var ScoreModifyLog_Action =
                                (ShopNum1_ScoreModifyLog_Action)LogicFactory.CreateShopNum1_ScoreModifyLog_Action();
                            var ScoreModifyLog = new ShopNum1_ScoreModifyLog();
                            ScoreModifyLog.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            ScoreModifyLog.CreateUser = MemLoginID;
                            ScoreModifyLog.CurrentScore = UserScore; //当前红包
                            ScoreModifyLog.Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            //ScoreModifyLog.EnteMemLoginID = "";
                            ScoreModifyLog.Guid = Guid.NewGuid();
                            ScoreModifyLog.IsDeleted = 0;
                            ScoreModifyLog.LastOperateScore = lastScore; //最后红包
                            ScoreModifyLog.MemLoginID = MemLoginID;
                            ScoreModifyLog.Memo = "兑换商品消费红包";
                            ScoreModifyLog.OperateScore = allScore;
                            ScoreModifyLog.OperateType = 3; //消费减少
                            //操作
                            ScoreModifyLog_Action.OperateScore(ScoreModifyLog);

                            msg = "ok";
                        }
                        else
                        {
                            msg = "no";
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    msg = "noProduct";
                }


                //会员登录ID
            }
            else
            {
                msg = "nologin";
            }
            return msg;
            //已经登录 
        }


        //验证码
        private string GetSafecode(string verifycodetype)
        {
            if (verifycodetype.ToLower() == HttpContext.Current.Session["code"].ToString().ToLower())
            {
                return "true";
            }

            return "false";
        }


        private string BindRegionCode(string fatherID)
        {
            string ID = fatherID.Split('/')[1];
            int intCodeID = Convert.ToInt32(ID);

            var productCategory_Action =
                (Shop_Category_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Category_Action();
            string GetOption = string.Empty;
            DataTable dataTable = productCategory_Action.GetRegionFatherID(intCodeID.ToString());
            GetOption = "<option value=\"-1\">-请选择-</option> ";
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                GetOption += "<option value=" + dataTable.Rows[i]["Code"] + "/" + dataTable.Rows[i]["ID"] + ">" +
                             dataTable.Rows[i]["Name"] + "</option>";
            }
            return GetOption;
        }
    }
}