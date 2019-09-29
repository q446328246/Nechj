using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Data;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Common.ShopNum1.Common;
using ShopNum1.Deploy.GzWeiXinPay;

namespace ShopNum1.Deploy.Main.Account
{
    public partial class WeiXinPay : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string order = Request.QueryString["ordernumber"].ToString();
            string price = Request.QueryString["payprice"].ToString();
            NativePay nativePay = new NativePay();
            decimal shijiprice = Convert.ToDecimal(price) * 100;
            string url1 = nativePay.GetPayUrl(order, Convert.ToInt32(shijiprice));
            Image1.ImageUrl = "MakeQRCode.aspx?data=" + HttpUtility.UrlEncode(url1);
            
            
        }
    }
}