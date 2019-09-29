using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class SpellBuyList : BaseWebControl
    {
        public static int int_0 = 0;

        private Label LabelPageCount;
        private Label LabelPageCount1;
        private LinkButton LinkButtonDefault;
        private LinkButton LinkButtonNew;
        private LinkButton LinkButtonPrice;
        private LinkButton LinkButtonSales;
        private Repeater RepeaterCategory;
        private Repeater RepeaterData;
        private HtmlGenericControl SpanNew;
        private HtmlGenericControl SpanPrice;
        private HtmlGenericControl SpanSales;
        private HtmlGenericControl pageDiv;
        private HtmlGenericControl pageDiv2;
        private string skinFilename = "SpellBuyList.ascx";

        public SpellBuyList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private string CategoryCode { get; set; }

        public string ShowCategoryCount { get; set; }

        public int ShowCount { get; set; }

        private string Sort { get; set; }

        private string SortType { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            LabelPageCount1 = (Label) skin.FindControl("LabelPageCount1");
            CategoryCode = (Common.Common.ReqStr("Guid") == "") ? "-1" : Common.Common.ReqStr("Guid");
            Sort = (Page.Request.QueryString["sort"] == null) ? "id" : Page.Request.QueryString["sort"];
            SortType = (Page.Request.QueryString["sorttype"] == null) ? "desc" : Page.Request.QueryString["sorttype"];
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            RepeaterCategory = (Repeater) skin.FindControl("RepeaterCategory");
            LinkButtonDefault = (LinkButton) skin.FindControl("LinkButtonDefault");
            LinkButtonDefault.Click += LinkButtonDefault_Click;
            LinkButtonNew = (LinkButton) skin.FindControl("LinkButtonNew");
            LinkButtonNew.Click += LinkButtonNew_Click;
            LinkButtonSales = (LinkButton) skin.FindControl("LinkButtonSales");
            LinkButtonSales.Click += LinkButtonSales_Click;
            LinkButtonPrice = (LinkButton) skin.FindControl("LinkButtonPrice");
            LinkButtonPrice.Click += LinkButtonPrice_Click;
            SpanNew = (HtmlGenericControl) skin.FindControl("SpanNew");
            SpanSales = (HtmlGenericControl) skin.FindControl("SpanSales");
            SpanPrice = (HtmlGenericControl) skin.FindControl("SpanPrice");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            pageDiv2 = (HtmlGenericControl) skin.FindControl("pageDiv2");
            if (Sort == "groupprice")
            {
                LinkButtonPrice.CssClass = "hover";
                LinkButtonSales.CssClass = "";
                LinkButtonDefault.CssClass = "";
                LinkButtonNew.CssClass = "";
                if (Common.Common.ReqStr("sorttype") == "desc")
                {
                    SpanPrice.Attributes.Add("class", "new");
                }
                else
                {
                    SpanPrice.Attributes.Add("class", "price");
                }
            }
            if (Sort == "groupcount")
            {
                LinkButtonPrice.CssClass = "";
                LinkButtonSales.CssClass = "hover";
                LinkButtonDefault.CssClass = "";
                LinkButtonNew.CssClass = "";
                if (Common.Common.ReqStr("sorttype") == "desc")
                {
                    SpanSales.Attributes.Add("class", "price");
                }
                else
                {
                    SpanSales.Attributes.Add("class", "new");
                }
            }
            if (Sort == "createtime")
            {
                LinkButtonPrice.CssClass = "";
                LinkButtonSales.CssClass = "";
                LinkButtonDefault.CssClass = "";
                LinkButtonNew.CssClass = "hover";
                if (Common.Common.ReqStr("sorttype") == "desc")
                {
                    SpanNew.Attributes.Add("class", "price");
                }
                else
                {
                    SpanNew.Attributes.Add("class", "new");
                }
            }
            if (((Sort == "id") || (Sort == string.Empty)) || (Sort == null))
            {
                LinkButtonPrice.CssClass = "";
                LinkButtonSales.CssClass = "";
                LinkButtonDefault.CssClass = "hover";
                LinkButtonNew.CssClass = "";
            }
            SpellBuyCategoryDataBind();
            SpellBuyDataBind(Sort, SortType);
        }

        public static string IsBegin(object begin, object object_0)
        {
            if (DateTime.Parse(begin.ToString()) > DateTime.Now.ToLocalTime())
            {
                return begin.ToString();
            }
            return object_0.ToString();
        }

        protected void LinkButtonDefault_Click(object sender, EventArgs e)
        {
            Sort = "id";
            string str = GetPageName.RetDomainUrl("SpellBuyList");
            Page.Response.Redirect(str + "?Guid=" + CategoryCode + "&sort=" + Sort + "&sorttype=" + SortType);
        }

        protected void LinkButtonNew_Click(object sender, EventArgs e)
        {
            Sort = "createtime";
            SortType = (Page.Request.QueryString["sorttype"] == null) ? "" : Page.Request.QueryString["sorttype"];
            if ((SortType == "asc") || (SortType == ""))
            {
                SortType = "desc";
            }
            else
            {
                SortType = "asc";
            }
            string str = GetPageName.RetDomainUrl("SpellBuyList");
            Page.Response.Redirect(str + "?Guid=" + CategoryCode + "&sort=" + Sort + "&sorttype=" + SortType);
        }

        protected void LinkButtonSales_Click(object sender, EventArgs e)
        {
            Sort = "groupcount";
            SortType = (Page.Request.QueryString["sorttype"] == null) ? "" : Page.Request.QueryString["sorttype"];
            if ((SortType == "asc") || (SortType == ""))
            {
                SortType = "desc";
            }
            else
            {
                SortType = "asc";
            }
            string str = GetPageName.RetDomainUrl("SpellBuyList");
            Page.Response.Redirect(str + "?Guid=" + CategoryCode + "&sort=" + Sort + "&sorttype=" + SortType);
        }

        protected void LinkButtonPrice_Click(object sender, EventArgs e)
        {
            Sort = "groupprice";
            SortType = (Page.Request.QueryString["sorttype"] == null) ? "" : Page.Request.QueryString["sorttype"];
            if ((SortType == "desc") || (SortType == ""))
            {
                SortType = "asc";
            }
            else
            {
                SortType = "desc";
            }
            string str = GetPageName.RetDomainUrl("SpellBuyList");
            Page.Response.Redirect(str + "?Guid=" + CategoryCode + "&sort=" + Sort + "&sorttype=" + SortType);
        }

        protected void SpellBuyCategoryDataBind()
        {
            try
            {
                int.Parse(ShowCategoryCount);
            }
            catch
            {
                ShowCategoryCount = "8";
            }
            DataTable productCategory =
                ((ShopNum1_ProductCategory_Action) LogicFactory.CreateShopNum1_ProductCategory_Action())
                    .GetProductCategory("0", ShowCategoryCount);
            if ((productCategory != null) && (productCategory.Rows.Count > 0))
            {
                RepeaterCategory.DataSource = productCategory.DefaultView;
                RepeaterCategory.DataBind();
            }
        }

        protected void SpellBuyDataBind(string strSortColumn, string strSortV)
        {
            var action = (ShopNum1_GroupProduct_Action) LogicFactory.CreateShopNum1_GroupProduct_Action();
            int pageCount = 1;
            if (Common.Common.ReqStr("pageid") != "")
            {
                pageCount = Convert.ToInt32(Common.Common.ReqStr("pageid"));
            }
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = pageCount
            };
            string condition = "  and State=1 ";
            if ((CategoryCode != "-1") && (CategoryCode != ""))
            {
                condition = condition + " and productcategorycode like '" + CategoryCode + "%'";
            }
            DataTable table = action.SelectGroupList(ShowCount.ToString(), pageCount.ToString(), condition, "3",
                strSortColumn, strSortV);
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("SpellBuyList", true)
            {
                ShowRecordCount = true,
                ShowPageCount = false,
                ShowPageIndex = false,
                //ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "上一页",
                NextPageText = "下一页 "
            };
            if (pl.RecordCount < pl.PageSize)
            {
                LabelPageCount.Text = LabelPageCount1.Text = "1";
            }
            else
            {
                int num2 = pl.RecordCount/pl.PageSize;
                LabelPageCount.Text = LabelPageCount1.Text = num2.ToString();
            }
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
                LabelPageCount.Text = pl.PageCount.ToString();
            }
            if (pageCount > pl.PageCount)
            {
                pageCount = pl.PageCount;
            }
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            pageDiv2.InnerHtml = bll.GetPageListVk(pl);
            if (LabelPageCount.Text == "1")
            {
                pageDiv.Visible = false;
                pageDiv2.Visible = false;
            }
            DataTable table2 = action.SelectGroupList(ShowCount.ToString(), pageCount.ToString(), condition, "2",
                strSortColumn, strSortV);
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                RepeaterData.DataSource = table2.DefaultView;
                RepeaterData.DataBind();
            }
        }
    }
}