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
    public class VideoList : BaseWebControl
    {
        private readonly string string_2 = GetPageName.AgentGetPage("");
        private Button ButtonSearch;
        private Button ButtonSure;

        private Label LabelPageCount;
        private Panel PanelNoFind;
        private Repeater RepeaterShow;
        private TextBox TextBoxIndex;
        private TextBox TextBoxTitle;
        private int int_0;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "VideoListNew.ascx";
        private string string_1;

        public VideoList()
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

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_2 + "?sort=" + soft + "&ordername=" + ordername + "&pageid=" + str);
        }

        protected override void InitializeSkin(Control skin)
        {
            PanelNoFind = (Panel) skin.FindControl("PanelNoFind");
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
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
                ? "A.CreateTime"
                : Page.Request.QueryString["ordername"];
            soft = (Page.Request.QueryString["sort"] == null) ? "desc" : Page.Request.QueryString["sort"];
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            MemLoginID = action.GetMemberLoginidByShopid(shopid);
            string_1 = (Page.Request.QueryString["guid"] == null) ? "-1" : Page.Request.QueryString["guid"];
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
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
            var action = (Shop_Video_Action) LogicFactory.CreateShop_Video_Action();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataSet set = action.SearchVideoListNew(MemLoginID, ordername, soft, ShowCount.ToString(), int_0.ToString(),
                "1");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("VideoList", true)
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
            if (pl.PageCount < ((pl.RecordCount)/((double) pl.PageSize)))
            {
                pl.PageCount++;
            }
            if (int_0 > pl.PageCount)
            {
                int_0 = pl.PageCount;
            }
            DataSet set2 = action.SearchVideoListNew(MemLoginID, ordername, soft, ShowCount.ToString(), int_0.ToString(),
                "0");
            if ((set2.Tables[0] == null) || (set2.Tables[0].Rows.Count == 0))
            {
                PanelNoFind.Visible = true;
            }
            else
            {
                RepeaterShow.DataSource = set2.Tables[0];
                RepeaterShow.DataBind();
            }
        }
    }
}