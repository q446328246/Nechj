using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopCopyright : BaseWebControl
    {
        private HtmlGenericControl CnzzCode;
        private HiddenField HiddenFieldXmlPath;
        private HyperLink HyperLinkCertification;
        private HyperLink HyperLinkUrl;
        private Label labelCopyright;
        private Label labelPoweredBy;
        private string skinFilename = "ShopCopyright.ascx";

        public ShopCopyright()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void GetCopyRightInfo()
        {
            labelCopyright.Text = Page.Server.HtmlDecode(ShopSettings.GetValue("CopyrightMember"));
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
            HiddenFieldXmlPath = (HiddenField) skin.FindControl("HiddenFieldXmlPath");
            HiddenFieldXmlPath.Value = Page.Server.MapPath(Globals.ApplicationPath + "/Settings/ShopSetting.xml");
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
            HyperLinkUrl.NavigateUrl = "http://www.t.com/";
            labelPoweredBy.Text = "Powered by 唐江国际";
        }

        protected void method_1()
        {
        }
    }
}