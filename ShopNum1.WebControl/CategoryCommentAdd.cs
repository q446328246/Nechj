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
    public class CategoryCommentAdd : BaseWebControl
    {
        private Button ButtonAdd;
        private HtmlAnchor LoginHref;
        private TextBox TextBoxCodex;
        private TextBox TextBoxContent;

        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxTitle;
        private string skinFilename = "CategoryCommentAdd.ascx";
        private HtmlTableRow trCode;

        public CategoryCommentAdd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CategoryGuid { get; set; }

        public string strCategoryInfoCommentCondition { get; set; }

        public string strCategoryInfoCommentVerifyCode { get; set; }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if ((strCategoryInfoCommentCondition == "1") && (Page.Request.Cookies["MemberLoginCookie"] == null))
            {
                GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
            }
            else
            {
                if (strCategoryInfoCommentVerifyCode == "1")
                {
                    if (TextBoxCodex.Text == null)
                    {
                        MessageBox.Show("验证码不能为空值！");
                        return;
                    }
                    if (TextBoxCodex.Text.ToUpper() != Page.Session["code"].ToString().ToUpper())
                    {
                        MessageBox.Show("验证码输入错误！");
                        return;
                    }
                }
                var categoryComment = new ShopNum1_CategoryComment
                {
                    Guid = Guid.NewGuid(),
                    CreateIP = Page.Request.UserHostAddress,
                    Title = TextBoxTitle.Text,
                    Content = TextBoxContent.Text
                };
                if (ShopSettings.GetValue("CategoryInfoCommentISAudit") == "1")
                {
                    categoryComment.IsAudit = 0;
                }
                else
                {
                    categoryComment.IsAudit = 1;
                }
                categoryComment.CategoryInfoGuid = new Guid(CategoryGuid);
                categoryComment.CreateMember = TextBoxMemLoginID.Text;
                categoryComment.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                var action4 = (ShopNum1_CategoryComment_Action) LogicFactory.CreateShopNum1_CategoryComment_Action();
                DataTable cateGoryAssociatedMemberID = action4.GetCateGoryAssociatedMemberID(CategoryGuid);
                if (cateGoryAssociatedMemberID.Rows.Count > 0)
                {
                    categoryComment.AssociatedMemberID =
                        cateGoryAssociatedMemberID.Rows[0]["AssociatedMemberID"].ToString();
                }
                if (action4.Add(categoryComment) > 0)
                {
                    MessageBox.Show("评论成功！");
                    TextBoxTitle.Text = "";
                    TextBoxContent.Text = "";
                    if ((ShopSettings.GetValue("CategoryInfoCommentISAudit") == "0") &&
                        (Page.Request.Cookies["MemberLoginCookie"] != null))
                    {
                        string text = TextBoxMemLoginID.Text;
                        string s = ShopSettings.GetValue("MyCategoryInfoCommentRankSorce");
                        string str = ShopSettings.GetValue("MyCategoryInfoCommentSorce");
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
                                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                            Memo = "分类信息评论赠送消费红包",
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
                                            CurrentScore = num2,
                                            OperateScore = int.Parse(s),
                                            LastOperateScore = num2 + int.Parse(s),
                                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                            Memo = "分类信息评论赠送等级红包",
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
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LoginHref = (HtmlAnchor) skin.FindControl("LoginHref");
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            trCode = (HtmlTableRow) skin.FindControl("trCode");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            TextBoxCodex = (TextBox) skin.FindControl("TextBoxCodex");
            ButtonAdd = (Button) skin.FindControl("ButtonAdd");
            ButtonAdd.Click += ButtonAdd_Click;
            CategoryGuid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            strCategoryInfoCommentCondition = ShopSettings.GetValue("CategoryInfoCommentCondition");
            strCategoryInfoCommentVerifyCode = ShopSettings.GetValue("CategoryInfoCommentVerifyCode");
            if (strCategoryInfoCommentVerifyCode == "0")
            {
                trCode.Visible = false;
            }
            else
            {
                TextBoxCodex = (TextBox) skin.FindControl("TextBoxCodex");
            }
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                TextBoxMemLoginID.Text = cookie2.Values["MemLoginID"];
                if (!(strCategoryInfoCommentCondition == "1"))
                {
                }
                TextBoxMemLoginID.ReadOnly = true;
                LoginHref.Visible = false;
            }
            else if (strCategoryInfoCommentCondition == "1")
            {
                LoginHref.Visible = true;
                LoginHref.HRef = "http://" + ShopSettings.siteDomain + "/Login" +
                                 (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx");
            }
            else
            {
                LoginHref.Visible = false;
            }
        }
    }
}