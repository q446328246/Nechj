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
    public class BrandShowOrder : BaseWebControl
    {
        private DropDownList DropDownListSort1;
        private DropDownList DropDownListSort2;
        private ImageButton ImageButtonGrid;
        private ImageButton ImageButtonList;
        private ImageButton ImageButtontext;
        private Label LabelBrandName;
        private Label LabelPageMessage;
        private Repeater Repeater1;
        private Repeater Repeater2;
        private Repeater Repeater3;
        private HyperLink hyperLink_3;
        private HyperLink lnkFirst;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "BrandShowOrder.ascx";

        public BrandShowOrder()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string BrandGuid { get; set; }

        public string PageShowCount { get; set; }

        protected void DropDownListSort1_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_0(ViewState["ShowStyle"].ToString());
        }

        protected void DropDownListSort2_SelectedIndexChanged(object sender, EventArgs e)
        {
            method_0(ViewState["ShowStyle"].ToString());
        }

        protected void ImageButtonList_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["ShowStyle"] = "List";
            method_0("List");
        }

        protected void ImageButtonGrid_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["ShowStyle"] = "Grid";
            method_0("Grid");
        }

        protected void ImageButtontext_Click(object sender, ImageClickEventArgs e)
        {
            ViewState["ShowStyle"] = "Text";
            method_0("Text");
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelBrandName = (Label) skin.FindControl("LabelBrandName");
            Repeater1 = (Repeater) skin.FindControl("Repeater1");
            Repeater2 = (Repeater) skin.FindControl("Repeater2");
            Repeater3 = (Repeater) skin.FindControl("Repeater3");
            ImageButtonList = (ImageButton) skin.FindControl("ImageButtonList");
            ImageButtonGrid = (ImageButton) skin.FindControl("ImageButtonGrid");
            ImageButtontext = (ImageButton) skin.FindControl("ImageButtontext");
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            hyperLink_3 = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            ImageButtonGrid.Click += ImageButtonGrid_Click;
            ImageButtonList.Click += ImageButtonList_Click;
            ImageButtontext.Click += ImageButtontext_Click;
            DropDownListSort1 = (DropDownList) skin.FindControl("DropDownListSort1");
            DropDownListSort1.SelectedIndexChanged += DropDownListSort1_SelectedIndexChanged;
            DropDownListSort2 = (DropDownList) skin.FindControl("DropDownListSort2");
            DropDownListSort2.SelectedIndexChanged += DropDownListSort2_SelectedIndexChanged;
            if (Common.Common.ReqStr("guid") != null)
            {
                BrandGuid = Common.Common.ReqStr("guid");
            }
            else
            {
                BrandGuid = "-1";
            }
            if (ViewState["ShowStyle"] == null)
            {
                ViewState["ShowStyle"] = "Grid";
            }
            method_0(ViewState["ShowStyle"].ToString());
        }

        protected void method_0(string string_3)
        {
            DataTable table =
                ((ShopNum1_Brand_Action) LogicFactory.CreateShopNum1_Brand_Action()).SearchProductByBrandGuid(
                    BrandGuid, DropDownListSort1.SelectedValue, DropDownListSort2.SelectedValue);
            if (table.Rows.Count > 0)
            {
                LabelBrandName.Text = table.Rows[0]["BrandName"].ToString();
            }
            var source = new PagedDataSource
            {
                DataSource = table.DefaultView,
                AllowPaging = true
            };
            if (Operator.FormatToEmpty(PageShowCount) == string.Empty)
            {
                source.PageSize = 8;
            }
            else
            {
                source.PageSize = Convert.ToInt32(PageShowCount);
            }
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
            string otherParam = "&&BrandGuid=" + BrandGuid + "&&ShowStyle=" + string_3;
            lnkTo.Text = common.AppendPage(Page, source.PageCount, currentPage, otherParam);
            lnkPrev.NavigateUrl =
                GetPageName.GetPage(
                    string.Concat(new object[]
                    {
                        "?Page=", Convert.ToInt32((currentPage - 1)), "&&BrandGuid=", BrandGuid, "&&ShowStyle=",
                        string_3
                    }));
            lnkFirst.NavigateUrl = GetPageName.GetPage("?Page=1&&BrandGuid=" + BrandGuid + "&&ShowStyle=" + string_3);
            lnkNext.NavigateUrl =
                GetPageName.GetPage(
                    string.Concat(new object[]
                    {
                        "?Page=", Convert.ToInt32((currentPage + 1)), "&&BrandGuid=", BrandGuid, "&&ShowStyle=",
                        string_3
                    }));
            hyperLink_3.NavigateUrl =
                GetPageName.GetPage(
                    string.Concat(new object[]
                    {"?Page=", source.PageCount, "&&BrandGuid=", BrandGuid, "&&ShowStyle=", string_3}));
            if ((currentPage <= 1) && (source.PageCount <= 1))
            {
                lnkFirst.NavigateUrl = "";
                lnkPrev.NavigateUrl = "";
                lnkNext.NavigateUrl = "";
                hyperLink_3.NavigateUrl = "";
            }
            if ((currentPage <= 1) && (source.PageCount > 1))
            {
                lnkFirst.NavigateUrl = "";
                lnkPrev.NavigateUrl = "";
            }
            if (currentPage >= source.PageCount)
            {
                lnkNext.NavigateUrl = "";
                hyperLink_3.NavigateUrl = "";
            }
            if (string_3.ToLower() == "Grid".ToLower())
            {
                Repeater1.Visible = true;
                Repeater2.Visible = false;
                Repeater3.Visible = false;
                Repeater1.DataSource = source;
                Repeater1.DataBind();
            }
            else if (string_3.ToLower() == "List".ToLower())
            {
                Repeater2.Visible = true;
                Repeater1.Visible = false;
                Repeater3.Visible = false;
                Repeater2.DataSource = source;
                Repeater2.DataBind();
            }
            else if (string_3.ToLower() == "Text".ToLower())
            {
                Repeater2.Visible = false;
                Repeater1.Visible = false;
                Repeater3.Visible = true;
                Repeater3.DataSource = source;
                Repeater3.DataBind();
            }
        }
    }
}