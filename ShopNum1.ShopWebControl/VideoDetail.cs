using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class VideoDetail : BaseWebControl
    {
        private Repeater RepeaterData;
        private string skinFilename = "VideoDetail.ascx";
        private string string_1;

        public VideoDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int ShowCount { get; set; }

        public static string GetVideo(object video, string height, string width)
        {
            string input = video.ToString();
            input = new Regex("height=\"[0-9]+\"", RegexOptions.IgnoreCase).Replace(input, "height=\"" + height + "\"");
            var regex2 = new Regex("width=\"[0-9]+\"", RegexOptions.IgnoreCase);
            return regex2.Replace(input, "width=\"" + width + "\"");
        }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            string_1 = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            if (!Page.IsPostBack)
            {
            }
            try
            {
                ((Shop_Video_Action) LogicFactory.CreateShop_Video_Action()).AddBroadcastCount(1, string_1);
            }
            catch (Exception)
            {
            }
            BindData();
        }

        public static string IsShow(object object_0)
        {
            switch (object_0.ToString())
            {
                case "0":
                    return "否";

                case "1":
                    return "是";
            }
            return "";
        }

        protected void BindData()
        {
            DataTable videoInfoByGuidAndMemLoginID =
                ((Shop_Video_Action) LogicFactory.CreateShop_Video_Action()).GetVideoInfoByGuidAndMemLoginID(string_1,
                    MemLoginID);
            if ((videoInfoByGuidAndMemLoginID != null) && (videoInfoByGuidAndMemLoginID.Rows.Count > 0))
            {
                RepeaterData.DataSource = videoInfoByGuidAndMemLoginID.DefaultView;
                RepeaterData.DataBind();
            }
        }
    }
}