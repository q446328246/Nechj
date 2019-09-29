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
    public class AdSimpleImage : BaseWebControl
    {
        private Image ImageAd;
        private HtmlAnchor Imglink;
        private string skinFilename = "AdSimpleImage.ascx";

        public AdSimpleImage()
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
            DataTable table = DefaultAdvertismentOperate.SelecByID(AdImgId);
            if ((table != null) && (table.Rows.Count != 0))
            {
                ImageAd.ImageUrl = table.Rows[0]["imgSrc"].ToString();
                if (table.Rows[0]["width"].ToString() != "")
                {
                    ImageAd.Width = Convert.ToInt32(table.Rows[0]["width"]);
                }
                ImageAd.Height = Convert.ToInt32(table.Rows[0]["height"]);
                Imglink.HRef = table.Rows[0]["href"].ToString();
                Imglink.Attributes.Add("adlink", Imglink.HRef);
            }
        }
    }
}