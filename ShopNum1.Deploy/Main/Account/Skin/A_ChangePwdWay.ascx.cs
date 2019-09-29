using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_ChangePwdWay : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable memInfo =
                ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).GetMemInfo(base.MemLoginID);
            string str = memInfo.Rows[0]["IsEmailActivation"].ToString();
            string str2 = memInfo.Rows[0]["Email"].ToString();
            string str3 = memInfo.Rows[0]["IsMobileActivation"].ToString();
            string str4 = memInfo.Rows[0]["Mobile"].ToString();
            if (str != "1")
            {
                LinkButtonEmail.Text = "绑定邮箱之后，可以设置交易密码";
                LinkButtonEmail.PostBackUrl = "../A_BindEmail.aspx?Type=3&Email=" + str2;
            }
            else
            {
                LinkButtonEmail.PostBackUrl = "../A_CheckEmail.aspx";
            }
            if (str3 != "1")
            {
                LinkButtonMobile.Text = "账号绑定手机之后，可以设置交易密码";
                LinkButtonMobile.PostBackUrl = "../A_BindMobile.aspx?Type=3&Mobile=" + str4;
            }
            else
            {
                LinkButtonMobile.PostBackUrl = "../A_CheckMobile.aspx";
            }
        }
    }
}
                                            
