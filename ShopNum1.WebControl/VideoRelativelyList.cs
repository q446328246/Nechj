using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class VideoRelativelyList : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "VideoRelativelyList.ascx";

        public VideoRelativelyList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        public int ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            Guid = (Page.Request.QueryString["Guid"] == null)
                ? ""
                : Page.Request.QueryString["Guid"];
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            RepeaterShow.DataSource =
                ((ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action()).GetVideoRelativelyList(Guid,
                    ShowCount);
            RepeaterShow.DataBind();
        }
    }
}