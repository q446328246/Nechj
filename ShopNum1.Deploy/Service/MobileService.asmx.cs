using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Text;
using ShopNum1.Common;
using ShopNum1MultiEntity;
using ShopNum1.Deploy.MobileServiceAPP;
using ShopNum1.Interface;
using System.Configuration;
using ShopNum1.Deploy.Api;
using System.Xml;
using System.IO;
using System.Net;

namespace ShopNum1.Deploy.Service
{
    /// <summary>
    /// M_Login 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class MobileService : System.Web.Services.WebService
    {

       


        //登陆
        [WebMethod]
        public void Login(string MemberloginID, string PWD)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable selectMember = member_Action.GetALLMemberAll(MemberloginID, Common.Encryption.GetMd5Hash(PWD));

            MMessage message = new MMessage();
            DateTime newtime = System.DateTime.Now;
            //DateTime newtime = Convert.ToDateTime("2015-01-19");

            if (selectMember.Rows.Count > 0)
            {
                MemberloginID = selectMember.Rows[0]["MemLoginID"].ToString();
                DateTime Oldtime = Convert.ToDateTime(selectMember.Rows[0]["ErrorTime"]);
                int ErrorNum = Convert.ToInt32(selectMember.Rows[0]["ErrorNum"]);
                int NewHouers = Convert.ToInt32(newtime.Subtract(Oldtime).TotalHours);
                if (selectMember.Rows[0]["IsForbid"].ToString() == "1")
                {
                    message.Result = 0;
                    message.Error_code = "用户已经被禁用";
                    message.Error_message = "用户已经被禁用";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();

                }
                else if (ErrorNum >= 5)
                {
                    if (NewHouers >= 1)
                    {
                        DateTime dt = DateTime.Now.AddHours(24);
                        string md5 = MemberloginID + "~" + PWD + "~" + dt;

                        //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                        //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);
                        member_Action.UpdateMemberErrorNumGetNull(MemberloginID);

                        ServiceHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                        message.Data = ShopNum1_M_Member.FromDataRow(selectMember.Rows[0]);//ServiceHelper.M_json(selectGoods);

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_Member));

                        Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                        Context.Response.End();
                    }
                    else
                    {
                        message.Result = 0;
                        message.Error_code = "用户密码错误过次数多已经被禁用";
                        message.Error_message = "用户密码错误次数过多已经被禁用";

                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                        Context.Response.End();
                    }
                }
                else
                {
                    DateTime dt = DateTime.Now.AddHours(720);
                    string md5 = MemberloginID + "~" + PWD + "~" + dt;
                    member_Action.UpdateMemberErrorNumGetNull(MemberloginID);
                    //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                    //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);

                    ServiceHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                    message.Data = ShopNum1_M_Member.FromDataRow(selectMember.Rows[0]);//ServiceHelper.M_json(selectGoods);

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Member));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                    Context.Response.End();
                }

            }
            else
            {

                // Serialize(ContentType);
                message.Result = 0;
                message.Error_code = "密码或者账户可能有误";
                message.Error_message = "密码或者账户可能有误";
                member_Action.UpdateMemberErrorNum(MemberloginID, 1);
                member_Action.UpdateMembeErrorTime(MemberloginID, newtime);
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }



        }

        //购物车邮费
        [WebMethod]
        public void PostPriceCar(string ShopID, int ShopCategoryID, string ProductGuids, string MemloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemloginID.ToUpper())
            {

                try
                {
                    ConfirmOrderAPP cc = new ConfirmOrderAPP();
                    string rult = cc.PostPriceCar(ShopID, ShopCategoryID, ProductGuids, MemloginID);
                    message.Result = 1;
                    message.Succeed_code = rult;
                    message.Succeed_message = "邮费";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);                  
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }


        }
        //单个邮费
        [WebMethod]
        public void PostPriceDan(int ShopCategoryID, string ProductGuids, int BuyNumber, string MemloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemloginID.ToUpper())
            {

                try
                {
                    ConfirmOrderAPP cc = new ConfirmOrderAPP();
                    string rult = cc.PostPriceDan(ShopCategoryID, ProductGuids, BuyNumber, MemloginID);

                    message.Result = 1;
                    message.Succeed_code = rult;
                    message.Succeed_message = "邮费";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);                  
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }


        }
        //登陆
        [WebMethod]
        public void Logintwo(string MemberloginID, string PWD, string MyToken)
        {
            ShopNum1_Member_Action member_Action = (ShopNum1_Member_Action)ShopNum1.Factory.LogicFactory.CreateShopNum1_Member_Action();
            DataTable selectMember = member_Action.GetALLMemberAll(MemberloginID, Common.Encryption.GetMd5Hash(PWD));
            MemberloginID = selectMember.Rows[0]["MemLoginID"].ToString();
            MMessage message = new MMessage();
            DateTime newtime = System.DateTime.Now;
            //DateTime newtime = Convert.ToDateTime("2015-01-19");

            if (selectMember.Rows.Count > 0)
            {
                DateTime Oldtime = Convert.ToDateTime(selectMember.Rows[0]["ErrorTime"]);
                int ErrorNum = Convert.ToInt32(selectMember.Rows[0]["ErrorNum"]);
                int NewHouers = Convert.ToInt32(newtime.Subtract(Oldtime).TotalHours);
                if (selectMember.Rows[0]["IsForbid"].ToString() == "1")
                {
                    message.Result = 0;
                    message.Error_code = "用户已经被禁用";
                    message.Error_message = "用户已经被禁用";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();

                }
                else if (ErrorNum >= 5)
                {
                    if (NewHouers >= 1)
                    {
                        DateTime dt = DateTime.Now.AddHours(24);
                        string md5 = MemberloginID + "~" + PWD + "~" + dt;

                        //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                        //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);
                        member_Action.UpdateMemberErrorNumGetNull(MemberloginID);

                        ServiceHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                        message.Data = ShopNum1_M_Member.FromDataRow(selectMember.Rows[0]);//ServiceHelper.M_json(selectGoods);

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_M_Member));

                        Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                        Context.Response.End();
                    }
                    else
                    {
                        message.Result = 0;
                        message.Error_code = "用户密码错误过次数多已经被禁用";
                        message.Error_message = "用户密码错误次数过多已经被禁用";

                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                        Context.Response.End();
                    }
                }
                else
                {
                    DateTime dt = DateTime.Now.AddHours(720);
                    string md5 = MemberloginID + "~" + PWD + "~" + dt;
                    member_Action.UpdateMemberErrorNumGetNull(MemberloginID);
                    //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                    //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);
                    string MemLoginNO_token = selectMember.Rows[0]["MemLoginNO"].ToString();
                    DataTable selectMobileToken = member_Action.SelectMobileToken(MemLoginNO_token);
                    if (selectMobileToken != null && selectMobileToken.Rows.Count > 0)
                    {
                        member_Action.UpdateMobileToken(MemLoginNO_token, MyToken);
                    }
                    else
                    {

                        member_Action.AddMobileToken(MemLoginNO_token, MemberloginID, MyToken);
                    }
                    ServiceHelper.AddColumnAndStringValue(selectMember, "LoginToken", ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5));

                    message.Data = ShopNum1_M_Member.FromDataRow(selectMember.Rows[0]);//ServiceHelper.M_json(selectGoods);

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Member));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                    Context.Response.End();
                }

            }
            else
            {

                // Serialize(ContentType);
                message.Result = 0;
                message.Error_code = "密码或者账户可能有误";
                message.Error_message = "密码或者账户可能有误";
                member_Action.UpdateMemberErrorNum(MemberloginID, 1);
                member_Action.UpdateMembeErrorTime(MemberloginID, newtime);
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }



        }


        //通过专区号查询商品详细
        [WebMethod]
        public void SelectProdctByShop_category_id(string Shop_category_id, int StartNumber, int OrderNumber)
        {
            DataTable selectProducet = new DataTable();
            MMessage message = new MMessage();
            try
            {
                selectProducet = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProdctShop_category_id(Shop_category_id, StartNumber, OrderNumber);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
            if (selectProducet.Rows.Count > 0)
            {

                try
                {

                    message.Data = ShopNum1_M_Producet.FromDataRowGetProductByShop_category_id(selectProducet);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Producet));
                    types.Add(typeof(List<ShopNum1_M_Producet>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Error_code = "参数错误";
                    message.Error_message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Error_code = "没有更多商品";
                message.Error_message = "没有更多商品";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }

        }


        //取消订单
        [WebMethod]
        public void CancelOrderNumber(string ordernumber, string MemloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == MemloginID.ToUpper())
            {

                try
                {
                    ConfirmOrderAPP cc = new ConfirmOrderAPP();
                    string rult = cc.CancelOrderNumber(ordernumber);



                    switch (rult)
                    {
                        case "1":
                            message.Result = 1;
                            message.Error_code = "订单取消成功";
                            message.Error_message = "订单取消成功";
                            break;
                        case "0":
                            message.Result = 0;
                            message.Error_code = "订单取消失败";
                            message.Error_message = "订单取消失败";
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "订单不存在";
                            message.Error_message = "订单不存在";
                            break;
                        default:
                            message.Succeed_code = "未知错误";
                            message.Succeed_message = "未知错误";
                            message.Result = 0;
                            break;
                    }

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);                  
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }


        }
        //删除订单    type=1  买家删除订单    type=2    卖家删除订单
        [WebMethod]
        public void DeleteBuyOrder(string ordernum, int Type, string memloginId)
        {
            int selectProducet = 0;
            MMessage message = new MMessage();
            try
            {
                selectProducet = ((ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action()).DeleteOrderInfoByOrdernum(ordernum, Type, memloginId);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
            if (selectProducet == 1)
            {

                try
                {

                    message.Result = 1;
                    message.Error_code = "订单删除成功";
                    message.Error_message = "订单删除成功";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Error_code = "参数错误";
                    message.Error_message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Error_code = "订单删除失败";
                message.Error_message = "订单删除失败";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }

        }


        //通过专区号查询商品详细(傻逼老刘强迫改的)
        [WebMethod]
        public void SelectProdctByShop_category_id_two(string Shop_category_id, int StartNumber, int OrderNumber, string memloginid)
        {
            DataTable selectProducet = new DataTable();
            MMessage message = new MMessage();
            try
            {
                selectProducet = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProdctShop_category_idddd(Shop_category_id, StartNumber, OrderNumber, memloginid);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
            if (selectProducet.Rows.Count > 0)
            {

                try
                {

                    message.Data = ShopNum1_M_two_product.FromDataRowGetProductByShop_category_id(selectProducet);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_two_product));
                    types.Add(typeof(List<ShopNum1_M_two_product>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Error_code = "参数错误";
                    message.Error_message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Error_code = "没有更多商品";
                message.Error_message = "没有更多商品";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }

        }


        //通过专区号查询商品详细(傻逼老刘强迫改的)
        [WebMethod]
        public void SelectProdctByShop_category_id_free(string Shop_category_id, int StartNumber, int OrderNumber, string memloginid)
        {
            DataTable selectProducet = new DataTable();
            MMessage message = new MMessage();
            try
            {
                selectProducet = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProdctShop_category_idddd(Shop_category_id, StartNumber, OrderNumber, memloginid);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
            if (selectProducet.Rows.Count > 0)
            {

                try
                {

                    message.Data = ShopNum1_M_two_product.FromDataRowGetProductByShop_category_id(selectProducet);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_two_product));
                    types.Add(typeof(List<ShopNum1_M_two_product>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Error_code = "参数错误";
                    message.Error_message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Error_code = "没有更多商品";
                message.Error_message = "没有更多商品";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }

        }
        /// <summary>
        /// 郭泽首页三个推荐产品
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="shop_category_id"></param>
        [WebMethod]
        public void SelectProdctByThree()
        {

            string Shop1 = ShopSettings.Shopm1.Substring(44, 36);
            string Shop2 = ShopSettings.Shopm2.Substring(44, 36);
            string Shop3 = ShopSettings.Shopm3.Substring(44, 36);

            string Guid = "'" + Shop1 + "','" + Shop2 + "','" + Shop3 + "'";

            DataTable selectProducet = new DataTable();
            MMessage message = new MMessage();
            try
            {
                selectProducet = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProdctThreeG(Guid);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
            if (selectProducet.Rows.Count > 0)
            {

                try
                {

                    message.Data = ShopNum1_M_Producet.FromDataRowGetProductByShop_category_id(selectProducet);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Producet));
                    types.Add(typeof(List<ShopNum1_M_Producet>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Error_code = "参数错误";
                    message.Error_message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Error_code = "输入专区号有误没查询到商品";
                message.Error_message = "输入专区号有误没查询到商品";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }

        }
        //查询商品通过id
        [WebMethod]
        public void SelectProdctByID(string ID, int shop_category_id)
        {
            MMessage message = new MMessage();
            DataTable selectProducetByID = new DataTable();
            try
            {
                int myID = Convert.ToInt32(ID);
                selectProducetByID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProdctByID_two(myID, shop_category_id);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }

            if (selectProducetByID.Rows.Count > 0)
            {
                try
                {

                    message.Data = ShopNum1_M_Producet.FromDataRowGetProductByShop_category_id(selectProducetByID).ToArray();

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Producet));
                    types.Add(typeof(ShopNum1_M_Producet[]));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Error_code = "参数错误";
                    message.Error_message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
            }
            else
            {

                message.Error_code = "输入ID有误没查询到商品";
                message.Error_message = "输入ID有误没查询到商品";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }

            Context.Response.End();
        }

        //查询商品通过店铺编号
        [WebMethod]
        public void SelectProdctByShopID(string ShopID)
        {
            MMessage message = new MMessage();
            DataTable selectProducetByID = new DataTable();
            try
            {
                selectProducetByID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProdctByShopID(ShopID);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }

            if (selectProducetByID.Rows.Count > 0)
            {
                try
                {

                    message.Data = ShopNum1_M_Producet.FromDataRowGetProductByShop_category_id(selectProducetByID).ToArray();

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Producet));
                    types.Add(typeof(ShopNum1_M_Producet[]));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Error_code = "参数错误";
                    message.Error_message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
            }
            else
            {

                message.Error_code = "输入店铺ID有误没查询到商品";
                message.Error_message = "输入店铺ID有误没查询到商品";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }

            Context.Response.End();
        }





        //查询商品通过guid

        [WebMethod]
        public void SelectProdctByGUID(string guid, int shop_category_id)
        {
            MMessage message = new MMessage();
            DataTable selectProducetByID = new DataTable();
            try
            {

                selectProducetByID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProdctByguid_two(guid, shop_category_id);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }

            if (selectProducetByID.Rows.Count > 0)
            {
                try
                {

                    message.Data = ShopNum1_M_Producet.FromDataRowGetProductByShop_category_id(selectProducetByID).ToArray();

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Producet));
                    types.Add(typeof(ShopNum1_M_Producet[]));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Error_code = "参数错误";
                    message.Error_message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
            }
            else
            {

                message.Error_code = "输入ID有误没查询到商品";
                message.Error_message = "输入ID有误没查询到商品";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }

            Context.Response.End();
        }
        //通过ID查他所有信息
        [WebMethod]
        public void SelectMemberInfoAllByMemloginID(string memberloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    DataTable SelectMemberInfoAllByMemberLoingID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberInfoByMemloginID(memberloginID);

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Member));
                    message.Data = ShopNum1_M_Member.FromDataRowGetMoney(SelectMemberInfoAllByMemberLoingID.Rows[0]);
                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);                  
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }

        }
        //查询这个帐号的地址信息
        [WebMethod]
        public void SelectAddressByMemberloginID(string memberloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    DataTable SelectAddressByMemloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectAddressByMemberloginID(memberloginID);

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Address));
                    types.Add(typeof(List<ShopNum1_M_Address>));
                    message.Data = ShopNum1_M_Address.FromDataRowGetAddressByMemloginID(SelectAddressByMemloginID);
                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }
        //查询他的系统信息
        [WebMethod]
        public void SelectUserMessageBymemberloginID(string memberloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    DataTable SelectAddressByMemloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectUserMessageByMemberloginID(memberloginID);

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_UserMessage));
                    types.Add(typeof(List<ShopNum1_M_UserMessage>));
                    message.Data = ShopNum1_M_UserMessage.FromDataRowGetUserMessage(SelectAddressByMemloginID);
                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //查询这个人是不是有权限访问
        [WebMethod]
        public void SelectMemberRank_LinkCategory(string memberloginID, string token, int IsReadOrBuy, int Category_ID)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                DataTable MemberInfoByMemloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberInfoByMemloginID(memberloginID);
                string MemberRankGuid = MemberInfoByMemloginID.Rows[0]["MemberRankGuid"].ToString();
                DataTable MemberRank_LinkCategory = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectMemberRank_LinkCategory(MemberRankGuid, IsReadOrBuy, Category_ID);
                if (MemberRank_LinkCategory == null || MemberRank_LinkCategory.Rows.Count == 0)
                {
                    try
                    {
                        message.Result = 0;
                        message.Error_code = "当前等级没有权限进行操作";
                        message.Error_message = "当前等级没有权限进行操作";

                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                    }
                    catch (Exception ex)
                    {

                        message.Result = 0;
                        message.Error_code = ex.Message;
                        message.Error_message = ex.Message;

                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                    }
                    Context.Response.End();
                }
                else
                {
                    message.Result = 1;
                    message.Succeed_code = "可以进行";
                    message.Succeed_message = "可以进行";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }


            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //查询这个人的所有订单
        [WebMethod]
        public void SelectOrderByMemberloginID(string memberloginID, string token, int startnum, int ordernumber)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    DataTable OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderByMemberloginID(memberloginID, startnum, ordernumber);


                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_Mobile_Order));
                    types.Add(typeof(List<ShopNum1_Mobile_Order>));
                    types.Add(typeof(List<ShopNum1_M_OrderProduct>));

                    List<ShopNum1_Mobile_Order> orders = ShopNum1_Mobile_Order.FromDataRowGetOrder(OrderByMemberloginID);

                    foreach (ShopNum1_Mobile_Order order in orders)
                    {
                        order.OrderProduct = ShopNum1_M_OrderProduct.FromDataRowOrderProduct(((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderProductByOrderInfoGuid(order.Guid));

                    }

                    message.Data = orders;
                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //通过订单状态查询这个人的订单
        [WebMethod]
        public void SelectOrderByMemberloginIDAndOrderStyle(string memberloginID, string token, int startnum, int ordernumber, string OrderStyle)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    DataTable OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderByMemberloginIDAndOrderStyle(memberloginID, startnum, ordernumber, OrderStyle);


                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_Mobile_Order));
                    types.Add(typeof(List<ShopNum1_Mobile_Order>));
                    types.Add(typeof(List<ShopNum1_M_OrderProduct>));

                    List<ShopNum1_Mobile_Order> orders = ShopNum1_Mobile_Order.FromDataRowGetOrder(OrderByMemberloginID);

                    foreach (ShopNum1_Mobile_Order order in orders)
                    {
                        order.OrderProduct = ShopNum1_M_OrderProduct.FromDataRowOrderProduct(((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderProductByOrderInfoGuid(order.Guid));

                    }

                    message.Data = orders;
                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //通过退款状态查询这个人的订单
        [WebMethod]
        public void SelectOrderByReFund(string memberloginID, string token, int startnum, int endnumber, string Refundstyle)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    if (Refundstyle == "1")
                    {
                        DataTable OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderRefundMobileOne(memberloginID, startnum, endnumber);


                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_Mobile_Order));
                        types.Add(typeof(List<ShopNum1_Mobile_Order>));
                        types.Add(typeof(List<ShopNum1_M_OrderProduct>));

                        List<ShopNum1_Mobile_Order> orders = ShopNum1_Mobile_Order.FromDataRowGetOrder(OrderByMemberloginID);

                        foreach (ShopNum1_Mobile_Order order in orders)
                        {
                            order.OrderProduct = ShopNum1_M_OrderProduct.FromDataRowOrderProduct(((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderProductByOrderInfoGuid(order.Guid));

                        }

                        message.Data = orders;
                        Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                    }
                    else if (Refundstyle == "2")
                    {
                        DataTable OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderRefundMobileTwo(memberloginID, startnum, endnumber);


                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_Mobile_Order));
                        types.Add(typeof(List<ShopNum1_Mobile_Order>));
                        types.Add(typeof(List<ShopNum1_M_OrderProduct>));

                        List<ShopNum1_Mobile_Order> orders = ShopNum1_Mobile_Order.FromDataRowGetOrder(OrderByMemberloginID);

                        foreach (ShopNum1_Mobile_Order order in orders)
                        {
                            order.OrderProduct = ShopNum1_M_OrderProduct.FromDataRowOrderProduct(((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderProductByOrderInfoGuid(order.Guid));

                        }

                        message.Data = orders;
                        Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                    }
                    else
                    {
                        DataTable OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderRefundMobileThree(memberloginID, startnum, endnumber);


                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_Mobile_Order));
                        types.Add(typeof(List<ShopNum1_Mobile_Order>));
                        types.Add(typeof(List<ShopNum1_M_OrderProduct>));

                        List<ShopNum1_Mobile_Order> orders = ShopNum1_Mobile_Order.FromDataRowGetOrder(OrderByMemberloginID);

                        foreach (ShopNum1_Mobile_Order order in orders)
                        {
                            order.OrderProduct = ShopNum1_M_OrderProduct.FromDataRowOrderProduct(((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderProductByOrderInfoGuid(order.Guid));

                        }

                        message.Data = orders;
                        Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                    }

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //查询一个订单号的guid对应的订单
        [WebMethod]
        public void SelectOrderProductByOrderInfoGuid(string OrderInfoGuid, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try
                {
                    DataTable OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderProductByOrderInfoGuid(OrderInfoGuid);


                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_OrderProduct));
                    types.Add(typeof(List<ShopNum1_M_OrderProduct>));
                    message.Data = ShopNum1_M_OrderProduct.FromDataRowOrderProduct(OrderByMemberloginID);
                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //显示这个人的订单个数

        [WebMethod]
        public void SelectOrderByMemberloginID_GetCount(string memberloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    DataTable OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderByMemberloginID_GetCount(memberloginID);


                    message.Succeed_code = OrderByMemberloginID.Rows[0]["OrderCount"];
                    message.Succeed_message = "成功";
                    message.Result = 1;
                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //穿件订单
        [WebMethod]
        public void CreateOrder(string token, string ServiceAgent, string MemloginID, int ShopCategoryID, int PayMentType, string ProductGuid, int BuyNumber, decimal PostPrice, string Color, string Size, string AddressGuid, string TextBoxMessage, string InvoiceType)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemloginID.ToUpper())
            {
                try
                {
                    string order = cnfirmOrderAPP.CreateOrder(ServiceAgent, MemloginID, ShopCategoryID, PayMentType, ProductGuid, BuyNumber, PostPrice, Color, Size, AddressGuid, TextBoxMessage, InvoiceType);

                    switch (order)
                    {
                        case "1":
                            message.Result = 0;
                            message.Error_code = "购买失败";
                            message.Error_message = "购买失败";
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "请填写正确的服务商";
                            message.Error_message = "请填写正确的服务商";
                            break;
                        case "3":
                            message.Result = 0;
                            message.Error_code = "支付方式不能为空";
                            message.Error_message = "支付方式不能为空";
                            break;
                        case "4":
                            message.Result = 0;
                            message.Error_code = "价格应处于￥105700-￥106300之间";
                            message.Error_message = "价格应处于￥105700-￥106300之间";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Error_code = "价格应该处于￥35900-￥36100之间";
                            message.Error_message = "价格应该处于￥35900-￥36100之间";
                            break;
                        case "6":
                            message.Result = 0;
                            message.Error_code = "收货地址错误";
                            message.Error_message = "收货地址错误";
                            break;
                        case "7":
                            message.Result = 0;
                            message.Error_code = "支付方式错误";
                            message.Error_message = "支付方式错误";
                            break;
                        case "8":
                            message.Result = 0;
                            message.Error_code = "很抱歉,抢购商品一个ID限购一件！";
                            message.Error_message = "很抱歉,抢购商品一个ID限购一件！";
                            break;
                        case "9":
                            message.Result = 0;
                            message.Error_code = "很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！";
                            message.Error_message = "很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！";
                            break;
                        case "111":
                            message.Result = 0;
                            message.Error_code = "10062";
                            message.Error_message = "服务代理不存在！";
                            break;
                        case "222":
                            message.Result = 0;
                            message.Error_code = "10063";
                            message.Error_message = "服务代理错误！";
                            break;

                        default:
                            message.Succeed_code = order;
                            message.Succeed_message = order;
                            message.Result = 1;
                            break;
                    }

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //添加购物车
        [WebMethod]
        public void AddShopCar(string MyMemLoginID, string category, string Num, string guid, string Size, string Color, string token)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MyMemLoginID.ToUpper())
            {
                try
                {
                    string order = cnfirmOrderAPP.AddShopCar(MyMemLoginID, category, Num, guid, Size, Color);
                    switch (order)
                    {
                        case "1":
                            message.Result = 0;
                            message.Error_code = "您的会员等级权限不足!";
                            message.Error_message = "您的会员等级权限不足!";
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "不可添加多个不同专区到购物车!";
                            message.Error_message = "不可添加多个不同专区到购物车!";
                            break;
                        case "3":
                            message.Result = 0;
                            message.Error_code = "不可添加不同店铺商品到购物车!";
                            message.Error_message = "不可添加不同店铺商品到购物车!";
                            break;
                        case "4":
                            message.Result = 0;
                            message.Error_code = "请正确填写购买数量!";
                            message.Error_message = "请正确填写购买数量!";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Error_code = "商品库存不足！";
                            message.Error_message = "商品库存不足！";
                            break;
                        case "6":
                            message.Result = 0;
                            message.Error_code = "您不能添加自己的商品！";
                            message.Error_message = "您不能添加自己的商品！";
                            break;
                        case "7":
                            message.Result = 0;
                            message.Error_code = "添加失败!";
                            message.Error_message = "添加失败!";
                            break;
                        case "8":
                            message.Result = 0;
                            message.Error_code = "购买失败";
                            message.Error_message = "购买失败";
                            break;
                        case "9":
                            message.Result = 0;
                            message.Error_code = "该商品不允许加入购入车与其他商品合买";
                            message.Error_message = "该商品不允许加入购入车与其他商品合买";
                            break;


                        default:
                            message.Succeed_code = order;
                            message.Succeed_message = order;
                            message.Result = 1;
                            break;
                    }
                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //手机APP邮费接口
        [WebMethod]
        public void PostPrice(string ShopID, string token)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try
                {
                    PostPrice post = cnfirmOrderAPP.PostPrice(ShopID);
                    message.FirstHeavyPrice = post.FirstHeavyPrice;
                    message.AfterHeavyPrice = post.AfterHeavyPrice;
                    message.FirstHeavy = post.FirstHeavy;
                    message.Succeed_code = "查询成功";
                    message.Succeed_message = "查询成功";
                    message.Result = 1;
                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }






        //创建购物车订单
        [WebMethod]
        public void CreateOrderCar(string ServiceAgent, string MemloginID, int ShopCategoryID, int PayMentType, string ProductGuids, string AddressGuid, string ShopID, string token, string TextBoxMessage, string InvoiceType)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemloginID.ToUpper())
            {
                try
                {
                    string order = cnfirmOrderAPP.CreateOrderCar(ServiceAgent, MemloginID, ShopCategoryID, PayMentType, ProductGuids, AddressGuid, ShopID, TextBoxMessage, InvoiceType);

                    switch (order)
                    {
                        case "1":
                            message.Result = 0;
                            message.Error_code = "购买失败";
                            message.Error_message = "购买失败";
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "10061";
                            message.Error_message = "服务代理不存在!";
                            break;
                        case "3":
                            message.Result = 0;
                            message.Error_code = "支付方式不能为空";
                            message.Error_message = "支付方式不能为空";
                            break;
                        case "4":
                            message.Result = 0;
                            message.Error_code = "价格应处于￥105700-￥106300之间";
                            message.Error_message = "价格应处于￥105700-￥106300之间";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Error_code = "价格应该处于￥35900-￥36100之间";
                            message.Error_message = "价格应该处于￥35900-￥36100之间";
                            break;
                        case "6":
                            message.Result = 0;
                            message.Error_code = "收货地址错误";
                            message.Error_message = "收货地址错误";
                            break;
                        case "7":
                            message.Result = 0;
                            message.Error_code = "支付方式错误";
                            message.Error_message = "支付方式错误";
                            break;
                        case "8":
                            message.Result = 0;
                            message.Error_code = "很抱歉,抢购商品一个ID限购一件！";
                            message.Error_message = "很抱歉,抢购商品一个ID限购一件！";
                            break;
                        case "9":
                            message.Result = 0;
                            message.Error_code = "很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！";
                            message.Error_message = "很抱歉,商品太火爆了,库存不足,无法完成下面操作哟！";
                            break;
                        case "111":
                            message.Result = 0;
                            message.Error_code = "10059";
                            message.Error_message = "服务代理不存在！";
                            break;
                        case "222":
                            message.Result = 0;
                            message.Error_code = "10060";
                            message.Error_message = "服务代理错误！";
                            break;

                        default:
                            message.Succeed_code = order;
                            message.Succeed_message = order;
                            message.Result = 1;
                            break;
                    }

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }
        //添加地址
        [WebMethod]
        public void ADDAddress(string Name, string Email, string AddressValue, string Area, string AddressCode, string Postalcode, string Tel, string Mobile, string MemLoginID, string Address, string token)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                int num = 0;
                try
                {
                    var shopNum1_Address = new ShopNum1_Address();
                    shopNum1_Address.Guid = Guid.NewGuid();
                    shopNum1_Address.Name = Name;
                    shopNum1_Address.Email = Email;
                    shopNum1_Address.Address = Address;
                    shopNum1_Address.AddressValue = AddressValue;
                    shopNum1_Address.Area = Area;
                    shopNum1_Address.AddressCode = AddressCode;
                    shopNum1_Address.Postalcode = Postalcode;
                    shopNum1_Address.Tel = Tel;
                    shopNum1_Address.Mobile = Mobile;
                    shopNum1_Address.IsDefault = 1;
                    shopNum1_Address.MemLoginID = MemLoginID;
                    shopNum1_Address.CreateUser = MemLoginID;
                    shopNum1_Address.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_Address.ModifyUser = MemLoginID;
                    shopNum1_Address.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    shopNum1_Address.IsDeleted = 0;


                    IShopNum1_Address_Action shopNum1_Address_Action = LogicFactory.CreateShopNum1_Address_Action();
                    num = shopNum1_Address_Action.Add(shopNum1_Address);
                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }


                if (num > 0)
                {
                    message.Result = 1;
                    message.Succeed_code = "添加成功";
                    message.Succeed_message = "添加成功";


                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else
                {
                    message.Result = 0;
                    message.Error_code = "添加失败";
                    message.Error_message = "添加失败";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //充值
        [WebMethod]
        public void MobileServiceRecharge(string token, string MemloginID, decimal RechargeBV, int RechargeType, string UserName, string BankCard, int BankCardType)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemloginID.ToUpper())
            {
                try
                {
                    string order = cnfirmOrderAPP.MobileServiceRecharge(MemloginID, RechargeBV, RechargeType, UserName, BankCard, BankCardType);

                    switch (order)
                    {
                        case "1":
                            message.Result = 0;
                            message.Error_code = "线下充值卡号错误";
                            message.Error_message = "线下充值卡号错误";
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "充值方式错误";
                            message.Error_message = "充值方式错误";
                            break;
                        case "3":
                            message.Result = 0;
                            message.Error_code = "充值失败,请联系管理员";
                            message.Error_message = "充值失败,请联系管理员";
                            break;
                        case "4":
                            message.Result = 1;
                            message.Succeed_code = "线下支付提交成功，请及时汇款";
                            message.Succeed_message = "线下支付提交成功，请及时汇款";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Error_code = "充值金额错误";
                            message.Error_message = "充值金额错误";
                            break;
                        case "6":
                            message.Result = 0;
                            message.Error_code = "目前只有服务站商户可以使用线下充值";
                            message.Error_message = "目前只有服务站商户可以使用线下充值";
                            break;


                        default:
                            message.Succeed_code = order;
                            message.Succeed_message = order;
                            message.Result = 2;
                            break;
                    }

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //付款
        [WebMethod]
        public void Pay(string OrderNumber, string MemloginID, string ScoreHvType, string PayPwd, string token)
        {
            MMessage message = new MMessage();
            PayApp payApp = new PayApp();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemloginID.ToUpper())
            {
                try
                {
                    string order = payApp.Pay(OrderNumber, MemloginID, PayPwd);

                    switch (order)
                    {
                        case "1":
                            message.Result = 0;
                            message.Error_code = "支付密码为空";
                            message.Error_message = "支付密码为空";
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "您输入的交易密码不正确";
                            message.Error_message = "您输入的交易密码不正确";
                            break;
                        case "3":
                            message.Result = 0;
                            message.Error_code = "不明确是否使用红包";
                            message.Error_message = "不明确是否使用红包";
                            break;
                        case "4":
                            message.Result = 0;
                            message.Error_code = "您的交易金额为0，不能使用智付支付";
                            message.Error_message = "您的交易金额为0，不能使用智付支付";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Error_code = "付款金额错误";
                            message.Error_message = "付款金额错误";
                            break;
                        case "6":
                            message.Result = 0;
                            message.Error_code = "您当前帐户上面的金额不足，无法支付";
                            message.Error_message = "您当前帐户上面的金额不足，无法支付";
                            break;
                        case "7":
                            message.Result = 0;
                            message.Error_code = "该订单已经支付";
                            message.Error_message = "该订单已经支付";
                            break;
                        case "8":
                            message.Succeed_code = "支付成功";
                            message.Succeed_message = "支付成功";
                            message.Result = 1;
                            break;


                        default:
                            message.Succeed_code = order;
                            message.Succeed_message = order;
                            message.Result = 2;
                            break;
                    }

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //根据专区号和名字查商品
        [WebMethod]
        public void SelectProductByNameAndShop_category_id(string Shop_category_id, string Name, int SatarNumber, int EndNumber)
        {
            MMessage message = new MMessage();

            try
            {
                DataTable ProductDetil = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProductByNameAndShop_category_id(Shop_category_id, Name, SatarNumber, EndNumber);


                message.Data = ShopNum1_M_Producet.FromDataRowGetProductByShop_category_id(ProductDetil);



                List<Type> types = new List<Type>();
                types.Add(typeof(ShopNum1_M_Producet));
                types.Add(typeof(List<ShopNum1_M_Producet>));

                Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
            Context.Response.End();

        }
        //通过分类号和名字查商品
        [WebMethod]
        public void SelectProductByProductCategoryCodeAndShop_category_id(string shop_category_id, int top, int number, string ProductCategoryCode, string name)
        {
            MMessage message = new MMessage();

            try
            {
                DataTable ProductDetil = new DataTable();
                if (name == "" || name == null)
                {
                    ProductDetil = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProductByProductCategoryCodeAndShop_category_id(shop_category_id, top, number, ProductCategoryCode);
                }
                else
                {
                    ProductDetil = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProductByProductCategoryCodeAndShop_category_idAndName(shop_category_id, top, number, ProductCategoryCode, name);
                }


                message.Data = ShopNum1_M_Producet.FromDataRowGetProductByShop_category_id(ProductDetil);



                List<Type> types = new List<Type>();
                types.Add(typeof(ShopNum1_M_Producet));
                types.Add(typeof(List<ShopNum1_M_Producet>));

                Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
            Context.Response.End();

        }

        //查询所有分类号
        [WebMethod]
        public void SelectAllShopCategory()
        {
            MMessage message = new MMessage();

            try
            {
                DataTable ShopCategory = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectAllShopCategory();


                message.Data = ShopNum1_ShopCategorys.FromDataRowGetAllShopCategorys(ShopCategory);



                List<Type> types = new List<Type>();
                types.Add(typeof(ShopNum1_ShopCategorys));
                types.Add(typeof(List<ShopNum1_ShopCategorys>));

                Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
            Context.Response.End();

        }

        //查询B积分
        [WebMethod]
        public void GetScore_pv_b(string MemLoginID, string token)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    String yy = DateTime.Now.Year.ToString();

                    String mm = DateTime.Now.Month.ToString();

                    String days = DateTime.DaysInMonth(int.Parse(yy), int.Parse(mm)).ToString();

                    DateTime startMonth = DateTime.Parse(yy + "/" + mm + "/1");

                    int year = DateTime.Now.Year;//当前年  
                    int mouth = DateTime.Now.Month;//当前月  

                    int beforeYear = 0;
                    int beforeMouth = 0;
                    if (mouth <= 1)//如果当前月是一月，那么年份就要减1  
                    {
                        beforeYear = year - 1;
                        beforeMouth = 12;//上个月  
                    }
                    else
                    {
                        beforeYear = year;
                        beforeMouth = mouth - 1;//上个月  
                    }
                    DateTime beforeMouthOneDay = Convert.ToDateTime(beforeYear + "-" + beforeMouth + "-" + 1);//上个月第一天  

                    string Score_pv_b_last = Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog",
                 " AND   MemLoginID ='" + MemLoginID + "' and Date<'" + startMonth + "' and Date>'" + beforeMouthOneDay + "'");//上月累计B积分

                    string Score_pv_b = Common.Common.GetNameById("sum(HuoDe_pv_b)-sum(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog",
                   " AND   MemLoginID ='" + MemLoginID + "' and Date>'" + startMonth + "'");//本月累计B积分

                    message.Succeed_code = Score_pv_b_last;
                    message.Succeed_message = Score_pv_b;
                    message.Result = 1;
                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }
        //返回NO的接口 验证的密码身份证
        [WebMethod]
        public string Login_Web_tj88(string MemberloginID, string PWD, string IdentityCard)
        {
            DataTable selectMember = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberAllByIdentityCard(MemberloginID, Common.Encryption.GetMd5Hash(PWD), IdentityCard);
            MMessage message = new MMessage();

            if (selectMember.Rows.Count > 0)
            {
                if (selectMember.Rows[0]["IsForbid"].ToString() == "1")
                {
                    //message.Result = 0;
                    //message.Error_code = "用户已经被禁用";
                    //message.Error_message = "用户已经被禁用";

                    //Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    //Context.Response.End();
                    return "0";
                }
                else
                {
                    //message.Succeed_code = "好的";
                    //message.Succeed_message = "好的";
                    //message.Result = 1;
                    //Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    //Context.Response.End();
                    return selectMember.Rows[0]["MemLoginNO"].ToString();
                }

            }
            else
            {

                //// Serialize(ContentType);
                //message.Result = 0;
                //message.Error_code = "密码或者账户可能有误";
                //message.Error_message = "密码或者账户可能有误";

                //Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                //Context.Response.End();
                return "0";
            }



        }

        //通过订单guid查询订单
        [WebMethod]
        public DataTable LoginidGetAllMember(string MemberLongiNO, string md5)
        {
            DataTable MemberTable = new DataTable();
            DataTable MemberNullTable = new DataTable();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "MemberLongiNO=" + MemberLongiNO + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            if (md5.ToUpper() == md5Check_two.ToUpper())
            {
                MemberTable = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberAll(MemberLongiNO);
                if (MemberTable != null && MemberTable.Rows.Count > 0)
                {
                    return MemberTable;
                }
                else
                {
                    return MemberNullTable;
                }
            }
            else
            {
                return MemberTable;
            }

        }

        //通过订单guid查询订单
        [WebMethod]
        public void SelectOrderByGuid(string token, string guid)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try
                {
                    DataTable OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderByMemberloginIDAndGuid(guid);


                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_Mobile_Order));
                    types.Add(typeof(List<ShopNum1_Mobile_Order>));
                    types.Add(typeof(List<ShopNum1_M_OrderProduct>));

                    List<ShopNum1_Mobile_Order> orders = ShopNum1_Mobile_Order.FromDataRowGetOrder(OrderByMemberloginID);

                    foreach (ShopNum1_Mobile_Order order in orders)
                    {
                        order.OrderProduct = ShopNum1_M_OrderProduct.FromDataRowOrderProduct(((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderProductByOrderInfoGuid(order.Guid));

                    }

                    message.Data = orders;
                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                    message.Result = 1;
                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //通过订单guid查询订单(不需要token版本)
        [WebMethod]
        public void SelectOrderByGuid_two(string guid)
        {
            MMessage message = new MMessage();



            DataTable OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderByMemberloginIDAndGuid(guid);


            List<Type> types = new List<Type>();
            types.Add(typeof(ShopNum1_Mobile_Order));
            types.Add(typeof(List<ShopNum1_Mobile_Order>));
            types.Add(typeof(List<ShopNum1_M_OrderProduct>));

            List<ShopNum1_Mobile_Order> orders = ShopNum1_Mobile_Order.FromDataRowGetOrder(OrderByMemberloginID);

            foreach (ShopNum1_Mobile_Order order in orders)
            {
                order.OrderProduct = ShopNum1_M_OrderProduct.FromDataRowOrderProduct(((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectOrderProductByOrderInfoGuid(order.Guid));

            }

            message.Data = orders;
            Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
            message.Result = 1;

            Context.Response.End();


        }
        //查询卖家信息
        [WebMethod]
        public void GetALLMemberByShopid(string shopid)
        {
            DataTable selectMember = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberByShopid(shopid);
            MMessage message = new MMessage();

            if (selectMember.Rows.Count > 0)
            {
                message.Data = ShopNum1_GetALLMemberByShopid.GetALLMemberByShopid(selectMember.Rows[0]);//ServiceHelper.M_json(selectGoods);

                List<Type> types = new List<Type>();
                types.Add(typeof(ShopNum1_GetALLMemberByShopid));

                Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                Context.Response.End();
            }
            else
            {


                message.Result = 0;
                message.Error_code = "可能有误";
                message.Error_message = "可能有误";

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
        }
        //查询所有店铺
        [WebMethod]
        public void GetALLShopid(string addcode, string ShopCategoryID, string ordername, string soft,
            string shopName, string memberid, string ShowCount, string current_pag)
        {
            var action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            DataSet set2 = action.SearchShopList(addcode, ShopCategoryID, ordername, soft, shopName, memberid,
                  ShowCount.ToString(), current_pag.ToString(), "0");


            MMessage message = new MMessage();

            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                message.Data = GetShopIDAll_two.FromDataRowGetProductByShop_category_id(set2.Tables[0]);//ServiceHelper.M_json(selectGoods);



                List<Type> types = new List<Type>();
                types.Add(typeof(GetShopIDAll_two));
                types.Add(typeof(List<GetShopIDAll_two>));

                Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
            }
            else
            {


                message.Result = 0;
                message.Error_code = "可能有误";
                message.Error_message = "可能有误";

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
        }
        //查询所有店铺总数
        [WebMethod]
        public void GetALLShopidCount(string addcode, string ShopCategoryID, string ordername, string soft,
            string shopName, string memberid, string ShowCount, string current_pag)
        {
            var action = (ShopNum1_ShopInfoList_Action)LogicFactory.CreateShopNum1_ShopInfoList_Action();
            DataSet set2 = action.SearchShopList(addcode, ShopCategoryID, ordername, soft, shopName, memberid,
                  ShowCount.ToString(), current_pag.ToString(), "1");


            MMessage message = new MMessage();

            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {

                message.Result = 1;
                message.Error_code = Convert.ToString(set2.Tables[0].Rows[0][0]); ;
                message.Error_message = Convert.ToString(set2.Tables[0].Rows[0][0]);
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
            else
            {


                message.Result = 0;
                message.Error_code = "可能有误";
                message.Error_message = "可能有误";

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
        }
        //手机退订单
        [WebMethod]
        public void MobileOrderRefund(string MemLoginID, string OrderGuid, string ShopID, string RefundReason, string Introduce, string RefundTypes, string token)
        {
            MMessage message = new MMessage();
            ReFund reFund = new ReFund();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    string order = reFund.MobileOrderRefund(MemLoginID, OrderGuid, ShopID, RefundReason, Introduce, RefundTypes);

                    switch (order)
                    {
                        case "1":
                            message.Result = 0;
                            message.Error_code = "付款时间大于7天后，不能申请退款";
                            message.Error_message = "付款时间大于7天后，不能申请退款";
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "操作失败";
                            message.Error_message = "操作失败";
                            break;
                        case "3":
                            message.Result = 1;
                            message.Succeed_code = "退款成功";
                            message.Succeed_message = "退款成功";
                            break;
                        case "4":
                            message.Result = 1;
                            message.Succeed_code = "退货成功";
                            message.Succeed_message = "退货成功";
                            break;



                    }

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //获取版本号
        [WebMethod]
        public void GetVersion()
        {
            string VersionNumber = ConfigurationManager.AppSettings["VersionNumber"];

            string Path = ConfigurationManager.AppSettings["Path"];
            string UpdeModel = ConfigurationManager.AppSettings["UpdeModel"];
            string VersionNumber2 = ConfigurationManager.AppSettings["VersionNumber2"];


            ProductShow product = new ProductShow();
            product.Version = VersionNumber;
            product.Path = Path;
            product.UpdeModel = UpdeModel;
            product.VersionNumber2 = VersionNumber2;
            // Serialize(ContentType);

            Context.Response.Write(ServiceHelper.GetJSON<ProductShow>(product));
            Context.Response.End();
        }

        //手机订单确认收货
        [WebMethod]
        public void MobileReceipt(string OrderNumber, string token)
        {
            MMessage message = new MMessage();
            MobileOrderReceipt reFund = new MobileOrderReceipt();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try
                {
                    string order = reFund.MobileReceipt(OrderNumber);

                    switch (order)
                    {

                        case "2":
                            message.Result = 0;
                            message.Error_code = "操作失败";
                            message.Error_message = "操作失败";
                            break;
                        case "1":
                            message.Result = 1;
                            message.Succeed_code = "操作成功";
                            message.Succeed_message = "操作成功";
                            break;




                    }

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }
        //删除地址
        [WebMethod]
        public void DelteAdress(string guid, string token)
        {
            MMessage message = new MMessage();
            MobileOrderReceipt reFund = new MobileOrderReceipt();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try
                {

                    int OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).DelteAdressByGuid(guid);


                    if (OrderByMemberloginID == 0)
                    {
                        message.Result = 0;
                        message.Error_code = "操作失败";
                        message.Error_message = "操作失败";
                    }
                    else
                    {
                        message.Result = 1;
                        message.Succeed_code = "操作成功";
                        message.Succeed_message = "操作成功";
                    }







                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //修改地址的默认值
        [WebMethod]
        public void UpdateAdressIsDefault(string guid, string memloginid, string token)
        {
            MMessage message = new MMessage();
            MobileOrderReceipt reFund = new MobileOrderReceipt();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memloginid.ToUpper())
            {
                try
                {

                    int OrderByMemberloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefault(guid);
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).UpdateAdressIsDefaultAndTwo(guid, memloginid);


                    if (OrderByMemberloginID == 0)
                    {
                        message.Result = 0;
                        message.Error_code = "操作失败";
                        message.Error_message = "操作失败";
                    }
                    else
                    {
                        message.Result = 1;
                        message.Succeed_code = "操作成功";
                        message.Succeed_message = "操作成功";
                    }







                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        [WebMethod]
        public void DeleteShopCar(string guid, string token)
        {
            MMessage message = new MMessage();
            MobileOrderReceipt reFund = new MobileOrderReceipt();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try
                {

                    var cartAction = (ShopNum1_Cart_Action)LogicFactory.CreateShopNum1_Cart_Action();
                    int c = cartAction.DeleteShopcara(guid);

                    if (c > 0)
                    {
                        message.Result = 1;
                        message.Succeed_code = "操作成功";
                        message.Succeed_message = "操作成功";
                    }
                    else
                    {
                        message.Result = 0;
                        message.Error_code = "删除失败";
                        message.Error_message = "删除失败";
                    }








                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //查询这个人的所有购物车
        [WebMethod]
        public void SelectAllShopCarBymemberloginID(string memberloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    DataTable ShopCategory = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectAllShopCarBymemberloginID(memberloginID);


                    message.Data = ShopNum1_AllShopCarBymemberloginID.FromDataRowGetAllShopCategorys(ShopCategory);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_AllShopCarBymemberloginID));
                    types.Add(typeof(List<ShopNum1_AllShopCarBymemberloginID>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //tj88到前海的转账

        [WebMethod]
        public string SelcteMoeneyBypwdANDTransfer(string meloginid, string paypwd, decimal AdvancePayment)
        {
            DataTable selectMember = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelcteMoeneyBypwd(meloginid, Common.Encryption.GetMd5SecondHash(paypwd.Trim()));
            MMessage message = new MMessage();


            if (selectMember.Rows.Count > 0)
            {
                decimal money = Convert.ToDecimal(selectMember.Rows[0]["AdvancePayment"]);
                if (AdvancePayment < money)
                {
                    decimal lastmoney = money - AdvancePayment;
                    int INsertAdvancePaymentModifyLogRecord = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).INsertAdvancePaymentModifyLogRecord(meloginid, money, AdvancePayment, lastmoney);
                    int updateMemberAdvancePayment = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).updateMemberAdvancePayment(meloginid, lastmoney);
                    if (INsertAdvancePaymentModifyLogRecord == 1 && updateMemberAdvancePayment == 1)
                    {
                        return "true";
                    }
                    else
                    {
                        if (INsertAdvancePaymentModifyLogRecord != 1 && updateMemberAdvancePayment == 1)
                        {
                            return "执行修改用户金钱时出错";
                        }
                        else if (INsertAdvancePaymentModifyLogRecord == 1 && updateMemberAdvancePayment != 1)
                        {
                            return "执行添加消费记录出错";
                        }
                        else
                        {
                            return "执行添加消费记录和修改用户金钱时都出错";
                        }

                    }

                }
                else
                {
                    return "转账金额大于实际拥有金额";
                }

            }
            else
            {

                return "账号错误或者支付密码错误请重试。";
            }
        }

        //签到
        [WebMethod]
        public void SignIn_HV(string MyMemLoginID, string token)
        {
            MMessage message = new MMessage();
            SignIn SignIn2 = new SignIn();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try
                {
                    string order = SignIn2.SignIn_HV(MyMemLoginID);
                    switch (order)
                    {
                        case "have":
                            message.Result = 0;
                            message.Error_code = "您今天已经签到过了!";
                            message.Error_message = "您今天已经签到过了!";
                            break;
                        case "true":
                            message.Succeed_code = "签到成功";
                            message.Succeed_message = "签到成功";
                            message.Result = 1;
                            break;
                        case "false":
                            message.Result = 0;
                            message.Error_code = "签到失败了!";
                            message.Error_message = "签到失败了!";
                            break;



                        default:
                            message.Succeed_code = order;
                            message.Succeed_message = order;
                            message.Result = 1;
                            break;
                    }
                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }






        //查询交易记录
        [WebMethod]
        public void SelectAllAdvancePaymentModifyLogByMemberloginID(string memberloginID, string Currentpage, string PageSize, string strPayType, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                var action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                try
                {
                    string str = string.Empty;
                    str = str + "  AND  MemLoginID=  '" + memberloginID + "'   ";
                    if ((Operator.FormatToEmpty(strPayType) != string.Empty) && (Operator.FormatToEmpty(strPayType) != "-1") && Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        str = str + " AND OperateType=" + strPayType;
                    }
                    string selce_two = string.Empty;
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        selce_two = " and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_rv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_cv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_cv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_DJ_BV <> 0";
                    }
                    var commonModel = new CommonPageModel
                    {
                        Condition = "  AND   1=1   " + str + selce_two,
                        Currentpage = Currentpage,
                        Tablename = "ShopNum1_AdvancePaymentModifyLog",
                        Resultnum = "1",
                        PageSize = PageSize
                    };

                    commonModel.Select_YuJu = "*";

                    string str2 = "0";
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,CurrentAdvancePayment as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(OperateMoney)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_a as money_first,XiaoFei_pv_a as money_two,XiaoFei_Hou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_a as money_first,HuoDe_pv_a as money_two,Huo_DeHou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_hv as money_first,XiaoFei_hv as money_two,XiaoFei_Hou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_hv as money_first,HuoDe_hv as money_two,Huo_DeHou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_b as money_first,XiaoFei_pv_b as money_two,XiaoFei_Hou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_b as money_first,HuoDe_pv_b as money_two,Huo_DeHou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_rv as money_first,XiaoFei_rv as money_two,XiaoFei_Hou_rv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_rv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_dv as money_first,HuoDe_dv as money_two,Huo_DeHou_sdv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_dv as money_first,DeDao_dv as money_two,DeDao_Hou_dv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(DeDao_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_Qian_cv as money_first,XiaoFei_cv as money_two,XiaoFei_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_cv as money_first,DeDao_cv as money_two,DeDao_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_DJ_BV as money_first,HuoDe_DJ_BV as money_two,Huo_DeHou_DJ_BV as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    DataTable table2 = action.SelectAdvPaymentModifyLog_List(commonModel);

                    if (table2.Rows.Count > 0)
                    {
                        message.Data = ShopNum1_AllAdvancePaymentModifyLog.FromDataRowGetAllShopCategorys(table2);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_AllAdvancePaymentModifyLog));
                        types.Add(typeof(List<ShopNum1_AllAdvancePaymentModifyLog>));

                        Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Error_code = "0";
                        message.Error_message = "没有任何一行";

                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    }



                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //查询转账记录条数
        [WebMethod]
        public void SelectAllPreTransferByMemberloginIDCount(string memberloginID, string Currentpage, string PageSize, string type, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {


                try
                {
                    string str = string.Empty;
                    if (type == "1")
                    {
                        str = str + "  AND  MemLoginID=  '" + memberloginID + "'   ";

                    }
                    else if (type == "2")
                    {
                        str = str + "  AND  Rmemberid=  '" + memberloginID + "'   ";

                    }
                    var commonModel = new CommonPageModel
                    {
                        Condition = "  AND   1=1   " + str + "     AND  IsDeleted=0 ",
                        Currentpage = Currentpage,
                        Tablename = "ShopNum1_PreTransfer",
                        Resultnum = "0",
                        PageSize = PageSize,
                        Select_YuJu = "*"
                    };
                    var action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                    DataTable table3 = action.SelectAdvPaymentModifyLog_List(commonModel);



                    message.Result = 1;
                    message.Succeed_code = Convert.ToString(table3.Rows[0][0]);
                    message.Succeed_message = Convert.ToString(table3.Rows[0][0]);

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //查询提现记录条数
        [WebMethod]
        public void SelectAllAdvancePaymentApplyLogByMemberloginIDCount(string memberloginID, string Currentpage, string PageSize, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    string str = string.Empty;
                    str = str + "  AND  MemLoginID=  '" + memberloginID + "'   ";
                    var commonModel = new CommonPageModel
                    {
                        Condition = "  AND   1=1   " + str + "     AND  IsDeleted=0 ",
                        Currentpage = Currentpage,
                        Tablename = "ShopNum1_AdvancePaymentApplyLog",
                        Resultnum = "0",
                        PageSize = PageSize,
                        Select_YuJu = "*"
                    };
                    var action =
                    (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                    DataTable table2 = action.SelectAdvPayment_List(commonModel);


                    message.Result = 1;
                    message.Succeed_code = Convert.ToString(table2.Rows[0][0]);
                    message.Succeed_message = Convert.ToString(table2.Rows[0][0]);

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }




        //查询交易记录条数
        [WebMethod]
        public void SelectAllAdvancePaymentModifyLogByMemberloginIDCount(string memberloginID, string Currentpage, string PageSize, string strPayType, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                var action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                try
                {
                    string str = string.Empty;
                    str = str + "  AND  MemLoginID=  '" + memberloginID + "'   ";
                    string selce_two = string.Empty;
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        selce_two = " and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_a <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_hv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_b <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_rv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_dv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.XiaoFei_cv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.DeDao_cv <> 0";
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                    {
                        selce_two = "and ShopNum1_AdvancePaymentModifyLog.HuoDe_DJ_BV <> 0";
                    }
                    var commonModel = new CommonPageModel
                    {
                        Condition = "  AND   1=1   " + str + selce_two,
                        Currentpage = Currentpage,
                        Tablename = "ShopNum1_AdvancePaymentModifyLog",
                        Resultnum = "0",
                        PageSize = PageSize
                    };

                    commonModel.Select_YuJu = "*";

                    string str2 = "0";
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) <= 6)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,CurrentAdvancePayment as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(OperateMoney)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 7)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_a as money_first,XiaoFei_pv_a as money_two,XiaoFei_Hou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 8)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_a as money_first,HuoDe_pv_a as money_two,Huo_DeHou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_a)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 9)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_hv as money_first,XiaoFei_hv as money_two,XiaoFei_Hou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 10)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_hv as money_first,HuoDe_hv as money_two,Huo_DeHou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_hv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 11)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_pv_b as money_first,XiaoFei_pv_b as money_two,XiaoFei_Hou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 12)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_pv_b as money_first,HuoDe_pv_b as money_two,Huo_DeHou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_pv_b)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 13)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_YuanYou_rv as money_first,XiaoFei_rv as money_two,XiaoFei_Hou_rv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_rv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 14)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_dv as money_first,HuoDe_dv as money_two,Huo_DeHou_sdv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(HuoDe_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 15)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_dv as money_first,DeDao_dv as money_two,DeDao_Hou_dv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(DeDao_dv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 16)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,XiaoFei_Qian_cv as money_first,XiaoFei_cv as money_two,XiaoFei_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(XiaoFei_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 17)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,DeDao_Qian_cv as money_first,DeDao_cv as money_two,DeDao_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    if (Convert.ToInt32(Operator.FormatToEmpty(strPayType)) == 18)
                    {
                        commonModel.Select_YuJu = "Guid,OperateType,HuoDe_YuanYou_DJ_BV as money_first,HuoDe_DJ_BV as money_two,Huo_DeHou_DJ_BV as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber";
                        str2 = Common.Common.GetNameById("SUM(DeDao_cv)", "ShopNum1_AdvancePaymentModifyLog", str + selce_two);
                    }
                    DataTable table2 = action.SelectAdvPaymentModifyLog_List(commonModel);



                    message.Result = 1;
                    message.Succeed_code = Convert.ToString(table2.Rows[0][0]);
                    message.Succeed_message = Convert.ToString(table2.Rows[0][0]);

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }



        //注册C会员
        // 0会员已存在
        //1 推荐人不能没有
        //2 真实姓名为空
        //3 推荐人错误
        //4 身份证已存在
        //5 注册失败
        //7 注册成功



        // memloginid 用户编号,  Email 邮箱,  Mobile 手机号 ,  Name 姓名,  recommendid 推荐人,  IdentityCard 身份证号,  Pwd 密码
        [WebMethod]
        public void MemberRegisterMember(string memloginid, string Email, string Mobile, string Name, string recommendid, string IdentityCard, string Pwd, string Code, string Encryption)
        {
            MMessage message = new MMessage();
            SignIn SignIn2 = new SignIn();
            if (Encryption.ToUpper() == Common.Encryption.GetMd5SecondHash(Code).ToUpper())
            {
                try
                {
                    string order = SignIn2.MemberRegisterMember(memloginid, Email, Mobile, Name, recommendid, IdentityCard, Pwd);
                    switch (order)
                    {
                        case "0":
                            message.Result = 0;
                            message.Error_code = "会员已存在!";
                            message.Error_message = "会员已存在!";
                            break;
                        case "1":
                            message.Error_code = "推荐人不能没有";
                            message.Error_message = "推荐人不能没有";
                            message.Result = 0;
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "真实姓名为空";
                            message.Error_message = "真实姓名为空";
                            break;
                        case "3":
                            message.Result = 0;
                            message.Error_code = "推荐人错误!";
                            message.Error_message = "推荐人错误!";
                            break;
                        case "4":
                            message.Result = 0;
                            message.Error_code = "身份证已存在!";
                            message.Error_message = "身份证已存在!";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Error_code = "注册失败!";
                            message.Error_message = "注册失败!";
                            break;

                        case "7":
                            message.Result = 1;
                            message.Succeed_code = "注册成功!";
                            message.Succeed_message = "注册成功!";
                            break;
                        case "9":
                            message.Result = 0;
                            message.Error_code = "手机号重复!";
                            message.Error_message = "手机号重复!";

                            break;






                    }
                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                }
                Context.Response.End();
            }
            else
            {
                message.Result = 0;
                message.Error_code = "两次加密串对比不匹配";
                message.Error_message = "验证码错误，请重新输入验证码";

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }


        }


        //注册S会员
        // 0会员已存在
        //1 推荐人不能没有
        //2 真实姓名为空
        //3 推荐人错误
        //4 身份证已存在
        //5 注册失败
        //7 注册成功



        // memloginid 用户编号,  Email 邮箱,  Mobile 手机号 ,  Name 姓名,  recommendid 推荐人,  IdentityCard 身份证号,  Pwd 密码
        [WebMethod]
        public void MemberRegisterMandarinMember(string memloginid, string Email, string Mobile, string Name, string recommendid, string IdentityCard, string Pwd, string Code, string Encryption)
        {
            MMessage message = new MMessage();
            SignIn SignIn2 = new SignIn();
            if (Encryption.ToUpper() == Common.Encryption.GetMd5SecondHash(Code).ToUpper())
            {
                try
                {
                    string order = SignIn2.MemberRegisterMandarinMember(memloginid, Email, Mobile, Name, recommendid, IdentityCard, Pwd);
                    switch (order)
                    {
                        case "0":
                            message.Result = 0;
                            message.Error_code = "会员已存在!";
                            message.Error_message = "会员已存在!";
                            break;
                        case "1":
                            message.Error_code = "推荐人不能没有";
                            message.Error_message = "推荐人不能没有";
                            message.Result = 0;
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "真实姓名为空";
                            message.Error_message = "真实姓名为空";
                            break;
                        case "3":
                            message.Result = 0;
                            message.Error_code = "推荐人错误!";
                            message.Error_message = "推荐人错误!";
                            break;
                        case "4":
                            message.Result = 0;
                            message.Error_code = "身份证已存在!";
                            message.Error_message = "身份证已存在!";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Error_code = "注册失败!";
                            message.Error_message = "注册失败!";
                            break;

                        case "7":
                            message.Result = 1;
                            message.Succeed_code = "注册成功!";
                            message.Succeed_message = "注册成功!";
                            break;






                    }
                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                }
                Context.Response.End();
            }
            else
            {
                message.Result = 0;
                message.Error_code = "两次加密串对比不匹配";
                message.Error_message = "验证码错误，请重新输入验证码";

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }

        }

        //随机C会员
        [WebMethod]
        public void MemberRegisterMemberGetMemberNumber()
        {
            MMessage message = new MMessage();


            try
            {
                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();


                message.Result = 1;
                message.Succeed_code = action.GetMemberNumber();
                message.Succeed_message = action.GetMemberNumber();
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
            }
            Context.Response.End();

        }
        //随机S会员
        [WebMethod]
        public void MemberRegisterMandarinMemberGetMemberNumberRegister()
        {
            MMessage message = new MMessage();


            try
            {
                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();

                message.Result = 1;
                message.Succeed_code = action.GetMemberNumberRegister();
                message.Succeed_message = action.GetMemberNumberRegister();
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
            }
            Context.Response.End();

        }


        //验证码
        [WebMethod]
        public void img()
        {
            MMessage message = new MMessage();
            SignIn SignIn2 = new SignIn();

            try
            {

                string string_1 = string.Empty;
                var random = new Random();
                for (int i = 0; i < 4; i++)
                {
                    char ch;
                    int num2 = random.Next();
                    if ((num2 % 2) == 0)
                    {
                        ch = (char)(0x30 + ((ushort)(num2 % 10)));
                    }
                    else
                    {
                        ch = (char)(0x41 + ((ushort)(num2 % 0x1a)));
                    }
                    string_1 = string_1 + ch;
                }
                string order = SignIn2.imgCode(string_1);




                message.Result = 1;
                message.Succeed_code = order;
                message.Succeed_message = Common.Encryption.GetMd5SecondHash(string_1);
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
            }
            Context.Response.End();

        }
        //绑定手机
        [WebMethod]
        public void BindMobile(string MessageCode, string modile, string MemLoginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    CheckInfo c = new CheckInfo();
                    string cw = c.MemberMobileExec(MessageCode, modile);
                    if (cw != "1")
                    {
                        message.Result = 0;
                        message.Error_code = "验证码错误";
                        message.Error_message = "验证码错误";
                    }
                    else
                    {
                        var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        string messagemodile = action.UpdataIsMobileActivation(MemLoginID, modile).ToString();
                        ((ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action()).DeleteKey(
                   MemLoginID, MessageCode);
                        message.Succeed_code = messagemodile;
                        message.Succeed_message = "绑定成功";
                        message.Result = 1;
                    }



                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = "10010";
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //忘记密码

        [WebMethod]
        public void ForgetPWD(string MessageCode, string modile, string newpwd, string MemLoginID)
        {
            MMessage message = new MMessage();
            try
            {

                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                try
                {
                    CheckInfo c = new CheckInfo();
                    string cw = c.MemberMobileExec(MessageCode, modile);
                    if (cw != "1")
                    {
                        message.Result = 0;
                        message.Error_code = "10007";
                        message.Error_message = "验证码错误";
                    }
                    else
                    {

                        int count = action.UpdatePwd(MemLoginID.Trim(), ShopNum1.Common.Encryption.GetMd5Hash(newpwd.Trim()));
                        if (count == 1)
                        {
                            message.Succeed_code = "10005";
                            message.Succeed_message = "密码修改成功";
                            message.Result = 1;
                        }
                        else
                        {
                            message.Result = 0;
                            message.Error_code = "10006";
                            message.Error_message = "密码修改失败";

                        }
                    }
                }
                catch (Exception ex)
                {
                    message.Result = 0;
                    message.Error_code = "10010";
                    message.Error_message = ex.Message;
                }




                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
            Context.Response.End();
        }
        //设置交易密码
        [WebMethod]
        public void BindTradePWD(string MessageCode, string modile, string MemLoginID, string payPwd, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {

                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    try
                    {
                        CheckInfo c = new CheckInfo();
                        string cw = c.MemberMobileExec(MessageCode, modile);
                        if (cw != "1")
                        {
                            message.Result = 0;
                            message.Error_code = "验证码错误";
                            message.Error_message = "验证码错误";
                        }
                        else
                        {
                            string payPwdd = Common.Encryption.GetMd5SecondHash(payPwd.Trim());
                            if (action.UpdatePayPwd(MemLoginID, payPwdd) > 0)
                            {

                                var action2 =
                                    (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
                                action2.DeleteKey(MemLoginID, MessageCode);
                                message.Succeed_code = "设置成功";
                                message.Succeed_message = "设置成功";
                                message.Result = 1;

                            }
                            else
                            {

                                message.Result = 0;
                                message.Error_code = "设置失败";
                                message.Error_message = "设置失败";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        message.Result = 0;
                        message.Error_code = "10010";
                        message.Error_message = ex.Message;
                    }




                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = "10010";
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }
        //修改密码
        [WebMethod]
        public void SettingsPWD(string MemLoginID, string OldPwd, string NewPwd, string NewSecondPwd, string token)
        {

            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {


                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    string str = ShopNum1.Common.Encryption.GetMd5Hash(OldPwd.Trim());
                    string newPwd = ShopNum1.Common.Encryption.GetMd5Hash(NewPwd.Trim());
                    string str3 = ShopNum1.Common.Encryption.GetMd5Hash(NewSecondPwd.Trim());
                    if (action.CheckPassword(MemLoginID, str) > 0)
                    {
                        if (newPwd == str3)
                        {
                            if (action.UpdatePwd(MemLoginID, newPwd) > 0)
                            {

                                message.Succeed_code = "修改成功";
                                message.Succeed_message = "修改成功";
                                message.Result = 1;
                                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                            }
                            else
                            {

                                message.Result = 0;
                                message.Error_code = "修改失败";
                                message.Error_message = "修改失败";
                                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                            }
                        }
                    }
                    else
                    {

                        message.Result = 0;
                        message.Error_code = "旧密码错误";
                        message.Error_message = "旧密码错误";
                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    }
                }
                catch
                {


                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
            }
        }


        //查询可以试用的支付方式
        [WebMethod]
        public void SelectSearchTwo()
        {
            DataTable selectProducet = new DataTable();
            MMessage message = new MMessage();
            try
            {
                var shopNum1_ShopPayment_Action =
                   (ShopNum1_ShopPayment_Action)LogicFactory.CreateShopNum1_ShopPayment_Action();
                IShopNum1_Payment_Action shopNum1_Payment_Action = LogicFactory.CreateShopNum1_Payment_Action();

                selectProducet = shopNum1_Payment_Action.SearchTwo(0);

            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = ex.Message;
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
            if (selectProducet.Rows.Count > 0)
            {

                try
                {


                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_SerchTwo));
                    types.Add(typeof(List<ShopNum1_SerchTwo>));
                    message.Data = ShopNum1_SerchTwo.FromDataRowGetProductByShop_category_id(selectProducet);
                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));


                    //message.Data = ShopNum1_SerchTwo.FromDataRowGetProductByShop_category_id(selectProducet);



                    //List<Type> types = new List<Type>();
                    //types.Add(typeof(ShopNum1_SerchTwo));


                    //Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                    Context.Response.End();



                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Error_code = "参数错误";
                    message.Error_message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Error_code = "没有更多商品";
                message.Error_message = "没有更多商品";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }

        }
        /// <summary>
        /// 手机发送验证码
        /// </summary>
        /// <param name="mobile">手机号码</param>
        /// <returns>返回值</returns>
        [WebMethod]
        public void VerificationCode(string mobile, string memloginid)
        {
            GZMessage message = new GZMessage();

            try
            {
                bool IsHandset = System.Text.RegularExpressions.Regex.IsMatch(mobile, @"^1[2|3|4|5|6|7|8|9][0-9]\d{8}$");
                if (IsHandset)
                {
                    ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    ShopNum1_MemberActivate_Action Activateaction = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
                    if (action.mobileYZ(mobile, memloginid) > 0)
                    {
                        string code = new Random().Next(111111, 999999).ToString();
                        DataTable activate = Activateaction.SelectActivate(mobile, memloginid);
                        if (activate.Rows.Count > 0)
                        {
                            string time = Convert.ToString(DateTime.Now.AddMinutes(30));
                            Activateaction.UpdateMobileCode(mobile, memloginid, code, time);

                        }
                        else
                        {
                            ShopNum1_MemberActivate shopNum1_MemberActivate = new ShopNum1_MemberActivate();
                            shopNum1_MemberActivate.Guid = Guid.NewGuid();
                            shopNum1_MemberActivate.MemberID = memloginid;
                            shopNum1_MemberActivate.Pwd = "";
                            shopNum1_MemberActivate.Key = code;
                            shopNum1_MemberActivate.type = 0;
                            shopNum1_MemberActivate.extireTime = DateTime.Now.AddMinutes(30);
                            shopNum1_MemberActivate.Phone = mobile;
                            shopNum1_MemberActivate.isinvalid = 0;
                            Activateaction.InsertforGetMobileCode(shopNum1_MemberActivate);
                        }

                        string content = "亲，本次操作的验证码为:" + code + " 切勿泄漏此验证码信息给他人，如非本人操作，请忽略此条信息。【唐江巴巴】";
                        bool ret = SendFast(mobile, content);
                        if (ret)
                        {


                            message.Code = "10001";
                            message.Message = "发送成功";
                            message.Result = 1;


                        }
                        else
                        {
                            message.Code = "10002";
                            message.Message = "发送失败";
                            message.Result = 0;

                        }
                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    }
                    else
                    {
                        message.Code = "10004";
                        message.Message = "输入的手机号与账号绑定的手机号不一致";
                        message.Result = 0;

                    }
                }
                else
                {
                    message.Code = "10003";
                    message.Message = "手机号码格式不正确";
                    message.Result = 0;

                }
            }
            catch (Exception ex)
            {
                message.Code = "10010";
                message.Message = ex.ToString();
                message.Result = 0;

            }
            Context.Response.End();
        }
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
        /// <summary>
        /// 登录密码修改（忘记密码）
        /// </summary>
        /// <param name="memberid">账号</param>
        /// <param name="newpwd">新密码</param>
        /// <returns></returns>
        [WebMethod]
        public string UpdatePwd(string memberid, string newpwd)
        {
            string result = string.Empty;
            var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            try
            {
                int count = action.UpdatePwd(memberid.Trim(), ShopNum1.Common.Encryption.GetMd5Hash(newpwd.Trim()));
                if (count == 1)
                {
                    result = "密码修改成功";
                }
                else
                {
                    result = "密码修改失败";
                }
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }
        //查询未读消息总数
        [WebMethod]
        public void SelectNoReadSendByMemberID(string memberloginID, string token)
        {
            MMessage message = new MMessage();


            try
            {

                string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
                string[] tValues = TokenPuzzle.Split('~');
                string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

                if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
                {




                    ShopNum1_MessageInfo_Action action =
               (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
                    string table = action.SelectNoReadSendByMemberID(memberloginID);


                    message.Result = 1;
                    message.Succeed_code = "10055";
                    message.Succeed_message = table;








                }

                else
                {
                    // Serialize(ContentType);
                    if (ReturnValue == "0")
                    {
                        message.Result = 0;
                        message.Error_code = "10086";
                        message.Error_message = "请重新登陆哟，您的身份验证已经过期";



                    }
                    else if (ReturnValue == "2")
                    {
                        message.Result = 0;
                        message.Error_code = "10086";
                        message.Error_message = "请重新登陆哟，您的身份验证已经过期";



                    }

                }
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = "10010";
                message.Error_message = ex.Message;



            }
            Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
            Context.Response.End();
        }

        //查询消息记录
        [WebMethod]
        public void SelectAllSendByMemberID(string memberloginID, int StartNumber, int EndNumber, string token)
        {
            MMessage message = new MMessage();


            try
            {

                string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
                string[] tValues = TokenPuzzle.Split('~');
                string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

                if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
                {


                    try
                    {

                        ShopNum1_MessageInfo_Action action =
                   (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
                        DataTable table = action.SelectAllSendByMemberID(memberloginID, StartNumber, EndNumber);

                        if (table.Rows.Count > 0)
                        {
                            message.Data = Mobile_ShopNum1_UserMessage.FromDataRow_ShopNum1_UserMessage(table);



                            List<Type> types = new List<Type>();
                            types.Add(typeof(Mobile_ShopNum1_UserMessage));
                            types.Add(typeof(List<Mobile_ShopNum1_UserMessage>));

                            Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                        }
                        else
                        {
                            message.Result = 0;
                            message.Error_code = "10008";
                            message.Error_message = "没有任何一行";

                            Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                        }



                    }
                    catch (Exception ex)
                    {

                        message.Result = 0;
                        message.Error_code = "10010";
                        message.Error_message = ex.Message;

                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                    }
                    Context.Response.End();
                }

                else
                {
                    // Serialize(ContentType);
                    if (ReturnValue == "0")
                    {
                        message.Result = 0;
                        message.Error_code = "10086";
                        message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                        Context.Response.End();
                    }
                    else if (ReturnValue == "2")
                    {
                        message.Result = 0;
                        message.Error_code = "10086";
                        message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                        Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                        Context.Response.End();
                    }

                }
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = "10010";
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
            Context.Response.End();
        }




        //查询消息记录的详细
        [WebMethod]
        public void SelectAllSendDetailByMemberID(string MessageInfoGuid)
        {
            MMessage message = new MMessage();



            try
            {

                ShopNum1_MessageInfo_Action action =
           (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
                DataTable table = action.SelectAllSendDetailByGuid(MessageInfoGuid);
                action.UpdateIsReadByGuid(MessageInfoGuid);

                if (table.Rows.Count > 0)
                {
                    message.Data = Mobile_ShopNum1_MessageInfo.FromDataRow_ShopNum1_MessageInfo(table);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(Mobile_ShopNum1_MessageInfo));
                    types.Add(typeof(List<Mobile_ShopNum1_MessageInfo>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                }
                else
                {
                    message.Result = 0;
                    message.Error_code = "10009";
                    message.Error_message = "没有任何一行";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                }



            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Error_code = "10010";
                message.Error_message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
            Context.Response.End();

        }

        //删除系统消息记录

        [WebMethod]
        public void DeleteSendByGuid(string guids)
        {
            MMessage message = new MMessage();


            ShopNum1_MessageInfo_Action action = (ShopNum1_MessageInfo_Action)LogicFactory.CreateShopNum1_MessageInfo_Action();
            try
            {


                int count = action.DeleteSendByGuids(guids);
                if (count == 1)
                {
                    message.Succeed_code = "10011";
                    message.Succeed_message = "删除成功";
                    message.Result = 1;
                }
                else
                {
                    message.Result = 0;
                    message.Error_code = "10012";
                    message.Error_message = "删除失败";

                }

            }
            catch (Exception ex)
            {
                message.Result = 0;
                message.Error_code = "10010";
                message.Error_message = ex.Message;
            }




            Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            Context.Response.End();
        }
        //分享注册链接
        [WebMethod]
        public void FxUrl(string memloginid)
        {
            GZMessage message = new GZMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            try
            {
                Mobile_ShopNum1_FxUrl url = cnfirmOrderAPP.FxUrl(memloginid);
                message.Data = MobileService_All_Entity.From_FxUrl(url);



                List<Type> types = new List<Type>();
                types.Add(typeof(Mobile_ShopNum1_FxUrl));
                types.Add(typeof(List<Mobile_ShopNum1_FxUrl>));

                Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));
                //message.Code = "10013";
                //message.Message = url;
                //message.Result = 1;
                //Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = "10010";
                message.Message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

            }
            Context.Response.End();

        }

        //通过分类查询商品详细
        [WebMethod]
        public void SelectProdctByShop_category_id_and_Code(string Code, string shop_category_id, int StartNumber, int EndNumber)
        {
            DataTable selectProducet = new DataTable();
            GZMessage message = new GZMessage();
            try
            {
                selectProducet = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectProdctShop_category_id_and_Code(Code, shop_category_id, StartNumber, EndNumber);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = "10010";
                message.Message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            if (selectProducet.Rows.Count > 0)
            {

                try
                {

                    message.Data = ShopNum1_M_Producet.FromDataRowGetProductByShop_category_id(selectProducet);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_M_Producet));
                    types.Add(typeof(List<ShopNum1_M_Producet>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = "参数错误";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Code = "10014";
                message.Message = "没有查询到更多商品";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

        }

        //热门搜索获取
        [WebMethod]
        public void SelectHot(string Shop_Category_ID)
        {
            DataTable HotProducet = new DataTable();
            GZMessage message = new GZMessage();
            try
            {
                HotProducet = ((ShopNum1_MobileService_Action)LogicFactory.CreateShopNum1_MobileService_Action()).SelectHot(Shop_Category_ID);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = "10010";
                message.Message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            if (HotProducet.Rows.Count > 0)
            {

                try
                {

                    message.Data = MobileService_All_Entity.From_SelectHot(HotProducet);



                    List<Type> types = new List<Type>();
                    types.Add(typeof(Mobile_ShopNum1_ReMenSouSuo));
                    types.Add(typeof(List<Mobile_ShopNum1_ReMenSouSuo>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = "系统错误";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Code = "10015";
                message.Message = "没有查询到任何数据";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

        }


        //关联所搜
        [WebMethod]
        public void RelationSelect(string Shop_Category_ID, string RelationWords)
        {

            DataTable RelationName = new DataTable();
            GZMessage message = new GZMessage();
            try
            {
                RelationName = ((ShopNum1_MobileService_Action)LogicFactory.CreateShopNum1_MobileService_Action()).RelationSelect(Shop_Category_ID, RelationWords);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = "10010";
                message.Message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            if (RelationName.Rows.Count > 0)
            {

                try
                {

                    message.Data = MobileService_All_Entity.From_RelationSelect(RelationName);


                    List<Type> types = new List<Type>();
                    types.Add(typeof(Mobile_ShopNum1_RelationSelect));
                    types.Add(typeof(List<Mobile_ShopNum1_RelationSelect>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = "系统错误";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Code = "10016";
                message.Message = "没有查询到任何数据";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

        }

        //关联所搜店铺
        [WebMethod]
        public void RelationSelectShopInfo(string RelationWords, int SatarNumber, int EndNumber)
        {

            DataTable shopinfo = new DataTable();
            GZMessage message = new GZMessage();
            try
            {
                shopinfo = ((ShopNum1_MobileService_Action)LogicFactory.CreateShopNum1_MobileService_Action()).RelationSelectShopInfo(RelationWords, SatarNumber, EndNumber);
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = "10010";
                message.Message = ex.Message;

                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }
            if (shopinfo.Rows.Count > 0)
            {

                try
                {

                    message.Data = MobileService_All_Entity.From_RelationSelectShopInfo(shopinfo);


                    List<Type> types = new List<Type>();
                    types.Add(typeof(MobileService_All_Entity));
                    types.Add(typeof(List<MobileService_All_Entity>));

                    Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));

                }
                catch (Exception)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = "系统错误";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }
            else
            {


                message.Code = "10016";
                message.Message = "没有查询到任何数据";
                message.Result = 0;
                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                Context.Response.End();
            }

        }


        //批量删除购物车
        //多条删除guid用,分隔
        [WebMethod]
        public void DeleteShopCarGuids(string memberloginID, string Guids, string token)
        {
            GZMessage message = new GZMessage();


            try
            {

                string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
                string[] tValues = TokenPuzzle.Split('~');
                string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

                if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
                {




                    ShopNum1_MobileService_Action action =
               (ShopNum1_MobileService_Action)LogicFactory.CreateShopNum1_MobileService_Action();
                    int fx = action.DeleteShopCar(Guids);

                    if (fx > 0)
                    {
                        message.Result = 1;
                        message.Code = "10017";
                        message.Message = "删除成功";


                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "10018";
                        message.Message = "删除失败";


                    }




                }

                else
                {
                    // Serialize(ContentType);
                    if (ReturnValue == "0")
                    {
                        message.Result = 0;
                        message.Code = "10086";
                        message.Message = "请重新登陆哟，您的身份验证已经过期";


                    }
                    else if (ReturnValue == "2")
                    {
                        message.Result = 0;
                        message.Code = "10086";
                        message.Message = "请重新登陆哟，您的身份验证已经过期";


                    }

                }
            }
            catch (Exception ex)
            {

                message.Result = 0;
                message.Code = "10010";
                message.Message = ex.Message;



            }
            Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
            Context.Response.End();

        }

        //提现
        //1    系统错误
        //2    用户信息获取失败，请联系管理员！
        //3    验证码错误
        //4    请设置支付密码
        //5    支付密码错误
        //6    交易金额不能为零或者负数
        //7    提现金额不能大于金币
        //8    会员备注不能大于300字符
        //9    顾客不能提现
        //10   提现金额人民币（RV）必须为整数
        //11   非常抱歉，非工作日不能提现哟~

        //0    申请提现成功
        [WebMethod]
        public void PayDecrease(string MemLoginID, string PayPwd, string Decrease_bv, string Remark, string token)
        {
            GZMessage message = new GZMessage();
            PayDecrease PayDecrease = new PayDecrease();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    string order = PayDecrease.PayDecrease_BV(MemLoginID, PayPwd, Decrease_bv, Remark);
                    switch (order)
                    {
                        case "0":
                            message.Result = 1;
                            message.Code = "10036!";
                            message.Message = "申请提现成功!";
                            break;
                        case "1":
                            message.Code = "10037";
                            message.Message = "系统错误";
                            message.Result = 0;
                            break;
                        case "2":
                            message.Result = 0;
                            message.Code = "10038";
                            message.Message = "用户信息获取失败，请联系管理员！";
                            break;
                        case "3":
                            message.Result = 0;
                            message.Code = "10039";
                            message.Message = "验证码错误!";
                            break;
                        case "4":
                            message.Result = 0;
                            message.Code = "10040";
                            message.Message = "请设置支付密码!";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Code = "10041";
                            message.Message = "支付密码错误!";
                            break;
                        case "6":
                            message.Result = 0;
                            message.Code = "10042";
                            message.Message = "交易金额不能小于100!";
                            break;
                        case "7":
                            message.Result = 0;
                            message.Code = "10043";
                            message.Message = "提现金额不能大于金币!";
                            break;
                        case "8":
                            message.Result = 0;
                            message.Code = "10044";
                            message.Message = "会员备注不能大于300字符!";
                            break;
                        case "9":
                            message.Result = 0;
                            message.Code = "10045";
                            message.Message = "顾客不能提现!";
                            break;
                        case "10":
                            message.Result = 0;
                            message.Code = "10046";
                            message.Message = "提现金额人民币（RV）必须为100的倍数!";
                            break;
                        case "11":
                            message.Result = 0;
                            message.Code = "10047";
                            message.Message = " 非常抱歉，非工作日不能提现哟~";
                            break;
                        case "12":
                            message.Result = 0;
                            message.Code = "10048";
                            message.Message = " 您的账户信息不完整！";
                            break;





                    }
                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //获取银行卡信息
        [WebMethod]
        public void PayDecrease_Bank(string MemLoginID, string token)
        {
            GZMessage message = new GZMessage();
            PayDecrease PayDecrease = new PayDecrease();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    Mobile_ShopNum1_Bank order = PayDecrease.PayDecrease_Bank(MemLoginID);
                    if (order != null)
                    {
                        message.Data = MobileService_All_Entity.From_PayDecrease_Bank(order);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(Mobile_ShopNum1_Bank));
                        types.Add(typeof(List<Mobile_ShopNum1_Bank>));

                        Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "10053";
                        message.Message = "无银行卡数据,请绑定";

                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    }

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //转账
        //1    验证码错误
        //2    请设置支付密码
        //3    支付密码错误
        //4    转账id不匹配
        //5    您不能转账给自己！
        //6    您不能转负数！
        //7    金币（BV）不足！
        //8    转账失败！
        //9    转账失败！
        //10   转账金额有误！
        //11   收款人用户名与收款人姓名不匹配或此收款人用户未填写用户名！
        //12   收款人用户有误或不存在！
        //0    转账成功！
        [WebMethod]
        public void PayTransfer_BV(string MemLoginID, string MessageCode, string TransferID, string TransferID2, string PayPwd, string Transfer, string TransferName, string Remark, string token)
        {
            MMessage message = new MMessage();
            PayTransfer PayTransfer = new PayTransfer();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    string order = PayTransfer.PayTransfer_BV(MemLoginID.ToUpper(), MessageCode, TransferID.ToUpper(), TransferID2.ToUpper(), PayPwd, Transfer, TransferName, Remark);
                    switch (order)
                    {

                        case "0":
                            message.Result = 1;
                            message.Succeed_code = "10019!";
                            message.Succeed_message = "转账成功!";
                            break;
                        case "1":
                            message.Error_code = "10020";
                            message.Error_message = "验证码错误";
                            message.Result = 0;
                            break;
                        case "2":
                            message.Result = 0;
                            message.Error_code = "10021！";
                            message.Error_message = "请设置支付密码！";
                            break;
                        case "3":
                            message.Result = 0;
                            message.Error_code = "10022!";
                            message.Error_message = "支付密码错误!";
                            break;
                        case "4":
                            message.Result = 0;
                            message.Error_code = "10023";
                            message.Error_message = "转账id不匹配!";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Error_code = "10024";
                            message.Error_message = "您不能转账给自己!";
                            break;
                        case "6":
                            message.Result = 0;
                            message.Error_code = "10025";
                            message.Error_message = "您不能转负数!";
                            break;
                        case "7":
                            message.Result = 0;
                            message.Error_code = "10026";
                            message.Error_message = "金币（BV）不足!";
                            break;
                        case "8":
                            message.Result = 0;
                            message.Error_code = "10027";
                            message.Error_message = "转账失败!";
                            break;
                        case "9":
                            message.Result = 0;
                            message.Error_code = "10028";
                            message.Error_message = "转账失败!";
                            break;
                        case "10":
                            message.Result = 0;
                            message.Error_code = "10029";
                            message.Error_message = "转账金额有误!";
                            break;
                        case "11":
                            message.Result = 0;
                            message.Error_code = "10030";
                            message.Error_message = " 收款人用户名与收款人姓名不匹配或此收款人用户未填写用户名";
                            break;

                        case "12":
                            message.Result = 0;
                            message.Error_code = "10031";
                            message.Error_message = " 收款人用户有误或不存在";
                            break;



                    }
                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = "10010";
                    message.Error_message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "10086";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }



        //查询转账记录
        [WebMethod]
        public void SelectAllPreTransferByMemberloginID(string memberloginID, string Currentpage, string PageSize, string type, string token)
        {
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {


                try
                {
                    string str = string.Empty;
                    if (type == "1")
                    {
                        str = str + "  AND  MemLoginID=  '" + memberloginID + "'   ";

                    }
                    else if (type == "2")
                    {
                        str = str + "  AND  Rmemberid=  '" + memberloginID + "'   ";

                    }
                    var commonModel = new CommonPageModel
                    {
                        Condition = "  AND   1=1   " + str + "     AND  IsDeleted=0 and  type=8",
                        Currentpage = Currentpage,
                        Tablename = "ShopNum1_PreTransfer",
                        Resultnum = "1",
                        PageSize = PageSize,
                        Select_YuJu = "*"
                    };
                    var action =
               (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                    DataTable table3 = action.SelectAdvPaymentModifyLog_List(commonModel);

                    if (table3.Rows.Count > 0)
                    {
                        message.Data = ShopNum1_AllPreTransfer.FromDataRowGetAllShopCategorys(table3);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_AllPreTransfer));
                        types.Add(typeof(List<ShopNum1_AllPreTransfer>));

                        Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "10032";
                        message.Message = "没有任何一行";

                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    }



                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //查询提现记录
        [WebMethod]
        public void SelectAllAdvancePaymentApplyLogByMemberloginID(string memberloginID, string Currentpage, string PageSize, string token)
        {
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == memberloginID.ToUpper())
            {
                try
                {
                    string str = string.Empty;
                    str = str + "  AND  MemLoginID=  '" + memberloginID + "'   ";
                    var commonModel = new CommonPageModel
                    {
                        Condition = "  AND   1=1   " + str + "     AND  IsDeleted=0 ",
                        Currentpage = Currentpage,
                        Tablename = "ShopNum1_AdvancePaymentApplyLog",
                        Resultnum = "1",
                        PageSize = PageSize,
                        Select_YuJu = "*"
                    };
                    var action =
                    (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                    DataTable table2 = action.SelectAdvPayment_List(commonModel);


                    if (table2.Rows.Count > 0)
                    {
                        message.Data = ShopNum1_AllAdvancePaymentApplyLog.FromDataRowGetAllShopCategorys(table2);



                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_AllAdvancePaymentApplyLog));
                        types.Add(typeof(List<ShopNum1_AllAdvancePaymentApplyLog>));

                        Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));
                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "10033";
                        message.Message = "没有任何一行";

                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    }



                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //绑定银行卡信息
        [WebMethod]
        public void Bind_Bank(string MemLoginID, string Bank, string BankNo, string BankAdress, string token)
        {
            GZMessage message = new GZMessage();
            string StrBankName = "";
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    DataTable member = action.GetMemInfo(MemLoginID);
                    if (member.Rows.Count > 0)
                    {
                        StrBankName = member.Rows[0]["RealName"].ToString();
                    }

                    int fh = action.UpdateMemberBank(Bank, StrBankName, BankNo, BankAdress, MemLoginID);
                    if (fh != 0)
                    {
                        message.Result = 1;
                        message.Code = "10049";
                        message.Message = "银行卡绑定成功";
                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "10050";
                        message.Message = "银行卡绑定失败";
                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    }




                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }


        //修改收货地址
        [WebMethod]
        public void Update_Address(string MemLoginID, string Guid, string Name, string Email, string Address, string Postalcode, string Mobile, string tel, string area, string addresscode, string token)
        {
            GZMessage message = new GZMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
            {
                try
                {
                    ShopNum1_Address_Action action = (ShopNum1_Address_Action)LogicFactory.CreateShopNum1_Address_Action();
                    ShopNum1_Address address = new ShopNum1_Address();
                    address.Guid = new Guid(Guid);
                    address.IsDefault = 0;
                    address.MemLoginID = MemLoginID;
                    address.Name = Name;
                    address.Email = Email;
                    address.Postalcode = Postalcode;
                    address.Mobile = Mobile;
                    address.Address = Address;
                    address.ModifyTime = DateTime.Now;
                    address.ModifyUser = MemLoginID;
                    address.AddressCode = addresscode;
                    address.AddressValue = area + "|";
                    address.Area = area;
                    address.Tel = tel;
                    address.CreateTime = DateTime.Now;
                    int fh = action.Update(address);
                    if (fh != 0)
                    {
                        message.Result = 1;
                        message.Code = "10051";
                        message.Message = "地址修改成功";
                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));

                    }
                    else
                    {
                        message.Result = 0;
                        message.Code = "10052";
                        message.Message = "地址修改失败";
                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    }




                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Code = "10010";
                    message.Message = ex.Message;

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                }
                Context.Response.End();
            }

            else
            {
                // Serialize(ContentType);
                if (ReturnValue == "0")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Code = "10086";
                    message.Message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
                    Context.Response.End();
                }

            }
        }

        //根据ID查询用户各个状态的订单数量

        [WebMethod]
        public void SelectOrderstatusByMemid(string MemLoginID, string token)
        {
            DataTable ordersgatus = new DataTable();
            GZMessage message = new GZMessage();
            try
            {

                string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
                string[] tValues = TokenPuzzle.Split('~');
                string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
                if (ReturnValue == "1" && tValues[0].ToUpper() == MemLoginID.ToUpper())
                {

                    ordersgatus = ((ShopNum1_MobileService_Action)LogicFactory.CreateShopNum1_MobileService_Action()).SelectOrderStatusNumber(MemLoginID);


                    message.Data = MobileService_All_Entity.From_SelectOrderstatusByMemid(ordersgatus);


                    List<Type> types = new List<Type>();
                    types.Add(typeof(Mobile_ShopNum1_SelectOrderStatusNum));
                    types.Add(typeof(List<Mobile_ShopNum1_SelectOrderStatusNum>));
                    Context.Response.Write(ServiceHelper.GetJSON_two<GZMessage>(message, types));


                }
                else
                {
                    // Serialize(ContentType);
                    if (ReturnValue == "0")
                    {
                        message.Result = 0;
                        message.Code = "10086";
                        message.Message = "请重新登陆哟，您的身份验证已经过期";
                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));


                    }
                    else if (ReturnValue == "2")
                    {
                        message.Result = 0;
                        message.Code = "10086";
                        message.Message = "请重新登陆哟，您的身份验证已经过期";
                        Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));


                    }
                }

            }
            catch (Exception ex)
            {
                message.Result = 0;
                message.Code = "10010";
                message.Message = ex.Message;
                Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));


            }

            Context.Response.End();
        }



        //通过GUID查询商品详细图
        [WebMethod]
        public void SelectProdctDetailByGuid(string Guid)
        {
            GZMessage message = new GZMessage();
            try
            {
                string detail = ((ShopNum1_MobileService_Action)LogicFactory.CreateShopNum1_MobileService_Action()).SelectProdctDetailByGuid(Guid);
                string shopurl = ((ShopNum1_MobileService_Action)LogicFactory.CreateShopNum1_MobileService_Action()).SelectShopInfoByGuid(Guid);
                if (detail == null || detail == "")
                {
                    message.Result = 0;
                    message.Code = "10056";
                    message.Message = "没有查询到商品数据";
                }
                else
                {
                    if (detail.Contains("http"))
                    {
                        message.Result = 1;
                        message.Code = "10057";
                        message.Message = detail;
                    }
                    else
                    {
                        string newdetail = detail.Replace("/ImgUpload/kindeditor/image/", "http://" + shopurl + ShopSettings.CookieDomain + "/ImgUpload/kindeditor/image/");
                        message.Result = 1;
                        message.Code = "10058";
                        message.Message = newdetail;
                    }
                }







            }
            catch (Exception)
            {

                message.Result = 0;
                message.Code = "10010";
                message.Message = "系统错误";



            }
            Context.Response.Write(ServiceHelper.GetJSON<GZMessage>(message));
            Context.Response.End();



        }
    }
}
