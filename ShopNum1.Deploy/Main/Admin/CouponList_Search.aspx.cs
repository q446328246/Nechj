using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.SessionState;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CouponList_Search : PageBase, IRequiresSessionState
    {
        protected string Type { get; set; }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            if (Type == "List")
            {
                base.Response.Redirect("CouponList.aspx");
            }
            else if (Type == "Audit")
            {
                base.Response.Redirect("CouponList_Audit.aspx");
            }
        }

        protected void GetCouponInfo()
        {
            DataTable couponInfoById =
                ((Shop_Coupon_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Coupon_Action()).GetCouponInfoById(
                    hiddenFieldGuid.Value.Replace("'", ""));
            if ((couponInfoById != null) && (couponInfoById.Rows.Count > 0))
            {
                TextBoxSaleTitle.Text = couponInfoById.Rows[0]["SaleTitle"].ToString();
                TextBoxName.Text = couponInfoById.Rows[0]["CouponName"].ToString();
                TextBoxCouponType.Text = couponInfoById.Rows[0]["Name"].ToString();
                TextBoxStartTime.Text = couponInfoById.Rows[0]["StartTime"].ToString();
                TextBoxEndTime.Text = couponInfoById.Rows[0]["EndTime"].ToString();
                string relativeUrl = couponInfoById.Rows[0]["ImgPath"].ToString();
                ACoupon.HRef = Page.ResolveUrl(relativeUrl);
                ImageCoupon.ImageUrl = Page.ResolveUrl(relativeUrl);
                TextBoxAdressName.Text = couponInfoById.Rows[0]["AdressName"].ToString();
                FCKeditorContent.Text = base.Server.HtmlDecode(couponInfoById.Rows[0]["Content"].ToString());
            }
        }

        public string GetWebFilePath(string MemloginID)
        {
            DataTable shopIDAndOpenTimeByMemLoginID =
                ((Shop_ShopInfo_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_ShopInfo_Action()).GetShopIDAndOpenTimeByMemLoginID(
                    MemloginID);
            string str = shopIDAndOpenTimeByMemLoginID.Rows[0]["ShopID"].ToString();
            string str2 =
                DateTime.Parse(shopIDAndOpenTimeByMemLoginID.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            string path = "/ImgUpload/" + str2.Replace("-", "/") + "/shop" + str + "/Coupon/";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(path));
            }
            return path;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            Type = (base.Request.QueryString["Type"] == null) ? "0" : base.Request.QueryString["Type"];
            if (!Page.IsPostBack)
            {
                GetCouponInfo();
            }
        }
    }
}