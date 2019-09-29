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
    /// Qhtj88CreateOrder 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Qhtj88CreateOrder : System.Web.Services.WebService
    {

        [WebMethod]
        public void CreateOrder(string md5, string MemloginNO, int LevelType)
        {
            MMessage message = new MMessage();
            QHTj88CreateOrder QHTJ88 = new QHTj88CreateOrder();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "MemloginNO=" + MemloginNO + "&LevelType=" + LevelType + md5_one + "";
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);

            if (md5Check_two.ToUpper() == md5.ToUpper())
            {
                try
                {
                    string order = QHTJ88.CreateOrder(MemloginNO, LevelType);

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

                   

                }
                catch (Exception ex)
                {

                    message.Result = 0;
                    message.Error_code = ex.Message;
                    message.Error_message = ex.Message;

                    

                }
          
            }

            else
            {
                message.Result = 0;
                message.Error_code = "MD5对比失败";
                message.Error_message = "MD5对比失败";



            }
        }
    }
}
