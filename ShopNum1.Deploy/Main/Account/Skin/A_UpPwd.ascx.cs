using System;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_UpPwd : BaseMemberControl
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
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string str = ShopNum1.Common.Encryption.GetMd5Hash(Input_OldPwd.Value.Trim());
            string newPwd = ShopNum1.Common.Encryption.GetMd5Hash(Input_NewPwd.Value.Trim());
            string str3 = ShopNum1.Common.Encryption.GetMd5Hash(Input_NewSecondPwd.Value.Trim());
            if (action.CheckPassword(base.MemLoginID, str) > 0)
            {
                if (newPwd == str3)
                {
                    if (action.UpdatePwd(base.MemLoginID, newPwd) > 0)
                    {
                        MessageBox.Show("ÐÞ¸Ä³É¹¦");
                    }
                    else
                    {
                        MessageBox.Show("ÐÞ¸ÄÊ§°Ü");
                    }
                }
            }
            else
            {
                MessageBox.Show("¾ÉÃÜÂë´íÎó");
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("A_PwdSer.aspx");
        }
    }
}
                                            
