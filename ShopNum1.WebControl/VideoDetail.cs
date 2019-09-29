using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class VideoDetail : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "VideoDetail.ascx";

        public VideoDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        public static string GetVideo(object video, string height, string width)
        {
            string input = video.ToString();
            input = new Regex("height=\"[0-9]+\"", RegexOptions.IgnoreCase).Replace(input, "height=\"" + height + "\"");
            var regex2 = new Regex("width=\"[0-9]+\"", RegexOptions.IgnoreCase);
            return regex2.Replace(input, "width=\"" + width + "\"");
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            Guid = (Page.Request.QueryString["guid"] == null)
                ? "0"
                : Page.Request.QueryString["guid"];
            if (Page.Request.Cookies[Guid] == null)
            {
                var action = (ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action();
                action.AddVideoCout("BroadcastCount", Guid);
            }
            else
            {
                HttpCookie cookie = Page.Request.Cookies[Guid];
                if (cookie["VideGuid"] != Guid)
                {
                    ((ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action()).AddVideoCout("BroadcastCount",
                        Guid);
                }
            }
            BindData();
        }

        protected void BindData()
        {
            RepeaterData.DataSource =
                ((ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action()).GetVideoDetail(Guid);
            RepeaterData.DataBind();
            var cookie = new HttpCookie(Guid);
            cookie.Values.Add("VideGuid", Guid);
            Page.Response.AppendCookie(cookie);
        }
    }
}