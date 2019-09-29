using System;
using System.IO;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ZoomImageDemo;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_LoadUserPhoto : BaseMemberControl
    {
        private string string_1 = string.Empty;


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

        protected void Page_Load(object sender, EventArgs e)
        {
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
                                            
