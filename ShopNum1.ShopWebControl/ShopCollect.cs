using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopCollect : BaseWebControl
    {
        private ImageButton ImageButtonShopCollect;
        private string skinFilename = "ShopCollect.ascx";

        public ShopCollect()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemberLoginID { get; set; }

        public string MemLoginID { get; set; }

        public string ShopID { get; set; }

        protected void ImageButtonShopCollect_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.Request.Cookies["MemberLoginCookie"] != null)
            {
                HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                MemberLoginID = cookie2.Values["MemLoginID"];
                var action = (Shop_Collect_Action)LogicFactory.CreateShop_Collect_Action();
                if (action.AddShopCollect(MemberLoginID, ShopID) > 0)
                {
                    MessageBox.Show("收藏成功");
                    action.ShopCollectNum(MemLoginID);
                }
                else
                {
                    MessageBox.Show("已收藏该店");
                }
            }
            else
            {
                GetUrl.RedirectShopLoginGoBack("目前尚未登录！请登录后再收藏店铺！");
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(ShopID);
            ImageButtonShopCollect = (ImageButton) skin.FindControl("ImageButtonShopCollect");
            ImageButtonShopCollect.Click += ImageButtonShopCollect_Click;
            if (!Page.IsPostBack)
            {
            }
            ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(MemLoginID);
        }
    }
}