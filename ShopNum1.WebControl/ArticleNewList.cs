using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.Common;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class ArticleNewList : BaseWebControl
    {
        private Repeater DataListAriticleNew;
        private Literal LiteralTitle;
        private string skinFilename = "ArticleNewList.ascx";

        public ArticleNewList()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShowCount { get; set; }

        public string Title { get; set; }

        protected override void InitializeSkin(Control skin)
        {
            DataListAriticleNew = (Repeater) skin.FindControl("DataListAriticleNew");
            LiteralTitle = (Literal) skin.FindControl("LiteralTitle");
            if (!Page.IsPostBack)
            {
            }
            BindData();
        }

        protected void BindData()
        {
            LiteralTitle.Text = Title;
             ShowCount = ShopSettings.GetValue("DefaultAnnouncementNewCount");
            DataTable table =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).SearchNewArticle(
                    Convert.ToInt32(ShowCount));
            if ((table != null) && (table.Rows.Count > 0))
            {
                DataListAriticleNew.DataSource = table.DefaultView;
                DataListAriticleNew.DataBind();
            }
        }
    }
}