using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class NetPaySubmit : Page, IRequiresSessionState
    {

        public string strAgentID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string text = base.Request.QueryString["id"].ToString();
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfoByOrdernum(text, "-1");
            if (dataTable.Rows.Count > 0)
            {
                string guid = dataTable.Rows[0]["PaymentGuid"].ToString();
                string text2 = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                string text3 = dataTable.Rows[0]["Createtime"].ToString();
                string text4 = dataTable.Rows[0]["PayMemo"].ToString();
                DataTable paymentInfoByGuid = shopNum1_Payment_Action.GetPaymentInfoByGuid(guid);
                if (paymentInfoByGuid.Rows.Count > 0)
                {
                    string text5 = paymentInfoByGuid.Rows[0]["MerchantCode"].ToString();
                    paymentInfoByGuid.Rows[0]["Name"].ToString();
                    string text6 = text5;
                    if (text.Length < 16)
                    {
                        text += "0000000000000000";
                        text = text.Substring(0, 16);
                    }
                    if (text.Length > 16)
                    {
                        text = text.Substring(0, 16);
                    }
                    string text7 = text;
                    string str = text2.Split(new char[]
				{
					'.'
				})[0].ToString();
                    string str2 = text2.Split(new char[]
				{
					'.'
				})[1].ToString();
                    text2 = str + str2;
                    if (text2.Length < 12)
                    {
                        text2 = "000000000000" + text2;
                        text2 = text2.Substring(text2.Length - 12, 12);
                    }
                    string text8 = text2;
                    string text9 = this.CuryId.Text;
                    text3 = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(text3));
                    text3 = text3.Split(new char[]
				{
					'-'
				})[0].ToString() + text3.Split(new char[]
				{
					'-'
				})[1].ToString() + text3.Split(new char[]
				{
					'-'
				})[2].ToString();
                    string text10 = text3;
                    string text11 = this.TransType.Text;
                    this.MerId.Text = text5;
                    this.OrdID.Text = text;
                    this.TransAmt.Text = text2;
                    this.TransDate.Text = text3;
                    this.Priv1.Text = text4;
                    this.BgRetUrl.Text = "http://" + HttpContext.Current.Request.Url.Host + "/PayRetrun/netpayclient_order_feedback.aspx";
                    this.PageRetUrl.Text = "http://" + HttpContext.Current.Request.Url.Host + "/PayReturn/netpayclient_order_feedback.aspx";
                    string text12 = this.Priv1.Text;
                    string str3 = string.Concat(new string[]
				{
					text6,
					text7,
					text8,
					text9,
					text10,
					text11,
					text12
				});
                    base.Response.Write("MerId:" + text6);
                    base.Response.Write("ChkValue:" + str3);
                }
            }
        }
    }
}