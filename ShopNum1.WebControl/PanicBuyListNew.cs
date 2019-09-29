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
    public class PanicBuyListNew : BaseWebControl
    {
        private Label LabelCount;
        private Label LabelIndex;
        private Label LabelPageCount;
        private LinkButton LinkButtonLast;
        private LinkButton LinkButtonNext;
        private Repeater RepeaterData;
        private int int_0 = 1;
        private string skinFilename = "PanicBuyList.ascx";

        public PanicBuyListNew()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string CategoryCode { get; set; }

        protected string OtherPage { get; set; }

        public string PageCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            LinkButtonNext = (LinkButton) skin.FindControl("LinkButtonNext");
            LinkButtonNext.Click += LinkButtonNext_Click;
            LinkButtonLast = (LinkButton) skin.FindControl("LinkButtonLast");
            LinkButtonLast.Click += LinkButtonLast_Click;
            LabelCount = (Label) skin.FindControl("LabelCount");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            LabelIndex = (Label) skin.FindControl("LabelIndex");
            if (Page.Request.QueryString["pindex"] != null)
            {
                LabelIndex.Text = Page.Request.QueryString["pindex"];
                int_0 = Convert.ToInt32(Page.Request.QueryString["pindex"]);
            }
            else
            {
                LabelIndex.Text = "1";
                int_0 = 1;
            }
            PanicBuyDataBind(int_0);
        }

        protected void LinkButtonNext_Click(object sender, EventArgs e)
        {
            if (int.Parse(LabelIndex.Text) == (int.Parse(LabelPageCount.Text) - 1))
            {
                int num = int.Parse(LabelIndex.Text) + 1;
                LabelIndex.Text = num.ToString();
                int_0 = int.Parse(LabelIndex.Text);
                LinkButtonNext.Enabled = false;
                LinkButtonNext.CssClass = "page_down_false";
            }
            else if (LabelPageCount.Text == LabelIndex.Text)
            {
                LinkButtonLast.Enabled = false;
                LinkButtonNext.Enabled = true;
            }
            else
            {
                LinkButtonLast.Enabled = true;
                LinkButtonLast.CssClass = "page_up_true";
                LabelIndex.Text = (int.Parse(LabelIndex.Text) + 1).ToString();
                int_0++;
            }
            Page.Response.Redirect(
                string.Concat(new object[]
                {"http://", ShopSettings.siteDomain, "/Main/panicbuylist.aspx?tag=7&pindex=", int_0}));
        }

        protected void LinkButtonLast_Click(object sender, EventArgs e)
        {
            if (int_0 == 2)
            {
                LabelIndex.Text = "1";
                LinkButtonLast.Enabled = false;
                LinkButtonLast.CssClass = "page_up";
                int_0 = 1;
            }
            else
            {
                LinkButtonNext.Enabled = true;
                LinkButtonNext.CssClass = "page_down";
                LabelIndex.Text = (int_0 - 1).ToString();
                int_0--;
            }
            Page.Response.Redirect(
                string.Concat(new object[]
                {"http://", ShopSettings.siteDomain, "/Main/panicbuylist.aspx?tag=7&pindex=", int_0}));
        }

        protected void PanicBuyDataBind(int pindex)
        {
            try
            {
                int.Parse(PageCount);
            }
            catch
            {
                PageCount = "5";
            }
            var action = (ShopNum1_Common_Action) LogicFactory.CreateShopNum1_Common_Action();
            string searchname =
                " ProductState=1 and EndTime>getdate() and IsAudit=1 and IsSell=1 and starttime<=getdate() ";
            if (CategoryCode != "-1")
            {
                searchname = searchname + "  and productcategorycode like '" + CategoryCode + "%'";
            }
            LabelCount.Text =
                action.CommonGetPageCount(PageCount, "ShopNum1_Shop_Product", searchname).Tables[0].Rows[0][0].ToString();
            LabelPageCount.Text =
                action.CommonGetPageCount(PageCount, "ShopNum1_Shop_Product", searchname).Tables[1].Rows[0][0].ToString();
            DataTable table =
                ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action())
                    .GetPanceProductByCategoryCode(CategoryCode, PageCount, pindex.ToString());
            if ((table != null) & (table.Rows.Count > 0))
            {
                RepeaterData.DataSource = table.DefaultView;
                RepeaterData.DataBind();
            }
            if (LabelPageCount.Text == "0")
            {
                LinkButtonLast.Enabled = false;
                LinkButtonNext.Enabled = false;
                LinkButtonLast.CssClass = "page_up_false";
                LinkButtonNext.CssClass = "page_down_false";
                RepeaterData.DataSource = null;
                RepeaterData.DataBind();
            }
            else if (LabelPageCount.Text == "1")
            {
                LinkButtonLast.Enabled = false;
                LinkButtonNext.Enabled = false;
                LinkButtonLast.CssClass = "page_up_false";
                LinkButtonNext.CssClass = "page_down_false";
            }
            else if (int.Parse(LabelIndex.Text) == 1)
            {
                LinkButtonLast.Enabled = false;
                LinkButtonNext.Enabled = true;
                LinkButtonLast.CssClass = "page_up_false";
            }
            else if (int.Parse(LabelIndex.Text) == int.Parse(LabelPageCount.Text))
            {
                LinkButtonNext.Enabled = false;
                LinkButtonNext.CssClass = "page_down_false";
            }
            else
            {
                LinkButtonLast.CssClass = "page_up_true";
                LinkButtonNext.CssClass = "page_down_true";
                LinkButtonLast.Enabled = true;
                LinkButtonNext.Enabled = true;
            }
        }
    }
}