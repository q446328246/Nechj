using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1.Common;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_UpPayPwd1 : BaseMemberControl
    {
        public int Count { get; set; }

        public string NewPwd { get; set; }

        public string OldPwd { get; set; }

        public string RNewPwd { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_UpPwd_Click(object sender, EventArgs e)
        {
            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            //string str = ShopNum1.Common.Encryption.GetMd5SecondHash(Input_OldPwd.Value.Trim());
            string newPwd = ShopNum1.Common.Encryption.GetMd5SecondHash(Input_NewPwd.Value.Trim());
            string str3 = ShopNum1.Common.Encryption.GetMd5SecondHash(Input_NewSecondPwd.Value.Trim());
            //if (action.CheckPayPassword(base.MemLoginID, str) > 0)
            //{
            if (newPwd == str3)
            {
                if (action.UpdatePayPwd(base.MemLoginID, newPwd) > 0)
                {
                    MessageBox.Show("设置成功");
                    var action2 =
                        (ShopNum1_MemberActivate_Action)LogicFactory.CreateShopNum1_MemberActivate_Action();
                    if (action2.DeleteKey(base.MemLoginID, newPwd) > 0)
                    {
                        Page.Response.Redirect("A_UpPayPwdSucceed.aspx");
                    }
                }
                else
                {
                    MessageBox.Show("设置失败");
                }
            }
            //}
            //else
            //{
            //    MessageBox.Show("旧支付密码错误");
            //}
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("A_PwdSer.aspx");
        }
    }
}