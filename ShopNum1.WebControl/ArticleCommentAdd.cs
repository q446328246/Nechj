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
    public class ArticleCommentAdd : BaseWebControl
    {
        private Button ButtonConfirm;
        private HtmlGenericControl CommentsAddShow;
        private HtmlAnchor LoginHref;
        private RadioButton RadioButton1;
        private RadioButton RadioButton2;
        private RadioButton RadioButton3;
        private RadioButton RadioButton4;
        private RadioButton RadioButton5;
        private TextBox TextBoxContent;
        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxTitle;
        private string skinFilename = "AriticleCommentAdd.ascx";
        private TextBox textBox_3;
        private HtmlTableRow trCode;

        public ArticleCommentAdd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public string strAriticleCommentVerifyCode { get; set; }

        public string strArticleCommentCondition { get; set; }

        public string strArticleCommentISAudit { get; set; }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if ((strArticleCommentCondition == "1") && (Page.Request.Cookies["MemberLoginCookie"] == null))
            {
                GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
            }
            else
            {
                if (strAriticleCommentVerifyCode == "1")
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
                var articleComment = new ShopNum1_ArticleComment
                {
                    Guid = Guid.NewGuid(),
                    ArticleGuid = new Guid(Page.Request.QueryString["guid"]),
                    Title = "",
                    Content = TextBoxContent.Text.Trim(),
                    MemLoginID = TextBoxMemLoginID.Text.Trim()
                };
                if (strArticleCommentISAudit == "0")
                {
                    articleComment.IsAudit = 1;
                }
                else
                {
                    articleComment.IsAudit = 0;
                }
                articleComment.IsReply = 0;
                articleComment.SendTime = DateTime.Now;
                articleComment.IsDeleted = 0;
                articleComment.IPAddress = Globals.IPAddress;
                articleComment.Rank = 1;
                var action4 = (ShopNum1_ArticleComment_Action) LogicFactory.CreateShopNum1_ArticleComment_Action();
                if (action4.Add(articleComment) > 0)
                {
                    //Page.Request.QueryString["guid"];
                    MessageBox.Show("评论成功！");
                    if ((strArticleCommentISAudit == "0") && (Page.Request.Cookies["MemberLoginCookie"] != null))
                    {
                        string text = TextBoxMemLoginID.Text;
                        string s = ShopSettings.GetValue("ArticleCommentRankSorce");
                        string str = ShopSettings.GetValue("ArticleCommentSorce");
                        if ((int.Parse(s) > 0) || (int.Parse(str) > 0))
                        {
                            var action3 = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                            DataTable memInfoByMemberloginId = action3.GetMemInfoByMemberloginId(text);
                            int num2 = 0;
                            int num = 0;
                            if ((memInfoByMemberloginId != null) && (memInfoByMemberloginId.Rows.Count > 0))
                            {
                                num2 = int.Parse(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString());
                                num = int.Parse(memInfoByMemberloginId.Rows[0]["Score"].ToString());
                                var member = new ShopNum1_Member
                                {
                                    MemberRank = num2 + int.Parse(s),
                                    Score = num + int.Parse(str),
                                    MemLoginID = text
                                };
                                if (action3.UpdateScore(member) >= 0)
                                {
                                    if (int.Parse(str) > 0)
                                    {
                                        var scoreModeLog = new ShopNum1_ScoreModifyLog
                                        {
                                            Guid = Guid.NewGuid(),
                                            OperateType = 1,
                                            CurrentScore = num,
                                            OperateScore = int.Parse(str),
                                            LastOperateScore = num + int.Parse(str),
                                            Date = DateTime.Now,
                                            Memo = "商品评论赠送消费红包",
                                            MemLoginID = text,
                                            CreateUser = text,
                                            CreateTime = DateTime.Now,
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
                                            CurrentScore = num2,
                                            OperateScore = int.Parse(s),
                                            LastOperateScore = num2 + int.Parse(s),
                                            Date = DateTime.Now,
                                            Memo = "商品评论赠送等级红包",
                                            MemLoginID = text,
                                            CreateUser = text,
                                            CreateTime = DateTime.Now,
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
        }

        protected override void InitializeSkin(Control skin)
        {
            CommentsAddShow = (HtmlGenericControl) skin.FindControl("CommentsAddShow");
            LoginHref = (HtmlAnchor) skin.FindControl("LoginHref");
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            trCode = (HtmlTableRow) skin.FindControl("trCode");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            RadioButton1 = (RadioButton) skin.FindControl("RadioButton1");
            RadioButton2 = (RadioButton) skin.FindControl("RadioButton2");
            RadioButton3 = (RadioButton) skin.FindControl("RadioButton3");
            RadioButton4 = (RadioButton) skin.FindControl("RadioButton4");
            RadioButton5 = (RadioButton) skin.FindControl("RadioButton5");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            ButtonConfirm.Click += ButtonConfirm_Click;
            string text1 = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            strArticleCommentCondition = ShopSettings.GetValue("ArticleCommentCondition");
            strAriticleCommentVerifyCode = ShopSettings.GetValue("AriticleCommentVerifyCode");
            strArticleCommentISAudit = ShopSettings.GetValue("ArticleCommentISAudit");
            if (strAriticleCommentVerifyCode == "0")
            {
                trCode.Visible = false;
            }
            else
            {
                textBox_3 = (TextBox) skin.FindControl("TextBoxCode");
            }
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                TextBoxMemLoginID.Text = cookie2.Values["MemLoginID"];
                LoginHref.Visible = false;
            }
            else
            {
                new Order();
                TextBoxMemLoginID.Text = "游客";
                LoginHref.Visible = true;
                LoginHref.HRef = "http://" + ShopSettings.siteDomain + "/Login" +
                                 (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
            }
            if (strArticleCommentCondition == "1")
            {
                TextBoxMemLoginID.ReadOnly = true;
                LoginHref.Visible = true;
            }
            else
            {
                LoginHref.Visible = false;
            }
            try
            {
                if (
                    Common.Common.GetNameById("isallowcomment", "ShopNum1_Article",
                        " and guid='" + Page.Request.QueryString["guid"] + "'") == "0")
                {
                    CommentsAddShow.Visible = false;
                }
            }
            catch
            {
            }
        }
    }
}