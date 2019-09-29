using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopVedioChecked_List : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!base.IsPostBack)
            {
                BindData();
                method_6();
            }
        }

        protected void ButtonAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Vedio_List_Action) LogicFactory.CreateShopNum1_Vedio_List_Action();
            if (action.UpdateAudit(CheckGuid.Value, 1) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Ա���ͨ��������Ƶ",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopVedioChecked_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                method_6();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonCancelAudit_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Vedio_List_Action) LogicFactory.CreateShopNum1_Vedio_List_Action();
            if (action.UpdateAudit(CheckGuid.Value, 2) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Ա��˲�ͨ��������Ƶ",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopVedioChecked_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                method_6();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            int num =
                ((ShopNum1_Vedio_List_Action) LogicFactory.CreateShopNum1_Vedio_List_Action()).Delete(CheckGuid.Value);
            method_6();
            if (num > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Աɾ��������Ƶ���",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopVedioChecked_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                method_6();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_Vedio_List_Action) LogicFactory.CreateShopNum1_Vedio_List_Action();
            if (action.Delete(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Աɾ��������Ƶ���",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopVedioChecked_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                method_6();
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
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            method_6();
        }

        protected void ButtonSearchDetails_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopVedio_Details.aspx?guid=" + CheckGuid.Value);
        }

        public string ChangeIsAudit(object strIsAudit)
        {
            if (strIsAudit.ToString() == "0")
            {
                return "δ���";
            }
            if (strIsAudit.ToString() == "1")
            {
                return "��ͨ��";
            }
            if (strIsAudit.ToString() == "2")
            {
                return "���δͨ��";
            }
            if (strIsAudit.ToString() == "3")
            {
                return "��ֹ";
            }
            return "�Ƿ�״̬";
        }

        private void BindData()
        {
            DropDownListIsAudit.Items.Clear();
            var item = new ListItem
                {
                    Text = "-ȫ��-",
                    Value = "-2"
                };
            DropDownListIsAudit.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "���δͨ��",
                    Value = "2"
                };
            DropDownListIsAudit.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "δ���",
                    Value = "0"
                };
            DropDownListIsAudit.Items.Add(item3);
        }

        private void method_6()
        {
            Num1GridViewShow.DataBind();
        }


    }
}