using System;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;
using Image = System.Drawing.Image;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class VideoCommentAdd : BaseWebControl
    {
        private Button ButtonConfirm;
        private Label LabelCheckCode;
        private TextBox TextBoxContent;
        private TextBox TextBoxMemLoginID;
        private HtmlInputText VideoCommentAddVerifyCode;
        private HtmlGenericControl divVerifyCode;
        private string skinFilename = "VideoCommentAdd.ascx";
        private string string_1;

        public VideoCommentAdd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guids { get; set; }

        public string MemLoginID { get; set; }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if ((ShopSettings.GetValue("VideoCommentCondition") == "1") &&
                (Page.Request.Cookies["MemberLoginCookie"] == null))
            {
                GetUrl.RedirectLogin("对不起，只有登录用户才能进行评论！");
                Page.Response.Redirect("http://" + ShopSettings.siteDomain + "/Login" +
                                       (ShopSettings.IsOverrideUrl ? ShopSettings.overrideUrlName : ".aspx"));
            }
            else
            {
                int num;
                if (!(ShopSettings.GetValue("VideoCommentVerifyCode") == "0"))
                {
                    string str2 = (Page.Session["code"].ToString() == null)
                        ? ""
                        : Page.Session["code"].ToString();
                    if (VideoCommentAddVerifyCode.Value.ToUpper().Trim() != str2)
                    {
                        //ClientScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg", "alert(\"验证码不正确!\");",true);
                        return;
                    }
                }
                var comment = new ShopNum1_VideoComment
                {
                    Guid = Guid.NewGuid(),
                    VideoGuid = Guids,
                    CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                    Content = TextBoxContent.Text.Trim(),
                    MemLoginID = TextBoxMemLoginID.Text.Trim()
                };
                if (ShopSettings.GetValue("VideoCommentISAudit").Trim() == "0")
                {
                    num = 1;
                }
                else
                {
                    num = 0;
                }
                comment.IsAudit = num;
                comment.IsDeleted = 0;
                var action = (ShopNum1_VideoComment_Action) LogicFactory.CreateShopNum1_VideoComment_Action();
                if (action.Add(comment) > 0)
                {
                    //Page.Request.QueryString["guid"];
                    //ClientScriptManager.RegisterStartupScript(Page, Page.GetType(), "msg",
                    //                                    "window.alert(\"评论成功！\");window.location.href=window.location.href",
                    //                                    true);
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
            string_1 = ShopSettings.GetValue("VideoCommentVerifyCode");
            if (string_1 == "0")
            {
                divVerifyCode = (HtmlGenericControl) skin.FindControl("divVerifyCode");
                LabelCheckCode = (Label) skin.FindControl("LabelCheckCode");
                LabelCheckCode.Visible = false;
                divVerifyCode.Visible = false;
                divVerifyCode.Attributes.Add("style", "display:none;");
            }
            VideoCommentAddVerifyCode = (HtmlInputText) skin.FindControl("VideoCommentAddVerifyCode");
            TextBoxMemLoginID = (TextBox) skin.FindControl("TextBoxMemLoginID");
            TextBoxContent = (TextBox) skin.FindControl("TextBoxContent");
            ButtonConfirm = (Button) skin.FindControl("ButtonConfirm");
            ButtonConfirm.Click += ButtonConfirm_Click;
            Guids = (Page.Request.QueryString["Guid"] == null)
                ? ""
                : Page.Request.QueryString["Guid"];
            switch (ShopSettings.GetValue("VideoCommentCondition"))
            {
                case "0":
                    if (Page.Request.Cookies["MemberLoginCookie"] != null)
                    {
                        cookie = Page.Request.Cookies["MemberLoginCookie"];
                        cookie2 = HttpSecureCookie.Decode(cookie);
                        MemLoginID = cookie2.Values["MemLoginID"];
                        TextBoxMemLoginID.Text = MemLoginID;
                    }
                    else
                    {
                        TextBoxMemLoginID.Text = "游客";
                    }
                    break;

                case "1":
                    if (Page.Request.Cookies["MemberLoginCookie"] != null)
                    {
                        cookie = Page.Request.Cookies["MemberLoginCookie"];
                        cookie2 = HttpSecureCookie.Decode(cookie);
                        MemLoginID = cookie2.Values["MemLoginID"];
                        TextBoxMemLoginID.Text = MemLoginID;
                    }
                    else
                    {
                        TextBoxMemLoginID.Text = "游客";
                    }
                    break;
            }
        }

        protected void BindData()
        {
            string str = Globals.SkinPath + "/Images/CheckCode/";
            var random = new Random();
            string str2 = random.Next(0x457, 0x270f).ToString();
            int width = 0;
            int height = 0;
            Bitmap bitmap = null;
            Graphics graphics = null;
            SolidBrush brush = null;
            method_1(str2);
            Image image = Image.FromFile(Page.Server.MapPath(str + str2.Substring(0, 1) + ".gif"));
            Image image2 = Image.FromFile(Page.Server.MapPath(str + str2.Substring(1, 1) + ".gif"));
            Image image3 = Image.FromFile(Page.Server.MapPath(str + str2.Substring(2, 1) + ".gif"));
            Image image4 = Image.FromFile(Page.Server.MapPath(str + str2.Substring(3, 1) + ".gif"));
            width = ((image.Width + image2.Width) + image3.Width) + image4.Width;
            height = image.Height;
            bitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(bitmap);
            brush = new SolidBrush(Color.Black);
            graphics.FillRectangle(brush, 0, 0, width, height);
            graphics.DrawImage(image, 0, 0);
            graphics.DrawImage(image2, image.Width, 0);
            graphics.DrawImage(image3, image.Width + image2.Width, 0);
            graphics.DrawImage(image4, (image.Width + image2.Width) + image3.Width, 0);
            bitmap.Save(Page.Server.MapPath(str + "/verify.bmp"));
            brush.Dispose();
            graphics.Dispose();
            bitmap.Dispose();
        }

        protected void method_1(string string_4)
        {
            ViewState["VerifyCode"] = string_4;
        }
    }
}