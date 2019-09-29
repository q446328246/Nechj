using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ZoomImageDemo;

namespace ShopNum1.AccountWebControl
{
    [ParseChildren(true)]
    public class A_LoadUserPhoto : BaseMemberWebControl
    {
        private Image ImageDrag;
        private Image ImageIcon;
        private Button btnUpload;
        private Button btn_Image;
        private FileUpload fuPhoto;
        private HtmlInputHidden hid_imgValue;
        private HiddenField hid_lefeValue;
        private Image imgphoto;
        private string skinFilename = "A_LoadUserPhoto.ascx";
        private string string_1 = string.Empty;
        private TextBox txt_DropHeight;
        private TextBox txt_DropWidth;
        private TextBox txt_Zoom;
        private TextBox txt_height;
        private TextBox txt_left;
        private TextBox txt_top;
        private TextBox txt_width;

        public A_LoadUserPhoto()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btn_Image_Click(object sender, EventArgs e)
        {
            int imageWidth = int.Parse(txt_width.Text);
            int imageHeight = int.Parse(txt_height.Text);
            int pOrigStartPointY = int.Parse(txt_top.Text);
            int pOrigStartPointX = int.Parse(txt_left.Text);
            int pPartWidth = int.Parse(txt_DropWidth.Text);
            int pPartHeight = int.Parse(txt_DropHeight.Text);
            string str = CutPhotoHelp.SaveCutPic(Page.Server.MapPath(ImageIcon.ImageUrl),
                Page.Server.MapPath(string_1), 0, 0, pPartWidth, pPartHeight,
                pOrigStartPointX, pOrigStartPointY, imageWidth, imageHeight);
            imgphoto.ImageUrl = string_1 + str;
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();
            string path = action.SearchByMemLoginID(base.MemLoginID).Rows[0]["Photo"].ToString();
            try
            {
                if (path != "")
                {
                    File.Delete(Page.Server.MapPath(path));
                }
            }
            catch
            {
            }
            finally
            {
                action.UpdatePhoto(base.MemLoginID, string_1 + str);
                File.Delete(Page.Server.MapPath(hid_imgValue.Value));
                Page.ClientScript.RegisterStartupScript(typeof (A_LoadUserPhoto), "setPic",
                    "<script type='text/javascript'>setPic('" +
                    imgphoto.ImageUrl + "');</script>");
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if ((fuPhoto.PostedFile != null) && (fuPhoto.PostedFile.ContentLength > 0))
            {
                string str = Path.GetExtension(fuPhoto.PostedFile.FileName).ToLower();
                if (((!(str != ".jpg") || !(str != ".jepg")) || (!(str != ".bmp") || !(str != ".gif"))) ||
                    !(str != ".png"))
                {
                    string str2 = base.MemLoginID + DateTime.Now.ToString("yyyyMMddHHmmss") + str;
                    string path = "/ImgUpload/MemberImage/" + str2;
                    fuPhoto.PostedFile.SaveAs(Page.Server.MapPath(path));
                    Page.Response.Redirect("A_LoadUserPhoto.aspx?Picurl=" + Page.Server.UrlEncode(path));
                }
            }
        }

        protected string GetWebFilePath()
        {
            ((ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(base.MemLoginID);
            DateTime.Now.ToString("yyyy-MM-dd");
            string path = "/ImgUpload/MemberImage/";
            if (!Directory.Exists(Page.Server.MapPath(path)))
            {
                Directory.CreateDirectory(Page.Server.MapPath(path));
            }
            return path;
        }

        protected override void InitializeSkin(Control skin)
        {
            imgphoto = (Image) skin.FindControl("imgphoto");
            ImageDrag = (Image) skin.FindControl("ImageDrag");
            ImageIcon = (Image) skin.FindControl("ImageIcon");
            btnUpload = (Button) skin.FindControl("btnUpload");
            btnUpload.Click += btnUpload_Click;
            fuPhoto = (FileUpload) skin.FindControl("fuPhoto");
            btn_Image = (Button) skin.FindControl("btn_Image");
            btn_Image.Click += btn_Image_Click;
            txt_width = (TextBox) skin.FindControl("txt_width");
            txt_height = (TextBox) skin.FindControl("txt_height");
            txt_top = (TextBox) skin.FindControl("txt_top");
            txt_left = (TextBox) skin.FindControl("txt_left");
            txt_DropWidth = (TextBox) skin.FindControl("txt_DropWidth");
            txt_DropHeight = (TextBox) skin.FindControl("txt_DropHeight");
            txt_Zoom = (TextBox) skin.FindControl("txt_Zoom");
            hid_lefeValue = (HiddenField) skin.FindControl("hid_lefeValue");
            hid_imgValue = (HtmlInputHidden) skin.FindControl("hid_imgValue");
            string_1 = GetWebFilePath();
            if (!string.IsNullOrEmpty(Page.Request.QueryString["Picurl"]))
            {
                ImageDrag.ImageUrl = Page.Request.QueryString["Picurl"];
                ImageIcon.ImageUrl = Page.Request.QueryString["Picurl"];
                Page.ClientScript.RegisterStartupScript(typeof (A_LoadUserPhoto), "step2",
                    "<script type='text/javascript'>Step2();</script>");
                hid_imgValue.Value = ImageDrag.ImageUrl;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof (A_LoadUserPhoto), "step1",
                    "<script type='text/javascript'>Step1();</script>");
            }
        }
    }
}