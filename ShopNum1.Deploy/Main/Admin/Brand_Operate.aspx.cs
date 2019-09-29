using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Brand_Operate : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                GetOrderID();
                if (hiddenFieldGuid.Value != "0")
                {
                    GetEditInfo();
                    ButtonConfirm.Text = "更新";
                }
                else
                {
                    TextBoxOrderID.Text = Convert.ToString((GetOrderID() + 1));
                }
            }
        }

        protected void Add()
        {
            DataTable table =
                ((ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action()).CheckBrand(TextBoxName.Text);
            if ((table != null) && (table.Rows.Count > 0))
            {
                MessageBox.Show("此商品品牌已存在!");
            }
            else
            {
                var brand = new ShopNum1_Brand
                    {
                        Guid = Guid.NewGuid(),
                        Name = TextBoxName.Text.Trim(),
                        Logo = TextBoxLogo.Text.Trim(),
                        WebSite = TextBoxWebSite.Text.Trim().Replace("http://", ""),
                        OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim()),
                        Keywords = TextBoxKeywords.Text.Trim(),
                        IsShow = Convert.ToInt32(DropDownListIsShow.SelectedValue),
                        Remark = TextBoxRemark.Text.Trim(),
                        Description = TextBoxDescription.Text.Trim(),
                        CreateUser = "admin",
                        CreateTime = DateTime.Now,
                        ModifyUser = "admin",
                        ModifyTime = DateTime.Now,
                        IsDeleted = 0,
                        CategoryName = txtCategoryName.Text
                    };
                if (CheckBoxIsCommend.Checked)
                {
                    brand.IsCommend = 1;
                }
                else
                {
                    brand.IsCommend = 0;
                }
                var action2 = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
                if (action2.Add(brand) > 0)
                {
                    HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                    var operateLog = new ShopNum1_OperateLog
                        {
                            Record = "管理员新增品牌",
                            OperatorID = cookie2.Values["LoginID"].ToString(),
                            IP = Globals.IPAddress,
                            PageName = "Brand_Operate.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(operateLog);
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
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (hiddenFieldGuid.Value != "0")
            {
                Edit();
            }
            else
            {
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxName.Text = string.Empty;
            TextBoxLogo.Text = string.Empty;
            TextBoxWebSite.Text = string.Empty;
            TextBoxOrderID.Text = (int.Parse(TextBoxOrderID.Text) + 1).ToString();
            TextBoxRemark.Text = string.Empty;
            TextBoxKeywords.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
            DropDownListIsShow.SelectedValue = "-1";
            CheckBoxIsCommend.Checked = false;
        }

        protected void Edit()
        {
            var action1 = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
            var brand = new ShopNum1_Brand
                {
                    Name = TextBoxName.Text.Trim(),
                    Logo = TextBoxLogo.Text.Trim(),
                    WebSite = TextBoxWebSite.Text.Trim().Replace("http://", "").Replace("https://", ""),
                    OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim()),
                    Keywords = TextBoxKeywords.Text.Trim(),
                    IsShow = Convert.ToInt32(DropDownListIsShow.SelectedValue),
                    Remark = TextBoxRemark.Text.Trim(),
                    Description = TextBoxDescription.Text.Trim(),
                    ModifyUser = "admin",
                    ModifyTime = DateTime.Now,
                    IsDeleted = 0,
                    CategoryName = txtCategoryName.Text
                };
            if (CheckBoxIsCommend.Checked)
            {
                brand.IsCommend = 1;
            }
            else
            {
                brand.IsCommend = 0;
            }
            var action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
            if (action.Update(hiddenFieldGuid.Value, brand) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "管理员修改品牌",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "Brand_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                base.Response.Redirect("Brand_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo =
                ((ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action()).GetEditInfo(hiddenFieldGuid.Value);
            TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
            ViewState["BrandName"] = TextBoxName.Text;
            TextBoxLogo.Text = editInfo.Rows[0]["Logo"].ToString();
            if (editInfo.Rows[0]["Logo"].ToString() != string.Empty)
            {
                ImageOriginalImge.Src = editInfo.Rows[0]["Logo"].ToString();
            }
            else
            {
                ImageOriginalImge.Src = Globals.ApplicationPath + "/Images/noImage.gif";
            }
            txtCategoryName.Text = editInfo.Rows[0]["categoryName"].ToString();
            TextBoxWebSite.Text = editInfo.Rows[0]["WebSite"].ToString();
            TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
            TextBoxKeywords.Text = editInfo.Rows[0]["Keywords"].ToString();
            TextBoxRemark.Text = editInfo.Rows[0]["Remark"].ToString();
            TextBoxDescription.Text = editInfo.Rows[0]["Description"].ToString();
            DropDownListIsShow.SelectedValue = editInfo.Rows[0]["IsShow"].ToString();
            if (editInfo.Rows[0]["IsCommend"].ToString() == "1")
            {
                CheckBoxIsCommend.Checked = true;
            }
            ButtonConfirm.Text = "更新";
            LabelPageTitle.Text = "编辑商品品牌";
        }

        protected int GetOrderID()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Brand");
        }


    }
}