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
    public class Search : BaseWebControl
    {
        private DropDownList DropDownListType;
        private ImageButton ImageButtonSearch;
        private TextBox TextBoxKeywords;
        private string skinFilename = "Search.ascx";

        public Search()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void Check(string name, int type)
        {
            DataTable table =
                ((ShopNum1_KeyWords_Action) LogicFactory.CreateShopNum1_KeyWords_Action()).CheckIsExist(name, type);
            if (table.Rows.Count > 0)
            {
                if (DropDownListType.SelectedValue == "0")
                {
                    method_1(TextBoxKeywords.Text, 0, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(
                        GetPageName.RetUrl("ProductListSearch", Operator.FilterString(TextBoxKeywords.Text.Trim()),
                            "search") +
                        "&pv=0");
                }
                else if (DropDownListType.SelectedValue == "1")
                {
                    method_1(TextBoxKeywords.Text, 1, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(
                        GetPageName.RetUrl("ShopList", Operator.FilterString(TextBoxKeywords.Text.Trim()), "search") +
                        "&pv=1");
                }
                else if (DropDownListType.SelectedValue == "2")
                {
                    method_1(TextBoxKeywords.Text, 2, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(
                        GetPageName.RetUrl("ArticleListSearch", Operator.FilterString(TextBoxKeywords.Text.Trim()),
                            "title") +
                        "&pv=2");
                }
                else if (DropDownListType.SelectedValue == "3")
                {
                    method_1(TextBoxKeywords.Text, 3, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(
                        GetPageName.RetUrl("Default", Operator.FilterString(TextBoxKeywords.Text.Trim()), "") + "&pv=3");
                }
                else if (DropDownListType.SelectedValue == "4")
                {
                    method_1(TextBoxKeywords.Text, 4, Convert.ToInt32(table.Rows[0]["Count"].ToString()) + 1);
                    Page.Response.Redirect(
                        GetPageName.RetUrl("SupplyDemandListSearch", Operator.FilterString(TextBoxKeywords.Text.Trim()),
                            "search") + "&pv=4");
                }
            }
            else if (DropDownListType.SelectedValue == "0")
            {
                method_0(TextBoxKeywords.Text, 0);
                Page.Response.Redirect(
                    GetPageName.RetUrl("ProductListSearch", Operator.FilterString(TextBoxKeywords.Text.Trim()), "search") +
                    "&pv=0");
            }
            else if (DropDownListType.SelectedValue == "1")
            {
                method_0(TextBoxKeywords.Text, 1);
                Page.Response.Redirect(
                    GetPageName.RetUrl("ShopList", Operator.FilterString(TextBoxKeywords.Text.Trim()), "search") +
                    "&pv=1");
            }
            else if (DropDownListType.SelectedValue == "2")
            {
                method_0(TextBoxKeywords.Text, 2);
                Page.Response.Redirect(
                    GetPageName.RetUrl("ArticleListSearch", Operator.FilterString(TextBoxKeywords.Text.Trim()), "title") +
                    "&pv=2");
            }
            else if (DropDownListType.SelectedValue == "3")
            {
                method_0(TextBoxKeywords.Text, 3);
                Page.Response.Redirect(
                    GetPageName.RetUrl("Default", Operator.FilterString(TextBoxKeywords.Text.Trim()), "") +
                    "&pv=3");
            }
            else if (DropDownListType.SelectedValue == "4")
            {
                method_0(TextBoxKeywords.Text, 4);
                Page.Response.Redirect(
                    GetPageName.RetUrl("SupplyDemandListSearch", Operator.FilterString(TextBoxKeywords.Text.Trim()),
                        "search") +
                    "&pv=4");
            }
        }

        protected void ImageButtonSearch_Click(object sender, ImageClickEventArgs e)
        {
            Check(TextBoxKeywords.Text, Convert.ToInt32(DropDownListType.SelectedValue));
        }

        protected override void InitializeSkin(Control skin)
        {
            ImageButtonSearch = (ImageButton) skin.FindControl("ImageButtonSearch");
            DropDownListType = (DropDownList) skin.FindControl("DropDownListType");
            TextBoxKeywords = (TextBox) skin.FindControl("TextBoxKeywords");
            ImageButtonSearch.Click += ImageButtonSearch_Click;
            if (!Page.IsPostBack && (Common.Common.ReqStr("pv") != ""))
            {
                DropDownListType.SelectedValue = Common.Common.ReqStr("pv");
            }
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