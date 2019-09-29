using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopDomainCopyright : BaseWebControl
    {
        private HtmlGenericControl CnzzCode;
        private HyperLink HyperLinkCertification;
        private HyperLink HyperLinkUrl;
        private Label labelCopyright;
        private Label labelPoweredBy;
        private string skinFilename = "ShopDomainCopyright.ascx";

        public ShopDomainCopyright()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void GetCopyRightInfo()
        {
        }

        protected void GetStatisticsCode()
        {
            CnzzCode.InnerHtml = Page.Server.HtmlDecode(ShopSettings.GetValue("StatisticsCode"));
        }

        protected override void InitializeSkin(Control skin)
        {
            labelCopyright = (Label) skin.FindControl("labelCopyright");
            labelPoweredBy = (Label) skin.FindControl("labelPoweredBy");
            HyperLinkUrl = (HyperLink) skin.FindControl("HyperLinkUrl");
            HyperLinkCertification = (HyperLink) skin.FindControl("HyperLinkCertification");
            CnzzCode = (HtmlGenericControl) skin.FindControl("CnzzCode");
            if (!Page.IsPostBack)
            {
            }
            if (CnzzCode != null)
            {
                GetStatisticsCode();
            }
            if (labelPoweredBy != null)
            {
                BindData();
            }
            if (labelCopyright != null)
            {
                GetCopyRightInfo();
            }
            if (HyperLinkCertification != null)
            {
                method_1();
            }
        }

        protected void BindData()
        {
            HyperLinkUrl.NavigateUrl = ShopSettings.GetValue("CopyrightLink");
            labelPoweredBy.Text = ShopSettings.GetValue("Copyright");
        }

        protected void method_1()
        {
        }
    }
}