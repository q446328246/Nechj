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
    public partial class ServiceOnLineService_Operate : PageBase, IRequiresSessionState
    {
        protected void Add()
        {
            var onlineservice = new ShopNum1_OnlineService
                {
                    Guid = Guid.NewGuid(),
                    Type = DropDownListType.SelectedValue,
                    Name = TextBoxName.Text.Trim(),
                    ServiceAccount = TextBoxServiceAccount.Text.Trim(),
                    OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim()),
                    Location = "-1"
                };
            if (CheckBoxIsShow.Checked)
            {
                onlineservice.IsShow = 1;
            }
            else
            {
                onlineservice.IsShow = 0;
            }
            onlineservice.CreateUser = "admin";
            onlineservice.CreateTime = DateTime.Now;
            onlineservice.ModifyUser = "admin";
            onlineservice.ModifyTime = DateTime.Now;
            onlineservice.IsDeleted = 0;
            var action = (ShopNum1_OnLineService_Action) LogicFactory.CreateShopNum1_OnLineService_Action();
            if (action.Add(onlineservice) > 0)
            {
                ClearControl();
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (ButtonConfirm.ToolTip == "Update")
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                log = new ShopNum1_OperateLog
                    {
                        Record = "客服管理信息修改成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ServiceOnLineService_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Edit();
            }
            else if (ButtonConfirm.ToolTip == "Submit")
            {
                  HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                    HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                    
                log = new ShopNum1_OperateLog
                    {
                        Record = "客服管理信息添加成功",
                        OperatorID = cookie2.Values["LoginID"].ToString(),
                        IP = Globals.IPAddress,
                        PageName = "ServiceOnLineService_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        protected void ClearControl()
        {
            TextBoxServiceAccount.Text = string.Empty;
            TextBoxName.Text = string.Empty;
            DropDownListType.SelectedValue = "-1";
            TextBoxOrderID.Text = Convert.ToString((BindData() + 1));
        }

        protected void Edit()
        {
            var onlineservice = new ShopNum1_OnlineService
                {
                    Type = DropDownListType.SelectedValue,
                    Name = TextBoxName.Text.Trim(),
                    ServiceAccount = TextBoxServiceAccount.Text.Trim(),
                    OrderID = Convert.ToInt32(TextBoxOrderID.Text.Trim()),
                    Location = "-1"
                };
            if (CheckBoxIsShow.Checked)
            {
                onlineservice.IsShow = 1;
            }
            else
            {
                onlineservice.IsShow = 0;
            }
            onlineservice.ModifyUser = "admin";
            onlineservice.ModifyTime = DateTime.Now;
            onlineservice.IsDeleted = 0;
            var action = (ShopNum1_OnLineService_Action) LogicFactory.CreateShopNum1_OnLineService_Action();
            if (action.Update(hiddenFieldGuid.Value, onlineservice) > 0)
            {
                base.Response.Redirect("ServiceOnLineService_List.aspx");
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
                ((ShopNum1_OnLineService_Action) LogicFactory.CreateShopNum1_OnLineService_Action()).GetEditInfo(
                    hiddenFieldGuid.Value, 0);
            TextBoxName.Text = editInfo.Rows[0]["Name"].ToString();
            TextBoxOrderID.Text = editInfo.Rows[0]["OrderID"].ToString();
            TextBoxServiceAccount.Text = editInfo.Rows[0]["ServiceAccount"].ToString();
            if (editInfo.Rows[0]["IsShow"].ToString() == "1")
            {
                CheckBoxIsShow.Checked = true;
            }
            else
            {
                CheckBoxIsShow.Checked = false;
            }
            DropDownListType.SelectedValue = editInfo.Rows[0]["Type"].ToString();
            ButtonConfirm.Text = "更新";
            ButtonConfirm.ToolTip = "Update";
        }

        private int BindData()
        {
            return ShopNum1_Common_Action.ReturnMaxID("OrderID", "ShopNum1_OnlineService");
        }

        private void method_6()
        {
            var item = new ListItem
                {
                    Text = "-请选择-",
                    Value = "-1"
                };
            DropDownListType.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "在线QQ",
                    Value = "QQ"
                };
            DropDownListType.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "在线旺旺",
                    Value = "WW"
                };
            DropDownListType.Items.Add(item3);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!base.IsPostBack)
            {
                BindData();
                method_6();
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelTitle.Text = "编辑在线客服";
                    GetEditInfo();
                }
                else
                {
                    TextBoxOrderID.Text = Convert.ToString((BindData() + 1));
                }
            }
        }
    }
}