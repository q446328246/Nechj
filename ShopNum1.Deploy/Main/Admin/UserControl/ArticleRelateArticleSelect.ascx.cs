using System;
using System.Data;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin.UserControl
{
    public partial class ArticleRelateArticleSelect : System.Web.UI.UserControl
    {
        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindArticleCategory();
                DropDownListRelatedArticleIsBothStatus();
            }
        }

        protected void AddSubAriticleCategory(DataTable dataTable)
        {
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            foreach (DataRow row in dataTable.Rows)
            {
                var item = new ListItem();
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + strSapce;
                }
                str = str + row["Name"].ToString().Trim();
                item.Text = str;
                item.Value = row["ID"].ToString().Trim();
                DropDownListSArticleCategory.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 1);
                if (table.Rows.Count > 0)
                {
                    AddSubAriticleCategory(table);
                }
            }
        }

        protected void BindArticleCategory()
        {
            var item = new ListItem
                {
                    Text = "-全部-",
                    Value = "-1"
                };
            DropDownListSArticleCategory.Items.Add(item);
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            foreach (DataRow row in action.Search(0, 0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["ID"].ToString().Trim()
                    };
                DropDownListSArticleCategory.Items.Add(item2);
                DataTable dataTable = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 1);
                if (dataTable.Rows.Count > 0)
                {
                    AddSubAriticleCategory(dataTable);
                }
            }
        }

        protected void BindListBoxLeftArticleArticle()
        {
            ListBoxLeftArticleArticle.Items.Clear();
            string title = TextBoxSArticleTitle.Text.Trim();
            int articleCategoryID = Convert.ToInt32(DropDownListSArticleCategory.SelectedValue);
            var action = (ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action();
            foreach (DataRow row in action.Search(title, articleCategoryID).DefaultView.Table.Rows)
            {
                var item = new ListItem
                    {
                        Text = row["Title"].ToString().Trim(),
                        Value = row["Guid"].ToString().Trim()
                    };
                ListBoxLeftArticleArticle.Items.Add(item);
            }
        }

        protected void ButtonAddArticle_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in ListBoxLeftArticleArticle.Items)
            {
                if (item.Selected && method_0(item.Value))
                {
                    if (DropDownListRelatedArticleIsBoth.SelectedValue == "1")
                    {
                        item.Value = item.Value + ";1";
                    }
                    else
                    {
                        item.Value = item.Value + ";0";
                    }
                    ListBoxRightArticleArticle.Items.Add(item);
                }
            }
        }

        protected void ButtonArticleAddAll_Click(object sender, EventArgs e)
        {
            ListBoxRightArticleArticle.Items.Clear();
            foreach (ListItem item in ListBoxLeftArticleArticle.Items)
            {
                if (method_0(item.Value))
                {
                    if (DropDownListRelatedArticleIsBoth.SelectedValue == "1")
                    {
                        item.Value = item.Value + ";1";
                    }
                    else
                    {
                        item.Value = item.Value + ";0";
                    }
                    ListBoxRightArticleArticle.Items.Add(item);
                }
            }
        }

        protected void ButtonArticleDeleteAll_Click(object sender, EventArgs e)
        {
            ListBoxRightArticleArticle.Items.Clear();
        }

        protected void ButtonDeleteArticle_Click(object sender, EventArgs e)
        {
            if (ListBoxRightArticleArticle.Items.Count != -1)
            {
                for (int i = ListBoxRightArticleArticle.Items.Count - 1; i >= 0; i--)
                {
                    if (ListBoxRightArticleArticle.Items[i].Selected)
                    {
                        ListBoxRightArticleArticle.Items.Remove(ListBoxRightArticleArticle.Items[i]);
                    }
                }
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindListBoxLeftArticleArticle();
        }

        protected void DropDownListRelatedArticleIsBothStatus()
        {
            var item = new ListItem
                {
                    Text = "单项关联",
                    Value = "0"
                };
            DropDownListRelatedArticleIsBoth.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "双向关联",
                    Value = "1"
                };
            DropDownListRelatedArticleIsBoth.Items.Add(item2);
        }

        private bool method_0(string string_0)
        {
            string[] strArray = string_0.Split(new[] {';'});
            for (int i = 0; i < ListBoxRightArticleArticle.Items.Count; i++)
            {
                if (ListBoxRightArticleArticle.Items[i].Value.Trim().Split(new[] {';'})[0] == strArray[0])
                {
                    return false;
                }
            }
            return true;
        }
    }
}