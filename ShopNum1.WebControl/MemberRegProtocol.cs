using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class MemberRegProtocol : BaseWebControl
    {
        private Label labelRegProtocol;
        private string skinFilename = "MemberRegProtocol.ascx";

        public MemberRegProtocol()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void GetRegProtocolInfo()
        {
            labelRegProtocol.Text = Page.Server.HtmlDecode(ShopSettings.GetValue("RegProtocol"));
        }

        protected override void InitializeSkin(Control skin)
        {
            labelRegProtocol = (Label) skin.FindControl("labelRegProtocol");
            if (!Page.IsPostBack)
            {
                GetRegProtocolInfo();
            }
        }
    }
}