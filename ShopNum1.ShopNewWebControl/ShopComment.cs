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
    public class ShopComment : BaseWebControl
    {
        private readonly string string_1 = GetPageName.AgentGetPage("");
        private HtmlGenericControl All;
        private HtmlGenericControl Bad;
        private Button ButtonSure;
        private HtmlGenericControl General;
        private HtmlGenericControl Good;
        private Label LabelPageCount;
        private LinkButton LinkButton;
        private LinkButton LinkButtonBad;
        private LinkButton LinkButtonGeneral;
        private LinkButton LinkButtonGood;
        private Repeater RepeaterShow;

        private TextBox TextBoxIndex;
        private int int_0;

        private Label label_0;
        private LinkButton linkButtonSure;
        private HtmlGenericControl pageDiv;
        private string skinFilename = "ShopCommentNew.ascx";

        public ShopComment()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        private string MemLoginID { get; set; }

        public string ordername { get; set; }

        private string ShopID { get; set; }

        public int ShowCount { get; set; }

        public string soft { get; set; }

        protected void ButtonSure_Click(object sender, EventArgs e)
        {
            string str = TextBoxIndex.Text.Trim();
            Page.Response.Redirect(string_1 + "?sort=" + soft + "&ordername=" + ordername + "&pageid=" + str);
        }

        protected override void InitializeSkin(Control skin)
        {
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
                ? "a.CommentTime"
                : Page.Request.QueryString["ordername"];
            soft = (Page.Request.QueryString["sort"] == null) ? "desc" : Page.Request.QueryString["sort"];
            linkButtonSure = (LinkButton) skin.FindControl("LinkButtonAll");
            linkButtonSure.Click += linkButtonSure_Click;
            LinkButtonGood = (LinkButton) skin.FindControl("LinkButtonGood");
            LinkButtonGood.Click += LinkButtonGood_Click;
            LinkButtonGeneral = (LinkButton) skin.FindControl("LinkButtonGeneral");
            LinkButtonGeneral.Click += LinkButtonGeneral_Click;
            LinkButtonBad = (LinkButton) skin.FindControl("LinkButtonBad");
            LinkButtonBad.Click += LinkButtonBad_Click;
            LinkButton = (LinkButton) skin.FindControl("LinkButton");
            LinkButton.Click += LinkButton_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            All = (HtmlGenericControl) skin.FindControl("All");
            Good = (HtmlGenericControl) skin.FindControl("Good");
            General = (HtmlGenericControl) skin.FindControl("General");
            Bad = (HtmlGenericControl) skin.FindControl("Bad");
            method_1(string.Empty);
        }

        protected void linkButtonSure_Click(object sender, EventArgs e)
        {
            method_1(string.Empty);
            method_0(All);
        }

        protected void LinkButtonGood_Click(object sender, EventArgs e)
        {
            method_1("5");
            method_0(Good);
        }

        protected void LinkButtonGeneral_Click(object sender, EventArgs e)
        {
            method_1("3");
            method_0(General);
        }

        protected void LinkButtonBad_Click(object sender, EventArgs e)
        {
            method_1("1");
            method_0(Bad);
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            method_1("0");
        }

        protected void method_0(HtmlGenericControl htmlGenericControl_5)
        {
            All.Style.Remove("background");
            Good.Style.Remove("background");
            General.Style.Remove("background");
            Bad.Style.Remove("background");
            htmlGenericControl_5.Style.Add("background", "#fff");
        }

        protected void method_1(string string_6)
        {
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action2 = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            action2.GetMemberLoginidByShopid(shopid);
            var action = (Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action();
            var pl = new PageList1
            {
                PageSize = ShowCount,
                PageID = int_0
            };
            DataSet set2 = action.ShopCommentNew(shopid, string_6, ordername, soft, ShowCount.ToString(),
                int_0.ToString(), "1");
            if ((set2 != null) && (set2.Tables[0].Rows.Count > 0))
            {
                pl.RecordCount = Convert.ToInt32(set2.Tables[0].Rows[0][0]);
            }
            else
            {
                pl.RecordCount = 0;
            }
            var bll = new PageListBll("ShopComment", true)
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
            DataSet set = action.ShopCommentNew(shopid, string_6, ordername, soft, ShowCount.ToString(),
                int_0.ToString(), "0");
            RepeaterShow.DataSource = set.Tables[0];
            RepeaterShow.DataBind();
            for (int i = 0; i < RepeaterShow.Items.Count; i++)
            {
                label_0 = (Label) RepeaterShow.Items[i].FindControl("LabelCommentType");
                string str = set.Tables[0].Rows[i]["CommentType"].ToString();
                if (str != null)
                {
                    if (str != "5")
                    {
                        if (!(str == "3"))
                        {
                            if (str == "1")
                            {
                                label_0.Text = "差评";
                            }
                        }
                        else
                        {
                            label_0.Text = "中评";
                        }
                    }
                    else
                    {
                        label_0.Text = "好评";
                    }
                }
            }
        }
    }
}