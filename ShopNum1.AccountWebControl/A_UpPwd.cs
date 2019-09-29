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
    public class A_UpPwd : BaseMemberWebControl
    {
        private HtmlInputPassword Input_NewPwd;
        private HtmlInputText Input_NewSecondPwd;
        private HtmlInputPassword Input_OldPwd;
        private Button btn_Back;
        private Button btn_UpPwd;
        private HtmlInputHidden hid_Count;
        private string skinFilename = "A_UpPwd.ascx";

        public A_UpPwd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int Count { get; set; }

        public string NewPwd { get; set; }

        public string OldPwd { get; set; }

        public string RNewPwd { get; set; }

        private void btn_UpPwd_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string str = Encryption.GetMd5Hash(Input_OldPwd.Value.Trim());
            string newPwd = Encryption.GetMd5Hash(Input_NewPwd.Value.Trim());
            string str3 = Encryption.GetMd5Hash(Input_NewSecondPwd.Value.Trim());
            if (action.CheckPassword(base.MemLoginID, str) > 0)
            {
                if (newPwd == str3)
                {
                    if (action.UpdatePwd(base.MemLoginID, newPwd) > 0)
                    {
                        MessageBox.Show("修改成功");
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("旧密码错误");
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("A_PwdSer.aspx");
        }

        protected override void InitializeSkin(Control skin)
        {
            Input_OldPwd = (HtmlInputPassword) skin.FindControl("Input_OldPwd");
            Input_NewPwd = (HtmlInputPassword) skin.FindControl("Input_NewPwd");
            Input_NewSecondPwd = (HtmlInputPassword) skin.FindControl("Input_NewSecondPwd");
            btn_UpPwd = (Button) skin.FindControl("btn_UpPwd");
            btn_UpPwd.Click += btn_UpPwd_Click;
            btn_Back = (Button) skin.FindControl("btn_Back");
            btn_Back.Click += btn_Back_Click;
            hid_Count = (HtmlInputHidden) skin.FindControl("hid_Count");
        }
    }
}