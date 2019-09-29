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
namespace ShopNum1.MobileService
{
    public class ServiceConfirmOrder : BaseWebControl
    {
        public string CreatOrderInfo(ShopNum1_OrderInfo shopNum1_OrderInfo, ShopNum1_Address shopNum1_Address, List<ShopNum1_OrderProduct> list) 
        {
            if (shopNum1_OrderInfo.Mobile != "" &&
                    shopNum1_OrderInfo.Address.Replace(",", "").Trim() != "-1")
            {
                IShopNum1_Address_Action shopNum1_Address_Action =
                    LogicFactory.CreateShopNum1_Address_Action();
                shopNum1_Address_Action.Add(shopNum1_Address);
                Thread.Sleep(100);
            }
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action =
                (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            string nameById42221 = Common.Common.GetNameById("mobile", "shopnum1_member",
                      " and memloginid='" + shopNum1_OrderInfo.MemLoginID + "'");
            int num = shopNum1_OrderInfo_Action.Add(shopNum1_OrderInfo, list);
            if (num > 0)
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
                string Success = "购买成功 订单号："+shopNum1_OrderInfo.TradeID;
                return Success;
            }
            
            
                return "购买失败";
            
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

        protected override void InitializeSkin(Control skin)
        {
            throw new NotImplementedException();
        }
    }
}
