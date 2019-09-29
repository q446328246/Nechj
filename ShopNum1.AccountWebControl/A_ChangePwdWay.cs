using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_ChangePwdWay : BaseMemberWebControl
    {
        private LinkButton LinkButtonEmail;
        private LinkButton LinkButtonMobile;
        private string skinFilename = "A_ChangePwdWay.ascx";

        public A_ChangePwdWay()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LinkButtonEmail = (LinkButton) skin.FindControl("LinkButtonEmail");
            LinkButtonMobile = (LinkButton) skin.FindControl("LinkButtonMobile");
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