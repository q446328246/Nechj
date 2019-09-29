using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopNewWebControl
{
    [ParseChildren(true)]
    public class NewsList : BaseWebControl
    {
        private readonly string string_1 = GetPageName.AgentGetPage("");
        private Button ButtonSure;
        private HiddenField HiddenFieldGuid;

        private Label LabelPageCount;
        private Panel PanelNoFind;
        private TextBox TextBoxIndex;
        private int int_0;
        private HtmlGenericControl pageDiv;
        private Repeater repeater_0;
        private string skinFilename = "NewsListNew.ascx";

        public NewsList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string MemLoginID { get; set; }

        public string ordername { get; set; }

        public int ShowCount { get; set; }

        public string soft { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_1 + "?pageid=" + str);
        }

        protected override void InitializeSkin(Control skin)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            HiddenFieldGuid = (HiddenField) skin.FindControl("HiddenFieldGuid");
            HiddenFieldGuid.Value = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            PanelNoFind = (Panel) skin.FindControl("PanelNoFind");
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Page.Request.QueryString["PageID"]);
            }
            catch
            {
                int_0 = 1;
            }
            ordername = (Page.Request.QueryString["ordername"] == null)
                ? "a.guid"
                : Page.Request.QueryString["ordername"];
            soft = (Page.Request.QueryString["sort"] == null) ? "desc" : Page.Request.QueryString["sort"];
            repeater_0 = (Repeater) skin.FindControl("RepeaterShow");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        public static string IsShow(object object_0)
        {
            switch (object_0.ToString())
            {
                case "0":
                    return "否";

                case "1":
                    return "是";
            }
            return "";
        }

        protected void BindData()
        {
            var action = (Shop_News_Action) LogicFactory.CreateShop_News_Action();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataSet set = action.SearchNewsListNew(MemLoginID, HiddenFieldGuid.Value, ordername, soft,
                ShowCount.ToString(), int_0.ToString(), "1");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("NewsListBestNew", true)
            {
                ShowPageCount = false,
                ShowPageIndex = false,
                ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "上一页",
                NextPageText = "下一页 "
            };
            TextBoxIndex.Text = int_0.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            DataSet set2 = action.SearchNewsListNew(MemLoginID, HiddenFieldGuid.Value, ordername, soft,
                ShowCount.ToString(), int_0.ToString(), "0");
            if ((set2.Tables[0] == null) || (set2.Tables[0].Rows.Count == 0))
            {
                PanelNoFind.Visible = true;
            }
            else
            {
                repeater_0.DataSource = set2.Tables[0];
                repeater_0.DataBind();
            }
        }
    }
}