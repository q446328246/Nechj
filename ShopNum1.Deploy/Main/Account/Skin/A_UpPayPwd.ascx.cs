

using System;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using System.Data;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_UpPayPwd : BaseMemberControl
    {
        private string string_1 = string.Empty;
        private string string_2 = string.Empty;
        private string string_3 = string.Empty;


        public string NewPayPwd { get; set; }

        public string RNewPayPwd { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

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
                    var action = (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
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

        protected void LinkButton_Save_Click(object sender, EventArgs e)
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
                string payPwd = Common.Encryption.GetMd5SecondHash(Input_NewPayPwd.Value.Trim());
                string str2 = Common.Encryption.GetMd5SecondHash(Input_NewSecondPayPwd.Value.Trim());
                if (payPwd == str2)
                {
                    var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                    try
                    {
                        if (action.UpdatePayPwd(base.MemLoginID, payPwd) > 0)
                        {
                            MessageBox.Show("设置成功");
                            var action2 =
                                (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
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

