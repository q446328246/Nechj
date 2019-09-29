using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopArticleCommentAudit_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                CheckGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                BindStatus();
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            try
            {
                Num1GridViewShow.DataBind();
            }
            catch (Exception)
            {
            }
        }

        protected void BindStatus()
        {
            var item = new ListItem
                {
                    Text = "-ȫ��-",
                    Value = "-1"
                };
            DropDownListSIsReply.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "-ȫ��-",
                    Value = "-2"
                };
            DropDownListSIsAudit.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "δ�ظ�",
                    Value = "0"
                };
            DropDownListSIsReply.Items.Add(item3);
            var item4 = new ListItem
                {
                    Text = "�ѻظ�",
                    Value = "1"
                };
            DropDownListSIsReply.Items.Add(item4);
            var item5 = new ListItem
                {
                    Text = "δ���",
                    Value = "0"
                };
            DropDownListSIsAudit.Items.Add(item5);
            var item6 = new ListItem
                {
                    Text = "���δͨ��",
                    Value = "2"
                };
            DropDownListSIsAudit.Items.Add(item6);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopArticleComment_Action) LogicFactory.CreateShopNum1_ShopArticleComment_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Աɾ��������������",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopArticleCommentAudit_List.aspx",
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

        protected void ButtonDeleteBylink_Click(object sender, EventArgs e)
        {
            var button = (LinkButton) sender;
            string guids = "'" + button.CommandArgument + "'";
            var action = (ShopNum1_ShopArticleComment_Action) LogicFactory.CreateShopNum1_ShopArticleComment_Action();
            if (action.Delete(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Աɾ��������������",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopArticleCommentAudit_List.aspx",
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

        protected void ButtonIsAudit0_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopArticleComment_Action) LogicFactory.CreateShopNum1_ShopArticleComment_Action();
            if (action.UpdateAuditNew(CheckGuid.Value, 2) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Ա��˲�ͨ��������������",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopArticleCommentAudit_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
            BindGrid();
        }

        protected void ButtonIsAudit1_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_ShopArticleComment_Action) LogicFactory.CreateShopNum1_ShopArticleComment_Action();
            if (action.UpdateAuditNew(CheckGuid.Value, 1) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "����Ա���ͨ��������������",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopArticleCommentAudit_List.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(operateLog);
                BindGrid();
                MessageShow.ShowMessage("Audit2Yes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("Audit2No");
                MessageShow.Visible = true;
            }
            BindGrid();
        }

        protected void ButtonReply_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShopArticleComment_Operate.aspx?guid=" + CheckGuid.Value + "&Type=Audit");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string ChangeIsAudit(string strIsAudit)
        {
            if (strIsAudit == "1")
            {
                return "�����";
            }
            if (strIsAudit == "0")
            {
                return "δ���";
            }
            if (strIsAudit == "2")
            {
                return "���δͨ��";
            }
            return "�Ƿ�״̬";
        }

        public string ChangeIsReply(string strIsReply)
        {
            if (strIsReply == "0")
            {
                return "δ�ظ�";
            }
            if (strIsReply == "1")
            {
                return "�ѻظ�";
            }
            return "";
        }


    }
}