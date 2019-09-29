using System;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Link_Manage : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            num1GridViewShow.DataBind();
        }

        protected void BindIsShow()
        {
            var item = new ListItem
                {
                    Text = "-ȫ��-",
                    Value = "-1"
                };
            DropDownListIsShow.Items.Add(item);
            var item2 = new ListItem
                {
                    Text = "����ʾ",
                    Value = "0"
                };
            DropDownListIsShow.Items.Add(item2);
            var item3 = new ListItem
                {
                    Text = "��ʾ",
                    Value = "1"
                };
            DropDownListIsShow.Items.Add(item3);
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("Link_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Link_Action) LogicFactory.CreateShopNum1_Link_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "ɾ���������ӳɹ�",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Link_Manage.aspx",
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
            var action = (ShopNum1_Link_Action) LogicFactory.CreateShopNum1_Link_Action();
            if (action.Delete(guids) > 0)
            {
                var operateLog = new ShopNum1_OperateLog
                    {
                        Record = "ɾ���������ӳɹ�",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Link_Manage.aspx",
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
            base.Response.Redirect("Link_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string ChangeImgType(string strImgType)
        {
            if (strImgType == "0")
            {
                return "����ͼƬ";
            }
            if (strImgType == "1")
            {
                return "Զ��ͼƬ";
            }
            return "";
        }

        public string ChangeIsShow(string strIsShow)
        {
            if (strIsShow == "0")
            {
                return "����ʾ";
            }
            if (strIsShow == "1")
            {
                return "��ʾ";
            }
            return "";
        }

        public string ChangeLinkType(string strLinkType)
        {
            if (strLinkType == "0")
            {
                return "��������";
            }
            if (strLinkType == "1")
            {
                return "ͼƬ����";
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                BindIsShow();
                BindGrid();
            }
        }
    }
}