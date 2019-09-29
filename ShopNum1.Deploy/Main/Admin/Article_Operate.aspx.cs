using System;
using System.Collections.Generic;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Article_Operate : PageBase, IRequiresSessionState
    {
        protected string strLine = " --- ";
        protected string strSapce = "　　";

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                            ? "0"
                                            : base.Request.QueryString["guid"];
                ClearControl();
                GetOrderID();
                BindStatus();
                BindData();
                if (hiddenFieldGuid.Value != "0")
                {
                    GetEditInfo();
                }
            }
        }

        protected void Add()
        {
            var article = new ShopNum1_Article
                {
                    Guid = Guid.NewGuid(),
                    Title = TextBoxTitle.Text.Trim(),
                    ArticleCategoryID = Convert.ToInt32(DropDownListArticleCategory.SelectedValue),
                    Publisher = TextBoxPublisher.Text.Trim(),
                    Source = TextBoxSource.Text.Trim(),
                    Keywords = TextBoxKeyWord.Text.Trim(),
                    Description = TextBoxDescription.Text.Trim(),
                    IsShow = Convert.ToInt32(DropDownListIfShow.SelectedValue),
                    IsAllowComment = Convert.ToInt32(DropDownListIfAllowComment.SelectedValue),
                    OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim())
                };
            if (CheckBoxIsHot.Checked)
            {
                article.IsHot = 1;
            }
            else
            {
                article.IsHot = 0;
            }
            if (CheckBoxIsRecommend.Checked)
            {
                article.IsRecommend = 1;
            }
            else
            {
                article.IsRecommend = 0;
            }
            if (CheckBoxIsHead.Checked)
            {
                article.IsHead = 1;
            }
            else
            {
                article.IsHead = 0;
            }
            article.Content = base.Server.HtmlEncode(FCKeditorRemark.Text.Replace("'", "''"));
            article.CreateUser = base.ShopNum1LoginID;
            article.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            article.ModifyUser = base.ShopNum1LoginID;
            article.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            article.IsDeleted = 0;
            article.IsAudit = 1;
            article.ClickCount = 0;
            var strRelateArticleList = new List<string>();
            var box = (ListBox) ArticleRelateArticleSelect1.FindControl("ListBoxRightArticleArticle");
            foreach (ListItem item in box.Items)
            {
                strRelateArticleList.Add(item.Value);
            }
            var strRelateProductList = new List<string>();
            var action = (ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action();
            if (action.Add(article, strRelateArticleList, strRelateProductList) > 0)
            {
                ClearControl();
                GetOrderID();
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void BindStatus()
        {
            var item = new ListItem
                {
                    Text = " -请选择-",//LocalizationUtil.GetCommonMessage("Select"),
                    Value = "-1"
                };
            DropDownListIfShow.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = " -请选择-",//LocalizationUtil.GetCommonMessage("Select"),
                    Value = "-1"
                };
            DropDownListIfAllowComment.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = " -请选择-",//LocalizationUtil.GetCommonMessage("Select"),
                    Value = "-1"
                };
            DropDownListArticleCategory.Items.Add(item3);
            var item4 = new ListItem
                {
                    Text = "-否-",//LocalizationUtil.GetCommonMessage("No"),
                    Value = "0"
                };
            DropDownListIfShow.Items.Add(item4);
            var item5 = new ListItem
                {
                    Text = "-否-",//LocalizationUtil.GetCommonMessage("No"),
                    Value = "0"
                };
            DropDownListIfAllowComment.Items.Add(item5);
            var item6 = new ListItem
                {
                    Text = " -是-",//LocalizationUtil.GetCommonMessage("Yes"),
                    Value = "1"
                };
            DropDownListIfShow.Items.Add(item6);
            var item7 = new ListItem
                {
                    Text = " -是-",//LocalizationUtil.GetCommonMessage("Yes"),
                    Value = "1"
                };
            DropDownListIfAllowComment.Items.Add(item7);
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (ButtonConfirm.ToolTip == "Update")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "编辑资讯成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Article_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Edit();
            }
            else if (ButtonConfirm.ToolTip == "Submit")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "添加资讯成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Article_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxTitle.Text = string.Empty;
            DropDownListArticleCategory.SelectedIndex = -1;
            TextBoxPublisher.Text = string.Empty;
            TextBoxSource.Text = string.Empty;
            TextBoxKeyWord.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
            DropDownListIfShow.SelectedIndex = -1;
            DropDownListIfAllowComment.SelectedIndex = -1;
            TextBoxOrderID.Text = string.Empty;
            CheckBoxIsHot.Checked = false;
            CheckBoxIsRecommend.Checked = false;
            CheckBoxIsHead.Checked = false;
            FCKeditorRemark.Text = string.Empty;
        }

        protected void Edit()
        {
            var article = new ShopNum1_Article
                {
                    Guid = new Guid(hiddenFieldGuid.Value.Replace("'", "")),
                    Title = TextBoxTitle.Text.Trim(),
                    ArticleCategoryID = Convert.ToInt32(DropDownListArticleCategory.SelectedValue),
                    Publisher = TextBoxPublisher.Text.Trim(),
                    Source = TextBoxSource.Text.Trim(),
                    Keywords = TextBoxKeyWord.Text.Trim(),
                    Description = TextBoxDescription.Text.Trim(),
                    IsShow = Convert.ToInt32(DropDownListIfShow.SelectedValue),
                    IsAllowComment = Convert.ToInt32(DropDownListIfAllowComment.SelectedValue),
                    OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim())
                };
            if (CheckBoxIsHot.Checked)
            {
                article.IsHot = 1;
            }
            else
            {
                article.IsHot = 0;
            }
            if (CheckBoxIsRecommend.Checked)
            {
                article.IsRecommend = 1;
            }
            else
            {
                article.IsRecommend = 0;
            }
            if (CheckBoxIsHead.Checked)
            {
                article.IsHead = 1;
            }
            else
            {
                article.IsHead = 0;
            }
            article.Content = base.Server.HtmlEncode(FCKeditorRemark.Text.Replace("'", "''"));
            article.ModifyUser = base.ShopNum1LoginID;
            article.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            article.IsDeleted = 0;
            var strRelateArticleList = new List<string>();
            var box = (ListBox) ArticleRelateArticleSelect1.FindControl("ListBoxRightArticleArticle");
            foreach (ListItem item in box.Items)
            {
                strRelateArticleList.Add(item.Value);
            }
            var strRelateProductList = new List<string>();
            var action = (ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action();
            if (action.Update(article, strRelateArticleList, strRelateProductList) > 0)
            {
                base.Response.Redirect("Article_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            var action = (ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action();
            DataTable editInfo = action.GetEditInfo(hiddenFieldGuid.Value);
            TextBoxTitle.Text = editInfo.Rows[0]["Title"].ToString();
            DropDownListArticleCategory.SelectedValue = editInfo.Rows[0]["ArticleCategoryID"].ToString();
            TextBoxPublisher.Text = editInfo.Rows[0]["Publisher"].ToString();
            TextBoxSource.Text = editInfo.Rows[0]["Source"].ToString();
            TextBoxKeyWord.Text = editInfo.Rows[0]["Keywords"].ToString();
            TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
            DropDownListIfShow.SelectedValue = editInfo.Rows[0]["IsShow"].ToString();
            DropDownListIfAllowComment.SelectedValue = editInfo.Rows[0]["IsAllowComment"].ToString();
            TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
            if (Convert.ToInt32(editInfo.Rows[0]["IsHot"].ToString()) == 1)
            {
                CheckBoxIsHot.Checked = true;
            }
            else
            {
                CheckBoxIsHot.Checked = false;
            }
            if (Convert.ToInt32(editInfo.Rows[0]["IsRecommend"].ToString()) == 1)
            {
                CheckBoxIsRecommend.Checked = true;
            }
            else
            {
                CheckBoxIsRecommend.Checked = false;
            }
            if (Convert.ToInt32(editInfo.Rows[0]["IsHead"].ToString()) == 1)
            {
                CheckBoxIsHead.Checked = true;
            }
            else
            {
                CheckBoxIsHead.Checked = false;
            }
            FCKeditorRemark.Text = base.Server.HtmlDecode(editInfo.Rows[0]["Content"].ToString());
            DataTable relatedArticleInfo = action.GetRelatedArticleInfo(hiddenFieldGuid.Value);
            var box = (ListBox) ArticleRelateArticleSelect1.FindControl("ListBoxRightArticleArticle");
            var list1 = (DropDownList) ArticleRelateArticleSelect1.FindControl("DropDownListRelatedArticleIsBoth");
            for (int i = 0; i < relatedArticleInfo.Rows.Count; i++)
            {
                var item = new ListItem
                    {
                        Value = relatedArticleInfo.Rows[i]["SubArticleGuid"].ToString()
                    };
                item.Text =
                    ((ShopNum1_Article_Action) LogicFactory.CreateShopNum1_Article_Action()).GetNameByGuid(
                        relatedArticleInfo.Rows[i]["SubArticleGuid"].ToString());
                item.Value = relatedArticleInfo.Rows[i]["SubArticleGuid"] + ";" + relatedArticleInfo.Rows[i]["IsBoth"];
                box.Items.Add(item);
            }
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
        }

        protected void GetOrderID()
        {
            string columnName = "OrderID";
            string tableName = "ShopNum1_Article";
            TextBoxOrderID.Text = Convert.ToString((1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }

        private void BindData()
        {
            DropDownListArticleCategory.Items.Clear();
            var item = new ListItem
                {
                    Text = " -请选择-",//LocalizationUtil.GetCommonMessage("Select"),
                    Value = "0"
                };
            DropDownListArticleCategory.Items.Add(item);
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            foreach (DataRow row in action.Search(0, 0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["ID"].ToString().Trim()
                    };
                DropDownListArticleCategory.Items.Add(item2);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (table.Rows.Count > 0)
                {
                    method_6(table);
                }
            }
        }

        private void method_6(DataTable dt)
        {
            var action = (ShopNum1_ArticleCategory_Action) LogicFactory.CreateShopNum1_ArticleCategory_Action();
            foreach (DataRow row in dt.Rows)
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
                DropDownListArticleCategory.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (table.Rows.Count > 0)
                {
                    method_6(table);
                }
            }
        }
    }
}