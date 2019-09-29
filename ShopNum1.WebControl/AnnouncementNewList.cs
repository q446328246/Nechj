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
    public class AnnouncementNewList : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "AnnouncementNewList.ascx";

        public AnnouncementNewList()
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
            var action = (ShopNum1_Announcement_Action) LogicFactory.CreateShopNum1_Announcement_Action();
            string showCount = ShopSettings.GetValue("DefaultAnnouncementNewCount");
            DataTable annoucementNew = action.GetAnnoucementNew(showCount);
            if (annoucementNew.Rows.Count > 0)
            {
                RepeaterData.DataSource = annoucementNew;
                RepeaterData.DataBind();
            }
        }
    }
}