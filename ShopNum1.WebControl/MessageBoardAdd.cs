using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class MessageBoardAdd : BaseWebControl
    {
        private Button ButtonConfirm;
        private HtmlAnchor LoginHref;
        private RadioButtonList RadioButtonListmessageType;
        private TextBox TextBoxContent;

        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxTitle;
        private string skinFilename = "MessageBoardAdd.ascx";
        private TextBox textBox_3;
        private HtmlTableRow trCode;

        public MessageBoardAdd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MessageCondition { get; set; }

        public string MessageConditionVerifyCode { get; set; }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if ((MessageCondition == "1") && (Page.Request.Cookies["MemberLoginCookie"] == null))
            {
                GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
            }
            else
            {
                if (MessageConditionVerifyCode == "1")
                {
                    if (textBox_3.Text == null)
                    {
                        MessageBox.Show("验证码不能为空值！");
                        return;
                    }
                    if (Page.Session["code"] == null)
                    {
                        MessageBox.Show("验证码有误！");
                        return;
                    }
                    if (textBox_3.Text.ToUpper() != Page.Session["code"].ToString().ToUpper())
                    {
                        MessageBox.Show("验证码输入错误！");
                        return;
                    }
                }
                var board = new ShopNum1_MessageBoard
                {
                    Guid = Guid.NewGuid(),
                    MessageType = RadioButtonListmessageType.SelectedValue,
                    MemLoginID = TextBoxMemLoginID.Text.Trim(),
                    ReplyUser = "",
                    Title = TextBoxTitle.Text.Trim(),
                    Content = TextBoxContent.Text.Trim(),
                    ModifyUser = TextBoxMemLoginID.Text.Trim(),
                    ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                if (ShopSettings.GetValue("MessageCommentISAudit") == "1")
                {
                    board.IsAudit = 0;
                }
                else
                {
                    board.IsAudit = 1;
                }
                var action3 = (ShopNum1_MessageBoard_Action) LogicFactory.CreateShopNum1_MessageBoard_Action();
                if (action3.AddMemberMessageBoard(board) > 0)
                {
                    MessageBox.Show("留言成功！");
                    TextBoxContent.Text = TextBoxTitle.Text = "";
                    if ((MessageConditionVerifyCode == "0") && (textBox_3 != null))
                    {
                        textBox_3.Text = "";
                    }
                    if ((ShopSettings.GetValue("MessageCommentISAudit") == "0") &&
                        (Page.Request.Cookies["MemberLoginCookie"] != null))
                    {
                        string text = TextBoxMemLoginID.Text;
                        string s = ShopSettings.GetValue("MyMessageRankSorce");
                        string str3 = ShopSettings.GetValue("MyMessageSorce");
                        if ((int.Parse(s) > 0) || (int.Parse(str3) > 0))
                        {
                            var action4 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                            DataTable memInfoByMemberloginId = action4.GetMemInfoByMemberloginId(text);
                            int num = 0;
                            int num2 = 0;
                            if ((memInfoByMemberloginId != null) && (memInfoByMemberloginId.Rows.Count > 0))
                            {
                                num = int.Parse(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString());
                                num2 = int.Parse(memInfoByMemberloginId.Rows[0]["Score"].ToString());
                                var member = new ShopNum1_Member
                                {
                                    MemberRank = num + int.Parse(s),
                                    Score = num2 + int.Parse(str3),
                                    MemLoginID = text
                                };
                                if (action4.UpdateScore(member) >= 0)
                                {
                                    if (int.Parse(str3) > 0)
                                    {
                                        var scoreModeLog = new ShopNum1_ScoreModifyLog
                                        {
                                            Guid = Guid.NewGuid(),
                                            OperateType = 1,
                                            CurrentScore = num2,
                                            OperateScore = int.Parse(str3),
                                            LastOperateScore = num2 + int.Parse(str3),
                                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                            Memo = "平台留言赠送消费红包",
                                            MemLoginID = text,
                                            CreateUser = text,
                                            CreateTime =
                                                Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                            IsDeleted = 0
                                        };
                                        ((ShopNum1_ScoreModifyLog_Action)
                                            LogicFactory.CreateShopNum1_ScoreModifyLog_Action()).OperateScore(
                                                scoreModeLog);
                                    }
                                    if (int.Parse(s) > 0)
                                    {
                                        var rankScoreModifyLog = new ShopNum1_RankScoreModifyLog
                                        {
                                            Guid = Guid.NewGuid(),
                                            OperateType = 1,
                                            CurrentScore = num,
                                            OperateScore = int.Parse(s),
                                            LastOperateScore = num + int.Parse(s),
                                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                            Memo = "平台留言赠送等级红包",
                                            MemLoginID = text,
                                            CreateUser = text,
                                            CreateTime =
                                                Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                            IsDeleted = 0
                                        };
                                        ((ShopNum1_RankScoreModifyLog_Action)
                                            LogicFactory.CreateShopNum1_RankScoreModifyLog_Action()).OperateScore(
                                                rankScoreModifyLog);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("留言失败！");
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            trCode = (HtmlTableRow) skin.FindControl("trCode");
            LoginHref = (HtmlAnchor) skin.FindControl("LoginHref");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            RadioButtonListmessageType = (RadioButtonList) skin.FindControl("RadioButtonListmessageType");
            BindData();
            MessageConditionVerifyCode = ShopSettings.GetValue("MessageVerifyCode");
            if (MessageConditionVerifyCode == "0")
            {
                trCode.Visible = false;
            }
            else
            {
                textBox_3 = (TextBox) skin.FindControl("TextBoxCode");
            }
            MessageCondition = ShopSettings.GetValue("MessageCondition");
            if (MessageCondition == "1")
            {
                if (Page.Request.Cookies["MemberLoginCookie"] != null)
                {
                    HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    TextBoxMemLoginID.Text = cookie2.Values["MemLoginID"];
                    TextBoxMemLoginID.ReadOnly = true;
                    LoginHref.Visible = false;
                }
                else
                {
                    LoginHref.Visible = true;
                    LoginHref.HRef = "http://" + ShopSettings.siteDomain + "/Login" +
                                     (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
                }
            }
            ButtonConfirm.Click += ButtonConfirm_Click;
            if (!Page.IsPostBack)
            {
            }
        }

        protected void BindData()
        {
            var item = new ListItem
            {
                Text = "售后",
                Value = "0"
            };
            RadioButtonListmessageType.Items.Add(item);
            var item2 = new ListItem
            {
                Text = "询问",
                Value = "1"
            };
            RadioButtonListmessageType.Items.Add(item2);
            var item3 = new ListItem
            {
                Text = "一般信息",
                Value = "2"
            };
            RadioButtonListmessageType.Items.Add(item3);
            var item4 = new ListItem
            {
                Text = "求购",
                Value = "3"
            };
            RadioButtonListmessageType.Items.Add(item4);
            var item5 = new ListItem
            {
                Text = "留言",
                Value = "4"
            };
            RadioButtonListmessageType.Items.Add(item5);
            var item6 = new ListItem
            {
                Text = "重要消息",
                Value = "5"
            };
            RadioButtonListmessageType.Items.Add(item6);
            RadioButtonListmessageType.Items[0].Selected = true;
        }
    }
}