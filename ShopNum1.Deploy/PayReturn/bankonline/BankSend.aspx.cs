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

namespace ShopNum1.Deploy.PayReturn.bankonline
{
    public partial class BankSend : Page, IRequiresSessionState
    {
        protected string v_amount;
        protected string v_moneytype;
        protected string v_md5info;
        protected string v_mid;
        protected string v_url;
        protected string v_oid;
        protected string v_rcvname;
        protected string v_rcvaddr;
        protected string v_rcvtel;
        protected string v_rcvpost;
        protected string v_rcvemail;
        protected string v_rcvmobile;
        protected string v_ordername;
        protected string v_orderaddr;
        protected string v_ordertel;
        protected string v_orderpost;
        protected string v_orderemail;
        protected string v_ordermobile;
        protected string pmode_id;
        protected string remark1;
        protected string remark2;
        protected string strAgentID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.Request.QueryString["AgentID"] != null)
            {
                this.strAgentID = this.Page.Request.QueryString["AgentID"].ToString();
            }
            string text = string.Empty;
            if (this.Page.Request.QueryString["ID"] != null)
            {
                ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
                DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Send.aspx");
                if (paymentKey == null || paymentKey.Rows.Count <= 0)
                {
                    this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
                }
                this.v_mid = paymentKey.Rows[0]["MerchantCode"].ToString();
                this.v_url = "http://" + ConfigurationManager.AppSettings["Domain"] + ConfigurationManager.AppSettings["receivebank_url"];
                text = paymentKey.Rows[0]["SecretKey"].ToString();
                ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
                DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(this.Page.Request.QueryString["ID"]);
                ShopNum1_AdvancePaymentApplyLog_Action shopNum1_AdvancePaymentApplyLog_Action = (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
                DataTable dataTable2 = shopNum1_AdvancePaymentApplyLog_Action.Search(this.Page.Request.QueryString["ID"], "", "", "", -1, -1, 0);
                if (dataTable2 != null && dataTable2.Rows.Count > 0)
                {
                    this.v_oid = this.Page.Request.QueryString["ID"];
                    this.v_amount = dataTable2.Rows[0]["OperateMoney"].ToString();
                    if (decimal.Parse(this.v_amount) <= 0m)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msg", "window.alert(\"支付金额必须大于0！\");window.location.href='" + GetPageName.RetUrl("Default") + "'", true);
                    }
                    else
                    {
                        this.v_moneytype = "CNY";
                        string password = string.Concat(new string[]
					{
						this.v_amount,
						this.v_moneytype,
						this.v_oid,
						this.v_mid,
						this.v_url,
						text
					});
                        this.v_md5info = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5").ToUpper();
                        this.v_rcvname = dataTable2.Rows[0]["MemLoginID"].ToString();
                        this.v_rcvaddr = "";
                        this.v_rcvtel = "";
                        this.v_rcvpost = "";
                        this.v_rcvemail = "";
                        this.v_rcvmobile = "";
                        this.v_ordername = dataTable2.Rows[0]["MemLoginID"].ToString();
                        this.v_orderaddr = "";
                        this.v_ordertel = "";
                        this.v_orderpost = "";
                        this.v_orderemail = "";
                        this.v_ordermobile = "";
                        this.remark1 = HttpUtility.UrlEncode(this.method_0());
                        this.remark2 = HttpUtility.UrlEncode(this.method_0());
                    }
                }
                else
                {
                    if (dataTable == null || dataTable.Rows.Count <= 0)
                    {
                        this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
                    }
                    this.v_oid = dataTable.Rows[0]["OrderNumber"].ToString();
                    if (string.IsNullOrEmpty(dataTable.Rows[0]["OrderNumber"].ToString()))
                    {
                        DateTime now = DateTime.Now;
                        string str = now.ToString("yyyyMMdd");
                        string str2 = now.ToString("HHmmss");
                        this.v_oid = str + this.v_mid + str2;
                    }
                    this.v_amount = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                    if (decimal.Parse(this.v_amount) <= 0m)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msg", "window.alert(\"支付金额必须大于0！\");window.location.href='" + GetPageName.RetUrl("Default") + "'", true);
                    }
                    else
                    {
                        this.v_moneytype = "CNY";
                        string password = string.Concat(new string[]
					{
						this.v_amount,
						this.v_moneytype,
						this.v_oid,
						this.v_mid,
						this.v_url,
						text
					});
                        this.v_md5info = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5").ToUpper();
                        this.v_rcvname = dataTable.Rows[0]["Name"].ToString();
                        this.v_rcvaddr = dataTable.Rows[0]["Address"].ToString();
                        this.v_rcvtel = dataTable.Rows[0]["Tel"].ToString();
                        this.v_rcvpost = dataTable.Rows[0]["Postalcode"].ToString();
                        this.v_rcvemail = dataTable.Rows[0]["Email"].ToString();
                        this.v_rcvmobile = dataTable.Rows[0]["Mobile"].ToString();
                        this.v_ordername = dataTable.Rows[0]["Name"].ToString();
                        this.v_orderaddr = dataTable.Rows[0]["Address"].ToString();
                        this.v_ordertel = dataTable.Rows[0]["Tel"].ToString();
                        this.v_orderpost = dataTable.Rows[0]["Postalcode"].ToString();
                        this.v_orderemail = dataTable.Rows[0]["Email"].ToString();
                        this.v_ordermobile = dataTable.Rows[0]["Mobile"].ToString();
                        this.remark1 = dataTable.Rows[0]["ClientToSellerMsg"].ToString();
                        this.remark2 = "";
                    }
                }
            }
            else
            {
                this.Page.Response.Redirect(GetPageName.RetUrl("Default"));
            }
        }

        private string method_0()
        {
            string result = "jely";
            if (HttpContext.Current.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["MemberLoginCookie"];
                HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                result = httpCookie.Values["MemLoginID"].ToString();
            }
            return result;
        }

    }
}