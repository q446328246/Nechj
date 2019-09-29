using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_PwdSer : BaseMemberWebControl
    {
        private Image Image_SafeRankImg;
        private Label Lab_SafeRank;
        private Label Lab_SafeRankTitle;
        private LinkButton LinkButton_Email;
        private LinkButton LinkButton_Mobile;
        private LinkButton LinkButton_Set;
        private HiddenField hfTradePwd;
        private string skinFilename = "A_PwdSer.ascx";

        public A_PwdSer()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            Lab_SafeRank = (Label) skin.FindControl("Lab_SafeRank");
            Lab_SafeRankTitle = (Label) skin.FindControl("Lab_SafeRankTitle");
            Image_SafeRankImg = (Image) skin.FindControl("Image_SafeRankImg");
            LinkButton_Mobile = (LinkButton) skin.FindControl("LinkButton_Mobile");
            LinkButton_Email = (LinkButton) skin.FindControl("LinkButton_Email");
            LinkButton_Set = (LinkButton) skin.FindControl("LinkButton_Set");
            hfTradePwd = (HiddenField) skin.FindControl("hfTradePwd");
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            var table = new DataTable();
            try
            {
                if (action.CheckSafeRank(base.MemLoginID, "and").Rows.Count > 0)
                {
                    Lab_SafeRank.Text = "高";
                    Lab_SafeRankTitle.Text = "账号已经设置了交易密码和手机绑定，请保管好手机，交易密码可重置";
                    Image_SafeRankImg.ImageUrl = "/Main/Account/images/jidongt03.jpg";
                    LinkButton_Mobile.Visible = false;
                    LinkButton_Email.Visible = false;
                }
                else
                {
                    table = action.CheckSafeRank(base.MemLoginID, "or");
                    if (table.Rows.Count > 0)
                    {
                        Lab_SafeRank.Text = "中";
                        Lab_SafeRankTitle.Text = "账号已经设置了交易密码和手机绑定，请保管好手机，交易密码可重置";
                        Image_SafeRankImg.ImageUrl = "/Main/Account/images/jidongt02.jpg";
                        string str = table.Rows[0]["IsEmailActivation"].ToString();
                        string str2 = table.Rows[0]["IsMobileActivation"].ToString();
                        if (str != "1")
                        {
                            Lab_SafeRankTitle.Text = "您的账户安全级别一般，为确保您账户安全，请您尽快提高安全等级，绑定邮箱";
                            LinkButton_Email.Visible = true;
                            LinkButton_Mobile.Visible = false;
                        }
                        else if (str2 != "1")
                        {
                            Lab_SafeRankTitle.Text = "您的账户安全级别一般，为确保您账户安全，请您尽快提高安全等级，绑定手机号码";
                            LinkButton_Mobile.Visible = true;
                            LinkButton_Email.Visible = false;
                        }
                    }
                    else
                    {
                        Lab_SafeRank.Text = "低";
                        Lab_SafeRankTitle.Text = "您的账户安全级别较低，为确保您账户安全，请您尽快提高安全等级";
                        Image_SafeRankImg.ImageUrl = "/Main/Account/images/jidongt01.jpg";
                        LinkButton_Mobile.Text = "手机绑定|";
                        LinkButton_Email.Text = "邮箱绑定";
                        LinkButton_Mobile.Visible = true;
                        LinkButton_Email.Visible = true;
                        hfTradePwd.Value = "0";
                    }
                }
            }
            catch
            {
            }
        }
    }
}