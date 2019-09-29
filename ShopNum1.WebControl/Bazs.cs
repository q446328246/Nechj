using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    /// <summary>
    ///     备案查询
    /// </summary>
    [ParseChildren(true)]
    public class Bazs : BaseWebControl
    {
        private HtmlGenericControl CnzzCode;
        private HyperLink HyperLinkUrl;
        private Label ICPNum;
        private string skinFilename = "Bazs.ascx";

        public Bazs()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void GetBazs()
        {
            ICPNum.Text = Page.Server.HtmlDecode(ShopSettings.GetValue("ICPNum"));
        }

        protected void GetStatisticsCode()
        {
            CnzzCode.InnerHtml = Page.Server.HtmlDecode(ShopSettings.GetValue("StatisticsCode"));
        }

        protected override void InitializeSkin(Control skin)
        {
            ICPNum = (Label) skin.FindControl("labelBazs");
            HyperLinkUrl = (HyperLink) skin.FindControl("HyperLinkUrl");
            CnzzCode = (HtmlGenericControl) skin.FindControl("CnzzCode");
            if (!Page.IsPostBack)
            {
            }
            if (ICPNum != null)
            {
                GetBazs();
                BindData();
            }
        }

        protected void BindData()
        {
            HyperLinkUrl.NavigateUrl = "http://www.miibeian.gov.cn/";
        }
    }
}