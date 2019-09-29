using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopCategoryAd : BaseWebControl
    {
        private HtmlAnchor ACategoryInfoAd;
        private Image ImageCategoryInfoAd;
        private string skinFilename = "ShopCategoryAd.ascx";

        public ShopCategoryAd()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string AdID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            string categorycode = (Page.Request.QueryString["code"] == null) ? "-1" : Page.Request.QueryString["code"];
            ImageCategoryInfoAd = (Image) skin.FindControl("ImageCategoryInfoAd");
            ACategoryInfoAd = (HtmlAnchor) skin.FindControl("ACategoryInfoAd");
            var action = (ShopNum1_CategoryAdPayMent_Action) LogicFactory.CreateShopNum1_CategoryAdPayMent_Action();
            DataTable table = action.SearchAdInfo(AdID, categorycode, "4");
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (table.Rows[0]["AdvertisementPic"].ToString() != string.Empty)
                {
                    ImageCategoryInfoAd.ImageUrl =
                        Page.ResolveUrl("~/ImgUpload/MemberImg/CategoryAdImg/" + table.Rows[0]["AdvertisementPic"]);
                    ACategoryInfoAd.HRef = table.Rows[0]["AdvertisementLike"].ToString();
                    ACategoryInfoAd.Title = table.Rows[0]["AdvertisementContent"].ToString();
                }
                else if (table.Rows[0]["AdvertisementDPic"].ToString() != string.Empty)
                {
                    ImageCategoryInfoAd.ImageUrl = Page.ResolveUrl("~/ImgUpload/" + table.Rows[0]["AdvertisementDPic"]);
                    ACategoryInfoAd.HRef = table.Rows[0]["AdDefaultLike"].ToString();
                    ACategoryInfoAd.Title = table.Rows[0]["AdIntroduce"].ToString();
                }
                else
                {
                    ImageCategoryInfoAd.ImageUrl =
                        Page.ResolveUrl("~/ImgUpload/" + table.Rows[0]["CategoryAdDefalutPic"]);
                    ACategoryInfoAd.HRef = table.Rows[0]["CategoryAdDefalutLike"].ToString();
                    ACategoryInfoAd.Title = table.Rows[0]["CategoryAdIntroduce"].ToString();
                }
                ImageCategoryInfoAd.Style.Add(HtmlTextWriterStyle.Height, table.Rows[0]["Height"] + "px");
                ImageCategoryInfoAd.Style.Add(HtmlTextWriterStyle.Width, table.Rows[0]["Width"] + "px");
            }
            else
            {
                DataTable table2 = action.SearchAdInfo(AdID, "4");
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    ImageCategoryInfoAd.ImageUrl =
                        Page.ResolveUrl("~/ImgUpload/" + table2.Rows[0]["CategoryAdDefalutPic"]);
                    ACategoryInfoAd.HRef = table2.Rows[0]["CategoryAdDefalutLike"].ToString();
                    ACategoryInfoAd.Title = table2.Rows[0]["CategoryAdIntroduce"].ToString();
                    ImageCategoryInfoAd.Style.Add(HtmlTextWriterStyle.Height, table2.Rows[0]["Height"] + "px");
                    ImageCategoryInfoAd.Style.Add(HtmlTextWriterStyle.Width, table2.Rows[0]["Width"] + "px");
                }
                else
                {
                    ImageCategoryInfoAd.Visible = false;
                    ACategoryInfoAd.Visible = false;
                }
            }
        }
    }
}