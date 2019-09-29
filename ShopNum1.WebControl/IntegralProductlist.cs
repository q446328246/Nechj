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
    public class IntegralProductlist : BaseWebControl
    {
        private Button ButtonSure;
        private Label LabelPageCount;
        private Repeater RepeaterProductShow;

        private TextBox TextBoxIndex;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "IntegralProductlist.ascx";

        public IntegralProductlist()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string pageID { get; set; }

        public string ShowCount { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxIndex.Text))
            {
                Page.Response.Redirect("integral.aspx?tag=" + Page.Request.QueryString["tag"] + "&pageid=" +
                                       TextBoxIndex.Text.Trim());
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            RepeaterProductShow = (Repeater) skin.FindControl("RepeaterProductShow");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            BindData();
        }

        protected void BindData()
        {
            int pageCount = 1;
            if (
                !((Page.Request.QueryString["PageID"] == null) ||
                  string.IsNullOrEmpty(Page.Request.QueryString["PageID"])))
            {
                pageCount = Convert.ToInt32(Page.Request.QueryString["PageID"]);
            }
            else
            {
                pageCount = 1;
            }
            var action = (ShopNum1_Shop_ScoreProduct_Action) LogicFactory.CreateShopNum1_Shop_ScoreProduct_Action();
            var pl = new PageList1
            {
                PageSize = Convert.ToInt32(ShowCount),
                PageID = pageCount
            };
            DataTable table =
                action.SearchScoreProductList("OrderID", "DESC", ShowCount, pageCount.ToString(), "1").Tables[0];
            if ((table != null) && (table.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table.Rows[0][0].ToString());
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("Integral", true)
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
            TextBoxIndex.Text = pageCount.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (pageCount > pl.PageCount)
            {
                pageCount = pl.PageCount;
            }
            DataTable table2 =
                action.SearchScoreProductList("modifytime", "DESC", ShowCount, pageCount.ToString(), "0").Tables[0];
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                RepeaterProductShow.DataSource = table2.DefaultView;
                RepeaterProductShow.DataBind();
            }
        }
    }
}