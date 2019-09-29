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
    public class SupplyDemandCommentAdd : BaseWebControl
    {
        private Button ButtonAdd;
        private HtmlAnchor LoginHref;
        private TextBox TextBoxCode;
        private TextBox TextBoxContent;

        private TextBox TextBoxMemLoginID;
        private TextBox TextBoxTitle;
        private string skinFilename = "SupplyDemandCommentAdd.ascx";
        private HtmlTableRow trCode;

        public SupplyDemandCommentAdd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string strSupplyDemandCommentCondition { get; set; }

        public string strSupplyDemandCommentVerifyCode { get; set; }

        public string SupplyDemandGuid { get; set; }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if ((strSupplyDemandCommentCondition == "1") && (Page.Request.Cookies["MemberLoginCookie"] == null))
            {
                GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
            }
            else
            {
                if (strSupplyDemandCommentVerifyCode == "1")
                {
                    if (TextBoxCode.Text == null)
                    {
                        MessageBox.Show("验证码不能为空值！");
                        return;
                    }
                    if (Page.Session["code"] == null)
                    {
                        MessageBox.Show("验证码有误！");
                        return;
                    }
                    if (TextBoxCode.Text.ToUpper() != Page.Session["code"].ToString().ToUpper())
                    {
                        MessageBox.Show("验证码输入错误！");
                        return;
                    }
                }
                var comment = new ShopNum1_SupplyDemandComment
                {
                    Guid = Guid.NewGuid(),
                    CreateIP = Page.Request.UserHostAddress,
                    Title = TextBoxTitle.Text,
                    Content = TextBoxContent.Text,
                    SupplyDemandGuid = SupplyDemandGuid,
                    CreateMerber = TextBoxMemLoginID.Text,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                if (ShopSettings.GetValue("SupplyDemandCommentISAudit") == "1")
                {
                    comment.IsAudit = 0;
                }
                else
                {
                    comment.IsAudit = 1;
                }
                var action2 =
                    (ShopNum1_SupplyDemandComment_Action) LogicFactory.CreateShopNum1_SupplyDemandComment_Action();
                DataTable supplyDemandAssociatedMemberID = action2.GetSupplyDemandAssociatedMemberID(SupplyDemandGuid);
                if (supplyDemandAssociatedMemberID.Rows.Count > 0)
                {
                    comment.AssociateMemberID = supplyDemandAssociatedMemberID.Rows[0][0].ToString();
                }
                if (action2.AddSupplyDemandComment(comment) > 0)
                {
                    if ((ShopSettings.GetValue("SupplyDemandCommentISAudit") == "0") &&
                        (Page.Request.Cookies["MemberLoginCookie"] != null))
                    {
                        string text = TextBoxMemLoginID.Text;
                        string s = ShopSettings.GetValue("MySupplyDemandCommentRankSorce");
                        string str2 = ShopSettings.GetValue("MySupplyDemandCommentSorce");
                        if ((int.Parse(s) > 0) || (int.Parse(str2) > 0))
                        {
                            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
                            DataTable memInfoByMemberloginId = action.GetMemInfoByMemberloginId(text);
                            int num = 0;
                            int num2 = 0;
                            if ((memInfoByMemberloginId == null) || (memInfoByMemberloginId.Rows.Count <= 0))
                            {
                                return;
                            }
                            if (!string.IsNullOrEmpty(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString()))
                            {
                                num = Convert.ToInt32(memInfoByMemberloginId.Rows[0]["MemberRank"].ToString());
                            }
                            if (!string.IsNullOrEmpty(memInfoByMemberloginId.Rows[0]["Score"].ToString()))
                            {
                                num2 = int.Parse(memInfoByMemberloginId.Rows[0]["Score"].ToString());
                            }
                            var member = new ShopNum1_Member
                            {
                                MemberRank = num + int.Parse(s),
                                Score = num2 + int.Parse(str2),
                                MemLoginID = text
                            };
                            if (action.UpdateScore(member) < 0)
                            {
                                return;
                            }
                            if (int.Parse(str2) > 0)
                            {
                                var scoreModeLog = new ShopNum1_ScoreModifyLog
                                {
                                    Guid = Guid.NewGuid(),
                                    OperateType = 1,
                                    CurrentScore = num2,
                                    OperateScore = int.Parse(str2),
                                    LastOperateScore = num2 + int.Parse(str2),
                                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    Memo = "供求评论赠送消费红包",
                                    MemLoginID = text,
                                    CreateUser = text,
                                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    IsDeleted = 0
                                };
                                ((ShopNum1_ScoreModifyLog_Action) LogicFactory.CreateShopNum1_ScoreModifyLog_Action())
                                    .OperateScore(scoreModeLog);
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
                                    Memo = "供求评论赠送等级红包",
                                    MemLoginID = text,
                                    CreateUser = text,
                                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                                    IsDeleted = 0
                                };
                                ((ShopNum1_RankScoreModifyLog_Action)
                                    LogicFactory.CreateShopNum1_RankScoreModifyLog_Action()).OperateScore(
                                        rankScoreModifyLog);
                            }
                        }
                    }
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"showpop",
                        "<script>alert('评论成功！');location.href='" + Page.Request.Url +
                        "';</script>");
                }
                else
                {
                    MessageBox.Show("评论失败！");
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            HttpCookie cookie;
            HttpCookie cookie2;
            trCode = (HtmlTableRow) skin.FindControl("trCode");
            LoginHref = (HtmlAnchor) skin.FindControl("LoginHref");
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            ButtonAdd = (Button) skin.FindControl("ButtonAdd");
            ButtonAdd.Click += ButtonAdd_Click;
            SupplyDemandGuid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            strSupplyDemandCommentCondition = ShopSettings.GetValue("SupplyDemandCommentCondition");
            strSupplyDemandCommentVerifyCode = ShopSettings.GetValue("SupplyDemandCommentVerifyCode");
            if (strSupplyDemandCommentVerifyCode == "0")
            {
                trCode.Visible = false;
            }
            else
            {
                TextBoxCode = (TextBox) skin.FindControl("TextBoxCode");
            }
            if (strSupplyDemandCommentCondition == "1")
            {
                if (Page.Request.Cookies["MemberLoginCookie"] != null)
                {
                    cookie = Page.Request.Cookies["MemberLoginCookie"];
                    cookie2 = HttpSecureCookie.Decode(cookie);
                    TextBoxMemLoginID.Text = cookie2.Values["MemLoginID"];
                    TextBoxMemLoginID.ReadOnly = true;
                    LoginHref.Visible = false;
                }
                else
                {
                    new Order();
                    TextBoxMemLoginID.Text = "游客";
                    LoginHref.Visible = true;
                    LoginHref.HRef = "http://" + ShopSettings.siteDomain + "/Login" +
                                     (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx") +
                                     "?goback=" +
                                     Page.Request.Url.ToString()
                                         .Replace("%3a%2f%2f", "://")
                                         .Replace("/", "%2f")
                                         .Replace("&", "%26");
                }
            }
            else if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                cookie = Page.Request.Cookies["MemberLoginCookie"];
                cookie2 = HttpSecureCookie.Decode(cookie);
                TextBoxMemLoginID.Text = cookie2.Values["MemLoginID"];
                TextBoxMemLoginID.ReadOnly = true;
                LoginHref.Visible = false;
            }
            else
            {
                new Order();
                TextBoxMemLoginID.Text = "游客";
                LoginHref.Visible = true;
                LoginHref.HRef = "http://" + ShopSettings.siteDomain + "/Login" +
                                 (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx") + "?goback=" +
                                 Page.Request.Url.ToString()
                                     .Replace("%3a%2f%2f", "://")
                                     .Replace("/", "%2f")
                                     .Replace("&", "%26");
            }
        }
    }
}