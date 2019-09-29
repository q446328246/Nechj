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
    public class ProductConsultList : BaseWebControl
    {
        private Label LabelPageMessage;
        private Repeater RepeaterProductConsultList;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "ProductConsultList.ascx";
        private string string_1 = string.Empty;

        public ProductConsultList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected string ShopID { get; set; }

        public string ShowCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            ShopID = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            RepeaterProductConsultList = (Repeater) skin.FindControl("RepeaterProductConsultList");
            string_1 = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            BindData();
            if (!Page.IsPostBack)
            {
            }
        }

        protected void BindData()
        {
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            string shopID = action.GetMemberLoginidByShopid(ShopID);
            DataTable table =
                ((Shop_ProductConsult_Action) LogicFactory.CreateShop_ProductConsult_Action()).Search(string_1, 0, 1,
                    shopID,CookieCustomerCategory);
            var source = new PagedDataSource
            {
                DataSource = table.DefaultView,
                AllowPaging = true,
                PageSize = Convert.ToInt32(ShowCount)
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
            int num2 = -1;
            if (Page.Request.QueryString.Get("page1") != null)
            {
                num2 = Convert.ToInt32(Page.Request.QueryString.Get("page1"));
            }
            else
            {
                num2 = 1;
            }
            source.CurrentPageIndex = currentPage - 1;
            var common = new Num1WebControlCommon();
            LabelPageMessage.Text = common.GetPageMessage(source.DataSourceCount, source.PageCount, source.PageSize,
                currentPage);
            lnkTo.Text = common.AppendPage(Page, source.PageCount, currentPage,
                string.Concat(new object[]
                {"&&Guid=", Page.Request.QueryString["Guid"], "&&Page1=", num2}));
            lnkPrev.NavigateUrl =
                GetPageName.AgentGetPage(
                    string.Concat(new object[]
                    {
                        "?Page=", Convert.ToInt32((currentPage - 1)), "&&Guid=", Page.Request.QueryString["Guid"],
                        "&&Page1=", num2
                    }));
            lnkFirst.NavigateUrl =
                GetPageName.AgentGetPage(
                    string.Concat(new object[] {"?Page=1&&Guid=", Page.Request.QueryString["Guid"], "&&Page1=", num2}));
            lnkNext.NavigateUrl =
                GetPageName.AgentGetPage(
                    string.Concat(new object[]
                    {
                        "?Page=", Convert.ToInt32((currentPage + 1)), "&&Guid=", Page.Request.QueryString["Guid"],
                        "&&Page1=", num2
                    }));
            lnkLast.NavigateUrl =
                GetPageName.AgentGetPage(
                    string.Concat(new object[]
                    {"?Page=", source.PageCount, "&&Guid=", Page.Request.QueryString["Guid"], "&&Page1=", num2}));
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
            RepeaterProductConsultList.DataSource = source;
            RepeaterProductConsultList.DataBind();
        }
    }
}