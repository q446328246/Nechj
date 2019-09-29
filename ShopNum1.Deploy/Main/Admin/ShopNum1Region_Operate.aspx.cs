using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopNum1Region_Operate : PageBase, IRequiresSessionState
    {

        protected char charSapce = '　';
        private ShopNum1_Region_Action shopNum1_Region_Action_0 = ((ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action());
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
                    Record = "编辑地区信息成功",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1Region_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.method_11();
            }
            else if (this.ButtonConfirm.ToolTip == "Submit")
            {
                log = new ShopNum1_OperateLog
                {
                    Record = "添加地区信息成功",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "ShopNum1Region_Operate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(log);
                this.method_9();
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            this.method_10();
        }

        private void method_10()
        {
            this.TextBoxName.Text = string.Empty;
            this.TextBoxOrderID.Text = (this.method_7() + 1).ToString();
        }

        private void method_11()
        {
            ShopNum1_Region region = new ShopNum1_Region
            {
                ID = Convert.ToInt32(this.hiddenFieldGuid.Value.ToString().Replace("'", "")),
                Name = this.TextBoxName.Text.Trim(),
                OrderID = Convert.ToInt32(this.TextBoxOrderID.Text)
            };
            if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
            {
                region.CategoryLevel = 1;
            }
            else
            {
                string[] strArray = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[] { this.charSapce });
                if (strArray.Length > 0)
                {
                    region.CategoryLevel = ((strArray.Length + 1) / 2) + 1;
                    if (region.CategoryLevel >= 4)
                    {
                        MessageBox.Show("区域分类为三级分类!");
                        return;
                    }
                }
                else
                {
                    region.CategoryLevel = 2;
                }
            }
            region.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            if (this.cbShopMap.Checked)
            {
                region.Family = "1";
            }
            else
            {
                region.Family = "0";
            }
            region.CreateUser = "";
            region.CreateTime = DateTime.Now;
            region.ModifyUser = "";
            region.ModifyTime = DateTime.Now;
            region.IsDeleted = "0";
            if (this.shopNum1_Region_Action_0.Update(this.hiddenFieldGuid.Value.ToString(), region) > 0)
            {
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
            ListItem item = new ListItem
            {
                Text = "顶级分类",
                Value = "0"
            };
            this.DropDownListFatherCateGory.Items.Add(item);
            foreach (DataRow row in this.shopNum1_Region_Action_0.SearchtRegionCategory(0, 0).Rows)
            {
                ListItem item2 = new ListItem
                {
                    Text = row["Name"].ToString(),
                    Value = row["ID"].ToString()
                };
                this.DropDownListFatherCateGory.Items.Add(item2);
                this.method_6(Convert.ToInt32(row["ID"].ToString()));
            }
        }

        private void method_6(int int_0)
        {
            foreach (DataRow row in this.shopNum1_Region_Action_0.SearchtRegionCategory(int_0, 0).Rows)
            {
                if (row["CategoryLevel"].ToString() == "3")
                {
                    break;
                }
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
                this.method_6(Convert.ToInt32(row["ID"].ToString()));
            }
        }

        private int method_7()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_Region");
        }

        private void method_8()
        {
            DataTable regionCategoryByID = this.shopNum1_Region_Action_0.GetRegionCategoryByID(this.hiddenFieldGuid.Value.ToString());
            this.TextBoxName.Text = regionCategoryByID.Rows[0]["Name"].ToString();
            this.TextBoxOrderID.Text = regionCategoryByID.Rows[0]["OrderID"].ToString();
            this.DropDownListFatherCateGory.Text = regionCategoryByID.Rows[0]["FatherID"].ToString();
            if (regionCategoryByID.Rows[0]["family"].ToString() == "0")
            {
                this.cbShopMap.Checked = false;
            }
            this.ButtonConfirm.Text = "更新";
            this.ButtonConfirm.ToolTip = "Update";
        }

        private void method_9()
        {
            ShopNum1_Region_Action action = (ShopNum1_Region_Action)LogicFactory.CreateShopNum1_Region_Action();
            ShopNum1_Region region = new ShopNum1_Region
            {
                Name = this.TextBoxName.Text.Trim(),
                OrderID = Convert.ToInt32(this.TextBoxOrderID.Text)
            };
            if (this.DropDownListFatherCateGory.SelectedValue.ToString() == "0")
            {
                region.CategoryLevel = 1;
            }
            else
            {
                string[] strArray = this.DropDownListFatherCateGory.SelectedItem.Text.Split(new char[] { this.charSapce });
                if (strArray.Length > 0)
                {
                    region.CategoryLevel = ((strArray.Length + 1) / 2) + 1;
                    if (region.CategoryLevel >= 4)
                    {
                        MessageBox.Show("区域分类为三级分类!");
                        return;
                    }
                }
                else
                {
                    region.CategoryLevel = 2;
                }
            }
            region.FatherID = Convert.ToInt32(this.DropDownListFatherCateGory.SelectedValue);
            region.Family = string.Empty;
            region.CreateUser = "admin";
            region.CreateTime = DateTime.Now;
            region.ModifyUser = "admin";
            region.ModifyTime = DateTime.Now;
            region.IsDeleted = "0";
            if (action.Add(region) > 0)
            {
                this.method_10();
                this.MessageShow.ShowMessage("AddYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!base.IsPostBack)
            {
                this.BindData();
                if (this.hiddenFieldGuid.Value != "0")
                {
                    this.LabelTitle.Text = "编辑区域";
                    this.method_8();
                }
                else
                {
                    this.TextBoxOrderID.Text = Convert.ToString((int)(this.method_7() + 1));
                }
            }
        }
    }
}