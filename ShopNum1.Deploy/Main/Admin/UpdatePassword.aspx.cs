using System;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class UpdatePassword : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
        }

        protected void ButtonPwd_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_User_Action) LogicFactory.CreateShopNum1_User_Action();
            int num = action.CheckLogin(base.ShopNum1LoginID.Trim(),
                                        Common.Encryption.GetSHA1SecondHash(TextBoxOldPwd.Text.Trim()), 0);
            if (TextBoxNewPwd.Text != TextBoxRePwd.Text)
            {
                MessageBox.Show("两次密码不一致！");
            }
            else if (num > 0)
            {
                if (
                    action.UpdatePwd(base.ShopNum1LoginID.Trim(),
                                     Common.Encryption.GetSHA1SecondHash(TextBoxOldPwd.Text.Trim()),
                                     Common.Encryption.GetSHA1SecondHash(TextBoxNewPwd.Text)) > 0)
                {
                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "修改密码成功",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "UpdatePassword.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
                    MessageBox.Show("修改成功！");
                }
            }
            else
            {
                MessageBox.Show("原密码不正确！");
            }
        }
    }
}