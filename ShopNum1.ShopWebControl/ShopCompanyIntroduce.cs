using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopCompanyIntroduce : BaseWebControl
    {
        private Button ButtonBooking;
        private Repeater RepeaterShow;
        private string skinFilename = "ShopCompanyIntroduce.ascx";

        public ShopCompanyIntroduce()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public static string ShopID { get; set; }

        protected void ButtonBooking_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(GetPageName.RetUrl("ProductBooking"));
        }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            ButtonBooking = (Button) skin.FindControl("ButtonBooking");
            ButtonBooking.Click += ButtonBooking_Click;
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            string memloginid = action.GetMemberLoginidByShopid(ShopID);
            DataTable shopInfo = action.GetShopInfo(memloginid);
            RepeaterShow.DataSource = shopInfo.DefaultView;
            RepeaterShow.DataBind();
        }

        public string RetrunRankPic(object object_0)
        {
            int num = int.Parse(object_0.ToString());
            DataTable shopRankScoreScope =
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).GetShopRankScoreScope();
            if (shopRankScoreScope.Rows.Count > 0)
            {
                int num2 = 0;
                if ((0 < shopRankScoreScope.Rows.Count) &&
                    ((num > int.Parse(shopRankScoreScope.Rows[num2]["minScore"].ToString())) &&
                     (num <= int.Parse(shopRankScoreScope.Rows[num2]["maxScore"].ToString()))))
                {
                    return shopRankScoreScope.Rows[num2]["Pic"].ToString();
                }
                return "~/ImgUpload/ShopEnsureImg/2011061409442255_20100821181046611.jpg";
            }
            return "~/ImgUpload/ShopEnsureImg/2011061409442255_20100821181046611.jpg";
        }
    }
}