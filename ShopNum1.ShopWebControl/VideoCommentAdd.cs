using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class VideoCommentAdd : BaseWebControl
    {
        private Button ButtonConfirm;
        private RadioButton RadioButton1;
        private RadioButton RadioButton2;
        private RadioButton RadioButton3;
        private RadioButton RadioButton4;
        private RadioButton RadioButton5;
        private TextBox TextBoxCode;
        private TextBox TextBoxContent;
        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxTitle;
        private HtmlTableRow VerifyCode;
        private string skinFilename = "VideoCommentAdd.ascx";

        public VideoCommentAdd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guids { get; set; }

        public string MemLoginID { get; set; }

        protected string ShopID { get; set; }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (ShopSettings.GetValue("VideoCommentVerifyCode") == "1")
            {
                if (Page.Session["code"] == null)
                {
                    MessageBox.Show("验证码有误！");
                    return;
                }
                if (TextBoxCode.Text.ToUpper().Trim() != Page.Session["code"].ToString())
                {
                    MessageBox.Show("验证码不正确！");
                    return;
                }
            }
            if ((ShopSettings.GetValue("VideoCommentCondition") == "1") &&
                (Page.Request.Cookies["MemberLoginCookie"] == null))
            {
                GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再评论！");
            }
            else
            {
                var comment = new ShopNum1_Shop_VideoComment
                {
                    Guid = Guid.NewGuid(),
                    Title = TextBoxTitle.Text.Trim()
                };
                int num3 = 0;
                if (RadioButton1.Checked)
                {
                    num3 = 1;
                }
                else if (RadioButton2.Checked)
                {
                    num3 = 2;
                }
                else if (RadioButton3.Checked)
                {
                    num3 = 3;
                }
                else if (RadioButton4.Checked)
                {
                    num3 = 4;
                }
                else if (RadioButton5.Checked)
                {
                    num3 = 5;
                }
                comment.CommentType = num3;
                comment.VideoGuid = Guids;
                comment.CommentTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                comment.Comment = TextBoxContent.Text.Trim();
                comment.ShopID = ShopID;
                if (ShopSettings.GetValue("VideoCommentISAudit") == "0")
                {
                    comment.IsAudit = 1;
                }
                else
                {
                    comment.IsAudit = 0;
                }
                comment.MemLoginID = TextBoxMemLoginID.Text.Trim();
                comment.IsReply = 0;
                comment.IPAddress = Page.Request.UserHostAddress;
                var action3 = (Shop_VideoComment_Action) LogicFactory.CreateShop_VideoComment_Action();
                if (action3.Add(comment) > 0)
                {
                    if (Page.Request.Cookies["MemberLoginCookie"] != null)
                    {
                        string text = TextBoxMemLoginID.Text;
                        string s = ShopSettings.GetValue("MyShopMessageRankSorce");
                        string str2 = ShopSettings.GetValue("MyShopMessageSorce");
                        if ((int.Parse(s) > 0) || (int.Parse(str2) > 0))
                        {
                            var action4 = (ShopNum1_Member_Action) Factory.LogicFactory.CreateShopNum1_Member_Action();
                            DataTable memInfoByMemberloginId = action4.GetMemInfoByMemberloginId(text);
                            int num2 = 0;
                            int num = 0;
                            if ((memInfoByMemberloginId != null) && (memInfoByMemberloginId.Rows.Count > 0))
                            {
                                num2 = int.Parse(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString());
                                num = int.Parse(memInfoByMemberloginId.Rows[0]["Score"].ToString());
                            }
                            var member = new ShopNum1_Member
                            {
                                MemberRank = num2 + int.Parse(s),
                                Score = num + int.Parse(str2),
                                MemLoginID = text
                            };
                            if (action4.UpdateScore(member) < 0)
                            {
                                return;
                            }
                            if (int.Parse(str2) > 0)
                            {
                                var scoreModeLog = new ShopNum1_ScoreModifyLog
                                {
                                    Guid = Guid.NewGuid(),
                                    OperateType = 1,
                                    CurrentScore = num,
                                    OperateScore = int.Parse(str2),
                                    LastOperateScore = num + int.Parse(str2),
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    Memo = "店铺留言赠送消费红包",
                                    MemLoginID = text,
                                    CreateUser = text,
                                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    IsDeleted = 0
                                };
                                ((ShopNum1_ScoreModifyLog_Action)
                                    Factory.LogicFactory.CreateShopNum1_ScoreModifyLog_Action()).OperateScore(
                                        scoreModeLog);
                            }
                            if (int.Parse(s) > 0)
                            {
                                var rankScoreModifyLog = new ShopNum1_RankScoreModifyLog
                                {
                                    Guid = Guid.NewGuid(),
                                    OperateType = 1,
                                    CurrentScore = num2,
                                    OperateScore = int.Parse(s),
                                    LastOperateScore = num2 + int.Parse(s),
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    Memo = "店铺留言赠送等级红包",
                                    MemLoginID = text,
                                    CreateUser = text,
                                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    IsDeleted = 0
                                };
                                ((ShopNum1_RankScoreModifyLog_Action)
                                    Factory.LogicFactory.CreateShopNum1_RankScoreModifyLog_Action()).OperateScore(
                                        rankScoreModifyLog);
                            }
                        }
                        Page.ClientScript.RegisterStartupScript(base.GetType(), "msg",
                            "<script>alert('恭喜您，评论成功！');window.location.href=window.location.href;</script>",
                            false);
                    }
                }
                else
                {
                    MessageBox.Show("评论失败！");
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxCode = (TextBox) skin.FindControl("TextBoxCode");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            RadioButton1 = (RadioButton) skin.FindControl("RadioButton1");
            RadioButton2 = (RadioButton) skin.FindControl("RadioButton2");
            RadioButton3 = (RadioButton) skin.FindControl("RadioButton3");
            RadioButton4 = (RadioButton) skin.FindControl("RadioButton4");
            RadioButton5 = (RadioButton) skin.FindControl("RadioButton5");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            ButtonConfirm.Click += ButtonConfirm_Click;
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            Guids = (Page.Request.QueryString["Guid"] == null) ? "" : Page.Request.QueryString["Guid"];
            if (!Page.IsPostBack)
            {
            }
            VerifyCode = (HtmlTableRow) skin.FindControl("VerifyCode");
            if (ShopSettings.GetValue("VideoCommentVerifyCode") == "1")
            {
                VerifyCode.Visible = true;
            }
            else
            {
                VerifyCode.Visible = false;
            }
            TextBoxMemLoginID.Enabled = false;
            TextBoxMemLoginID.Text = "仅限登录用户";
            if (ShopSettings.GetValue("VideoCommentCondition") == "0")
            {
                TextBoxMemLoginID.Enabled = true;
                TextBoxMemLoginID.Text = "游客";
                ButtonConfirm.Enabled = true;
            }
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemLoginID = cookie2.Values["MemLoginID"];
                TextBoxMemLoginID.Text = MemLoginID;
                TextBoxMemLoginID.ReadOnly = true;
                ButtonConfirm.Enabled = true;
            }
        }
    }
}