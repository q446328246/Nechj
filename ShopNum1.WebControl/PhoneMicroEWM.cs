using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    public class PhoneMicroEWM : BaseWebControl
    {
        private Image imgPhoneMicroEWM;
        private string skinFilename = "PhoneMicroEWM.ascx";

        public PhoneMicroEWM()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string TypeEWM { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            imgPhoneMicroEWM = (Image) skin.FindControl("imgPhoneMicroEWM");
            XmlOperator.ReadXmlReturnNodeList(
                Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), "ShopSetting");
            string relativeUrl =
                XmlOperator.ReadXmlReturnNode(
                    Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml"), TypeEWM);
            imgPhoneMicroEWM.ImageUrl = Page.ResolveUrl(relativeUrl);
        }
    }
}