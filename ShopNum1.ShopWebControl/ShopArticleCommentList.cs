using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.ShopWebControl
{
    [ParseChildren(true)]
    public class ShopArticleCommentList : BaseWebControl
    {
        private HyperLink hyperLink_0;
        private HyperLink hyperLink_1;
        private HyperLink hyperLink_2;
        private HyperLink hyperLink_3;
        private Label label_0;
        private Literal literal_0;
        private Repeater repeater_0;
        private string string_0 = "ShopArticleCommentList.ascx";


        public ShopArticleCommentList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = string_0;
            }
        }

        private string Guid { get; set; }
        public string PageCount { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            repeater_0 = (Repeater) skin.FindControl("RepeaterData");
            Guid = ((Page.Request.QueryString["Guid"] == null) ? "" : Page.Request.QueryString["Guid"]);
            if (!Page.IsPostBack)
            {
            }
            hyperLink_0 = (HyperLink) skin.FindControl("lnkPrev");
            hyperLink_1 = (HyperLink) skin.FindControl("lnkFirst");
            hyperLink_2 = (HyperLink) skin.FindControl("lnkNext");
            hyperLink_3 = (HyperLink) skin.FindControl("lnkLast");
            label_0 = (Label) skin.FindControl("LabelPageMessage");
            literal_0 = (Literal) skin.FindControl("lnkTo");
            method_0();
        }

        public static string GetValue(object object_0)
        {
            string text = object_0.ToString();
            string result;
            switch (text)
            {
                case "0":
                    result = "一般";
                    return result;
                case "1":
                    result = "一星";
                    return result;
                case "2":
                    result = "二星";
                    return result;
                case "3":
                    result = "三星";
                    return result;
                case "4":
                    result = "四星";
                    return result;
                case "5":
                    result = "五星";
                    return result;
            }
            result = "一般";
            return result;
        }

        protected void method_0()
        {
            var shopNum1_ShopArticleComment_Action =
                (ShopNum1_ShopArticleComment_Action) LogicFactory.CreateShopNum1_ShopArticleComment_Action();
            DataTable shopArticleCommentByGuid = shopNum1_ShopArticleComment_Action.GetShopArticleCommentByGuid(Guid);
            var pagedDataSource = new PagedDataSource();
            pagedDataSource.DataSource = shopArticleCommentByGuid.DefaultView;
            pagedDataSource.AllowPaging = true;
            try
            {
                if (int.Parse(PageCount) < 1)
                {
                    pagedDataSource.PageSize = 10;
                }
                else
                {
                    pagedDataSource.PageSize = int.Parse(PageCount);
                }
            }
            catch
            {
                pagedDataSource.PageSize = 10;
            }
            int num;
            if (Page.Request.QueryString.Get("page") != null)
            {
                num = Convert.ToInt32(Page.Request.QueryString.Get("page"));
            }
            else
            {
                num = 1;
            }
            pagedDataSource.CurrentPageIndex = num - 1;
            var num1WebControlCommon = new Num1WebControlCommon();
            label_0.Text = num1WebControlCommon.GetPageMessage(pagedDataSource.DataSourceCount,
                pagedDataSource.PageCount, pagedDataSource.PageSize, num);
            literal_0.Text = num1WebControlCommon.AppendPage(Page, pagedDataSource.PageCount, num);
            hyperLink_0.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(num - 1);
            hyperLink_1.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=1";
            hyperLink_2.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" + Convert.ToInt32(num + 1);
            hyperLink_3.NavigateUrl = Page.Request.CurrentExecutionFilePath + "?Page=" + pagedDataSource.PageCount;
            if (num <= 1 && pagedDataSource.PageCount <= 1)
            {
                hyperLink_1.NavigateUrl = "";
                hyperLink_0.NavigateUrl = "";
                hyperLink_2.NavigateUrl = "";
                hyperLink_3.NavigateUrl = "";
            }
            if (num <= 1 && pagedDataSource.PageCount > 1)
            {
                hyperLink_1.NavigateUrl = "";
                hyperLink_0.NavigateUrl = "";
            }
            if (num >= pagedDataSource.PageCount)
            {
                hyperLink_2.NavigateUrl = "";
                hyperLink_3.NavigateUrl = "";
            }
            repeater_0.DataSource = pagedDataSource;
            repeater_0.DataBind();
        }
    }
}