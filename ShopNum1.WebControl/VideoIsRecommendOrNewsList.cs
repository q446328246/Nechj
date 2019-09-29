using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class VideoIsRecommendOrNewsList : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "VideoIsRecommendOrNewsList.ascx";

        public VideoIsRecommendOrNewsList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string IsType { get; set; }

        public int ShowCount { get; set; }

        public static string GetSubstr(object title, int length, bool isEllipsis)
        {
            string str = title.ToString();
            if (str.Length > length)
            {
                str = str.Substring(0, length);
            }
            if (isEllipsis)
            {
                str = str + "...";
            }
            return str;
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            RepeaterShow.DataSource =
                ((ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action()).GetVideoList(ShowCount, IsType);
            RepeaterShow.DataBind();
        }
    }
}