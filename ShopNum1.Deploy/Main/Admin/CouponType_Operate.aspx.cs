using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CouponType_Operate : PageBase, IRequiresSessionState
    {
        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_Shop_CouponType type;
            Shop_CouponType_Action action;
            ShopNum1_OperateLog log;
            if (ButtonConfirm.ToolTip == "Submit")
            {
                type = new ShopNum1_Shop_CouponType
                    {
                        Name = TextBoxName.Text.Trim(),
                        OrderID = int.Parse(TextBoxOrderID.Text.Trim()),
                        Comment = TextBoxDescription.Text.Trim()
                    };
                if (CheckBoxIsShow.Checked)
                {
                    type.IsShow = 1;
                }
                else
                {
                    type.IsShow = 0;
                }
                type.CreateUser = base.ShopNum1LoginID;
                type.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                type.IsDeleted = 0;
                action = (Shop_CouponType_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_CouponType_Action();
                if (action.Add(type) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "新增优惠券分类",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "CouponType_Operate.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    MessageShow.ShowMessage("AddYes");
                    MessageShow.Visible = true;
                    method_5();
                }
                else
                {
                    MessageShow.ShowMessage("AddNo");
                    MessageShow.Visible = true;
                }
            }
            else if (ButtonConfirm.ToolTip == "Update")
            {
                type = new ShopNum1_Shop_CouponType
                    {
                        Name = TextBoxName.Text.Trim(),
                        OrderID = int.Parse(TextBoxOrderID.Text.Trim()),
                        Comment = TextBoxDescription.Text.Trim()
                    };
                if (CheckBoxIsShow.Checked)
                {
                    type.IsShow = 1;
                }
                else
                {
                    type.IsShow = 0;
                }
                type.ModifyUser = base.ShopNum1LoginID;
                type.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                type.id = int.Parse(hiddenFieldGuid.Value.Replace("'", ""));
                action = (Shop_CouponType_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_CouponType_Action();
                if (action.Update(type) > 0)
                {
                    log = new ShopNum1_OperateLog
                        {
                            Record = "修改优惠券分类",
                            OperatorID = base.ShopNum1LoginID,
                            IP = Globals.IPAddress,
                            PageName = "CouponType_Operate.aspx",
                            Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        };
                    base.OperateLog(log);
                    base.Response.Redirect("CouponType_List.aspx");
                }
                else
                {
                    MessageShow.ShowMessage("EditNo");
                    MessageShow.Visible = true;
                }
            }
        }

        protected void GetEditInfo()
        {
            DataTable table =
                ((Shop_CouponType_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_CouponType_Action()).search(
                    int.Parse(hiddenFieldGuid.Value.Replace("'", "")), -1);
            if ((table != null) && (table.Rows.Count > 0))
            {
                TextBoxName.Text = table.Rows[0]["Name"].ToString();
                TextBoxOrderID.Text = table.Rows[0]["OrderID"].ToString();
                TextBoxDescription.Text = table.Rows[0]["Comment"].ToString();
                if (table.Rows[0]["IsShow"].ToString() == "1")
                {
                    CheckBoxIsShow.Checked = true;
                }
                else
                {
                    CheckBoxIsShow.Checked = false;
                }
            }
            ButtonConfirm.ToolTip = "Update";
            LabelPageTitle.Text = "编辑优惠券分类";
        }

        protected void GetOrderID()
        {
            string columnName = "OrderID";
            string tableName = "ShopNum1_Shop_CouponType";
            TextBoxOrderID.Text = Convert.ToString((1 + ShopNum1_Common_Action.ReturnMaxID(columnName, tableName)));
        }

        private void method_5()
        {
            TextBoxName.Text = string.Empty;
            TextBoxDescription.Text = string.Empty;
            CheckBoxIsShow.Checked = true;
            GetOrderID();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"];
            if (!Page.IsPostBack)
            {
                if (hiddenFieldGuid.Value != "0")
                {
                    GetEditInfo();
                    ButtonConfirm.Text = "更新";
                }
                else
                {
                    GetOrderID();
                }
            }
        }
    }
}