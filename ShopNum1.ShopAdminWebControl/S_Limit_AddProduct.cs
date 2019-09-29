using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_Limit_AddProduct : BaseShopWebControl
    {
        public static DataTable dt_LimitProduct = null;
        private readonly Shop_LimtProduct_Action shop_LimtProduct_Action_0 = new Shop_LimtProduct_Action();
        private Label lblDisCount;
        private Label lblEndTime;
        private Label lblLimitPcount;
        private Label lblName;
        private Label lblSelectProduct;
        private Label lblStartName;
        private Label lblState;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "S_Limit_AddProduct.ascx";

        public S_Limit_AddProduct()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int PageSize { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            lblName = (Label) skin.FindControl("lblName");
            lblStartName = (Label) skin.FindControl("lblStartName");
            lblEndTime = (Label) skin.FindControl("lblEndTime");
            lblState = (Label) skin.FindControl("lblState");
            lblDisCount = (Label) skin.FindControl("lblDisCount");
            lblLimitPcount = (Label) skin.FindControl("lblLimitPcount");
            lblSelectProduct = (Label) skin.FindControl("lblSelectProduct");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            if (!Page.IsPostBack)
            {
                BindData();
                method_2();
            }
        }

        protected void BindData()
        {
            if (Common.Common.ReqStr("lid") != "")
            {
                DataTable activityById =
                    ((ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action()).GetActivityById(
                        base.MemLoginID, Common.Common.ReqStr("lid"));
                if (activityById.Rows.Count > 0)
                {
                    lblName.Text = activityById.Rows[0]["name"].ToString();
                    lblStartName.Text = activityById.Rows[0]["s"].ToString();
                    lblEndTime.Text = activityById.Rows[0]["e"].ToString();
                    lblState.Text = method_1(activityById.Rows[0]["state"].ToString());
                    if (Convert.ToDateTime(lblEndTime.Text) < DateTime.Now)
                    {
                        lblState.Text = "已结束";
                    }
                    lblDisCount.Text = activityById.Rows[0]["discount"].ToString();
                    lblLimitPcount.Text = activityById.Rows[0]["limitProduct"].ToString();
                    lblSelectProduct.Text = activityById.Rows[0]["pc"].ToString();
                }
            }
        }

        private string method_1(string string_1)
        {
            string str = string_1;
            switch (str)
            {
                case null:
                    break;

                case "0":
                    return "未发布";

                default:
                    if (!(str == "1"))
                    {
                        if (str == "2")
                        {
                            return "已取消";
                        }
                    }
                    else
                    {
                        return "已发布";
                    }
                    break;
            }
            return "";
        }

        protected void method_2()
        {
            string condition = " and memloginid='" + base.MemLoginID +
                               "' and ProductState=0 And guid not in(select productguid from ShopNum1_Group_Product where state=1)";
            int num = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                num = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            int num3 =
                Convert.ToInt32(
                    shop_LimtProduct_Action_0.GetLimtProdcut(PageSize.ToString(), num.ToString(), condition, "3",
                        Common.Common.ReqStr("lid")).Rows[0][0]);
            var bll = new PageListBll("shop/ShopAdmin/S_Limit_AddProduct.aspx", true);
            var pl = new PageList1
            {
                PageSize = PageSize,
                PageID = num,
                RecordCount = num3
            };
            pageDiv.InnerHtml = bll.GetPageListNew(pl);
            dt_LimitProduct = shop_LimtProduct_Action_0.GetLimtProdcut(PageSize.ToString(), num.ToString(), condition,
                "2", Common.Common.ReqStr("lid"));
            if (dt_LimitProduct.Rows.Count == 0)
            {
                dt_LimitProduct = null;
            }
        }
    }
}