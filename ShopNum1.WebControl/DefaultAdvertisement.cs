using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    public class DefaultAdvertisement : BaseWebControl
    {
        private HtmlImage AdBigImg;
        private Repeater RepeaterSmall;
        private string skinFilename = "DefaultAdvertisement.ascx";

        public DefaultAdvertisement()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void BindAd()
        {
            string filePath = Page.Request.FilePath;
            if (filePath.Substring(filePath.LastIndexOf('/') + 1) == "")
            {
            }
            var action = (ShopNum1_DefaultAdImg_Action) LogicFactory.CreateShopNum1_DefaultAdImg_Action();
            DataTable defaultData = action.DefaultData;
            if ((defaultData != null) && (defaultData.Rows.Count != 0))
            {
                DataView defaultView = defaultData.DefaultView;
                defaultView.Sort = "orderID";
                RepeaterSmall.DataSource = defaultView;
                RepeaterSmall.DataBind();
                string clientID = AdBigImg.ClientID;
                AdBigImg.Src = defaultData.Rows[0]["imgsrc"].ToString();
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterSmall = (Repeater) skin.FindControl("RepeaterSmall");
            AdBigImg = (HtmlImage) skin.FindControl("AdBigImg");
            BindAd();
        }
    }
}