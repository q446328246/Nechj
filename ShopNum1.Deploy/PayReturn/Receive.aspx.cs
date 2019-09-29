using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class Receive : Page, IRequiresSessionState
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
        public bool IsDoMain;
        public string AgentHost = string.Empty;
  
        protected void Page_Load(object sender, EventArgs e)
        {
            ShopNum1_Member_Action shopNum1_Member_Action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string text = string.Empty;
            this.v_oid = base.Request["v_oid"];
            ShopNum1_OrderInfo_Action shopNum1_OrderInfo_Action = (ShopNum1_OrderInfo_Action)LogicFactory.CreateShopNum1_OrderInfo_Action();
            DataTable dataTable = shopNum1_OrderInfo_Action.SearchOrderInfo(this.v_oid);
            ShopNum1_Payment_Action shopNum1_Payment_Action = (ShopNum1_Payment_Action)LogicFactory.CreateShopNum1_Payment_Action();
            DataTable paymentKey = shopNum1_Payment_Action.GetPaymentKey("Send.aspx");
            text = paymentKey.Rows[0]["SecretKey"].ToString();
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
                    int num = int.Parse(dataTable.Rows[0]["PaymentStatus"].ToString());
                    if (num == 1 || num == 0)
                    {
                        string text3 = dataTable.Rows[0]["MemLoginID"].ToString();
                        string text4 = dataTable.Rows[0]["Guid"].ToString();
                        string value = dataTable.Rows[0]["ShouldPayPrice"].ToString();
                        dataTable.Rows[0]["OrderNumber"].ToString();
                        shopNum1_OrderInfo_Action.SetPaymentStatus2(text4, 1, 1, 0, DateTime.Now, Convert.ToDecimal(this.v_amount), Convert.ToDecimal(value));
                        if (this.CheckMember(text3) == 1)
                        {
                            shopNum1_Member_Action.UpdateCostMoney(text3, Convert.ToDecimal(this.v_amount));
                        }
                        this.Page.Response.Redirect(GetPageName.RetUrlMore("index", "shopurl=OrderDetail.aspx?guid=" + text4));
                    }
                    else
                    {
                        File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "订单当前状态：" + this.v_pstatus.ToString(), Encoding.UTF8);
                    }
                }
                else
                {
                    File.AppendAllText(base.Server.MapPath("~/log/log.txt"), "返回状态：" + this.v_pstatus.ToString(), Encoding.UTF8);
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