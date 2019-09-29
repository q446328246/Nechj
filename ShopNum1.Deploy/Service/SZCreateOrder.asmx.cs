using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ShopNum1.Common;
using ShopNum1.Deploy.MobileServiceAPP;
using ShopNum1.BusinessLogic;
using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Service
{
    /// <summary>
    /// SZCreateOrder 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class SZCreateOrder : System.Web.Services.WebService
    {

        
        [WebMethod]
        public void CreateOrder(string md5, string MemloginNO, decimal OrderPrice)
        {
            MMessage message = new MMessage();
            ShengZhenCreateOrder cnfirmOrderAPP = new ShengZhenCreateOrder();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "memloginNO=" + MemloginNO + "&orderPrice=" + OrderPrice + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    string order = cnfirmOrderAPP.CreateOrder(MemloginNO, OrderPrice);

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
                message.Result = 0;
                message.Error_code = "MD5对比失败";
                message.Error_message = "MD5对比失败";

                Context.Response.Write(ServiceHelper.GetJSON<MMessage>(message));

            }
        }

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



                        message.Data = ShopNum1_SZ_Member.FromDataRow(selectMember.Rows[0]);//ServiceHelper.M_json(selectGoods);

                        List<Type> types = new List<Type>();
                        types.Add(typeof(ShopNum1_SZ_Member));

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
                    DateTime dt = DateTime.Now.AddHours(2);
                    string md5 = MemberloginID + "~" + PWD + "~" + dt;
                    member_Action.UpdateMemberErrorNumGetNull(MemberloginID);
                    //string test1 = ShopNum1.Encryption.DESEncrypt.M_Encrypt(md5);
                    //string test2 = ShopNum1.Encryption.DESEncrypt.M_Decrypt(test1);

            

                    message.Data = ShopNum1_SZ_Member.FromDataRow(selectMember.Rows[0]);//ServiceHelper.M_json(selectGoods);

                    List<Type> types = new List<Type>();
                    types.Add(typeof(ShopNum1_SZ_Member));

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

    }
}
