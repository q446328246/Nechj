using System;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_SendMsg : BaseMemberControl
    {
        protected void butSure_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_MemberMessage_Action) LogicFactory.CreateShopNum1_MemberMessage_Action();
            var message = new ShopNum1_MemberMessage
            {
                SendLoginID = base.MemLoginID
            };
            if (txtUser.Value.IndexOf(',') != -1)
            {
                string[] strArray = txtUser.Value.Split(new[] {','});
                for (int i = 0; i < strArray.Length; i++)
                {
                    message.ReLoginID = strArray[i];
                    message.Content = txtMsg.Value;
                    message.Title = txtTitle.Value;
                    action.Add_MemberMsg(message);
                }
            }
            else
            {
                message.ReLoginID = txtUser.Value;
                message.Content = txtMsg.Value;
                message.Title = txtTitle.Value;
                action.Add_MemberMsg(message);
            }
            MessageBox.Show("发送成功！");
            txtMsg.Value = "";
            txtTitle.Value = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (Common.Common.ReqStr("ordernumber").IndexOf("|") == -1)
                {
                    txtUser.Value = Common.Common.GetNameById("shopid", "shopnum1_orderinfo",
                        " and ordernumber='" +
                        Common.Common.ReqStr("ordernumber") + "'");
                }
                else
                {
                    txtUser.Value = Common.Common.GetNameById("memloginid", "shopnum1_orderinfo",
                        " and ordernumber='" +
                        Common.Common.ReqStr("ordernumber")
                            .Split(new[] {'|'})[0] + "'");
                }
            }
            HiddenFieldUser.Value = base.MemLoginID;
        }
    }
}