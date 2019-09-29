using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.MultiBaseWebControl;
using ShopNum1MultiEntity;

namespace ShopNum1.WebControl
{
    [ParseChildren(true)]
    public class TopSearch : BaseWebControl
    {
        private Button ButtonSearch;
        private HiddenField HiddenSwitchType;
        private string skinFilename = "TopSearch.ascx";

        public TopSearch()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Check(Page.Request.Form["textfield"].Trim().Replace("/", ""), Convert.ToInt32(HiddenSwitchType.Value));
        }

        protected void Check(string name, int type)
        {
            DataTable table =
                ((ShopNum1_KeyWords_Action) LogicFactory.CreateShopNum1_KeyWords_Action()).CheckIsExist(name, type);
            if (table.Rows.Count > 0)
            {
                if (type == 1)
                {
                    method_1(name, 1, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(
                        GetPageName.RetUrl("ProductListSearch", Operator.FilterString(name), "search") + "&pv=1");
                }
                else if (type == 2)
                {
                    method_1(name, 2, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(GetPageName.RetUrl("ShopListSearch", Operator.FilterString(name), "search") +
                                           "&pv=2");
                }
                else if (type == 3)
                {
                    method_1(name, 3, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(
                        GetPageName.RetUrl("ArticleListSearch", Operator.FilterString(name), "search") + "&pv=3");
                }
                else if (type == 4)
                {
                    method_1(name, 4, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(
                        GetPageName.RetUrl("CategoryListSearch", Operator.FilterString(name), "search") + "&pv=4");
                }
                else if (type == 5)
                {
                    method_1(name, 5, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(
                        GetPageName.RetUrl("SupplyDemandListSearch", Operator.FilterString(name), "search") + "&pv=5");
                }
            }
            else if (type == 1)
            {
                method_0(name, 1);
                Page.Response.Redirect(GetPageName.RetUrl("ProductListSearch", Operator.FilterString(name), "search") +
                                       "&pv=1");
            }
            else if (type == 2)
            {
                method_0(name, 2);
                Page.Response.Redirect(GetPageName.RetUrl("ShopListSearch", Operator.FilterString(name), "search") +
                                       "&pv=2");
            }
            else if (type == 3)
            {
                method_0(name, 3);
                Page.Response.Redirect(GetPageName.RetUrl("ArticleListSearch", Operator.FilterString(name), "search") +
                                       "&pv=3");
            }
            else if (type == 4)
            {
                method_0(name, 4);
                Page.Response.Redirect(GetPageName.RetUrl("CategoryListSearch", Operator.FilterString(name), "search") +
                                       "&pv=4");
            }
            else if (type == 5)
            {
                method_0(name, 5);
                Page.Response.Redirect(
                    GetPageName.RetUrl("SupplyDemandListSearch", Operator.FilterString(name), "search") + "&pv=5");
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            HiddenSwitchType = (HiddenField) skin.FindControl("HiddenSwitchType");
            ButtonSearch = (Button) skin.FindControl("ButtonSearch");
            ButtonSearch.Click += ButtonSearch_Click;
        }

        protected void method_0(string string_1, int int_0)
        {
            var words = new ShopNum1_KeyWords
            {
                Guid = Guid.NewGuid(),
                Name = string_1,
                Type = int_0,
                IfShow = 0,
                Count = 1,
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                CreateUser = string.Empty,
                ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                ModifyUser = string.Empty,
                IsDeleted = 0
            };
            ((ShopNum1_KeyWords_Action) LogicFactory.CreateShopNum1_KeyWords_Action()).Add(words);
        }

        protected void method_1(string string_1, int int_0, int int_1)
        {
            ((ShopNum1_KeyWords_Action) LogicFactory.CreateShopNum1_KeyWords_Action()).UpdateCount(string_1, int_0,
                int_1);
        }
    }
}