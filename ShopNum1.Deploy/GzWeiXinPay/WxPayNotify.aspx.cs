using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.GzWeiXinPay
{
    public partial class WxPayNotify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            NativeNotify nativeNatify = new NativeNotify(this);
            
            nativeNatify.ProcessNotify();
        }
    }
}