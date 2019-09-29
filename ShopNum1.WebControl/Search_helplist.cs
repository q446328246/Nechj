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
    public class Search_helplist : BaseWebControl
    {
        private readonly ShopNum1_Help_Action shopNum1_Help_Action_0 =
            ((ShopNum1_Help_Action) LogicFactory.CreateShopNum1_Help_Action());

        private readonly string string_1 = GetPageName.RetDomainUrl("HelpListSearch");

        private Button ButtonAgainSearch;
        private Button ButtonSure;
        private Label LabelName;
        private Label LabelNum;
        private Label LabelPageCount;
        private Repeater RepeaterData;
        private TextBox TextBoxIndex;
        private TextBox TextBoxSearch;
        private int int_0;
        private HtmlGenericControl pageDiv;

        private string skinFilename = "Search_helplist.ascx";
        private string string_3;
        private string string_4;
        private string string_5;

        public Search_helplist()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int ShowCount { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_1 + "?search=" + string_3 + "&sort=" + string_4 + "&ordername=" + string_5 +
                                   "&pageid=" + str);
        }

        protected void ButtonAgainSearch_Click(object sender, EventArgs e)
        {
            string_3 = (TextBoxSearch.Text.Trim().Replace("'", "") == string.Empty)
                ? "-1"
                : TextBoxSearch.Text.Trim().Replace("'", "");
            string url = GetPageName.AgentRetUrl("HelpListSearch", string_3, "search");
            Page.Response.Redirect(url);
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            LabelName = (Label) skin.FindControl("LabelName");
            LabelNum = (Label) skin.FindControl("LabelNum");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            ButtonAgainSearch = (Button) skin.FindControl("ButtonAgainSearch");
            ButtonAgainSearch.Click += ButtonAgainSearch_Click;
            TextBoxSearch = (TextBox) skin.FindControl("TextBoxSearch");
            string_3 = (Common.Common.ReqStr("search") == "") ? "" : Common.Common.ReqStr("search");
            string_5 = (Common.Common.ReqStr("ordername") == "") ? "CreateTime" : Common.Common.ReqStr("ordername");
            string_4 = (Common.Common.ReqStr("sort") == "") ? "desc" : Common.Common.ReqStr("sort");
            LabelName.Text = string_3;
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
                BindData();
            }
        }

        protected void BindData()
        {
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataSet set = shopNum1_Help_Action_0.Search(string_3, string_5, string_4, ShowCount.ToString(),
                int_0.ToString(), "1");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            LabelNum.Text = pl.RecordCount.ToString();
            var bll = new PageListBll("HelpListSearch", true)
            {
                ShowRecordCount = true,
                ShowPageCount = false,
                ShowPageIndex = false,
                //ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "上一页",
                NextPageText = "下一页"
            };
            TextBoxIndex.Text = int_0.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            DataSet set2 = shopNum1_Help_Action_0.Search(string_3, string_5, string_4, ShowCount.ToString(),
                int_0.ToString(), "0");
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                RepeaterData.DataSource = set2.Tables[0];
                RepeaterData.DataBind();
            }
        }
    }
}