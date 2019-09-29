using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class CouponPrint : BaseWebControl
    {
        private HtmlAnchor Aprint;
        private Literal LiteralCount;
        private Literal LiteralPic;
        private Repeater RepeaterData;
        private string skinFilename = "CouponPrint.ascx";

        public CouponPrint()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private string Count { get; set; }

        public string CouponGuid { get; set; }

        private string ShopID { get; set; }

        protected string GetWebFilePath()
        {
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            string str =
                DateTime.Parse(action.GetOpenTimeByShopID(ShopID).Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            string path = "/ImgUpload/" + str.Replace("-", "/") + "/shop" + ShopID + "/Coupon/";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }
            return path;
        }

        protected void Aprint_ServerClick(object sender, EventArgs e)
        {
            string count = (Page.Request.QueryString["count"] == null) ? "2" : Page.Request.QueryString["count"];
            ((Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action()).UpdataDownloadCountByGuid(CouponGuid, count);
        }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            CouponGuid = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            LiteralCount = (Literal) skin.FindControl("LiteralCount");
            LiteralPic = (Literal) skin.FindControl("LiteralPic");
            Aprint = (HtmlAnchor) skin.FindControl("Aprint");
            Aprint.ServerClick += Aprint_ServerClick;
            BindData();
        }

        protected void BindData()
        {
            int num = int.Parse((Page.Request.QueryString["count"] == null) ? "2" : Page.Request.QueryString["count"]);
            string str = string.Empty;
            DataTable table =
                ((Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action()).SearchCouponByGuid(CouponGuid, ShopID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                string str2 = Page.ResolveUrl(table.Rows[0]["ImgPath"].ToString());
                LiteralCount.Text = num.ToString();
                for (int i = 0; i < num; i++)
                {
                    str = str + "<div class=\"ticket\"> <p><img alt=\"\" src=\"" + str2 +
                          "\" width=\"294\" /></p><span><img alt=\"\" src=\"Themes/Skin_Default/Images/33.gif\" /></span> </div>";
                }
                LiteralPic.Text = str;
            }
        }
    }
}