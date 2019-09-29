using System.Web.UI;
using System.Web.UI.HtmlControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.MemberWebControl
{
    [ParseChildren(true)]
    public class M_RecommendUserLink : BaseMemberWebControl
    {
        private HtmlInputHidden hidMemLoginId;
        private HtmlInputText inputShopurl;
        private string skinFilename = "M_RecommendUserLink.ascx";

        public M_RecommendUserLink()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            inputShopurl = (HtmlInputText) skin.FindControl("inputShopurl");
            hidMemLoginId = (HtmlInputHidden) skin.FindControl("hidMemLoginId");
            hidMemLoginId.Value = base.MemLoginID;
            inputShopurl.Value = ShopSettings.siteDomain + "/MemberRegister.aspx?memberid=";
        }
    }
}