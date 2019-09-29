using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ProductMessageBoardReply : BaseShopWebControl
    {
        private Label LabelIPAddress;
        private Label LabelIsReply;
        private Label LabelMemLoginID;
        private Label LabelProductGuid;
        private Label LabelReplyTime;
        private Label LabelSendTime;
        private TextBox TextBoxReplyContent;
        private Button btn_Back;
        private Button btn_OK;
        private HtmlTextArea htmlTextArea_0;
        private string skinFilename = "S_ProductMessageBoardReply.ascx";
        private string string_1 = string.Empty;

        public S_ProductMessageBoardReply()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btn_OK_Click(object sender, EventArgs e)
        {
            Edit();
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ProductMessageBoardList.aspx");
        }

        public void Edit()
        {
            var action = (Shop_ProductConsult_Action) LogicFactory.CreateShop_ProductConsult_Action();
            var shopProductConsult = new ShopNum1_ShopProductConsult
            {
                Guid = new Guid(string_1),
                ReplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                ReplyContent = TextBoxReplyContent.Text.Trim()
            };
            if (action.MessageBoardReply(shopProductConsult) > 0)
            {
                Page.Response.Redirect("S_ProductMessageBoardList.aspx");
            }
        }

        public void GetEditInfo()
        {
            DataTable table =
                ((Shop_ProductConsult_Action) LogicFactory.CreateShop_ProductConsult_Action()).SearchByGuid("'" +
                                                                                                            string_1 +
                                                                                                            "'");
            LabelProductGuid.Text = table.Rows[0]["Name"].ToString();
            LabelMemLoginID.Text = table.Rows[0]["MemLoginID"].ToString();
            LabelIPAddress.Text = table.Rows[0]["IPAddress"].ToString();
            LabelSendTime.Text = table.Rows[0]["SendTime"].ToString();
            htmlTextArea_0.Value = table.Rows[0]["Content"].ToString();
            LabelReplyTime.Text = table.Rows[0]["ReplyTime"].ToString();
            if (table.Rows[0]["IsReply"].ToString() == "0")
            {
                LabelIsReply.Text = "未回复";
            }
            else
            {
                LabelIsReply.Text = "已回复";
                btn_OK.Visible = false;
                TextBoxReplyContent.ReadOnly = true;
            }
            TextBoxReplyContent.Text = table.Rows[0]["ReplyContent"].ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelProductGuid = (Label) skin.FindControl("LabelProductGuid");
            LabelMemLoginID = (Label) skin.FindControl("LabelMemLoginID");
            LabelIPAddress = (Label) skin.FindControl("LabelIPAddress");
            LabelSendTime = (Label) skin.FindControl("LabelSendTime");
            LabelIsReply = (Label) skin.FindControl("LabelIsReply");
            htmlTextArea_0 = (HtmlTextArea) skin.FindControl("txtContent");
            LabelReplyTime = (Label) skin.FindControl("LabelReplyTime");
            TextBoxReplyContent = (TextBox) skin.FindControl("TextBoxReplyContent");
            btn_OK = (Button) skin.FindControl("btn_OK");
            btn_OK.Click += btn_OK_Click;
            btn_Back = (Button) skin.FindControl("btn_Back");
            btn_Back.Click += btn_Back_Click;
            string_1 = (Common.Common.ReqStr("guid") == "") ? "0" : Common.Common.ReqStr("Guid");
            if (string_1 != "0")
            {
                GetEditInfo();
            }
        }
    }
}