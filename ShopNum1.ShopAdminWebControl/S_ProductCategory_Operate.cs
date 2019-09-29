using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ProductCategory_Operate : BaseShopWebControl
    {
        private readonly ShopNum1_Shop_ProductCategory shopNum1_Shop_ProductCategory_0 =
            new ShopNum1_Shop_ProductCategory();

        private readonly Shop_ProductCategory_Action shop_ProductCategory_Action_0 =
            ((Shop_ProductCategory_Action) LogicFactory.CreateShop_ProductCategory_Action());

        private Button btnConfrim;
        private CheckBox cbIsshow;
        protected char charSapce = '　';
        private Label lblShopCategory;
        private HtmlSelect selectCategory;
        private string skinFilename = "S_ProductCategory_Operate.ascx";
        protected string strSapce = "　　";
        private HtmlTableRow trIv;
        private HtmlTextArea txtDesc;
        private HtmlInputText txtKeyWord;
        private HtmlInputText txtName;
        private HtmlInputText txtOrderId;

        public S_ProductCategory_Operate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        protected void btnConfrim_Click(object sender, EventArgs e)
        {
            method_3();
        }

        protected override void InitializeSkin(Control skin)
        {
            lblShopCategory = (Label) skin.FindControl("lblShopCategory");
            trIv = (HtmlTableRow) skin.FindControl("trIv");
            selectCategory = (HtmlSelect) skin.FindControl("selectCategory");
            btnConfrim = (Button) skin.FindControl("btnConfrim");
            txtName = (HtmlInputText) skin.FindControl("txtName");
            txtKeyWord = (HtmlInputText) skin.FindControl("txtKeyWord");
            txtDesc = (HtmlTextArea) skin.FindControl("txtDesc");
            txtOrderId = (HtmlInputText) skin.FindControl("txtOrderId");
            cbIsshow = (CheckBox) skin.FindControl("cbIsshow");
            btnConfrim.Click += btnConfrim_Click;
            BindData();
            method_2();
        }

        protected void BindData()
        {
            selectCategory.Items.Clear();
            var item = new ListItem
            {
                Text = "顶级分类",
                Value = "0"
            };
            selectCategory.Items.Add(item);
            if (Common.Common.ReqStr("parentid") == "")
            {
                selectCategory.Disabled = true;
            }
            DataTable shopProductCategoryCode = shop_ProductCategory_Action_0.GetShopProductCategoryCode("0",
                base.MemLoginID);
            if (shopProductCategoryCode.Rows.Count > 0)
            {
                foreach (DataRow row in shopProductCategoryCode.Rows)
                {
                    var item2 = new ListItem
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString()
                    };
                    selectCategory.Items.Add(item2);
                    if (Common.Common.ReqStr("parentid") == row["ID"].ToString())
                    {
                        selectCategory.Disabled = true;
                        selectCategory.Items[selectCategory.SelectedIndex].Value = Common.Common.ReqStr("parentid");
                        selectCategory.Items[selectCategory.SelectedIndex].Text = row["Name"].ToString();
                        selectCategory.Items[selectCategory.SelectedIndex].Selected = true;
                    }
                }
            }
        }

        protected void method_1(string string_1)
        {
            DataTable shopProductCategoryCode = shop_ProductCategory_Action_0.GetShopProductCategoryCode(string_1,
                base.MemLoginID);
            if (shopProductCategoryCode.Rows.Count > 0)
            {
                foreach (DataRow row in shopProductCategoryCode.Rows)
                {
                    string str = string.Empty;
                    for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                    {
                        str = str + strSapce;
                    }
                    var item = new ListItem
                    {
                        Text = str + row["Name"],
                        Value = row["ID"].ToString()
                    };
                    selectCategory.Items.Add(item);
                }
            }
        }

        protected void method_2()
        {
            if ((Common.Common.ReqStr("id") != "") && (Common.Common.ReqStr("op") == "edit"))
            {
                selectCategory.Disabled = true;
                DataTable productCategoryInfoByCode =
                    shop_ProductCategory_Action_0.GetProductCategoryInfoByCode(Common.Common.ReqStr("id"),
                        base.MemLoginID);
                if (productCategoryInfoByCode.Rows.Count > 0)
                {
                    txtName.Value = productCategoryInfoByCode.Rows[0]["name"].ToString();
                    txtKeyWord.Value = productCategoryInfoByCode.Rows[0]["keywords"].ToString();
                    txtDesc.Value = productCategoryInfoByCode.Rows[0]["description"].ToString();
                    txtOrderId.Value = productCategoryInfoByCode.Rows[0]["orderid"].ToString();
                    if (productCategoryInfoByCode.Rows[0]["isshow"].ToString() == "1")
                    {
                        cbIsshow.Checked = true;
                    }
                    else
                    {
                        cbIsshow.Checked = false;
                    }
                }
                trIv.Disabled = true;
                lblShopCategory.Text = "修改店铺商品分类";
            }
            else
            {
                txtOrderId.Value = shop_ProductCategory_Action_0.GetMaxID(base.MemLoginID).ToString();
                lblShopCategory.Text = "添加店铺商品分类";
            }
            if ((Common.Common.ReqStr("id") != "") && (Common.Common.ReqStr("op") == "add"))
            {
                trIv.Disabled = true;
                lblShopCategory.Text = "添加店铺商品分类";
            }
        }

        protected void method_3()
        {
            Random random;
            if (!(Common.Common.ReqStr("op") == "add"))
            {
                shopNum1_Shop_ProductCategory_0.ID = Convert.ToInt32(Common.Common.ReqStr("id"));
                shopNum1_Shop_ProductCategory_0.Name = Operator.FilterString(txtName.Value);
                shopNum1_Shop_ProductCategory_0.Keywords = Operator.FilterString(txtKeyWord.Value);
                shopNum1_Shop_ProductCategory_0.Description = Operator.FilterString(txtDesc.Value);
                if (cbIsshow.Checked)
                {
                    shopNum1_Shop_ProductCategory_0.IsShow = 1;
                }
                else
                {
                    shopNum1_Shop_ProductCategory_0.IsShow = 0;
                }
                shopNum1_Shop_ProductCategory_0.OrderID = Convert.ToInt32(txtOrderId.Value);
                shopNum1_Shop_ProductCategory_0.MemLoginID = base.MemLoginID;
                shop_ProductCategory_Action_0.Update(shopNum1_Shop_ProductCategory_0);
                random = new Random();
                Page.Response.Redirect("S_ProductCategory.aspx?r=" + random.Next(0, 0x2710));
            }
            else
            {
                shopNum1_Shop_ProductCategory_0.Name = Operator.FilterString(txtName.Value);
                shopNum1_Shop_ProductCategory_0.Keywords = Operator.FilterString(txtKeyWord.Value);
                shopNum1_Shop_ProductCategory_0.Description = Operator.FilterString(txtDesc.Value);
                if (cbIsshow.Checked)
                {
                    shopNum1_Shop_ProductCategory_0.IsShow = 1;
                }
                else
                {
                    shopNum1_Shop_ProductCategory_0.IsShow = 0;
                }
                shopNum1_Shop_ProductCategory_0.OrderID = Convert.ToInt32(txtOrderId.Value);
                if (selectCategory.Value == "0")
                {
                    shopNum1_Shop_ProductCategory_0.CategoryLevel = 1;
                }
                else
                {
                    string[] strArray = selectCategory.Items[selectCategory.SelectedIndex].Text.Split(new[] {charSapce});
                    if (strArray.Length > 0)
                    {
                        shopNum1_Shop_ProductCategory_0.CategoryLevel = ((strArray.Length + 1)/2) + 1;
                        if (shopNum1_Shop_ProductCategory_0.CategoryLevel >= 3)
                        {
                            MessageBox.Show("商品分类为二级分类!");
                            return;
                        }
                    }
                    else
                    {
                        shopNum1_Shop_ProductCategory_0.CategoryLevel = 2;
                    }
                }
                if (Common.Common.ReqStr("id") != "")
                {
                    shopNum1_Shop_ProductCategory_0.FatherID = Convert.ToInt32(Common.Common.ReqStr("id"));
                }
                else
                {
                    shopNum1_Shop_ProductCategory_0.FatherID =
                        Convert.ToInt32(selectCategory.Items[selectCategory.SelectedIndex].Value);
                }
                shopNum1_Shop_ProductCategory_0.MemLoginID = base.MemLoginID;
                shop_ProductCategory_Action_0.Add(shopNum1_Shop_ProductCategory_0);
                random = new Random();
                method_2();
                MessageBox.Show("分类添加成功！");
                Page.Response.Redirect("S_ProductCategory.aspx?r=" + random.Next(0, 0x2710));
            }
        }
    }
}