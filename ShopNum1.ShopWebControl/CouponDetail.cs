using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class CouponDetail : BaseWebControl
    {
        private HtmlImage CouponImg;
        private DropDownList DropDownListPrint;
        private HiddenField HiddenFieldGuid;
        private ImageButton ImageButton;
        private Literal LiteralBrowserCount;
        private Literal LiteralDownloadCount;
        private Repeater RepeaterDetail;
        private HtmlImage imgIsEffective;
        private string skinFilename = "CouponDetail.ascx";

        public CouponDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShopID { get; set; }

        protected string GetWebFilePath()
        {
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            string str =
                DateTime.Parse(action.GetOpenTimeByShopID(ShopID).Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            string path = "~/ImgUpload/" + str.Replace("-", "/") + "/shop" + ShopID + "/Coupon/";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }
            return path;
        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (DropDownListPrint.SelectedValue == "0")
            {
                Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "msg", "<script>alert('最少打印一张!');window.location.href=window.location.href;</script>", false);
            }
            else
            {
                try
                {
                    var guid = new Guid(HiddenFieldGuid.Value);
                }
                catch
                {
                    MessageBox.Show("当前没有可以打印的优惠券！");
                    return;
                }
                string str2 = ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf("."));
                string shopURLByShopID =
                    Factory.LogicFactory.CreateShopNum1_ShopInfoList_Action().GetShopURLByShopID(ShopID);
                if (ShopSettings.IsOverrideUrl)
                {
                    Page.Response.Redirect("http://" + shopURLByShopID + str2 + "/CouponPrint/" + HiddenFieldGuid.Value +
                                           ShopSettings.overrideUrlName + "?count=" + DropDownListPrint.SelectedValue);
                }
                else
                {
                    Page.Response.Redirect("http://" + shopURLByShopID + str2 + "/CouponPrint/" + HiddenFieldGuid.Value +
                                           ".aspx?count=" + DropDownListPrint.SelectedValue);
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            RepeaterDetail = (Repeater) skin.FindControl("RepeaterDetail");
            LiteralBrowserCount = (Literal) skin.FindControl("LiteralBrowserCount");
            LiteralDownloadCount = (Literal) skin.FindControl("LiteralDownloadCount");
            DropDownListPrint = (DropDownList) skin.FindControl("DropDownListPrint");
            HiddenFieldGuid = (HiddenField) skin.FindControl("HiddenFieldGuid");
            HiddenFieldGuid.Value = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            CouponImg = (HtmlImage) skin.FindControl("CouponImg");
            imgIsEffective = (HtmlImage) skin.FindControl("imgIsEffective");
            ImageButton = (ImageButton) skin.FindControl("ImageButton");
            ImageButton.Click += ImageButton_Click;
            BindData();
            method_1();
        }

        protected void BindData()
        {
            DataTable table =
                ((Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action()).SearchCouponByGuid(HiddenFieldGuid.Value,
                    ShopID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                CouponImg.Src = Page.ResolveUrl(table.Rows[0]["ImgPath"].ToString());
                LiteralBrowserCount.Text = table.Rows[0]["BrowserCount"].ToString();
                LiteralDownloadCount.Text = table.Rows[0]["DownloadCount"].ToString();
                if ((table.Rows[0]["IsEffective"].ToString() == "0") ||
                    (Convert.ToDateTime(table.Rows[0]["EndTime"].ToString()) < DateTime.Now))
                {
                    imgIsEffective.Src = "../Images/unineffect.gif";
                }
                else
                {
                    imgIsEffective.Src = "../Images/ineffect.gif";
                }
                HiddenFieldGuid.Value = table.Rows[0]["Guid"].ToString();
                RepeaterDetail.DataSource = table.DefaultView;
                RepeaterDetail.DataBind();
            }
        }

        protected void method_1()
        {
            if (Page.Request.Cookies["Browser"] == null)
            {
                try
                {
                    var guid = new Guid(HiddenFieldGuid.Value);
                }
                catch
                {
                    return;
                }
                var action = (Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action();
                if (action.UpdateBrowserCount(HiddenFieldGuid.Value) > 0)
                {
                    var cookie = new HttpCookie("Browser");
                    HttpCookie cookie2 = HttpSecureCookie.Encode(cookie);
                    cookie2.Domain = ConfigurationManager.AppSettings["CookieDomain"];
                    cookie2.Expires = DateTime.Now.AddMinutes(30.0);
                    Page.Response.AppendCookie(cookie2);
                }
            }
        }
    }
}