using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_BindEmail : BaseMemberControl
    {
        private string string_1 = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
          //  hid_Email.Value = Common.Common.ReqStr("Email");
            string_1 = Common.Common.ReqStr("type");
            if (string_1 == "2")
            {
                divProEmail.Visible = true;
            }
            else
            {
                divProEmail.Visible = false;
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
                Page.Response.Redirect("A_UpPayPwd.aspx?Email=" + hid_Email.Value + "&key=" + str);
            }
            else
            {
                method_1(str);
                Page.Response.Redirect("A_PwdSer.aspx");
            }
        }



        private void method_0()
        {
            if (!string.IsNullOrEmpty(hid_Email.Value))
            {
                Common.Common.UpdateInfo("Email='" + hid_Email.Value + "', IsEmailActivation=1",
                    "ShopNum1_Member", " and  MemLoginID='" + base.MemLoginID + "'");
            }
        }

        private void method_1(string string_2)
        {
            ((ShopNum1_MemberActivate_Action) LogicFactory.CreateShopNum1_MemberActivate_Action()).DeleteKey(
                base.MemLoginID, string_2);
        }
    }
}