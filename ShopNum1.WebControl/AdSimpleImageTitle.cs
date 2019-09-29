using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.AdXml;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AdSimpleImageTitle : BaseWebControl
    {
        private Image ImageAd;
        private HtmlAnchor Imglink;
        private HtmlAnchor TitleLink;
        private string skinFilename = "AdSimpleImageTitle.ascx";

        public AdSimpleImageTitle()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string AdImgId { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            ImageAd = (Image) skin.FindControl("ImageAd");
            Imglink = (HtmlAnchor) skin.FindControl("Imglink");
            TitleLink = (HtmlAnchor) skin.FindControl("TitleLink");
            DataTable table = DefaultAdvertismentOperate.SelecByID(AdImgId);
            if ((table != null) && (table.Rows.Count != 0))
            {
                if (ImageAd != null)
                {
                    ImageAd.ImageUrl = table.Rows[0]["imgSrc"].ToString();
                    ImageAd.Width = Convert.ToInt32(table.Rows[0]["width"]);
                    ImageAd.Height = Convert.ToInt32(table.Rows[0]["height"]);
                    ImageAd.ToolTip = table.Rows[0]["id"].ToString();
                }
                if (Imglink != null)
                {
                    Imglink.HRef = table.Rows[0]["href"].ToString();
                    Imglink.Attributes.Add("adlink", Imglink.HRef);
                    Imglink.Title = table.Rows[0]["title"].ToString();
                }
                if (TitleLink != null)
                {
                    TitleLink.HRef = table.Rows[0]["href"].ToString();
                    TitleLink.InnerHtml = table.Rows[0]["title"].ToString();
                }
            }
        }
    }
}