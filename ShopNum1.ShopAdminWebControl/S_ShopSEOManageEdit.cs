using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopSEOManageEdit : BaseShopWebControl
    {
        private Button ButtonBackList;
        private Button ButtonSubmit;
        private TextBox TextBoxEsec;
        private TextBox TextBoxKeyWord;
        private TextBox TextBoxPageName;
        private TextBox TextBoxTitle;
        private string skinFilename = "S_ShopSEOManageEdit.ascx";

        public S_ShopSEOManageEdit()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string SetPath { get; set; }

        public void Add()
        {
            IShopNum1_ExtendSiteMota_Action action = LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
            string name = TextBoxPageName.Text.Trim();
            string title = TextBoxTitle.Text.Trim();
            string keywords = TextBoxKeyWord.Text.Trim();
            string str4 = TextBoxEsec.Text.Trim();
            int num = action.Add(name, title, keywords, str4, SetPath);
            if (num > 0)
            {
                MessageBox.Show("添加成功！");
                TextBoxPageName.Text = "";
                TextBoxTitle.Text = "";
            }
            else if (num == 0)
            {
                MessageBox.Show("此页面名已经存在了!");
            }
            else
            {
                MessageBox.Show("添加失败!");
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["pid"] != null)
            {
                Edit();
            }
            else
            {
                Add();
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ShopSEOManage.aspx");
        }

        public void Edit()
        {
            IShopNum1_ExtendSiteMota_Action action = LogicFactory.CreateShopNum1_ExtendSiteMota_Action();
            string name = TextBoxPageName.Text.Trim();
            string title = TextBoxTitle.Text.Trim();
            string keywords = TextBoxKeyWord.Text.Trim();
            string str4 = TextBoxEsec.Text.Trim();
            if (action.edit(name, title, keywords, str4, SetPath) > 0)
            {
                Page.Response.Redirect("S_ShopSEOManage.aspx");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        public void GetEditInfo()
        {
            DataRow row =
                LogicFactory.CreateShopNum1_ExtendSiteMota_Action()
                    .SelectByName(Page.Request.QueryString["pid"].Replace("'", ""), SetPath)
                    .Rows[0];
            TextBoxPageName.Text = row["PageName"].ToString();
            TextBoxTitle.Text = row["Title"].ToString();
            TextBoxKeyWord.Text = row["KeyWords"].ToString();
            TextBoxEsec.Text = row["Description"].ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            TextBoxPageName = (TextBox) skin.FindControl("TextBoxPageName");
            TextBoxTitle = (TextBox) skin.FindControl("TextBoxTitle");
            TextBoxKeyWord = (TextBox) skin.FindControl("TextBoxKeyWord");
            TextBoxEsec = (TextBox) skin.FindControl("TextBoxEsec");
            ButtonSubmit = (Button) skin.FindControl("ButtonSubmit");
            ButtonSubmit.Click += ButtonSubmit_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            DataTable memLoginInfo =
                ((Shop_ShopInfo_Action) ShopFactory.LogicFactory.CreateShop_ShopInfo_Action()).GetMemLoginInfo(
                    base.MemLoginID);
            string str = memLoginInfo.Rows[0]["ShopID"].ToString();
            string str2 = DateTime.Parse(memLoginInfo.Rows[0]["OpenTime"].ToString()).ToString("yyyy-MM-dd");
            SetPath = "~/Shop/Shop/" + str2.Replace("-", "/") + "/shop" + str + "/xml/SetMeto.xml";
            if (Page.Request.QueryString["pid"] != null)
            {
                GetEditInfo();
                TextBoxPageName.ReadOnly = true;
            }
        }
    }
}