using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_SendMsg : BaseMemberWebControl
    {
        private HiddenField HiddenFieldUser;
        private Button butSure;
        private string skinFilename = "M_SendMsg.ascx";
        private HtmlTextArea txtMsg;
        private HtmlInputText txtTitle;
        private HtmlInputText txtUser;

        public M_SendMsg()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private void butSure_Click(object sender, EventArgs e)
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

        protected override void InitializeSkin(Control skin)
        {
            HiddenFieldUser = (HiddenField) skin.FindControl("HiddenFieldUser");
            txtTitle = (HtmlInputText) skin.FindControl("txtTitle");
            txtUser = (HtmlInputText) skin.FindControl("txtUser");
            txtMsg = (HtmlTextArea) skin.FindControl("txtMsg");
            butSure = (Button) skin.FindControl("butSure");
            butSure.Click += butSure_Click;
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