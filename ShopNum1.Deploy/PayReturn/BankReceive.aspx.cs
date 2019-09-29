using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class BankReceive : Page, IRequiresSessionState
    {
        protected string v_oid;
        protected string v_pstatus;
        protected string v_pstring;
        protected string v_pmode;
        protected string v_amount;
        protected string v_moneytype;
        protected string remark1;
        protected string remark2;
        protected string v_md5str;
        protected string status_msg;
        protected string string_0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string arg_14_0 = HttpContext.Current.Request.Url.Host;
            ConfigurationManager.AppSettings["DoMain"].ToString();
            string text = string.Empty;
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("BankOnline.aspx");
            if (paymentKey != null && paymentKey.Rows.Count > 0)
            {
                paymentKey.Rows[0]["MerchantCode"].ToString();
                text = paymentKey.Rows[0]["SecretKey"].ToString();
            }
            this.v_oid = base.Request["v_oid"];
            this.v_pstatus = base.Request["v_pstatus"];
            this.v_pstring = base.Request["v_pstring"];
            this.v_pmode = base.Request["v_pmode"];
            this.v_md5str = base.Request["v_md5str"];
            this.v_amount = base.Request["v_amount"];
            this.v_moneytype = base.Request["v_moneytype"];
            this.remark1 = base.Request["remark1"];
            this.remark2 = base.Request["remark2"];
            string text2 = string.Concat(new string[]
		{
			this.v_oid,
			this.v_pstatus,
			this.v_amount,
			this.v_moneytype,
			text
		});
            text2 = FormsAuthentication.HashPasswordForStoringInConfigFile(text2, "md5").ToUpper();
            if (text2 == this.v_md5str)
            {
                if (this.v_pstatus.Equals("20"))
                {
                    string text3 = this.v_oid;
                    ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                    DataTable dataTable;
                    if (this.Page.Request.QueryString["PayType"] == "0")
                    {
                        dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text3);
                    }
                    else
                    {
                        dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(text3);
                    }
                    int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
                    if (num == 1 || num == 0)
                    {
                        string text4 = dataTable.Rows[0]["MemLoginID"].ToString();
                        string text5 = dataTable.Rows[0]["Guid"].ToString();
                        string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                        dataTable.Rows[0]["OrderNumber"].ToString();
                        shopNum1_OrderInfo_Action.SetPaymentStatus2(text5, 1, 1, 0, DateTime.Now, Convert.ToDecimal(this.v_amount), Convert.ToDecimal(value));
                        if (this.CheckMember(text4) == 1)
                        {
                            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                            shopNum1_Member_Action.UpdateCostMoney(text4, Convert.ToDecimal(this.v_amount));
                        }
                        this.Page.Response.Redirect(GetPageName.RetUrlMore("index", "MemberUrl=OrderDetail.aspx?guid=" + text5));
                    }
                }
            }
            else
            {
                this.status_msg = "校验失败，数据可疑";
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

    }
}