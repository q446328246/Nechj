using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_MessageBoardReply : BaseShopWebControl
    {
        private Localize LocalizeContent;
        private Localize LocalizeIsReply;
        private Localize LocalizeIsShow;
        private Localize LocalizeMemLoginID;
        private Localize LocalizeReplyTime;
        private Localize LocalizeSendTime;
        private Localize LocalizeTitle;
        private Localize LocalizeType;
        private TextBox TextBoxReplyContent;
        private Button btn_Back;
        private Button btn_OK;
        private string skinFilename = "S_MessageBoardReply.ascx";
        private string string_1 = string.Empty;

        public S_MessageBoardReply()
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
            Page.Response.Redirect("S_MessageBoardList.aspx");
        }

        public void Edit()
        {
            var messageBoard = new ShopNum1_Shop_MessageBoard
            {
                Guid = new Guid(string_1),
                ReplyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                ReplyContent = TextBoxReplyContent.Text
            };
            var action = (Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action();
            if (action.MessageBoardReply(messageBoard) > 0)
            {
                Page.Response.Redirect("S_MessageBoardList.aspx");
            }
        }

        public void GetEditInfo()
        {
            DataTable table =
                ((Shop_MessageBoard_Action) LogicFactory.CreateShop_MessageBoard_Action()).SearchMessageBoard(string_1);
            LocalizeType.Text = IsType(table.Rows[0]["MessageType"].ToString());
            LocalizeMemLoginID.Text = table.Rows[0]["MemLoginID"].ToString();
            LocalizeTitle.Text = table.Rows[0]["Title"].ToString();
            LocalizeSendTime.Text = table.Rows[0]["SendTime"].ToString();
            LocalizeReplyTime.Text = table.Rows[0]["ReplyTime"].ToString();
            LocalizeContent.Text = table.Rows[0]["Content"].ToString();
            TextBoxReplyContent.Text = table.Rows[0]["ReplyContent"].ToString();
            if (table.Rows[0]["IsReply"].ToString() == "0")
            {
                LocalizeIsReply.Text = "未回复";
            }
            else
            {
                LocalizeIsReply.Text = "已回复";
            }
            if (table.Rows[0]["IsShow"].ToString() == "0")
            {
                LocalizeIsShow.Text = "不显示";
            }
            else
            {
                LocalizeIsShow.Text = "显示";
            }
            if (table.Rows[0]["IsReply"].ToString() == "1")
            {
                TextBoxReplyContent.ReadOnly = true;
                btn_OK.Visible = false;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LocalizeType = (Localize) skin.FindControl("LocalizeType");
            LocalizeMemLoginID = (Localize) skin.FindControl("LocalizeMemLoginID");
            LocalizeTitle = (Localize) skin.FindControl("LocalizeTitle");
            LocalizeSendTime = (Localize) skin.FindControl("LocalizeSendTime");
            LocalizeReplyTime = (Localize) skin.FindControl("LocalizeReplyTime");
            LocalizeIsReply = (Localize) skin.FindControl("LocalizeIsReply");
            LocalizeIsShow = (Localize) skin.FindControl("LocalizeIsShow");
            LocalizeContent = (Localize) skin.FindControl("LocalizeContent");
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

        public string IsType(object object_0)
        {
            string str2 = object_0.ToString();
            switch (str2)
            {
                case null:
                    break;

                case "0":
                    return "询问";

                case "1":
                    return "求购";

                default:
                    if (!(str2 == "2"))
                    {
                        if (str2 == "3")
                        {
                            return "其它";
                        }
                    }
                    else
                    {
                        return "售后";
                    }
                    break;
            }
            return "其它";
        }
    }
}