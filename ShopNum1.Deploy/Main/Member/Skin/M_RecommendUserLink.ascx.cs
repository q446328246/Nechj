using System;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;

namespace ShopNum1.Deploy.Main.Member.Skin
{
    public partial class M_RecommendUserLink : BaseMemberControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hidMemLoginId.Value = base.MemLoginID;
            inputShopurl.Value = ShopSettings.siteDomain + "/MemberRegister.aspx?memberid=";
        }
    }
}