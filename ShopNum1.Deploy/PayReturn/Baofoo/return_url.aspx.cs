using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Payment;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;

namespace ShopNum1.Deploy.PayReturn.Baofoo
{
    public partial class return_url : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string text = base.Request.Params["MerchantID"];
            string text2 = base.Request.Params["TransID"];
            string text3 = base.Request.Params["Result"];
            string text4 = base.Request.Params["resultDesc"];
            string text5 = base.Request.Params["factMoney"];
            string text6 = base.Request.Params["additionalInfo"];
            string text7 = base.Request.Params["SuccTime"];
            string text8 = base.Request.Params["Md5Sign"].ToLower();
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Baofoo.aspx");
            if (paymentKey == null || paymentKey.Rows.Count <= 0)
            {
                this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
            }
            string text9 = paymentKey.Rows[0]["SecretKey"].ToString();
            string strToBeEncrypt = string.Concat(new string[]
		{
			text,
			text2,
			text3,
			text4,
			text5,
			text6,
			text7,
			text9
		});
            if (text8.ToLower() == ShopNum1.Payment.Baofoo.Md5Encrypt(strToBeEncrypt).ToLower())
            {
                base.Response.Write("OK");
                if (text2.IndexOf('C') == -1)
                {
                    ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text2);
                    int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
                    if (num == 1 || num == 0)
                    {
                        string text10 = dataTable.Rows[0]["MemLoginID"].ToString();
                        string text11 = dataTable.Rows[0]["Guid"].ToString();
                        string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                        dataTable.Rows[0]["OrderNumber"].ToString();
                        string text12 = dataTable.Rows[0]["TradeID"].ToString();
                        shopNum1_OrderInfo_Action.SetPaymentStatus2(text12, 1, 1, 0, DateTime.Now, Convert.ToDecimal(value), Convert.ToDecimal(value));
                        ShopNum1_OrderProduct_Action shopNum1_OrderProduct_Action = (ShopNum1_OrderProduct_Action)LogicFactory.CreateShopNum1_OrderProduct_Action();
                        shopNum1_OrderProduct_Action.UpdateStock(text11);
                        if (this.CheckMember(text10) == 1)
                        {
                            shopNum1_Member_Action.UpdateCostMoney(text10, Convert.ToDecimal(value));
                        }
                        this.Page.Response.Redirect("/main/member/m_index.aspx?tosurl=M_OrderDetail.aspx?guid=" + text11);
                    }
                    else
                    {
                        File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "订单当前状态：" + text4.ToString(), Encoding.UTF8);
                    }
                }
                else
                {
                    ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                    DataTable dataTable2 = shopNum1_AdvancePaymentApplyLog_Action.SelectOperateMoney("", "1", "", "", text2, "", "");
                    if (dataTable2 == null || dataTable2.Rows.Count <= 0)
                    {
                        this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
                    }
                    if (dataTable2.Rows[0]["OperateStatus"].ToString() == "0")
                    {
                        string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginId='" + dataTable2.Rows[0]["MemLoginID"].ToString() + "'");
                        this.AdvancePaymentModifyLog(1, Convert.ToDecimal(nameById), Convert.ToDecimal(((double)int.Parse(text5) * 0.01).ToString()), "宝付支付会员充值", dataTable2.Rows[0]["MemLoginID"].ToString(), Convert.ToDateTime(DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")), 1);
                        shopNum1_AdvancePaymentApplyLog_Action.ChangeApplyLogStatus(1, text2);
                    }
                    base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayDetailList.aspx");
                }
            }
            else
            {
                base.Response.Write("Md5CheckFail");
            }
        }
        protected int CheckMember(string strValue)
        {
            int result = 0;
            try
            {
                Guid guid = new Guid(strValue);
            }
            catch
            {
                result = 1;
            }
            return result;
        }
        public void AdvancePaymentModifyLog(int OperateType, decimal AdvancePayments, decimal payMoney, string Memo, string shopMemloginID, DateTime time, int type)
        {
            ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
            shopNum1_AdvancePaymentModifyLog.Guid=new Guid?(Guid.NewGuid());
            shopNum1_AdvancePaymentModifyLog.OperateType=OperateType;
            shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment=AdvancePayments;
            shopNum1_AdvancePaymentModifyLog.OperateMoney=payMoney;
            if (type == 1)
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney=AdvancePayments + payMoney;
            }
            else
            {
                shopNum1_AdvancePaymentModifyLog.LastOperateMoney=AdvancePayments - payMoney;
            }
            shopNum1_AdvancePaymentModifyLog.Date=time;
            shopNum1_AdvancePaymentModifyLog.Memo=Memo;
            shopNum1_AdvancePaymentModifyLog.MemLoginID=shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateUser=shopMemloginID;
            shopNum1_AdvancePaymentModifyLog.CreateTime=new DateTime?(time);
            shopNum1_AdvancePaymentModifyLog.IsDeleted=new int?(0);
            ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
            shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
        }

    }
}