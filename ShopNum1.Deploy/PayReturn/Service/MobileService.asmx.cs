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

        [WebMethod]
        public void Login(string MemberloginID, string PWD)
        {
            DataTable selectMember = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberAll(MemberloginID, Common.Encryption.GetMd5Hash(PWD));
            MMessage message = new MMessage();

            if (selectMember.Rows.Count > 0)
            {
                if (selectMember.Rows[0]["IsForbid"].ToString()=="1")
                {
                    message.Result = 0;
                    message.Error_code = "用户已经被禁用";
                    message.Error_message = "用户已经被禁用";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else
                {
                    DateTime dt = DateTime.Now.AddHours(2);
                    string md5 = MemberloginID + "~" + PWD + "~" + dt;

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

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                Context.Response.End();
            }
            
           
            
        }

        
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

                try{
               
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
                try{
                
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
        [WebMethod]
        public void SelectMemberInfoAllByMemloginID(string memberloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);
            if (ReturnValue=="1")
            {
                try{
                DataTable SelectMemberInfoAllByMemberLoingID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberInfoByMemloginID(memberloginID);
                
                 List<Type> types = new List<Type>();
                 types.Add(typeof(ShopNum1_M_Member));
                 message.Data = ShopNum1_M_Member.FromDataRowGetMoney(SelectMemberInfoAllByMemberLoingID.Rows[0]);
                     Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                
                }
                catch (Exception ex )
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
                if (ReturnValue=="0")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue=="2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
               
            }

        }
        [WebMethod]
        public void SelectAddressByMemberloginID(string memberloginID, string token)
        {
               MMessage message = new MMessage();
               string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
               string[] tValues = TokenPuzzle.Split('~');
               string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try{
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        [WebMethod]
        public void SelectUserMessageBymemberloginID(string memberloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try{
                DataTable SelectAddressByMemloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectUserMessageByMemberloginID(memberloginID);

                List<Type> types = new List<Type>();
                types.Add(typeof(ShopNum1_M_UserMessage));
                types.Add(typeof(List<ShopNum1_M_UserMessage>));
                message.Data = ShopNum1_M_UserMessage.FromDataRowGetUserMessage(SelectAddressByMemloginID);
                Context.Response.Write(ServiceHelper.GetJSON_two<MMessage>(message, types));
                
                }
                catch (Exception ex )
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }



        [WebMethod]
        public void SelectMemberRank_LinkCategory(string memberloginID, string token, int IsReadOrBuy,int Category_ID)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                DataTable MemberInfoByMemloginID = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetALLMemberInfoByMemloginID(memberloginID);
                string MemberRankGuid = MemberInfoByMemloginID.Rows[0]["MemberRankGuid"].ToString();
                DataTable MemberRank_LinkCategory = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SelectMemberRank_LinkCategory(MemberRankGuid, IsReadOrBuy, Category_ID);
                if (MemberRank_LinkCategory== null || MemberRank_LinkCategory.Rows.Count==0)
                {
                    try{
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


        [WebMethod]
        public void SelectOrderByMemberloginID(string memberloginID, string token,int startnum, int ordernumber)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try{
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }



       [WebMethod]
        public void SelectOrderByMemberloginID_GetCount(string memberloginID, string token)
        {
            MMessage message = new MMessage();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }


        [WebMethod]
        public void CreateOrder(string token, string ServiceAgent, string MemloginID, int ShopCategoryID, int PayMentType, string ProductGuid, int BuyNumber, decimal PostPrice, string Color, string Size, string AddressGuid,string TextBoxMessage, string InvoiceType, string InvoiceTitle, string InvoiceContent)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try{
                string order = cnfirmOrderAPP.CreateOrder(ServiceAgent, MemloginID, ShopCategoryID, PayMentType, ProductGuid, BuyNumber, PostPrice, Color, Size, AddressGuid,TextBoxMessage,  InvoiceType,  InvoiceTitle,  InvoiceContent);

                switch (order)
                {
                    case    "1":
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }



        [WebMethod]
        public void AddShopCar(string MyMemLoginID, string category, string Num, string guid,string token)
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
                    string order = cnfirmOrderAPP.AddShopCar(MyMemLoginID, category, Num, guid);
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }



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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }



      


        [WebMethod]
        public void CreateOrderCar(string ServiceAgent, string MemloginID, int ShopCategoryID, int PayMentType, string ProductGuids, int BuyNumber, decimal PostPrice, string Color, string Size, string AddressGuid, string ShopID, string token,string TextBoxMessage, string InvoiceType, string InvoiceTitle, string InvoiceContent)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try{
                 string order = cnfirmOrderAPP.CreateOrderCar( ServiceAgent,  MemloginID,  ShopCategoryID,  PayMentType,  ProductGuids,  BuyNumber,  PostPrice,  Color,  Size,  AddressGuid,  ShopID, TextBoxMessage,  InvoiceType,  InvoiceTitle,  InvoiceContent);
                
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

        [WebMethod]
        public void ADDAddress(string Name, string Email, string AddressValue, string Area, string AddressCode, string Postalcode, string Tel, string Mobile, string MemLoginID, string Address, string token)
        {
            MMessage message = new MMessage();
            ConfirmOrderAPP cnfirmOrderAPP = new ConfirmOrderAPP();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                int num = 0;
                try {
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
                    shopNum1_Address.IsDefault = 0;
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }



        [WebMethod]
        public void  MobileServiceRecharge(string token, string MemloginID, decimal RechargeBV, int RechargeType, string UserName, string BankCard, int BankCardType)
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
                            message.Error_code = "充值失败";
                            message.Error_message = "充值失败";
                            break;
                        case "4":
                            message.Result = 0;
                            message.Error_code = "线下支付提交成功，请及时汇款";
                            message.Error_message = "线下支付提交成功，请及时汇款";
                            break;
                        case "5":
                            message.Result = 0;
                            message.Error_code = "充值金额错误";
                            message.Error_message = "充值金额错误";
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
                    message.Error_code =  ex.Message;
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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }



        [WebMethod]
        public void Pay(string OrderNumber, string MemloginID, string ScoreHvType, string PayPwd,string token)
        {
            MMessage message = new MMessage();
            PayApp payApp = new PayApp();
            string TokenPuzzle = ShopNum1.Encryption.DESEncrypt.M_Decrypt(ServiceHelper.FormatParam(token));
            string[] tValues = TokenPuzzle.Split('~');
            string ReturnValue = ServiceHelper.UserAuthentication(tValues[0], tValues[1], tValues[2]);

            if (ReturnValue == "1")
            {
                try
                {
                    string order = payApp.Pay( OrderNumber,  MemloginID,  ScoreHvType,  PayPwd);

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
                    message.Error_code = "TKON里的值错误（有效时间已过期）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }
                else if (ReturnValue == "2")
                {
                    message.Result = 0;
                    message.Error_code = "TKON里的值错误（账户密码不匹配）";
                    message.Error_message = "请重新登陆哟，您的身份验证已经过期";

                    Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));
                    Context.Response.End();
                }

            }
        }

    }



}
