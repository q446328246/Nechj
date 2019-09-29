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

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopArticleCommentAdd : BaseWebControl
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
        private string skinFilename = "ShopArticleCommentAdd.ascx";

        public ShopArticleCommentAdd()
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
            if (ShopSettings.GetValue("ShopAriticleCommentVerifyCode") == "1")
            {
                if (Page.Session["code"] == null)
                {
                    MessageBox.Show("验证码不正确！");
                    return;
                }
                if (TextBoxCode.Text.ToUpper() != Page.Session["code"].ToString())
                {
                    MessageBox.Show("验证码不正确！");
                    return;
                }
            }
            if (ShopSettings.GetValue("ShopArticleCommentCondition") == "1")
            {
                if (Page.Request.Cookies["MemberLoginCookie"] == null)
                {
                    GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再评论！");
                    return;
                }
                TextBoxMemLoginID.ReadOnly = true;
            }
            var comment = new ShopNum1_Shop_NewsComment
            {
                Guid = Guid.NewGuid(),
                Title = TextBoxTitle.Text.Trim()
            };
            int num2 = 0;
            if (RadioButton1.Checked)
            {
                num2 = 1;
            }
            else if (RadioButton2.Checked)
            {
                num2 = 2;
            }
            else if (RadioButton3.Checked)
            {
                num2 = 3;
            }
            else if (RadioButton4.Checked)
            {
                num2 = 4;
            }
            else if (RadioButton5.Checked)
            {
                num2 = 5;
            }
            comment.Rank = num2;
            comment.ArticleGuid = new Guid(Guids);
            comment.CommentTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            comment.IPAddress = Page.Request.UserHostAddress;
            comment.Content = TextBoxContent.Text.Trim();
            comment.MemLoginID = MemLoginID;
            string str5 = ShopSettings.GetValue("ShopArticleCommentISAudit");
            if (str5 == "0")
            {
                comment.IsAudit = 1;
            }
            else
            {
                comment.IsAudit = 0;
            }
            comment.MemLoginID = TextBoxMemLoginID.Text.Trim();
            comment.IsReply = 0;
            comment.ShopID = ShopID;
            comment.IsDeleted = 0;
            var action3 = (ShopNum1_ShopArticleComment_Action) LogicFactory.CreateShopNum1_ShopArticleComment_Action();
            if (action3.Shop_NewsCommentAdd(comment) > 0)
            {
                MessageBox.Show("评论成功！");
                TextBoxContent.Text = "";
                TextBoxCode.Text = "";
                if ((str5 == "0") && (Page.Request.Cookies["MemberLoginCookie"] != null))
                {
                    string text = TextBoxMemLoginID.Text;
                    string s = ShopSettings.GetValue("ShopArticleCommentRankSorce");
                    string str4 = ShopSettings.GetValue("ShopArticleCommentSorce");
                    if ((int.Parse(s) > 0) || (int.Parse(str4) > 0))
                    {
                        var action2 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                        DataTable memInfoByMemberloginId = action2.GetMemInfoByMemberloginId(text);
                        int num = 0;
                        int num3 = 0;
                        if ((memInfoByMemberloginId != null) && (memInfoByMemberloginId.Rows.Count > 0))
                        {
                            num = int.Parse(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString());
                            num3 = int.Parse(memInfoByMemberloginId.Rows[0]["Score"].ToString());
                            var member = new ShopNum1_Member
                            {
                                MemberRank = num + int.Parse(s),
                                Score = num3 + int.Parse(str4),
                                MemLoginID = text
                            };
                            if (action2.UpdateScore(member) >= 0)
                            {
                                if (int.Parse(str4) > 0)
                                {
                                    var scoreModeLog = new ShopNum1_ScoreModifyLog
                                    {
                                        Guid = Guid.NewGuid(),
                                        OperateType = 1,
                                        CurrentScore = num3,
                                        OperateScore = int.Parse(str4),
                                        LastOperateScore = num3 + int.Parse(str4),
                                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                        Memo = "商品评论赠送消费红包",
                                        MemLoginID = text,
                                        CreateUser = text,
                                        CreateTime =
                                            Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                        IsDeleted = 0
                                    };
                                    ((ShopNum1_ScoreModifyLog_Action)
                                        LogicFactory.CreateShopNum1_ScoreModifyLog_Action()).OperateScore(scoreModeLog);
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
                                        Memo = "商品评论赠送等级红包",
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
                MessageBox.Show("评论失败！");
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
            if (ShopSettings.GetValue("ShopAriticleCommentVerifyCode") == "1")
            {
                VerifyCode.Visible = true;
            }
            else
            {
                VerifyCode.Visible = false;
            }
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemLoginID = cookie2.Values["MemLoginID"];
                TextBoxMemLoginID.Text = MemLoginID;
            }
            else
            {
                TextBoxMemLoginID.Text = "游客";
            }
        }
    }
}