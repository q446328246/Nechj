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
    public class VideoCommentList : BaseWebControl
    {
        private readonly string string_1 = GetPageName.RetDomainUrl("VideoDetail");
        private Button ButtonSure;
        private Label LabelPageCount;
        private Repeater RepeaterData;
        private TextBox TextBoxIndex;
        private int int_0;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "VideoCommentList.ascx";

        public VideoCommentList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string Guid { get; set; }

        public int ShowCount { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_1 + "?Guid=" + Guid + "&pageid=" + str);
        }

        protected override void InitializeSkin(Control skin)
        {
            pageDiv = (HtmlGenericControl) skin.FindControl("pageDiv");
            LabelPageCount = (Label) skin.FindControl("LabelPageCount");
            TextBoxIndex = (TextBox) skin.FindControl("TextBoxIndex");
            ButtonSure = (Button) skin.FindControl("ButtonSure");
            ButtonSure.Click += ButtonSure_Click;
            RepeaterData = (Repeater) skin.FindControl("RepeaterData");
            Guid = (Page.Request.QueryString["Guid"] == null)
                ? ""
                : Page.Request.QueryString["Guid"];
            int_0 = 1;
            try
            {
                int_0 = int.Parse(Page.Request.QueryString["PageID"]);
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

        protected void BindData()
        {
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            var action = (ShopNum1_VideoComment_Action) LogicFactory.CreateShopNum1_VideoComment_Action();
            DataSet set = action.GetPageVideoComment(Guid, ShowCount.ToString(), int_0.ToString(), "1");
            if ((set != null) && (set.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("videodetail", true)
            {
                ShowRecordCount = true,
                ShowPageCount = false,
                ShowPageIndex = false,
                //ShowRecordCount = false,
                ShowNoRecordInfo = false,
                ShowNumListButton = true,
                PrevPageText = "<上一页",
                NextPageText = "下一页>"
            };
            TextBoxIndex.Text = int_0.ToString();
            pageDiv.InnerHtml = bll.GetPageListVk(pl);
            LabelPageCount.Text = pl.PageCount.ToString();
            DataSet set2 = action.GetPageVideoComment(Guid, ShowCount.ToString(), int_0.ToString(), "0");
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                RepeaterData.DataSource = set2.Tables[0];
                RepeaterData.DataBind();
            }
        }
    }
}