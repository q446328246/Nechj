using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class AnnouncementDetail : BaseWebControl
    {
        private Repeater RepeaterData;
        private Repeater RepeaterUpDown;
        private string skinFilename = "AnnouncementDetail.ascx";
        private string string_1 = "上一篇：";
        private string string_2 = "下一篇：";

        public AnnouncementDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string NextAnnouncementName
        {
            get { return string_2; }
            set { string_2 = value; }
        }

        public string OnAnnouncementName
        {
            get { return string_1; }
            set { string_1 = value; }
        }

        public string StrGuid { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterUpDown = (Repeater) skin.FindControl("RepeaterUpDown");
            StrGuid = (Page.Request.QueryString["Guid"] == null) ? "" : Page.Request.QueryString["Guid"];
            if (StrGuid != "")
            {
                BindData();
            }
        }

        protected void BindData()
        {
            var action = (ShopNum1_Announcement_Action) LogicFactory.CreateShopNum1_Announcement_Action();
            DataTable annoucementDetails = action.GetAnnoucementDetails(StrGuid);
            if (annoucementDetails.Rows.Count > 0)
            {
                RepeaterData.DataSource = annoucementDetails;
                RepeaterData.DataBind();
            }
            DataTable table2 = action.GetAnnouncementOnAndNext(StrGuid, string_1, string_2);
            if (table2.Rows.Count > 0)
            {
                RepeaterUpDown.DataSource = table2.DefaultView;
                RepeaterUpDown.DataBind();
            }
        }
    }
}