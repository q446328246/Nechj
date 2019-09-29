using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class VideoIsHotList : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "VideoIsHotList.ascx";

        public VideoIsHotList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCount { get; set; }

        public static string GetVideoCommentCount(string guid)
        {
            try
            {
                var action = (ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action();
                return action.GetVideoComment(guid).ToString();
            }
            catch (Exception)
            {
                return "0";
            }
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
                ((ShopNum1_Video_Action) LogicFactory.CreateShopNum1_Video_Action()).GetVideoHotList(ShowCount);
            RepeaterShow.DataBind();
        }
    }
}