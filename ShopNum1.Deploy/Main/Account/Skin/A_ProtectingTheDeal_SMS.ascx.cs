using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_ProtectingTheDeal_SMS :  BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable memInfo =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMemInfo(base.MemLoginID);
           
            string str3 = memInfo.Rows[0]["IsMobileActivation"].ToString();
            string str4 = memInfo.Rows[0]["Mobile"].ToString();
           
            if (str3 != "1")
            {
                LinkButtonMobile.Text = "账号绑定手机之后，可以开启或关闭资金保护。";
                LinkButtonMobile.PostBackUrl = "../A_Protection.aspx?Type=3&Mobile=" + str4;
            }
            else
            {
                LinkButtonMobile.PostBackUrl = "../A_Protection.aspx";
            }
        }
    }
}