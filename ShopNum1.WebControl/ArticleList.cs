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
    public class ArticleList : BaseWebControl
    {
        private Repeater RepeaterArticleList;
        private string skinFilename = "ArticleList.ascx";

        public ArticleList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterArticleList = (Repeater) skin.FindControl("RepeaterArticleList");
            if (!Page.IsPostBack)
            {
            }
            string str = (Page.Request.QueryString["ID"] == null) ? "0" : Page.Request.QueryString["ID"];
            if (str != "0")
            {
                BindData(str);
            }
            else
            {
                BindData("-1");
            }
        }

        protected void BindData(string string_1)
        {
            var action = (ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action();
            string str = ShopSettings.GetValue("ArticleListCount");
            DataTable table = action.SearchArticleList("0", Convert.ToInt32(string_1), Convert.ToInt32(str));
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterArticleList.DataSource = table.DefaultView;
                RepeaterArticleList.DataBind();
            }
        }
    }
}