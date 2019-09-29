using System;
using System.Collections;
using System.Data;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class City_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';
        protected string strSapce = "　　";

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_City_Action action;
            ShopNum1_City city;
            ShopNum1_OperateLog log;
            string[] strArray;
            if (this.ButtonConfirm.ToolTip == "Submit")
            {
                action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
                city = new ShopNum1_City
                {
                    CityName = this.TextBoxName.Text.Trim(),
                    FatherID = Convert.ToInt32(this.DropDownListFatherID.SelectedValue),
                    OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim()),
                    Letter = this.TextBoxLetter.Text.Trim(),
                    ShortName = this.TextBoxShortName.Text.Trim()
                };
                if (this.CheckBoxIsShow.Checked)
                {
                    city.IsShow = 1;
                }
                else
                {
                    city.IsShow = 0;
                }
                if (this.CheckBoxIsHot.Checked)
                {
                    city.IsHot = 1;
                }
                else
                {
                    city.IsHot = 0;
                }
                city.CreateUser = base.ShopNum1LoginID;
                city.CreateTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                city.ModifyUser = base.ShopNum1LoginID;
                city.ModifyTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                city.IsDeleted = 0;
                city.ID = action.GetMaxID();
                if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
                {
                    city.CategoryLevel = 1;
                }
                else
                {
                    strArray = this.DropDownListFatherID.SelectedItem.Text.Split(new char[] { this.charSapce });
                    if (strArray.Length > 0)
                    {
                        city.CategoryLevel = new int?(((strArray.Length + 1) / 2) + 1);
                    }
                    else
                    {
                        city.CategoryLevel = 2;
                    }
                }
                if (city.CategoryLevel >= 4)
                {
                    MessageBox.Show("城市分类级别数为3");
                }
                else if (action.Add(city) > 0)
                {
                    log = new ShopNum1_OperateLog
                    {
                        Record = "新增" + this.TextBoxName.Text.Trim() + "成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "City_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                    base.OperateLog(log);
                    this.MessageShow.ShowMessage("AddYes");
                    this.MessageShow.Visible = true;
                    this.method_6();
                    this.method_9();
                }
                else
                {
                    this.MessageShow.ShowMessage("AddNo");
                    this.MessageShow.Visible = true;
                }
            }
            else if (this.ButtonConfirm.ToolTip == "Update")
            {
                if (this.hiddenGuid.Value.ToString() == this.DropDownListFatherID.SelectedValue)
                {
                    this.MessageShow.ShowMessage("EditError");
                    this.MessageShow.Visible = true;
                }
                else
                {
                    action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
                    city = new ShopNum1_City
                    {
                        ID = Convert.ToInt32(this.hiddenGuid.Value.Replace("'", "")),
                        CityName = this.TextBoxName.Text.Trim(),
                        FatherID = Convert.ToInt32(this.DropDownListFatherID.SelectedValue),
                        OrderID = Convert.ToInt32(this.TextBoxOrderID.Text.Trim()),
                        Letter = this.TextBoxLetter.Text.Trim()
                    };
                    if (this.CheckBoxIsShow.Checked)
                    {
                        city.IsShow = 1;
                    }
                    else
                    {
                        city.IsShow = 0;
                    }
                    if (this.CheckBoxIsHot.Checked)
                    {
                        city.IsHot = 1;
                    }
                    else
                    {
                        city.IsHot = 0;
                    }
                    city.ModifyUser = base.ShopNum1LoginID;
                    city.ModifyTime = new DateTime?(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    city.IsDeleted = 0;
                    if (this.DropDownListFatherID.SelectedValue.ToString() == "0")
                    {
                        city.CategoryLevel = 1;
                    }
                    else
                    {
                        strArray = this.DropDownListFatherID.SelectedItem.Text.Split(new char[] { this.charSapce });
                        if (strArray.Length > 0)
                        {
                            city.CategoryLevel = new int?(((strArray.Length + 1) / 2) + 1);
                        }
                        else
                        {
                            city.CategoryLevel = 2;
                        }
                    }
                    if (city.CategoryLevel >= 4)
                    {
                        MessageBox.Show("商品分类级别数为3");
                    }
                    else if (this.method_5(city.ID.ToString(), city.FatherID.ToString()))
                    {
                        MessageBox.Show("无法使用该父分类");
                    }
                    else if (action.Update(city) > 0)
                    {
                        log = new ShopNum1_OperateLog
                        {
                            Record = "编辑" + this.TextBoxName.Text.Trim() + "成功",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "City_Operate.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                        base.OperateLog(log);
                        base.Response.Redirect("City_List.aspx");
                    }
                    else
                    {
                        this.MessageShow.ShowMessage("EditNo");
                        this.MessageShow.Visible = true;
                    }
                }
            }
        }

        protected void GetOrderID()
        {
        }

        private bool method_5(string string_4, string string_5)
        {
            bool flag = false;
            ShopNum1_City_Action action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
            //using ()
            //{
            IEnumerator enumerator = action.CheckIsChilds("ID", "ShopNum1_City", string_4).Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow)enumerator.Current;
                    if (string_5.ToString() == current[0].ToString())
                    {
                        goto Label_0062;
                    }
                }
                return flag;
            Label_0062:
                flag = true;
            //}
            return flag;
        }

        private void method_6()
        {
            this.DropDownListFatherID.Items.Clear();
            ListItem item = new ListItem
            {
                Text = " -请选择-",//LocalizationUtil.GetCommonMessage("Select"),
                Value = "0"
            };
            this.DropDownListFatherID.Items.Add(item);
            ShopNum1_City_Action action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
            DataView defaultView = action.Search(0, 0).DefaultView;
            if (defaultView != null)
            {
                foreach (DataRow row in defaultView.Table.Rows)
                {
                    DataTable table;
                    ListItem item2 = new ListItem();
                    if (row["FatherID"].ToString().Trim() == "0")
                    {
                        item2.Text = row["CityName"].ToString().Trim();
                        item2.Value = row["ID"].ToString().Trim();
                        this.DropDownListFatherID.Items.Add(item2);
                        table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                        if (table.Rows.Count > 0)
                        {
                            this.method_7(table);
                        }
                    }
                    else
                    {
                        table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                        if (table.Rows.Count > 0)
                        {
                            this.method_7(table);
                        }
                        else
                        {
                            item2.Text = "├ " + row["CityName"].ToString().Trim();
                            item2.Value = row["ID"].ToString().Trim();
                            this.DropDownListFatherID.Items.Add(item2);
                        }
                    }
                }
            }
        }

        private void method_7(DataTable dt)
        {
            ShopNum1_City_Action action = (ShopNum1_City_Action)LogicFactory.CreateShopNum1_City_Action();
            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                string str = string.Empty;
                for (int i = 0; i < (Convert.ToInt32(row["CategoryLevel"].ToString()) - 1); i++)
                {
                    str = str + this.strSapce;
                }
                str = str + this.charSapce.ToString() + row["CityName"].ToString().Trim();
                item.Text = str;
                item.Value = row["ID"].ToString().Trim();
                this.DropDownListFatherID.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()), 0);
                if (table.Rows.Count > 0)
                {
                    this.method_7(table);
                }
            }
        }

        private void method_8()
        {
            DataTable table = new ShopNum1_City_Action().SearchInfoByID(this.hiddenGuid.Value.ToString());
            this.TextBoxName.Text = table.Rows[0]["CityName"].ToString();
            this.TextBoxOrderID.Text = table.Rows[0]["OrderID"].ToString();
            this.TextBoxLetter.Text = table.Rows[0]["Letter"].ToString().Replace(" ", "");
            if (table.Rows[0]["IsHot"].ToString() == "0")
            {
                this.CheckBoxIsHot.Checked = false;
            }
            else
            {
                this.CheckBoxIsHot.Checked = true;
            }
            if (table.Rows[0]["IsShow"].ToString() == "0")
            {
                this.CheckBoxIsShow.Checked = false;
            }
            else
            {
                this.CheckBoxIsShow.Checked = true;
            }
            this.TextBoxShortName.Text = table.Rows[0]["ShortName"].ToString();
            this.ButtonConfirm.Text = "更新";
            this.ButtonConfirm.ToolTip = "Update";
            this.LabelPageTitle.Text = "编辑商品分类";
        }

        private void method_9()
        {
            this.TextBoxName.Text = string.Empty;
            this.TextBoxOrderID.Text = string.Empty;
            this.DropDownListFatherID.SelectedValue = "0";
            this.TextBoxLetter.Text = string.Empty;
            this.CheckBoxIsShow.Checked = true;
            this.GetOrderID();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenGuid.Value = (base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"];
            if (!this.Page.IsPostBack)
            {
                this.method_6();
                this.GetOrderID();
                if (this.hiddenGuid.Value != "0")
                {
                    this.method_8();
                }
            }
        }
    }
}