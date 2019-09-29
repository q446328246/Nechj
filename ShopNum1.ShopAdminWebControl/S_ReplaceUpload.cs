using System.Web;
using System.Web.UI;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ReplaceUpload : BaseShopWebControl
    {
        private string skinFilename = "S_ReplaceUpload.cs.ascx";

        public S_ReplaceUpload()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            if (Page.Request.Files["file"] != null)
            {
                HttpPostedFile file = Page.Request.Files["file"];
                MessageBox.Show(file.FileName);
            }
        }
    }
}