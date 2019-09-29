using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AnnouncementNewList1 : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "AnnouncementNewList1.ascx";

        public AnnouncementNewList1()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            DataTable annoucementNew =
                ((ShopNum1_Announcement_Action) LogicFactory.CreateShopNum1_Announcement_Action()).GetAnnoucementNew(
                    ShowCount);
            if (annoucementNew.Rows.Count > 0)
            {
                RepeaterData.DataSource = annoucementNew;
                RepeaterData.DataBind();
            }
        }
    }
}