using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopNewsEdit : BaseShopWebControl
    {
        private readonly Shop_News_Action shop_News_Action_0 =
            ((Shop_News_Action) LogicFactory.CreateShop_News_Action());

        private Button ButtonBackList;
        private Button ButtonSubmit;
        private CheckBox CheckBoxIsShow;
        private DropDownList DropDownListNewsCategory;
        private HiddenField HiddenFieldGuid;
        private Label LabelTitle;
        private TextBox TextBoxDescription;
        private TextBox TextBoxKeywords;
        private TextBox TextBoxSEOTitle;

        private TextBox TextBoxTitle;
        private TextBox TexteditorContent;
        private string skinFilename = "S_ShopNewsEdit.ascx";

        public S_ShopNewsEdit()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["guid"] != null)
            {
                BindData();
            }
            else
            {
                method_1();
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ShopNews.aspx");
        }

        public void GetDataInfo()
        {
            DataTable newsByGuidAndMemLoginID =
                shop_News_Action_0.GetNewsByGuidAndMemLoginID(Page.Request.QueryString["guid"], base.MemLoginID);
            if ((newsByGuidAndMemLoginID != null) && (newsByGuidAndMemLoginID.Rows.Count > 0))
            {
                TextBoxTitle.Text = newsByGuidAndMemLoginID.Rows[0]["Title"].ToString();
                DropDownListNewsCategory.SelectedValue = newsByGuidAndMemLoginID.Rows[0]["NewsCategoryGuid"].ToString();
                TexteditorContent.Text = newsByGuidAndMemLoginID.Rows[0]["Content"].ToString();
                if (newsByGuidAndMemLoginID.Rows[0]["IsShow"].ToString() == "1")
                {
                    CheckBoxIsShow.Checked = true;
                }
                else
                {
                    CheckBoxIsShow.Checked = false;
                }
                TextBoxSEOTitle.Text = newsByGuidAndMemLoginID.Rows[0]["SEOTitle"].ToString();
                TextBoxKeywords.Text = newsByGuidAndMemLoginID.Rows[0]["Keywords"].ToString();
                TextBoxDescription.Text = newsByGuidAndMemLoginID.Rows[0]["Description"].ToString();
            }
        }

        public void GetShopNewsCategory()
        {
            DataTable newsCategoryList =
                ((Shop_NewsCategory_Action) LogicFactory.CreateShop_NewsCategory_Action()).GetNewsCategoryList(
                    base.MemLoginID, "1");
            DropDownListNewsCategory.Items.Clear();
            DropDownListNewsCategory.Items.Add(new ListItem("-全部-", "-1"));
            if ((newsCategoryList != null) && (newsCategoryList.Rows.Count > 0))
            {
                foreach (DataRow row in newsCategoryList.Rows)
                {
                    DropDownListNewsCategory.Items.Add(new ListItem(row["Name"].ToString(), row["Guid"].ToString()));
                }
            }
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelTitle = (Label) skin.FindControl("LabelTitle");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            DropDownListNewsCategory = (DropDownList) skin.FindControl("DropDownListNewsCategory");
            TexteditorContent = (TextBox) skin.FindControl("TexteditorContent");
            CheckBoxIsShow = (CheckBox) skin.FindControl("CheckBoxIsShow");
            TextBoxSEOTitle = (TextBox) skin.FindControl("TextBoxSEOTitle");
            TextBoxKeywords = (TextBox) skin.FindControl("TextBoxKeywords");
            TextBoxDescription = (TextBox) skin.FindControl("TextBoxDescription");
            ButtonSubmit = (Button) skin.FindControl("ButtonSubmit");
            ButtonSubmit.Click += ButtonSubmit_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            HiddenFieldGuid = (HiddenField) skin.FindControl("HiddenFieldGuid");
            GetShopNewsCategory();
            if (Page.Request.QueryString["guid"] != null)
            {
                HiddenFieldGuid.Value = Page.Request.QueryString["guid"];
                LabelTitle.Text = "编辑资讯";
                GetDataInfo();
            }
            else
            {
                LabelTitle.Text = "添加资讯";
            }
        }

        protected void BindData()
        {
            var news = new ShopNum1_Shop_News
            {
                Content = TexteditorContent.Text.Trim(),
                Description = TextBoxDescription.Text.Trim(),
                Guid = new Guid(Page.Request.QueryString["guid"])
            };
            if (CheckBoxIsShow.Checked)
            {
                news.IsShow = 1;
            }
            else
            {
                news.IsShow = 0;
            }
            news.Keywords = TextBoxKeywords.Text.Trim();
            news.NewsCategoryGuid = DropDownListNewsCategory.SelectedValue;
            news.SEOTitle = TextBoxSEOTitle.Text.Trim();
            news.Title = TextBoxTitle.Text.Trim();
            try
            {
                if (shop_News_Action_0.UpdateNews(news) > 0)
                {
                    MessageBox.Show("修改成功！");
                    GetDataInfo();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("修改失败！");
            }
        }

        protected void method_1()
        {
            Exception exception;
            try
            {
                string str = Common.Common.GetNameById("ShopRank", "ShopNum1_ShopInfo",
                    "   AND  MemLoginID ='" + base.MemLoginID + "'  ");
                if (!string.IsNullOrEmpty(str))
                {
                    int num2 = 0;
                    string str2 = Common.Common.GetNameById("MaxArticleCout", "ShopNum1_ShopRank",
                        "   AND   Guid ='" + str + "'  ");
                    if (!string.IsNullOrEmpty(str2))
                    {
                        num2 = Convert.ToInt32(str2);
                    }
                    int num3 = 0;
                    string str3 = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_Shop_News",
                        "   AND    MemLoginID ='" + base.MemLoginID + "'  ");
                    if (!string.IsNullOrEmpty(str3))
                    {
                        num3 = Convert.ToInt32(str3);
                    }
                    if (num3 >= num2)
                    {
                        MessageBox.Show("店铺添加资讯数量已经达到最大值，如要添加更多资讯，请及时升级店铺等级！");
                        return;
                    }
                }
            }
            catch (Exception exception1)
            {
                exception = exception1;
                MessageBox.Show(exception.Message);
                return;
            }
            var news = new ShopNum1_Shop_News
            {
                ClickCount = 0,
                Content = TexteditorContent.Text.Trim(),
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Description = TextBoxDescription.Text.Trim(),
                Guid = Guid.NewGuid(),
                IsAudit = 0,
                IsDeleted = 0
            };
            if (CheckBoxIsShow.Checked)
            {
                news.IsShow = 1;
            }
            else
            {
                news.IsShow = 0;
            }
            news.Keywords = TextBoxKeywords.Text.Trim();
            news.MemLoginID = base.MemLoginID;
            news.NewsCategoryGuid = DropDownListNewsCategory.SelectedValue;
            news.OrderID = 0;
            news.SEOTitle = TextBoxSEOTitle.Text.Trim();
            news.Title = TextBoxTitle.Text.Trim();
            try
            {
                if (shop_News_Action_0.AddNews(news) > 0)
                {
                    MessageBox.Show("添加成功");
                    TexteditorContent.Text = "";
                    TextBoxDescription.Text = "";
                    TextBoxKeywords.Text = "";
                    DropDownListNewsCategory.SelectedValue = "-1";
                    TextBoxSEOTitle.Text = "";
                    TextBoxTitle.Text = "";
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                MessageBox.Show("添加失败！");
            }
        }
    }
}