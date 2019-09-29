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
    public class S_UserDefinedColumnOperate : BaseShopWebControl
    {
        private Button btn_Back;
        private Button btn_Save;
        private HtmlInputCheckBox check_IsShow;
        private string skinFilename = "S_UserDefinedColumnOperate.ascx";
        private string string_1 = string.Empty;
        private HtmlInputText txt_AdLink;
        private HtmlInputText txt_MenuName;
        private HtmlInputText txt_OrderID;

        public S_UserDefinedColumnOperate()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public void Add()
        {
            if (txt_MenuName.Value == "")
            {
                MessageBox.Show("自定义栏目不能为空");
            }
            else if (txt_AdLink.Value == "")
            {
                MessageBox.Show("链接不能为空");
            }
            else
            {
                var column = new ShopNum1_Shop_UserDefinedColumn
                {
                    Guid = Guid.NewGuid()
                };
                if (check_IsShow.Checked)
                {
                    column.IsShow = 1;
                }
                else
                {
                    column.IsShow = 0;
                }
                column.IfOpen = 0;
                column.Name = txt_MenuName.Value.Trim();
                column.LinkAddress = txt_AdLink.Value.Trim();
                column.OrderID = Convert.ToInt32(txt_OrderID.Value);
                column.MemLoginID = base.MemLoginID;
                var action = (Shop_UserDefinedColumn_Action) LogicFactory.CreateShop_UserDefinedColumn_Action();
                if (action.AddUserDefinedColumn(column) > 0)
                {
                    Page.Response.Redirect("S_UserDefinedColumnList.aspx");
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (string_1 != "0")
            {
                Edit();
            }
            else
            {
                Add();
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_UserDefinedColumnList.aspx");
        }

        public void Edit()
        {
            if (txt_MenuName.Value == "")
            {
                MessageBox.Show("自定义栏目不能为空");
            }
            else if (txt_AdLink.Value == "")
            {
                MessageBox.Show("链接不能为空");
            }
            else
            {
                var column = new ShopNum1_Shop_UserDefinedColumn
                {
                    Guid = new Guid(string_1)
                };
                if (check_IsShow.Checked)
                {
                    column.IsShow = 1;
                }
                else
                {
                    column.IsShow = 0;
                }
                column.IfOpen = 0;
                column.Name = txt_MenuName.Value.Trim();
                column.LinkAddress = txt_AdLink.Value.Trim();
                column.OrderID = Convert.ToInt32(txt_OrderID.Value);
                var action = (Shop_UserDefinedColumn_Action) LogicFactory.CreateShop_UserDefinedColumn_Action();
                if (action.UpdateUserDefinedColumn(column) > 0)
                {
                    Page.Response.Redirect("S_UserDefinedColumnList.aspx");
                }
            }
        }

        public void GetEditInfo()
        {
            DataTable userDefinedColumn =
                ((Shop_UserDefinedColumn_Action) LogicFactory.CreateShop_UserDefinedColumn_Action())
                    .GetUserDefinedColumn(string_1);
            if (userDefinedColumn.Rows[0]["IsShow"].ToString() == "1")
            {
                check_IsShow.Checked = true;
            }
            else
            {
                check_IsShow.Checked = false;
            }
            txt_MenuName.Value = userDefinedColumn.Rows[0]["Name"].ToString();
            txt_AdLink.Value = userDefinedColumn.Rows[0]["LinkAddress"].ToString();
            txt_OrderID.Value = userDefinedColumn.Rows[0]["OrderID"].ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            txt_MenuName = (HtmlInputText) skin.FindControl("txt_MenuName");
            txt_AdLink = (HtmlInputText) skin.FindControl("txt_AdLink");
            txt_OrderID = (HtmlInputText) skin.FindControl("txt_OrderID");
            check_IsShow = (HtmlInputCheckBox) skin.FindControl("check_IsShow");
            btn_Save = (Button) skin.FindControl("btn_Save");
            btn_Save.Click += btn_Save_Click;
            btn_Back = (Button) skin.FindControl("btn_Back");
            btn_Back.Click += btn_Back_Click;
            string_1 = (Common.Common.ReqStr("guid") == "") ? "0" : Common.Common.ReqStr("Guid");
            if (string_1 != "0")
            {
                GetEditInfo();
            }
            else
            {
                txt_OrderID.Value = (BindData() + 1).ToString();
            }
        }

        private int BindData()
        {
            return Common.Common.ReturnMaxID("OrderID", "MemLoginID", base.MemLoginID, "ShopNum1_Shop_UserDefinedColumn");
        }
    }
}