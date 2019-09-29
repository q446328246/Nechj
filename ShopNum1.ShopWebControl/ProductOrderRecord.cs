using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ProductOrderRecord : BaseWebControl
    {
        private Label LabelPageMessage;
        private Repeater RepeaterShow;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "ProductOrderRecord.ascx";
        private HtmlGenericControl spanOrderCount;

        public ProductOrderRecord()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public int PageCount { get; set; }

        public string ProductGuid { get; set; }

        public static string ChangeOperateType(string operateType)
        {
            if (operateType == "0")
            {
                return "未付款";
            }
            if (operateType == "1")
            {
                return "已付款";
            }
            return "";
        }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            spanOrderCount = (HtmlGenericControl) skin.FindControl("spanOrderCount");
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            if (!Page.IsPostBack)
            {
            }
            ProductGuid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            BindData();
        }

        protected void BindData()
        {
            DataSet set =
                ((ShopNum1_OrderInfo_Action)Factory.LogicFactory.CreateShopNum1_OrderInfo_Action())
                    .SearchProductOrderRecord(ProductGuid, "-1", CookieCustomerCategory);
            if ((set != null) && (set.Tables.Count == 2))
            {
                spanOrderCount.InnerHtml = "共" + set.Tables[1].Rows[0]["allNum"] + "条订单记录";
                var source = new PagedDataSource
                {
                    DataSource = set.Tables[0].DefaultView,
                    AllowPaging = true,
                    PageSize = PageCount
                };
                int currentPage = -1;
                if (Page.Request.QueryString.Get("page") != null)
                {
                    currentPage = Convert.ToInt32(Page.Request.QueryString.Get("page"));
                }
                else
                {
                    currentPage = 1;
                }
                source.CurrentPageIndex = currentPage - 1;
                RepeaterShow.DataSource = source;
                RepeaterShow.DataBind();
                var common = new Num1WebControlCommon();
                LabelPageMessage.Text = common.GetPageMessage(source.DataSourceCount, source.PageCount, source.PageSize,
                    currentPage);
                lnkTo.Text = common.AppendPage(Page, source.PageCount, currentPage);
                ProductGuid = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
                lnkPrev.NavigateUrl =
                    GetPageName.GetPage(
                        string.Concat(new object[] { "?Page=", Convert.ToInt32((currentPage - 1)), "&guid=", ProductGuid }));
                lnkFirst.NavigateUrl = GetPageName.GetPage("?Page=1&guid=" + ProductGuid);
                lnkNext.NavigateUrl =
                    GetPageName.GetPage(
                        string.Concat(new object[] { "?Page=", Convert.ToInt32((currentPage + 1)), "&guid=", ProductGuid }));
                lnkLast.NavigateUrl =
                    GetPageName.GetPage(string.Concat(new object[] { "?Page=", source.PageCount, "&guid=", ProductGuid }));
                if ((currentPage <= 1) && (source.PageCount <= 1))
                {
                    lnkFirst.NavigateUrl = "";
                    lnkPrev.NavigateUrl = "";
                    lnkNext.NavigateUrl = "";
                    lnkLast.NavigateUrl = "";
                }
                if ((currentPage <= 1) && (source.PageCount > 1))
                {
                    lnkFirst.NavigateUrl = "";
                    lnkPrev.NavigateUrl = "";
                }
                if (currentPage >= source.PageCount)
                {
                    lnkNext.NavigateUrl = "";
                    lnkLast.NavigateUrl = "";
                }
            }
        }

        public static string SetNoNull(object value)
        {
            if (value.ToString() == "")
            {
                return "0";
            }
            return value.ToString();
        }
    }
}