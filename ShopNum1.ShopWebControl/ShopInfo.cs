using System;
using System.Data;
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
    public class ShopInfo : BaseWebControl
    {
        private Repeater RepeaterShow;
        private string skinFilename = "ShopInfo.ascx";

        public ShopInfo()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public static string ShopID { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            RepeaterShow.ItemDataBound += RepeaterShow_ItemDataBound;
            if (!Page.IsPostBack)
            {
                BindData(ShopID);
            }
            try
            {
                method_1();
            }
            catch
            {
            }
        }

        protected void BindData(string string_2)
        {
            HttpCookie cookie = Page.Request.Cookies["IsExitCount"];
            if (cookie == null)
            {
                ((Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action()).UpdateClickCount(string_2);
                var cookie2 = new HttpCookie("IsExitCount")
                {
                    Expires = Convert.ToDateTime(DateTime.Now.AddDays(1.0).ToString("yyyy-MM-dd HH:mm:ss"))
                };
                Page.Response.AppendCookie(cookie2);
            }
        }

        protected void method_1()
        {
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            string memloginid = action.GetMemberLoginidByShopid(ShopID);
            DataTable shopInfo = action.GetShopInfo(memloginid);
            if (shopInfo.Rows.Count > 0)
            {
                RepeaterShow.DataSource = shopInfo.DefaultView;
                RepeaterShow.DataBind();
                var image = (Image) RepeaterShow.Items[0].FindControl("ImageIdentity");
                var image2 = (Image) RepeaterShow.Items[0].FindControl("ImageCompan");
                var row = (HtmlTableRow) RepeaterShow.Items[0].FindControl("TRIdentity");
                if (!string.IsNullOrEmpty(shopInfo.Rows[0]["BusinessLicense"].ToString()))
                {
                    image2.Visible = true;
                }
                else
                {
                    image2.Visible = false;
                }
                if (!string.IsNullOrEmpty(shopInfo.Rows[0]["CardImage"].ToString()))
                {
                    image.Visible = true;
                }
                else
                {
                    image.Visible = false;
                }
                if (string.IsNullOrEmpty(shopInfo.Rows[0]["CardImage"].ToString()) &&
                    string.IsNullOrEmpty(shopInfo.Rows[0]["BusinessLicense"].ToString()))
                {
                    row.Visible = false;
                }
            }
        }

        protected void RepeaterShow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                var label = (Label) e.Item.FindControl("LabelShopRank");
                var image = (Image) e.Item.FindControl("ImageReputation");
                var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
                string memberloginid = action.GetMemberLoginidByShopid(ShopID);
                DataTable shopRank = action.GetShopRank(memberloginid);
                if ((shopRank != null) && (shopRank.Rows.Count > 0))
                {
                    label.Text = shopRank.Rows[0]["Name"].ToString();
                    image.ImageUrl = shopRank.Rows[0]["Pic"].ToString();
                }
            }
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
                return "";
            }
            return "";
        }
    }
}