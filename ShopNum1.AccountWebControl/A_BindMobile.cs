﻿using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_BindMobile : BaseMemberWebControl
    {
        private Label Lab_MemLoginID;
        private HtmlInputText M_code;
        private Button btn_Next;
        private HtmlContainerControl divProMobile;
        private HtmlInputHidden hid_Mobile;
        private string skinFilename = "A_BindMobile.ascx";
        private string string_1 = string.Empty;

        public A_BindMobile()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
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

        protected override void InitializeSkin(Control skin)
        {
            btn_Next = (Button) skin.FindControl("btn_Next");
            btn_Next.Click += btn_Next_Click;
            M_code = (HtmlInputText) skin.FindControl("M_code");
            hid_Mobile = (HtmlInputHidden) skin.FindControl("hid_Mobile");
            Lab_MemLoginID = (Label) skin.FindControl("Lab_MemLoginID");
            Lab_MemLoginID.Text = base.MemLoginID;
            divProMobile = (HtmlContainerControl) skin.FindControl("divProMobile");
            hid_Mobile.Value = Common.Common.ReqStr("mobile");
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