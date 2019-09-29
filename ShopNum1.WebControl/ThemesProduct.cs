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
    public class ThemesProduct : BaseWebControl
    {
        private readonly string string_1 = GetPageName.RetDomainUrl("ThemesProduct");
        private Button ButtonSure;
        private HtmlInputHidden HiddenEndDate;
        private Image ImageTheme;

        private Label LabelPageCount;
        private Repeater RepeaterData;
        private TextBox TextBoxIndex;
        private int int_0;
        public string memberid;
        private HtmlGenericControl pageDiv;

        private ShopNum1_ProuductChecked_Action shopNum1_ProuductChecked_Action_0 =
            ((ShopNum1_ProuductChecked_Action) LogicFactory.CreateShopNum1_ProuductChecked_Action());

        private string skinFilename = "ThemesProduct.ascx";
        public string themeguid;

        public ThemesProduct()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCount { get; set; }

        protected void BindData()
        {
            string condition = string.Empty;
            if (themeguid != "-1")
            {
                condition = " and B.IsAudit=1 and ThemeGuid='" + themeguid + "'";
            }
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            var action = (ShopNum1_Activity_Action) LogicFactory.CreateShopNum1_Activity_Action();
            DataTable table2 = action.SelectThemeProductByGuid(ShowCount.ToString(), int_0.ToString(), condition, "0");
            if ((table2 != null) && (table2.Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(table2.Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("ThemesProduct", true)
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
            TextBoxIndex.Text = int_0.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            DataTable table = action.SelectThemeProductByGuid(ShowCount.ToString(), int_0.ToString(), condition, "1");
            if ((table != null) && (table.Rows.Count > 0))
            {
                ImageTheme.ImageUrl = table.Rows[0]["ThemeImage"].ToString();
                HiddenEndDate.Value = table.Rows[0]["EndDate"].ToString();
                RepeaterData.DataSource = table;
                RepeaterData.DataBind();
            }
        }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string text = TextBoxIndex.Text.Trim();
            if (Convert.ToInt32(TextBoxIndex.Text.Trim()) > Convert.ToInt32(LabelPageCount.Text))
            {
                TextBoxIndex.Text = LabelPageCount.Text;
                text = LabelPageCount.Text;
            }
            Page.Response.Redirect(string_1 + "?ThemeGuid=" + themeguid + "&pageid=" + text);
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            ImageTheme = (Image) skin.FindControl("ImageTheme");
            HiddenEndDate = (HtmlInputHidden) skin.FindControl("HiddenEndDate");
            themeguid = (Common.Common.ReqStr("themeguid") == "") ? "-1" : Common.Common.ReqStr("themeguid");
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Common.Common.ReqStr("PageID"));
            }
            catch
            {
                int_0 = 1;
            }
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }
    }
}