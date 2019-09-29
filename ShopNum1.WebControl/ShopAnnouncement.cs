using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ShopAnnouncement : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "ShopAnnouncement.ascx";

        public ShopAnnouncement()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCategory { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            DataTable shopAnnouncementNew =
                ((ShopNum1_Announcement_Action) LogicFactory.CreateShopNum1_Announcement_Action())
                    .GetShopAnnouncementNew(ShopSettings.GetValue("ShopAnnouncementCount"), ShowCategory);
            if (shopAnnouncementNew.Rows.Count > 0)
            {
                RepeaterData.DataSource = shopAnnouncementNew;
                RepeaterData.DataBind();
            }
        }
    }
}