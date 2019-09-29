using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_UpPayPwd : BaseMemberWebControl
    {
        private HtmlInputPassword Input_NewPayPwd;
        private HtmlInputPassword Input_NewSecondPayPwd;
        private Label Lab_MemLoginID;
        private Label Lab_MobileOrEmailText;
        private Label Lab_MobileOrEmailValue;
        private LinkButton LinkButton_Save;
        //private LinkButton linkButton_1;
        private string skinFilename = "A_UpPayPwd.ascx";
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;

        public A_UpPayPwd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string NewPayPwd { get; set; }

        public string RNewPayPwd { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            Lab_MemLoginID = (Label) skin.FindControl("Lab_MemLoginID");
            Input_NewPayPwd = (HtmlInputPassword) skin.FindControl("Input_NewPayPwd");
            Input_NewSecondPayPwd = (HtmlInputPassword) skin.FindControl("Input_NewSecondPayPwd");
            LinkButton_Save = (LinkButton) skin.FindControl("LinkButton_Save");
            LinkButton_Save.Click += LinkButton_Save_Click;
            Lab_MobileOrEmailValue = (Label) skin.FindControl("Lab_MobileOrEmailValue");
            Lab_MobileOrEmailText = (Label) skin.FindControl("Lab_MobileOrEmailText");
            string_1 = Common.Common.ReqStr("key");
            Lab_MemLoginID.Text = base.MemLoginID;
            if (
                !(((Common.Common.ReqStr("Email") != null) || (Common.Common.ReqStr("Mobile") != null))
                    ? !(string_1 != "")
                    : true))
            {
                try
                {
                    string_2 = (Common.Common.ReqStr("Email") == "") ? "Mobile" : "Email";
                    string_3 = (Common.Common.ReqStr("Email") == "")
                        ? Common.Common.ReqStr("Mobile")
                        : Common.Common.ReqStr("Email");
                    var action = (ShopNum1_MemberActivate_Action) LogicFactory.CreateShopNum1_MemberActivate_Action();
                    if (!action.CheckKey(string_2, base.MemLoginID, string_1, string_3))
                    {
                        if (string_2 == "Email")
                        {
                            Page.Response.Redirect("A_CheckEmail.aspx");
                        }
                        if (string_2 == "Mobile")
                        {
                            Page.Response.Redirect("A_CheckEmail.aspx");
                        }
                        else
                        {
                            Page.Response.Redirect("A_PwdSer.aspx");
                        }
                    }
                }
                catch
                {
                    Page.Response.Redirect("A_PwdSer.aspx");
                }
            }
            else
            {
                Page.Response.Redirect("A_PwdSer.aspx");
            }
        }

        private void LinkButton_Save_Click(object sender, EventArgs e)
        {
            method_0();
        }

        private void method_0()
        {
            if (Input_NewPayPwd.Value == "")
            {
                MessageBox.Show("交易密码不能为空");
            }
            else if (Input_NewSecondPayPwd.Value == "")
            {
                MessageBox.Show("重复的交易密码不能为空");
            }
            else if (Input_NewPayPwd.Value != Input_NewSecondPayPwd.Value)
            {
                MessageBox.Show("两次输入的不一样");
            }
            else
            {
                string payPwd = Encryption.GetMd5SecondHash(Input_NewPayPwd.Value.Trim());
                string str2 = Encryption.GetMd5SecondHash(Input_NewSecondPayPwd.Value.Trim());
                if (payPwd == str2)
                {
                    var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                    try
                    {
                        if (action.UpdatePayPwd(base.MemLoginID, payPwd) > 0)
                        {
                            MessageBox.Show("设置成功");
                            var action2 =
                                (ShopNum1_MemberActivate_Action) LogicFactory.CreateShopNum1_MemberActivate_Action();
                            if (action2.DeleteKey(base.MemLoginID, string_1) > 0)
                            {
                                Page.Response.Redirect("A_UpPayPwdSucceed.aspx");
                            }
                        }
                        else
                        {
                            MessageBox.Show("设置失败");
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}