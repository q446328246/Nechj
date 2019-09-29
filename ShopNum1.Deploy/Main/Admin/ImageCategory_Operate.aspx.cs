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
    public partial class ImageCategory_Operate : PageBase, IRequiresSessionState
    {
        protected char charSapce = '　';

        protected string strSapce = "　　";

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (!method_5())
            {
                MessageBox.Show("分类名称不能和上级分类重复!");
            }
            else
            {
                string str;
                string str3;
                string str4;
                string selectedValue;
                string str6;
                string[] strArray;
                int num;
                ShopNum1_ImageCategory_Action action;
                ShopNum1_OperateLog log;
                if (ButtonConfirm.ToolTip == "Submit")
                {
                    str = "";
                    str3 = TextBoxName.Text.Trim();
                    str4 = TextBoxDescription.Text.Trim();
                    selectedValue = DropDownListFatherID.SelectedValue;
                    str6 = "admin";
                    if (DropDownListFatherID.SelectedValue == "0")
                    {
                        num = 1;
                    }
                    else
                    {
                        strArray = DropDownListFatherID.SelectedItem.Text.Split(new[] { charSapce });
                        if (strArray.Length > 0)
                        {
                            num = ((strArray.Length + 1) / 2) + 1;
                        }
                        else
                        {
                            num = 2;
                        }
                    }
                    action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
                    if (action.Insert(str3, str4, num.ToString(), selectedValue, str, str6) > 0)
                    {
                        HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                        HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                        log = new ShopNum1_OperateLog
                            {
                                Record = "新增图片分类成功",
                                OperatorID = cookie2.Values["LoginID"].ToString(),
                                IP = Globals.IPAddress,
                                PageName = "ImageCategory_Operate.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script",
                                                   "<script>alert('添加成功！');window.parent.location.reload();</script>");
                        method_6();
                        method_9();
                    }
                    else
                    {
                        MessageShow.ShowMessage("AddNo");
                        MessageShow.Visible = true;
                    }
                }
                else if (ButtonConfirm.ToolTip == "Update")
                {
                    str = "";
                    string strid = hiddenGuid.Value;
                    str3 = TextBoxName.Text.Trim();
                    str4 = TextBoxDescription.Text.Trim();
                    selectedValue = DropDownListFatherID.SelectedValue;
                    str6 = "admin";
                    if (DropDownListFatherID.SelectedValue == "0")
                    {
                        num = 1;
                    }
                    else
                    {
                        strArray = DropDownListFatherID.SelectedItem.Text.Split(new[] { charSapce });
                        if (strArray.Length > 0)
                        {
                            num = ((strArray.Length + 1) / 2) + 1;
                        }
                        else
                        {
                            num = 2;
                        }
                    }
                    action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
                    if (action.Update(strid, str3, str4, num.ToString(), selectedValue, str, str6) > 0)
                    {
                        HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                        HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                        log = new ShopNum1_OperateLog
                            {
                                Record = "编辑图片分类成功",
                                OperatorID = cookie2.Values["LoginID"].ToString(),
                                IP = Globals.IPAddress,
                                PageName = "ImageCategory_Operate.aspx",
                                Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                            };
                        base.OperateLog(log);
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>window.parent.location.reload();</script>");
                    }
                    else
                    {
                        MessageShow.ShowMessage("EditNo");
                        MessageShow.Visible = true;
                    }
                }
            }
        }

        private bool method_5()
        {
            if (TextBoxName.Text.Trim() == DropDownListFatherID.SelectedItem.Text)
            {
                return false;
            }
            return true;
        }

        private void method_6()
        {
            DropDownListFatherID.Items.Clear();
            var item = new ListItem
                {
                    Text = "全部",
                    Value = "0"
                };
            DropDownListFatherID.Items.Add(item);
            var action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
            foreach (DataRow row in action.Search(0).DefaultView.Table.Rows)
            {
                var item2 = new ListItem
                    {
                        Text = row["Name"].ToString().Trim(),
                        Value = row["ID"].ToString().Trim()
                    };
                DropDownListFatherID.Items.Add(item2);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()));
                if (table.Rows.Count > 0)
                {
                    method_7(table);
                }
            }
        }

        private void method_7(DataTable dt)
        {
            var action = (ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action();
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
                DropDownListFatherID.Items.Add(item);
                DataTable table = action.Search(Convert.ToInt32(row["ID"].ToString().Trim()));
                if (table.Rows.Count > 0)
                {
                    method_7(table);
                }
            }
        }

        private void method_8()
        {
            DataTable table =
                ((ShopNum1_ImageCategory_Action)LogicFactory.CreateShopNum1_ImageCategory_Action()).SearchInfoByID(
                    hiddenGuid.Value);
            TextBoxName.Text = table.Rows[0]["Name"].ToString();
            ViewState["cName"] = TextBoxName.Text;
            DropDownListFatherID.SelectedValue = table.Rows[0]["FatherID"].ToString();
            TextBoxDescription.Text = table.Rows[0]["Description"].ToString();
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
            LabelPageTitle.Text = "编辑图片分类";
        }

        private void method_9()
        {
            TextBoxName.Text = string.Empty;
            DropDownListFatherID.SelectedValue = "0";
            TextBoxDescription.Text = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenGuid.Value = (base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"];
            if (!Page.IsPostBack)
            {
                method_6();
                if (hiddenGuid.Value != "0")
                {
                    method_8();
                    DropDownListFatherID.Enabled = false;
                }
            }
        }
    }
}