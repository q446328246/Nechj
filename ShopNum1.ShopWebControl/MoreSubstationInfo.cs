using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class MoreSubstationInfo : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "MoreSubstationInfo.ascx";

        public MoreSubstationInfo()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            RepeaterData.DataBind();
        }

        public static string returnAgentUlr(object object_0)
        {
            return ("http://" + object_0 + ConfigurationManager.AppSettings["Domain"]);
        }
    }
}