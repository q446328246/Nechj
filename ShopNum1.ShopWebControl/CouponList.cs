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
    public class CouponList : BaseWebControl
    {
        private Repeater RepeaterData;
        private HtmlImage htmlImage_0;
        private HtmlImage htmlImage_1;
        private string skinFilename = "CouponList.ascx";

        public CouponList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private string MemLoginID { get; set; }

        private string ShopID { get; set; }

        public string ShowCount { get; set; }

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

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(ShopID);
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            BindData();
        }

        protected void BindData()
        {
            DataTable table =
                ((Shop_Coupon_Action) LogicFactory.CreateShop_Coupon_Action()).SearchCouponByMemloginID(ShowCount,
                    MemLoginID);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
                for (int i = 0; i < RepeaterData.Items.Count; i++)
                {
                    htmlImage_1 = (HtmlImage) RepeaterData.Items[i].FindControl("ImgCoupon");
                    htmlImage_1.Src = Page.ResolveUrl(GetWebFilePath() + table.Rows[i]["ImgPath"]);
                    htmlImage_0 = (HtmlImage) RepeaterData.Items[i].FindControl("imgIsEffective");
                    if ((table.Rows[i]["IsEffective"].ToString() == "0") ||
                        (Convert.ToDateTime(table.Rows[i]["EndTime"].ToString()) < DateTime.Now))
                    {
                        htmlImage_0.Src = "../Images/unineffect.gif";
                    }
                    else
                    {
                        htmlImage_0.Src = "../Images/ineffect.gif";
                    }
                }
            }
        }
    }
}