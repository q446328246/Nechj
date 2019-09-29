using System;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_BindMobile : BaseMemberControl
    {
        private string string_1 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string_1 = Common.Common.ReqStr("type");
            if (string_1 == "2")
            {
                divProMobile.Visible = true;
            }
            else
            {
                divProMobile.Visible = false;
            }
        }

        protected void btn_Next_Click(object sender, EventArgs e)
        {
            string str = M_code.Value;
            method_0();
            if ((string_1 == "1") || (string_1 == "2"))
            {
                method_1(str);
                Page.Response.Redirect("A_MemInfo.aspx");
            }
            else if (string_1 == "3")
            {
                Page.Response.Redirect("A_UpPayPwd.aspx?Mobile=" + hid_Mobile.Value + "&key=" + str);
            }
            else
            {
                method_1(str);
                Page.Response.Redirect("A_PwdSer.aspx");
            }
        }



        private int method_0()
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            return action.UpdataIsMobileActivation(base.MemLoginID, hid_Mobile.Value);
        }

        private void method_1(string string_2)
        {
            ((ShopNum1_MemberActivate_Action) LogicFactory.CreateShopNum1_MemberActivate_Action()).DeleteKey(
                base.MemLoginID, string_2);
        }
    }
}
                                            
