using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class DeArticleCategoryDetail : BaseWebControl
    {
        private Repeater RepeaterData1;
        private Repeater RepeaterData2;
        private Repeater RepeaterData3;
        private string skinFilename = "DeArticleCategoryDetail.ascx";

        public DeArticleCategoryDetail()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public int CategoryID { get; set; }

        public string ShowCount { get; set; }

        protected void BindData1()
        {
            DataTable table =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).GetTitleByID(
                    ViewState["IDAll"].ToString(), "IsHead", ShowCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData1.DataSource = table.DefaultView;
                RepeaterData1.DataBind();
            }
        }

        protected void BindData2()
        {
            DataTable table =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).GetTitleByID(
                    ViewState["IDAll"].ToString(), "IsHot", ShowCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData2.DataSource = table.DefaultView;
                RepeaterData2.DataBind();
            }
        }

        protected void BindData3()
        {
            DataTable table =
                ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).GetTitleByID(
                    ViewState["IDAll"].ToString(), "IsRecommend", ShowCount);
            if ((table != null) && (table.Rows.Count > 0))
            {
                RepeaterData3.DataSource = table.DefaultView;
                RepeaterData3.DataBind();
            }
        }

        protected string GetAll(int CategoryID)
        {
            var builder = new StringBuilder();
            builder.Append("(" + CategoryID);
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            DataView defaultView = action.SearchID(CategoryID).DefaultView;
            if ((defaultView != null) && (defaultView.Count > 0))
            {
                foreach (DataRow row in defaultView.Table.Rows)
                {
                    int num = Convert.ToInt32(row["ID"].ToString().Trim());
                    builder.Append("," + num);
                    DataView view2 = action.SearchID(num).DefaultView;
                    if ((view2 != null) && (view2.Count > 0))
                    {
                        foreach (DataRow row2 in view2.Table.Rows)
                        {
                            builder.Append("," + Convert.ToInt32(row2["ID"].ToString().Trim()));
                        }
                    }
                }
            }
            builder.Append(")");
            return builder.ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            RepeaterData1 = (Repeater) skin.FindControl("RepeaterData1");
            RepeaterData2 = (Repeater) skin.FindControl("RepeaterData2");
            RepeaterData3 = (Repeater) skin.FindControl("RepeaterData3");
            ViewState["IDAll"] = GetAll(CategoryID);
            BindData1();
            BindData2();
            BindData3();
        }
    }
}