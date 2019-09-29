using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopComment : BaseWebControl
    {
        private HtmlGenericControl All;
        private HtmlGenericControl Bad;
        private HtmlGenericControl General;
        private HtmlGenericControl Good;
        private Label LabelPageMessage;
        private LinkButton LinkButtonAll;
        private LinkButton LinkButtonBad;
        private LinkButton LinkButtonGeneral;
        private LinkButton LinkButtonGood;
        private Repeater RepeaterShow;
        private HyperLink lnkFirst;
        private HyperLink lnkLast;
        private HyperLink lnkNext;
        private HyperLink lnkPrev;
        private Literal lnkTo;
        private string skinFilename = "ShopComment.ascx";

        public ShopComment()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LinkButtonAll = (LinkButton) skin.FindControl("LinkButtonAll");
            LinkButtonAll.Click += LinkButtonAll_Click;
            LinkButtonGood = (LinkButton) skin.FindControl("LinkButtonGood");
            LinkButtonGood.Click += LinkButtonGood_Click;
            LinkButtonGeneral = (LinkButton) skin.FindControl("LinkButtonGeneral");
            LinkButtonGeneral.Click += LinkButtonGeneral_Click;
            LinkButtonBad = (LinkButton) skin.FindControl("LinkButtonBad");
            LinkButtonBad.Click += LinkButtonBad_Click;
            RepeaterShow = (Repeater) skin.FindControl("RepeaterShow");
            All = (HtmlGenericControl) skin.FindControl("All");
            Good = (HtmlGenericControl) skin.FindControl("Good");
            General = (HtmlGenericControl) skin.FindControl("General");
            Bad = (HtmlGenericControl) skin.FindControl("Bad");
            lnkPrev = (HyperLink) skin.FindControl("lnkPrev");
            lnkFirst = (HyperLink) skin.FindControl("lnkFirst");
            lnkNext = (HyperLink) skin.FindControl("lnkNext");
            lnkLast = (HyperLink) skin.FindControl("lnkLast");
            LabelPageMessage = (Label) skin.FindControl("LabelPageMessage");
            lnkTo = (Literal) skin.FindControl("lnkTo");
            method_1(string.Empty);
        }

        protected void LinkButtonAll_Click(object sender, EventArgs e)
        {
            method_1(string.Empty);
            BindData(All);
        }

        protected void LinkButtonGood_Click(object sender, EventArgs e)
        {
            method_1("0");
            BindData(Good);
        }

        protected void LinkButtonGeneral_Click(object sender, EventArgs e)
        {
            method_1("1");
            BindData(General);
        }

        protected void LinkButtonBad_Click(object sender, EventArgs e)
        {
            method_1("2");
            BindData(Bad);
        }

        protected void BindData(HtmlGenericControl htmlGenericControl_4)
        {
            All.Style.Remove("background");
            Good.Style.Remove("background");
            General.Style.Remove("background");
            Bad.Style.Remove("background");
            htmlGenericControl_4.Style.Add("background", "#fff");
        }

        protected void method_1(string string_1)
        {
            string s = ShopSettings.GetValue("ProductCommentPageCount");
            try
            {
                int.Parse(s);
            }
            catch
            {
                s = "10";
            }
            string shopid = (Page.Request.QueryString["ShopID"] == null) ? "0" : Page.Request.QueryString["ShopID"];
            var action = (Shop_ShopInfo_Action) LogicFactory.CreateShop_ShopInfo_Action();
            action.GetMemberLoginidByShopid(shopid);
            DataTable table =
                ((Shop_ProductComment_Action) LogicFactory.CreateShop_ProductComment_Action()).ShopComment(string_1,
                    shopid);
            if ((table == null) || (table.Rows.Count == 0))
            {
                RepeaterShow.DataSource = null;
                RepeaterShow.DataBind();
            }
            else
            {
                var source = new PagedDataSource
                {
                    DataSource = table.DefaultView,
                    AllowPaging = true
                };
                if (int.Parse(s) < 1)
                {
                    source.PageSize = 10;
                }
                else
                {
                    source.PageSize = int.Parse(s);
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
                if (string_1 == "")
                {
                    source.CurrentPageIndex = 1;
                }
                var common = new Num1WebControlCommon();
                LabelPageMessage.Text = common.GetPageMessage(source.DataSourceCount, source.PageCount, source.PageSize,
                    currentPage);
                lnkTo.Text = common.AppendPage(Page, source.PageCount, currentPage);
                lnkPrev.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32((currentPage - 1));
                lnkFirst.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=1";
                lnkNext.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" +
                                      Convert.ToInt32((currentPage + 1));
                lnkLast.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" + source.PageCount;
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
                RepeaterShow.DataSource = source;
                RepeaterShow.DataBind();
                for (int i = 0; i < RepeaterShow.Items.Count; i++)
                {
                    var label = (Label) RepeaterShow.Items[i].FindControl("LabelCommentType");
                    string str2 = table.Rows[i]["CommentType"].ToString();
                    if (str2 != null)
                    {
                        if (str2 != "5")
                        {
                            if (!(str2 == "3"))
                            {
                                if (str2 == "1")
                                {
                                    label.Text = "差评";
                                }
                            }
                            else
                            {
                                label.Text = "中评";
                            }
                        }
                        else
                        {
                            label.Text = "好评";
                        }
                    }
                }
            }
        }
    }
}