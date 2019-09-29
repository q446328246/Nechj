using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1_ProductCategory_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';
       
        private IShopNum1_SpecificationProudctCategory_Action ishopNum1_SpecificationProudctCategory_Action_0 = LogicFactory.CreateShopNum1_SpecificationProudctCategory_Action();
      
        private ShopNum1_ProductCategory_Action shopNum1_ProductCategory_Action_0 = ((ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action());
        protected string strSapce = "　　";

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            ShopNum1_OperateLog log;
            if (this.ButtonConfirm.ToolTip == "Update")
            {
                
                    
                log = new ShopNum1_OperateLog
                {
                    Record = "更改商品分类",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1_ProductCategory_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.method_13();
            }
            else if (this.ButtonConfirm.ToolTip == "Submit")
            {
                log = new ShopNum1_OperateLog
                {
                    Record = "新增商品分类",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1_ProductCategory_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.method_11();
            }
            this.BindData();
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            this.method_12();
        }

        private void method_10()
        {
            DataTable productCategoryByID;
            if (base.Request.QueryString["op"].ToString() == "edit")
            {
                productCategoryByID = this.shopNum1_ProductCategory_Action_0.GetProductCategoryByID(this.hiddenFieldGuid.Value.ToString());
                this.TextBoxName.Text = productCategoryByID.Rows[0]["Name"].ToString();
                this.TextBoxKeywords.Text = productCategoryByID.Rows[0]["Keywords"].ToString();
                this.TextBoxDescription.Text = productCategoryByID.Rows[0]["Description"].ToString();
                this.TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
                this.DropDownListFatherCateGory.Text = productCategoryByID.Rows[0]["FatherID"].ToString();
                this.DropDownListCateType.Text = productCategoryByID.Rows[0]["CategoryType"].ToString();
                if (productCategoryByID.Rows[0]["IsShow"].ToString() == "1")
                {
                    this.CheckBoxIsShow.Checked = true;
                }
                else
                {
                    this.CheckBoxIsShow.Checked = false;
                }
                this.imgshow.Src = productCategoryByID.Rows[0]["logoimg"].ToString();
                this.TextBoxId.Text = this.hiddenFieldGuid.Value.ToString();
                this.TextBoxCode.Text = productCategoryByID.Rows[0]["code"].ToString();
                this.ButtonConfirm.Text = "更新";
                this.ButtonConfirm.ToolTip = "Update";
            }
            else if ((base.Request.QueryString["op"].ToString() == "add") && (ShopNum1.Common.Common.ReqStr("guid") != ""))
            {
                productCategoryByID = this.shopNum1_ProductCategory_Action_0.GetProductCategoryByID(this.hiddenFieldGuid.Value.ToString());
                this.TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
                string str = ShopNum1.Common.Common.GetNameById("[Name]+','+cast(id as varchar(8))", "ShopNum1_ProductCategory", " and id='" + ShopNum1.Common.Common.ReqStr("guid") + "'");
                ListItem item = new ListItem();
                if (ShopNum1.Common.Common.ReqStr("level") == "1")
                {
                    item.Text = this.charSapce + str.Split(new char[] { ',' })[0];
                }
                else if (ShopNum1.Common.Common.ReqStr("level") == "2")
                {
                    item.Text = this.strSapce + str.Split(new char[] { ',' })[0];
                }
                item.Value = str.Split(new char[] { ',' })[1];
                this.DropDownListFatherCateGory.Items.Add(item);
                this.ButtonConfirm.Text = "添加";
                this.ButtonConfirm.ToolTip = "Submit";
            }
            else
            {
                productCategoryByID = this.shopNum1_ProductCategory_Action_0.GetProductCategoryByID(this.hiddenFieldGuid.Value.ToString());
                this.TextBoxOrderID.Text = productCategoryByID.Rows[0]["OrderID"].ToString();
                this.DropDownListFatherCateGory.Text = base.Request.QueryString["guid"].ToString();
                this.ButtonConfirm.Text = "添加";
                this.ButtonConfirm.ToolTip = "Submit";
            }
        }

        private void method_11()
        {
            ShopNum1_ProductCategory category;
            object obj2;
            string str3;
            string[] strArray3;
            ShopNum1_ProductCategory_Action action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
            string str = string.Empty;
            if (!this.fileCategory.HasFile)
            {
                category = new ShopNum1_ProductCategory
                {
                    Name = this.TextBoxName.Text.Trim(),
                    Keywords = this.TextBoxKeywords.Text.Trim(),
                    Description = this.TextBoxDescription.Text.Trim(),
                    OrderID = Convert.ToInt32(this.TextBoxOrderID.Text),
                    logoimg = ""
                };
                if (this.CheckBoxIsShow.Checked)
                {
                    category.IsShow = 1;
                }
                else
                {
                    category.IsShow = 0;
                }
                if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
                {
                    category.CategoryLevel = 1;
                }
                else
                {
                    strArray3 = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[] { this.charSapce });
                    if (strArray3.Length > 0)
                    {
                        category.CategoryLevel = ((strArray3.Length + 1) / 2) + 1;
                        if (category.CategoryLevel >= 4)
                        {
                            MessageBox.Show("商品分类为三级分类!");
                            return;
                        }
                    }
                    else
                    {
                        category.CategoryLevel = 2;
                    }
                }
            }
            else
            {
                string contentType = this.fileCategory.PostedFile.ContentType;
                string[] extArry = new string[] { "image/png", "image/gif", "image/x-png", "image/jpeg", "image/pjpeg" };
                if (!ImageUpload.CheckImgTypex(extArry, contentType))
                {
                    MessageBox.Show("请上传png/jpg/pjpeg/x-png/jpeg类型图片！");
                    return;
                }
                string fileName = Operator.FilterString(this.fileCategory.PostedFile.FileName);
                Random random = new Random();
                string str7 = (10 + random.Next(70)).ToString();
                Thread.Sleep(20);
                string str8 = DateTime.Now.ToString("yyyyMMddHHmmss") + str7;
                FileInfo info = new FileInfo(fileName);
                string str4 = str8 + info.Extension;
                if (!Directory.Exists(base.Server.MapPath("~/ImgUpload/productCategory")))
                {
                    Directory.CreateDirectory(base.Server.MapPath("~/ImgUpload/productCategory"));
                }
                string path = base.Server.MapPath("~/ImgUpload/productCategory/" + str4);
                str = "~/ImgUpload/productCategory/" + str4;
                if (File.Exists(path))
                {
                    this.MessageShow.Visible = true;
                    this.MessageShow.ShowMessage("UpdateNo2");
                    return;
                }
                this.fileCategory.SaveAs(path);
                category = new ShopNum1_ProductCategory
                {
                    Name = this.TextBoxName.Text.Trim(),
                    Keywords = this.TextBoxKeywords.Text.Trim(),
                    Description = this.TextBoxDescription.Text.Trim(),
                    OrderID = Convert.ToInt32(this.TextBoxOrderID.Text),
                    logoimg = str
                };
                if (this.CheckBoxIsShow.Checked)
                {
                    category.IsShow = 1;
                }
                else
                {
                    category.IsShow = 0;
                }
                if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
                {
                    category.CategoryLevel = 1;
                }
                else
                {
                    strArray3 = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[] { this.charSapce });
                    if (strArray3.Length > 0)
                    {
                        category.CategoryLevel = ((strArray3.Length + 1) / 2) + 1;
                        if (category.CategoryLevel >= 4)
                        {
                            MessageBox.Show("商品分类为三级分类!");
                            return;
                        }
                    }
                    else
                    {
                        category.CategoryLevel = 2;
                    }
                }
                if ((ShopNum1.Common.Common.ReqStr("op") == "add") && (ShopNum1.Common.Common.ReqStr("guid") != ""))
                {
                    category.FatherID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("guid"));
                }
                else
                {
                    category.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
                }
                category.CreateUser = "admin";
                category.CreateTime = DateTime.Now;
                category.ModifyUser = "admin";
                category.ModifyTime = DateTime.Now;
                category.IsDeleted = 0;
                category.CategoryType = new int?(Convert.ToInt32(this.DropDownListCateType.SelectedValue));
                category.CategoryTypeName = this.DropDownListCateType.SelectedItem.Text;
                obj2 = action.Add1(category);
                if (obj2 != null)
                {
                    str3 = Convert.ToString(obj2);
                    if (this.hiddenFieldSpecification.Value != "-1")
                    {
                        this.ishopNum1_SpecificationProudctCategory_Action_0.InsertMuch(str3, "", this.hiddenFieldSpecification.Value);
                    }
                    this.method_12();
                    this.MessageShow.ShowMessage("AddYes");
                    this.MessageShow.Visible = true;
                }
                else
                {
                    this.MessageShow.ShowMessage("AddNo");
                    this.MessageShow.Visible = true;
                }
                return;
            }
            if ((ShopNum1.Common.Common.ReqStr("op") == "add") && (ShopNum1.Common.Common.ReqStr("guid") != ""))
            {
                category.FatherID = Convert.ToInt32(ShopNum1.Common.Common.ReqStr("guid"));
            }
            else
            {
                category.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            }
            category.CreateUser = "admin";
            category.CreateTime = DateTime.Now;
            category.ModifyUser = "admin";
            category.ModifyTime = DateTime.Now;
            category.IsDeleted = 0;
            category.CategoryType = new int?(Convert.ToInt32(this.DropDownListCateType.SelectedValue));
            category.CategoryTypeName = this.DropDownListCateType.SelectedItem.Text;
            obj2 = action.Add1(category);
            if (obj2 != null)
            {
                str3 = Convert.ToString(obj2);
                if (this.hiddenFieldSpecification.Value != "-1")
                {
                    this.ishopNum1_SpecificationProudctCategory_Action_0.InsertMuch(str3, "", this.hiddenFieldSpecification.Value);
                }
                this.method_12();
                this.MessageShow.ShowMessage("AddYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        private void method_12()
        {
            this.TextBoxName.Text = string.Empty;
            this.TextBoxKeywords.Text = string.Empty;
            this.TextBoxDescription.Text = string.Empty;
            this.TextBoxOrderID.Text = (int.Parse(this.TextBoxOrderID.Text) + 1).ToString();
            this.CheckBoxIsShow.Checked = true;
        }

        private void method_13()
        {
            string[] strArray3;
            ShopNum1_ProductCategory category;
            ShopNum1_ProductCategory_Action action = (ShopNum1_ProductCategory_Action)LogicFactory.CreateShopNum1_ProductCategory_Action();
            string str = string.Empty;
            if (!this.fileCategory.HasFile)
            {
                category = new ShopNum1_ProductCategory
                {
                    ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString().Replace("'", "")),
                    Name = this.TextBoxName.Text.Trim(),
                    Keywords = this.TextBoxKeywords.Text.Trim(),
                    Description = this.TextBoxDescription.Text.Trim(),
                    OrderID = Convert.ToInt32(this.TextBoxOrderID.Text)
                };
                if (this.CheckBoxIsShow.Checked)
                {
                    category.IsShow = 1;
                }
                else
                {
                    category.IsShow = 0;
                }
                if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
                {
                    category.CategoryLevel = 1;
                }
                else
                {
                    strArray3 = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[] { this.charSapce });
                    if (strArray3.Length > 0)
                    {
                        category.CategoryLevel = ((strArray3.Length + 1) / 2) + 1;
                        if (category.CategoryLevel >= 4)
                        {
                            MessageBox.Show("商品分类为三级分类!");
                            return;
                        }
                    }
                    else
                    {
                        category.CategoryLevel = 2;
                    }
                }
            }
            else
            {
                string contentType = this.fileCategory.PostedFile.ContentType;
                string[] extArry = new string[] { "image/png", "image/gif", "image/x-png", "image/jpeg", "image/pjpeg", "image/bmp" };
                if (!ImageUpload.CheckImgTypex(extArry, contentType))
                {
                    MessageBox.Show("请上传png/jpg/pjpeg/x-png/jpeg类型图片！");
                    return;
                }
                string fileName = Operator.FilterString(this.fileCategory.PostedFile.FileName);
                Random random = new Random();
                string str4 = (10 + random.Next(70)).ToString();
                Thread.Sleep(20);
                string str5 = DateTime.Now.ToString("yyyyMMddHHmmss") + str4;
                FileInfo info = new FileInfo(fileName);
                string str6 = str5 + info.Extension;
                if (!Directory.Exists(base.Server.MapPath("~/ImgUpload/productCategory")))
                {
                    Directory.CreateDirectory(base.Server.MapPath("~/ImgUpload/productCategory"));
                }
                string path = base.Server.MapPath("~/ImgUpload/productCategory/" + str6);
                str = "~/ImgUpload/productCategory/" + str6;
                if (File.Exists(path))
                {
                    this.MessageShow.Visible = true;
                    this.MessageShow.ShowMessage("UpdateNo2");
                    return;
                }
                this.fileCategory.SaveAs(path);
                category = new ShopNum1_ProductCategory
                {
                    logoimg = str,
                    ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString().Replace("'", "")),
                    Name = this.TextBoxName.Text.Trim(),
                    Keywords = this.TextBoxKeywords.Text.Trim(),
                    Description = this.TextBoxDescription.Text.Trim(),
                    OrderID = Convert.ToInt32(this.TextBoxOrderID.Text)
                };
                if (this.CheckBoxIsShow.Checked)
                {
                    category.IsShow = 1;
                }
                else
                {
                    category.IsShow = 0;
                }
                if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
                {
                    category.CategoryLevel = 1;
                }
                else
                {
                    strArray3 = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[] { this.charSapce });
                    if (strArray3.Length > 0)
                    {
                        category.CategoryLevel = ((strArray3.Length + 1) / 2) + 1;
                        if (category.CategoryLevel >= 4)
                        {
                            MessageBox.Show("商品分类为三级分类!");
                            return;
                        }
                    }
                    else
                    {
                        category.CategoryLevel = 2;
                    }
                }
                category.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
                category.CreateUser = "admin";
                category.CreateTime = DateTime.Now;
                category.ModifyUser = "admin";
                category.ModifyTime = DateTime.Now;
                category.IsDeleted = 0;
                category.CategoryType = new int?(Convert.ToInt32(this.DropDownListCateType.SelectedValue));
                category.CategoryTypeName = this.DropDownListCateType.SelectedItem.Text;
                if (action.Update(this.hiddenFieldGuid.Value.ToString(), category) > 0)
                {
                    if (this.hiddenFieldSpecification.Value != "-1")
                    {
                        this.ishopNum1_SpecificationProudctCategory_Action_0.InsertMuch(this.hiddenFieldGuid.Value, "", this.hiddenFieldSpecification.Value);
                    }
                    else
                    {
                        this.ishopNum1_SpecificationProudctCategory_Action_0.DeleteByProductCategoryID(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
                    }
                    this.MessageShow.ShowMessage("EditYes");
                    this.MessageShow.Visible = true;
                }
                else
                {
                    this.MessageShow.ShowMessage("EditNo");
                    this.MessageShow.Visible = true;
                }
                return;
            }
            category.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            category.CreateUser = "admin";
            category.CreateTime = DateTime.Now;
            category.ModifyUser = "admin";
            category.ModifyTime = DateTime.Now;
            category.IsDeleted = 0;
            category.logoimg = this.imgshow.Src;
            category.CategoryType = new int?(Convert.ToInt32(this.DropDownListCateType.SelectedValue));
            category.CategoryTypeName = this.DropDownListCateType.SelectedItem.Text;
            if (action.Update(this.hiddenFieldGuid.Value.ToString(), category) > 0)
            {
                if (this.hiddenFieldSpecification.Value != "-1")
                {
                    this.ishopNum1_SpecificationProudctCategory_Action_0.InsertMuch(this.hiddenFieldGuid.Value, "", this.hiddenFieldSpecification.Value);
                }
                else
                {
                    this.ishopNum1_SpecificationProudctCategory_Action_0.DeleteByProductCategoryID(this.hiddenFieldGuid.Value.ToString().Replace("'", ""));
                }
                this.MessageShow.ShowMessage("EditYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }

        private void BindData()
        {
            this.method_7();
            this.method_6();
            if (this.hiddenFieldGuid.Value != "0")
            {
                this.LabelTitle.Text = "编辑商品分类";
                this.method_10();
                this.trID.Visible = false;
                this.trCode.Visible = false;
                this.DropDownListFatherCateGory.Enabled = false;
                if (ShopNum1.Common.Common.ReqStr("op") == "add")
                {
                    this.TextBoxOrderID.Text = Convert.ToString((int)(this.method_9() + 1));
                }
            }
            else
            {
                this.TextBoxOrderID.Text = Convert.ToString((int)(this.method_9() + 1));
                this.trID.Visible = false;
                this.trCode.Visible = false;
            }
        }

        private void method_6()
        {
            this.DropDownListFatherCateGory.Enabled = true;
            this.DropDownListCateType.Items.Clear();
            DataTable table = ((ShopNum1_CategoryType_Action)LogicFactory.CreateShopNum1_CategoryType_Action()).Select_ProductCategoryType();
            ListItem item = new ListItem
            {
                Text = "-请选择-",
                Value = "-1"
            };
            this.DropDownListCateType.Items.Add(item);
            foreach (DataRow row in table.Rows)
            {
                ListItem item2 = new ListItem
                {
                    Text = row["Name"].ToString(),
                    Value = row["ID"].ToString()
                };
                this.DropDownListCateType.Items.Add(item2);
            }
        }

        private void method_7()
        {
            this.DropDownListFatherCateGory.Items.Clear();
            if (ShopNum1.Common.Common.ReqStr("op") != "add")
            {
                ListItem item = new ListItem
                {
                    Text = "顶级分类",
                    Value = "0"
                };
                this.DropDownListFatherCateGory.Items.Add(item);
                foreach (DataRow row in this.shopNum1_ProductCategory_Action_0.SearchtTwoProductCategory(0, 0).Rows)
                {
                    ListItem item2 = new ListItem
                    {
                        Text = row["Name"].ToString(),
                        Value = row["ID"].ToString()
                    };
                    this.DropDownListFatherCateGory.Items.Add(item2);
                    this.method_8(Convert.ToInt32(row["ID"].ToString()));
                }
            }
        }

        private void method_8(int int_0)
        {
            foreach (DataRow row in this.shopNum1_ProductCategory_Action_0.SearchtTwoProductCategory(int_0, 0).Rows)
            {
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + this.strSapce;
                }
                ListItem item = new ListItem
                {
                    Text = str + row["Name"].ToString(),
                    Value = row["ID"].ToString()
                };
                this.DropDownListFatherCateGory.Items.Add(item);
                this.method_8(Convert.ToInt32(row["ID"].ToString()));
            }
        }

        private int method_9()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_ProductCategory");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!this.Page.IsPostBack)
            {
                this.BindData();
            }
        }
    }
}