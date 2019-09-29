using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class MessageBoardList : BaseWebControl
    {
        private Button btnSubmit;
        private string skinFilename = "MessageBoardList.ascx";
        private TextBox txtMobile;
        private TextBox txtRemark;

        public MessageBoardList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                str = HttpSecureCookie.Decode(cookie).Values["MemLoginID"];
            }
            var board = new ShopNum1_MessageBoard
            {
                Guid = Guid.NewGuid(),
                MessageType = "",
                MemLoginID = str,
                ReplyUser = txtMobile.Text.Trim(),
                Title = "建议反馈",
                Content = Operator.FilterString(txtRemark.Text.Trim()),
                ModifyUser = str,
                ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            ((ShopNum1_MessageBoard_Action) LogicFactory.CreateShopNum1_MessageBoard_Action()).AddMemberMessageBoard(
                board);
        }

        protected override void InitializeSkin(Control skin)
        {
            txtMobile = skin.FindControl("txtMobile") as TextBox;
            txtRemark = skin.FindControl("txtRemark") as TextBox;
            btnSubmit = skin.FindControl("btnSubmit") as Button;
            btnSubmit.Click += btnSubmit_Click;
        }
    }
}