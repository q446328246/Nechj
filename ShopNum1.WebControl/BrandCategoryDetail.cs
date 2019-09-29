using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class BrandCategoryDetail : BaseWebControl
    {
        private Label LabelCategory;
        private Label LabelPageMessage;
        private Repeater RepeaterBrand;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "BrandCategoryDetail.ascx";

        public BrandCategoryDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string code { get; set; }

        public string PageCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LabelCategory = (Label) skin.FindControl("LabelCategory");
            RepeaterBrand = (Repeater) skin.FindControl("RepeaterBrand");
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            if (!Page.IsPostBack)
            {
            }
            code = (Common.Common.ReqStr("code") == null) ? "-1" : Common.Common.ReqStr("code");
            BindData();
        }

        protected void BindData()
        {
            DataTable productCategoryCode =
                ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action())
                    .GetProductCategoryCode(code);
            if (productCategoryCode.Rows.Count == 1)
            {
                LabelCategory.Text = productCategoryCode.Rows[0]["Name"].ToString();
            }
            else if (productCategoryCode.Rows.Count > 1)
            {
                LabelCategory.Text = "全部";
            }
            else
            {
                LabelCategory.Text = "";
            }
            DataTable productBrand =
                ((ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action()).GetProductBrand(code);
            if ((productBrand.Rows.Count >= 0) && (productBrand != null))
            {
                var source = new PagedDataSource
                {
                    DataSource = productBrand.DefaultView,
                    AllowPaging = true,
                    PageSize = Convert.ToInt32(PageCount)
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
                var common = new Num1WebControlCommon();
                LabelPageMessage.Text = common.GetPageMessage(source.DataSourceCount, source.PageCount, source.PageSize,
                    currentPage);
                lnkTo.Text = common.AppendPage2(Page, source.PageCount, currentPage, "&code=" + code);
                lnkPrev.NavigateUrl =
                    GetPageName.GetPage(
                        string.Concat(new object[] {"?Page=", Convert.ToInt32((currentPage - 1)), "&code=", code}));
                lnkFirst.NavigateUrl = GetPageName.GetPage("?Page=1&code=" + code);
                lnkNext.NavigateUrl =
                    GetPageName.GetPage(
                        string.Concat(new object[] {"?Page=", Convert.ToInt32((currentPage + 1)), "&code=", code}));
                lnkLast.NavigateUrl =
                    GetPageName.GetPage(string.Concat(new object[] {"?Page=", source.PageCount, "&code=", code}));
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
                RepeaterBrand.DataSource = source;
                RepeaterBrand.DataBind();
            }
        }
    }
}