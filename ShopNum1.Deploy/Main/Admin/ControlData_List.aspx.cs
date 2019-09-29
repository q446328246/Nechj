using System;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ControlData_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            num1GridiewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("ControlData_Operate.aspx?guid=" + CheckGuid.Value + "&&ControlGuid=" +
                                   hiddenFieldGuid.Value);
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InfoControl_List.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ControlData_Action) LogicFactory.CreateShopNum1_ControlData_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "删除成功",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ControlData_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ControlData_Operate.aspx?guid=" + CheckGuid.Value + "&&ControlGuid=" +
                                   hiddenFieldGuid.Value);
        }

        public string ChangeDataType(object strType)
        {
            if (strType.ToString() == "1")
            {
                return "文字";
            }
            if (strType.ToString() == "2")
            {
                return "图片";
            }
            if (strType.ToString() == "3")
            {
                return "商品";
            }
            if (strType.ToString() == "4")
            {
                return "Flash";
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                        ? "0"
                                        : base.Request.QueryString["guid"].Replace("'", "");
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }
    }
}