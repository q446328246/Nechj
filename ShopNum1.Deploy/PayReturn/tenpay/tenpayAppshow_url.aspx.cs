using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using ShopNum1.Common;

namespace ShopNum1.Deploy.PayReturn
{
    public partial class tenpayAppshow_url : Page, IRequiresSessionState
    {
   
        public string strOrderinfo = string.Empty;
        public string strUser = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelTime.Text = "订单于：" + DateTime.Now.ToString() + "支付成功！";
            this.strOrderinfo = "商城订单号：<span class=\"span1\">0</span>";
            if (!this.Page.IsPostBack)
            {
                if (this.Page.Request.Cookies["MemberLoginCookie"] != null)
                {
                    HttpCookie cookie = this.Page.Request.Cookies["MemberLoginCookie"];
                    HttpCookie httpCookie = HttpSecureCookie.Decode(cookie);
                    this.strUser = httpCookie.Values["MemLoginID"].ToString();
                }
                if (this.Session["orderNum"] != null)
                {
                    this.strOrderinfo = "商城订单号：<span class=\"span1\">" + this.Session["orderNum"].ToString() + "</span>";
                    this.Session.Remove("orderNum");
                }
            }
        }

    }
}