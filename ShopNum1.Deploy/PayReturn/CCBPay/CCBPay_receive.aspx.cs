using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using CCBRSA;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class CCBPay_receive : Page, IRequiresSessionState
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string publicKey = ConfigurationManager.AppSettings["ccb_PublicKey"].ToString();
                RSASig rSASig;
                try
                {
                    rSASig = new RSASigClass();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("支付失败！网上银行控件失效" + ex.Message);
                    return;
                }
                string text = base.Request.QueryString["SIGN"];
                string text2 = base.Request.QueryString["SUCCESS"];
                string text3 = base.Request.QueryString["ORDERID"];
                string text4 = base.Request.QueryString["PAYMENT"];
                string text5 = base.Request.QueryString["REMARK1"];
                string text6 = base.Request.QueryString["REMARK2"];
                string text7 = base.Request.QueryString["CURCODE"];
                ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
                DataTable paymentInfoByGuid = shopNum1_Payment_Action.GetPaymentInfoByGuid("25357722-8D29-4572-83EB-AED1A369A3DF");
                string text8 = string.Empty;
                string text9 = string.Empty;
                if (paymentInfoByGuid.Rows.Count > 0)
                {
                    text8 = string.Format("{0}", paymentInfoByGuid.Rows[0]["SecretKey"]);
                    text9 = string.Format("{0}", paymentInfoByGuid.Rows[0]["SecondKey"]);
                }
                else
                {
                    text8 = ConfigurationManager.AppSettings["ccb_POSID"].ToString();
                    text9 = ConfigurationManager.AppSettings["ccb_BRANCHID"].ToString();
                }
                string text10 = "POSID={0}&BRANCHID={1}&ORDERID={2}&PAYMENT={3}&CURCODE={4}&REMARK1={5}&REMARK2={6}&ACC_TYPE=12&SUCCESS={7}";
                text10 = string.Format(text10, new object[]
			{
				text8,
				text9,
				text3,
				text4,
				text7,
				text5,
				text6,
				text2
			});
                rSASig.setPublicKey(publicKey);
                if (rSASig.verifySigature(text, text10) && text2.ToUpper() == "Y")
                {
                    this.method_1(text3, text4, text5, text6);
                    base.Response.Redirect("/Main/Account/A_Index.aspx?toaurl=A_AdPayRecharge.aspx?type=1");
                }
            }
        }
        private void method_0(string string_0)
        {
            string path = string.Format("D:/Payment/{0}CCBlog.log", DateTime.Now.ToString("yyyy-MM-dd"));
            string str = "";
            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    str = streamReader.ReadToEnd();
                }
            }
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(str + string_0);
            }
        }
        private void method_1(string string_0, string string_1, string string_2, string string_3)
        {
            if (string_2.Equals("product"))
            {
                ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                DataTable dataTable = shopNum1_OrderInfo_Action.SearchStatus(string_0);
                int num = int.Parse(dataTable.Rows[0]["OderStatus"].ToString());
                if (num < 1)
                {
                    shopNum1_OrderInfo_Action.UpdateOrderInfoStatus_tenpay(string_0, "OderStatus", "1");
                }
            }
            else
            {
                if (string_2.Equals("Recharge") && string_2.IndexOf('_') != -1)
                {
                    try
                    {
                        ShopNum1_AdvancePaymentModifyLog_Action shopNum1_AdvancePaymentModifyLog_Action = (ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action();
                        DataTable advancePaymentModifyLog = shopNum1_AdvancePaymentModifyLog_Action.GetAdvancePaymentModifyLog(string_2.Split(new char[]
					{
						'_'
					})[1].ToString());
                        if (advancePaymentModifyLog != null && advancePaymentModifyLog.Rows.Count > 0 && advancePaymentModifyLog.Rows[0]["OperateStatus"].ToString() == "0")
                        {
                            string text = string.Empty;
                            text = string_2.Split(new char[]
						{
							'_'
						})[1].ToString();
                            shopNum1_AdvancePaymentModifyLog_Action.ChangeOperateStatus(text, 1);
                            string nameById = ShopNum1.Common.Common.GetNameById("advancepayment", "shopnum1_member", " and memloginid='" + string_3 + "'");
                            if (nameById != "")
                            {
                                ShopNum1_AdvancePaymentModifyLog shopNum1_AdvancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog();
                                shopNum1_AdvancePaymentModifyLog.Guid=new Guid?(Guid.NewGuid());
                                shopNum1_AdvancePaymentModifyLog.OperateType=3;
                                shopNum1_AdvancePaymentModifyLog.CurrentAdvancePayment=Convert.ToDecimal(nameById);
                                shopNum1_AdvancePaymentModifyLog.OperateMoney=Convert.ToDecimal(string_1);
                                shopNum1_AdvancePaymentModifyLog.LastOperateMoney=Convert.ToDecimal(nameById) + Convert.ToDecimal(shopNum1_AdvancePaymentModifyLog.OperateMoney);
                                shopNum1_AdvancePaymentModifyLog.Date=Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                shopNum1_AdvancePaymentModifyLog.Memo="建行网银充值";
                                shopNum1_AdvancePaymentModifyLog.MemLoginID=string_3;
                                shopNum1_AdvancePaymentModifyLog.CreateUser=string_3;
                                shopNum1_AdvancePaymentModifyLog.CreateTime=new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                                shopNum1_AdvancePaymentModifyLog.IsDeleted=new int?(0);
                                shopNum1_AdvancePaymentModifyLog_Action.OperateMoney(shopNum1_AdvancePaymentModifyLog);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

    }
}