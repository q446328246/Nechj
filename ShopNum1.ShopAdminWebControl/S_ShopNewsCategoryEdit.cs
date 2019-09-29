using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopNewsCategoryEdit : BaseMemberWebControl
    {
        private Button ButtonBack;
        private Button ButtonConfrim;
        private CheckBox CheckBoxIsShow;
        private TextBox TextBoxDescription;
        private TextBox TextBoxKeyWrods;
        private TextBox TextBoxName;
        private TextBox TextBoxOrderID;
        private HiddenField hiddenFieldGuid;
        private Shop_Common_Action shop_Common_Action_0 = ((Shop_Common_Action) LogicFactory.CreateShop_Common_Action());
        private string skinFilename = "S_ShopNewsCategoryEdit.ascx";

        public S_ShopNewsCategoryEdit()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void ButtonConfrim_Click(object sender, EventArgs e)
        {
            if (hiddenFieldGuid.Value != "0")
            {
                method_1();
            }
            else
            {
                method_3();
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ShopNewsCategory.aspx");
        }

        protected override void InitializeSkin(Control skin)
        {
            ButtonBack = (Button) skin.FindControl("ButtonBack");
            ButtonBack.Click += ButtonBack_Click;
            TextBoxName = (TextBox) skin.FindControl("TextBoxName");
            TextBoxKeyWrods = (TextBox) skin.FindControl("TextBoxKeyWrods");
            TextBoxDescription = (TextBox) skin.FindControl("TextBoxDescription");
            TextBoxOrderID = (TextBox) skin.FindControl("TextBoxOrderID");
            CheckBoxIsShow = (CheckBox) skin.FindControl("CheckBoxIsShow");
            hiddenFieldGuid = (HiddenField) skin.FindControl("hiddenFieldGuid");
            ButtonConfrim = (Button) skin.FindControl("ButtonConfrim");
            ButtonConfrim.Click += ButtonConfrim_Click;
            hiddenFieldGuid = (HiddenField) skin.FindControl("hiddenFieldGuid");
            hiddenFieldGuid.Value = (Page.Request.QueryString["guid"] == null) ? "0" : Page.Request.QueryString["guid"];
            if (hiddenFieldGuid.Value != "0")
            {
                method_2();
            }
            else
            {
                TextBoxOrderID.Text = Convert.ToString((BindData() + 1));
            }
        }

        private int BindData()
        {
            string str = Common.Common.GetNameById("MAX(OrderID)", "ShopNum1_Shop_NewsCategory",
                "  AND   MemLoginID='" + base.MemLoginID + "'");
            if (!string.IsNullOrEmpty(str))
            {
                return Convert.ToInt32(str);
            }
            return 0;
        }

        protected void method_1()
        {
            var category = new ShopNum1_Shop_NewsCategory
            {
                Guid = new Guid(hiddenFieldGuid.Value),
                Description = TextBoxDescription.Text,
                Keywords = TextBoxKeyWrods.Text,
                Name = TextBoxName.Text,
                OrderID = Convert.ToInt32(TextBoxOrderID.Text)
            };
            if (CheckBoxIsShow.Checked)
            {
                category.IsShow = 1;
            }
            else
            {
                category.IsShow = 0;
            }
            var action = (Shop_NewsCategory_Action) LogicFactory.CreateShop_NewsCategory_Action();
            if (action.UpdateNewsCategory(category) > 0)
            {
                Page.Response.Redirect("S_ShopNewsCategory.aspx");
            }
        }

        protected void method_2()
        {
            DataTable newsCategory =
                ((Shop_NewsCategory_Action) LogicFactory.CreateShop_NewsCategory_Action()).GetNewsCategory(
                    hiddenFieldGuid.Value);
            TextBoxName.Text = newsCategory.Rows[0]["Name"].ToString();
            TextBoxKeyWrods.Text = newsCategory.Rows[0]["Keywords"].ToString();
            TextBoxDescription.Text = newsCategory.Rows[0]["Description"].ToString();
            TextBoxOrderID.Text = newsCategory.Rows[0]["OrderID"].ToString();
            if (newsCategory.Rows[0]["IsShow"].ToString() == "1")
            {
                CheckBoxIsShow.Checked = true;
            }
            else
            {
                CheckBoxIsShow.Checked = false;
            }
        }

        protected void method_3()
        {
            var category = new ShopNum1_Shop_NewsCategory
            {
                Guid = Guid.NewGuid(),
                Description = TextBoxDescription.Text,
                Keywords = TextBoxKeyWrods.Text,
                Name = TextBoxName.Text,
                OrderID = Convert.ToInt32(TextBoxOrderID.Text)
            };
            if (CheckBoxIsShow.Checked)
            {
                category.IsShow = 1;
            }
            else
            {
                category.IsShow = 0;
            }
            category.MemLoginID = base.MemLoginID;
            var action = (Shop_NewsCategory_Action) LogicFactory.CreateShop_NewsCategory_Action();
            if (action.AddNewsCategory(category) > 0)
            {
                Page.Response.Redirect("S_ShopNewsCategory.aspx");
            }
        }
    }
}