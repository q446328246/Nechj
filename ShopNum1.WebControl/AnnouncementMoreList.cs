using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AnnouncementMoreList : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "AnnouncementMoreList.ascx";

        public AnnouncementMoreList()
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
            DataTable annoucementList =
                ((ShopNum1_Announcement_Action) LogicFactory.CreateShopNum1_Announcement_Action()).GetAnnoucementList();
            if (annoucementList.Rows.Count > 0)
            {
                RepeaterData.DataSource = annoucementList;
                RepeaterData.DataBind();
            }
        }
    }
}